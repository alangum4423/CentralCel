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
using ventas_historial_VENTAS;
using ventas_historial_VENTAS.Formularios._3.Ventas;
using CentralCel.Formularios._3_Reportes;
using CentralCel.Formularios._1._Acceso_y_Administracion;

namespace CentralCel.Formularios
{
    public partial class MenuPrincipal : Form
    {

        public MenuPrincipal(string usuario, string rol)
        {
            InitializeComponent();

            lblUsuarioMenuPrincipal.Text = "👥 Usuario: " + usuario;
            lblRolMenuPrincipal.Text = "⚙️ Rol: " + rol;
            lblFechaMenuPrincipal.Text = "🗓️ Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            this.ContextMenuStrip = ctxMenuPrincipal;
            pnlMenuPrincipal.ContextMenuStrip = ctxMenuPrincipal;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (UsuarioSesion.Rol == "Superadministrador")
            {
                AlertarStockBajo();
            }
            else if (UsuarioSesion.Rol == "Administrador")
            {
                AlertarStockBajo();
            }
            else if (UsuarioSesion.Rol == "Empleado")
            {
                menuUsuarios.Visible = false;
                menuSucursales.Visible = false;
                menuConfiguracion.Visible = false;
                menuReportesGenerales.Visible = false;
                menuAdministracion.Visible = false;
                menuReportes.Visible = false;

                btnAdministracion.Visible = false;
                btnReportes.Visible = false;
                pctCajeros.Visible = false;

                ctxReportes.Visible = false;

                AlertarStockBajo();
            }
            else if (UsuarioSesion.Rol == "Contador")
            {
                menuUsuarios.Visible = false;
                menuSucursales.Visible = false;
                menuConfiguracion.Visible = false;
                menuAdministracion.Visible = false;
                menuNuevaVenta.Visible = false;
                menuClientes.Visible = false;
                menuCatalogos.Visible = false;

                btnAdministracion.Visible = false;
                btnPuntodeVenta.Visible = false;
                pctCajeros.Visible = false;

                ctxNuevaVenta.Visible = false;
            }
        }

        private void AlertarStockBajo()
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql = @"
                        SELECT p.Codigo, p.Nombre, e.StockActual, e.StockMinimo
                        FROM Existencias e
                        INNER JOIN Productos p ON e.IdProducto = p.IdProducto
                        WHERE e.IdSucursal = @idSucursal
                          AND p.Activo = 1
                          AND e.StockActual <= e.StockMinimo
                        ORDER BY e.StockActual ASC;";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idSucursal", UsuarioSesion.IdSucursal);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            StringBuilder lista = new StringBuilder();
                            int contador = 0;

                            while (dr.Read())
                            {
                                contador++;
                                string estado = Convert.ToInt32(dr["StockActual"]) == 0 ? "AGOTADO" : "STOCK BAJO";
                                lista.AppendLine($"• [{dr["Codigo"]}] {dr["Nombre"]} — Actual: {dr["StockActual"]} / Mín: {dr["StockMinimo"]} ({estado})");
                            }

                            if (contador > 0)
                            {
                                MessageBox.Show(
                                    $"Se detectaron {contador} producto(s) con stock bajo o agotado en {UsuarioSesion.Sucursal}:\n\n" +
                                    lista.ToString(),
                                    "⚠️ Alerta de Stock Bajo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo verificar el stock mínimo: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbrirFormulario(Form formulario)
        {
            this.Hide();
            using (formulario)
            {
                formulario.ShowDialog();
            }
            this.Show();
        }

        private void menuProductosExistencias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInventario());
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            AbrirFormulario(new Login());
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
                "Desarrollado por:\n" +
                "Alan Gutierrez" +
                "Camilo Calle" +
                "Rodrigo Mollericona" +
                "Davis Cupi" +
                "Y una pequeña ayuda de Coca Cola Company." +
                "Versión 4.04",
                "2026",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAdministracion());
        }

        private void menuSucursales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAdministracion());
        }

        private void menuConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAdministracion());
        }

        private void menuCatalogos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCatalogosInventario());
        }

        private void menuNuevaVenta_Click(object sender, EventArgs e)
        {
            AlertarStockBajo();
            AbrirFormulario(new FormVentas());
        }

        private void menuHistorialVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormHistorialVentas());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormVentas());
        }

        private void menuReportesGenerales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes());
        }

        private void ctxInventario_Click(object sender, EventArgs e)
        {
            AlertarStockBajo();
            AbrirFormulario(new FormInventario());
        }

        private void ctxNuevaVenta_Click(object sender, EventArgs e)
        {
            AlertarStockBajo();
            AbrirFormulario(new FormVentas());
        }

        private void ctxReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes());
        }

        private void ctxCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            AbrirFormulario(new Login());
        }

        private void ctxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AlertarStockBajo();
            AbrirFormulario(new FormInventario());
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAdministracion());
        }

        private void btnPuntodeVenta_Click(object sender, EventArgs e)
        {
            AlertarStockBajo();
            AbrirFormulario(new FormVentas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes());
        }
    }
}