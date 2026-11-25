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
            UsuarioSesion.Limpiar();
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

            lblAlerta.Text = string.Empty;

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

                    string sql = @"
                        SELECT TOP 1
                            u.IdUsuario,
                            u.ClaveHash,
                            u.ClaveSalt,
                            r.Nombre AS RolNombre
                        FROM dbo.Usuarios u
                        INNER JOIN dbo.Roles r ON u.IdRol = r.IdRol
                        WHERE u.NombreUsuario = @usuario
                          AND u.Activo = 1
                          AND r.Activo = 1;";

                    int idUsuario = 0;
                    byte[] claveHashGuardada = null;
                    byte[] claveSaltGuardada = null;
                    string rolRegistrado = null;

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 50).Value = usuario;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                idUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                claveHashGuardada = dr["ClaveHash"] as byte[];
                                claveSaltGuardada = dr["ClaveSalt"] as byte[];
                                rolRegistrado = dr["RolNombre"]?.ToString();
                            }
                        }
                    }

                    if (idUsuario == 0 || string.IsNullOrEmpty(rolRegistrado) ||
                        !SeguridadHelper.VerificarPassword(contraseña, claveHashGuardada, claveSaltGuardada))
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

                    object idSucursalObj;
                    using (SqlCommand cmdSucursal = new SqlCommand(
                        "SELECT TOP 1 IdSucursal FROM dbo.Sucursales WHERE Nombre = @sucursal AND Activo = 1;", conn))
                    {
                        cmdSucursal.Parameters.Add("@sucursal", SqlDbType.NVarChar, 100).Value = sucursal;
                        idSucursalObj = cmdSucursal.ExecuteScalar();
                    }

                    if (idSucursalObj == null || idSucursalObj == DBNull.Value)
                    {
                        lblAlerta.Text = "La sucursal seleccionada no es válida o está inactiva.";
                        lblAlerta.ForeColor = Color.Red;
                        return;
                    }

                    UsuarioSesion.IdUsuario = idUsuario;
                    UsuarioSesion.Usuario = usuario;
                    UsuarioSesion.Rol = rolRegistrado;
                    UsuarioSesion.IdSucursal = Convert.ToInt32(idSucursalObj);
                    UsuarioSesion.Sucursal = sucursal;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL (" + ex.Number + "): " + ex.Message);
                lblAlerta.Text = "No se pudo ingresar. Revise sus credenciales";
                lblAlerta.ForeColor = Color.Red;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
                lblAlerta.Text = "No se pudo ingresar.";
                lblAlerta.ForeColor = Color.Red;
                return;
            }

            txtPassword.Clear();

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
