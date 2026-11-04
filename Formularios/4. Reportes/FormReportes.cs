using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Security;
using System.Windows.Forms;

namespace CentralCel.Formularios._4._Reportes
{
    public partial class FormReportes : Form
    {
        private Button btnExportarExcel;
        private Button btnExportarCSV;
        private Label lblResumen;

        public FormReportes()
        {
            InitializeComponent();

            ConfigurarFormulario();
            CrearBotonesExportacion();
            CargarFiltros();

            btnGenerar.Click -= btnGenerar_Click;
            btnGenerar.Click += btnGenerar_Click;

            btnLimpiar.Click -= btnLimpiar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            btnVolverMenu.Click -= btnVolverMenu_Click;
            btnVolverMenu.Click += btnVolverMenu_Click;

            cmbTipoReporte.SelectedIndexChanged +=
                cmbTipoReporte_SelectedIndexChanged;

            cmbTipoReporte.SelectedIndex = 0;
        }

        private void ConfigurarFormulario()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.AddRange(new string[]
            {
                "Ventas",
                "Productos más vendidos",
                "Existencias",
                "Stock bajo",
                "Movimientos de inventario"
            });

            cmbTipoReporte.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbTipoMovimiento.Items.Clear();
            cmbTipoMovimiento.Items.AddRange(new string[]
            {
                "Todos",
                "Ingreso",
                "Ajuste",
                "Venta",
                "Traslado enviado",
                "Traslado recibido"
            });

            cmbTipoMovimiento.DropDownStyle =
                ComboBoxStyle.DropDownList;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            dgvReportes.ReadOnly = true;
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.MultiSelect = false;
            dgvReportes.RowHeadersVisible = false;

            dgvReportes.DefaultCellStyle.ForeColor = Color.Black;
            dgvReportes.DefaultCellStyle.BackColor = Color.White;
            dgvReportes.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvReportes.AlternatingRowsDefaultCellStyle.BackColor =
                Color.AliceBlue;

            lblTituloTarjeta1.Text = "Ventas confirmadas";
            lblTituloTarjeta2.Text = "Unidades vendidas";
            lblTituloTarjeta3.Text = "Total vendido";

            cmbTipoReporte.SelectedIndex = 0;
            cmbTipoMovimiento.SelectedIndex = 0;
        }

        private void CrearBotonesExportacion()
        {
            lblResumen = new Label();
            lblResumen.Text = "0 registros";
            lblResumen.AutoSize = true;
            lblResumen.ForeColor = Color.MidnightBlue;
            lblResumen.Location = new Point(5, 35);

            btnExportarExcel = new Button();
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.Size = new Size(150, 35);
            btnExportarExcel.Location = new Point(825, 20);
            btnExportarExcel.BackColor = Color.SteelBlue;
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Click += btnExportarExcel_Click;

            btnExportarCSV = new Button();
            btnExportarCSV.Text = "Exportar a CSV";
            btnExportarCSV.Size = new Size(150, 35);
            btnExportarCSV.Location = new Point(985, 20);
            btnExportarCSV.BackColor = Color.SteelBlue;
            btnExportarCSV.ForeColor = Color.White;
            btnExportarCSV.FlatStyle = FlatStyle.Flat;
            btnExportarCSV.Click += btnExportarCSV_Click;

            panelPie.Controls.Add(lblResumen);
            panelPie.Controls.Add(btnExportarExcel);
            panelPie.Controls.Add(btnExportarCSV);
        }

