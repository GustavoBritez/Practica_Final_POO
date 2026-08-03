namespace Final
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            
            // GroupBoxes
            this.grpOrg = new System.Windows.Forms.GroupBox();
            this.dgvOrganizadores = new System.Windows.Forms.DataGridView();
            this.txtOrgCodigo = new System.Windows.Forms.TextBox();
            this.txtOrgNombre = new System.Windows.Forms.TextBox();
            this.txtOrgTelefono = new System.Windows.Forms.TextBox();
            this.txtOrgDireccion = new System.Windows.Forms.TextBox();
            this.btnAgregarOrg = new System.Windows.Forms.Button();
            this.btnEliminarOrg = new System.Windows.Forms.Button();
            this.lblOrgCod = new System.Windows.Forms.Label();
            this.lblOrgNom = new System.Windows.Forms.Label();
            this.lblOrgTel = new System.Windows.Forms.Label();
            this.lblOrgDir = new System.Windows.Forms.Label();

            this.grpProv = new System.Windows.Forms.GroupBox();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.txtProvCodigo = new System.Windows.Forms.TextBox();
            this.txtProvRazonSocial = new System.Windows.Forms.TextBox();
            this.txtProvTelefono = new System.Windows.Forms.TextBox();
            this.btnAgregarProv = new System.Windows.Forms.Button();
            this.btnEliminarProv = new System.Windows.Forms.Button();
            this.lblProvCod = new System.Windows.Forms.Label();
            this.lblProvRazon = new System.Windows.Forms.Label();
            this.lblProvTel = new System.Windows.Forms.Label();

            this.grpAsociacion = new System.Windows.Forms.GroupBox();
            this.btnAsociar = new System.Windows.Forms.Button();
            this.lblGrilla3Header = new System.Windows.Forms.Label();
            this.dgvProvDeOrg = new System.Windows.Forms.DataGridView();
            this.lblGrilla4Header = new System.Windows.Forms.Label();
            this.dgvOrgDeProv = new System.Windows.Forms.DataGridView();

            this.grpPagos = new System.Windows.Forms.GroupBox();
            this.lblGrilla5Header = new System.Windows.Forms.Label();
            this.dgvPagosEnComun = new System.Windows.Forms.DataGridView();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtImportePago = new System.Windows.Forms.TextBox();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.cmbTipoPago = new System.Windows.Forms.ComboBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDetallePago = new System.Windows.Forms.TextBox();
            this.btnAgregarPago = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();

            this.grpTodosLosPagos = new System.Windows.Forms.GroupBox();
            this.dgvTodosLosPagos = new System.Windows.Forms.DataGridView();

            this.grpOrg.SuspendLayout();
            this.grpProv.SuspendLayout();
            this.grpAsociacion.SuspendLayout();
            this.grpPagos.SuspendLayout();
            this.grpTodosLosPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganizadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvDeOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgDeProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosEnComun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodosLosPagos)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(540, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema de Gestión: Organizadores, Proveedores y Pagos";

            // 
            // grpOrg (Grilla 1: ABM Organizadores)
            // 
            this.grpOrg.Controls.Add(this.btnEliminarOrg);
            this.grpOrg.Controls.Add(this.btnAgregarOrg);
            this.grpOrg.Controls.Add(this.lblOrgDir);
            this.grpOrg.Controls.Add(this.txtOrgDireccion);
            this.grpOrg.Controls.Add(this.lblOrgTel);
            this.grpOrg.Controls.Add(this.txtOrgTelefono);
            this.grpOrg.Controls.Add(this.lblOrgNom);
            this.grpOrg.Controls.Add(this.txtOrgNombre);
            this.grpOrg.Controls.Add(this.lblOrgCod);
            this.grpOrg.Controls.Add(this.txtOrgCodigo);
            this.grpOrg.Controls.Add(this.dgvOrganizadores);
            this.grpOrg.Location = new System.Drawing.Point(12, 45);
            this.grpOrg.Name = "grpOrg";
            this.grpOrg.Size = new System.Drawing.Size(560, 240);
            this.grpOrg.TabIndex = 1;
            this.grpOrg.TabStop = false;
            this.grpOrg.Text = "Grilla 1: ABM Organizadores";

            // dgvOrganizadores
            this.dgvOrganizadores.AllowUserToAddRows = false;
            this.dgvOrganizadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrganizadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrganizadores.Location = new System.Drawing.Point(10, 25);
            this.dgvOrganizadores.MultiSelect = false;
            this.dgvOrganizadores.Name = "dgvOrganizadores";
            this.dgvOrganizadores.ReadOnly = true;
            this.dgvOrganizadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrganizadores.Size = new System.Drawing.Size(540, 130);
            this.dgvOrganizadores.TabIndex = 0;
            this.dgvOrganizadores.SelectionChanged += new System.EventHandler(this.dgvOrganizadores_SelectionChanged);

            // Inputs Organizador
            this.lblOrgCod.AutoSize = true;
            this.lblOrgCod.Location = new System.Drawing.Point(10, 165);
            this.lblOrgCod.Text = "Cód:";
            this.txtOrgCodigo.Location = new System.Drawing.Point(45, 162);
            this.txtOrgCodigo.Size = new System.Drawing.Size(50, 23);

            this.lblOrgNom.AutoSize = true;
            this.lblOrgNom.Location = new System.Drawing.Point(105, 165);
            this.lblOrgNom.Text = "Nombre:";
            this.txtOrgNombre.Location = new System.Drawing.Point(165, 162);
            this.txtOrgNombre.Size = new System.Drawing.Size(120, 23);

            this.lblOrgTel.AutoSize = true;
            this.lblOrgTel.Location = new System.Drawing.Point(295, 165);
            this.lblOrgTel.Text = "Tel:";
            this.txtOrgTelefono.Location = new System.Drawing.Point(330, 162);
            this.txtOrgTelefono.Size = new System.Drawing.Size(90, 23);

            this.lblOrgDir.AutoSize = true;
            this.lblOrgDir.Location = new System.Drawing.Point(428, 165);
            this.lblOrgDir.Text = "Dir:";
            this.txtOrgDireccion.Location = new System.Drawing.Point(460, 162);
            this.txtOrgDireccion.Size = new System.Drawing.Size(90, 23);

            this.btnAgregarOrg.Location = new System.Drawing.Point(330, 195);
            this.btnAgregarOrg.Name = "btnAgregarOrg";
            this.btnAgregarOrg.Size = new System.Drawing.Size(105, 30);
            this.btnAgregarOrg.Text = "Agregar Org";
            this.btnAgregarOrg.UseVisualStyleBackColor = true;
            this.btnAgregarOrg.Click += new System.EventHandler(this.btnAgregarOrg_Click);

            this.btnEliminarOrg.Location = new System.Drawing.Point(445, 195);
            this.btnEliminarOrg.Name = "btnEliminarOrg";
            this.btnEliminarOrg.Size = new System.Drawing.Size(105, 30);
            this.btnEliminarOrg.Text = "Eliminar Org";
            this.btnEliminarOrg.UseVisualStyleBackColor = true;
            this.btnEliminarOrg.Click += new System.EventHandler(this.btnEliminarOrg_Click);

            // 
            // grpProv (Grilla 2: ABM Proveedores)
            // 
            this.grpProv.Controls.Add(this.btnEliminarProv);
            this.grpProv.Controls.Add(this.btnAgregarProv);
            this.grpProv.Controls.Add(this.lblProvTel);
            this.grpProv.Controls.Add(this.txtProvTelefono);
            this.grpProv.Controls.Add(this.lblProvRazon);
            this.grpProv.Controls.Add(this.txtProvRazonSocial);
            this.grpProv.Controls.Add(this.lblProvCod);
            this.grpProv.Controls.Add(this.txtProvCodigo);
            this.grpProv.Controls.Add(this.dgvProveedores);
            this.grpProv.Location = new System.Drawing.Point(585, 45);
            this.grpProv.Name = "grpProv";
            this.grpProv.Size = new System.Drawing.Size(580, 240);
            this.grpProv.TabIndex = 2;
            this.grpProv.TabStop = false;
            this.grpProv.Text = "Grilla 2: ABM Proveedores";

            // dgvProveedores
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(10, 25);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(560, 130);
            this.dgvProveedores.TabIndex = 0;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);

            // Inputs Proveedor
            this.lblProvCod.AutoSize = true;
            this.lblProvCod.Location = new System.Drawing.Point(10, 165);
            this.lblProvCod.Text = "Cód:";
            this.txtProvCodigo.Location = new System.Drawing.Point(45, 162);
            this.txtProvCodigo.Size = new System.Drawing.Size(50, 23);

            this.lblProvRazon.AutoSize = true;
            this.lblProvRazon.Location = new System.Drawing.Point(105, 165);
            this.lblProvRazon.Text = "Razón Social:";
            this.txtProvRazonSocial.Location = new System.Drawing.Point(185, 162);
            this.txtProvRazonSocial.Size = new System.Drawing.Size(180, 23);

            this.lblProvTel.AutoSize = true;
            this.lblProvTel.Location = new System.Drawing.Point(375, 165);
            this.lblProvTel.Text = "Tel:";
            this.txtProvTelefono.Location = new System.Drawing.Point(410, 162);
            this.txtProvTelefono.Size = new System.Drawing.Size(160, 23);

            this.btnAgregarProv.Location = new System.Drawing.Point(350, 195);
            this.btnAgregarProv.Name = "btnAgregarProv";
            this.btnAgregarProv.Size = new System.Drawing.Size(105, 30);
            this.btnAgregarProv.Text = "Agregar Prov";
            this.btnAgregarProv.UseVisualStyleBackColor = true;
            this.btnAgregarProv.Click += new System.EventHandler(this.btnAgregarProv_Click);

            this.btnEliminarProv.Location = new System.Drawing.Point(465, 195);
            this.btnEliminarProv.Name = "btnEliminarProv";
            this.btnEliminarProv.Size = new System.Drawing.Size(105, 30);
            this.btnEliminarProv.Text = "Eliminar Prov";
            this.btnEliminarProv.UseVisualStyleBackColor = true;
            this.btnEliminarProv.Click += new System.EventHandler(this.btnEliminarProv_Click);

            // 
            // grpAsociacion (Grilla 3 y Grilla 4 + Botón Asociar)
            // 
            this.grpAsociacion.Controls.Add(this.btnAsociar);
            this.grpAsociacion.Controls.Add(this.dgvOrgDeProv);
            this.grpAsociacion.Controls.Add(this.lblGrilla4Header);
            this.grpAsociacion.Controls.Add(this.dgvProvDeOrg);
            this.grpAsociacion.Controls.Add(this.lblGrilla3Header);
            this.grpAsociacion.Location = new System.Drawing.Point(12, 290);
            this.grpAsociacion.Name = "grpAsociacion";
            this.grpAsociacion.Size = new System.Drawing.Size(1153, 190);
            this.grpAsociacion.TabIndex = 3;
            this.grpAsociacion.TabStop = false;
            this.grpAsociacion.Text = "Asociaciones entre Organizadores y Proveedores";

            // Boton Asociar
            this.btnAsociar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAsociar.ForeColor = System.Drawing.Color.White;
            this.btnAsociar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAsociar.Location = new System.Drawing.Point(460, 85);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(235, 40);
            this.btnAsociar.Text = "⚡ Asociar (Grilla 1 + Grilla 2)";
            this.btnAsociar.UseVisualStyleBackColor = false;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);

            // Grilla 3: Proveedores asociados al organizador seleccionado en Grilla 1
            this.lblGrilla3Header.AutoSize = true;
            this.lblGrilla3Header.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrilla3Header.Location = new System.Drawing.Point(10, 22);
            this.lblGrilla3Header.Text = "Grilla 3: Proveedores del Organizador Seleccionado (Grilla 1)";
            this.dgvProvDeOrg.AllowUserToAddRows = false;
            this.dgvProvDeOrg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProvDeOrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvDeOrg.Location = new System.Drawing.Point(10, 42);
            this.dgvProvDeOrg.MultiSelect = false;
            this.dgvProvDeOrg.Name = "dgvProvDeOrg";
            this.dgvProvDeOrg.ReadOnly = true;
            this.dgvProvDeOrg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProvDeOrg.Size = new System.Drawing.Size(435, 135);
            this.dgvProvDeOrg.SelectionChanged += new System.EventHandler(this.dgvProvDeOrg_SelectionChanged);

            // Grilla 4: Organizadores asociados al proveedor seleccionado en Grilla 2
            this.lblGrilla4Header.AutoSize = true;
            this.lblGrilla4Header.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrilla4Header.Location = new System.Drawing.Point(710, 22);
            this.lblGrilla4Header.Text = "Grilla 4: Organizadores del Proveedor Seleccionado (Grilla 2)";
            this.dgvOrgDeProv.AllowUserToAddRows = false;
            this.dgvOrgDeProv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrgDeProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrgDeProv.Location = new System.Drawing.Point(710, 42);
            this.dgvOrgDeProv.MultiSelect = false;
            this.dgvOrgDeProv.Name = "dgvOrgDeProv";
            this.dgvOrgDeProv.ReadOnly = true;
            this.dgvOrgDeProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrgDeProv.Size = new System.Drawing.Size(435, 135);

            // 
            // grpPagos (Grilla 5 + Formularios de Pago + Botón Agregar Pago + Botón Pagar)
            // 
            this.grpPagos.Controls.Add(this.btnPagar);
            this.grpPagos.Controls.Add(this.btnAgregarPago);
            this.grpPagos.Controls.Add(this.txtDetallePago);
            this.grpPagos.Controls.Add(this.lblDetalle);
            this.grpPagos.Controls.Add(this.cmbTipoPago);
            this.grpPagos.Controls.Add(this.lblTipoPago);
            this.grpPagos.Controls.Add(this.dtpVencimiento);
            this.grpPagos.Controls.Add(this.lblVencimiento);
            this.grpPagos.Controls.Add(this.txtImportePago);
            this.grpPagos.Controls.Add(this.lblImporte);
            this.grpPagos.Controls.Add(this.dgvPagosEnComun);
            this.grpPagos.Controls.Add(this.lblGrilla5Header);
            this.grpPagos.Location = new System.Drawing.Point(12, 485);
            this.grpPagos.Name = "grpPagos";
            this.grpPagos.Size = new System.Drawing.Size(1153, 195);
            this.grpPagos.TabIndex = 4;
            this.grpPagos.TabStop = false;
            this.grpPagos.Text = "Grilla 5: Pagos en común y Gestión de Pagos";

            // Grilla 5 Header
            this.lblGrilla5Header.AutoSize = true;
            this.lblGrilla5Header.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrilla5Header.Location = new System.Drawing.Point(10, 22);
            this.lblGrilla5Header.Text = "Grilla 5: Pagos en Común (Organizador Grilla 1 + Proveedor Grilla 3)";

            // dgvPagosEnComun
            this.dgvPagosEnComun.AllowUserToAddRows = false;
            this.dgvPagosEnComun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagosEnComun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagosEnComun.Location = new System.Drawing.Point(10, 42);
            this.dgvPagosEnComun.MultiSelect = false;
            this.dgvPagosEnComun.Name = "dgvPagosEnComun";
            this.dgvPagosEnComun.ReadOnly = true;
            this.dgvPagosEnComun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagosEnComun.Size = new System.Drawing.Size(650, 140);

            // Inputs para Nuevo Pago
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(675, 45);
            this.lblImporte.Text = "Importe ($):";
            this.txtImportePago.Location = new System.Drawing.Point(755, 42);
            this.txtImportePago.Size = new System.Drawing.Size(100, 23);

            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Location = new System.Drawing.Point(870, 45);
            this.lblVencimiento.Text = "Vencimiento:";
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(955, 42);
            this.dtpVencimiento.Size = new System.Drawing.Size(110, 23);

            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Location = new System.Drawing.Point(675, 80);
            this.lblTipoPago.Text = "Tipo Pago:";
            this.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPago.FormattingEnabled = true;
            this.cmbTipoPago.Items.AddRange(new object[] { "Tarjeta", "Efectivo" });
            this.cmbTipoPago.Location = new System.Drawing.Point(755, 77);
            this.cmbTipoPago.Size = new System.Drawing.Size(100, 23);
            this.cmbTipoPago.SelectedIndex = 0;

            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(870, 80);
            this.lblDetalle.Text = "Detalle:";
            this.txtDetallePago.Location = new System.Drawing.Point(955, 77);
            this.txtDetallePago.Size = new System.Drawing.Size(185, 23);

            // Boton Agregar Pago
            this.btnAgregarPago.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregarPago.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarPago.Location = new System.Drawing.Point(675, 120);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(220, 40);
            this.btnAgregarPago.Text = "➕ Agregar Pago (Org G1 + Prov G3)";
            this.btnAgregarPago.UseVisualStyleBackColor = false;
            this.btnAgregarPago.Click += new System.EventHandler(this.btnAgregarPago_Click);

            // Boton Pagar
            this.btnPagar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPagar.Location = new System.Drawing.Point(915, 120);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(225, 40);
            this.btnPagar.Text = "💳 PAGAR (Calcular Recargo)";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);

            // 
            // grpTodosLosPagos (Grilla 6)
            // 
            this.grpTodosLosPagos.Controls.Add(this.dgvTodosLosPagos);
            this.grpTodosLosPagos.Location = new System.Drawing.Point(12, 685);
            this.grpTodosLosPagos.Name = "grpTodosLosPagos";
            this.grpTodosLosPagos.Size = new System.Drawing.Size(1153, 200);
            this.grpTodosLosPagos.TabIndex = 5;
            this.grpTodosLosPagos.TabStop = false;
            this.grpTodosLosPagos.Text = "Grilla 6: Todos los pagos (Pendientes y Pagados) Ordenados por Código de Organizador (LINQ)";

            // dgvTodosLosPagos
            this.dgvTodosLosPagos.AllowUserToAddRows = false;
            this.dgvTodosLosPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodosLosPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodosLosPagos.Location = new System.Drawing.Point(10, 25);
            this.dgvTodosLosPagos.MultiSelect = false;
            this.dgvTodosLosPagos.Name = "dgvTodosLosPagos";
            this.dgvTodosLosPagos.ReadOnly = true;
            this.dgvTodosLosPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodosLosPagos.Size = new System.Drawing.Size(1130, 160);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1180, 895);
            this.Controls.Add(this.grpTodosLosPagos);
            this.Controls.Add(this.grpPagos);
            this.Controls.Add(this.grpAsociacion);
            this.Controls.Add(this.grpProv);
            this.Controls.Add(this.grpOrg);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión - Ejercicio Final Cardacci";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.grpOrg.ResumeLayout(false);
            this.grpOrg.PerformLayout();
            this.grpProv.ResumeLayout(false);
            this.grpProv.PerformLayout();
            this.grpAsociacion.ResumeLayout(false);
            this.grpAsociacion.PerformLayout();
            this.grpPagos.ResumeLayout(false);
            this.grpPagos.PerformLayout();
            this.grpTodosLosPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganizadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvDeOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrgDeProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosEnComun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodosLosPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpOrg;
        private System.Windows.Forms.DataGridView dgvOrganizadores;
        private System.Windows.Forms.TextBox txtOrgCodigo;
        private System.Windows.Forms.TextBox txtOrgNombre;
        private System.Windows.Forms.TextBox txtOrgTelefono;
        private System.Windows.Forms.TextBox txtOrgDireccion;
        private System.Windows.Forms.Button btnAgregarOrg;
        private System.Windows.Forms.Button btnEliminarOrg;
        private System.Windows.Forms.Label lblOrgCod;
        private System.Windows.Forms.Label lblOrgNom;
        private System.Windows.Forms.Label lblOrgTel;
        private System.Windows.Forms.Label lblOrgDir;

        private System.Windows.Forms.GroupBox grpProv;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.TextBox txtProvCodigo;
        private System.Windows.Forms.TextBox txtProvRazonSocial;
        private System.Windows.Forms.TextBox txtProvTelefono;
        private System.Windows.Forms.Button btnAgregarProv;
        private System.Windows.Forms.Button btnEliminarProv;
        private System.Windows.Forms.Label lblProvCod;
        private System.Windows.Forms.Label lblProvRazon;
        private System.Windows.Forms.Label lblProvTel;

        private System.Windows.Forms.GroupBox grpAsociacion;
        private System.Windows.Forms.Button btnAsociar;
        private System.Windows.Forms.Label lblGrilla3Header;
        private System.Windows.Forms.DataGridView dgvProvDeOrg;
        private System.Windows.Forms.Label lblGrilla4Header;
        private System.Windows.Forms.DataGridView dgvOrgDeProv;

        private System.Windows.Forms.GroupBox grpPagos;
        private System.Windows.Forms.Label lblGrilla5Header;
        private System.Windows.Forms.DataGridView dgvPagosEnComun;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImportePago;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtDetallePago;
        private System.Windows.Forms.Button btnAgregarPago;
        private System.Windows.Forms.Button btnPagar;

        private System.Windows.Forms.GroupBox grpTodosLosPagos;
        private System.Windows.Forms.DataGridView dgvTodosLosPagos;
    }
}
