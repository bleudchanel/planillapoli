namespace UI.Policlinico.Personal
{
    partial class frm0001Especialidad
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
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.txtMontMedic = new System.Windows.Forms.TextBox();
            this.txtPrecCon = new System.Windows.Forms.TextBox();
            this.lblCodido = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblEstadoL = new System.Windows.Forms.Label();
            this.lblMontMedicL = new System.Windows.Forms.Label();
            this.lblPrecConsL = new System.Windows.Forms.Label();
            this.lblEspecialidadL = new System.Windows.Forms.Label();
            this.lblCodidoL = new System.Windows.Forms.Label();
            this.gpConsulta = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDescripcionB = new System.Windows.Forms.TextBox();
            this.txtCodigoB = new System.Windows.Forms.TextBox();
            this.cbEstadoB = new System.Windows.Forms.ComboBox();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodEsp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioConsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.gpConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.btnCancelar);
            this.gbDatos.Controls.Add(this.cbEstado);
            this.gbDatos.Controls.Add(this.txtMontMedic);
            this.gbDatos.Controls.Add(this.txtPrecCon);
            this.gbDatos.Controls.Add(this.lblCodido);
            this.gbDatos.Controls.Add(this.txtDescripcion);
            this.gbDatos.Controls.Add(this.BtnGrabar);
            this.gbDatos.Controls.Add(this.btnNuevo);
            this.gbDatos.Controls.Add(this.lblEstadoL);
            this.gbDatos.Controls.Add(this.lblMontMedicL);
            this.gbDatos.Controls.Add(this.lblPrecConsL);
            this.gbDatos.Controls.Add(this.lblEspecialidadL);
            this.gbDatos.Controls.Add(this.lblCodidoL);
            this.gbDatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(583, 144);
            this.gbDatos.TabIndex = 0;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(421, 114);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 21);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(93, 115);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(102, 21);
            this.cbEstado.TabIndex = 4;
            // 
            // txtMontMedic
            // 
            this.txtMontMedic.Location = new System.Drawing.Point(93, 89);
            this.txtMontMedic.Name = "txtMontMedic";
            this.txtMontMedic.Size = new System.Drawing.Size(69, 20);
            this.txtMontMedic.TabIndex = 3;
            this.txtMontMedic.Text = "0.00";
            // 
            // txtPrecCon
            // 
            this.txtPrecCon.Location = new System.Drawing.Point(93, 63);
            this.txtPrecCon.Name = "txtPrecCon";
            this.txtPrecCon.Size = new System.Drawing.Size(69, 20);
            this.txtPrecCon.TabIndex = 2;
            this.txtPrecCon.Text = "0.00";
            // 
            // lblCodido
            // 
            this.lblCodido.AutoSize = true;
            this.lblCodido.Location = new System.Drawing.Point(90, 18);
            this.lblCodido.Name = "lblCodido";
            this.lblCodido.Size = new System.Drawing.Size(10, 13);
            this.lblCodido.TabIndex = 8;
            this.lblCodido.Text = "-";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(93, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(484, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Location = new System.Drawing.Point(502, 114);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(75, 21);
            this.BtnGrabar.TabIndex = 7;
            this.BtnGrabar.Text = "Grabar";
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Visible = false;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(502, 115);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 21);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblEstadoL
            // 
            this.lblEstadoL.AutoSize = true;
            this.lblEstadoL.Location = new System.Drawing.Point(6, 118);
            this.lblEstadoL.Name = "lblEstadoL";
            this.lblEstadoL.Size = new System.Drawing.Size(40, 13);
            this.lblEstadoL.TabIndex = 0;
            this.lblEstadoL.Text = "Estado";
            // 
            // lblMontMedicL
            // 
            this.lblMontMedicL.AutoSize = true;
            this.lblMontMedicL.Location = new System.Drawing.Point(6, 92);
            this.lblMontMedicL.Name = "lblMontMedicL";
            this.lblMontMedicL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMontMedicL.Size = new System.Drawing.Size(75, 13);
            this.lblMontMedicL.TabIndex = 0;
            this.lblMontMedicL.Text = "Monto Medico";
            // 
            // lblPrecConsL
            // 
            this.lblPrecConsL.AutoSize = true;
            this.lblPrecConsL.Location = new System.Drawing.Point(6, 66);
            this.lblPrecConsL.Name = "lblPrecConsL";
            this.lblPrecConsL.Size = new System.Drawing.Size(81, 13);
            this.lblPrecConsL.TabIndex = 0;
            this.lblPrecConsL.Text = "Precio Consulta";
            // 
            // lblEspecialidadL
            // 
            this.lblEspecialidadL.AutoSize = true;
            this.lblEspecialidadL.Location = new System.Drawing.Point(6, 40);
            this.lblEspecialidadL.Name = "lblEspecialidadL";
            this.lblEspecialidadL.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidadL.TabIndex = 0;
            this.lblEspecialidadL.Text = "Especialidad";
            // 
            // lblCodidoL
            // 
            this.lblCodidoL.AutoSize = true;
            this.lblCodidoL.Location = new System.Drawing.Point(6, 18);
            this.lblCodidoL.Name = "lblCodidoL";
            this.lblCodidoL.Size = new System.Drawing.Size(40, 13);
            this.lblCodidoL.TabIndex = 0;
            this.lblCodidoL.Text = "Código";
            // 
            // gpConsulta
            // 
            this.gpConsulta.Controls.Add(this.btnBuscar);
            this.gpConsulta.Controls.Add(this.txtDescripcionB);
            this.gpConsulta.Controls.Add(this.txtCodigoB);
            this.gpConsulta.Controls.Add(this.cbEstadoB);
            this.gpConsulta.Controls.Add(this.dgvEspecialidades);
            this.gpConsulta.Location = new System.Drawing.Point(12, 162);
            this.gpConsulta.Name = "gpConsulta";
            this.gpConsulta.Size = new System.Drawing.Size(583, 236);
            this.gpConsulta.TabIndex = 1;
            this.gpConsulta.TabStop = false;
            this.gpConsulta.Text = "Consulta";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(502, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 20);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcionB
            // 
            this.txtDescripcionB.Location = new System.Drawing.Point(93, 20);
            this.txtDescripcionB.Name = "txtDescripcionB";
            this.txtDescripcionB.Size = new System.Drawing.Size(277, 20);
            this.txtDescripcionB.TabIndex = 9;
            this.txtDescripcionB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDescripcionB_MouseClick);
            // 
            // txtCodigoB
            // 
            this.txtCodigoB.Location = new System.Drawing.Point(6, 20);
            this.txtCodigoB.Name = "txtCodigoB";
            this.txtCodigoB.Size = new System.Drawing.Size(81, 20);
            this.txtCodigoB.TabIndex = 8;
            this.txtCodigoB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCodigoB_MouseClick);
            // 
            // cbEstadoB
            // 
            this.cbEstadoB.FormattingEnabled = true;
            this.cbEstadoB.Location = new System.Drawing.Point(376, 19);
            this.cbEstadoB.Name = "cbEstadoB";
            this.cbEstadoB.Size = new System.Drawing.Size(120, 21);
            this.cbEstadoB.TabIndex = 12;
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.AllowUserToOrderColumns = true;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.CodEsp,
            this.Descripcion,
            this.PrecioConsulta,
            this.MontoMedico,
            this.estado,
            this.estadoDesc,
            this.FechaRegistro});
            this.dgvEspecialidades.Location = new System.Drawing.Point(6, 46);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.Size = new System.Drawing.Size(571, 184);
            this.dgvEspecialidades.TabIndex = 14;
            this.dgvEspecialidades.DoubleClick += new System.EventHandler(this.dgvEspecialidades_DoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // CodEsp
            // 
            this.CodEsp.DataPropertyName = "CodEsp";
            this.CodEsp.HeaderText = "Código";
            this.CodEsp.Name = "CodEsp";
            this.CodEsp.ReadOnly = true;
            this.CodEsp.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Especialidad";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 120;
            // 
            // PrecioConsulta
            // 
            this.PrecioConsulta.DataPropertyName = "PrecioConsulta";
            this.PrecioConsulta.HeaderText = "Precio Consulta";
            this.PrecioConsulta.Name = "PrecioConsulta";
            this.PrecioConsulta.ReadOnly = true;
            this.PrecioConsulta.Width = 80;
            // 
            // MontoMedico
            // 
            this.MontoMedico.DataPropertyName = "MontoMedico";
            this.MontoMedico.HeaderText = "Monto Medico";
            this.MontoMedico.Name = "MontoMedico";
            this.MontoMedico.ReadOnly = true;
            this.MontoMedico.Width = 80;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estadocod";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // estadoDesc
            // 
            this.estadoDesc.DataPropertyName = "EstadoDesc";
            this.estadoDesc.HeaderText = "Estado";
            this.estadoDesc.Name = "estadoDesc";
            this.estadoDesc.ReadOnly = true;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.DataPropertyName = "FechaRegistro";
            this.FechaRegistro.HeaderText = "Fecha Registro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(520, 404);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frm0001Especialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 439);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gpConsulta);
            this.Controls.Add(this.gbDatos);
            this.Name = "frm0001Especialidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEspecialidad";
            this.Load += new System.EventHandler(this.frmEspecialidad_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gpConsulta.ResumeLayout(false);
            this.gpConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.GroupBox gpConsulta;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox txtMontMedic;
        private System.Windows.Forms.TextBox txtPrecCon;
        private System.Windows.Forms.Label lblCodido;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button BtnGrabar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblEstadoL;
        private System.Windows.Forms.Label lblMontMedicL;
        private System.Windows.Forms.Label lblPrecConsL;
        private System.Windows.Forms.Label lblEspecialidadL;
        private System.Windows.Forms.Label lblCodidoL;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.ComboBox cbEstadoB;
        private System.Windows.Forms.TextBox txtDescripcionB;
        private System.Windows.Forms.TextBox txtCodigoB;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
    }
}