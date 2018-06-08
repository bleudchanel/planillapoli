namespace UI.Policlinico
{
    partial class Persona
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
            this.dgvPersona = new System.Windows.Forms.DataGridView();
            this.btnNuevaPersona = new System.Windows.Forms.Button();
            this.btnEditarPersona = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnEliminarPersona = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersona
            // 
            this.dgvPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersona.Location = new System.Drawing.Point(12, 126);
            this.dgvPersona.Name = "dgvPersona";
            this.dgvPersona.Size = new System.Drawing.Size(642, 377);
            this.dgvPersona.TabIndex = 0;
            // 
            // btnNuevaPersona
            // 
            this.btnNuevaPersona.Location = new System.Drawing.Point(12, 47);
            this.btnNuevaPersona.Name = "btnNuevaPersona";
            this.btnNuevaPersona.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaPersona.TabIndex = 1;
            this.btnNuevaPersona.Text = "Nuevo";
            this.btnNuevaPersona.UseVisualStyleBackColor = true;
            this.btnNuevaPersona.Click += new System.EventHandler(this.btnNuevaPersona_Click);
            // 
            // btnEditarPersona
            // 
            this.btnEditarPersona.Location = new System.Drawing.Point(155, 47);
            this.btnEditarPersona.Name = "btnEditarPersona";
            this.btnEditarPersona.Size = new System.Drawing.Size(75, 23);
            this.btnEditarPersona.TabIndex = 2;
            this.btnEditarPersona.Text = "Editar";
            this.btnEditarPersona.UseVisualStyleBackColor = true;
            this.btnEditarPersona.Click += new System.EventHandler(this.btnEditarPersona_Click);
            // 
            // btnEliminarPersona
            // 
            this.btnEliminarPersona.Location = new System.Drawing.Point(336, 46);
            this.btnEliminarPersona.Name = "btnEliminarPersona";
            this.btnEliminarPersona.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarPersona.TabIndex = 3;
            this.btnEliminarPersona.Text = "Eliminar";
            this.btnEliminarPersona.UseVisualStyleBackColor = true;
            this.btnEliminarPersona.Click += new System.EventHandler(this.btnEliminarPersona_Click);
            // 
            // Persona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 529);
            this.Controls.Add(this.btnEliminarPersona);
            this.Controls.Add(this.btnEditarPersona);
            this.Controls.Add(this.btnNuevaPersona);
            this.Controls.Add(this.dgvPersona);
            this.Name = "Persona";
            this.Text = "Persona";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersona;
        private System.Windows.Forms.Button btnNuevaPersona;
        private System.Windows.Forms.Button btnEditarPersona;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnEliminarPersona;
    }
}