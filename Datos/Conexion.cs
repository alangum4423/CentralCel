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
        private static string cadenaConexion = ConstruirCadena();

        private static string ConstruirCadena()
        {
            SqlConnectionStringBuilder cadena = new SqlConnectionStringBuilder();

            cadena.DataSource = "localhost";
            cadena.InitialCatalog = "CentralCelDB";
            cadena.IntegratedSecurity = false;

            cadena.UserID = "app_centralcel";
            cadena.Password = "AppCentralCel2026#!";
            cadena.Encrypt = true;
            cadena.TrustServerCertificate = true;

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