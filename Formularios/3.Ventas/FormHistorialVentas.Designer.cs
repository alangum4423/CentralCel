namespace ventas_historial_VENTAS.Formularios._3.Ventas
{
    partial class FormHistorialVentas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorialVentas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblResumenCambio = new System.Windows.Forms.Label();
            this.lblResumenRecibido = new System.Windows.Forms.Label();
            this.lblResumenPago = new System.Windows.Forms.Label();
            this.lblResumenTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtBuscarVenta = new System.Windows.Forms.TextBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnAnularVenta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnVolverMenu);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1363, 97);
            this.panel1.TabIndex = 4;
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolverMenu.ForeColor = System.Drawing.Color.White;
            this.btnVolverMenu.Location = new System.Drawing.Point(1111, 27);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(225, 47);
            this.btnVolverMenu.TabIndex = 4;
            this.btnVolverMenu.Text = "Volver al Menu";
            this.btnVolverMenu.UseVisualStyleBackColor = false;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 60);
            this.label1.TabIndex = 3;
            this.label1.Text = "Historial de Ventas";
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistorial.Controls.Add(this.dgvHistorialVentas);
            this.pnlHistorial.Controls.Add(this.groupBox2);
            this.pnlHistorial.Controls.Add(this.groupBox4);
            this.pnlHistorial.Controls.Add(this.groupBox1);
            this.pnlHistorial.Location = new System.Drawing.Point(25, 128);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1311, 615);
            this.pnlHistorial.TabIndex = 5;
            // 
            // dgvHistorialVentas
            // 
            this.dgvHistorialVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.dgvHistorialVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialVentas.Location = new System.Drawing.Point(24, 162);
            this.dgvHistorialVentas.Name = "dgvHistorialVentas";
            this.dgvHistorialVentas.RowHeadersWidth = 51;
            this.dgvHistorialVentas.RowTemplate.Height = 24;
            this.dgvHistorialVentas.Size = new System.Drawing.Size(1264, 180);
            this.dgvHistorialVentas.TabIndex = 9;
            this.dgvHistorialVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorialVentas_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetalleVenta);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.groupBox2.Location = new System.Drawing.Point(24, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 250);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle de la Venta";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(11, 43);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.RowTemplate.Height = 24;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(815, 189);
            this.dgvDetalleVenta.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAnularVenta);
            this.groupBox4.Controls.Add(this.btnReimprimir);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.lblResumenCambio);
            this.groupBox4.Controls.Add(this.lblResumenRecibido);
            this.groupBox4.Controls.Add(this.lblResumenPago);
            this.groupBox4.Controls.Add(this.lblResumenTotal);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.groupBox4.Location = new System.Drawing.Point(877, 348);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(411, 250);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resumen";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label10.Location = new System.Drawing.Point(221, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 28);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cambio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label9.Location = new System.Drawing.Point(221, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 28);
            this.label9.TabIndex = 7;
            this.label9.Text = "Recibido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label8.Location = new System.Drawing.Point(13, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 28);
            this.label8.TabIndex = 6;
            this.label8.Text = "Pago:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label7.Location = new System.Drawing.Point(13, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 28);
            this.label7.TabIndex = 5;
            this.label7.Text = "Total:";
            // 
            // lblResumenCambio
            // 
            this.lblResumenCambio.AutoSize = true;
            this.lblResumenCambio.BackColor = System.Drawing.Color.Transparent;
            this.lblResumenCambio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenCambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.lblResumenCambio.Location = new System.Drawing.Point(365, 73);
            this.lblResumenCambio.Name = "lblResumenCambio";
            this.lblResumenCambio.Size = new System.Drawing.Size(35, 28);
            this.lblResumenCambio.TabIndex = 3;
            this.lblResumenCambio.Text = "Bs:";
            // 
            // lblResumenRecibido
            // 
            this.lblResumenRecibido.AutoSize = true;
            this.lblResumenRecibido.BackColor = System.Drawing.Color.Transparent;
            this.lblResumenRecibido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenRecibido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.lblResumenRecibido.Location = new System.Drawing.Point(365, 43);
            this.lblResumenRecibido.Name = "lblResumenRecibido";
            this.lblResumenRecibido.Size = new System.Drawing.Size(35, 28);
            this.lblResumenRecibido.TabIndex = 2;
            this.lblResumenRecibido.Text = "Bs:";
            // 
            // lblResumenPago
            // 
            this.lblResumenPago.AutoSize = true;
            this.lblResumenPago.BackColor = System.Drawing.Color.Transparent;
            this.lblResumenPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.lblResumenPago.Location = new System.Drawing.Point(157, 73);
            this.lblResumenPago.Name = "lblResumenPago";
            this.lblResumenPago.Size = new System.Drawing.Size(35, 28);
            this.lblResumenPago.TabIndex = 1;
            this.lblResumenPago.Text = "Bs.";
            // 
            // lblResumenTotal
            // 
            this.lblResumenTotal.AutoSize = true;
            this.lblResumenTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblResumenTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.lblResumenTotal.Location = new System.Drawing.Point(157, 43);
            this.lblResumenTotal.Name = "lblResumenTotal";
            this.lblResumenTotal.Size = new System.Drawing.Size(35, 28);
            this.lblResumenTotal.TabIndex = 0;
            this.lblResumenTotal.Text = "Bs.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboSucursal);
            this.groupBox1.Controls.Add(this.cboVendedor);
            this.groupBox1.Controls.Add(this.btnLimpiarFiltros);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.txtBuscarVenta);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.groupBox1.Location = new System.Drawing.Point(24, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1264, 135);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label13.Location = new System.Drawing.Point(16, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 28);
            this.label13.TabIndex = 16;
            this.label13.Text = "Buscar:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label12.Location = new System.Drawing.Point(1035, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 28);
            this.label12.TabIndex = 15;
            this.label12.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label11.Location = new System.Drawing.Point(755, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 28);
            this.label11.TabIndex = 14;
            this.label11.Text = "Vendedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label5.Location = new System.Drawing.Point(478, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 28);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sucursal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label4.Location = new System.Drawing.Point(237, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.label3.Location = new System.Drawing.Point(16, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Desde:";
            // 
            // cboSucursal
            // 
            this.cboSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cboSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSucursal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(581, 38);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(168, 36);
            this.cboSucursal.TabIndex = 10;
            // 
            // cboVendedor
            // 
            this.cboVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cboVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVendedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(871, 38);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(150, 36);
            this.cboVendedor.TabIndex = 9;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(956, 86);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(297, 34);
            this.btnLimpiarFiltros.TabIndex = 7;
            this.btnLimpiarFiltros.Text = "Limpiar filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click_1);
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(1116, 38);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(137, 36);
            this.cboEstado.TabIndex = 8;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(653, 86);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(297, 34);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click_2);
            // 
            // txtBuscarVenta
            // 
            this.txtBuscarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.txtBuscarVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarVenta.Location = new System.Drawing.Point(114, 86);
            this.txtBuscarVenta.Name = "txtBuscarVenta";
            this.txtBuscarVenta.Size = new System.Drawing.Size(513, 34);
            this.txtBuscarVenta.TabIndex = 5;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(317, 38);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(142, 34);
            this.dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(92, 38);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(134, 34);
            this.dtpDesde.TabIndex = 3;
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReimprimir.ForeColor = System.Drawing.Color.White;
            this.btnReimprimir.Location = new System.Drawing.Point(18, 183);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(382, 50);
            this.btnReimprimir.TabIndex = 9;
            this.btnReimprimir.Text = "Reimprimir nota de venta";
            this.btnReimprimir.UseVisualStyleBackColor = false;
            // 
            // btnAnularVenta
            // 
            this.btnAnularVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnAnularVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAnularVenta.ForeColor = System.Drawing.Color.White;
            this.btnAnularVenta.Location = new System.Drawing.Point(18, 127);
            this.btnAnularVenta.Name = "btnAnularVenta";
            this.btnAnularVenta.Size = new System.Drawing.Size(382, 50);
            this.btnAnularVenta.TabIndex = 10;
            this.btnAnularVenta.Text = "Anular venta";
            this.btnAnularVenta.UseVisualStyleBackColor = false;
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::CentralCel.Properties.Resources.background_blured_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1363, 776);
            this.Controls.Add(this.pnlHistorial);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "FormHistorialVentas";
            this.Text = "FormHistorialVentas";
            this.Load += new System.EventHandler(this.FormHistorialVentas_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblResumenCambio;
        private System.Windows.Forms.Label lblResumenRecibido;
        private System.Windows.Forms.Label lblResumenPago;
        private System.Windows.Forms.Label lblResumenTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtBuscarVenta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.Button btnAnularVenta;
        private System.Windows.Forms.Button btnReimprimir;
    }
}