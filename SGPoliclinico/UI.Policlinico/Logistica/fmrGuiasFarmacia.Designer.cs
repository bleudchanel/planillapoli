namespace UI.Policlinico.Logistica
{
    partial class fmrGuiasFarmacia
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
            this.rbtNormal = new System.Windows.Forms.RadioButton();
            this.rbtDonacion = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.rbtFactura = new System.Windows.Forms.RadioButton();
            this.rbtBoleta = new System.Windows.Forms.RadioButton();
            this.rbtOtro = new System.Windows.Forms.RadioButton();
            this.txtNroBoleta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtTipoCompra = new System.Windows.Forms.GroupBox();
            this.lblRUC = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.rbtTipoDoc = new System.Windows.Forms.GroupBox();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPreCosto = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cmbMedicamento = new System.Windows.Forms.ComboBox();
            this.dgvFormato = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lblS = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FVenc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMedicina = new System.Windows.Forms.Button();
            this.btnActM = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.rbtTipoCompra.SuspendLayout();
            this.rbtTipoDoc.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormato)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtNormal
            // 
            this.rbtNormal.AutoSize = true;
            this.rbtNormal.Location = new System.Drawing.Point(6, 20);
            this.rbtNormal.Name = "rbtNormal";
            this.rbtNormal.Size = new System.Drawing.Size(58, 17);
            this.rbtNormal.TabIndex = 1;
            this.rbtNormal.TabStop = true;
            this.rbtNormal.Text = "Normal";
            this.rbtNormal.UseVisualStyleBackColor = true;
            this.rbtNormal.CheckedChanged += new System.EventHandler(this.rbtNormal_CheckedChanged);
            // 
            // rbtDonacion
            // 
            this.rbtDonacion.AutoSize = true;
            this.rbtDonacion.Location = new System.Drawing.Point(6, 43);
            this.rbtDonacion.Name = "rbtDonacion";
            this.rbtDonacion.Size = new System.Drawing.Size(71, 17);
            this.rbtDonacion.TabIndex = 2;
            this.rbtDonacion.TabStop = true;
            this.rbtDonacion.Text = "Donación";
            this.rbtDonacion.UseVisualStyleBackColor = true;
            this.rbtDonacion.CheckedChanged += new System.EventHandler(this.rbtDonacion_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "RUC";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(197, 15);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(448, 21);
            this.cmbProveedor.TabIndex = 6;
            // 
            // rbtFactura
            // 
            this.rbtFactura.AutoSize = true;
            this.rbtFactura.Location = new System.Drawing.Point(6, 16);
            this.rbtFactura.Name = "rbtFactura";
            this.rbtFactura.Size = new System.Drawing.Size(61, 17);
            this.rbtFactura.TabIndex = 7;
            this.rbtFactura.TabStop = true;
            this.rbtFactura.Text = "Factura";
            this.rbtFactura.UseVisualStyleBackColor = true;
            this.rbtFactura.CheckedChanged += new System.EventHandler(this.rbtFactura_CheckedChanged);
            // 
            // rbtBoleta
            // 
            this.rbtBoleta.AutoSize = true;
            this.rbtBoleta.Location = new System.Drawing.Point(71, 16);
            this.rbtBoleta.Name = "rbtBoleta";
            this.rbtBoleta.Size = new System.Drawing.Size(55, 17);
            this.rbtBoleta.TabIndex = 8;
            this.rbtBoleta.TabStop = true;
            this.rbtBoleta.Text = "Boleta";
            this.rbtBoleta.UseVisualStyleBackColor = true;
            this.rbtBoleta.CheckedChanged += new System.EventHandler(this.rbtBoleta_CheckedChanged);
            // 
            // rbtOtro
            // 
            this.rbtOtro.AutoSize = true;
            this.rbtOtro.Location = new System.Drawing.Point(132, 16);
            this.rbtOtro.Name = "rbtOtro";
            this.rbtOtro.Size = new System.Drawing.Size(71, 17);
            this.rbtOtro.TabIndex = 9;
            this.rbtOtro.TabStop = true;
            this.rbtOtro.Text = "Otro Doc.";
            this.rbtOtro.UseVisualStyleBackColor = true;
            this.rbtOtro.CheckedChanged += new System.EventHandler(this.rbtOtro_CheckedChanged);
            // 
            // txtNroBoleta
            // 
            this.txtNroBoleta.Location = new System.Drawing.Point(738, 51);
            this.txtNroBoleta.Name = "txtNroBoleta";
            this.txtNroBoleta.Size = new System.Drawing.Size(100, 20);
            this.txtNroBoleta.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(946, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Guía de Ingreso";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtTipoCompra);
            this.panel1.Controls.Add(this.lblRUC);
            this.panel1.Controls.Add(this.lblDireccion);
            this.panel1.Controls.Add(this.rbtTipoDoc);
            this.panel1.Controls.Add(this.dtpFechaRecepcion);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNroBoleta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbProveedor);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 102);
            this.panel1.TabIndex = 13;
            // 
            // rbtTipoCompra
            // 
            this.rbtTipoCompra.Controls.Add(this.rbtNormal);
            this.rbtTipoCompra.Controls.Add(this.rbtDonacion);
            this.rbtTipoCompra.Location = new System.Drawing.Point(7, 11);
            this.rbtTipoCompra.Name = "rbtTipoCompra";
            this.rbtTipoCompra.Size = new System.Drawing.Size(89, 75);
            this.rbtTipoCompra.TabIndex = 17;
            this.rbtTipoCompra.TabStop = false;
            this.rbtTipoCompra.Text = "Tipo Compra";
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Location = new System.Drawing.Point(197, 73);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(10, 13);
            this.lblRUC.TabIndex = 16;
            this.lblRUC.Text = "-";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(197, 47);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(10, 13);
            this.lblDireccion.TabIndex = 15;
            this.lblDireccion.Text = "-";
            // 
            // rbtTipoDoc
            // 
            this.rbtTipoDoc.Controls.Add(this.rbtFactura);
            this.rbtTipoDoc.Controls.Add(this.rbtBoleta);
            this.rbtTipoDoc.Controls.Add(this.rbtOtro);
            this.rbtTipoDoc.Location = new System.Drawing.Point(692, 4);
            this.rbtTipoDoc.Name = "rbtTipoDoc";
            this.rbtTipoDoc.Size = new System.Drawing.Size(206, 42);
            this.rbtTipoDoc.TabIndex = 14;
            this.rbtTipoDoc.TabStop = false;
            // 
            // dtpFechaRecepcion
            // 
            this.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(738, 77);
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaRecepcion.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActM);
            this.panel2.Controls.Add(this.btnMedicina);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtLote);
            this.panel2.Controls.Add(this.dtpVencimiento);
            this.panel2.Controls.Add(this.txtCantidad);
            this.panel2.Controls.Add(this.txtPrecioVenta);
            this.panel2.Controls.Add(this.txtPreCosto);
            this.panel2.Controls.Add(this.txtStock);
            this.panel2.Controls.Add(this.cmbMedicamento);
            this.panel2.Location = new System.Drawing.Point(12, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 67);
            this.panel2.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(957, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Lote";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(855, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Vencimiento";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(778, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cantidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(698, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Precio Venta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(615, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Precio Costo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(551, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Descripción";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(960, 30);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(100, 20);
            this.txtLote.TabIndex = 14;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(858, 30);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(96, 20);
            this.dtpVencimiento.TabIndex = 14;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(781, 30);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(74, 20);
            this.txtCantidad.TabIndex = 16;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(701, 30);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(74, 20);
            this.txtPrecioVenta.TabIndex = 15;
            // 
            // txtPreCosto
            // 
            this.txtPreCosto.Location = new System.Drawing.Point(618, 30);
            this.txtPreCosto.Name = "txtPreCosto";
            this.txtPreCosto.Size = new System.Drawing.Size(77, 20);
            this.txtPreCosto.TabIndex = 14;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(554, 30);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(58, 20);
            this.txtStock.TabIndex = 13;
            // 
            // cmbMedicamento
            // 
            this.cmbMedicamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMedicamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMedicamento.FormattingEnabled = true;
            this.cmbMedicamento.Location = new System.Drawing.Point(43, 29);
            this.cmbMedicamento.Name = "cmbMedicamento";
            this.cmbMedicamento.Size = new System.Drawing.Size(397, 21);
            this.cmbMedicamento.TabIndex = 0;
            // 
            // dgvFormato
            // 
            this.dgvFormato.AllowUserToAddRows = false;
            this.dgvFormato.AllowUserToOrderColumns = true;
            this.dgvFormato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.Codigo,
            this.Stock,
            this.PreCosto,
            this.PreVenta,
            this.Cant,
            this.SubTotalCom,
            this.FVenc,
            this.Lote});
            this.dgvFormato.Location = new System.Drawing.Point(0, 0);
            this.dgvFormato.Name = "dgvFormato";
            this.dgvFormato.ReadOnly = true;
            this.dgvFormato.Size = new System.Drawing.Size(1092, 241);
            this.dgvFormato.TabIndex = 15;
            this.dgvFormato.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFormato_DataBindingComplete);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvFormato);
            this.panel3.Location = new System.Drawing.Point(12, 194);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1092, 240);
            this.panel3.TabIndex = 16;
            // 
            // cmbServicio
            // 
            this.cmbServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(12, 467);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(230, 21);
            this.cmbServicio.TabIndex = 14;
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(12, 451);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(45, 13);
            this.lblS.TabIndex = 14;
            this.lblS.Text = "Servicio";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(605, 451);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(245, 35);
            this.txtTotal.TabIndex = 14;
            this.txtTotal.Text = "Total S/.";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(605, 489);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(245, 23);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "Grabar Compra";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1121, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 347;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 75;
            // 
            // PreCosto
            // 
            this.PreCosto.HeaderText = "PreCosto";
            this.PreCosto.Name = "PreCosto";
            this.PreCosto.ReadOnly = true;
            this.PreCosto.Width = 75;
            // 
            // PreVenta
            // 
            this.PreVenta.HeaderText = "PreVenta";
            this.PreVenta.Name = "PreVenta";
            this.PreVenta.ReadOnly = true;
            this.PreVenta.Width = 75;
            // 
            // Cant
            // 
            this.Cant.HeaderText = "Cant";
            this.Cant.Name = "Cant";
            this.Cant.ReadOnly = true;
            this.Cant.Width = 75;
            // 
            // SubTotalCom
            // 
            this.SubTotalCom.HeaderText = "SubTotalCom";
            this.SubTotalCom.Name = "SubTotalCom";
            this.SubTotalCom.ReadOnly = true;
            // 
            // FVenc
            // 
            this.FVenc.HeaderText = "FVenc";
            this.FVenc.Name = "FVenc";
            this.FVenc.ReadOnly = true;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            // 
            // btnMedicina
            // 
            this.btnMedicina.Location = new System.Drawing.Point(457, 29);
            this.btnMedicina.Name = "btnMedicina";
            this.btnMedicina.Size = new System.Drawing.Size(75, 23);
            this.btnMedicina.TabIndex = 23;
            this.btnMedicina.Text = "Producto";
            this.btnMedicina.UseVisualStyleBackColor = true;
            this.btnMedicina.Click += new System.EventHandler(this.btnMedicina_Click);
            // 
            // btnActM
            // 
            this.btnActM.BackgroundImage = global::UI.Policlinico.Properties.Resources.dd;
            this.btnActM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActM.Location = new System.Drawing.Point(10, 28);
            this.btnActM.Name = "btnActM";
            this.btnActM.Size = new System.Drawing.Size(27, 23);
            this.btnActM.TabIndex = 24;
            this.btnActM.UseVisualStyleBackColor = true;
            this.btnActM.Click += new System.EventHandler(this.btnActM_Click);
            // 
            // fmrGuiasFarmacia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 524);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.cmbServicio);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fmrGuiasFarmacia";
            this.Text = "fmrGuiasFarmacia";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rbtTipoCompra.ResumeLayout(false);
            this.rbtTipoCompra.PerformLayout();
            this.rbtTipoDoc.ResumeLayout(false);
            this.rbtTipoDoc.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormato)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtNormal;
        private System.Windows.Forms.RadioButton rbtDonacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.RadioButton rbtFactura;
        private System.Windows.Forms.RadioButton rbtBoleta;
        private System.Windows.Forms.RadioButton rbtOtro;
        private System.Windows.Forms.TextBox txtNroBoleta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPreCosto;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.ComboBox cmbMedicamento;
        private System.Windows.Forms.DataGridView dgvFormato;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.GroupBox rbtTipoDoc;
        private System.Windows.Forms.GroupBox rbtTipoCompra;
        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn FVenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.Button btnMedicina;
        private System.Windows.Forms.Button btnActM;
    }
}