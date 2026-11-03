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
using CentralCel.Formularios._2.Inventario;

namespace CentralCel.Formularios
{
    public partial class MenuPrincipal : Form
    {
        public bool SolicitoCerrarSesion = false;
        public MenuPrincipal()
        {
            InitializeComponent();

            this.ContextMenuStrip = ctxMenuPrincipal;
            pnlMenuPrincipal.ContextMenuStrip = ctxMenuPrincipal;
            pnlResumenDia.ContextMenuStrip = ctxMenuPrincipal;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (UsuarioSesion.IdUsuario <= 0)
            {
                MessageBox.Show("Debe iniciar sesión.");
                this.Close();
                return;
            }

            // Asignacion de permisos a los Roles
            lblUsuarioMenuPrincipal.Text = "Usuario: " + UsuarioSesion.Usuario;
            lblRolMenuPrincipal.Text = "Rol: " + UsuarioSesion.Rol;
            lblSucursalMenuPrincipal.Text = "Sucursal: " + UsuarioSesion.Sucursal;

            bool administrador = UsuarioSesion.Rol == "Administrador" || UsuarioSesion.Rol == "Superadministrador";

            menuCatalogos.Enabled = administrador;
            menuTraslados.Enabled = administrador;

            menuAdministracion.Enabled = false;
            menuNuevaVenta.Enabled = false;
            menuHistorialVentas.Enabled = false;
            menuClientes.Enabled = false;
            menuKardex.Enabled = false;
            menuReportesGenerales.Enabled = false;

            ctxNuevaVenta.Enabled = false;
            ctxReportes.Enabled = false;

            CargarResumen();
        }

        // Resumen de la Sucursal
        private void CargarResumen()
        {
            lblFechaMenuPrincipal.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            lblVentasDiaMenuPrincipal.Text = "Ventas del día: —";
            lblBajoStockMenuPrincipal.Text = "Productos con stock bajo: —";

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        "SELECT ISNULL(SUM(d.Cantidad * d.PrecioUnitario), 0) " +
                        "FROM Ventas v " +
                        "INNER JOIN DetalleVenta d ON v.IdVenta = d.IdVenta " +
                        "WHERE v.IdSucursal = @sucursal " +
                        "AND v.Fecha >= @desde AND v.Fecha < @hasta " +
                        "AND v.FechaAnulacion IS NULL";

                    if (UsuarioSesion.Rol == "Cajero")
                    {
                        sql += " AND v.IdUsuario = @usuario";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sucursal", UsuarioSesion.IdSucursal);
                        cmd.Parameters.AddWithValue("@desde", DateTime.Today);
                        cmd.Parameters.AddWithValue( "@hasta", DateTime.Today.AddDays(1));
                        cmd.Parameters.AddWithValue("@usuario", UsuarioSesion.IdUsuario);

                        decimal total = Convert.ToDecimal(cmd.ExecuteScalar());

                        lblVentasDiaMenuPrincipal.Text = "Ventas del día: Bs " + total.ToString("N2");

                        // Consulta de stock
                        cmd.CommandText =
                            "SELECT COUNT(*) " +
                            "FROM Existencias e " +
                            "INNER JOIN Productos p " +
                            "ON e.IdProducto = p.IdProducto " +
                            "WHERE e.IdSucursal = @sucursal " +
                            "AND e.StockActual <= e.StockMinimo " +
                            "AND p.Activo = 1";

                        int cantidad =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        lblBajoStockMenuPrincipal.Text =
                            "Productos con stock bajo: " + cantidad;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar el resumen: " + ex.Message);
            }
        }

        private void menuProductosExistencias_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormInventario().ShowDialog();
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().ShowDialog();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "CentralCel\n" +
                "Sistema de Ventas e Inventarios\n" +
                "Versión 1.0",
                "2026",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void menuSucursales_Click(object sender, EventArgs e)
        {

        }

        private void menuConfiguracion_Click(object sender, EventArgs e)
        {

        }

        private void menuTraslados_Click(object sender, EventArgs e)
        {

        }

        private void menuCatalogos_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormCatalogosInventario().ShowDialog();
        }

        private void menuKardex_Click(object sender, EventArgs e)
        {

        }

        private void menuNuevaVenta_Click(object sender, EventArgs e)
        {

        }

        private void menuHistorialVentas_Click(object sender, EventArgs e)
        {

        }

        private void menuClientes_Click(object sender, EventArgs e)
        {

        }

        private void menuReportesGenerales_Click(object sender, EventArgs e)
        {

        }

        private void ctxInventario_Click(object sender, EventArgs e)
        {

        }

        private void ctxNuevaVenta_Click(object sender, EventArgs e)
        {

        }

        private void ctxReportes_Click(object sender, EventArgs e)
        {

        }

        private void ctxActualizarResumen_Click(object sender, EventArgs e)
        {

        }

        private void ctxCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login();ShowDialog();
        }

        private void ctxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
