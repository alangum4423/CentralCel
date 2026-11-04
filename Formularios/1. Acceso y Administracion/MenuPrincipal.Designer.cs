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
            this.menuTraslados = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKardex = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNuevaVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistorialVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportesGenerales = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenuPrincipal = new System.Windows.Forms.Panel();
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
            this.ctxActualizarResumen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSeparador2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMenuPrincipal.SuspendLayout();
            this.pnlMenuPrincipal.SuspendLayout();
            this.pnlBienvenida.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.ctxMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMenuPrincipal
            // 
            this.menuMenuPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuMenuPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMenuPrincipal.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuMenuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArchivo,
            this.menuAdministracion,
            this.menuInventario,
            this.menuVentas,
            this.menuReportes});
            this.menuMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuMenuPrincipal.Name = "menuMenuPrincipal";
            this.menuMenuPrincipal.Size = new System.Drawing.Size(1368, 40);
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
            this.menuArchivo.Size = new System.Drawing.Size(112, 36);
            this.menuArchivo.Text = "Archivo";
            // 
            // menuCerrarSesion
            // 
            this.menuCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.menuCerrarSesion.Name = "menuCerrarSesion";
            this.menuCerrarSesion.Size = new System.Drawing.Size(263, 40);
            this.menuCerrarSesion.Text = "Cerrar Sesion";
            this.menuCerrarSesion.Click += new System.EventHandler(this.menuCerrarSesion_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuSalir.ForeColor = System.Drawing.Color.White;
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(263, 40);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuAcercaDe.ForeColor = System.Drawing.Color.White;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(263, 40);
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
            this.menuAdministracion.Size = new System.Drawing.Size(189, 36);
            this.menuAdministracion.Text = "Administracion";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuUsuarios.ForeColor = System.Drawing.Color.White;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(268, 40);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuSucursales
            // 
            this.menuSucursales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuSucursales.ForeColor = System.Drawing.Color.White;
            this.menuSucursales.Name = "menuSucursales";
            this.menuSucursales.Size = new System.Drawing.Size(268, 40);
            this.menuSucursales.Text = "Sucursales";
            this.menuSucursales.Click += new System.EventHandler(this.menuSucursales_Click);
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuConfiguracion.ForeColor = System.Drawing.Color.White;
            this.menuConfiguracion.Name = "menuConfiguracion";
            this.menuConfiguracion.Size = new System.Drawing.Size(268, 40);
            this.menuConfiguracion.Text = "Configuracion";
            this.menuConfiguracion.Click += new System.EventHandler(this.menuConfiguracion_Click);
            // 
            // menuInventario
            // 
            this.menuInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProductosExistencias,
            this.menuTraslados,
            this.menuCatalogos,
            this.menuKardex});
            this.menuInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuInventario.ForeColor = System.Drawing.Color.White;
            this.menuInventario.Name = "menuInventario";
            this.menuInventario.Size = new System.Drawing.Size(151, 36);
            this.menuInventario.Text = "Inventarios";
            // 
            // menuProductosExistencias
            // 
            this.menuProductosExistencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuProductosExistencias.ForeColor = System.Drawing.Color.White;
            this.menuProductosExistencias.Name = "menuProductosExistencias";
            this.menuProductosExistencias.Size = new System.Drawing.Size(369, 40);
            this.menuProductosExistencias.Text = "Productos y Existencias";
            this.menuProductosExistencias.Click += new System.EventHandler(this.menuProductosExistencias_Click);
            // 
            // menuTraslados
            // 
            this.menuTraslados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuTraslados.ForeColor = System.Drawing.Color.White;
            this.menuTraslados.Name = "menuTraslados";
            this.menuTraslados.Size = new System.Drawing.Size(369, 40);
            this.menuTraslados.Text = "Traslados";
            this.menuTraslados.Click += new System.EventHandler(this.menuTraslados_Click);
            // 
            // menuCatalogos
            // 
            this.menuCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuCatalogos.ForeColor = System.Drawing.Color.White;
            this.menuCatalogos.Name = "menuCatalogos";
            this.menuCatalogos.Size = new System.Drawing.Size(369, 40);
            this.menuCatalogos.Text = "Catalogos";
            this.menuCatalogos.Click += new System.EventHandler(this.menuCatalogos_Click);
            // 
            // menuKardex
            // 
            this.menuKardex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuKardex.ForeColor = System.Drawing.Color.White;
            this.menuKardex.Name = "menuKardex";
            this.menuKardex.Size = new System.Drawing.Size(369, 40);
            this.menuKardex.Text = "Kardex";
            this.menuKardex.Click += new System.EventHandler(this.menuKardex_Click);
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
            this.menuVentas.Size = new System.Drawing.Size(102, 36);
            this.menuVentas.Text = "Ventas";
            // 
            // menuNuevaVenta
            // 
            this.menuNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.menuNuevaVenta.Name = "menuNuevaVenta";
            this.menuNuevaVenta.Size = new System.Drawing.Size(288, 40);
            this.menuNuevaVenta.Text = "Nueva Venta";
            this.menuNuevaVenta.Click += new System.EventHandler(this.menuNuevaVenta_Click);
            // 
            // menuHistorialVentas
            // 
            this.menuHistorialVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuHistorialVentas.ForeColor = System.Drawing.Color.White;
            this.menuHistorialVentas.Name = "menuHistorialVentas";
            this.menuHistorialVentas.Size = new System.Drawing.Size(288, 40);
            this.menuHistorialVentas.Text = "Historial Ventas";
            this.menuHistorialVentas.Click += new System.EventHandler(this.menuHistorialVentas_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuClientes.ForeColor = System.Drawing.Color.White;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(288, 40);
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
            this.menuReportes.Size = new System.Drawing.Size(127, 36);
            this.menuReportes.Text = "Reportes";
            // 
            // menuReportesGenerales
            // 
            this.menuReportesGenerales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.menuReportesGenerales.ForeColor = System.Drawing.Color.White;
            this.menuReportesGenerales.Name = "menuReportesGenerales";
            this.menuReportesGenerales.Size = new System.Drawing.Size(330, 40);
            this.menuReportesGenerales.Text = "Reportes Generales";
            this.menuReportesGenerales.Click += new System.EventHandler(this.menuReportesGenerales_Click);
            // 
            // pnlMenuPrincipal
            // 
            this.pnlMenuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuPrincipal.Controls.Add(this.btnReportes);
            this.pnlMenuPrincipal.Controls.Add(this.btnAdministracion);
            this.pnlMenuPrincipal.Controls.Add(this.btnPuntodeVenta);
            this.pnlMenuPrincipal.Controls.Add(this.btnInventario);
            this.pnlMenuPrincipal.Controls.Add(this.pnlBienvenida);
            this.pnlMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuPrincipal.Location = new System.Drawing.Point(0, 40);
            this.pnlMenuPrincipal.Name = "pnlMenuPrincipal";
            this.pnlMenuPrincipal.Size = new System.Drawing.Size(1368, 630);
            this.pnlMenuPrincipal.TabIndex = 1;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(111)))), ((int)(((byte)(189)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(1032, 386);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(301, 214);
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
            this.btnAdministracion.Location = new System.Drawing.Point(1032, 140);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(301, 214);
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
            this.btnPuntodeVenta.Location = new System.Drawing.Point(707, 386);
            this.btnPuntodeVenta.Name = "btnPuntodeVenta";
            this.btnPuntodeVenta.Size = new System.Drawing.Size(301, 214);
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
            this.btnInventario.Location = new System.Drawing.Point(707, 140);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(301, 214);
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
            this.pnlBienvenida.Location = new System.Drawing.Point(30, 140);
            this.pnlBienvenida.Margin = new System.Windows.Forms.Padding(30, 140, 30, 30);
            this.pnlBienvenida.Name = "pnlBienvenida";
            this.pnlBienvenida.Size = new System.Drawing.Size(624, 460);
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
            this.lblFechaMenuPrincipal.Location = new System.Drawing.Point(26, 308);
            this.lblFechaMenuPrincipal.Name = "lblFechaMenuPrincipal";
            this.lblFechaMenuPrincipal.Size = new System.Drawing.Size(269, 60);
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
            this.lblRolMenuPrincipal.Location = new System.Drawing.Point(26, 232);
            this.lblRolMenuPrincipal.Name = "lblRolMenuPrincipal";
            this.lblRolMenuPrincipal.Size = new System.Drawing.Size(218, 60);
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
            this.lblUsuarioMenuPrincipal.Location = new System.Drawing.Point(26, 155);
            this.lblUsuarioMenuPrincipal.Name = "lblUsuarioMenuPrincipal";
            this.lblUsuarioMenuPrincipal.Size = new System.Drawing.Size(307, 60);
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
            this.lblTituloBienvenidoMenuPrincipal.Location = new System.Drawing.Point(26, 65);
            this.lblTituloBienvenidoMenuPrincipal.Name = "lblTituloBienvenidoMenuPrincipal";
            this.lblTituloBienvenidoMenuPrincipal.Size = new System.Drawing.Size(264, 65);
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
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 40);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1368, 120);
            this.pnlPrincipal.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(28, 66);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(446, 54);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Sistema de Ventas e Inventarios";
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(20, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(349, 78);
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
            this.ctxActualizarResumen,
            this.ctxSeparador2,
            this.ctxCerrarSesion,
            this.ctxSalir});
            this.ctxMenuPrincipal.Name = "ctxMenuPrincipal";
            this.ctxMenuPrincipal.Size = new System.Drawing.Size(301, 276);
            // 
            // ctxInventario
            // 
            this.ctxInventario.BackColor = System.Drawing.Color.White;
            this.ctxInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxInventario.Name = "ctxInventario";
            this.ctxInventario.Size = new System.Drawing.Size(300, 34);
            this.ctxInventario.Text = "📦 Abrir Inventario";
            this.ctxInventario.Click += new System.EventHandler(this.ctxInventario_Click);
            // 
            // ctxNuevaVenta
            // 
            this.ctxNuevaVenta.BackColor = System.Drawing.Color.White;
            this.ctxNuevaVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxNuevaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxNuevaVenta.Name = "ctxNuevaVenta";
            this.ctxNuevaVenta.Size = new System.Drawing.Size(300, 34);
            this.ctxNuevaVenta.Text = "🛒 Nueva Venta";
            this.ctxNuevaVenta.Click += new System.EventHandler(this.ctxNuevaVenta_Click);
            // 
            // ctxReportes
            // 
            this.ctxReportes.BackColor = System.Drawing.Color.White;
            this.ctxReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxReportes.Name = "ctxReportes";
            this.ctxReportes.Size = new System.Drawing.Size(300, 34);
            this.ctxReportes.Text = "📊 Abrir Reportes";
            this.ctxReportes.Click += new System.EventHandler(this.ctxReportes_Click);
            // 
            // ctxSeparador1
            // 
            this.ctxSeparador1.BackColor = System.Drawing.Color.White;
            this.ctxSeparador1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxSeparador1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxSeparador1.Name = "ctxSeparador1";
            this.ctxSeparador1.Size = new System.Drawing.Size(300, 34);
            this.ctxSeparador1.Text = "---------------------------";
            // 
            // ctxActualizarResumen
            // 
            this.ctxActualizarResumen.BackColor = System.Drawing.Color.White;
            this.ctxActualizarResumen.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxActualizarResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxActualizarResumen.Name = "ctxActualizarResumen";
            this.ctxActualizarResumen.Size = new System.Drawing.Size(300, 34);
            this.ctxActualizarResumen.Text = "🔄 Actualizar Resumen";
            this.ctxActualizarResumen.Click += new System.EventHandler(this.ctxActualizarResumen_Click);
            // 
            // ctxSeparador2
            // 
            this.ctxSeparador2.BackColor = System.Drawing.Color.White;
            this.ctxSeparador2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxSeparador2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxSeparador2.Name = "ctxSeparador2";
            this.ctxSeparador2.Size = new System.Drawing.Size(300, 34);
            this.ctxSeparador2.Text = "---------------------------";
            // 
            // ctxCerrarSesion
            // 
            this.ctxCerrarSesion.BackColor = System.Drawing.Color.White;
            this.ctxCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxCerrarSesion.Name = "ctxCerrarSesion";
            this.ctxCerrarSesion.Size = new System.Drawing.Size(300, 34);
            this.ctxCerrarSesion.Text = "🔒 Cerrar Sesion";
            this.ctxCerrarSesion.Click += new System.EventHandler(this.ctxCerrarSesion_Click);
            // 
            // ctxSalir
            // 
            this.ctxSalir.BackColor = System.Drawing.Color.White;
            this.ctxSalir.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.ctxSalir.Name = "ctxSalir";
            this.ctxSalir.Size = new System.Drawing.Size(300, 34);
            this.ctxSalir.Text = "🚪 Salir";
            this.ctxSalir.Click += new System.EventHandler(this.ctxSalir_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CentralCel.Properties.Resources.background_blured_login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1368, 670);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.pnlMenuPrincipal);
            this.Controls.Add(this.menuMenuPrincipal);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMenuPrincipal;
            this.Name = "MenuPrincipal";
            this.Text = "CentralCel - Menu Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuMenuPrincipal.ResumeLayout(false);
            this.menuMenuPrincipal.PerformLayout();
            this.pnlMenuPrincipal.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem menuTraslados;
        private System.Windows.Forms.ToolStripMenuItem menuNuevaVenta;
        private System.Windows.Forms.ToolStripMenuItem menuHistorialVentas;
        private System.Windows.Forms.ToolStripMenuItem menuReportesGenerales;
        private System.Windows.Forms.ToolStripMenuItem menuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuSucursales;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem menuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem menuKardex;
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
        private System.Windows.Forms.ToolStripMenuItem ctxActualizarResumen;
        private System.Windows.Forms.ToolStripMenuItem ctxSeparador2;
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
    }
}