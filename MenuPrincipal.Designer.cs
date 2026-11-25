namespace CentralCel.Formularios
{
    partial class MenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSucursales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProductosExistencias = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNuevaVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistorialVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportesGenerales = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenuPrincipal = new System.Windows.Forms.Panel();
            this.pctCajeros = new System.Windows.Forms.PictureBox();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.btnPuntodeVenta = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.pnlBienvenida = new System.Windows.Forms.Panel();
            this.lblFechaMenuPrincipal = new System.Windows.Forms.Label();
            this.lblRolMenuPrincipal = new System.Windows.Forms.Label();
            this.lblUsuarioMenuPrincipal = new System.Windows.Forms.Label();
            this.lblTituloBienvenidoMenuPrincipal = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.ctxMenuPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNuevaVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSeparador1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMenuPrincipal.SuspendLayout();
            this.pnlMenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCajeros)).BeginInit();
            this.pnlBienvenida.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.ctxMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMenuPrincipal
            // 
            this.menuMenuPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuMenuPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMenuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArchivo,
            this.menuAdministracion,
            this.menuInventario,
            this.menuVentas,
            this.menuReportes});
            this.menuMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuMenuPrincipal.Name = "menuMenuPrincipal";
            this.menuMenuPrincipal.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuMenuPrincipal.Size = new System.Drawing.Size(1216, 36);
            this.menuMenuPrincipal.TabIndex = 0;
            this.menuMenuPrincipal.Text = "menuStrip1";
            // 
            // menuArchivo
            // 
            this.menuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCerrarSesion,
            this.menuSalir,
            this.menuAcercaDe});
            this.menuArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuArchivo.ForeColor = System.Drawing.Color.White;
            this.menuArchivo.Name = "menuArchivo";
            this.menuArchivo.Size = new System.Drawing.Size(94, 32);
            this.menuArchivo.Text = "Archivo";
            // 
            // menuCerrarSesion
            // 
            this.menuCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.menuCerrarSesion.Name = "menuCerrarSesion";
            this.menuCerrarSesion.Size = new System.Drawing.Size(218, 32);
            this.menuCerrarSesion.Text = "Cerrar Sesion";
            this.menuCerrarSesion.Click += new System.EventHandler(this.menuCerrarSesion_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuSalir.ForeColor = System.Drawing.Color.White;
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(218, 32);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuAcercaDe.ForeColor = System.Drawing.Color.White;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(218, 32);
            this.menuAcercaDe.Text = "Acerca de...";
            this.menuAcercaDe.Click += new System.EventHandler(this.menuAcercaDe_Click);
            // 
            // menuAdministracion
            // 
            this.menuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuSucursales,
            this.menuConfiguracion});
            this.menuAdministracion.ForeColor = System.Drawing.Color.White;
            this.menuAdministracion.Name = "menuAdministracion";
            this.menuAdministracion.Size = new System.Drawing.Size(158, 32);
            this.menuAdministracion.Text = "Administracion";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuUsuarios.ForeColor = System.Drawing.Color.White;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(221, 32);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuSucursales
            // 
            this.menuSucursales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuSucursales.ForeColor = System.Drawing.Color.White;
            this.menuSucursales.Name = "menuSucursales";
            this.menuSucursales.Size = new System.Drawing.Size(221, 32);
            this.menuSucursales.Text = "Sucursales";
            this.menuSucursales.Click += new System.EventHandler(this.menuSucursales_Click);
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuConfiguracion.ForeColor = System.Drawing.Color.White;
            this.menuConfiguracion.Name = "menuConfiguracion";
            this.menuConfiguracion.Size = new System.Drawing.Size(221, 32);
            this.menuConfiguracion.Text = "Configuracion";
            this.menuConfiguracion.Click += new System.EventHandler(this.menuConfiguracion_Click);
            // 
            // menuInventario
            // 
            this.menuInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProductosExistencias,
            this.menuCatalogos});
            this.menuInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuInventario.ForeColor = System.Drawing.Color.White;
            this.menuInventario.Name = "menuInventario";
            this.menuInventario.Size = new System.Drawing.Size(127, 32);
            this.menuInventario.Text = "Inventarios";
            // 
            // menuProductosExistencias
            // 
            this.menuProductosExistencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuProductosExistencias.ForeColor = System.Drawing.Color.White;
            this.menuProductosExistencias.Name = "menuProductosExistencias";
            this.menuProductosExistencias.Size = new System.Drawing.Size(309, 32);
            this.menuProductosExistencias.Text = "Productos y Existencias";
            this.menuProductosExistencias.Click += new System.EventHandler(this.menuProductosExistencias_Click);
            // 
            // menuCatalogos
            // 
            this.menuCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuCatalogos.ForeColor = System.Drawing.Color.White;
            this.menuCatalogos.Name = "menuCatalogos";
            this.menuCatalogos.Size = new System.Drawing.Size(309, 32);
            this.menuCatalogos.Text = "Catalogos";
            this.menuCatalogos.Click += new System.EventHandler(this.menuCatalogos_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNuevaVenta,
            this.menuHistorialVentas,
            this.menuClientes});
            this.menuVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuVentas.ForeColor = System.Drawing.Color.White;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(87, 32);
            this.menuVentas.Text = "Ventas";
            // 
            // menuNuevaVenta
            // 
            this.menuNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.menuNuevaVenta.Name = "menuNuevaVenta";
            this.menuNuevaVenta.Size = new System.Drawing.Size(240, 32);
            this.menuNuevaVenta.Text = "Nueva Venta";
            this.menuNuevaVenta.Click += new System.EventHandler(this.menuNuevaVenta_Click);
            // 
            // menuHistorialVentas
            // 
            this.menuHistorialVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuHistorialVentas.ForeColor = System.Drawing.Color.White;
            this.menuHistorialVentas.Name = "menuHistorialVentas";
            this.menuHistorialVentas.Size = new System.Drawing.Size(240, 32);
            this.menuHistorialVentas.Text = "Historial Ventas";
            this.menuHistorialVentas.Click += new System.EventHandler(this.menuHistorialVentas_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuClientes.ForeColor = System.Drawing.Color.White;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(240, 32);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReportesGenerales});
            this.menuReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReportes.ForeColor = System.Drawing.Color.White;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(107, 32);
            this.menuReportes.Text = "Reportes";
            // 
            // menuReportesGenerales
            // 
            this.menuReportesGenerales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuReportesGenerales.ForeColor = System.Drawing.Color.White;
            this.menuReportesGenerales.Name = "menuReportesGenerales";
            this.menuReportesGenerales.Size = new System.Drawing.Size(275, 32);
            this.menuReportesGenerales.Text = "Reportes Generales";
            this.menuReportesGenerales.Click += new System.EventHandler(this.menuReportesGenerales_Click);
            // 
            // pnlMenuPrincipal
            // 
            this.pnlMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuPrincipal.Controls.Add(this.pctCajeros);
            this.pnlMenuPrincipal.Controls.Add(this.btnReportes);
            this.pnlMenuPrincipal.Controls.Add(this.btnAdministracion);
            this.pnlMenuPrincipal.Controls.Add(this.btnPuntodeVenta);
            this.pnlMenuPrincipal.Controls.Add(this.btnInventario);
            this.pnlMenuPrincipal.Controls.Add(this.pnlBienvenida);
            this.pnlMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuPrincipal.Location = new System.Drawing.Point(0, 36);
            this.pnlMenuPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenuPrincipal.Name = "pnlMenuPrincipal";
            this.pnlMenuPrincipal.Size = new System.Drawing.Size(1216, 500);
            this.pnlMenuPrincipal.TabIndex = 1;
            // 
            // pctCajeros
            // 
            this.pctCajeros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pctCajeros.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctCajeros.ErrorImage = null;
            this.pctCajeros.Location = new System.Drawing.Point(917, 0);
            this.pctCajeros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctCajeros.Name = "pctCajeros";
            this.pctCajeros.Size = new System.Drawing.Size(299, 500);
            this.pctCajeros.TabIndex = 15;
            this.pctCajeros.TabStop = false;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(917, 309);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(268, 171);
            this.btnReportes.TabIndex = 13;
            this.btnReportes.Text = "REPORTES";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.btnAdministracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministracion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministracion.ForeColor = System.Drawing.Color.White;
            this.btnAdministracion.Location = new System.Drawing.Point(917, 112);
            this.btnAdministracion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(268, 171);
            this.btnAdministracion.TabIndex = 12;
            this.btnAdministracion.Text = "ADMINISTRACION";
            this.btnAdministracion.UseVisualStyleBackColor = false;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);
            // 
            // btnPuntodeVenta
            // 
            this.btnPuntodeVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.btnPuntodeVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuntodeVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPuntodeVenta.ForeColor = System.Drawing.Color.White;
            this.btnPuntodeVenta.Location = new System.Drawing.Point(628, 309);
            this.btnPuntodeVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPuntodeVenta.Name = "btnPuntodeVenta";
            this.btnPuntodeVenta.Size = new System.Drawing.Size(268, 171);
            this.btnPuntodeVenta.TabIndex = 11;
            this.btnPuntodeVenta.Text = "PUNTO DE VENTA";
            this.btnPuntodeVenta.UseVisualStyleBackColor = false;
            this.btnPuntodeVenta.Click += new System.EventHandler(this.btnPuntodeVenta_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(628, 112);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(268, 171);
            this.btnInventario.TabIndex = 10;
            this.btnInventario.Text = "INVENTARIO";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // pnlBienvenida
            // 
            this.pnlBienvenida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBienvenida.Controls.Add(this.lblFechaMenuPrincipal);
            this.pnlBienvenida.Controls.Add(this.lblRolMenuPrincipal);
            this.pnlBienvenida.Controls.Add(this.lblUsuarioMenuPrincipal);
            this.pnlBienvenida.Controls.Add(this.lblTituloBienvenidoMenuPrincipal);
            this.pnlBienvenida.Location = new System.Drawing.Point(27, 112);
            this.pnlBienvenida.Margin = new System.Windows.Forms.Padding(27, 112, 27, 24);
            this.pnlBienvenida.Name = "pnlBienvenida";
            this.pnlBienvenida.Size = new System.Drawing.Size(555, 368);
            this.pnlBienvenida.TabIndex = 1;
            // 
            // lblFechaMenuPrincipal
            // 
            this.lblFechaMenuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaMenuPrincipal.AutoSize = true;
            this.lblFechaMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaMenuPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblFechaMenuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.lblFechaMenuPrincipal.Location = new System.Drawing.Point(23, 246);
            this.lblFechaMenuPrincipal.Name = "lblFechaMenuPrincipal";
            this.lblFechaMenuPrincipal.Size = new System.Drawing.Size(227, 50);
            this.lblFechaMenuPrincipal.TabIndex = 9;
            this.lblFechaMenuPrincipal.Text = "🗓️ Fecha: ...";
            // 
            // lblRolMenuPrincipal
            // 
            this.lblRolMenuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRolMenuPrincipal.AutoSize = true;
            this.lblRolMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.lblRolMenuPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblRolMenuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.lblRolMenuPrincipal.Location = new System.Drawing.Point(23, 186);
            this.lblRolMenuPrincipal.Name = "lblRolMenuPrincipal";
            this.lblRolMenuPrincipal.Size = new System.Drawing.Size(184, 50);
            this.lblRolMenuPrincipal.TabIndex = 8;
            this.lblRolMenuPrincipal.Text = "⚙️ Rol: ...";
            // 
            // lblUsuarioMenuPrincipal
            // 
            this.lblUsuarioMenuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioMenuPrincipal.AutoSize = true;
            this.lblUsuarioMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioMenuPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioMenuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.lblUsuarioMenuPrincipal.Location = new System.Drawing.Point(23, 124);
            this.lblUsuarioMenuPrincipal.Name = "lblUsuarioMenuPrincipal";
            this.lblUsuarioMenuPrincipal.Size = new System.Drawing.Size(259, 50);
            this.lblUsuarioMenuPrincipal.TabIndex = 7;
            this.lblUsuarioMenuPrincipal.Text = "👥 Usuario: ...";
            // 
            // lblTituloBienvenidoMenuPrincipal
            // 
            this.lblTituloBienvenidoMenuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloBienvenidoMenuPrincipal.AutoSize = true;
            this.lblTituloBienvenidoMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloBienvenidoMenuPrincipal.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold);
            this.lblTituloBienvenidoMenuPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.lblTituloBienvenidoMenuPrincipal.Location = new System.Drawing.Point(23, 52);
            this.lblTituloBienvenidoMenuPrincipal.Name = "lblTituloBienvenidoMenuPrincipal";
            this.lblTituloBienvenidoMenuPrincipal.Size = new System.Drawing.Size(219, 54);
            this.lblTituloBienvenidoMenuPrincipal.TabIndex = 6;
            this.lblTituloBienvenidoMenuPrincipal.Text = "Bievenido";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.pnlPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPrincipal.Controls.Add(this.lblDescripcion);
            this.pnlPrincipal.Controls.Add(this.lblNombre);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 36);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1216, 96);
            this.pnlPrincipal.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(25, 53);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(396, 43);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Sistema de Ventas e Inventarios";
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(18, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(310, 62);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "CentralCel";
            // 
            // ctxMenuPrincipal
            // 
            this.ctxMenuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctxMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxInventario,
            this.ctxNuevaVenta,
            this.ctxReportes,
            this.ctxSeparador1,
            this.ctxCerrarSesion,
            this.ctxSalir});
            this.ctxMenuPrincipal.Name = "ctxMenuPrincipal";
            this.ctxMenuPrincipal.Size = new System.Drawing.Size(269, 172);
            // 
            // ctxInventario
            // 
            this.ctxInventario.BackColor = System.Drawing.Color.White;
            this.ctxInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxInventario.Name = "ctxInventario";
            this.ctxInventario.Size = new System.Drawing.Size(268, 28);
            this.ctxInventario.Text = "📦 Abrir Inventario";
            this.ctxInventario.Click += new System.EventHandler(this.ctxInventario_Click);
            // 
            // ctxNuevaVenta
            // 
            this.ctxNuevaVenta.BackColor = System.Drawing.Color.White;
            this.ctxNuevaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxNuevaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxNuevaVenta.Name = "ctxNuevaVenta";
            this.ctxNuevaVenta.Size = new System.Drawing.Size(268, 28);
            this.ctxNuevaVenta.Text = "🛒 Nueva Venta";
            this.ctxNuevaVenta.Click += new System.EventHandler(this.ctxNuevaVenta_Click);
            // 
            // ctxReportes
            // 
            this.ctxReportes.BackColor = System.Drawing.Color.White;
            this.ctxReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxReportes.Name = "ctxReportes";
            this.ctxReportes.Size = new System.Drawing.Size(268, 28);
            this.ctxReportes.Text = "📊 Abrir Reportes";
            this.ctxReportes.Click += new System.EventHandler(this.ctxReportes_Click);
            // 
            // ctxSeparador1
            // 
            this.ctxSeparador1.BackColor = System.Drawing.Color.White;
            this.ctxSeparador1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxSeparador1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxSeparador1.Name = "ctxSeparador1";
            this.ctxSeparador1.Size = new System.Drawing.Size(268, 28);
            this.ctxSeparador1.Text = "---------------------------";
            // 
            // ctxCerrarSesion
            // 
            this.ctxCerrarSesion.BackColor = System.Drawing.Color.White;
            this.ctxCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxCerrarSesion.Name = "ctxCerrarSesion";
            this.ctxCerrarSesion.Size = new System.Drawing.Size(268, 28);
            this.ctxCerrarSesion.Text = "🔒 Cerrar Sesion";
            this.ctxCerrarSesion.Click += new System.EventHandler(this.ctxCerrarSesion_Click);
            // 
            // ctxSalir
            // 
            this.ctxSalir.BackColor = System.Drawing.Color.White;
            this.ctxSalir.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxSalir.Name = "ctxSalir";
            this.ctxSalir.Size = new System.Drawing.Size(268, 28);
            this.ctxSalir.Text = "🚪 Salir";
            this.ctxSalir.Click += new System.EventHandler(this.ctxSalir_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CentralCel.Properties.Resources.background_blured_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1216, 536);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlMenuPrincipal);
            this.Controls.Add(this.menuMenuPrincipal);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMenuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuPrincipal";
            this.Text = "CentralCel - Menu Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuMenuPrincipal.ResumeLayout(false);
            this.menuMenuPrincipal.PerformLayout();
            this.pnlMenuPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCajeros)).EndInit();
            this.pnlBienvenida.ResumeLayout(false);
            this.pnlBienvenida.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.ctxMenuPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuArchivo;
        private System.Windows.Forms.ToolStripMenuItem menuInventario;
        private System.Windows.Forms.ToolStripMenuItem menuVentas;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.Panel pnlMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem menuProductosExistencias;
        private System.Windows.Forms.ToolStripMenuItem menuNuevaVenta;
        private System.Windows.Forms.ToolStripMenuItem menuHistorialVentas;
        private System.Windows.Forms.ToolStripMenuItem menuReportesGenerales;
        private System.Windows.Forms.ToolStripMenuItem menuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuSucursales;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem menuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuAcercaDe;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ContextMenuStrip ctxMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem ctxInventario;
        private System.Windows.Forms.ToolStripMenuItem ctxNuevaVenta;
        private System.Windows.Forms.ToolStripMenuItem ctxReportes;
        private System.Windows.Forms.ToolStripMenuItem ctxSeparador1;
        private System.Windows.Forms.ToolStripMenuItem ctxCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem ctxSalir;
        private System.Windows.Forms.Panel pnlBienvenida;
        private System.Windows.Forms.Label lblFechaMenuPrincipal;
        private System.Windows.Forms.Label lblRolMenuPrincipal;
        private System.Windows.Forms.Label lblUsuarioMenuPrincipal;
        private System.Windows.Forms.Label lblTituloBienvenidoMenuPrincipal;
        private System.Windows.Forms.Button btnPuntodeVenta;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.PictureBox pctCajeros;
    }
}