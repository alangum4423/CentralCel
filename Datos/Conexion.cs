using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCel.Datos
{
    public class Conexion
    {
        private static string cadenaConexion;

        // Configuracion de la conexión con el usuario que inicia sesión
        public static void Configurar(string usuario, string contrasena)
        {
            SqlConnectionStringBuilder cadena =
                new SqlConnectionStringBuilder();

            cadena.DataSource = "localhost";
            cadena.InitialCatalog = "CentralCelDB";
            cadena.IntegratedSecurity = false;

            cadena.UserID = usuario;
            cadena.Password = contrasena;

            cadena.Encrypt = true;
            cadena.TrustServerCertificate = true;

            cadenaConexion = cadena.ConnectionString;
        }

        // Devuelve una conexión nueva
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