        private void CargarFiltros()
        {
            try
            {
                using (SqlConnection cn =
                    CentralCel.Datos.Conexion.ObtenerConexion())
                {
                    cn.Open();

                    CargarCombo(cn, cmbSucursal,
                        @"SELECT 0 AS IdSucursal, 'Todas' AS Nombre
                          UNION ALL
                          SELECT IdSucursal, Nombre
                          FROM Sucursales
                          WHERE Activo = 1
                          ORDER BY Nombre",
                        "Nombre", "IdSucursal");

                    CargarCombo(cn, cmbVendedor,
                        @"SELECT 0 AS IdUsuario, 'Todos' AS Nombre
                          UNION ALL
                          SELECT IdUsuario, NombreUsuario AS Nombre
                          FROM Usuarios
                          WHERE Activo = 1
                          ORDER BY Nombre",
                        "Nombre", "IdUsuario");

                    CargarCombo(cn, cmbCategoria,
                        @"SELECT 0 AS IdCategoria, 'Todas' AS Nombre
                          UNION ALL
                          SELECT IdCategoria, Nombre
                          FROM Categorias
                          ORDER BY Nombre",
                        "Nombre", "IdCategoria");

                    CargarCombo(cn, cmbMarca,
                        @"SELECT 0 AS IdMarca, 'Todas' AS Nombre
                          UNION ALL
                          SELECT IdMarca, Nombre
                          FROM Marcas
                          ORDER BY Nombre",
                        "Nombre", "IdMarca");

                    CargarCombo(cn, cmbProducto,
                        @"SELECT 0 AS IdProducto, 'Todos' AS Nombre
                          UNION ALL
                          SELECT IdProducto,
                                 Codigo + ' - ' + Nombre AS Nombre
                          FROM Productos
                          WHERE Activo = 1
                          ORDER BY Nombre",
                        "Nombre", "IdProducto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los filtros:\n" + ex.Message,
                    "Reportes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarCombo(
            SqlConnection cn,
            ComboBox combo,
            string consulta,
            string display,
            string value)
        {
            using (SqlDataAdapter da =
                new SqlDataAdapter(consulta, cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);

                combo.DataSource = tabla;
                combo.DisplayMember = display;
                combo.ValueMember = value;
                combo.SelectedIndex = 0;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private int ObtenerId(ComboBox combo)
        {
            if (combo.SelectedValue == null)
                return 0;

            int id;

            if (int.TryParse(combo.SelectedValue.ToString(), out id))
                return id;

            return 0;
        }

        private void cmbTipoReporte_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            string tipo = cmbTipoReporte.Text;

            bool esVenta = tipo == "Ventas";
            bool esProducto = tipo == "Productos más vendidos";
            bool esInventario =
                tipo == "Existencias" || tipo == "Stock bajo";
            bool esMovimiento =
                tipo == "Movimientos de inventario";

            lblDesde.Visible = esVenta || esProducto || esMovimiento;
            dtpDesde.Visible = esVenta || esProducto || esMovimiento;
            lblHasta.Visible = esVenta || esProducto || esMovimiento;
            dtpHasta.Visible = esVenta || esProducto || esMovimiento;

            lblSucursal.Visible = true;
            cmbSucursal.Visible = true;

            lblVendedor.Visible = esVenta;
            cmbVendedor.Visible = esVenta;

            lblCategoria.Visible = esInventario;
            cmbCategoria.Visible = esInventario;

            lblMarca.Visible = esInventario;
            cmbMarca.Visible = esInventario;

            lblProducto.Visible = esMovimiento;
            cmbProducto.Visible = esMovimiento;

            lblTipoMovimiento.Visible = esMovimiento;
            cmbTipoMovimiento.Visible = esMovimiento;

            panelTarjeta1.Visible = esVenta;
            panelTarjeta2.Visible = esVenta;
            panelTarjeta3.Visible = esVenta;

            lblTituloReporte.Text = tipo;

            if (esVenta)
                lblTituloReporte.Text =
                    "Ventas por fecha, sucursal y vendedor";
            else if (esProducto)
                lblTituloReporte.Text = "Productos más vendidos";
            else if (tipo == "Existencias")
                lblTituloReporte.Text =
                    "Existencias actuales por sucursal";
            else if (tipo == "Stock bajo")
                lblTituloReporte.Text =
                    "Productos con stock bajo o agotado";
            else
                lblTituloReporte.Text = "Movimientos del período";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipoReporte.Text;

            if ((tipo == "Ventas" ||
                 tipo == "Productos más vendidos" ||
                 tipo == "Movimientos de inventario") &&
                dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor que la fecha final.",
                    "Revisar fechas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable tabla = new DataTable();

                using (SqlConnection cn =
                    CentralCel.Datos.Conexion.ObtenerConexion())
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cn.Open();

                    cmd.CommandText = ObtenerConsulta(tipo);
                    AgregarParametros(cmd);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }

                dgvReportes.DataSource = tabla;
                ActualizarResumen(tabla);

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron datos con los filtros seleccionados.",
                        "Reportes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al generar el reporte:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string ObtenerConsulta(string tipo)
        {
            if (tipo == "Ventas")
            {
                return @"
                    SELECT
                        CONVERT(VARCHAR(10), v.Fecha, 103) AS Fecha,
                        v.NumeroVenta AS Venta,
                        s.Nombre AS Sucursal,
                        u.NombreUsuario AS Vendedor,
                        ISNULL(c.Nombre, 'Cliente general') AS Cliente,
                        SUM(dv.Cantidad) AS Unidades,
                        SUM(dv.Cantidad * dv.PrecioUnitario) AS Total
                    FROM Ventas v
                    INNER JOIN DetalleVenta dv
                        ON v.IdVenta = dv.IdVenta
                    INNER JOIN Sucursales s
                        ON v.IdSucursal = s.IdSucursal
                    INNER JOIN Usuarios u
                        ON v.IdUsuario = u.IdUsuario
                    LEFT JOIN Clientes c
                        ON v.IdCliente = c.IdCliente
                    WHERE v.Fecha >= @Desde
                      AND v.Fecha < DATEADD(DAY, 1, @Hasta)
                      AND v.FechaAnulacion IS NULL
                      AND (@Sucursal = 0 OR v.IdSucursal = @Sucursal)
                      AND (@Vendedor = 0 OR v.IdUsuario = @Vendedor)
                    GROUP BY v.Fecha, v.NumeroVenta,
                        s.Nombre, u.NombreUsuario, c.Nombre
                    ORDER BY v.Fecha DESC";
            }

            if (tipo == "Productos más vendidos")
            {
                return @"
                    SELECT
                        ROW_NUMBER() OVER (
                            ORDER BY SUM(dv.Cantidad) DESC
                        ) AS Posicion,
                        p.Codigo AS Codigo,
                        p.Nombre AS Producto,
                        m.Nombre AS Marca,
                        SUM(dv.Cantidad) AS UnidadesVendidas,
                        SUM(dv.Cantidad * dv.PrecioUnitario) AS Importe
                    FROM DetalleVenta dv
                    INNER JOIN Ventas v
                        ON dv.IdVenta = v.IdVenta
                    INNER JOIN Productos p
                        ON dv.IdProducto = p.IdProducto
                    INNER JOIN Marcas m
                        ON p.IdMarca = m.IdMarca
                    WHERE v.Fecha >= @Desde
                      AND v.Fecha < DATEADD(DAY, 1, @Hasta)
                      AND v.FechaAnulacion IS NULL
                      AND (@Sucursal = 0 OR v.IdSucursal = @Sucursal)
                    GROUP BY p.Codigo, p.Nombre, m.Nombre
                    ORDER BY UnidadesVendidas DESC";
            }

            if (tipo == "Existencias")
            {
                return @"
                    SELECT
                        p.Codigo AS Codigo,
                        p.Nombre AS Producto,
                        ca.Nombre AS Categoria,
                        ma.Nombre AS Marca,
                        s.Nombre AS Sucursal,
                        e.StockActual AS Stock,
                        e.StockMinimo AS Minimo,
                        CASE
                            WHEN e.StockActual = 0 THEN 'Agotado'
                            WHEN e.StockActual <= e.StockMinimo
                                THEN 'Bajo mínimo'
                            ELSE 'Disponible'
                        END AS Estado
                    FROM Existencias e
                    INNER JOIN Productos p
                        ON e.IdProducto = p.IdProducto
                    INNER JOIN Categorias ca
                        ON p.IdCategoria = ca.IdCategoria
                    INNER JOIN Marcas ma
                        ON p.IdMarca = ma.IdMarca
                    INNER JOIN Sucursales s
                        ON e.IdSucursal = s.IdSucursal
                    WHERE (@Sucursal = 0 OR e.IdSucursal = @Sucursal)
                      AND (@Categoria = 0 OR p.IdCategoria = @Categoria)
                      AND (@Marca = 0 OR p.IdMarca = @Marca)
                    ORDER BY s.Nombre, p.Nombre";
            }

            if (tipo == "Stock bajo")
            {
                return @"
                    SELECT
                        p.Codigo AS Codigo,
                        p.Nombre AS Producto,
                        ma.Nombre AS Marca,
                        s.Nombre AS Sucursal,
                        e.StockActual AS Stock,
                        e.StockMinimo AS Minimo,
                        CASE
                            WHEN e.StockMinimo > e.StockActual
                            THEN e.StockMinimo - e.StockActual
                            ELSE 0
                        END AS Faltante,
                        CASE
                            WHEN e.StockActual = 0 THEN 'Agotado'
                            ELSE 'Bajo mínimo'
                        END AS Estado
                    FROM Existencias e
                    INNER JOIN Productos p
                        ON e.IdProducto = p.IdProducto
                    INNER JOIN Marcas ma
                        ON p.IdMarca = ma.IdMarca
                    INNER JOIN Sucursales s
                        ON e.IdSucursal = s.IdSucursal
                    WHERE e.StockActual <= e.StockMinimo
                      AND (@Sucursal = 0 OR e.IdSucursal = @Sucursal)
                      AND (@Categoria = 0 OR p.IdCategoria = @Categoria)
                      AND (@Marca = 0 OR p.IdMarca = @Marca)
                    ORDER BY e.StockActual ASC, p.Nombre";
            }

            if (tipo == "Movimientos de inventario")
            {
                return @"
                    SELECT
                        Fecha,
                        Referencia,
                        Movimiento,
                        Producto,
                        Sucursal,
                        Entrada,
                        Salida,
                        Responsable
                    FROM
                    (
                        SELECT
                            mm.Fecha AS Fecha,
                            COALESCE(
                                CAST(mm.Referencia AS NVARCHAR(50)),
                                'MOV-' + CAST(mm.IdMovimiento AS NVARCHAR(20))
                            ) AS Referencia,
                            CASE
                                WHEN mm.TipoMovimiento = 'Entrada'
                                    THEN 'Ingreso'
                                ELSE 'Ajuste'
                            END AS Movimiento,
                            p.Nombre AS Producto,
                            s.Nombre AS Sucursal,
                            mm.IdSucursal AS IdSucursal,
                            mm.IdProducto AS IdProducto,
                            CASE
                                WHEN mm.CantidadMovimiento > 0
                                THEN mm.CantidadMovimiento ELSE 0
                            END AS Entrada,
                            CASE
                                WHEN mm.CantidadMovimiento < 0
                                THEN ABS(mm.CantidadMovimiento) ELSE 0
                            END AS Salida,
                            u.NombreUsuario AS Responsable
                        FROM MovimientosManuales mm
                        INNER JOIN Productos p
                            ON mm.IdProducto = p.IdProducto
                        INNER JOIN Sucursales s
                            ON mm.IdSucursal = s.IdSucursal
                        INNER JOIN Usuarios u
                            ON mm.IdUsuario = u.IdUsuario

                        UNION ALL

                        SELECT
                            v.Fecha,
                            CAST(v.NumeroVenta AS NVARCHAR(50)),
                            'Venta',
                            p.Nombre,
                            s.Nombre,
                            v.IdSucursal,
                            dv.IdProducto,
                            0,
                            dv.Cantidad,
                            u.NombreUsuario
                        FROM Ventas v
                        INNER JOIN DetalleVenta dv
                            ON v.IdVenta = dv.IdVenta
                        INNER JOIN Productos p
                            ON dv.IdProducto = p.IdProducto
                        INNER JOIN Sucursales s
                            ON v.IdSucursal = s.IdSucursal
                        INNER JOIN Usuarios u
                            ON v.IdUsuario = u.IdUsuario
                        WHERE v.FechaAnulacion IS NULL

                        UNION ALL

                        SELECT
                            t.FechaEnvio,
                            CAST(t.Referencia AS NVARCHAR(50)),
                            'Traslado enviado',
                            p.Nombre,
                            so.Nombre,
                            t.IdSucursalOrigen,
                            dt.IdProducto,
                            0,
                            dt.Cantidad,
                            ue.NombreUsuario
                        FROM Traslados t
                        INNER JOIN DetalleTraslado dt
                            ON t.IdTraslado = dt.IdTraslado
                        INNER JOIN Productos p
                            ON dt.IdProducto = p.IdProducto
                        INNER JOIN Sucursales so
                            ON t.IdSucursalOrigen = so.IdSucursal
                        INNER JOIN Usuarios ue
                            ON t.IdUsuarioEnvio = ue.IdUsuario

                        UNION ALL

                        SELECT
                            t.FechaRecepcion,
                            CAST(t.Referencia AS NVARCHAR(50)),
                            'Traslado recibido',
                            p.Nombre,
                            sd.Nombre,
                            t.IdSucursalDestino,
                            dt.IdProducto,
                            dt.Cantidad,
                            0,
                            ur.NombreUsuario
                        FROM Traslados t
                        INNER JOIN DetalleTraslado dt
                            ON t.IdTraslado = dt.IdTraslado
                        INNER JOIN Productos p
                            ON dt.IdProducto = p.IdProducto
                        INNER JOIN Sucursales sd
                            ON t.IdSucursalDestino = sd.IdSucursal
                        INNER JOIN Usuarios ur
                            ON t.IdUsuarioRecepcion = ur.IdUsuario
                        WHERE t.FechaRecepcion IS NOT NULL
                    ) AS Movimientos
                    WHERE Fecha >= @Desde
                      AND Fecha < DATEADD(DAY, 1, @Hasta)
                      AND (@Sucursal = 0 OR IdSucursal = @Sucursal)
                      AND (@Producto = 0 OR IdProducto = @Producto)
                      AND (@TipoMovimiento = 'Todos'
                           OR Movimiento = @TipoMovimiento)
                    ORDER BY Fecha DESC";
            }

            throw new Exception("Selecciona un tipo de reporte válido.");
        }

        private void AgregarParametros(SqlCommand cmd)
        {
            string tipo = cmbTipoReporte.Text;

            if (tipo == "Ventas" ||
                tipo == "Productos más vendidos" ||
                tipo == "Movimientos de inventario")
            {
                cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value =
                    dtpDesde.Value.Date;

                cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value =
                    dtpHasta.Value.Date;
            }

            if (tipo == "Ventas")
            {
                cmd.Parameters.Add("@Sucursal", SqlDbType.Int).Value =
                    ObtenerId(cmbSucursal);

                cmd.Parameters.Add("@Vendedor", SqlDbType.Int).Value =
                    ObtenerId(cmbVendedor);
            }
            else if (tipo == "Productos más vendidos")
            {
                cmd.Parameters.Add("@Sucursal", SqlDbType.Int).Value =
                    ObtenerId(cmbSucursal);
            }
            else if (tipo == "Existencias" || tipo == "Stock bajo")
            {
                cmd.Parameters.Add("@Sucursal", SqlDbType.Int).Value =
                    ObtenerId(cmbSucursal);

                cmd.Parameters.Add("@Categoria", SqlDbType.Int).Value =
                    ObtenerId(cmbCategoria);

                cmd.Parameters.Add("@Marca", SqlDbType.Int).Value =
                    ObtenerId(cmbMarca);
            }
            else if (tipo == "Movimientos de inventario")
            {
                cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value =
                    dtpDesde.Value.Date;

                cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value =
                    dtpHasta.Value.Date;

                cmd.Parameters.Add("@Sucursal", SqlDbType.Int).Value =
                    ObtenerId(cmbSucursal);

                cmd.Parameters.Add("@Producto", SqlDbType.Int).Value =
                    ObtenerId(cmbProducto);

                cmd.Parameters.Add("@TipoMovimiento",
                    SqlDbType.NVarChar, 30).Value =
                    cmbTipoMovimiento.Text;
            }
        }

        private void ActualizarResumen(DataTable tabla)
        {
            lblResumen.Text =
                tabla.Rows.Count + " registros encontrados";

            if (cmbTipoReporte.Text == "Ventas")
            {
                decimal total = 0;
                int unidades = 0;

                foreach (DataRow fila in tabla.Rows)
                {
                    total += Convert.ToDecimal(fila["Total"]);
                    unidades += Convert.ToInt32(fila["Unidades"]);
                }

                lblValorTarjeta1.Text =
                    tabla.Rows.Count.ToString();

                lblValorTarjeta2.Text =
                    unidades.ToString();

                lblValorTarjeta3.Text =
                    "Bs " + total.ToString("N2");
            }
            else if (cmbTipoReporte.Text == "Existencias")
            {
                int unidades = 0;

                foreach (DataRow fila in tabla.Rows)
                    unidades += Convert.ToInt32(fila["Stock"]);

                lblResumen.Text =
                    tabla.Rows.Count + " productos · " +
                    unidades + " unidades disponibles";
            }
            else if (cmbTipoReporte.Text == "Stock bajo")
            {
                lblResumen.Text =
                    tabla.Rows.Count +
                    " productos con stock bajo o agotado";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbSucursal.Items.Count > 0)
                cmbSucursal.SelectedIndex = 0;

            if (cmbVendedor.Items.Count > 0)
                cmbVendedor.SelectedIndex = 0;

            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;

            if (cmbMarca.Items.Count > 0)
                cmbMarca.SelectedIndex = 0;

            if (cmbProducto.Items.Count > 0)
                cmbProducto.SelectedIndex = 0;

            cmbTipoMovimiento.SelectedIndex = 0;
            cmbTipoReporte.SelectedIndex = 0;

            dgvReportes.DataSource = null;

            lblValorTarjeta1.Text = "0";
            lblValorTarjeta2.Text = "0";
            lblValorTarjeta3.Text = "Bs 0,00";

            lblResumen.Text = "0 registros";
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            if (dgvReportes.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes generar un reporte.");
                return;
            }

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo CSV (*.csv)|*.csv";
                guardar.FileName = "ReporteCentralCel.csv";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw =
                        new StreamWriter(guardar.FileName, false,
                            Encoding.UTF8))
                    {
                        for (int i = 0; i < dgvReportes.Columns.Count; i++)
                        {
                            sw.Write("\"" +
                                dgvReportes.Columns[i].HeaderText
                                .Replace("\"", "\"\"") + "\"");

                            if (i < dgvReportes.Columns.Count - 1)
                                sw.Write(";");
                        }

                        sw.WriteLine();

                        foreach (DataGridViewRow fila in dgvReportes.Rows)
                        {
                            for (int i = 0; i < dgvReportes.Columns.Count; i++)
                            {
                                string valor =
                                    Convert.ToString(fila.Cells[i].Value);

                                sw.Write("\"" +
                                    valor.Replace("\"", "\"\"") + "\"");

                                if (i < dgvReportes.Columns.Count - 1)
                                    sw.Write(";");
                            }

                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("El archivo CSV se guardó correctamente.");
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvReportes.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes generar un reporte.");
                return;
            }

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo Excel (*.xls)|*.xls";
                guardar.FileName = "ReporteCentralCel.xls";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder html = new StringBuilder();

                    html.Append(
                        "<html><head><meta charset='utf-8'></head><body>");
                    html.Append("<h2>Reporte CentralCel</h2><table border='1'>");
                    html.Append("<tr>");

                    foreach (DataGridViewColumn columna in dgvReportes.Columns)
                    {
                        html.Append("<th>" +
                            SecurityElement.Escape(columna.HeaderText) +
                            "</th>");
                    }

                    html.Append("</tr>");

                    foreach (DataGridViewRow fila in dgvReportes.Rows)
                    {
                        html.Append("<tr>");

                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            html.Append("<td>" +
                                SecurityElement.Escape(
                                    Convert.ToString(celda.Value) ?? "") +
                                "</td>");
                        }

                        html.Append("</tr>");
                    }

                    html.Append("</table></body></html>");

                    File.WriteAllText(
                        guardar.FileName,
                        html.ToString(),
                        Encoding.UTF8);

                    MessageBox.Show(
                        "El reporte se guardó y puedes abrirlo con Excel.");
                }
            }
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}