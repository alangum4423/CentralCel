using CentralCel.Datos;
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
using System.Net;
using System.Net.Mail;

namespace ventas_historial_VENTAS.Formularios._3.Ventas
{
    public partial class FormHistorialVentas : Form
    {
        private int idVentaSeleccionada = 0;
        private string numVentaSeleccionada = "";

        public FormHistorialVentas()
        {
            InitializeComponent();
        }

        private void FormHistorialVentas_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;

            dgvHistorialVentas.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToAddRows = false;

            if (UsuarioSesion.Rol != "Administrador" && UsuarioSesion.Rol != "Superadministrador")
            {
                btnAnularVenta.Enabled = false;
            }

            CargarFiltros();
            CargarHistorialVentas();
            LimpiarResumen();
        }


        private void CargarFiltros()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();

                    cboEstado.Items.Clear();
                    cboEstado.Items.Add("Todas");
                    cboEstado.Items.Add("Confirmada");
                    cboEstado.Items.Add("Anulada");
                    cboEstado.SelectedIndex = 0;

                    SqlDataAdapter daSuc = new SqlDataAdapter("SELECT IdSucursal, Nombre FROM Sucursales", con);
                    DataTable dtSuc = new DataTable();
                    daSuc.Fill(dtSuc);

                    DataRow drSuc = dtSuc.NewRow();
                    drSuc["IdSucursal"] = 0;
                    drSuc["Nombre"] = "Todas";
                    dtSuc.Rows.InsertAt(drSuc, 0);

                    cboSucursal.DataSource = dtSuc;
                    cboSucursal.DisplayMember = "Nombre";
                    cboSucursal.ValueMember = "IdSucursal";

                    SqlDataAdapter daUsu = new SqlDataAdapter("SELECT IdUsuario, NombreCompleto FROM Usuarios", con);
                    DataTable dtUsu = new DataTable();
                    daUsu.Fill(dtUsu);

                    DataRow drUsu = dtUsu.NewRow();
                    drUsu["IdUsuario"] = 0;
                    drUsu["NombreCompleto"] = "Todos";
                    dtUsu.Rows.InsertAt(drUsu, 0);

                    cboVendedor.DataSource = dtUsu;
                    cboVendedor.DisplayMember = "Nombres";
                    cboVendedor.ValueMember = "IdUsuario";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar filtros: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialVentas()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            v.IdVenta,
                            v.Impuesto,
                            v.NumeroVenta AS [Venta],
                            v.Fecha AS [Fecha],
                            s.Nombre AS [Sucursal],
                            u.Nombres AS [Vendedor],
                            c.Nombre AS [Cliente],
                            v.FormaPago AS [Forma Pago],
                            v.MontoRecibido AS [Recibido (Bs)],
                            CASE WHEN v.FechaAnulacion IS NULL THEN 'Confirmada' ELSE 'Anulada' END AS [Estado]
                        FROM Ventas v
                        LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                        LEFT JOIN Sucursales s ON v.IdSucursal = s.IdSucursal
                        LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                        WHERE v.Fecha BETWEEN @fechaDesde AND @fechaHasta";

                    if (!string.IsNullOrWhiteSpace(txtBuscarVenta.Text))
                    {
                        query += " AND (v.NumeroVenta LIKE @busqueda OR c.Nombre LIKE @busqueda)";
                    }

                    if (cboEstado.SelectedItem != null)
                    {
                        string estado = cboEstado.SelectedItem.ToString();
                        if (estado == "Confirmada")
                            query += " AND v.FechaAnulacion IS NULL";
                        else if (estado == "Anulada")
                            query += " AND v.FechaAnulacion IS NOT NULL";
                    }

                    if (cboSucursal.SelectedValue != null && Convert.ToInt32(cboSucursal.SelectedValue) > 0)
                    {
                        query += " AND v.IdSucursal = @idSucursal";
                    }

