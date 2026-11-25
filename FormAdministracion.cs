using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CentralCel.Datos;

namespace CentralCel.Formularios._1._Acceso_y_Administracion
{
    public partial class FormAdministracion : Form
    {
        private int idUsuarioSeleccionado = 0;
        private int idSucursalSeleccionada = 0;

        private byte[] fotoUsuario;
        private byte[] logoNegocio;

        public FormAdministracion()
        {
            InitializeComponent();
            Load += FormAdministracion_Load;

            btnVolverMenu.Click += btnVolverMenu_Click;

            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            btnBuscarUsuario.Click += btnBuscarUsuario_Click;
            btnLimpiarUsuario.Click += btnLimpiarUsuario_Click;
            btnGuardarUsuario.Click += btnGuardarUsuario_Click;
            btnCancelarUsuario.Click += btnCancelarUsuario_Click;
            btnDesactivarUsuario.Click += btnDesactivarUsuario_Click;
            btnCargarFoto.Click += btnCargarFoto_Click;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;

            btnNuevaSucursal.Click += btnNuevaSucursal_Click;
            btnBuscarSucursal.Click += btnBuscarSucursal_Click;
            btnLimpiarSucursal.Click += btnLimpiarSucursal_Click;
            btnGuardarSucursal.Click += btnGuardarSucursal_Click;
            btnCancelarSucursal.Click += btnCancelarSucursal_Click;
            btnDesactivarSucursal.Click += btnDesactivarSucursal_Click;
            dgvSucursales.SelectionChanged += dgvSucursales_SelectionChanged;

            btnGuardarConfiguracion.Click += btnGuardarConfiguracion_Click;
            btnCancelarConfiguracion.Click += btnCancelarConfiguracion_Click;
            btnCargarLogo.Click += btnCargarLogo_Click;
            btnQuitarLogo.Click += btnQuitarLogo_Click;
        }

        private void FormAdministracion_Load(object sender, EventArgs e)
        {
            lblSesion.Text = "Usuario: " + UsuarioSesion.Usuario +
                             " | Sucursal: " + UsuarioSesion.Sucursal;

            try
            {
                ConfigurarTablas();
                CargarRoles();
                CargarSucursalesCombo();
                CargarUsuarios();
                CargarSucursales();
                CargarConfiguracion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar Administración: " + ex.Message);
            }
        }

        private void ConfigurarTablas()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;

            dgvSucursales.AutoGenerateColumns = false;
            dgvSucursales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSucursales.MultiSelect = false;
            dgvSucursales.ReadOnly = true;
        }

