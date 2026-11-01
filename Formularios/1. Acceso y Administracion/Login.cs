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

            // Validacion de datos (evita que los campos esten vacios)
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                lblAlerta.Text = "Error. Debe ingresar con su usuario y contraseña.";
                lblAlerta.ForeColor = Color.Blue;
                return;
            }

            // Define y permite las credenciales de usuario
            string cadena = $@"Server=localhost;Database=CentralCel;User Id={usuario};Password={contraseña}";

            try
            {
                using (SqlConnection conn = new SqlConnection(cadena))
                {
                    conn.Open();
                    lblAlerta.Text = "Conexión exitosa. Bienvenido " + usuario;
                    lblAlerta.ForeColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                lblAlerta.Text = "Error de conexión: " + ex.Message;
                lblAlerta.ForeColor = Color.Red;
            }

            this.Hide();
            using (MenuPrincipal menu = new MenuPrincipal())
            {
                menu.ShowDialog();
            }
            this.Close();
        }
    }
}
