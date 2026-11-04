using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CentralCel.Datos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CentralCel.Formularios._2.Inventario
{
    public partial class FormCatalogosInventario : Form
    {
        private int idCategoria = 0;
        private int idMarca = 0;
        private int idProveedor = 0;

        public FormCatalogosInventario()
        {
            InitializeComponent();
            CargarCategorias();
            CargarMarcas();
            CargarProveedores();

            //Carga de Eventos
            btnVolverInventario.Click += (s, e) => Close();
            btnBuscarCategoria.Click += (s, e) => CargarCategorias();
            btnLimpiarBusquedaCategoria.Click += (s, e) => { txtBuscarCategoria.Clear(); CargarCategorias(); };
            btnNuevaCategoria.Click += (s, e) => LimpiarCategoria();
            btnGuardarCategoria.Click += GuardarCategoria;
            btnCancelarCategoria.Click += (s, e) => LimpiarCategoria();
            btnDesactivarCategoria.Click += DesactivarCategoria;
            dgvCategorias.SelectionChanged += SeleccionarCategoria;

            btnBuscarMarca.Click += (s, e) => CargarMarcas();
            btnLimpiarBusquedaMarca.Click += (s, e) => { txtBuscarMarca.Clear(); CargarMarcas(); };
            btnNuevaMarca.Click += (s, e) => LimpiarMarca();
            btnGuardarMarca.Click += GuardarMarca;
            btnCancelarMarca.Click += (s, e) => LimpiarMarca();
            btnDesactivarMarca.Click += DesactivarMarca;
            dgvMarcas.SelectionChanged += SeleccionarMarca;

            btnBuscarProveedor.Click += (s, e) => CargarProveedores();
            btnLimpiarBusquedaProveedor.Click += (s, e) => { txtBuscarProveedor.Clear(); CargarProveedores(); };
            btnNuevoProveedor.Click += (s, e) => LimpiarProveedor();
            btnGuardarProveedor.Click += GuardarProveedor;
            btnCancelarProveedor.Click += (s, e) => LimpiarProveedor();
            btnDesactivarProveedor.Click += DesactivarProveedor;
            dgvProveedores.SelectionChanged += SeleccionarProveedor;
        }

        private DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(tabla);
            }
            return tabla;
        }

        private void Ejecutar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                cmd.ExecuteNonQuery();
            }
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = Consultar(
                "SELECT IdCategoria, Codigo, Nombre, CASE WHEN Activo=1 THEN N'Activo' ELSE N'Inactivo' END AS Estado FROM Categorias WHERE Codigo LIKE @b OR Nombre LIKE @b ORDER BY Nombre",
                new SqlParameter("@b", "%" + txtBuscarCategoria.Text.Trim() + "%"));
        }

        private void CargarMarcas()
        {
            dgvMarcas.DataSource = Consultar(
                "SELECT IdMarca, Codigo, Nombre, CASE WHEN Activo=1 THEN N'Activa' ELSE N'Inactiva' END AS Estado FROM Marcas WHERE Codigo LIKE @b OR Nombre LIKE @b ORDER BY Nombre",
                new SqlParameter("@b", "%" + txtBuscarMarca.Text.Trim() + "%"));
        }

        private void CargarProveedores()
        {
            dgvProveedores.DataSource = Consultar(
                "SELECT IdProveedor, Codigo, Nombre, Telefono, CASE WHEN Activo=1 THEN N'Activo' ELSE N'Inactivo' END AS Estado FROM Proveedores WHERE Codigo LIKE @b OR Nombre LIKE @b ORDER BY Nombre",
                new SqlParameter("@b", "%" + txtBuscarProveedor.Text.Trim() + "%"));
        }

        private void SeleccionarCategoria(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;
            idCategoria = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["colIdCategoria"].Value);
            txtCodigoCategoria.Text = Convert.ToString(dgvCategorias.CurrentRow.Cells["colCodigo"].Value);
            txtNombreCategoria.Text = Convert.ToString(dgvCategorias.CurrentRow.Cells["colNombreCategoria"].Value);
            chkCategoriaActivo.Checked = Convert.ToString(dgvCategorias.CurrentRow.Cells["colMarca"].Value) == "Activo";
        }

        private void GuardarCategoria(object sender, EventArgs e)
        {
            if (txtCodigoCategoria.Text.Trim() == "" || txtNombreCategoria.Text.Trim() == "") 
            { 
                MessageBox.Show("Complete código y nombre."); return; 
            }
            try
            {
                if (idCategoria == 0)
                    Ejecutar("INSERT INTO Categorias (Codigo, Nombre) VALUES (@c, @n)", 
                        new SqlParameter("@c", txtCodigoCategoria.Text.Trim()), 
                        new SqlParameter("@n", txtNombreCategoria.Text.Trim()));
                else
                    Ejecutar("UPDATE Categorias SET Codigo=@c, Nombre=@n, Activo=@a WHERE IdCategoria=@id", 
                        new SqlParameter("@c", txtCodigoCategoria.Text.Trim()), 
                        new SqlParameter("@n", txtNombreCategoria.Text.Trim()), 
                        new SqlParameter("@a", chkCategoriaActivo.Checked), 
                        new SqlParameter("@id", idCategoria));
                CargarCategorias(); 
                LimpiarCategoria();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al guardar categoría: " + ex.Message); 
            }
        }

        private void DesactivarCategoria(object sender, EventArgs e)
        {
            if (idCategoria == 0) return;
            try 
            { 
                Ejecutar("UPDATE Categorias SET Activo=0 WHERE IdCategoria=@id", 
                    new SqlParameter("@id", idCategoria)); 
                CargarCategorias(); 
                LimpiarCategoria(); 
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al desactivar categoría: " + ex.Message); 
            }
        }

        private void LimpiarCategoria() 
        { 
            idCategoria = 0; 
            txtCodigoCategoria.Clear(); 
            txtNombreCategoria.Clear(); 
            chkCategoriaActivo.Checked = true; 
            dgvCategorias.ClearSelection(); 
        }

        private void SeleccionarMarca(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null) return;
            idMarca = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["colIdMarca"].Value);
            txtCodigoMarca.Text = Convert.ToString(dgvMarcas.CurrentRow.Cells["colCodigoMarca"].Value);
            txtNombreMarca.Text = Convert.ToString(dgvMarcas.CurrentRow.Cells["colNombreMarca"].Value);
            chkMarcaActiva.Checked = Convert.ToString(dgvMarcas.CurrentRow.Cells["colEstadoMarca"].Value) == "Activa";
        }

        private void GuardarMarca(object sender, EventArgs e)
        {
            if (txtCodigoMarca.Text.Trim() == "" || txtNombreMarca.Text.Trim() == "") 
            { 
                MessageBox.Show("Complete código y nombre."); return; 
            }
            try
            {
                if (idMarca == 0)
                    Ejecutar("INSERT INTO Marcas (Codigo, Nombre) VALUES (@c, @n)", 
                        new SqlParameter("@c", txtCodigoMarca.Text.Trim()), 
                        new SqlParameter("@n", txtNombreMarca.Text.Trim()));
                else
                    Ejecutar("UPDATE Marcas SET Codigo=@c, Nombre=@n, Activo=@a WHERE IdMarca=@id", 
                        new SqlParameter("@c", txtCodigoMarca.Text.Trim()), 
                        new SqlParameter("@n", txtNombreMarca.Text.Trim()), 
                        new SqlParameter("@a", chkMarcaActiva.Checked), 
                        new SqlParameter("@id", idMarca));
                CargarMarcas(); 
                LimpiarMarca();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al guardar marca: " + ex.Message); 
            }
        }

        private void DesactivarMarca(object sender, EventArgs e)
        {
            if (idMarca == 0) return;
            try 
            { 
                Ejecutar("UPDATE Marcas SET Activo=0 WHERE IdMarca=@id", new SqlParameter("@id", idMarca)); 
                CargarMarcas(); 
                LimpiarMarca(); 
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al desactivar marca: " + ex.Message); 
            }
        }

        private void LimpiarMarca() 
        { 
            idMarca = 0; txtCodigoMarca.Clear(); 
            txtNombreMarca.Clear(); 
            chkMarcaActiva.Checked = true; 
            dgvMarcas.ClearSelection(); 
        }

        private void SeleccionarProveedor(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;
            idProveedor = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["colIdProveedor"].Value);
            txtCodigoProveedor.Text = Convert.ToString(dgvProveedores.CurrentRow.Cells["colCodigoProveedor"].Value);
            txtNombreProveedor.Text = Convert.ToString(dgvProveedores.CurrentRow.Cells["colNombreProveedor"].Value);
            txtTelefonoProveedor.Text = Convert.ToString(dgvProveedores.CurrentRow.Cells["colTelefonoProveedor"].Value);
            chkProveedorActivo.Checked = Convert.ToString(dgvProveedores.CurrentRow.Cells["colEstadoProveedor"].Value) == "Activo";
        }

        private void GuardarProveedor(object sender, EventArgs e)
        {
            if (txtCodigoProveedor.Text.Trim() == "" || txtNombreProveedor.Text.Trim() == "") 
            { 
                MessageBox.Show("Complete código y nombre."); return; 
            }
            try
            {
                if (idProveedor == 0)
                    Ejecutar("INSERT INTO Proveedores (Codigo, Nombre, Telefono, NIT, Direccion, Correo) VALUES (@c, @n, @t, @nit, @d, @co)", new SqlParameter("@c", txtCodigoProveedor.Text.Trim()), new SqlParameter("@n", txtNombreProveedor.Text.Trim()), new SqlParameter("@t", txtTelefonoProveedor.Text.Trim()), new SqlParameter("@nit", txtNitProveedor.Text.Trim()), new SqlParameter("@d", txtDireccionProveedor.Text.Trim()), new SqlParameter("@co", txtCorreoProveedor.Text.Trim()));
                else
                    Ejecutar("UPDATE Proveedores SET Codigo=@c, Nombre=@n, Telefono=@t, NIT=@nit, Direccion=@d, Correo=@co, Activo=@a WHERE IdProveedor=@id", 
                        new SqlParameter("@c", txtCodigoProveedor.Text.Trim()), 
                        new SqlParameter("@n", txtNombreProveedor.Text.Trim()), 
                        new SqlParameter("@t", txtTelefonoProveedor.Text.Trim()), 
                        new SqlParameter("@nit", txtNitProveedor.Text.Trim()), 
                        new SqlParameter("@d", txtDireccionProveedor.Text.Trim()), 
                        new SqlParameter("@co", txtCorreoProveedor.Text.Trim()), 
                        new SqlParameter("@a", chkProveedorActivo.Checked), 
                        new SqlParameter("@id", idProveedor));
                CargarProveedores(); 
                LimpiarProveedor();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al guardar proveedor: " + ex.Message); 
            }
        }

        private void DesactivarProveedor(object sender, EventArgs e)
        {
            if (idProveedor == 0) return;
            try 
            { 
                Ejecutar("UPDATE Proveedores SET Activo=0 WHERE IdProveedor=@id", 
                    new SqlParameter("@id", idProveedor)); 
                CargarProveedores(); 
                LimpiarProveedor(); 
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al desactivar proveedor: " + ex.Message); 
            }
        }

        private void LimpiarProveedor() 
        { 
            idProveedor = 0; 
            txtCodigoProveedor.Clear(); 
            txtNombreProveedor.Clear(); 
            txtTelefonoProveedor.Clear(); 
            txtNitProveedor.Clear(); 
            txtDireccionProveedor.Clear(); 
            txtCorreoProveedor.Clear(); 
            chkProveedorActivo.Checked = true; 
            dgvProveedores.ClearSelection(); 
        }
    }
}

