using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CentralCel.Datos;

namespace CentralCel.Formularios._2.Inventario
{
    public partial class FormInventario : Form
    {
        private int idProductoActual = 0;
        private int stockActualProducto = 0;

        public FormInventario()
        {
            InitializeComponent();
            ConectarEventos();
        }

        private void ConectarEventos()
        {
            this.Load += FormInventario_Load;
            btnVolverMenu.Click += btnVolverMenu_Click;
            btnCatalogo.Click += btnCatalogo_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;

            dgvInventario.SelectionChanged += dgvInventario_SelectionChanged;

            btnNuevaProducto.Click += btnNuevaProducto_Click;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            btnCancelarProducto.Click += btnCancelarProducto_Click;
            btnDesactivarProducto.Click += btnDesactivarProducto_Click;
            btnAgregarMercaderia.Click += btnAgregarMercaderia_Click;
            btnVerKardex.Click += btnVerKardex_Click;
            nudCantidadEntrada.ValueChanged += nudCantidadEntrada_ValueChanged;
        }

        // Metodos Auxiliares
        private DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            return tabla;
        }

        private void Ejecutar(string sql, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LlenarCombo(ComboBox combo, string sql, string texto, string valor)
        {
            combo.DataSource = Consultar(sql);
            combo.DisplayMember = texto;
            combo.ValueMember = valor;
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            lblSesion.Text = "Usuario: " + UsuarioSesion.Usuario + " | Sucursal: " + UsuarioSesion.Sucursal;
            dgvInventario.AutoGenerateColumns = false;

            CargarCombos();
            CargarInventario();
        }

        private void CargarCombos()
        {
            // Combos del panel de productos
            LlenarCombo(cmbCategoriaProducto, "SELECT IdCategoria, Nombre FROM Categorias WHERE Activo = 1 ORDER BY Nombre", "Nombre", "IdCategoria");
            LlenarCombo(cmbMarcaProducto, "SELECT IdMarca, Nombre FROM Marcas WHERE Activo = 1 ORDER BY Nombre", "Nombre", "IdMarca");
            LlenarCombo(cmbProveedorEntrada, "SELECT IdProveedor, Nombre FROM Proveedores WHERE Activo = 1 ORDER BY Nombre", "Nombre", "IdProveedor");
            // Combos de filtros
            LlenarCombo(cmbFiltroCategoria, "SELECT 0 AS Id, N'(Todos)' AS Nombre UNION ALL SELECT IdCategoria, Nombre FROM Categorias ORDER BY Id", "Nombre", "Id");
            LlenarCombo(cmbFiltroMarca, "SELECT 0 AS Id, N'(Todos)' AS Nombre UNION ALL SELECT IdMarca, Nombre FROM Marcas ORDER BY Id", "Nombre", "Id");
            LlenarCombo(cmbFiltroProveedor, "SELECT 0 AS Id, N'(Todos)' AS Nombre UNION ALL SELECT IdProveedor, Nombre FROM Proveedores ORDER BY Id", "Nombre", "Id");
            LlenarCombo(cmbFiltroSucursal, "SELECT IdSucursal, Nombre FROM Sucursales WHERE Activo = 1 ORDER BY Nombre", "Nombre", "IdSucursal");
            cmbFiltroSucursal.SelectedValue = UsuarioSesion.IdSucursal;
            cmbFiltroDisponibilidad.Items.Clear();
            cmbFiltroDisponibilidad.Items.AddRange(new object[] { "Todos", "Disponible", "Bajo Mínimo", "Agotado" });
            cmbFiltroDisponibilidad.SelectedIndex = 0;
        }

        // Filtros de Productos
        private void CargarInventario()
        {
            try
            {
                LimpiarCampos();

                DataTable dt = Consultar(@"
                    SELECT * FROM (
                        SELECT p.IdProducto, p.Codigo, p.Nombre AS Producto, m.Nombre AS Marca,
                               p.PrecioVenta, e.StockActual AS Stock, e.StockMinimo,
                               CASE WHEN e.StockActual = 0 THEN N'Agotado'
                                    WHEN e.StockActual <= e.StockMinimo THEN N'Bajo Mínimo'
                                    ELSE N'Disponible' END AS EstadoStock
                        FROM Productos p
                        JOIN Marcas m ON m.IdMarca = p.IdMarca
                        JOIN Existencias e ON e.IdProducto = p.IdProducto AND e.IdSucursal = @suc
                        WHERE p.Activo = 1
                          AND (p.Codigo LIKE @texto OR p.Nombre LIKE @texto)
                          AND (@cat = 0 OR p.IdCategoria = @cat)
                          AND (@mar = 0 OR p.IdMarca = @mar)
                          AND (@prov = 0 OR p.IdProducto IN (SELECT IdProducto FROM ProductosProveedores WHERE IdProveedor = @prov))
                    ) x
                    WHERE (@disp = N'Todos' OR x.EstadoStock = @disp)
                    ORDER BY x.Producto",
                    new SqlParameter("@suc", cmbFiltroSucursal.SelectedValue),
                    new SqlParameter("@texto", "%" + txtBuscarProducto.Text.Trim() + "%"),
                    new SqlParameter("@cat", cmbFiltroCategoria.SelectedValue),
                    new SqlParameter("@mar", cmbFiltroMarca.SelectedValue),
                    new SqlParameter("@prov", cmbFiltroProveedor.SelectedValue),
                    new SqlParameter("@disp", cmbFiltroDisponibilidad.Text));

                dgvInventario.DataSource = dt;

                int agotados = dt.Select("EstadoStock = 'Agotado'").Length;
                int bajoMinimo = dt.Select("EstadoStock = 'Bajo Mínimo'").Length;
                lblAlertasStock.Text = "Bajo Mínimo: " + bajoMinimo + " | Agotados: " + agotados;
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar inventario: " + ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Clear();
            cmbFiltroCategoria.SelectedIndex = 0;
            cmbFiltroMarca.SelectedIndex = 0;
            cmbFiltroProveedor.SelectedIndex = 0;
            cmbFiltroDisponibilidad.SelectedIndex = 0;
            cmbFiltroSucursal.SelectedValue = UsuarioSesion.IdSucursal;
            CargarInventario();
        }

        // Carga de Datos del producto
        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            MostrarProductoSeleccionado();
        }

        private void MostrarProductoSeleccionado()
        {
            if (dgvInventario.CurrentRow == null) return;

            idProductoActual = Convert.ToInt32(dgvInventario.CurrentRow.Cells["colIdProducto"].Value);

            DataTable dt = Consultar(@"SELECT p.*, e.StockActual, e.StockMinimo
                                       FROM Productos p
                                       JOIN Existencias e ON e.IdProducto = p.IdProducto AND e.IdSucursal = @s
                                       WHERE p.IdProducto = @id",
                new SqlParameter("@s", UsuarioSesion.IdSucursal),
                new SqlParameter("@id", idProductoActual));

            DataRow r = dt.Rows[0];
            txtCodigoProducto.Text = Convert.ToString(r["Codigo"]);
            txtNombreProducto.Text = Convert.ToString(r["Nombre"]);
            txtModeloProducto.Text = Convert.ToString(r["Modelo"]);
            txtCompatibilidadProducto.Text = Convert.ToString(r["Compatibilidad"]);
            txtColorProducto.Text = Convert.ToString(r["Color"]);
            cmbCategoriaProducto.SelectedValue = r["IdCategoria"];
            cmbMarcaProducto.SelectedValue = r["IdMarca"];
            nudPrecioVenta.Value = Convert.ToDecimal(r["PrecioVenta"]);
            nudStockMinimo.Value = Convert.ToInt32(r["StockMinimo"]);
            chkProductoActivo.Checked = Convert.ToBoolean(r["Activo"]);

            stockActualProducto = Convert.ToInt32(r["StockActual"]);
            ActualizarResumenStock();
        }

        private void btnNuevaProducto_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCodigoProducto.Focus();
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            MostrarProductoSeleccionado();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Trim() == "" || txtNombreProducto.Text.Trim() == "")
            {
                MessageBox.Show("Complete el código y el nombre del producto.");
                return;
            }

