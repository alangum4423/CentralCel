using CentralCel.Datos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace CentralCel.Formularios._3_Reportes
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();

            ConfigurarFormulario();

            CargarSucursales();
            CargarCategorias();
            CargarMarcas();
            CargarProductos();
            CargarTiposMovimiento();
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

            cmbTipoReporte.SelectedIndex = 0;

            lblVendedor.Text = "Estado:";

            cmbVendedor.Items.Clear();
            cmbVendedor.Items.AddRange(new string[]
            {
                "Todos",
                "Vigentes",
                "Anuladas"
            });

            cmbVendedor.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbVendedor.SelectedIndex = 0;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            dgvReportes.ReadOnly = true;
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AllowUserToDeleteRows = false;
            dgvReportes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.MultiSelect = false;
            dgvReportes.RowHeadersVisible = false;

            lblResumen.Text = "Datos del reporte";

            btnGenerar.Click -= btnGenerar_Click;
            btnGenerar.Click += btnGenerar_Click;

            btnLimpiar.Click -= btnLimpiar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            btnExportarPDF.Click += btnExportarExcel_Click;
            btnExportarCSV.Click += btnExportarCSV_Click;
            btnVolverMenu.Click += btnVolverMenu_Click;

            cmbTipoReporte.SelectedIndexChanged +=
                cmbTipoReporte_SelectedIndexChanged;

            ActualizarTituloReporte();
        }

        private void CargarSucursales()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"
                        SELECT IdSucursal, Nombre
                        FROM Sucursales
                        WHERE Activo = 1
                        ORDER BY Nombre";

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        DataRow fila = tabla.NewRow();
                        fila["IdSucursal"] = 0;
                        fila["Nombre"] = "Todas";

                        tabla.Rows.InsertAt(fila, 0);

                        cmbSucursal.DataSource = tabla;
                        cmbSucursal.DisplayMember = "Nombre";
                        cmbSucursal.ValueMember = "IdSucursal";
                        cmbSucursal.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las sucursales: " + ex.Message,
                    "CentralCel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"
                SELECT IdCategoria, Nombre
                FROM Categorias
                WHERE Activo = 1
                ORDER BY Nombre";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        DataRow fila = tabla.NewRow();
                        fila["IdCategoria"] = 0;
                        fila["Nombre"] = "Todas";

                        tabla.Rows.InsertAt(fila, 0);

                        cmbCategoria.DataSource = tabla;
                        cmbCategoria.DisplayMember = "Nombre";
                        cmbCategoria.ValueMember = "IdCategoria";
                        cmbCategoria.DropDownStyle =
                            ComboBoxStyle.DropDownList;

                        cmbCategoria.SelectedIndex = 0;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las categorías: " + ex.Message,
                    "CentralCel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarMarcas()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"
                SELECT IdMarca, Nombre
                FROM Marcas
                WHERE Activo = 1
                ORDER BY Nombre";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        DataRow fila = tabla.NewRow();
                        fila["IdMarca"] = 0;
                        fila["Nombre"] = "Todas";

                        tabla.Rows.InsertAt(fila, 0);

                        cmbMarca.DataSource = tabla;
                        cmbMarca.DisplayMember = "Nombre";
                        cmbMarca.ValueMember = "IdMarca";
                        cmbMarca.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar marcas: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"
                SELECT IdProducto, Nombre
                FROM Productos
                WHERE Activo = 1
                ORDER BY Nombre";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        DataRow fila = tabla.NewRow();
                        fila["IdProducto"] = 0;
                        fila["Nombre"] = "Todos";

                        tabla.Rows.InsertAt(fila, 0);

                        cmbProducto.DataSource = tabla;
                        cmbProducto.DisplayMember = "Nombre";
                        cmbProducto.ValueMember = "IdProducto";
                        cmbProducto.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void CargarTiposMovimiento()
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"
                SELECT DISTINCT TipoMovimiento
                FROM MovimientosManuales
                WHERE TipoMovimiento IS NOT NULL
                ORDER BY TipoMovimiento";

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        DataRow fila = tabla.NewRow();
                        fila["TipoMovimiento"] = "Todos";

                        tabla.Rows.InsertAt(fila, 0);

                        cmbTipoMovimiento.DataSource = tabla;
                        cmbTipoMovimiento.DisplayMember = "TipoMovimiento";
                        cmbTipoMovimiento.ValueMember = "TipoMovimiento";
                        cmbTipoMovimiento.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar tipos de movimiento: " + ex.Message);
            }
        }

        private void cmbTipoReporte_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            ActualizarTituloReporte();
        }

        private void ActualizarTituloReporte()
        {
            if (cmbTipoReporte.SelectedItem == null)
                return;

            lblTituloReporte.Text =
                cmbTipoReporte.SelectedItem.ToString().ToUpper();

            switch (cmbTipoReporte.Text)
            {
                case "Ventas":
                    lblTituloTarjeta1.Text = "Ventas encontradas";
                    lblTituloTarjeta2.Text = "Ventas vigentes";
                    lblTituloTarjeta3.Text = "Total vendido";
                    break;

                case "Productos más vendidos":
                    lblTituloTarjeta1.Text = "Productos encontrados";
                    lblTituloTarjeta2.Text = "Unidades vendidas";
                    lblTituloTarjeta3.Text = "Importe vendido";
                    break;

                case "Existencias":
                    lblTituloTarjeta1.Text = "Productos encontrados";
                    lblTituloTarjeta2.Text = "Stock total";
                    lblTituloTarjeta3.Text = "Stock mínimo";
                    break;

                case "Stock bajo":
                    lblTituloTarjeta1.Text = "Productos con alerta";
                    lblTituloTarjeta2.Text = "Stock disponible";
                    lblTituloTarjeta3.Text = "Stock mínimo";
                    break;

                case "Movimientos de inventario":
                    lblTituloTarjeta1.Text = "Movimientos";
                    lblTituloTarjeta2.Text = "Entradas";
                    lblTituloTarjeta3.Text = "Salidas";
                    break;
            }

            lblValorTarjeta1.Text = "0";
            lblValorTarjeta2.Text = "0";
            lblValorTarjeta3.Text = "0";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor a la fecha final.",
                    "CentralCel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cmbSucursal.SelectedValue == null)
                    return;

                int sucursal =
                    Convert.ToInt32(cmbSucursal.SelectedValue);

                string sql = "";
                string reporte = cmbTipoReporte.Text;

                switch (reporte)
                {
                    case "Ventas":
                        sql = @"
                            SELECT
                                v.NumeroVenta AS [N° Venta],
                                v.Fecha,
                                s.Nombre AS Sucursal,
                                c.Nombre AS Cliente,
                                u.NombreCompleto AS Usuario,
                                v.FormaPago AS [Forma de pago],
                                ISNULL(
                                    SUM(dv.Cantidad * dv.PrecioUnitario), 0
                                ) AS Total,
                                CASE
                                    WHEN v.FechaAnulacion IS NULL
                                    THEN 'Vigente'
                                    ELSE 'Anulada'
                                END AS Estado
                            FROM Ventas v
                            INNER JOIN Sucursales s
                                ON v.IdSucursal = s.IdSucursal
                            LEFT JOIN Clientes c
                                ON v.IdCliente = c.IdCliente
                            INNER JOIN Usuarios u
                                ON v.IdUsuario = u.IdUsuario
                            LEFT JOIN DetalleVenta dv
                                ON v.IdVenta = dv.IdVenta
                            WHERE
                                v.Fecha >= @desde
                                AND v.Fecha < DATEADD(DAY, 1, @hasta)
                                AND (@sucursal = 0
                                     OR v.IdSucursal = @sucursal)
                                AND (
                                    @filtro = 'Todos'
                                    OR (@filtro = 'Vigentes'
                                        AND v.FechaAnulacion IS NULL)
                                    OR (@filtro = 'Anuladas'
                                        AND v.FechaAnulacion IS NOT NULL)
                                )
                            GROUP BY
                                v.NumeroVenta,
                                v.Fecha,
                                s.Nombre,
                                c.Nombre,
                                u.NombreCompleto,
                                v.FormaPago,
                                v.FechaAnulacion
                            ORDER BY v.Fecha DESC";
                        break;

                    case "Productos más vendidos":
                        sql = @"
                            SELECT TOP 20
                                p.Codigo AS Código,
                                p.Nombre AS Producto,
                                SUM(dv.Cantidad) AS [Unidades vendidas],
                                SUM(dv.Cantidad * dv.PrecioUnitario)
                                    AS [Total vendido]
                            FROM DetalleVenta dv
                            INNER JOIN Ventas v
                                ON dv.IdVenta = v.IdVenta
                            INNER JOIN Productos p
                                ON dv.IdProducto = p.IdProducto
                            WHERE
                                v.Fecha >= @desde
                                AND v.Fecha < DATEADD(DAY, 1, @hasta)
                                AND v.FechaAnulacion IS NULL
                                AND (@sucursal = 0
                                     OR v.IdSucursal = @sucursal)
                            GROUP BY p.Codigo, p.Nombre
                            ORDER BY SUM(dv.Cantidad) DESC";
                        break;

                    case "Existencias":
                        sql = @"
                            SELECT
                                p.Codigo AS Código,
                                p.Nombre AS Producto,
                                s.Nombre AS Sucursal,
                                e.StockActual AS [Stock actual],
                                e.StockMinimo AS [Stock mínimo]
                            FROM Existencias e
                            INNER JOIN Productos p
                                ON e.IdProducto = p.IdProducto
                            INNER JOIN Sucursales s
                                ON e.IdSucursal = s.IdSucursal
                            WHERE
                                (@sucursal = 0
                                 OR e.IdSucursal = @sucursal)
                            ORDER BY p.Nombre, s.Nombre";
                        break;

                    case "Stock bajo":
                        sql = @"
                            SELECT
                                p.Codigo AS Código,
                                p.Nombre AS Producto,
                                s.Nombre AS Sucursal,
                                e.StockActual AS [Stock actual],
                                e.StockMinimo AS [Stock mínimo]
                            FROM Existencias e
                            INNER JOIN Productos p
                                ON e.IdProducto = p.IdProducto
                            INNER JOIN Sucursales s
                                ON e.IdSucursal = s.IdSucursal
                            WHERE
                                e.StockActual <= e.StockMinimo
                                AND (@sucursal = 0
                                     OR e.IdSucursal = @sucursal)
                            ORDER BY e.StockActual ASC";
                        break;

                    case "Movimientos de inventario":
                        sql = @"
                            SELECT *
                            FROM
                            (
                                SELECT
                                    mm.Fecha,
                                    mm.TipoMovimiento AS Movimiento,
                                    p.Nombre AS Producto,
                                    s.Nombre AS Sucursal,
                                    mm.CantidadMovimiento AS Cantidad,
                                    mm.Referencia
                                FROM MovimientosManuales mm
                                INNER JOIN Productos p
                                    ON mm.IdProducto = p.IdProducto
                                INNER JOIN Sucursales s
                                    ON mm.IdSucursal = s.IdSucursal
                                WHERE
                                    mm.Fecha >= @desde
                                    AND mm.Fecha < DATEADD(DAY, 1, @hasta)
                                    AND (@sucursal = 0
                                         OR mm.IdSucursal = @sucursal)

                                UNION ALL

                                SELECT
                                    t.FechaEnvio,
                                    'Traslado enviado',
                                    p.Nombre,
                                    so.Nombre,
                                    -dt.Cantidad,
                                    t.Referencia
                                FROM Traslados t
                                INNER JOIN DetalleTraslado dt
                                    ON t.IdTraslado = dt.IdTraslado
                                INNER JOIN Productos p
                                    ON dt.IdProducto = p.IdProducto
                                INNER JOIN Sucursales so
                                    ON t.IdSucursalOrigen = so.IdSucursal
                                WHERE
                                    t.FechaEnvio >= @desde
                                    AND t.FechaEnvio < DATEADD(DAY, 1, @hasta)
                                    AND (@sucursal = 0
                                         OR t.IdSucursalOrigen = @sucursal)

                                UNION ALL

                                SELECT
                                    t.FechaRecepcion,
                                    'Traslado recibido',
                                    p.Nombre,
                                    sd.Nombre,
                                    dt.Cantidad,
                                    t.Referencia
                                FROM Traslados t
                                INNER JOIN DetalleTraslado dt
                                    ON t.IdTraslado = dt.IdTraslado
                                INNER JOIN Productos p
                                    ON dt.IdProducto = p.IdProducto
                                INNER JOIN Sucursales sd
                                    ON t.IdSucursalDestino = sd.IdSucursal
                                WHERE
                                    t.FechaRecepcion IS NOT NULL
                                    AND t.FechaRecepcion >= @desde
                                    AND t.FechaRecepcion < DATEADD(DAY, 1, @hasta)
                                    AND (@sucursal = 0
                                         OR t.IdSucursalDestino = @sucursal)
                            ) AS Movimientos
                            ORDER BY Fecha DESC";
                        break;

                    default:
                        MessageBox.Show("Selecciona un tipo de reporte válido.");
                        return;
                }

                using (SqlConnection conexion =
                    Conexion.ObtenerConexion())
                using (SqlCommand cmd =
                    new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value =
                        dtpDesde.Value.Date;

                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value =
                        dtpHasta.Value.Date;

                    cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value =
                        sucursal;

                    if (reporte == "Ventas")
                    {
                        cmd.Parameters.Add(
                            "@filtro", SqlDbType.NVarChar, 20).Value =
                            cmbVendedor.Text;
                    }

                    DataTable tabla = new DataTable();

                    using (SqlDataAdapter adaptador =
                        new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }

                    dgvReportes.DataSource = tabla;

                    lblResumen.Text =
                        "Reporte: " + reporte +
                        " | Registros encontrados: " +
                        tabla.Rows.Count;

                    ActualizarTarjetas(tabla, reporte);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al generar el reporte:\n" + ex.Message,
                    "CentralCel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ActualizarTarjetas(
            DataTable tabla, string reporte)
        {
            int cantidad = tabla.Rows.Count;

            decimal total1 = 0;
            decimal total2 = 0;
            decimal total3 = 0;

            switch (reporte)
            {
                case "Ventas":
                    total1 = cantidad;
                    total2 = ContarVigentes(tabla);
                    total3 = SumarColumna(tabla, "Total");
                    break;

                case "Productos más vendidos":
                    total1 = cantidad;
                    total2 = SumarColumna(tabla, "Unidades vendidas");
                    total3 = SumarColumna(tabla, "Total vendido");
                    break;

                case "Existencias":
                case "Stock bajo":
                    total1 = cantidad;
                    total2 = SumarColumna(tabla, "Stock actual");
                    total3 = SumarColumna(tabla, "Stock mínimo");
                    break;

                case "Movimientos de inventario":
                    total1 = cantidad;
                    total2 = ContarEntradas(tabla);
                    total3 = ContarSalidas(tabla);
                    break;
            }

            lblValorTarjeta1.Text = total1.ToString("N0");
            lblValorTarjeta2.Text = total2.ToString("N0");

            if (reporte == "Ventas" ||
                reporte == "Productos más vendidos")
            {
                lblValorTarjeta3.Text = "Bs " + total3.ToString("N2");
            }
            else
            {
                lblValorTarjeta3.Text = total3.ToString("N0");
            }
        }

        private decimal SumarColumna(
            DataTable tabla, string columna)
        {
            if (!tabla.Columns.Contains(columna))
                return 0;

            decimal suma = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                if (fila[columna] != DBNull.Value)
                    suma += Convert.ToDecimal(fila[columna]);
            }

            return suma;
        }

        private int ContarVigentes(DataTable tabla)
        {
            int cantidad = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                if (fila["Estado"].ToString() == "Vigente")
                    cantidad++;
            }

            return cantidad;
        }

        private int ContarEntradas(DataTable tabla)
        {
            if (!tabla.Columns.Contains("Cantidad"))
                return 0;

            int cantidad = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                if (Convert.ToDecimal(fila["Cantidad"]) > 0)
                    cantidad++;
            }

            return cantidad;
        }

        private int ContarSalidas(DataTable tabla)
        {
            if (!tabla.Columns.Contains("Cantidad"))
                return 0;

            int cantidad = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                if (Convert.ToDecimal(fila["Cantidad"]) < 0)
                    cantidad++;
            }

            return cantidad;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbSucursal.Items.Count > 0)
                cmbSucursal.SelectedIndex = 0;

            if (cmbVendedor.Items.Count > 0)
                cmbVendedor.SelectedIndex = 0;

            if (cmbTipoReporte.Items.Count > 0)
                cmbTipoReporte.SelectedIndex = 0;

            dgvReportes.DataSource = null;

            lblResumen.Text = "Datos del reporte";

            ActualizarTituloReporte();
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            DataTable tabla = dgvReportes.DataSource as DataTable;

            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debes generar un reporte.",
                    "CentralCel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo PDF (*.pdf)|*.pdf";
                guardar.FileName = "ReporteCentralCel.pdf";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document documento = new Document(
                            PageSize.A4.Rotate(),
                            25, 25, 25, 25);

                        using (FileStream archivo = new FileStream(
                            guardar.FileName, FileMode.Create))
                        {
                            PdfWriter.GetInstance(documento, archivo);

                            documento.Open();

                            // Título
                            Paragraph titulo = new Paragraph(
                                "CENTRALCEL - REPORTE",
                                FontFactory.GetFont(
                                    FontFactory.HELVETICA_BOLD, 18));

                            titulo.Alignment = Element.ALIGN_CENTER;
                            documento.Add(titulo);

                            documento.Add(new Paragraph(" "));

                            // Información del reporte
                            documento.Add(new Paragraph(
                                "Tipo de reporte: " + cmbTipoReporte.Text));

                            documento.Add(new Paragraph(
                                "Fecha de generación: " +
                                DateTime.Now.ToString("dd/MM/yyyy HH:mm")));

                            documento.Add(new Paragraph(
                                "Periodo: " +
                                dtpDesde.Value.ToString("dd/MM/yyyy") +
                                " - " +
                                dtpHasta.Value.ToString("dd/MM/yyyy")));

                            documento.Add(new Paragraph(" "));

                            // Crear tabla
                            PdfPTable pdfTabla =
                                new PdfPTable(tabla.Columns.Count);

                            pdfTabla.WidthPercentage = 100;

                            // Encabezados
                            foreach (DataColumn columna in tabla.Columns)
                            {
                                PdfPCell celda = new PdfPCell(
                                    new Phrase(columna.ColumnName));

                                celda.BackgroundColor =
                                    new BaseColor(70, 130, 180);

                                celda.HorizontalAlignment =
                                    Element.ALIGN_CENTER;

                                celda.Padding = 5;

                                pdfTabla.AddCell(celda);
                            }

                            // Datos
                            foreach (DataRow fila in tabla.Rows)
                            {
                                foreach (DataColumn columna in tabla.Columns)
                                {
                                    PdfPCell celda = new PdfPCell(
                                        new Phrase(
                                            Convert.ToString(fila[columna])));

                                    celda.Padding = 4;

                                    pdfTabla.AddCell(celda);
                                }
                            }

                            documento.Add(pdfTabla);

                            documento.Add(new Paragraph(" "));

                            documento.Add(new Paragraph(
                                "Total de registros: " + tabla.Rows.Count));

                            documento.Close();
                        }

                        MessageBox.Show(
                            "Reporte PDF exportado correctamente.",
                            "CentralCel",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al exportar PDF: " + ex.Message,
                            "CentralCel",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportarCSV_Click(
            object sender, EventArgs e)
        {
            DataTable tabla = dgvReportes.DataSource as DataTable;

            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes generar un reporte.");
                return;
            }

            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter =
                    "Archivo CSV (*.csv)|*.csv";

                guardar.FileName = "ReporteCentralCel.csv";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter escritor =
                            new StreamWriter(
                                guardar.FileName,
                                false,
                                new UTF8Encoding(true)))
                        {
                            for (int i = 0; i < tabla.Columns.Count; i++)
                            {
                                escritor.Write(
                                    "\"" + tabla.Columns[i].ColumnName
                                    .Replace("\"", "\"\"") + "\"");

                                if (i < tabla.Columns.Count - 1)
                                    escritor.Write(";");
                            }

                            escritor.WriteLine();

                            foreach (DataRow fila in tabla.Rows)
                            {
                                for (int i = 0; i < tabla.Columns.Count; i++)
                                {
                                    string valor =
                                        Convert.ToString(fila[i]);

                                    escritor.Write(
                                        "\"" + valor.Replace("\"", "\"\"")
                                        + "\"");

                                    if (i < tabla.Columns.Count - 1)
                                        escritor.Write(";");
                                }

                                escritor.WriteLine();
                            }
                        }

                        MessageBox.Show(
                            "Archivo CSV exportado correctamente.",
                            "CentralCel",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al exportar CSV: " + ex.Message);
                    }
                }
            }
        }

        private void btnVolverMenu_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSucursal_SelectedIndexChanged(
            object sender, EventArgs e)
        {

        }
    }
}
