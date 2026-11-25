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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtPassword.Text;
            string rol = cmbRol.Text;
            string sucursal = cmbSucursal.Text;

            // Validacion de campos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(sucursal))
            {
                lblAlerta.Text = "Complete usuario, contraseña, rol y sucursal.";
                lblAlerta.ForeColor = Color.Red;
                return;
            }

            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string sql =
                        "SELECT u.IdUsuario, r.Nombre " +
                        "FROM Usuarios u " +
                        "INNER JOIN Roles r ON u.IdRol = r.IdRol " +
                        "INNER JOIN Sucursales s ON u.IdSucursal = s.IdSucursal " +
                        "WHERE u.NombreUsuario = @usuario " +
                        "AND u.ClaveHash = HASHBYTES('SHA2_256', CONCAT(@password, CONVERT(NVARCHAR(36), u.ClaveSalt))) " +
                        "AND u.Activo = 1 " +
                        "AND r.Activo = 1 " +
                        "AND s.Activo = 1";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", contraseña);

                        string rolRegistrado = null;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                UsuarioSesion.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                rolRegistrado = dr["Nombre"].ToString();
                            }
                        }

                        if (string.IsNullOrEmpty(rolRegistrado))
                        {
                            lblAlerta.Text = "Usuario o contraseña incorrectos, o perfil inactivo.";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL (" + ex.Number + "): " + ex.Message);
                lblAlerta.Text = "No se pudo ingresar. Revise sus credenciales";
                lblAlerta.ForeColor = Color.Red;
                return;
            }

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