            try
            {
                if (idProductoActual == 0)
                {
                    // Registro de Nuevo Producto
                    DataTable dt = Consultar(@"DECLARE @nuevo INT;
                        INSERT INTO Productos (Codigo, Nombre, IdCategoria, IdMarca, Modelo, Compatibilidad, Color, PrecioVenta, Activo)
                        VALUES (@c, @n, @cat, @mar, @mod, @comp, @col, @prec, @act);
                        SET @nuevo = SCOPE_IDENTITY();
                        INSERT INTO Existencias (IdProducto, IdSucursal) SELECT @nuevo, IdSucursal FROM Sucursales;
                        SELECT @nuevo AS Id",
                        new SqlParameter("@c", txtCodigoProducto.Text.Trim()),
                        new SqlParameter("@n", txtNombreProducto.Text.Trim()),
                        new SqlParameter("@cat", cmbCategoriaProducto.SelectedValue),
                        new SqlParameter("@mar", cmbMarcaProducto.SelectedValue),
                        new SqlParameter("@mod", txtModeloProducto.Text.Trim()),
                        new SqlParameter("@comp", txtCompatibilidadProducto.Text.Trim()),
                        new SqlParameter("@col", txtColorProducto.Text.Trim()),
                        new SqlParameter("@prec", nudPrecioVenta.Value),
                        new SqlParameter("@act", chkProductoActivo.Checked));
                    idProductoActual = Convert.ToInt32(dt.Rows[0]["Id"]);
                }
                else
                {
                    // nUEVAS eXISTENCIAS
                    Ejecutar(@"UPDATE Productos SET Codigo=@c, Nombre=@n, IdCategoria=@cat, IdMarca=@mar,
                                      Modelo=@mod, Compatibilidad=@comp, Color=@col, PrecioVenta=@prec, Activo=@act
                               WHERE IdProducto=@id",
                        new SqlParameter("@c", txtCodigoProducto.Text.Trim()),
                        new SqlParameter("@n", txtNombreProducto.Text.Trim()),
                        new SqlParameter("@cat", cmbCategoriaProducto.SelectedValue),
                        new SqlParameter("@mar", cmbMarcaProducto.SelectedValue),
                        new SqlParameter("@mod", txtModeloProducto.Text.Trim()),
                        new SqlParameter("@comp", txtCompatibilidadProducto.Text.Trim()),
                        new SqlParameter("@col", txtColorProducto.Text.Trim()),
                        new SqlParameter("@prec", nudPrecioVenta.Value),
                        new SqlParameter("@act", chkProductoActivo.Checked),
                        new SqlParameter("@id", idProductoActual));
                }

                // Stock Minimo
                Ejecutar("UPDATE Existencias SET StockMinimo = @min WHERE IdProducto = @p AND IdSucursal = @s",
                    new SqlParameter("@min", Convert.ToInt32(nudStockMinimo.Value)),
                    new SqlParameter("@p", idProductoActual),
                    new SqlParameter("@s", UsuarioSesion.IdSucursal));

                MessageBox.Show("Producto guardado correctamente.");
                CargarInventario();
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }
        }

        private void btnDesactivarProducto_Click(object sender, EventArgs e)
        {
            if (idProductoActual == 0)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Desactivar este producto?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                Ejecutar("UPDATE Productos SET Activo = 0 WHERE IdProducto = @id",
                    new SqlParameter("@id", idProductoActual));
                MessageBox.Show("Producto desactivado.");
                CargarInventario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // Ingreso de Mercaderia
        private void btnAgregarMercaderia_Click(object sender, EventArgs e)
        {
            if (idProductoActual == 0)
            {
                MessageBox.Show("Seleccione un producto para agregarle mercadería.");
                return;
            }
            if (nudCantidadEntrada.Value <= 0)
            {
                MessageBox.Show("Ingrese una cantidad mayor a cero.");
                return;
            }
            if (cmbProveedorEntrada.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            try
            {
                // Guarda el stock y lo relaciona con el proveedor
                Ejecutar(@"INSERT INTO MovimientosManuales (Fecha, IdProducto, IdSucursal, IdUsuario, TipoMovimiento, CantidadMovimiento, StockAnterior, IdProveedor, Referencia)
                           SELECT @f, @p, @s, @u, N'Entrada', @cant, StockActual, @prov, @ref
                           FROM Existencias WHERE IdProducto = @p AND IdSucursal = @s;

                           UPDATE Existencias SET StockActual = StockActual + @cant
                           WHERE IdProducto = @p AND IdSucursal = @s;

                           IF NOT EXISTS (SELECT 1 FROM ProductosProveedores WHERE IdProducto = @p AND IdProveedor = @prov)
                               INSERT INTO ProductosProveedores (IdProducto, IdProveedor) VALUES (@p, @prov);",
                    new SqlParameter("@f", dtpFechaEntrada.Value),
                    new SqlParameter("@p", idProductoActual),
                    new SqlParameter("@s", UsuarioSesion.IdSucursal),
                    new SqlParameter("@u", UsuarioSesion.IdUsuario),
                    new SqlParameter("@cant", Convert.ToInt32(nudCantidadEntrada.Value)),
                    new SqlParameter("@prov", cmbProveedorEntrada.SelectedValue),
                    new SqlParameter("@ref", txtReferenciaEntrada.Text.Trim()));

                MessageBox.Show("Mercadería registrada.");
                CargarInventario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnVerKardex_Click(object sender, EventArgs e)
        {
            if (idProductoActual == 0)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            DataTable dt = Consultar(@"SELECT TOP 20 Fecha, TipoMovimiento, CantidadMovimiento, Referencia, Motivo
                                       FROM MovimientosManuales
                                       WHERE IdProducto = @p AND IdSucursal = @s
                                       ORDER BY Fecha DESC",
                new SqlParameter("@p", idProductoActual),
                new SqlParameter("@s", UsuarioSesion.IdSucursal));

            string mensaje = "KARDEX - " + txtNombreProducto.Text + "\n\n";
            foreach (DataRow r in dt.Rows)
            {
                mensaje += Convert.ToDateTime(r["Fecha"]).ToString("dd/MM/yyyy") + " | " +
                           r["TipoMovimiento"] + " | " + r["CantidadMovimiento"] + " | " +
                           r["Referencia"] + " | " + r["Motivo"] + "\n";
            }
            MessageBox.Show(mensaje, "Kardex");
        }

        private void nudCantidadEntrada_ValueChanged(object sender, EventArgs e)
        {
            ActualizarResumenStock();
        }

        private void ActualizarResumenStock()
        {
            int resultante = stockActualProducto + Convert.ToInt32(nudCantidadEntrada.Value);
            lblResumenStock.Text = "Stock Actual: " + stockActualProducto + " | Stock Resultante: " + resultante;
        }

        // Limpia los campos
        private void LimpiarCampos()
        {
            idProductoActual = 0;
            stockActualProducto = 0;
            txtCodigoProducto.Clear();
            txtNombreProducto.Clear();
            txtModeloProducto.Clear();
            txtCompatibilidadProducto.Clear();
            txtColorProducto.Clear();
            nudPrecioVenta.Value = 0;
            nudStockMinimo.Value = 0;
            chkProductoActivo.Checked = true;
            nudCantidadEntrada.Value = 0;
            txtReferenciaEntrada.Clear();
            dtpFechaEntrada.Value = DateTime.Now;
            ActualizarResumenStock();
        }
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            using (FormCatalogosInventario frm = new FormCatalogosInventario())
            {
                frm.ShowDialog();
            }
            CargarCombos();
            CargarInventario();
        }
    }
}
