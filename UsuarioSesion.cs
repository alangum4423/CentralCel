using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCel.Datos
{
    public static class UsuarioSesion
    {
        public static int IdUsuario { get; set; }
        public static string Usuario { get; set; } = string.Empty;
        public static string Nombres { get; set; } = string.Empty;
        public static string Apellidos { get; set; } = string.Empty;
        public static string NombreCompleto => $"{Nombres} {Apellidos}".Trim();
        public static string CI { get; set; } = string.Empty;
        public static string Direccion { get; set; } = string.Empty;
        public static string Telefono { get; set; } = string.Empty;
        public static string Correo { get; set; } = string.Empty;
        public static int IdRol { get; set; }
        public static string Rol { get; set; } = string.Empty;
        public static int IdSucursal { get; set; }
        public static string Sucursal { get; set; } = string.Empty;
        public static int IdSueldo { get; set; }

        public static void Limpiar()
        {
            IdUsuario = 0;
            Usuario = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            CI = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
            IdRol = 0;
            Rol = string.Empty;
            IdSucursal = 0;
            Sucursal = string.Empty;
            IdSueldo = 0;
        }
    }
}
