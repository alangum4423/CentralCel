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
        private readonly string cadenaConexion = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=CentralCelDB;Integrated Security=True;";
        private int idVentaSeleccionada = 0;

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
        }


        private void CargarFiltros()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    cboEstado.Items.Clear();
                    cboEstado.Items.Add("Todas");
                    cboEstado.Items.Add("Confirmada");
                    cboEstado.Items.Add("Anulada");
                    cboEstado.SelectedIndex = 0;
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
                using (SqlConnection con = new SqlConnection(cadenaConexion))
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
                            v.MontoRecibido AS [Total (Bs)],
                            CASE WHEN v.FormaPago IS NULL THEN 'Confirmada' ELSE 'Confirmada' END AS [Estado]
                        FROM Ventas v
                        LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                        LEFT JOIN Sucursales s ON v.IdSucursal = s.IdSucursal
                        LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                        WHERE v.Fecha BETWEEN @fechaDesde AND @fechaHasta";

                    if (!string.IsNullOrWhiteSpace(txtBuscarVenta.Text))
                    {
                        query += " AND (v.NumeroVenta LIKE @busqueda OR c.Nombre LIKE @busqueda)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fechaDesde", dtpDesde.Value.Date);
                        cmd.Parameters.AddWithValue("@fechaHasta", dtpHasta.Value.Date.AddDays(1).AddSeconds(-1));

                        if (!string.IsNullOrWhiteSpace(txtBuscarVenta.Text))
                            cmd.Parameters.AddWithValue("@busqueda", "%" + txtBuscarVenta.Text.Trim() + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvHistorialVentas.DataSource = dt;

                        if (dgvHistorialVentas.Columns["IdVenta"] != null)
                            dgvHistorialVentas.Columns["IdVenta"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleVenta(int idVenta)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle de venta: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvHistorialVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHistorialVentas.Rows[e.RowIndex];
                idVentaSeleccionada = Convert.ToInt32(row.Cells["IdVenta"].Value);

                string numVenta = row.Cells["Venta"].Value?.ToString();
                lblDetalleTitulo.Text = $"Detalle de la venta {numVenta}";

                CargarDetalleVenta(idVentaSeleccionada);

                decimal total = Convert.ToDecimal(row.Cells["Total (Bs)"].Value ?? 0);
                lblResumenTotal.Text = $"Bs {total:N2}";
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
            CargarHistorialVentas();
        }

        private void btnAnularVenta_Click(object sender, EventArgs e)
        {
            if (idVentaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una venta de la lista para anular.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show("¿Está seguro de anular esta venta? Se devolverá el stock a inventario.", "Confirmar anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                MessageBox.Show("Venta anulada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialVentas();
            }
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarVenta_TextChanged(object sender, EventArgs e)
        {
        }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }




}