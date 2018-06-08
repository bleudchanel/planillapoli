namespace UI.Policlinico.Dashboard
{
    partial class frmPanelControl
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
            this.btnPanelMantenimiento = new System.Windows.Forms.Button();
            this.btnPanelLogistica = new System.Windows.Forms.Button();
            this.btnPanelFarmacia = new System.Windows.Forms.Button();
            this.btnPanelCaja = new System.Windows.Forms.Button();
            this.btnPanelLaboratorio = new System.Windows.Forms.Button();
            this.btnPanelContabilidad = new System.Windows.Forms.Button();
            this.btnPanelPersonal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPanelMantenimiento
            // 
            this.btnPanelMantenimiento.Location = new System.Drawing.Point(82, 82);
            this.btnPanelMantenimiento.Name = "btnPanelMantenimiento";
            this.btnPanelMantenimiento.Size = new System.Drawing.Size(127, 67);
            this.btnPanelMantenimiento.TabIndex = 0;
            this.btnPanelMantenimiento.Text = "MANTENIMIENTO";
            this.btnPanelMantenimiento.UseVisualStyleBackColor = true;
            // 
            // btnPanelLogistica
            // 
            this.btnPanelLogistica.Location = new System.Drawing.Point(341, 82);
            this.btnPanelLogistica.Name = "btnPanelLogistica";
            this.btnPanelLogistica.Size = new System.Drawing.Size(127, 67);
            this.btnPanelLogistica.TabIndex = 1;
            this.btnPanelLogistica.Text = "LOGISTICA";
            this.btnPanelLogistica.UseVisualStyleBackColor = true;
            this.btnPanelLogistica.Click += new System.EventHandler(this.btnPanelLogistica_Click);
            // 
            // btnPanelFarmacia
            // 
            this.btnPanelFarmacia.Location = new System.Drawing.Point(82, 211);
            this.btnPanelFarmacia.Name = "btnPanelFarmacia";
            this.btnPanelFarmacia.Size = new System.Drawing.Size(127, 67);
            this.btnPanelFarmacia.TabIndex = 2;
            this.btnPanelFarmacia.Text = "FARMACIA";
            this.btnPanelFarmacia.UseVisualStyleBackColor = true;
            // 
            // btnPanelCaja
            // 
            this.btnPanelCaja.Location = new System.Drawing.Point(341, 211);
            this.btnPanelCaja.Name = "btnPanelCaja";
            this.btnPanelCaja.Size = new System.Drawing.Size(127, 67);
            this.btnPanelCaja.TabIndex = 3;
            this.btnPanelCaja.Text = "CAJA";
            this.btnPanelCaja.UseVisualStyleBackColor = true;
            // 
            // btnPanelLaboratorio
            // 
            this.btnPanelLaboratorio.Location = new System.Drawing.Point(82, 342);
            this.btnPanelLaboratorio.Name = "btnPanelLaboratorio";
            this.btnPanelLaboratorio.Size = new System.Drawing.Size(127, 67);
            this.btnPanelLaboratorio.TabIndex = 4;
            this.btnPanelLaboratorio.Text = "LABORATORIO";
            this.btnPanelLaboratorio.UseVisualStyleBackColor = true;
            // 
            // btnPanelContabilidad
            // 
            this.btnPanelContabilidad.Location = new System.Drawing.Point(341, 342);
            this.btnPanelContabilidad.Name = "btnPanelContabilidad";
            this.btnPanelContabilidad.Size = new System.Drawing.Size(127, 67);
            this.btnPanelContabilidad.TabIndex = 5;
            this.btnPanelContabilidad.Text = "CONTABILIDAD";
            this.btnPanelContabilidad.UseVisualStyleBackColor = true;
            // 
            // btnPanelPersonal
            // 
            this.btnPanelPersonal.Location = new System.Drawing.Point(82, 478);
            this.btnPanelPersonal.Name = "btnPanelPersonal";
            this.btnPanelPersonal.Size = new System.Drawing.Size(127, 67);
            this.btnPanelPersonal.TabIndex = 6;
            this.btnPanelPersonal.Text = "PERSONAL";
            this.btnPanelPersonal.UseVisualStyleBackColor = true;
            this.btnPanelPersonal.Click += new System.EventHandler(this.btnPanelPersonal_Click);
            // 
            // frmPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 557);
            this.Controls.Add(this.btnPanelPersonal);
            this.Controls.Add(this.btnPanelContabilidad);
            this.Controls.Add(this.btnPanelLaboratorio);
            this.Controls.Add(this.btnPanelCaja);
            this.Controls.Add(this.btnPanelFarmacia);
            this.Controls.Add(this.btnPanelLogistica);
            this.Controls.Add(this.btnPanelMantenimiento);
            this.Name = "frmPanelControl";
            this.Text = "SGPoliclinico - Panel";
            this.Load += new System.EventHandler(this.frmPanelControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPanelMantenimiento;
        private System.Windows.Forms.Button btnPanelLogistica;
        private System.Windows.Forms.Button btnPanelFarmacia;
        private System.Windows.Forms.Button btnPanelCaja;
        private System.Windows.Forms.Button btnPanelLaboratorio;
        private System.Windows.Forms.Button btnPanelContabilidad;
        private System.Windows.Forms.Button btnPanelPersonal;
    }
}