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
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(203, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTES";
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelEncabezado.Controls.Add(this.btnVolverMenu);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Location = new System.Drawing.Point(-1, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(1228, 75);
            this.panelEncabezado.TabIndex = 15;
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnVolverMenu.ForeColor = System.Drawing.Color.White;
            this.btnVolverMenu.Location = new System.Drawing.Point(1080, 25);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(130, 35);
            this.btnVolverMenu.TabIndex = 1;
            this.btnVolverMenu.Text = "Volver al menú";
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
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 736);
            this.panel1.TabIndex = 16;
            // 
            // panelPie
            // 
            this.panelPie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelPie.Controls.Add(this.btnExportarCSV);
            this.panelPie.Controls.Add(this.btnExportarPDF);
            this.panelPie.Controls.Add(this.lblResumen);
            this.panelPie.Location = new System.Drawing.Point(28, 631);
            this.panelPie.Name = "panelPie";
            this.panelPie.Size = new System.Drawing.Size(1142, 85);
            this.panelPie.TabIndex = 28;
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExportarCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportarCSV.Location = new System.Drawing.Point(719, 25);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(135, 38);
            this.btnExportarCSV.TabIndex = 16;
            this.btnExportarCSV.Text = "Exportar a CSV";
            this.btnExportarCSV.UseVisualStyleBackColor = false;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(544, 25);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(135, 38);
            this.btnExportarPDF.TabIndex = 15;
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(35, 31);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(182, 16);
            this.lblResumen.TabIndex = 14;
            this.lblResumen.Text = "0 registros · Datos del reporte";
            // 
            // panelTarjeta3
            // 
            this.panelTarjeta3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTarjeta3.Controls.Add(this.lblValorTarjeta3);
            this.panelTarjeta3.Controls.Add(this.lblTituloTarjeta3);
            this.panelTarjeta3.Location = new System.Drawing.Point(808, 222);
            this.panelTarjeta3.Name = "panelTarjeta3";
            this.panelTarjeta3.Size = new System.Drawing.Size(360, 65);
            this.panelTarjeta3.TabIndex = 27;
            // 
            // lblValorTarjeta3
            // 
            this.lblValorTarjeta3.AutoSize = true;
            this.lblValorTarjeta3.Location = new System.Drawing.Point(151, 33);
            this.lblValorTarjeta3.Name = "lblValorTarjeta3";
            this.lblValorTarjeta3.Size = new System.Drawing.Size(50, 16);
            this.lblValorTarjeta3.TabIndex = 1;
            this.lblValorTarjeta3.Text = "Bs 0,00";
            // 
            // lblTituloTarjeta3
            // 
            this.lblTituloTarjeta3.AutoSize = true;
            this.lblTituloTarjeta3.Location = new System.Drawing.Point(132, 4);
            this.lblTituloTarjeta3.Name = "lblTituloTarjeta3";
            this.lblTituloTarjeta3.Size = new System.Drawing.Size(90, 16);
            this.lblTituloTarjeta3.TabIndex = 0;
            this.lblTituloTarjeta3.Text = "Total vendido";
            // 
            // panelTarjeta2
            // 
            this.panelTarjeta2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTarjeta2.Controls.Add(this.lblValorTarjeta2);
            this.panelTarjeta2.Controls.Add(this.lblTituloTarjeta2);
            this.panelTarjeta2.Location = new System.Drawing.Point(426, 222);
            this.panelTarjeta2.Name = "panelTarjeta2";
            this.panelTarjeta2.Size = new System.Drawing.Size(360, 65);
            this.panelTarjeta2.TabIndex = 26;
            // 
            // lblValorTarjeta2
            // 
            this.lblValorTarjeta2.AutoSize = true;
            this.lblValorTarjeta2.Location = new System.Drawing.Point(173, 33);
            this.lblValorTarjeta2.Name = "lblValorTarjeta2";
            this.lblValorTarjeta2.Size = new System.Drawing.Size(14, 16);
            this.lblValorTarjeta2.TabIndex = 1;
            this.lblValorTarjeta2.Text = "0";
            // 
            // lblTituloTarjeta2
            // 
            this.lblTituloTarjeta2.AutoSize = true;
            this.lblTituloTarjeta2.Location = new System.Drawing.Point(116, 4);
            this.lblTituloTarjeta2.Name = "lblTituloTarjeta2";
            this.lblTituloTarjeta2.Size = new System.Drawing.Size(125, 16);
            this.lblTituloTarjeta2.TabIndex = 0;
            this.lblTituloTarjeta2.Text = "Unidades vendidas";
            // 
            // panelTarjeta1
            // 
            this.panelTarjeta1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTarjeta1.Controls.Add(this.lblValorTarjeta1);
            this.panelTarjeta1.Controls.Add(this.lblTituloTarjeta1);
            this.panelTarjeta1.Location = new System.Drawing.Point(40, 222);
            this.panelTarjeta1.Name = "panelTarjeta1";
            this.panelTarjeta1.Size = new System.Drawing.Size(360, 65);
            this.panelTarjeta1.TabIndex = 25;
            // 
            // lblValorTarjeta1
            // 
            this.lblValorTarjeta1.AutoSize = true;
            this.lblValorTarjeta1.Location = new System.Drawing.Point(161, 33);
            this.lblValorTarjeta1.Name = "lblValorTarjeta1";
            this.lblValorTarjeta1.Size = new System.Drawing.Size(14, 16);
            this.lblValorTarjeta1.TabIndex = 1;
            this.lblValorTarjeta1.Text = "0";
            // 
            // lblTituloTarjeta1
            // 
            this.lblTituloTarjeta1.AutoSize = true;
            this.lblTituloTarjeta1.Location = new System.Drawing.Point(113, 4);
            this.lblTituloTarjeta1.Name = "lblTituloTarjeta1";
            this.lblTituloTarjeta1.Size = new System.Drawing.Size(126, 16);
            this.lblTituloTarjeta1.TabIndex = 0;
            this.lblTituloTarjeta1.Text = "Ventas confirmadas";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.lblTituloReporte.Location = new System.Drawing.Point(27, 166);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(512, 38);
            this.lblTituloReporte.TabIndex = 24;
            this.lblTituloReporte.Text = "Ventas por fecha, sucursal y vendedor";
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
            this.panelFiltros.Location = new System.Drawing.Point(28, 20);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1140, 130);
            this.panelFiltros.TabIndex = 23;
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(896, 50);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(121, 24);
            this.cmbTipoMovimiento.TabIndex = 21;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(544, 50);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(180, 24);
            this.cmbProducto.TabIndex = 20;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(302, 50);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(145, 24);
            this.cmbMarca.TabIndex = 19;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(84, 50);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(150, 24);
            this.cmbCategoria.TabIndex = 18;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(297, 87);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 35);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(755, 53);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.Size = new System.Drawing.Size(129, 16);
            this.lblTipoMovimiento.TabIndex = 17;
            this.lblTipoMovimiento.Text = "Tipo de movimiento:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(84, 87);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(150, 35);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(474, 54);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(64, 16);
            this.lblProducto.TabIndex = 16;
            this.lblProducto.Text = "Producto:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(248, 53);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(48, 16);
            this.lblMarca.TabIndex = 15;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(9, 53);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(69, 16);
            this.lblCategoria.TabIndex = 14;
            this.lblCategoria.Text = "Categoría:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(3, 12);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(103, 16);
            this.lblTipo.TabIndex = 10;
            this.lblTipo.Text = "Tipo de reporte:";
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new System.Drawing.Point(112, 9);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(180, 24);
            this.cmbTipoReporte.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(309, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(51, 16);
            this.lblDesde.TabIndex = 8;
            this.lblDesde.Text = "Desde:";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(890, 87);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(180, 24);
            this.cmbVendedor.TabIndex = 9;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(814, 92);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(70, 16);
            this.lblVendedor.TabIndex = 13;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(366, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(180, 22);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(822, 12);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(62, 16);
            this.lblSucursal.TabIndex = 12;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(571, 12);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(46, 16);
            this.lblHasta.TabIndex = 11;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(623, 11);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(180, 22);
            this.dtpHasta.TabIndex = 3;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(890, 9);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(180, 24);
            this.cmbSucursal.TabIndex = 4;
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToResizeRows = false;
            this.dgvReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportes.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvReportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(28, 311);
            this.dgvReportes.MultiSelect = false;
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersVisible = false;
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.RowTemplate.Height = 24;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new System.Drawing.Size(1142, 300);
            this.dgvReportes.TabIndex = 22;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CentralCel.Properties.Resources.background_blured_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1227, 844);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelEncabezado);
            this.DoubleBuffered = true;
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