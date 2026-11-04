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
using CentralCel.Formularios;

namespace CentralCel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        // Funcion del Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Funcion del btoton Ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtPassword.Text;
            string rol = cmbRol.Text;
            string sucursal = cmbSucursal.Text;

            // Validacion de campos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(sucursal))
            {
                lblAlerta.Text = "Complete usuario, contraseña y rol.";
                lblAlerta.ForeColor = Color.Red;
                return;
            }

            try
            {
                // Comprobacion de SQL del usuario y la contraseña
                Conexion.Configurar(usuario, contraseña);

                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    // Comprobacion de perfil, rol y sucursal.
                    string sql =
                        "SELECT r.Nombre " +
                        "FROM Usuarios u " +
                        "INNER JOIN Roles r ON u.IdRol = r.IdRol " +
                        "INNER JOIN Sucursales s ON u.IdSucursal = s.IdSucursal " +
                        "WHERE u.NombreUsuario = @usuario " +
                        "AND u.Activo = 1 " +
                        "AND r.Activo = 1 " +
                        "AND s.Activo = 1";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        SqlCommand cmdId = new SqlCommand("SELECT IdUsuario FROM Usuarios WHERE NombreUsuario = @usuario", conn);
                        cmdId.Parameters.AddWithValue("@usuario", usuario);
                        UsuarioSesion.IdUsuario = Convert.ToInt32(cmdId.ExecuteScalar());

                        string rolRegistrado = Convert.ToString(cmd.ExecuteScalar());

                        if (string.IsNullOrEmpty(rolRegistrado))
                        {
                            lblAlerta.Text = "No tiene un perfil activo autorizado.";
                            lblAlerta.ForeColor = Color.Red;
                            return;
                        }

                        if (!string.Equals(rol, rolRegistrado, StringComparison.OrdinalIgnoreCase))
                        {
                            lblAlerta.Text = "El rol no corresponde a su cuenta.";
                            lblAlerta.ForeColor = Color.Red;
                            return;
                        }

                        UsuarioSesion.Usuario = usuario;
                        UsuarioSesion.Rol = rolRegistrado;
                        SqlCommand cmdSucursal = new SqlCommand("SELECT IdSucursal FROM Sucursales WHERE Nombre = @sucursal AND Activo = 1", conn);
                        cmdSucursal.Parameters.AddWithValue("@sucursal", cmbSucursal.Text);
                        UsuarioSesion.IdSucursal = Convert.ToInt32(cmdSucursal.ExecuteScalar());
                        UsuarioSesion.Sucursal = cmbSucursal.Text;

                    }

                }
            }
            catch (SqlException)
            {
                lblAlerta.Text = "No se pudo ingresar. Revise sus credenciales";

                lblAlerta.ForeColor = Color.Red;
                return;
            }

            // Apertura del menú después de las validaciones

            using (MenuPrincipal menu = new MenuPrincipal(usuario, rol))
            {
                menu.ShowDialog();
            }

            this.Close();
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
