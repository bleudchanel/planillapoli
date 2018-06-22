<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaCTS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvPlanilla = New System.Windows.Forms.DataGridView()
        Me.IdPersonal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaNac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIng = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumCta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotRemuneracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SextoGrati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemComputable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MesesLab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoCTS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntidadFinanciera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpPrincipal = New System.Windows.Forms.GroupBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnioAProgramar = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMontoCts = New System.Windows.Forms.TextBox()
        Me.txtRemComputable = New System.Windows.Forms.TextBox()
        Me.txtSextoGrati = New System.Windows.Forms.TextBox()
        Me.txtTotalRemuneracion = New System.Windows.Forms.TextBox()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPrincipal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1094, 39)
        Me.Panel1.TabIndex = 92
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(15, 6)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(140, 25)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Gestión de CTS"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvPlanilla, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.grpPrincipal, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidad, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 39)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1094, 557)
        Me.TableLayoutPanel1.TabIndex = 94
        '
        'dgvPlanilla
        '
        Me.dgvPlanilla.AllowUserToAddRows = False
        Me.dgvPlanilla.AllowUserToDeleteRows = False
        Me.dgvPlanilla.AllowUserToOrderColumns = True
        Me.dgvPlanilla.AllowUserToResizeRows = False
        Me.dgvPlanilla.BackgroundColor = System.Drawing.Color.White
        Me.dgvPlanilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPersonal, Me.CodPer, Me.Dni, Me.Empleado, Me.FechaNac, Me.FechaIng, Me.NumCta, Me.TotRemuneracion, Me.SextoGrati, Me.RemComputable, Me.MesesLab, Me.MontoCTS, Me.EntidadFinanciera})
        Me.dgvPlanilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPlanilla.EnableHeadersVisualStyles = False
        Me.dgvPlanilla.Location = New System.Drawing.Point(5, 57)
        Me.dgvPlanilla.Margin = New System.Windows.Forms.Padding(5, 7, 5, 7)
        Me.dgvPlanilla.MultiSelect = False
        Me.dgvPlanilla.Name = "dgvPlanilla"
        Me.dgvPlanilla.ReadOnly = True
        Me.dgvPlanilla.RowHeadersVisible = False
        Me.dgvPlanilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPlanilla.Size = New System.Drawing.Size(1084, 410)
        Me.dgvPlanilla.TabIndex = 89
        '
        'IdPersonal
        '
        Me.IdPersonal.HeaderText = "IdPersonal"
        Me.IdPersonal.Name = "IdPersonal"
        Me.IdPersonal.ReadOnly = True
        Me.IdPersonal.Visible = False
        '
        'CodPer
        '
        Me.CodPer.HeaderText = "Cod"
        Me.CodPer.Name = "CodPer"
        Me.CodPer.ReadOnly = True
        Me.CodPer.Width = 50
        '
        'Dni
        '
        Me.Dni.HeaderText = "Dni"
        Me.Dni.Name = "Dni"
        Me.Dni.ReadOnly = True
        Me.Dni.Width = 75
        '
        'Empleado
        '
        Me.Empleado.HeaderText = "Empleado"
        Me.Empleado.Name = "Empleado"
        Me.Empleado.ReadOnly = True
        Me.Empleado.Width = 220
        '
        'FechaNac
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FechaNac.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaNac.HeaderText = "Fecha Nac"
        Me.FechaNac.Name = "FechaNac"
        Me.FechaNac.ReadOnly = True
        Me.FechaNac.Width = 75
        '
        'FechaIng
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FechaIng.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaIng.HeaderText = "Fecha Ing"
        Me.FechaIng.Name = "FechaIng"
        Me.FechaIng.ReadOnly = True
        Me.FechaIng.Width = 75
        '
        'NumCta
        '
        DataGridViewCellStyle3.Format = "d"
        Me.NumCta.DefaultCellStyle = DataGridViewCellStyle3
        Me.NumCta.HeaderText = "Num Cta"
        Me.NumCta.Name = "NumCta"
        Me.NumCta.ReadOnly = True
        Me.NumCta.Width = 150
        '
        'TotRemuneracion
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.TotRemuneracion.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotRemuneracion.HeaderText = "Tot. Remun."
        Me.TotRemuneracion.Name = "TotRemuneracion"
        Me.TotRemuneracion.ReadOnly = True
        Me.TotRemuneracion.Width = 75
        '
        'SextoGrati
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.SextoGrati.DefaultCellStyle = DataGridViewCellStyle5
        Me.SextoGrati.HeaderText = "1/6 Grati."
        Me.SextoGrati.Name = "SextoGrati"
        Me.SextoGrati.ReadOnly = True
        Me.SextoGrati.Width = 75
        '
        'RemComputable
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.Format = "N2"
        Me.RemComputable.DefaultCellStyle = DataGridViewCellStyle6
        Me.RemComputable.HeaderText = "Rem Computable"
        Me.RemComputable.Name = "RemComputable"
        Me.RemComputable.ReadOnly = True
        '
        'MesesLab
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.MesesLab.DefaultCellStyle = DataGridViewCellStyle7
        Me.MesesLab.HeaderText = "Meses"
        Me.MesesLab.Name = "MesesLab"
        Me.MesesLab.ReadOnly = True
        Me.MesesLab.Width = 50
        '
        'MontoCTS
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.MontoCTS.DefaultCellStyle = DataGridViewCellStyle8
        Me.MontoCTS.HeaderText = "Monto CTS"
        Me.MontoCTS.Name = "MontoCTS"
        Me.MontoCTS.ReadOnly = True
        Me.MontoCTS.Width = 85
        '
        'EntidadFinanciera
        '
        Me.EntidadFinanciera.HeaderText = "Entidad"
        Me.EntidadFinanciera.Name = "EntidadFinanciera"
        Me.EntidadFinanciera.ReadOnly = True
        Me.EntidadFinanciera.Width = 80
        '
        'grpPrincipal
        '
        Me.grpPrincipal.Controls.Add(Me.btnExcel)
        Me.grpPrincipal.Controls.Add(Me.btnGenerar)
        Me.grpPrincipal.Controls.Add(Me.Label1)
        Me.grpPrincipal.Controls.Add(Me.txtAnioAProgramar)
        Me.grpPrincipal.Controls.Add(Me.cmbMes)
        Me.grpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.grpPrincipal.Name = "grpPrincipal"
        Me.grpPrincipal.Size = New System.Drawing.Size(1088, 44)
        Me.grpPrincipal.TabIndex = 0
        Me.grpPrincipal.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.White
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(942, 9)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(140, 30)
        Me.btnExcel.TabIndex = 128
        Me.btnExcel.Text = "&Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.White
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(283, 9)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(140, 30)
        Me.btnGenerar.TabIndex = 125
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Año"
        '
        'txtAnioAProgramar
        '
        Me.txtAnioAProgramar.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnioAProgramar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioAProgramar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioAProgramar.Location = New System.Drawing.Point(204, 12)
        Me.txtAnioAProgramar.MaxLength = 350
        Me.txtAnioAProgramar.Name = "txtAnioAProgramar"
        Me.txtAnioAProgramar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAnioAProgramar.Size = New System.Drawing.Size(73, 25)
        Me.txtAnioAProgramar.TabIndex = 123
        Me.txtAnioAProgramar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(8, 14)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(158, 21)
        Me.cmbMes.TabIndex = 122
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMontoCts)
        Me.GroupBox1.Controls.Add(Me.txtRemComputable)
        Me.GroupBox1.Controls.Add(Me.txtSextoGrati)
        Me.GroupBox1.Controls.Add(Me.txtTotalRemuneracion)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 477)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1088, 54)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(981, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 131
        Me.Label5.Text = "Monto CTS"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(852, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "Rem. Computable"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(738, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "1/6 Gratificación"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(614, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Total Remuneración"
        '
        'txtMontoCts
        '
        Me.txtMontoCts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoCts.BackColor = System.Drawing.SystemColors.Window
        Me.txtMontoCts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoCts.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoCts.Location = New System.Drawing.Point(959, 23)
        Me.txtMontoCts.MaxLength = 350
        Me.txtMontoCts.Name = "txtMontoCts"
        Me.txtMontoCts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMontoCts.Size = New System.Drawing.Size(110, 25)
        Me.txtMontoCts.TabIndex = 127
        Me.txtMontoCts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRemComputable
        '
        Me.txtRemComputable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemComputable.BackColor = System.Drawing.SystemColors.Window
        Me.txtRemComputable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemComputable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemComputable.Location = New System.Drawing.Point(843, 23)
        Me.txtRemComputable.MaxLength = 350
        Me.txtRemComputable.Name = "txtRemComputable"
        Me.txtRemComputable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRemComputable.Size = New System.Drawing.Size(110, 25)
        Me.txtRemComputable.TabIndex = 126
        Me.txtRemComputable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSextoGrati
        '
        Me.txtSextoGrati.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSextoGrati.BackColor = System.Drawing.SystemColors.Window
        Me.txtSextoGrati.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSextoGrati.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSextoGrati.Location = New System.Drawing.Point(727, 23)
        Me.txtSextoGrati.MaxLength = 350
        Me.txtSextoGrati.Name = "txtSextoGrati"
        Me.txtSextoGrati.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSextoGrati.Size = New System.Drawing.Size(110, 25)
        Me.txtSextoGrati.TabIndex = 125
        Me.txtSextoGrati.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalRemuneracion
        '
        Me.txtTotalRemuneracion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalRemuneracion.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalRemuneracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalRemuneracion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRemuneracion.Location = New System.Drawing.Point(611, 23)
        Me.txtTotalRemuneracion.MaxLength = 350
        Me.txtTotalRemuneracion.Name = "txtTotalRemuneracion"
        Me.txtTotalRemuneracion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalRemuneracion.Size = New System.Drawing.Size(110, 25)
        Me.txtTotalRemuneracion.TabIndex = 124
        Me.txtTotalRemuneracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(3, 534)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(0, 13)
        Me.lblCantidad.TabIndex = 91
        '
        'frmPlanillaCTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 596)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPlanillaCTS"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPrincipal.ResumeLayout(False)
        Me.grpPrincipal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvPlanilla As DataGridView
    Friend WithEvents grpPrincipal As GroupBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnGenerar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAnioAProgramar As TextBox
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMontoCts As TextBox
    Friend WithEvents txtRemComputable As TextBox
    Friend WithEvents txtSextoGrati As TextBox
    Friend WithEvents txtTotalRemuneracion As TextBox
    Friend WithEvents lblCantidad As Label
    Friend WithEvents IdPersonal As DataGridViewTextBoxColumn
    Friend WithEvents CodPer As DataGridViewTextBoxColumn
    Friend WithEvents Dni As DataGridViewTextBoxColumn
    Friend WithEvents Empleado As DataGridViewTextBoxColumn
    Friend WithEvents FechaNac As DataGridViewTextBoxColumn
    Friend WithEvents FechaIng As DataGridViewTextBoxColumn
    Friend WithEvents NumCta As DataGridViewTextBoxColumn
    Friend WithEvents TotRemuneracion As DataGridViewTextBoxColumn
    Friend WithEvents SextoGrati As DataGridViewTextBoxColumn
    Friend WithEvents RemComputable As DataGridViewTextBoxColumn
    Friend WithEvents MesesLab As DataGridViewTextBoxColumn
    Friend WithEvents MontoCTS As DataGridViewTextBoxColumn
    Friend WithEvents EntidadFinanciera As DataGridViewTextBoxColumn
End Class
