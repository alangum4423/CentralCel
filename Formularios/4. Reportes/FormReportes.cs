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
namespace CentralCel.Formularios._3_Reportes
{
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();

            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.AddRange(new string[]
            {
                "Ventas",
                "Productos más vendidos",
                "Existencias",
                "Stock bajo",
                "Movimientos de inventario"
            });

            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.SelectedIndex = 0;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.AddRange(new string[]
            {
                "Todos",
                "Vigentes",
                "Anuladas"
            });
            cmbFiltro.SelectedIndex = 0;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            dgvReportes.ReadOnly = true;
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.MultiSelect = false;

            lblResumen.Text = "Datos del reporte";

            btnLimpiar.Click += btnLimpiar_Click;

            btnGenerar.Click += btnGenerar_Click;

            CargarSucursales();
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

                    using (SqlDataAdapter adaptador =
                           new SqlDataAdapter(consulta, conexion))
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor a la fecha final.");
                return;
            }

            try
            {
                int sucursal = Convert.ToInt32(cmbSucursal.SelectedValue);

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
                        ISNULL(SUM(dv.Cantidad * dv.PrecioUnitario), 0) AS Total,
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
                        AND (@sucursal = 0 OR v.IdSucursal = @sucursal)
                        AND (
                            @filtro = 'Todos'
                            OR (@filtro = 'Vigentes'
                                AND v.FechaAnulacion IS NULL)
                            OR (@filtro = 'Anuladas'
                                AND v.FechaAnulacion IS NOT NULL)
                        )
                    GROUP BY
                        v.NumeroVenta, v.Fecha, s.Nombre,
                        c.Nombre, u.NombreCompleto,
                        v.FormaPago, v.FechaAnulacion
                    ORDER BY v.Fecha DESC";
                        break;

                    case "Productos más vendidos":
                        sql = @"
                    SELECT TOP 20
                        p.Codigo AS Código,
                        p.Nombre AS Producto,
                        SUM(dv.Cantidad) AS [Unidades vendidas],
                        SUM(dv.Cantidad * dv.PrecioUnitario) AS [Total vendido]
                    FROM DetalleVenta dv
                    INNER JOIN Ventas v
                        ON dv.IdVenta = v.IdVenta
                    INNER JOIN Productos p
                        ON dv.IdProducto = p.IdProducto
                    WHERE
                        v.Fecha >= @desde
                        AND v.Fecha < DATEADD(DAY, 1, @hasta)
                        AND v.FechaAnulacion IS NULL
                        AND (@sucursal = 0 OR v.IdSucursal = @sucursal)
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
                        (@sucursal = 0 OR e.IdSucursal = @sucursal)
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
                        AND (@sucursal = 0 OR e.IdSucursal = @sucursal)
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
                            AND (@sucursal = 0 OR mm.IdSucursal = @sucursal)

                        UNION ALL

                        SELECT
                            t.FechaEnvio,
                            'Traslado enviado' AS Movimiento,
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
                            AND (@sucursal = 0 OR t.IdSucursalOrigen = @sucursal)

                        UNION ALL

                        SELECT
                            t.FechaRecepcion,
                            'Traslado recibido' AS Movimiento,
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
                            AND (@sucursal = 0 OR t.IdSucursalDestino = @sucursal)
                    ) AS Movimientos
                    ORDER BY Fecha DESC";
                        break;

                    default:
                        MessageBox.Show("Selecciona un tipo de reporte válido.");
                        return;
                }

                using (SqlConnection conn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value =
                        dtpDesde.Value.Date;

                    cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value =
                        dtpHasta.Value.Date;

                    cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value =
                        sucursal;

                    cmd.Parameters.Add("@filtro", SqlDbType.NVarChar, 20).Value =
                        cmbFiltro.Text;

                    DataTable tabla = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }

                    dgvReportes.DataSource = tabla;

                    lblResumen.Text =
                        "Reporte: " + reporte +
                        " | Registros encontrados: " + tabla.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al generar el reporte:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            if (cmbSucursal.Items.Count > 0)
                cmbSucursal.SelectedIndex = 0;

            if (cmbFiltro.Items.Count > 0)
                cmbFiltro.SelectedIndex = 0;

            if (cmbTipoReporte.Items.Count > 0)
                cmbTipoReporte.SelectedIndex = 0;

            dgvReportes.DataSource = null;
            lblResumen.Text = "Datos del reporte";
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
