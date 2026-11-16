namespace CentralCel.Formularios._3_Reportes
{
    partial class FormReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPie = new System.Windows.Forms.Panel();
            this.btnExportarCSV = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.lblResumen = new System.Windows.Forms.Label();
            this.panelTarjeta3 = new System.Windows.Forms.Panel();
            this.lblValorTarjeta3 = new System.Windows.Forms.Label();
            this.lblTituloTarjeta3 = new System.Windows.Forms.Label();
            this.panelTarjeta2 = new System.Windows.Forms.Panel();
            this.lblValorTarjeta2 = new System.Windows.Forms.Label();
            this.lblTituloTarjeta2 = new System.Windows.Forms.Label();
            this.panelTarjeta1 = new System.Windows.Forms.Panel();
            this.lblValorTarjeta1 = new System.Windows.Forms.Label();
            this.lblTituloTarjeta1 = new System.Windows.Forms.Label();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.panelEncabezado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelPie.SuspendLayout();
            this.panelTarjeta3.SuspendLayout();
            this.panelTarjeta2.SuspendLayout();
            this.panelTarjeta1.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(4, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(245, 61);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTES";
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelEncabezado.Controls.Add(this.btnVolverMenu);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Location = new System.Drawing.Point(-1, 0);
            this.panelEncabezado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(1382, 94);
            this.panelEncabezado.TabIndex = 15;
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnVolverMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVolverMenu.ForeColor = System.Drawing.Color.White;
            this.btnVolverMenu.Location = new System.Drawing.Point(1113, 23);
            this.btnVolverMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(248, 52);
            this.btnVolverMenu.TabIndex = 1;
            this.btnVolverMenu.Text = "Volver Al Menu";
            this.btnVolverMenu.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.panelPie);
            this.panel1.Controls.Add(this.panelTarjeta3);
            this.panel1.Controls.Add(this.panelTarjeta2);
            this.panel1.Controls.Add(this.panelTarjeta1);
            this.panel1.Controls.Add(this.lblTituloReporte);
            this.panel1.Controls.Add(this.panelFiltros);
            this.panel1.Controls.Add(this.dgvReportes);
            this.panel1.Location = new System.Drawing.Point(14, 112);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1347, 920);
            this.panel1.TabIndex = 16;
            // 
            // panelPie
            // 
            this.panelPie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelPie.Controls.Add(this.btnExportarCSV);
            this.panelPie.Controls.Add(this.btnExportarPDF);
            this.panelPie.Controls.Add(this.lblResumen);
            this.panelPie.Location = new System.Drawing.Point(32, 789);
            this.panelPie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPie.Name = "panelPie";
            this.panelPie.Size = new System.Drawing.Size(1285, 106);
            this.panelPie.TabIndex = 28;
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExportarCSV.FlatAppearance.BorderSize = 0;
            this.btnExportarCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarCSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportarCSV.Location = new System.Drawing.Point(973, 20);
            this.btnExportarCSV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(292, 71);
            this.btnExportarCSV.TabIndex = 16;
            this.btnExportarCSV.Text = "Exportar a CSV";
            this.btnExportarCSV.UseVisualStyleBackColor = false;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExportarPDF.FlatAppearance.BorderSize = 0;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(675, 20);
            this.btnExportarPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(292, 71);
            this.btnExportarPDF.TabIndex = 15;
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumen.Location = new System.Drawing.Point(28, 41);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(271, 28);
            this.lblResumen.TabIndex = 14;
            this.lblResumen.Text = "0 registros · Datos del reporte";
            // 
            // panelTarjeta3
            // 
            this.panelTarjeta3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTarjeta3.Controls.Add(this.lblValorTarjeta3);
            this.panelTarjeta3.Controls.Add(this.lblTituloTarjeta3);
            this.panelTarjeta3.Location = new System.Drawing.Point(912, 297);
            this.panelTarjeta3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTarjeta3.Name = "panelTarjeta3";
            this.panelTarjeta3.Size = new System.Drawing.Size(405, 81);
            this.panelTarjeta3.TabIndex = 27;
            // 
            // lblValorTarjeta3
            // 
            this.lblValorTarjeta3.AutoSize = true;
            this.lblValorTarjeta3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblValorTarjeta3.Location = new System.Drawing.Point(181, 41);
            this.lblValorTarjeta3.Name = "lblValorTarjeta3";
            this.lblValorTarjeta3.Size = new System.Drawing.Size(73, 28);
            this.lblValorTarjeta3.TabIndex = 1;
            this.lblValorTarjeta3.Text = "Bs 0,00";
            // 
            // lblTituloTarjeta3
            // 
            this.lblTituloTarjeta3.AutoSize = true;
            this.lblTituloTarjeta3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloTarjeta3.Location = new System.Drawing.Point(150, 5);
            this.lblTituloTarjeta3.Name = "lblTituloTarjeta3";
            this.lblTituloTarjeta3.Size = new System.Drawing.Size(131, 28);
            this.lblTituloTarjeta3.TabIndex = 0;
            this.lblTituloTarjeta3.Text = "Total vendido";
            // 
            // panelTarjeta2
            // 
            this.panelTarjeta2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTarjeta2.Controls.Add(this.lblValorTarjeta2);
            this.panelTarjeta2.Controls.Add(this.lblTituloTarjeta2);
            this.panelTarjeta2.Location = new System.Drawing.Point(479, 297);
            this.panelTarjeta2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTarjeta2.Name = "panelTarjeta2";
            this.panelTarjeta2.Size = new System.Drawing.Size(405, 81);
            this.panelTarjeta2.TabIndex = 26;
            // 
            // lblValorTarjeta2
            // 
            this.lblValorTarjeta2.AutoSize = true;
            this.lblValorTarjeta2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblValorTarjeta2.Location = new System.Drawing.Point(206, 41);
            this.lblValorTarjeta2.Name = "lblValorTarjeta2";
            this.lblValorTarjeta2.Size = new System.Drawing.Size(23, 28);
            this.lblValorTarjeta2.TabIndex = 1;
            this.lblValorTarjeta2.Text = "0";
            // 
            // lblTituloTarjeta2
            // 
            this.lblTituloTarjeta2.AutoSize = true;
            this.lblTituloTarjeta2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloTarjeta2.Location = new System.Drawing.Point(130, 5);
            this.lblTituloTarjeta2.Name = "lblTituloTarjeta2";
            this.lblTituloTarjeta2.Size = new System.Drawing.Size(177, 28);
            this.lblTituloTarjeta2.TabIndex = 0;
            this.lblTituloTarjeta2.Text = "Unidades vendidas";
            // 
            // panelTarjeta1
            // 
            this.panelTarjeta1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTarjeta1.Controls.Add(this.lblValorTarjeta1);
            this.panelTarjeta1.Controls.Add(this.lblTituloTarjeta1);
            this.panelTarjeta1.Location = new System.Drawing.Point(32, 297);
            this.panelTarjeta1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTarjeta1.Name = "panelTarjeta1";
            this.panelTarjeta1.Size = new System.Drawing.Size(405, 81);
            this.panelTarjeta1.TabIndex = 25;
            // 
            // lblValorTarjeta1
            // 
            this.lblValorTarjeta1.AutoSize = true;
            this.lblValorTarjeta1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblValorTarjeta1.Location = new System.Drawing.Point(178, 41);
            this.lblValorTarjeta1.Name = "lblValorTarjeta1";
            this.lblValorTarjeta1.Size = new System.Drawing.Size(23, 28);
            this.lblValorTarjeta1.TabIndex = 1;
            this.lblValorTarjeta1.Text = "0";
            // 
            // lblTituloTarjeta1
            // 
            this.lblTituloTarjeta1.AutoSize = true;
            this.lblTituloTarjeta1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloTarjeta1.Location = new System.Drawing.Point(104, 5);
            this.lblTituloTarjeta1.Name = "lblTituloTarjeta1";
            this.lblTituloTarjeta1.Size = new System.Drawing.Size(181, 28);
            this.lblTituloTarjeta1.TabIndex = 0;
            this.lblTituloTarjeta1.Text = "Ventas confirmadas";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.lblTituloReporte.Location = new System.Drawing.Point(24, 239);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(617, 45);
            this.lblTituloReporte.TabIndex = 24;
            this.lblTituloReporte.Text = "Ventas por Fecha, Sucursal y Vendedor";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelFiltros.Controls.Add(this.cmbTipoMovimiento);
            this.panelFiltros.Controls.Add(this.cmbProducto);
            this.panelFiltros.Controls.Add(this.cmbMarca);
            this.panelFiltros.Controls.Add(this.cmbCategoria);
            this.panelFiltros.Controls.Add(this.btnLimpiar);
            this.panelFiltros.Controls.Add(this.lblTipoMovimiento);
            this.panelFiltros.Controls.Add(this.btnGenerar);
            this.panelFiltros.Controls.Add(this.lblProducto);
            this.panelFiltros.Controls.Add(this.lblMarca);
            this.panelFiltros.Controls.Add(this.lblCategoria);
            this.panelFiltros.Controls.Add(this.lblTipo);
            this.panelFiltros.Controls.Add(this.cmbTipoReporte);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.cmbVendedor);
            this.panelFiltros.Controls.Add(this.lblVendedor);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblSucursal);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.cmbSucursal);
            this.panelFiltros.Location = new System.Drawing.Point(32, 27);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1285, 198);
            this.panelFiltros.TabIndex = 23;
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(1063, 72);
            this.cmbTipoMovimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(199, 36);
            this.cmbTipoMovimiento.TabIndex = 21;
            // 
            // cmbProducto
            // 
            this.cmbProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(168, 149);
            this.cmbProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(215, 36);
            this.cmbProducto.TabIndex = 20;
            // 
            // cmbMarca
            // 
            this.cmbMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(168, 105);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(215, 36);
            this.cmbMarca.TabIndex = 19;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(168, 61);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(215, 36);
            this.cmbCategoria.TabIndex = 18;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(619, 124);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(225, 61);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTipoMovimiento.Location = new System.Drawing.Point(864, 75);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.Size = new System.Drawing.Size(193, 28);
            this.lblTipoMovimiento.TabIndex = 17;
            this.lblTipoMovimiento.Text = "Tipo de movimiento:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(415, 124);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(198, 61);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProducto.Location = new System.Drawing.Point(10, 152);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(97, 28);
            this.lblProducto.TabIndex = 16;
            this.lblProducto.Text = "Producto:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMarca.Location = new System.Drawing.Point(10, 110);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(70, 28);
            this.lblMarca.TabIndex = 15;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCategoria.Location = new System.Drawing.Point(10, 64);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(101, 28);
            this.lblCategoria.TabIndex = 14;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTipo.Location = new System.Drawing.Point(10, 17);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(152, 28);
            this.lblTipo.TabIndex = 10;
            this.lblTipo.Text = "Tipo de reporte:";
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new System.Drawing.Point(168, 14);
            this.cmbTipoReporte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(215, 36);
            this.cmbTipoReporte.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesde.Location = new System.Drawing.Point(410, 17);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(70, 28);
            this.lblDesde.TabIndex = 8;
            this.lblDesde.Text = "Desde:";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVendedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(1063, 137);
            this.cmbVendedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(202, 36);
            this.cmbVendedor.TabIndex = 9;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVendedor.Location = new System.Drawing.Point(867, 140);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(101, 28);
            this.lblVendedor.TabIndex = 13;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.Location = new System.Drawing.Point(486, 14);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(358, 34);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSucursal.Location = new System.Drawing.Point(867, 17);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(88, 28);
            this.lblSucursal.TabIndex = 12;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHasta.Location = new System.Drawing.Point(410, 72);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(65, 28);
            this.lblHasta.TabIndex = 11;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Location = new System.Drawing.Point(486, 67);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(358, 34);
            this.dtpHasta.TabIndex = 3;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSucursal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(1063, 14);
            this.cmbSucursal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(202, 36);
            this.cmbSucursal.TabIndex = 4;
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToResizeRows = false;
            this.dgvReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportes.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvReportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(32, 407);
            this.dgvReportes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvReportes.MultiSelect = false;
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersVisible = false;
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.RowTemplate.Height = 24;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new System.Drawing.Size(1285, 363);
            this.dgvReportes.TabIndex = 22;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CentralCel.Properties.Resources.background_blured_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEncabezado);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Inventario";
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPie.ResumeLayout(false);
            this.panelPie.PerformLayout();
            this.panelTarjeta3.ResumeLayout(false);
            this.panelTarjeta3.PerformLayout();
            this.panelTarjeta2.ResumeLayout(false);
            this.panelTarjeta2.PerformLayout();
            this.panelTarjeta1.ResumeLayout(false);
            this.panelTarjeta1.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPie;
        private System.Windows.Forms.Button btnExportarCSV;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Panel panelTarjeta3;
        private System.Windows.Forms.Label lblValorTarjeta3;
        private System.Windows.Forms.Label lblTituloTarjeta3;
        private System.Windows.Forms.Panel panelTarjeta2;
        private System.Windows.Forms.Label lblValorTarjeta2;
        private System.Windows.Forms.Label lblTituloTarjeta2;
        private System.Windows.Forms.Panel panelTarjeta1;
        private System.Windows.Forms.Label lblValorTarjeta1;
        private System.Windows.Forms.Label lblTituloTarjeta1;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.DataGridView dgvReportes;
    }
}