using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralCel.Datos;

namespace ventas_historial_VENTAS
{
    public partial class FormVentas : Form
    {
        private DataTable dtDetalle;
        private int idSucursalSesion => UsuarioSesion.IdSucursal;
        private int idUsuarioSesion => UsuarioSesion.IdUsuario;
        private int idClienteSeleccionado = 0;
        private bool esNuevoCliente = true;
        private decimal totalPagar = 0;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigurarTablaDetalle();
            CargarClientesCombo();
            CargarClientesTabla();
            LimpiarFormulario();
            LimpiarFormularioCliente();
        }


        private void ConfigurarTablaDetalle()
        {
            dtDetalle = new DataTable();
            dtDetalle.Columns.Add("Código", typeof(string));
            dtDetalle.Columns.Add("Producto / variante", typeof(string));
            dtDetalle.Columns.Add("Cantidad", typeof(int));
            dtDetalle.Columns.Add("Precio (Bs)", typeof(decimal));
            dtDetalle.Columns.Add("Subtotal (Bs)", typeof(decimal));
            dtDetalle.Columns.Add("IdProducto", typeof(int));

            dgvDetalle.DataSource = dtDetalle;

            if (dgvDetalle.Columns["IdProducto"] != null)
                dgvDetalle.Columns["IdProducto"].Visible = false;

            if (dgvDetalle.Columns["Precio (Bs)"] != null)
                dgvDetalle.Columns["Precio (Bs)"].DefaultCellStyle.Format = "N2";
            if (dgvDetalle.Columns["Subtotal (Bs)"] != null)
                dgvDetalle.Columns["Subtotal (Bs)"].DefaultCellStyle.Format = "N2";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarClientesCombo()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "SELECT IdCliente, Nombre FROM Clientes WHERE Activo = 1";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dtClientes = new DataTable();
                    adapter.Fill(dtClientes);

                    cboCliente.DataSource = dtClientes;
                    cboCliente.DisplayMember = "Nombre";
                    cboCliente.ValueMember = "IdCliente";

                    if (dtClientes.Rows.Count == 0)
                    {
                        cboCliente.Text = "-- Sin Clientes --";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nota al conectar con CentralCelDB: " + ex.Message, "Conexión BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscarProducto.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un código o nombre para buscar el producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = @"
                        SELECT TOP 200 p.IdProducto, p.Codigo, p.Nombre, p.PrecioVenta, 
                               ISNULL(e.StockActual, 0) AS Stock
                        FROM Productos p
                        LEFT JOIN Existencias e ON p.IdProducto = e.IdProducto AND e.IdSucursal = @idSucursal
                        WHERE (p.Codigo LIKE @criterio OR p.Nombre LIKE @criterio) 
                          AND p.Activo = 1
                        ORDER BY p.Nombre";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idSucursal", idSucursalSesion);
                        cmd.Parameters.AddWithValue("@criterio", "%" + busqueda + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dtProductos = new DataTable();
                        adapter.Fill(dtProductos);

                        if (dtProductos.Rows.Count > 0)
                        {
                            cboProducto.DataSource = dtProductos;
                            cboProducto.DisplayMember = "Nombre";
                            cboProducto.ValueMember = "IdProducto";
                            cboProducto.SelectedIndex = 0;

                            txtDisponible.Text = dtProductos.Rows[0]["Stock"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron productos coincidentes.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cboProducto.DataSource = null;
                            txtDisponible.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar Productos en CentralCelDB: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e) => btnBuscar_Click(sender, e);

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is DataRowView fila && fila.Row.Table.Columns.Contains("Stock"))
            {
                txtDisponible.Text = fila["Stock"].ToString();
            }
            else
            {
                txtDisponible.Text = "0";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(cboProducto.SelectedItem is DataRowView fila))
            {
                MessageBox.Show("Busque y seleccione un producto válido primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(fila["IdProducto"]);
            string codigo = fila["Codigo"].ToString();
            string nombre = fila["Nombre"].ToString();
            int stockDisponible = Convert.ToInt32(fila["Stock"]);
            decimal precio = Convert.ToDecimal(fila["PrecioVenta"]);
            int cantidad = (int)numCantidad.Value;

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad > stockDisponible)
            {
                MessageBox.Show($"Stock insuficiente. Solo quedan {stockDisponible} unidades disponibles.", "Stock Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool existe = false;
            foreach (DataRow row in dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    int nuevaCantidad = Convert.ToInt32(row["Cantidad"]) + cantidad;
                    if (nuevaCantidad > stockDisponible)
                    {
                        MessageBox.Show($"No puede agregar más de {stockDisponible} unidades de este producto.", "Stock Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    row["Cantidad"] = nuevaCantidad;
                    row["Subtotal (Bs)"] = nuevaCantidad * precio;
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                decimal subtotal = cantidad * precio;
                dtDetalle.Rows.Add(codigo, nombre, cantidad, precio, subtotal, idProducto);
            }

            CalcularTotales();
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null && !dgvDetalle.CurrentRow.IsNewRow)
            {
                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
                CalcularTotales();
            }
        }

        private void btnVaciarDetalle_Click(object sender, EventArgs e)
        {
            dtDetalle.Clear();
            CalcularTotales();
        }


        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            if (dtDetalle == null) return;

            decimal subtotal = 0;
            foreach (DataRow row in dtDetalle.Rows)
            {
                subtotal += Convert.ToDecimal(row["Subtotal (Bs)"]);
            }

            decimal porcentajeImpuesto = 0;
            if (!string.IsNullOrWhiteSpace(txtImpuesto.Text))
            {
                decimal.TryParse(txtImpuesto.Text.Trim(), out porcentajeImpuesto);
            }

            decimal montoImpuesto = subtotal * (porcentajeImpuesto / 100m);
            totalPagar = Math.Round(subtotal + montoImpuesto, 2);

            lblTotalPagar.Text = $"BS: {totalPagar:N2}";
            CalcularCambio();
        }

        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }

        private void CalcularCambio()
        {
            if (decimal.TryParse(txtEfectivoRecibido.Text.Trim(), out decimal efectivo))
            {
                decimal cambio = efectivo - totalPagar;
                txtCambio.Text = cambio >= 0 ? cambio.ToString("N2") : "0.00";
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }


        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en el detalle de la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente para la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtEfectivoRecibido.Text.Trim(), out decimal efectivo) || efectivo < totalPagar)
            {
                MessageBox.Show("El efectivo recibido es menor al total a pagar.", "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtImpuesto.Text.Trim(), out decimal porcentajeImpuesto);

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            string numVenta = "VEN-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string formaPago = string.IsNullOrWhiteSpace(cboFormaPago.Text) ? "Efectivo" : cboFormaPago.Text.Trim();

                            string queryVenta = @"
                                INSERT INTO Ventas (NumeroVenta, Fecha, IdSucursal, IdUsuario, IdCliente, FormaPago, MontoRecibido, Impuesto) 
                                VALUES (@numVenta, GETDATE(), @idSucursal, @idUsuario, @idCliente, @formaPago, @montoRecibido, @impuesto); 
                                SELECT SCOPE_IDENTITY();";

                            SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion);
                            cmdVenta.Parameters.AddWithValue("@numVenta", numVenta);
                            cmdVenta.Parameters.AddWithValue("@idSucursal", idSucursalSesion);
                            cmdVenta.Parameters.AddWithValue("@idUsuario", idUsuarioSesion);
                            cmdVenta.Parameters.AddWithValue("@idCliente", cboCliente.SelectedValue);
                            cmdVenta.Parameters.AddWithValue("@formaPago", formaPago);
                            cmdVenta.Parameters.AddWithValue("@montoRecibido", efectivo);
                            cmdVenta.Parameters.AddWithValue("@impuesto", porcentajeImpuesto);

                            int idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                            foreach (DataRow fila in dtDetalle.Rows)
                            {
                                int idProducto = Convert.ToInt32(fila["IdProducto"]);
                                int cantidad = Convert.ToInt32(fila["Cantidad"]);
                                decimal precioUnitario = Convert.ToDecimal(fila["Precio (Bs)"]);

                                string queryDetalle = @"
                                    INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario) 
                                    VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario)";

                                SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion);
                                cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                                cmdDetalle.Parameters.AddWithValue("@idProducto", idProducto);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                                cmdDetalle.ExecuteNonQuery();

                                string queryExistencias = @"
                                    UPDATE Existencias 
                                    SET StockActual = StockActual - @cantidad 
                                    WHERE IdProducto = @idProducto AND IdSucursal = @idSucursal";

                                SqlCommand cmdStock = new SqlCommand(queryExistencias, conexion, transaccion);
                                cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdStock.Parameters.AddWithValue("@idProducto", idProducto);
                                cmdStock.Parameters.AddWithValue("@idSucursal", idSucursalSesion);
                                int filasStock = cmdStock.ExecuteNonQuery();

                                if (filasStock == 0)
                                {
                                    throw new Exception("El producto " + fila["Código"] + " no tiene existencias registradas en esta sucursal.");
                                }
                            }

