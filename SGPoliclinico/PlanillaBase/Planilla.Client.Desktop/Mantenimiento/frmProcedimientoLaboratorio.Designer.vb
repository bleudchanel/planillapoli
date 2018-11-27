<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcedimientoLaboratorio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.tbcOtrosPagos = New System.Windows.Forms.TabControl()
        Me.tbpListar = New System.Windows.Forms.TabPage()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvPagoDctoBasico = New System.Windows.Forms.DataGridView()
        Me.IdProcedimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipPro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Procedimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEspecialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEsp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioProcedimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoMedico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProImprimir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AreaLaboratorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpNuevo = New System.Windows.Forms.TabPage()
        Me.grpManagement = New System.Windows.Forms.GroupBox()
        Me.cmbAreaLaboratorio = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbConsultaPro = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombreCorto = New System.Windows.Forms.TextBox()
        Me.cmbEspecialidad = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMontoMedico = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProcedimiento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtPrecioProcedimiento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpAccion = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.tbcOtrosPagos.SuspendLayout()
        Me.tbpListar.SuspendLayout()
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpNuevo.SuspendLayout()
        Me.grpManagement.SuspendLayout()
        Me.grpAccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 35)
        Me.Panel1.TabIndex = 87
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(12, 4)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(432, 25)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Mantenimiento Procedimiento de LABORATORIO"
        '
        'tbcOtrosPagos
        '
        Me.tbcOtrosPagos.Controls.Add(Me.tbpListar)
        Me.tbcOtrosPagos.Controls.Add(Me.tbpNuevo)
        Me.tbcOtrosPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcOtrosPagos.Location = New System.Drawing.Point(0, 35)
        Me.tbcOtrosPagos.Name = "tbcOtrosPagos"
        Me.tbcOtrosPagos.SelectedIndex = 0
        Me.tbcOtrosPagos.Size = New System.Drawing.Size(803, 430)
        Me.tbcOtrosPagos.TabIndex = 88
        '
        'tbpListar
        '
        Me.tbpListar.Controls.Add(Me.txtBusqueda)
        Me.tbpListar.Controls.Add(Me.btnModificar)
        Me.tbpListar.Controls.Add(Me.btnNuevo)
        Me.tbpListar.Controls.Add(Me.dgvPagoDctoBasico)
        Me.tbpListar.Location = New System.Drawing.Point(4, 22)
        Me.tbpListar.Name = "tbpListar"
        Me.tbpListar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpListar.Size = New System.Drawing.Size(795, 404)
        Me.tbpListar.TabIndex = 0
        Me.tbpListar.Text = "Listar"
        Me.tbpListar.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BackColor = System.Drawing.SystemColors.Window
        Me.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqueda.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(6, 6)
        Me.txtBusqueda.MaxLength = 350
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(257, 25)
        Me.txtBusqueda.TabIndex = 1
        Me.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.BackColor = System.Drawing.Color.White
        Me.btnModificar.Image = Global.Planilla.Client.Desktop.My.Resources.Resources.page_edit
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(154, 366)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(140, 30)
        Me.btnModificar.TabIndex = 4
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackColor = System.Drawing.Color.White
        Me.btnNuevo.Image = Global.Planilla.Client.Desktop.My.Resources.Resources.page_add
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(7, 366)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(140, 30)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
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
        Me.dgvPagoDctoBasico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProcedimiento, Me.CodPro, Me.TipPro, Me.Procedimiento, Me.IdEspecialidad, Me.CodEsp, Me.PrecioProcedimiento, Me.MontoMedico, Me.Observacion, Me.ProImprimir, Me.AreaLaboratorio})
        Me.dgvPagoDctoBasico.EnableHeadersVisualStyles = False
        Me.dgvPagoDctoBasico.Location = New System.Drawing.Point(7, 33)
        Me.dgvPagoDctoBasico.Name = "dgvPagoDctoBasico"
        Me.dgvPagoDctoBasico.ReadOnly = True
        Me.dgvPagoDctoBasico.RowHeadersVisible = False
        Me.dgvPagoDctoBasico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagoDctoBasico.Size = New System.Drawing.Size(780, 327)
        Me.dgvPagoDctoBasico.TabIndex = 2
        '
        'IdProcedimiento
        '
        Me.IdProcedimiento.HeaderText = "IdProcedimiento"
        Me.IdProcedimiento.Name = "IdProcedimiento"
        Me.IdProcedimiento.ReadOnly = True
        Me.IdProcedimiento.Visible = False
        '
        'CodPro
        '
        Me.CodPro.HeaderText = "CodPro"
        Me.CodPro.Name = "CodPro"
        Me.CodPro.ReadOnly = True
        Me.CodPro.Width = 60
        '
        'TipPro
        '
        Me.TipPro.HeaderText = "TipPro"
        Me.TipPro.Name = "TipPro"
        Me.TipPro.ReadOnly = True
        Me.TipPro.Width = 50
        '
        'Procedimiento
        '
        Me.Procedimiento.HeaderText = "Procedimiento"
        Me.Procedimiento.Name = "Procedimiento"
        Me.Procedimiento.ReadOnly = True
        Me.Procedimiento.Width = 200
        '
        'IdEspecialidad
        '
        Me.IdEspecialidad.HeaderText = "IdEspecialidad"
        Me.IdEspecialidad.Name = "IdEspecialidad"
        Me.IdEspecialidad.ReadOnly = True
        Me.IdEspecialidad.Visible = False
        '
        'CodEsp
        '
        Me.CodEsp.HeaderText = "CodEsp"
        Me.CodEsp.Name = "CodEsp"
        Me.CodEsp.ReadOnly = True
        Me.CodEsp.Width = 50
        '
        'PrecioProcedimiento
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.PrecioProcedimiento.DefaultCellStyle = DataGridViewCellStyle9
        Me.PrecioProcedimiento.HeaderText = "PrecioProce"
        Me.PrecioProcedimiento.Name = "PrecioProcedimiento"
        Me.PrecioProcedimiento.ReadOnly = True
        Me.PrecioProcedimiento.Width = 70
        '
        'MontoMedico
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.MontoMedico.DefaultCellStyle = DataGridViewCellStyle10
        Me.MontoMedico.HeaderText = "MontoMed"
        Me.MontoMedico.Name = "MontoMedico"
        Me.MontoMedico.ReadOnly = True
        Me.MontoMedico.Width = 70
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.Width = 150
        '
        'ProImprimir
        '
        Me.ProImprimir.HeaderText = "ProImprimir"
        Me.ProImprimir.Name = "ProImprimir"
        Me.ProImprimir.ReadOnly = True
        Me.ProImprimir.Width = 150
        '
        'AreaLaboratorio
        '
        Me.AreaLaboratorio.HeaderText = "AreaLaboratorio"
        Me.AreaLaboratorio.Name = "AreaLaboratorio"
        Me.AreaLaboratorio.ReadOnly = True
        '
        'tbpNuevo
        '
        Me.tbpNuevo.Controls.Add(Me.grpManagement)
        Me.tbpNuevo.Controls.Add(Me.grpAccion)
        Me.tbpNuevo.Location = New System.Drawing.Point(4, 22)
        Me.tbpNuevo.Name = "tbpNuevo"
        Me.tbpNuevo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpNuevo.Size = New System.Drawing.Size(795, 404)
        Me.tbpNuevo.TabIndex = 1
        Me.tbpNuevo.Text = "Nuevo"
        Me.tbpNuevo.UseVisualStyleBackColor = True
        '
        'grpManagement
        '
        Me.grpManagement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpManagement.Controls.Add(Me.cmbAreaLaboratorio)
        Me.grpManagement.Controls.Add(Me.Label6)
        Me.grpManagement.Controls.Add(Me.cmbConsultaPro)
        Me.grpManagement.Controls.Add(Me.Label5)
        Me.grpManagement.Controls.Add(Me.txtObservacion)
        Me.grpManagement.Controls.Add(Me.Label3)
        Me.grpManagement.Controls.Add(Me.txtNombreCorto)
        Me.grpManagement.Controls.Add(Me.cmbEspecialidad)
        Me.grpManagement.Controls.Add(Me.Label2)
        Me.grpManagement.Controls.Add(Me.Label1)
        Me.grpManagement.Controls.Add(Me.txtMontoMedico)
        Me.grpManagement.Controls.Add(Me.Label14)
        Me.grpManagement.Controls.Add(Me.Label8)
        Me.grpManagement.Controls.Add(Me.txtProcedimiento)
        Me.grpManagement.Controls.Add(Me.Label4)
        Me.grpManagement.Controls.Add(Me.txtCodigo)
        Me.grpManagement.Controls.Add(Me.txtPrecioProcedimiento)
        Me.grpManagement.Controls.Add(Me.Label9)
        Me.grpManagement.Location = New System.Drawing.Point(3, 6)
        Me.grpManagement.Name = "grpManagement"
        Me.grpManagement.Size = New System.Drawing.Size(782, 325)
        Me.grpManagement.TabIndex = 4
        Me.grpManagement.TabStop = False
        '
        'cmbAreaLaboratorio
        '
        Me.cmbAreaLaboratorio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbAreaLaboratorio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAreaLaboratorio.FormattingEnabled = True
        Me.cmbAreaLaboratorio.Location = New System.Drawing.Point(174, 149)
        Me.cmbAreaLaboratorio.Name = "cmbAreaLaboratorio"
        Me.cmbAreaLaboratorio.Size = New System.Drawing.Size(352, 21)
        Me.cmbAreaLaboratorio.TabIndex = 129
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(66, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 15)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Area Laboratorio"
        '
        'cmbConsultaPro
        '
        Me.cmbConsultaPro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbConsultaPro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbConsultaPro.FormattingEnabled = True
        Me.cmbConsultaPro.Location = New System.Drawing.Point(174, 93)
        Me.cmbConsultaPro.Name = "cmbConsultaPro"
        Me.cmbConsultaPro.Size = New System.Drawing.Size(167, 21)
        Me.cmbConsultaPro.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(84, 280)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 15)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(174, 276)
        Me.txtObservacion.MaxLength = 350
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(576, 25)
        Me.txtObservacion.TabIndex = 12
        Me.txtObservacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Nombre Corto"
        '
        'txtNombreCorto
        '
        Me.txtNombreCorto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtNombreCorto.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombreCorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreCorto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCorto.Location = New System.Drawing.Point(174, 245)
        Me.txtNombreCorto.MaxLength = 350
        Me.txtNombreCorto.Name = "txtNombreCorto"
        Me.txtNombreCorto.Size = New System.Drawing.Size(352, 25)
        Me.txtNombreCorto.TabIndex = 11
        Me.txtNombreCorto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbEspecialidad
        '
        Me.cmbEspecialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbEspecialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEspecialidad.FormattingEnabled = True
        Me.cmbEspecialidad.Location = New System.Drawing.Point(174, 122)
        Me.cmbEspecialidad.Name = "cmbEspecialidad"
        Me.cmbEspecialidad.Size = New System.Drawing.Size(352, 21)
        Me.cmbEspecialidad.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(91, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Especialidad"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Precio Procedimiento"
        '
        'txtMontoMedico
        '
        Me.txtMontoMedico.AccessibleName = "Money"
        Me.txtMontoMedico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMontoMedico.BackColor = System.Drawing.SystemColors.Window
        Me.txtMontoMedico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoMedico.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoMedico.Location = New System.Drawing.Point(174, 214)
        Me.txtMontoMedico.MaxLength = 350
        Me.txtMontoMedico.Name = "txtMontoMedico"
        Me.txtMontoMedico.Size = New System.Drawing.Size(106, 25)
        Me.txtMontoMedico.TabIndex = 10
        Me.txtMontoMedico.Text = "0.00"
        Me.txtMontoMedico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(84, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 109
        Me.Label14.Text = "Monto Médico"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(76, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 15)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Procedimiento"
        '
        'txtProcedimiento
        '
        Me.txtProcedimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtProcedimiento.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcedimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcedimiento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcedimiento.Location = New System.Drawing.Point(176, 52)
        Me.txtProcedimiento.MaxLength = 350
        Me.txtProcedimiento.Name = "txtProcedimiento"
        Me.txtProcedimiento.Size = New System.Drawing.Size(352, 25)
        Me.txtProcedimiento.TabIndex = 6
        Me.txtProcedimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(110, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(176, 21)
        Me.txtCodigo.MaxLength = 350
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(87, 25)
        Me.txtCodigo.TabIndex = 5
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecioProcedimiento
        '
        Me.txtPrecioProcedimiento.AccessibleName = "Money"
        Me.txtPrecioProcedimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtPrecioProcedimiento.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecioProcedimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioProcedimiento.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioProcedimiento.Location = New System.Drawing.Point(174, 183)
        Me.txtPrecioProcedimiento.MaxLength = 350
        Me.txtPrecioProcedimiento.Name = "txtPrecioProcedimiento"
        Me.txtPrecioProcedimiento.Size = New System.Drawing.Size(106, 25)
        Me.txtPrecioProcedimiento.TabIndex = 9
        Me.txtPrecioProcedimiento.Text = "0.00"
        Me.txtPrecioProcedimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Consulta/Procedimiento"
        '
        'grpAccion
        '
        Me.grpAccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAccion.Controls.Add(Me.btnCancelar)
        Me.grpAccion.Controls.Add(Me.btnGuardar)
        Me.grpAccion.Location = New System.Drawing.Point(3, 337)
        Me.grpAccion.Name = "grpAccion"
        Me.grpAccion.Size = New System.Drawing.Size(782, 61)
        Me.grpAccion.TabIndex = 3
        Me.grpAccion.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(392, 22)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(143, 30)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(245, 22)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(143, 30)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmProcedimientoLaboratorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 465)
        Me.Controls.Add(Me.tbcOtrosPagos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmProcedimientoLaboratorio"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbcOtrosPagos.ResumeLayout(False)
        Me.tbpListar.ResumeLayout(False)
        Me.tbpListar.PerformLayout()
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpNuevo.ResumeLayout(False)
        Me.grpManagement.ResumeLayout(False)
        Me.grpManagement.PerformLayout()
        Me.grpAccion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents tbcOtrosPagos As TabControl
    Friend WithEvents tbpListar As TabPage
    Friend WithEvents txtBusqueda As TextBox
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvPagoDctoBasico As DataGridView
    Friend WithEvents IdProcedimiento As DataGridViewTextBoxColumn
    Friend WithEvents CodPro As DataGridViewTextBoxColumn
    Friend WithEvents TipPro As DataGridViewTextBoxColumn
    Friend WithEvents Procedimiento As DataGridViewTextBoxColumn
    Friend WithEvents IdEspecialidad As DataGridViewTextBoxColumn
    Friend WithEvents CodEsp As DataGridViewTextBoxColumn
    Friend WithEvents PrecioProcedimiento As DataGridViewTextBoxColumn
    Friend WithEvents MontoMedico As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents ProImprimir As DataGridViewTextBoxColumn
    Friend WithEvents AreaLaboratorio As DataGridViewTextBoxColumn
    Friend WithEvents tbpNuevo As TabPage
    Friend WithEvents grpManagement As GroupBox
    Friend WithEvents cmbAreaLaboratorio As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbConsultaPro As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombreCorto As TextBox
    Friend WithEvents cmbEspecialidad As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMontoMedico As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtProcedimiento As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtPrecioProcedimiento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents grpAccion As GroupBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
End Class
