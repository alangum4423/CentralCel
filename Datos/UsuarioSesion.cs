using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralCel.Datos
{
    public static class UsuarioSesion
    {
        public static int IdUsuario;
        public static int IdSucursal { get; set; }
        public static string Sucursal { get; set; }
        public static string Usuario;
        public static string Rol;
    }
}
