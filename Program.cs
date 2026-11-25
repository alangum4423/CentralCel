using CentralCel.Datos;
using System;
using System.Windows.Forms;

namespace CentralCel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (var conn = Conexion.ObtenerConexion())
                {
                    SeguridadHelper.InicializarSuperAdminSiNoExiste(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo verificar o inicializar el usuario administrador en la base de datos:\n" + ex.Message,
                    "Error de inicialización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


            Application.Run(new Login());
        }
    }
}
