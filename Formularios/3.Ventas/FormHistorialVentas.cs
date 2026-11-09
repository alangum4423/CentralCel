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

                    // Cargar Estados
                    cboEstado.Items.Clear();
                    cboEstado.Items.Add("Todas");
                    cboEstado.Items.Add("Confirmada");
                    cboEstado.Items.Add("Anulada");
                    cboEstado.SelectedIndex = 0;

                    // Cargar Sucursales
                    try
                    {
                        string querySuc = "SELECT IdSucursal, Nombre FROM Sucursales";
                        SqlDataAdapter daSuc = new SqlDataAdapter(querySuc, con);
                        DataTable dtSuc = new DataTable();
                        daSuc.Fill(dtSuc);

                        DataRow drSuc = dtSuc.NewRow();
                        drSuc["IdSucursal"] = 0;
                        drSuc["Nombre"] = "Todas";
                        dtSuc.Rows.InsertAt(drSuc, 0);

                        cboSucursal.DataSource = dtSuc;
                        cboSucursal.DisplayMember = "Nombre";
                        cboSucursal.ValueMember = "IdSucursal";
                    }
                    catch { }

                    // Cargar Vendedores
                    try
                    {
                        string queryUsu = "SELECT IdUsuario, Nombre FROM Usuarios";
                        SqlDataAdapter daUsu = new SqlDataAdapter(queryUsu, con);
                        DataTable dtUsu = new DataTable();
                        daUsu.Fill(dtUsu);

                        DataRow drUsu = dtUsu.NewRow();
                        drUsu["IdUsuario"] = 0;
                        drUsu["Nombre"] = "Todos";
                        dtUsu.Rows.InsertAt(drUsu, 0);

                        cboVendedor.DataSource = dtUsu;
                        cboVendedor.DisplayMember = "Nombre";
                        cboVendedor.ValueMember = "IdUsuario";
                    }
                    catch { }
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
                            v.NumeroVenta AS [Venta],
                            v.Fecha AS [Fecha],
                            ISNULL(s.Nombre, 'La Paz 1') AS [Sucursal],
                            ISNULL(u.Nombre, 'vendedor01') AS [Vendedor],
                            ISNULL(c.Nombre, 'Cliente general') AS [Cliente],
                            v.FormaPago AS [Forma Pago],
                            v.MontoRecibido AS [Recibido (Bs)],
                            ISNULL(v.Estado, 'Confirmada') AS [Estado]
                        FROM Ventas v
                        LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                        LEFT JOIN Sucursales s ON v.IdSucursal = s.IdSucursal
                        LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                        WHERE v.Fecha BETWEEN @fechaDesde AND @fechaHasta";

                    if (!string.IsNullOrWhiteSpace(txtBuscarVenta.Text))
                    {
                        query += " AND (v.NumeroVenta LIKE @busqueda OR c.Nombre LIKE @busqueda)";
                    }

                    if (cboEstado.SelectedItem != null && cboEstado.SelectedItem.ToString() != "Todas")
                    {
                        query += " AND ISNULL(v.Estado, 'Confirmada') = @estado";
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

                        if (cboEstado.SelectedItem != null && cboEstado.SelectedItem.ToString() != "Todas")
                            cmd.Parameters.AddWithValue("@estado", cboEstado.SelectedItem.ToString());

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

                        dgvHistorialVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                        // Calcular el Total Acumulado de la venta en base a sus ítems
                        decimal totalAcumulado = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            totalAcumulado += Convert.ToDecimal(row["Subtotal (Bs)"]);
                        }

                        ActualizarResumen(idVenta, totalAcumulado);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la venta: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumen(int idVenta, decimal totalVenta)
        {
            if (dgvHistorialVentas.CurrentRow == null) return;

            DataGridViewRow row = dgvHistorialVentas.CurrentRow;

            string formaPago = row.Cells["Forma Pago"].Value?.ToString() ?? "Efectivo";
            decimal recibido = Convert.ToDecimal(row.Cells["Recibido (Bs)"].Value ?? 0);
            decimal cambio = recibido - totalVenta;
            if (cambio < 0) cambio = 0;

            lblResumenTotal.Text = $"Bs {totalVenta:N2}";
            lblResumenPago.Text = formaPago;
            lblResumenRecibido.Text = $"Bs {recibido:N2}";
            lblResumenCambio.Text = $"Bs {cambio:N2}";
        }

        private void LimpiarResumen()
        {
            lblDetalleTitulo.Text = "Detalle de la venta";
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

                lblDetalleTitulo.Text = $"Detalle de la venta {numVentaSeleccionada}";
                CargarDetalleVenta(idVentaSeleccionada);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarHistorialVentas();
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

            if (resp == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        con.Open();
                        using (SqlTransaction transaccion = con.BeginTransaction())
                        {
                            try
                            {
                                string queryObtenerSucursal = "SELECT IdSucursal FROM Ventas WHERE IdVenta = @idVenta";
                                SqlCommand cmdSuc = new SqlCommand(queryObtenerSucursal, con, transaccion);
                                cmdSuc.Parameters.AddWithValue("@idVenta", idVentaSeleccionada);
                                int idSucursal = Convert.ToInt32(cmdSuc.ExecuteScalar());

                                string queryDetalles = "SELECT IdProducto, Cantidad FROM DetalleVenta WHERE IdVenta = @idVenta";
                                SqlCommand cmdDetalles = new SqlCommand(queryDetalles, con, transaccion);
                                cmdDetalles.Parameters.AddWithValue("@idVenta", idVentaSeleccionada);

                                SqlDataAdapter da = new SqlDataAdapter(cmdDetalles);
                                DataTable dtDetalles = new DataTable();
                                da.Fill(dtDetalles);

                                foreach (DataRow row in dtDetalles.Rows)
                                {
                                    int idProducto = Convert.ToInt32(row["IdProducto"]);
                                    int cantidad = Convert.ToInt32(row["Cantidad"]);

                                    string queryDevolverStock = @"
                                        UPDATE Existencias 
                                        SET StockActual = StockActual + @cantidad 
                                        WHERE IdProducto = @idProducto AND IdSucursal = @idSucursal";

                                    SqlCommand cmdStock = new SqlCommand(queryDevolverStock, con, transaccion);
                                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                    cmdStock.Parameters.AddWithValue("@idProducto", idProducto);
                                    cmdStock.Parameters.AddWithValue("@idSucursal", idSucursal);
                                    cmdStock.ExecuteNonQuery();
                                }

                                string queryAnular = "UPDATE Ventas SET Estado = 'Anulada' WHERE IdVenta = @idVenta";
                                SqlCommand cmdAnular = new SqlCommand(queryAnular, con, transaccion);
                                cmdAnular.Parameters.AddWithValue("@idVenta", idVentaSeleccionada);
                                cmdAnular.ExecuteNonQuery();

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
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (idVentaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una venta de la lista para reimprimir la nota.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder ticket = new StringBuilder();
            ticket.AppendLine("========== CENTRALCEL ==========");
            ticket.AppendLine($"Comprobante: {numVentaSeleccionada}");
            ticket.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
            ticket.AppendLine($"Cliente: {dgvHistorialVentas.CurrentRow.Cells["Cliente"].Value}");
            ticket.AppendLine("--------------------------------");
            ticket.AppendLine("CANT | PRODUCTO | SUBTOTAL");
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

        private void txtBuscarVenta_TextChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void FormHistorialVentas_Load_1(object sender, EventArgs e) { }
        private void btnConsultar_Click_1(object sender, EventArgs e) { }
    }
}