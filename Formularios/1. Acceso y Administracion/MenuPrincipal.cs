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


namespace CentralCel.Formularios
{
    public partial class MenuPrincipal : Form
    {
        public bool SolicitoCerrarSesion = false;

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
            SolicitoCerrarSesion = true;
            this.Close();
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
            AbrirFormulario(new FormInventario());
        }

        private void menuCatalogos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCatalogosInventario());
        }

        private void menuKardex_Click(object sender, EventArgs e)
        {

        }

        private void menuNuevaVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormVentas());
        }

        private void menuHistorialVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormHistorialVentas());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {

        }

        private void menuReportesGenerales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes());
        }

        private void ctxInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInventario());
        }

        private void ctxNuevaVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormVentas());
        }

        private void ctxReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes());
        }

        private void ctxCerrarSesion_Click(object sender, EventArgs e)
        {
            SolicitoCerrarSesion = true;

        }

        private void ctxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInventario());
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {

        }

        private void btnPuntodeVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormVentas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReportes());
        }
    }
}