                    if (cboVendedor.SelectedValue != null && Convert.ToInt32(cboVendedor.SelectedValue) > 0)
                    {
                        query += " AND v.IdUsuario = @idUsuario";
                    }

                    query += " ORDER BY v.Fecha DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fechaDesde", dtpDesde.Value.Date);
                        cmd.Parameters.AddWithValue("@fechaHasta", dtpHasta.Value.Date.AddDays(1).AddSeconds(-1));

                        if (!string.IsNullOrWhiteSpace(txtBuscarVenta.Text))
                            cmd.Parameters.AddWithValue("@busqueda", "%" + txtBuscarVenta.Text.Trim() + "%");

                        if (cboSucursal.SelectedValue != null && Convert.ToInt32(cboSucursal.SelectedValue) > 0)
                            cmd.Parameters.AddWithValue("@idSucursal", Convert.ToInt32(cboSucursal.SelectedValue));

                        if (cboVendedor.SelectedValue != null && Convert.ToInt32(cboVendedor.SelectedValue) > 0)
                            cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(cboVendedor.SelectedValue));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvHistorialVentas.DataSource = dt;

                        if (dgvHistorialVentas.Columns["IdVenta"] != null)
                            dgvHistorialVentas.Columns["IdVenta"].Visible = false;
                        if (dgvHistorialVentas.Columns["Impuesto"] != null)
                            dgvHistorialVentas.Columns["Impuesto"].Visible = false;
                        if (dgvHistorialVentas.Columns["Recibido (Bs)"] != null)
                            dgvHistorialVentas.Columns["Recibido (Bs)"].DefaultCellStyle.Format = "N2";

                        dgvHistorialVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



                        if (dgvHistorialVentas.Rows.Count > 0)
                        {
                            dgvHistorialVentas.Rows[0].Selected = true;
                            idVentaSeleccionada = Convert.ToInt32(dgvHistorialVentas.Rows[0].Cells["IdVenta"].Value);
                            numVentaSeleccionada = dgvHistorialVentas.Rows[0].Cells["Venta"].Value?.ToString();
                            CargarDetalleVenta(idVentaSeleccionada);
                        }
                        else
                        {
                            LimpiarResumen();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial de ventas: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDetalleVenta(int idVenta)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            p.Codigo AS [Código],
                            p.Nombre AS [Producto],
                            dv.Cantidad AS [Cantidad],
                            dv.PrecioUnitario AS [Precio (Bs)],
                            (dv.Cantidad * dv.PrecioUnitario) AS [Subtotal (Bs)]
                        FROM DetalleVenta dv
                        INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                        WHERE dv.IdVenta = @idVenta";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvDetalleVenta.DataSource = dt;

                        if (dgvDetalleVenta.Columns["Precio (Bs)"] != null)
                            dgvDetalleVenta.Columns["Precio (Bs)"].DefaultCellStyle.Format = "N2";
                        if (dgvDetalleVenta.Columns["Subtotal (Bs)"] != null)
                            dgvDetalleVenta.Columns["Subtotal (Bs)"].DefaultCellStyle.Format = "N2";

                        dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        decimal subtotal = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            subtotal += Convert.ToDecimal(row["Subtotal (Bs)"]);
                        }

                        ActualizarResumen(subtotal);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la venta: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumen(decimal subtotal)
        {
            if (dgvHistorialVentas.CurrentRow == null) return;

            DataGridViewRow row = dgvHistorialVentas.CurrentRow;

            string formaPago = row.Cells["Forma Pago"].Value?.ToString() ?? "Efectivo";

            decimal.TryParse(Convert.ToString(row.Cells["Recibido (Bs)"].Value), out decimal recibido);
            decimal.TryParse(Convert.ToString(row.Cells["Impuesto"].Value), out decimal impuesto);

            decimal totalVenta = Math.Round(subtotal * (1 + impuesto / 100m), 2);

            decimal cambio = recibido - totalVenta;
            if (cambio < 0) cambio = 0;

            lblResumenTotal.Text = $"Bs {totalVenta:N2}";
            lblResumenPago.Text = formaPago;
            lblResumenRecibido.Text = $"Bs {recibido:N2}";
            lblResumenCambio.Text = $"Bs {cambio:N2}";
        }

        private void LimpiarResumen()
        {
            lblResumenTotal.Text = "Bs 0.00";
            lblResumenPago.Text = "-";
            lblResumenRecibido.Text = "Bs 0.00";
            lblResumenCambio.Text = "Bs 0.00";
            idVentaSeleccionada = 0;
            numVentaSeleccionada = "";

            if (dgvDetalleVenta.DataSource is DataTable dt)
            {
                dt.Clear();
            }
        }

        private void dgvHistorialVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHistorialVentas.Rows[e.RowIndex];
                idVentaSeleccionada = Convert.ToInt32(row.Cells["IdVenta"].Value);
                numVentaSeleccionada = row.Cells["Venta"].Value?.ToString();

                CargarDetalleVenta(idVentaSeleccionada);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarHistorialVentas();
            LimpiarResumen();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarVenta.Clear();
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboSucursal.Items.Count > 0) cboSucursal.SelectedIndex = 0;
            if (cboVendedor.Items.Count > 0) cboVendedor.SelectedIndex = 0;

            CargarHistorialVentas();
            LimpiarResumen();
        }

        private void btnAnularVenta_Click(object sender, EventArgs e)
        {
            if (UsuarioSesion.Rol != "Administrador" && UsuarioSesion.Rol != "Superadministrador")
            {
                MessageBox.Show("Solo un administrador puede anular ventas.", "Sin permiso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idVentaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una venta de la lista para anular.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHistorialVentas.CurrentRow != null)
            {
                string estadoActual = dgvHistorialVentas.CurrentRow.Cells["Estado"].Value?.ToString();
                if (estadoActual == "Anulada")
                {
                    MessageBox.Show("Esta venta ya se encuentra anulada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult resp = MessageBox.Show($"¿Está seguro de anular la venta {numVentaSeleccionada}? Se devolverán los productos al inventario.", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    con.Open();
                    using (SqlTransaction transaccion = con.BeginTransaction())
                    {
                        try
                        {
                            string queryAnular = @"
                                UPDATE Ventas 
                                SET FechaAnulacion = GETDATE(), 
                                    IdUsuarioAnulacion = @idUsuario, 
                                    MotivoAnulacion = @motivo 
                                WHERE IdVenta = @idVenta AND FechaAnulacion IS NULL";

                            SqlCommand cmdAnular = new SqlCommand(queryAnular, con, transaccion);
                            cmdAnular.Parameters.AddWithValue("@idUsuario", UsuarioSesion.IdUsuario);
                            cmdAnular.Parameters.AddWithValue("@motivo", "Anulada desde el historial de ventas");
                            cmdAnular.Parameters.AddWithValue("@idVenta", idVentaSeleccionada);

                            if (cmdAnular.ExecuteNonQuery() == 0)
                            {
                                throw new Exception("La venta ya estaba anulada o no existe.");
                            }

                            SqlCommand cmdSuc = new SqlCommand("SELECT IdSucursal FROM Ventas WHERE IdVenta = @idVenta", con, transaccion);
                            cmdSuc.Parameters.AddWithValue("@idVenta", idVentaSeleccionada);
                            int idSucursal = Convert.ToInt32(cmdSuc.ExecuteScalar());

                            // 3. Leer los productos vendidos
                            SqlCommand cmdDetalles = new SqlCommand("SELECT IdProducto, Cantidad FROM DetalleVenta WHERE IdVenta = @idVenta", con, transaccion);
                            cmdDetalles.Parameters.AddWithValue("@idVenta", idVentaSeleccionada);

                            SqlDataAdapter da = new SqlDataAdapter(cmdDetalles);
                            DataTable dtDetalles = new DataTable();
                            da.Fill(dtDetalles);

                            // 4. Devolver el stock
                            foreach (DataRow row in dtDetalles.Rows)
                            {
                                SqlCommand cmdStock = new SqlCommand(@"
                                    UPDATE Existencias 
                                    SET StockActual = StockActual + @cantidad 
                                    WHERE IdProducto = @idProducto AND IdSucursal = @idSucursal", con, transaccion);
                                cmdStock.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row["Cantidad"]));
                                cmdStock.Parameters.AddWithValue("@idProducto", Convert.ToInt32(row["IdProducto"]));
                                cmdStock.Parameters.AddWithValue("@idSucursal", idSucursal);
                                cmdStock.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                            MessageBox.Show($"La venta {numVentaSeleccionada} fue anulada con éxito y se devolvió el stock al inventario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CargarHistorialVentas();
                            LimpiarResumen();
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
                MessageBox.Show("Error al anular la venta en CentralCelDB: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (idVentaSeleccionada == 0 || dgvHistorialVentas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una venta de la lista para reimprimir la nota.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow venta = dgvHistorialVentas.CurrentRow;
            DateTime fechaVenta = Convert.ToDateTime(venta.Cells["Fecha"].Value);

            StringBuilder ticket = new StringBuilder();
            ticket.AppendLine("========== CENTRALCEL ==========");
            ticket.AppendLine($"Comprobante: {numVentaSeleccionada}");
            ticket.AppendLine($"Fecha: {fechaVenta:dd/MM/yyyy HH:mm}");
            ticket.AppendLine($"Cliente: {venta.Cells["Cliente"].Value}");
            ticket.AppendLine("--------------------------------");
            ticket.AppendLine("CANT x PRODUCTO - SUBTOTAL");
            ticket.AppendLine("--------------------------------");

            foreach (DataGridViewRow row in dgvDetalleVenta.Rows)
            {
                if (!row.IsNewRow)
                {
                    string prod = row.Cells["Producto"].Value?.ToString();
                    string cant = row.Cells["Cantidad"].Value?.ToString();
                    string sub = Convert.ToDecimal(row.Cells["Subtotal (Bs)"].Value).ToString("N2");
                    ticket.AppendLine($"{cant} x {prod} - Bs {sub}");
                }
            }

            ticket.AppendLine("--------------------------------");
            ticket.AppendLine($"TOTAL: {lblResumenTotal.Text}");
            ticket.AppendLine($"FORMA DE PAGO: {lblResumenPago.Text}");
            ticket.AppendLine($"RECIBIDO: {lblResumenRecibido.Text}");
            ticket.AppendLine($"CAMBIO: {lblResumenCambio.Text}");
            ticket.AppendLine("================================");
            ticket.AppendLine("   ¡Gracias por su compra!   ");

            MessageBox.Show(ticket.ToString(), "Reimpresión de Nota de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHistorialVentas_Load_1(object sender, EventArgs e) { FormHistorialVentas_Load(sender, e); }
        private void btnConsultar_Click_1(object sender, EventArgs e) { btnConsultar_Click(sender, e); }
        private void btnConsultar_Click_2(object sender, EventArgs e) { btnConsultar_Click(sender, e); }
        private void btnLimpiarFiltros_Click_1(object sender, EventArgs e) { btnLimpiarFiltros_Click(sender, e); }
        private void btnReimprimir_Click_1(object sender, EventArgs e) { btnReimprimir_Click(sender, e); }
        private void btnAnularVenta_Click_1(object sender, EventArgs e) { btnAnularVenta_Click(sender, e); }

        private void txtBuscarVenta_TextChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnVolverMenu_Click_1(object sender, EventArgs e)
        {
            Form menuPrincipal = Application.OpenForms["MenuPrincipal"];

            if (menuPrincipal != null)
            {
                menuPrincipal.Show();
            }
            else
            {
            }

            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}