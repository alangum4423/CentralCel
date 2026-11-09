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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnAnularVenta = new System.Windows.Forms.Button();
            this.dgvHistorialVentas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 83);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Historial de Ventas";
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.Controls.Add(this.btnReimprimir);
            this.pnlHistorial.Controls.Add(this.btnAnularVenta);
            this.pnlHistorial.Controls.Add(this.dgvHistorialVentas);
            this.pnlHistorial.Controls.Add(this.groupBox2);
            this.pnlHistorial.Controls.Add(this.groupBox4);
            this.pnlHistorial.Controls.Add(this.groupBox1);
            this.pnlHistorial.Location = new System.Drawing.Point(13, 100);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1211, 561);
            this.pnlHistorial.TabIndex = 5;
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimir.ForeColor = System.Drawing.Color.White;
            this.btnReimprimir.Location = new System.Drawing.Point(51, 506);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(226, 29);
            this.btnReimprimir.TabIndex = 6;
            this.btnReimprimir.Text = "Reimprimir nota de venta";
            this.btnReimprimir.UseVisualStyleBackColor = false;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click_1);
            // 
            // btnAnularVenta
            // 
            this.btnAnularVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnAnularVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnularVenta.ForeColor = System.Drawing.Color.White;
            this.btnAnularVenta.Location = new System.Drawing.Point(299, 506);
            this.btnAnularVenta.Name = "btnAnularVenta";
            this.btnAnularVenta.Size = new System.Drawing.Size(226, 29);
            this.btnAnularVenta.TabIndex = 8;
            this.btnAnularVenta.Text = "Anular venta";
            this.btnAnularVenta.UseVisualStyleBackColor = false;
            this.btnAnularVenta.Click += new System.EventHandler(this.btnAnularVenta_Click_1);
            // 
            // dgvHistorialVentas
            // 
            this.dgvHistorialVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialVentas.Location = new System.Drawing.Point(49, 139);
            this.dgvHistorialVentas.Name = "dgvHistorialVentas";
            this.dgvHistorialVentas.RowHeadersWidth = 51;
            this.dgvHistorialVentas.RowTemplate.Height = 24;
            this.dgvHistorialVentas.Size = new System.Drawing.Size(1113, 190);
            this.dgvHistorialVentas.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDetalleTitulo);
            this.groupBox2.Controls.Add(this.dgvDetalleVenta);
            this.groupBox2.Location = new System.Drawing.Point(49, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 170);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lblDetalleTitulo
            // 
            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleTitulo.Location = new System.Drawing.Point(5, 15);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(270, 30);
            this.lblDetalleTitulo.TabIndex = 1;
            this.lblDetalleTitulo.Text = "Detalle de la venta V-0012";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(4, 43);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.RowTemplate.Height = 24;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(733, 119);
            this.dgvDetalleVenta.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblResumenCambio);
            this.groupBox4.Controls.Add(this.lblResumenRecibido);
            this.groupBox4.Controls.Add(this.lblResumenPago);
            this.groupBox4.Controls.Add(this.lblResumenTotal);
            this.groupBox4.Location = new System.Drawing.Point(811, 330);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(351, 191);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cambio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "Recibido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Pago:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Total:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "Resumen";
            // 
            // lblResumenCambio
            // 
            this.lblResumenCambio.AutoSize = true;
            this.lblResumenCambio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.lblResumenCambio.Location = new System.Drawing.Point(217, 145);
            this.lblResumenCambio.Name = "lblResumenCambio";
            this.lblResumenCambio.Size = new System.Drawing.Size(31, 21);
            this.lblResumenCambio.TabIndex = 3;
            this.lblResumenCambio.Text = "Bs:";
            // 
            // lblResumenRecibido
            // 
            this.lblResumenRecibido.AutoSize = true;
            this.lblResumenRecibido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.lblResumenRecibido.Location = new System.Drawing.Point(217, 115);
            this.lblResumenRecibido.Name = "lblResumenRecibido";
            this.lblResumenRecibido.Size = new System.Drawing.Size(31, 21);
            this.lblResumenRecibido.TabIndex = 2;
            this.lblResumenRecibido.Text = "Bs:";
            // 
            // lblResumenPago
            // 
            this.lblResumenPago.AutoSize = true;
            this.lblResumenPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.lblResumenPago.Location = new System.Drawing.Point(217, 83);
            this.lblResumenPago.Name = "lblResumenPago";
            this.lblResumenPago.Size = new System.Drawing.Size(14, 21);
            this.lblResumenPago.TabIndex = 1;
            this.lblResumenPago.Text = ".";
            // 
            // lblResumenTotal
            // 
            this.lblResumenTotal.AutoSize = true;
            this.lblResumenTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.lblResumenTotal.Location = new System.Drawing.Point(217, 53);
            this.lblResumenTotal.Name = "lblResumenTotal";
            this.lblResumenTotal.Size = new System.Drawing.Size(31, 21);
            this.lblResumenTotal.TabIndex = 0;
            this.lblResumenTotal.Text = "Bs:";
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
            this.groupBox1.Location = new System.Drawing.Point(49, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1113, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 30);
            this.label13.TabIndex = 16;
            this.label13.Text = "Buscar:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(930, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 21);
            this.label12.TabIndex = 15;
            this.label12.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(725, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 21);
            this.label11.TabIndex = 14;
            this.label11.Text = "Vendedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sucursal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Desde:";
            // 
            // cboSucursal
            // 
            this.cboSucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(598, 19);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(121, 29);
            this.cboSucursal.TabIndex = 10;
            // 
            // cboVendedor
            // 
            this.cboVendedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(803, 19);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(121, 29);
            this.cboVendedor.TabIndex = 9;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(552, 63);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(124, 27);
            this.btnLimpiarFiltros.TabIndex = 7;
            this.btnLimpiarFiltros.Text = "Limpiar filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click_1);
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(986, 19);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 29);
            this.cboEstado.TabIndex = 8;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(411, 63);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(124, 27);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click_2);
            // 
            // txtBuscarVenta
            // 
            this.txtBuscarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(229)))), ((int)(((byte)(249)))));
            this.txtBuscarVenta.Location = new System.Drawing.Point(90, 65);
            this.txtBuscarVenta.Name = "txtBuscarVenta";
            this.txtBuscarVenta.Size = new System.Drawing.Size(304, 28);
            this.txtBuscarVenta.TabIndex = 5;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(323, 19);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 28);
            this.dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(64, 19);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 28);
            this.dtpDesde.TabIndex = 3;
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::CentralCel.Properties.Resources.background_blured_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1236, 673);
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
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Button btnAnularVenta;
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
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
    }
}