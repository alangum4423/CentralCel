using System.Data.SqlClient;

namespace CentralCel.Datos
{
    public class Conexion
    {
        private static string cadenaConexion = ConstruirCadena();

        private static string ConstruirCadena()
        {
            SqlConnectionStringBuilder cadena = new SqlConnectionStringBuilder();

            cadena.DataSource = "localhost";
            cadena.InitialCatalog = "CentralCelDB";
            cadena.IntegratedSecurity = true;
            cadena.Encrypt = false;

            return cadena.ConnectionString;
        }

        public static void Configurar(string usuario, string contrasena)
        {
            if (string.IsNullOrEmpty(cadenaConexion))
            {
                cadenaConexion = ConstruirCadena();
            }
        }

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
