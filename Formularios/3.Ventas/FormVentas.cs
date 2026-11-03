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

namespace ventas_historial_VENTAS
{
    public partial class FormVentas : Form
    {
        private readonly string cadenaConexion = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=CentralCelDB;Integrated Security=True;";

        private DataTable dtDetalle;

        private int idSucursalSesion = 1;
        private int idUsuarioSesion = 1;

        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigurarTablaDetalle();
            CargarClientes();
            LimpiarFormulario();
        }

        #region Configuración Inicial

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

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = "SELECT IdCliente, Nombre FROM Clientes WHERE Activo = 1";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dtClientes = new DataTable();
                    adapter.Fill(dtClientes);

                    cboCliente.DataSource = dtClientes;
                    cboCliente.DisplayMember = "Nombre";
                    cboCliente.ValueMember = "IdCliente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nota al conectar con CentralCelDB: " + ex.Message, "Conexión BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Búsqueda y Selección de Productos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscarProducto.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un código o nombre para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string query = @"
                        SELECT p.IdProducto, p.Codigo, p.Nombre, p.PrecioVenta, 
                               ISNULL(e.StockActual, 0) AS Stock
                        FROM Productos p
                        LEFT JOIN Existencias e ON p.IdProducto = e.IdProducto AND e.IdSucursal = @idSucursal
                        WHERE (p.Codigo LIKE @criterio OR p.Nombre LIKE @criterio) 
                          AND p.Activo = 1";

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
                MessageBox.Show("Error al consultar Productos: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem != null && cboProducto.DataSource is DataTable dt)
            {
                DataRowView fila = (DataRowView)cboProducto.SelectedItem;
                txtDisponible.Text = fila["Stock"].ToString();
            }
        }

        #endregion

        #region Carrito y Cálculos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView fila = (DataRowView)cboProducto.SelectedItem;
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

        private void CalcularTotales()
        {
            decimal total = 0;
            foreach (DataRow row in dtDetalle.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal (Bs)"]);
            }

            lblTotalPagar.Text = $"Bs {total:N2}";
            CalcularCambio();
        }

        private void txtEfectivoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }

        private void CalcularCambio()
        {
            string totalTexto = lblTotalPagar.Text.Replace("Bs", "").Trim();
            if (decimal.TryParse(totalTexto, out decimal total) && decimal.TryParse(txtEfectivoRecibido.Text, out decimal efectivo))
            {
                decimal cambio = efectivo - total;
                txtCambio.Text = cambio >= 0 ? cambio.ToString("N2") : "0.00";
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }

        #endregion

        #region Confirmación de Venta (Transacción SQL)

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en el detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string totalTexto = lblTotalPagar.Text.Replace("Bs", "").Trim();
            decimal totalVenta = Convert.ToDecimal(totalTexto);

            if (!decimal.TryParse(txtEfectivoRecibido.Text, out decimal efectivo) || efectivo < totalVenta)
            {
                MessageBox.Show("El efectivo recibido es menor al total a pagar.", "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlTransaction transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            string numVenta = "VEN-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string formaPago = cboFormaPago.SelectedItem != null ? cboFormaPago.SelectedItem.ToString() : "Efectivo";

                            string queryVenta = @"
                                INSERT INTO Ventas (NumeroVenta, Fecha, IdSucursal, IdUsuario, IdCliente, FormaPago, MontoRecibido) 
                                VALUES (@numVenta, GETDATE(), @idSucursal, @idUsuario, @idCliente, @formaPago, @montoRecibido); 
                                SELECT SCOPE_IDENTITY();";

                            SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion);
                            cmdVenta.Parameters.AddWithValue("@numVenta", numVenta);
                            cmdVenta.Parameters.AddWithValue("@idSucursal", idSucursalSesion);
                            cmdVenta.Parameters.AddWithValue("@idUsuario", idUsuarioSesion);
                            cmdVenta.Parameters.AddWithValue("@idCliente", cboCliente.SelectedValue ?? DBNull.Value);
                            cmdVenta.Parameters.AddWithValue("@formaPago", formaPago);
                            cmdVenta.Parameters.AddWithValue("@montoRecibido", efectivo);

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
                                cmdStock.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            MessageBox.Show($"Venta {numVenta} registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Error al registrar venta en CentralCelDB: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            dtDetalle.Clear();
            txtBuscarProducto.Clear();
            cboProducto.DataSource = null;
            txtDisponible.Text = "0";
            numCantidad.Value = 1;
            txtEfectivoRecibido.Clear();
            txtCambio.Text = "0.00";
            lblTotalPagar.Text = "Bs 0,00";
        }

        #endregion

        #region Eventos auxiliares del Diseñador

        private void btnBuscarProducto_Click(object sender, EventArgs e) => btnBuscar_Click(sender, e);
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void btnGestionarClientes_Click(object sender, EventArgs e) { }
        private void cboFormaPago_SelectedIndexChanged(object sender, EventArgs e) { }
        private void chkVistaPrevia_CheckedChanged(object sender, EventArgs e) { }
        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtDisponible_TextChanged(object sender, EventArgs e) { }
        private void numCantidad_ValueChanged(object sender, EventArgs e) { }
        private void lblTotalPagar_Click(object sender, EventArgs e) { }
        private void txtCambio_TextChanged(object sender, EventArgs e) { }
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion
    }
}