        private DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        private int Ejecutar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                if (!string.IsNullOrEmpty(UsuarioSesion.Usuario))
                {
                    using (SqlCommand cmdCtx = new SqlCommand("EXEC sp_set_session_context @key = N'UsuarioActual', @value = @u;", conexion))
                    {
                        cmdCtx.Parameters.AddWithValue("@u", UsuarioSesion.Usuario);
                        cmdCtx.ExecuteNonQuery();
                    }
                }

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);

                    return comando.ExecuteNonQuery();
                }
            }
        }

        private bool EsSuperadministrador()
        {
            return string.Equals(
                UsuarioSesion.Rol,
                "Superadministrador",
                StringComparison.OrdinalIgnoreCase);
        }

        private void CargarRoles()
        {
            cmbRol.DataSource = Consultar(
                "SELECT IdRol, Nombre FROM Roles WHERE Activo = 1 ORDER BY Nombre");

            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "IdRol";
            cmbRol.SelectedIndex = -1;
        }

        private void CargarSucursalesCombo()
        {
            cmbSucursalUsuario.DataSource = Consultar(
                "SELECT IdSucursal, Nombre FROM Sucursales WHERE Activo = 1 ORDER BY Nombre");

            cmbSucursalUsuario.DisplayMember = "Nombre";
            cmbSucursalUsuario.ValueMember = "IdSucursal";
            cmbSucursalUsuario.SelectedIndex = -1;
        }

        private void CargarUsuarios()
        {
            string sql =
                "SELECT u.IdUsuario, " +
                "u.NombreUsuario AS Usuario, " +
                "LTRIM(RTRIM(CONCAT(u.Nombres, N' ', NULLIF(u.Apellidos, N'-')))) AS Nombre, " +
                "r.Nombre AS Rol, " +
                "s.Nombre AS Sucursal, " +
                "CASE WHEN u.Activo = 1 THEN N'Activo' ELSE N'Inactivo' END AS Estado, " +
                "c.Nombre_Cargo AS Cargo, " +
                "u.IdRol, u.IdSucursal, u.Activo, u.Foto " +
                "FROM Usuarios u " +
                "INNER JOIN Roles r ON u.IdRol = r.IdRol " +
                "INNER JOIN Sucursales s ON u.IdSucursal = s.IdSucursal " +
                "INNER JOIN Sueldos su ON u.IdSueldo = su.IdSueldo " +
                "INNER JOIN Cargos c ON su.Cargo = c.IdCargo " +
                "WHERE u.NombreUsuario LIKE @buscar OR u.Nombres LIKE @buscar OR u.Apellidos LIKE @buscar " +
                "ORDER BY u.Nombres";

            dgvUsuarios.DataSource = Consultar(
                sql,
                new SqlParameter("@buscar", "%" + txtBuscarUsuario.Text.Trim() + "%"));
        }

        private void CargarSucursales()
        {
            string sql =
                "SELECT IdSucursal, Codigo, Nombre, Ciudad, Direccion, Telefono, " +
                "CASE WHEN Activo = 1 THEN N'Activo' ELSE N'Inactivo' END AS Estado, " +
                "Activo " +
                "FROM Sucursales " +
                "WHERE Codigo LIKE @buscar OR Nombre LIKE @buscar OR Ciudad LIKE @buscar " +
                "ORDER BY Nombre";

            dgvSucursales.DataSource = Consultar(
                sql,
                new SqlParameter("@buscar", "%" + txtBuscarSucursal.Text.Trim() + "%"));
        }

        // PESTANIA USUARIOS lol

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            LimpiarUsuario();
            txtNombreUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            txtNombreUsuario.Focus();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron buscar los usuarios: " + ex.Message);
            }
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            txtBuscarUsuario.Clear();

            try
            {
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los usuarios: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null ||
                dgvUsuarios.CurrentRow.DataBoundItem == null)
                return;

            DataRowView fila = dgvUsuarios.CurrentRow.DataBoundItem as DataRowView;
            if (fila == null) return;

            idUsuarioSeleccionado = Convert.ToInt32(fila["IdUsuario"]);

            txtNombreUsuario.Text = Convert.ToString(fila["Usuario"]);
            txtNombreCompleto.Text = Convert.ToString(fila["Nombre"]);
            txtCargo.Text = Convert.ToString(fila["Cargo"]);
            chkUsuarioActivo.Checked = Convert.ToBoolean(fila["Activo"]);

            cmbRol.SelectedValue = Convert.ToInt32(fila["IdRol"]);
            cmbSucursalUsuario.SelectedValue = Convert.ToInt32(fila["IdSucursal"]);

            txtContraseña.Clear();
            txtNombreUsuario.Enabled = false;

            fotoUsuario = fila["Foto"] == DBNull.Value
                ? null
                : (byte[])fila["Foto"];

            MostrarFotoUsuario();
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    fotoUsuario = File.ReadAllBytes(dialogo.FileName);
                    MostrarFotoUsuario();
                }
            }
        }

        private void MostrarFotoUsuario()
        {
            if (fotoUsuario == null)
            {
                picFotoUsuario.Image = null;
                return;
            }

            using (MemoryStream memoria = new MemoryStream(fotoUsuario))
            using (Image imagen = Image.FromStream(memoria))
            {
                picFotoUsuario.Image = new Bitmap(imagen);
            }
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string nombreCompleto = txtNombreCompleto.Text.Trim();
            string cargo = txtCargo.Text.Trim();

            if (nombreUsuario == "" || nombreCompleto == "" ||
                cmbRol.SelectedValue == null || cmbSucursalUsuario.SelectedValue == null)
            {
                MessageBox.Show("Complete usuario, nombre, rol y sucursal.");
                return;
            }

            if (!Regex.IsMatch(nombreUsuario, @"^[A-Za-z0-9_]{1,50}$"))
            {
                MessageBox.Show(
                    "El nombre de usuario solo puede contener letras, números y guion bajo.");
                return;
            }

            try
            {
                int idRol = Convert.ToInt32(cmbRol.SelectedValue);
                int idSucursal = Convert.ToInt32(cmbSucursalUsuario.SelectedValue);

                if (idUsuarioSeleccionado == 0)
                {
                    if (!EsSuperadministrador() &&
                        cmbRol.Text != "Empleado" && cmbRol.Text != "Contador")
                    {
                        MessageBox.Show(
                            "Solo el superadministrador puede crear cuentas de Administrador o Superadministrador.");
                        return;
                    }

                    if (txtContraseña.Text.Trim() == "")
                    {
                        MessageBox.Show("Escriba una contraseña para la nueva cuenta.");
                        return;
                    }

                    CrearCuenta(nombreUsuario, nombreCompleto, cargo,
                        idRol, idSucursal, txtContraseña.Text, fotoUsuario);
                }
                else
                {
                    if (!EsSuperadministrador() &&
                        (txtContraseña.Text.Trim() != "" ||
                         idRol != Convert.ToInt32(
                             ((DataRowView)dgvUsuarios.CurrentRow.DataBoundItem)["IdRol"])))
                    {
                        MessageBox.Show(
                            "Solo el superadministrador puede cambiar contraseñas o roles.");
                        return;
                    }

                    ActualizarCuenta(
                        nombreUsuario, nombreCompleto, cargo,
                        idRol, idSucursal, txtContraseña.Text,
                        chkUsuarioActivo.Checked, fotoUsuario);
                }

                CargarUsuarios();
                CargarSucursalesCombo();
                LimpiarUsuario();

                MessageBox.Show("Usuario guardado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el usuario: " + ex.Message);
            }
        }

        private void SepararNombreCompleto(string nombreCompleto, out string nombres, out string apellidos)
        {
            string[] partes = nombreCompleto.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            nombres = partes.Length > 0 ? partes[0] : nombreCompleto;
            apellidos = partes.Length > 1 ? partes[1] : "-";
        }

        private byte[] GenerarSalt16()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private void CrearCuenta(
            string usuario, string nombre, string cargo,
            int idRol, int idSucursal, string contrasena, byte[] foto)
        {
            byte[] salt = GenerarSalt16();
            string nombres;
            string apellidos;
            SepararNombreCompleto(nombre, out nombres, out apellidos);

            const string fraseCifrado = "CentralCel2026!";

            string sql =
                "INSERT INTO Usuarios " +
                "(NombreUsuario, CICifrado, CIHash, Nombres, Apellidos, " +
                "DireccionCifrada, TelefonoCifrado, CorreoCifrado, Fecha_nacimiento, " +
                "ClaveHash, ClaveSalt, IdRol, IdSucursal, IdSueldo, Foto, Activo) " +
                "VALUES (" +
                "@usuario, " +
                "ENCRYPTBYPASSPHRASE(@frase, @ci), " +
                "HASHBYTES('SHA2_256', @ci), " +
                "@nombres, @apellidos, " +
                "ENCRYPTBYPASSPHRASE(@frase, N'Sin especificar'), " +
                "ENCRYPTBYPASSPHRASE(@frase, N'0'), " +
                "ENCRYPTBYPASSPHRASE(@frase, @correo), " +
                "'2000-01-01', " +
                "HASHBYTES('SHA2_256', CONVERT(VARBINARY(MAX), @password) + @salt), " +
                "@salt, " +
                "@rol, @sucursal, " +
                "COALESCE(" +
                "  (SELECT TOP 1 s.IdSueldo FROM Sueldos s INNER JOIN Cargos c ON s.Cargo = c.IdCargo WHERE c.Nombre_Cargo = @cargo AND c.Activo_Cargo = 1), " +
                "  (SELECT TOP 1 IdSueldo FROM Sueldos WHERE IdSueldo = @rol), " +
                "  (SELECT TOP 1 IdSueldo FROM Sueldos)" +
                "), " +
                "@foto, 1)";

            SqlParameter paramSalt = new SqlParameter("@salt", SqlDbType.VarBinary, 16) { Value = salt };
            SqlParameter paramFoto = new SqlParameter("@foto", SqlDbType.VarBinary, -1) { Value = (object)foto ?? DBNull.Value };

            Ejecutar(
                sql,
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@frase", fraseCifrado),
                new SqlParameter("@ci", usuario),
                new SqlParameter("@nombres", nombres),
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@correo", usuario + "@centralcel.com"),
                new SqlParameter("@password", contrasena),
                paramSalt,
                new SqlParameter("@rol", idRol),
                new SqlParameter("@sucursal", idSucursal),
                new SqlParameter("@cargo", cargo),
                paramFoto);
        }

        private void ActualizarCuenta(
            string usuario, string nombre, string cargo,
            int idRol, int idSucursal, string nuevaContrasena,
            bool activo, byte[] foto)
        {
            string nombres;
            string apellidos;
            SepararNombreCompleto(nombre, out nombres, out apellidos);

            string subconsultaSueldo =
                "COALESCE(" +
                "  (SELECT TOP 1 s.IdSueldo FROM Sueldos s INNER JOIN Cargos c ON s.Cargo = c.IdCargo WHERE c.Nombre_Cargo = @cargo AND c.Activo_Cargo = 1), " +
                "  IdSueldo" +
                ")";

            SqlParameter paramFoto = new SqlParameter("@foto", SqlDbType.VarBinary, -1) { Value = (object)foto ?? DBNull.Value };

            if (EsSuperadministrador())
            {
                if (nuevaContrasena.Trim() != "")
                {
                    byte[] nuevoSalt = GenerarSalt16();
                    SqlParameter paramSalt = new SqlParameter("@salt", SqlDbType.VarBinary, 16) { Value = nuevoSalt };

                    Ejecutar(
                        "UPDATE Usuarios SET Nombres = @nombres, Apellidos = @apellidos, " +
                        "ClaveSalt = @salt, ClaveHash = HASHBYTES('SHA2_256', CONVERT(VARBINARY(MAX), @password) + @salt), " +
                        "Foto = @foto, IdRol = @rol, IdSucursal = @sucursal, IdSueldo = " + subconsultaSueldo + ", Activo = @activo " +
                        "WHERE NombreUsuario = @usuario",
                        new SqlParameter("@nombres", nombres),
                        new SqlParameter("@apellidos", apellidos),
                        paramSalt,
                        new SqlParameter("@password", nuevaContrasena),
                        paramFoto,
                        new SqlParameter("@rol", idRol),
                        new SqlParameter("@sucursal", idSucursal),
                        new SqlParameter("@cargo", cargo),
                        new SqlParameter("@activo", activo),
                        new SqlParameter("@usuario", usuario));
                }
                else
                {
                    Ejecutar(
                        "UPDATE Usuarios SET Nombres = @nombres, Apellidos = @apellidos, " +
                        "Foto = @foto, IdRol = @rol, IdSucursal = @sucursal, IdSueldo = " + subconsultaSueldo + ", Activo = @activo " +
                        "WHERE NombreUsuario = @usuario",
                        new SqlParameter("@nombres", nombres),
                        new SqlParameter("@apellidos", apellidos),
                        paramFoto,
                        new SqlParameter("@rol", idRol),
                        new SqlParameter("@sucursal", idSucursal),
                        new SqlParameter("@cargo", cargo),
                        new SqlParameter("@activo", activo),
                        new SqlParameter("@usuario", usuario));
                }
            }
            else
            {
                Ejecutar(
                    "UPDATE Usuarios SET Nombres = @nombres, Apellidos = @apellidos, " +
                    "Foto = @foto, IdSucursal = @sucursal, IdSueldo = " + subconsultaSueldo + " " +
                    "WHERE NombreUsuario = @usuario",
                    new SqlParameter("@nombres", nombres),
                    new SqlParameter("@apellidos", apellidos),
                    paramFoto,
                    new SqlParameter("@sucursal", idSucursal),
                    new SqlParameter("@cargo", cargo),
                    new SqlParameter("@usuario", usuario));
            }
        }

        private void btnDesactivarUsuario_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            if (!EsSuperadministrador())
            {
                MessageBox.Show("Solo el superadministrador puede desactivar cuentas.");
                return;
            }

            chkUsuarioActivo.Checked = false;
            btnGuardarUsuario_Click(sender, e);
        }

        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarUsuario();
        }

        private void LimpiarUsuario()
        {
            idUsuarioSeleccionado = 0;
            txtNombreUsuario.Clear();
            txtNombreCompleto.Clear();
            txtCargo.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = -1;
            cmbSucursalUsuario.SelectedIndex = -1;
            chkUsuarioActivo.Checked = true;
            fotoUsuario = null;
            picFotoUsuario.Image = null;
            txtNombreUsuario.Enabled = true;
        }

        // PESTANIA SUCURSALES

        private void btnNuevaSucursal_Click(object sender, EventArgs e)
        {
            LimpiarSucursal();
            txtCodigoSucursal.Focus();
        }

        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            try { CargarSucursales(); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron buscar sucursales: " + ex.Message);
            }
        }

        private void btnLimpiarSucursal_Click(object sender, EventArgs e)
        {
            txtBuscarSucursal.Clear();

            try { CargarSucursales(); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar sucursales: " + ex.Message);
            }
        }

        private void dgvSucursales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow == null ||
                dgvSucursales.CurrentRow.DataBoundItem == null)
                return;

            DataRowView fila = dgvSucursales.CurrentRow.DataBoundItem as DataRowView;
            if (fila == null) return;

            idSucursalSeleccionada = Convert.ToInt32(fila["IdSucursal"]);
            txtCodigoSucursal.Text = Convert.ToString(fila["Codigo"]);
            txtNombreSucursal.Text = Convert.ToString(fila["Nombre"]);
            txtCiudadSucursal.Text = Convert.ToString(fila["Ciudad"]);
            txtDireccionSucursal.Text = Convert.ToString(fila["Direccion"]);
            txtTelefonoSucursal.Text = Convert.ToString(fila["Telefono"]);
            chkSucursalActivo.Checked = Convert.ToBoolean(fila["Activo"]);
        }

        private void btnGuardarSucursal_Click(object sender, EventArgs e)
        {
            if (!EsSuperadministrador())
            {
                MessageBox.Show("Solo el superadministrador puede modificar sucursales.");
                return;
            }

            if (txtCodigoSucursal.Text.Trim() == "" ||
                txtNombreSucursal.Text.Trim() == "" ||
                txtCiudadSucursal.Text.Trim() == "")
            {
                MessageBox.Show("Complete código, nombre y ciudad.");
                return;
            }

            try
            {
                if (idSucursalSeleccionada == 0)
                {
                    Ejecutar(
                        "INSERT INTO Sucursales " +
                        "(Codigo, Nombre, Ciudad, Direccion, Telefono, Activo) " +
                        "VALUES (@codigo, @nombre, @ciudad, @direccion, @telefono, @activo)",
                        ParametrosSucursal());
                }
                else
                {
                    Ejecutar(
                        "UPDATE Sucursales SET Codigo=@codigo, Nombre=@nombre, Ciudad=@ciudad, " +
                        "Direccion=@direccion, Telefono=@telefono, Activo=@activo " +
                        "WHERE IdSucursal=@id",
                        ParametrosSucursal(
                            new SqlParameter("@id", idSucursalSeleccionada)));
                }

                CargarSucursales();
                CargarSucursalesCombo();
                LimpiarSucursal();

                MessageBox.Show("Sucursal guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la sucursal: " + ex.Message);
            }
        }

        private SqlParameter[] ParametrosSucursal(params SqlParameter[] adicionales)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@codigo", txtCodigoSucursal.Text.Trim()),
                new SqlParameter("@nombre", txtNombreSucursal.Text.Trim()),
                new SqlParameter("@ciudad", txtCiudadSucursal.Text.Trim()),
                new SqlParameter("@direccion", txtDireccionSucursal.Text.Trim()),
                new SqlParameter("@telefono", txtTelefonoSucursal.Text.Trim()),
                new SqlParameter("@activo", chkSucursalActivo.Checked)
            };

            if (adicionales == null || adicionales.Length == 0)
                return parametros;

            SqlParameter[] todos = new SqlParameter[parametros.Length + adicionales.Length];
            parametros.CopyTo(todos, 0);
            adicionales.CopyTo(todos, parametros.Length);
            return todos;
        }

        private void btnDesactivarSucursal_Click(object sender, EventArgs e)
        {
            if (!EsSuperadministrador())
            {
                MessageBox.Show("Solo el superadministrador puede desactivar sucursales.");
                return;
            }

            if (idSucursalSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una sucursal.");
                return;
            }

            try
            {
                Ejecutar(
                    "UPDATE Sucursales SET Activo = 0 WHERE IdSucursal = @id",
                    new SqlParameter("@id", idSucursalSeleccionada));

                CargarSucursales();
                CargarSucursalesCombo();
                LimpiarSucursal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo desactivar la sucursal: " + ex.Message);
            }
        }

        private void btnCancelarSucursal_Click(object sender, EventArgs e)
        {
            LimpiarSucursal();
        }

        private void LimpiarSucursal()
        {
            idSucursalSeleccionada = 0;
            txtCodigoSucursal.Clear();
            txtNombreSucursal.Clear();
            txtCiudadSucursal.Clear();
            txtDireccionSucursal.Clear();
            txtTelefonoSucursal.Clear();
            chkSucursalActivo.Checked = true;
        }

        // PESTANIA CONFIGURACION

        private void CargarConfiguracion()
        {
            DataTable tabla = Consultar(
                "SELECT TOP 1 NombreComercial, RazonSocial, NIT, Telefono, Correo, " +
                "DireccionPrincipal, Logo, Moneda, MensajeComprobante " +
                "FROM ConfiguracionNegocio WHERE IdConfiguracion = 1");

            if (tabla.Rows.Count == 0)
                return;

            DataRow fila = tabla.Rows[0];

            txtNombreComercial.Text = Convert.ToString(fila["NombreComercial"]);
            txtRazonSocial.Text = Convert.ToString(fila["RazonSocial"]);
            txtNIT.Text = Convert.ToString(fila["NIT"]);
            txtTelefonoNegocio.Text = Convert.ToString(fila["Telefono"]);
            txtCorreoNegocio.Text = Convert.ToString(fila["Correo"]);
            txtDireccionPrincipal.Text = Convert.ToString(fila["DireccionPrincipal"]);
            txtMoneda.Text = Convert.ToString(fila["Moneda"]);
            txtMensajeComprobante.Text = Convert.ToString(fila["MensajeComprobante"]);

            logoNegocio = fila["Logo"] == DBNull.Value
                ? null
                : (byte[])fila["Logo"];

            MostrarLogo();
        }

        private void btnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            if (txtNombreComercial.Text.Trim() == "" ||
                txtMoneda.Text.Trim() == "")
            {
                MessageBox.Show("Complete el nombre comercial y la moneda.");
                return;
            }

            try
            {
                SqlParameter paramLogo = new SqlParameter("@logo", SqlDbType.VarBinary, -1)
                {
                    Value = (object)logoNegocio ?? DBNull.Value
                };

                int filas = Ejecutar(
                    "UPDATE ConfiguracionNegocio SET NombreComercial=@nombre, " +
                    "RazonSocial=@razon, NIT=@nit, Telefono=@telefono, Correo=@correo, " +
                    "DireccionPrincipal=@direccion, Logo=@logo, Moneda=@moneda, " +
                    "MensajeComprobante=@mensaje WHERE IdConfiguracion=1",
                    new SqlParameter("@nombre", txtNombreComercial.Text.Trim()),
                    new SqlParameter("@razon", txtRazonSocial.Text.Trim()),
                    new SqlParameter("@nit", txtNIT.Text.Trim()),
                    new SqlParameter("@telefono", txtTelefonoNegocio.Text.Trim()),
                    new SqlParameter("@correo", txtCorreoNegocio.Text.Trim()),
                    new SqlParameter("@direccion", txtDireccionPrincipal.Text.Trim()),
                    paramLogo,
                    new SqlParameter("@moneda", txtMoneda.Text.Trim()),
                    new SqlParameter("@mensaje", txtMensajeComprobante.Text.Trim()));

                if (filas == 0)
                {
                    SqlParameter paramLogoInsert = new SqlParameter("@logo", SqlDbType.VarBinary, -1)
                    {
                        Value = (object)logoNegocio ?? DBNull.Value
                    };

                    Ejecutar(
                        "INSERT INTO ConfiguracionNegocio " +
                        "(IdConfiguracion, NombreComercial, RazonSocial, NIT, Telefono, " +
                        "Correo, DireccionPrincipal, Logo, Moneda, MensajeComprobante) " +
                        "VALUES (1, @nombre, @razon, @nit, @telefono, @correo, " +
                        "@direccion, @logo, @moneda, @mensaje)",
                        new SqlParameter("@nombre", txtNombreComercial.Text.Trim()),
                        new SqlParameter("@razon", txtRazonSocial.Text.Trim()),
                        new SqlParameter("@nit", txtNIT.Text.Trim()),
                        new SqlParameter("@telefono", txtTelefonoNegocio.Text.Trim()),
                        new SqlParameter("@correo", txtCorreoNegocio.Text.Trim()),
                        new SqlParameter("@direccion", txtDireccionPrincipal.Text.Trim()),
                        paramLogoInsert,
                        new SqlParameter("@moneda", txtMoneda.Text.Trim()),
                        new SqlParameter("@mensaje", txtMensajeComprobante.Text.Trim()));
                }

                MessageBox.Show("Configuración guardada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la configuración: " + ex.Message);
            }
        }

        private void btnCancelarConfiguracion_Click(object sender, EventArgs e)
        {
            try { CargarConfiguracion(); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la configuración: " + ex.Message);
            }
        }

        private void btnCargarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    logoNegocio = File.ReadAllBytes(dialogo.FileName);
                    MostrarLogo();
                }
            }
        }

        private void btnQuitarLogo_Click(object sender, EventArgs e)
        {
            logoNegocio = null;
            pictureBox1.Image = null;
        }

        private void MostrarLogo()
        {
            if (logoNegocio == null)
            {
                pictureBox1.Image = null;
                return;
            }

            using (MemoryStream memoria = new MemoryStream(logoNegocio))
            using (Image imagen = Image.FromStream(memoria))
            {
                pictureBox1.Image = new Bitmap(imagen);
            }
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}