                            transaccion.Commit();
                            MessageBox.Show($"Venta {numVenta} registrada con éxito en CentralCelDB.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarFormulario();
                        }
                        catch
                        {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta en la base de datos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            if (dtDetalle != null)
                dtDetalle.Clear();

            txtBuscarProducto.Clear();
            cboProducto.DataSource = null;
            txtDisponible.Text = "0";
            numCantidad.Value = 1;
            txtImpuesto.Text = "0";
            txtEfectivoRecibido.Clear();
            txtCambio.Text = "0.00";
            totalPagar = 0;
            lblTotalPagar.Text = "BS: 0,00";
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            TabVentas.SelectedIndex = 1;
        }

        private void CargarClientesTabla(string filtro = "")
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = @"SELECT 
                                        IdCliente AS [Código], 
                                        Nombre AS [Nombre o razón social], 
                                        Documento AS [Documento], 
                                        Telefono AS [Teléfono], 
                                        Correo AS [Correo electrónico], 
                                        Direccion AS [Dirección], 
                                        CASE WHEN Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado] 
                                     FROM Clientes";

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query += " WHERE Nombre LIKE @filtro OR Documento LIKE @filtro";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvClientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clientes: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioCliente()
        {
            txtCodigoCliente.Clear();
            txtNombreCliente.Clear();
            txtDocumentoCliente.Clear();
            txtTelefonoCliente.Clear();
            txtCorreoCliente.Clear();
            txtDireccionCliente.Clear();
            chkActivoCliente.Checked = true;
            idClienteSeleccionado = 0;
            esNuevoCliente = true;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];

                idClienteSeleccionado = Convert.ToInt32(row.Cells["Código"].Value);
                txtCodigoCliente.Text = "CLI" + idClienteSeleccionado.ToString("D3");
                txtNombreCliente.Text = row.Cells["Nombre o razón social"].Value?.ToString();
                txtDocumentoCliente.Text = row.Cells["Documento"].Value?.ToString();
                txtTelefonoCliente.Text = row.Cells["Teléfono"].Value?.ToString();
                txtCorreoCliente.Text = row.Cells["Correo electrónico"].Value?.ToString();
                txtDireccionCliente.Text = row.Cells["Dirección"].Value?.ToString();

                string estadoStr = row.Cells["Estado"].Value?.ToString();
                chkActivoCliente.Checked = (estadoStr == "Activo");

                esNuevoCliente = false;
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCliente();
            txtNombreCliente.Focus();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("El nombre o razón social es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
                return;
            }

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmd;

                    if (esNuevoCliente || idClienteSeleccionado == 0)
                    {
                        string queryInsert = @"INSERT INTO Clientes (Codigo, Nombre, Documento, Telefono, Correo, Direccion, Activo) 
                                               VALUES ('CLI' + RIGHT('000' + CAST((SELECT ISNULL(MAX(IdCliente), 0) + 1 FROM Clientes) AS NVARCHAR(10)), 3),
                                                       @nombre, @documento, @telefono, @correo, @direccion, @activo);
                                               SELECT SCOPE_IDENTITY();";
                        cmd = new SqlCommand(queryInsert, conexion);
                    }
                    else
                    {
                        string queryUpdate = @"UPDATE Clientes 
                                               SET Nombre = @nombre, Documento = @documento, Telefono = @telefono, 
                                                   Correo = @correo, Direccion = @direccion, Activo = @activo 
                                               WHERE IdCliente = @id";
                        cmd = new SqlCommand(queryUpdate, conexion);
                        cmd.Parameters.AddWithValue("@id", idClienteSeleccionado);
                    }

                    cmd.Parameters.AddWithValue("@nombre", txtNombreCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@documento", string.IsNullOrWhiteSpace(txtDocumentoCliente.Text) ? (object)DBNull.Value : txtDocumentoCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", string.IsNullOrWhiteSpace(txtTelefonoCliente.Text) ? (object)DBNull.Value : txtTelefonoCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(txtCorreoCliente.Text) ? (object)DBNull.Value : txtCorreoCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", string.IsNullOrWhiteSpace(txtDireccionCliente.Text) ? (object)DBNull.Value : txtDireccionCliente.Text.Trim());
                    cmd.Parameters.AddWithValue("@activo", chkActivoCliente.Checked ? 1 : 0);

                    if (esNuevoCliente || idClienteSeleccionado == 0)
                    {
                        int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                        idClienteSeleccionado = nuevoId;
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente guardado correctamente en CentralCelDB.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientesTabla();
                    CargarClientesCombo();

                    if (idClienteSeleccionado > 0)
                    {
                        cboCliente.SelectedValue = idClienteSeleccionado;
                    }

                    LimpiarFormularioCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente en la base de datos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsarClienteVenta_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado > 0)
            {
                CargarClientesCombo();
                cboCliente.SelectedValue = idClienteSeleccionado;
                TabVentas.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Selecciona un cliente de la lista antes de presionar 'Usar cliente en la venta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            CargarClientesTabla(txtBuscarCliente.Text.Trim());
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Clear();
            CargarClientesTabla();
        }

        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCliente();
        }

        private void btnDesactivarCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente de la lista para modificar su estado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "UPDATE Clientes SET Activo = CASE WHEN Activo = 1 THEN 0 ELSE 1 END WHERE IdCliente = @id";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", idClienteSeleccionado);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Estado del cliente actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormularioCliente();
                    CargarClientesTabla();
                    CargarClientesCombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del cliente: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void cboFormaPago_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkVistaPrevia_CheckedChanged(object sender, EventArgs e) { }
        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtDisponible_TextChanged(object sender, EventArgs e) { }
        private void numCantidad_ValueChanged(object sender, EventArgs e) { }
        private void lblTotalPagar_Click(object sender, EventArgs e) { }
        private void txtCambio_TextChanged(object sender, EventArgs e) { }
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
    }
}