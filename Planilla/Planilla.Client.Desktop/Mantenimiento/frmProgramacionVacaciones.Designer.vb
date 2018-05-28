<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacionVacaciones
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAnioAProgramar = New System.Windows.Forms.TextBox()
        Me.grpDetalle = New System.Windows.Forms.GroupBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvPagoDctoBasico = New System.Windows.Forms.DataGridView()
        Me.IdVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IniProg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinProg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IniEje1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinEje1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IniEje2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinEje2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IniEje3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinEje3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCantidadEmpleados = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpDetalle.SuspendLayout()
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1060, 46)
        Me.Panel1.TabIndex = 87
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(15, 10)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(257, 25)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Programación de Vacaciones"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtAnioAProgramar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1054, 60)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "A programar : "
        '
        'txtAnioAProgramar
        '
        Me.txtAnioAProgramar.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnioAProgramar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioAProgramar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioAProgramar.Location = New System.Drawing.Point(7, 26)
        Me.txtAnioAProgramar.MaxLength = 350
        Me.txtAnioAProgramar.Name = "txtAnioAProgramar"
        Me.txtAnioAProgramar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAnioAProgramar.Size = New System.Drawing.Size(116, 25)
        Me.txtAnioAProgramar.TabIndex = 108
        Me.txtAnioAProgramar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpDetalle
        '
        Me.grpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetalle.Controls.Add(Me.dgvPagoDctoBasico)
        Me.grpDetalle.Location = New System.Drawing.Point(3, 115)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(1053, 380)
        Me.grpDetalle.TabIndex = 109
        Me.grpDetalle.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.BackColor = System.Drawing.Color.White
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(917, 501)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(140, 30)
        Me.btnGrabar.TabIndex = 111
        Me.btnGrabar.Text = "&Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(3, 501)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(140, 30)
        Me.btnCancelar.TabIndex = 110
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'dgvPagoDctoBasico
        '
        Me.dgvPagoDctoBasico.AllowUserToAddRows = False
        Me.dgvPagoDctoBasico.AllowUserToDeleteRows = False
        Me.dgvPagoDctoBasico.AllowUserToOrderColumns = True
        Me.dgvPagoDctoBasico.AllowUserToResizeRows = False
        Me.dgvPagoDctoBasico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPagoDctoBasico.BackgroundColor = System.Drawing.Color.White
        Me.dgvPagoDctoBasico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdVacaciones, Me.Anio, Me.Codigo, Me.Empleado, Me.Area, Me.IniProg, Me.FinProg, Me.IniEje1, Me.FinEje1, Me.IniEje2, Me.FinEje2, Me.IniEje3, Me.FinEje3})
        Me.dgvPagoDctoBasico.EnableHeadersVisualStyles = False
        Me.dgvPagoDctoBasico.Location = New System.Drawing.Point(7, 13)
        Me.dgvPagoDctoBasico.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvPagoDctoBasico.Name = "dgvPagoDctoBasico"
        Me.dgvPagoDctoBasico.RowHeadersVisible = False
        Me.dgvPagoDctoBasico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagoDctoBasico.Size = New System.Drawing.Size(1039, 359)
        Me.dgvPagoDctoBasico.TabIndex = 88
        '
        'IdVacaciones
        '
        Me.IdVacaciones.HeaderText = "IdVacaciones"
        Me.IdVacaciones.Name = "IdVacaciones"
        Me.IdVacaciones.Visible = False
        '
        'Anio
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Anio.DefaultCellStyle = DataGridViewCellStyle11
        Me.Anio.HeaderText = "Anio"
        Me.Anio.Name = "Anio"
        Me.Anio.ReadOnly = True
        Me.Anio.Width = 40
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 50
        '
        'Empleado
        '
        Me.Empleado.HeaderText = "Empleado"
        Me.Empleado.Name = "Empleado"
        Me.Empleado.ReadOnly = True
        Me.Empleado.Width = 220
        '
        'Area
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.Area.DefaultCellStyle = DataGridViewCellStyle12
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        Me.Area.Width = 140
        '
        'IniProg
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "d"
        Me.IniProg.DefaultCellStyle = DataGridViewCellStyle13
        Me.IniProg.HeaderText = "IniProg"
        Me.IniProg.Name = "IniProg"
        Me.IniProg.Width = 70
        '
        'FinProg
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "d"
        Me.FinProg.DefaultCellStyle = DataGridViewCellStyle14
        Me.FinProg.HeaderText = "FinProg"
        Me.FinProg.Name = "FinProg"
        Me.FinProg.Width = 70
        '
        'IniEje1
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "d"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.IniEje1.DefaultCellStyle = DataGridViewCellStyle15
        Me.IniEje1.HeaderText = "IniEje1"
        Me.IniEje1.Name = "IniEje1"
        Me.IniEje1.ReadOnly = True
        Me.IniEje1.Width = 70
        '
        'FinEje1
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "d"
        Me.FinEje1.DefaultCellStyle = DataGridViewCellStyle16
        Me.FinEje1.HeaderText = "FinEje1"
        Me.FinEje1.Name = "FinEje1"
        Me.FinEje1.ReadOnly = True
        Me.FinEje1.Width = 70
        '
        'IniEje2
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "d"
        Me.IniEje2.DefaultCellStyle = DataGridViewCellStyle17
        Me.IniEje2.HeaderText = "IniEje2"
        Me.IniEje2.Name = "IniEje2"
        Me.IniEje2.ReadOnly = True
        Me.IniEje2.Width = 70
        '
        'FinEje2
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "d"
        Me.FinEje2.DefaultCellStyle = DataGridViewCellStyle18
        Me.FinEje2.HeaderText = "FinEje2"
        Me.FinEje2.Name = "FinEje2"
        Me.FinEje2.ReadOnly = True
        Me.FinEje2.Width = 70
        '
        'IniEje3
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "d"
        Me.IniEje3.DefaultCellStyle = DataGridViewCellStyle19
        Me.IniEje3.HeaderText = "IniEje3"
        Me.IniEje3.Name = "IniEje3"
        Me.IniEje3.ReadOnly = True
        Me.IniEje3.Width = 70
        '
        'FinEje3
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "d"
        Me.FinEje3.DefaultCellStyle = DataGridViewCellStyle20
        Me.FinEje3.HeaderText = "FinEje3"
        Me.FinEje3.Name = "FinEje3"
        Me.FinEje3.ReadOnly = True
        Me.FinEje3.Width = 70
        '
        'lblCantidadEmpleados
        '
        Me.lblCantidadEmpleados.AutoSize = True
        Me.lblCantidadEmpleados.Location = New System.Drawing.Point(178, 509)
        Me.lblCantidadEmpleados.Name = "lblCantidadEmpleados"
        Me.lblCantidadEmpleados.Size = New System.Drawing.Size(144, 15)
        Me.lblCantidadEmpleados.TabIndex = 112
        Me.lblCantidadEmpleados.Text = "Cantidad de Empleados: 0"
        '
        'frmProgramacionVacaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 541)
        Me.Controls.Add(Me.lblCantidadEmpleados)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.grpDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmProgramacionVacaciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpDetalle.ResumeLayout(False)
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAnioAProgramar As TextBox
    Friend WithEvents grpDetalle As GroupBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents dgvPagoDctoBasico As DataGridView
    Friend WithEvents IdVacaciones As DataGridViewTextBoxColumn
    Friend WithEvents Anio As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents Empleado As DataGridViewTextBoxColumn
    Friend WithEvents Area As DataGridViewTextBoxColumn
    Friend WithEvents IniProg As DataGridViewTextBoxColumn
    Friend WithEvents FinProg As DataGridViewTextBoxColumn
    Friend WithEvents IniEje1 As DataGridViewTextBoxColumn
    Friend WithEvents FinEje1 As DataGridViewTextBoxColumn
    Friend WithEvents IniEje2 As DataGridViewTextBoxColumn
    Friend WithEvents FinEje2 As DataGridViewTextBoxColumn
    Friend WithEvents IniEje3 As DataGridViewTextBoxColumn
    Friend WithEvents FinEje3 As DataGridViewTextBoxColumn
    Friend WithEvents lblCantidadEmpleados As Label
End Class
