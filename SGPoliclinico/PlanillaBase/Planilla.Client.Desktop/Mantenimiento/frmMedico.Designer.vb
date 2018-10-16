<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedico
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.tbcOtrosPagos = New System.Windows.Forms.TabControl()
        Me.tbpListar = New System.Windows.Forms.TabPage()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvPagoDctoBasico = New System.Windows.Forms.DataGridView()
        Me.IdMedico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApePaterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApeMaterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodDis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecNac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RNE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEsp1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEsp2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpNuevo = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtCodPer = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpFecIngreso = New System.Windows.Forms.DateTimePicker()
        Me.cmbDistrito = New System.Windows.Forms.ComboBox()
        Me.txtRUC = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFecNac = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpAccion = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grpRemuneracion = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNroColegiatura = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtRNE = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbSituacionEspecialidad = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbEspecialidad2 = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbEspecialidad1 = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.tbcOtrosPagos.SuspendLayout()
        Me.tbpListar.SuspendLayout()
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpNuevo.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpDatos.SuspendLayout()
        Me.grpAccion.SuspendLayout()
        Me.grpRemuneracion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(971, 30)
        Me.Panel1.TabIndex = 85
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(5, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(214, 25)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Mantenimiento Médico"
        '
        'tbcOtrosPagos
        '
        Me.tbcOtrosPagos.Controls.Add(Me.tbpListar)
        Me.tbcOtrosPagos.Controls.Add(Me.tbpNuevo)
        Me.tbcOtrosPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcOtrosPagos.Location = New System.Drawing.Point(0, 30)
        Me.tbcOtrosPagos.Name = "tbcOtrosPagos"
        Me.tbcOtrosPagos.SelectedIndex = 0
        Me.tbcOtrosPagos.Size = New System.Drawing.Size(971, 524)
        Me.tbcOtrosPagos.TabIndex = 86
        '
        'tbpListar
        '
        Me.tbpListar.Controls.Add(Me.btnExcel)
        Me.tbpListar.Controls.Add(Me.btnModificar)
        Me.tbpListar.Controls.Add(Me.btnNuevo)
        Me.tbpListar.Controls.Add(Me.dgvPagoDctoBasico)
        Me.tbpListar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpListar.Location = New System.Drawing.Point(4, 22)
        Me.tbpListar.Name = "tbpListar"
        Me.tbpListar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpListar.Size = New System.Drawing.Size(963, 498)
        Me.tbpListar.TabIndex = 0
        Me.tbpListar.Text = "Listar"
        Me.tbpListar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.White
        Me.btnExcel.Image = Global.Planilla.Client.Desktop.My.Resources.Resources.page_excel
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(835, 464)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(120, 26)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.Text = "&Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.BackColor = System.Drawing.Color.White
        Me.btnModificar.Image = Global.Planilla.Client.Desktop.My.Resources.Resources.page_edit
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(129, 464)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(120, 26)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackColor = System.Drawing.Color.White
        Me.btnNuevo.Image = Global.Planilla.Client.Desktop.My.Resources.Resources.page_add
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(3, 464)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(120, 26)
        Me.btnNuevo.TabIndex = 2
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
        Me.dgvPagoDctoBasico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdMedico, Me.CodMed, Me.ApePaterno, Me.ApeMaterno, Me.Nombre, Me.Direccion, Me.CodDis, Me.FecNac, Me.Cel, Me.Email, Me.RUC, Me.FecIngreso, Me.Grado, Me.NumCol, Me.Sit, Me.RNE, Me.CodEsp1, Me.CodEsp2, Me.Estado, Me.Tipo})
        Me.dgvPagoDctoBasico.EnableHeadersVisualStyles = False
        Me.dgvPagoDctoBasico.Location = New System.Drawing.Point(6, 29)
        Me.dgvPagoDctoBasico.MultiSelect = False
        Me.dgvPagoDctoBasico.Name = "dgvPagoDctoBasico"
        Me.dgvPagoDctoBasico.ReadOnly = True
        Me.dgvPagoDctoBasico.RowHeadersVisible = False
        Me.dgvPagoDctoBasico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagoDctoBasico.Size = New System.Drawing.Size(952, 428)
        Me.dgvPagoDctoBasico.TabIndex = 1
        '
        'IdMedico
        '
        Me.IdMedico.Frozen = True
        Me.IdMedico.HeaderText = "IdMedico"
        Me.IdMedico.Name = "IdMedico"
        Me.IdMedico.ReadOnly = True
        Me.IdMedico.Visible = False
        '
        'CodMed
        '
        Me.CodMed.Frozen = True
        Me.CodMed.HeaderText = "CodMed"
        Me.CodMed.Name = "CodMed"
        Me.CodMed.ReadOnly = True
        Me.CodMed.Width = 60
        '
        'ApePaterno
        '
        Me.ApePaterno.Frozen = True
        Me.ApePaterno.HeaderText = "ApePaterno"
        Me.ApePaterno.Name = "ApePaterno"
        Me.ApePaterno.ReadOnly = True
        '
        'ApeMaterno
        '
        Me.ApeMaterno.Frozen = True
        Me.ApeMaterno.HeaderText = "ApeMaterno"
        Me.ApeMaterno.Name = "ApeMaterno"
        Me.ApeMaterno.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.Frozen = True
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Direccion
        '
        Me.Direccion.HeaderText = "Dirección"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        Me.Direccion.Width = 150
        '
        'CodDis
        '
        Me.CodDis.HeaderText = "CodDis"
        Me.CodDis.Name = "CodDis"
        Me.CodDis.ReadOnly = True
        Me.CodDis.Width = 60
        '
        'FecNac
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "d"
        Me.FecNac.DefaultCellStyle = DataGridViewCellStyle1
        Me.FecNac.HeaderText = "FecNac"
        Me.FecNac.Name = "FecNac"
        Me.FecNac.ReadOnly = True
        '
        'Cel
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cel.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cel.HeaderText = "Cel"
        Me.Cel.Name = "Cel"
        Me.Cel.ReadOnly = True
        Me.Cel.Width = 75
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 120
        '
        'RUC
        '
        Me.RUC.HeaderText = "RUC"
        Me.RUC.Name = "RUC"
        Me.RUC.ReadOnly = True
        Me.RUC.Width = 40
        '
        'FecIngreso
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        Me.FecIngreso.DefaultCellStyle = DataGridViewCellStyle3
        Me.FecIngreso.HeaderText = "FecIngreso"
        Me.FecIngreso.Name = "FecIngreso"
        Me.FecIngreso.ReadOnly = True
        Me.FecIngreso.Width = 80
        '
        'Grado
        '
        Me.Grado.HeaderText = "Grado"
        Me.Grado.Name = "Grado"
        Me.Grado.ReadOnly = True
        Me.Grado.Width = 55
        '
        'NumCol
        '
        Me.NumCol.HeaderText = "NumCol"
        Me.NumCol.Name = "NumCol"
        Me.NumCol.ReadOnly = True
        Me.NumCol.Width = 50
        '
        'Sit
        '
        Me.Sit.HeaderText = "Sit"
        Me.Sit.Name = "Sit"
        Me.Sit.ReadOnly = True
        Me.Sit.Width = 55
        '
        'RNE
        '
        Me.RNE.HeaderText = "RNE"
        Me.RNE.Name = "RNE"
        Me.RNE.ReadOnly = True
        Me.RNE.Width = 45
        '
        'CodEsp1
        '
        Me.CodEsp1.HeaderText = "CodEsp1"
        Me.CodEsp1.Name = "CodEsp1"
        Me.CodEsp1.ReadOnly = True
        Me.CodEsp1.Width = 45
        '
        'CodEsp2
        '
        Me.CodEsp2.HeaderText = "CodEsp2"
        Me.CodEsp2.Name = "CodEsp2"
        Me.CodEsp2.ReadOnly = True
        Me.CodEsp2.Width = 45
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 55
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 55
        '
        'tbpNuevo
        '
        Me.tbpNuevo.Controls.Add(Me.TableLayoutPanel1)
        Me.tbpNuevo.Location = New System.Drawing.Point(4, 22)
        Me.tbpNuevo.Name = "tbpNuevo"
        Me.tbpNuevo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpNuevo.Size = New System.Drawing.Size(963, 498)
        Me.tbpNuevo.TabIndex = 1
        Me.tbpNuevo.Text = "Nuevo"
        Me.tbpNuevo.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpDatos, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grpAccion, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpRemuneracion, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(957, 492)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'grpDatos
        '
        Me.grpDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDatos.Controls.Add(Me.txtCodPer)
        Me.grpDatos.Controls.Add(Me.Label15)
        Me.grpDatos.Controls.Add(Me.dtpFecIngreso)
        Me.grpDatos.Controls.Add(Me.cmbDistrito)
        Me.grpDatos.Controls.Add(Me.txtRUC)
        Me.grpDatos.Controls.Add(Me.Label13)
        Me.grpDatos.Controls.Add(Me.txtEmail)
        Me.grpDatos.Controls.Add(Me.Label12)
        Me.grpDatos.Controls.Add(Me.txtCelular)
        Me.grpDatos.Controls.Add(Me.Label11)
        Me.grpDatos.Controls.Add(Me.txtTelefono)
        Me.grpDatos.Controls.Add(Me.Label10)
        Me.grpDatos.Controls.Add(Me.Label7)
        Me.grpDatos.Controls.Add(Me.dtpFecNac)
        Me.grpDatos.Controls.Add(Me.Label6)
        Me.grpDatos.Controls.Add(Me.txtDireccion)
        Me.grpDatos.Controls.Add(Me.Label3)
        Me.grpDatos.Controls.Add(Me.txtNombres)
        Me.grpDatos.Controls.Add(Me.Label2)
        Me.grpDatos.Controls.Add(Me.txtApellidoMaterno)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.txtApellidoPaterno)
        Me.grpDatos.Controls.Add(Me.txtDni)
        Me.grpDatos.Controls.Add(Me.Label5)
        Me.grpDatos.Location = New System.Drawing.Point(3, 3)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(951, 215)
        Me.grpDatos.TabIndex = 2
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Documento"
        '
        'txtCodPer
        '
        Me.txtCodPer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtCodPer.BackColor = System.Drawing.SystemColors.Menu
        Me.txtCodPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodPer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPer.Location = New System.Drawing.Point(122, 20)
        Me.txtCodPer.MaxLength = 350
        Me.txtCodPer.Name = "txtCodPer"
        Me.txtCodPer.ReadOnly = True
        Me.txtCodPer.Size = New System.Drawing.Size(122, 25)
        Me.txtCodPer.TabIndex = 5
        Me.txtCodPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(679, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 15)
        Me.Label15.TabIndex = 135
        Me.Label15.Text = "Fec. Ingreso"
        '
        'dtpFecIngreso
        '
        Me.dtpFecIngreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.dtpFecIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIngreso.Location = New System.Drawing.Point(755, 83)
        Me.dtpFecIngreso.Name = "dtpFecIngreso"
        Me.dtpFecIngreso.Size = New System.Drawing.Size(110, 20)
        Me.dtpFecIngreso.TabIndex = 17
        '
        'cmbDistrito
        '
        Me.cmbDistrito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbDistrito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDistrito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(633, 180)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(233, 21)
        Me.cmbDistrito.TabIndex = 15
        '
        'txtRUC
        '
        Me.txtRUC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtRUC.BackColor = System.Drawing.SystemColors.Window
        Me.txtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRUC.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUC.Location = New System.Drawing.Point(755, 50)
        Me.txtRUC.MaxLength = 11
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(111, 25)
        Me.txtRUC.TabIndex = 16
        Me.txtRUC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(684, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 15)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "RUC"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(409, 143)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(222, 25)
        Me.txtEmail.TabIndex = 14
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(362, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 15)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "E-mail"
        '
        'txtCelular
        '
        Me.txtCelular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtCelular.BackColor = System.Drawing.SystemColors.Window
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelular.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(409, 112)
        Me.txtCelular.MaxLength = 15
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(122, 25)
        Me.txtCelular.TabIndex = 13
        Me.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(359, 116)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 15)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Celular"
        '
        'txtTelefono
        '
        Me.txtTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Window
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(409, 81)
        Me.txtTelefono.MaxLength = 15
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(122, 25)
        Me.txtTelefono.TabIndex = 12
        Me.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(350, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 15)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Teléfono"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(334, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 15)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Fec. Nacim."
        '
        'dtpFecNac
        '
        Me.dtpFecNac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.dtpFecNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecNac.Location = New System.Drawing.Point(409, 50)
        Me.dtpFecNac.Name = "dtpFecNac"
        Me.dtpFecNac.Size = New System.Drawing.Size(110, 20)
        Me.dtpFecNac.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(122, 180)
        Me.txtDireccion.MaxLength = 100
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(502, 25)
        Me.txtDireccion.TabIndex = 10
        Me.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Nombres"
        '
        'txtNombres
        '
        Me.txtNombres.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtNombres.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.Location = New System.Drawing.Point(122, 143)
        Me.txtNombres.MaxLength = 60
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(197, 25)
        Me.txtNombres.TabIndex = 9
        Me.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Ap. Paterno"
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtApellidoMaterno.BackColor = System.Drawing.SystemColors.Window
        Me.txtApellidoMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidoMaterno.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(122, 112)
        Me.txtApellidoMaterno.MaxLength = 60
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(197, 25)
        Me.txtApellidoMaterno.TabIndex = 8
        Me.txtApellidoMaterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Ap. Paterno"
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtApellidoPaterno.BackColor = System.Drawing.SystemColors.Window
        Me.txtApellidoPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidoPaterno.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(122, 81)
        Me.txtApellidoPaterno.MaxLength = 60
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(197, 25)
        Me.txtApellidoPaterno.TabIndex = 7
        Me.txtApellidoPaterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDni
        '
        Me.txtDni.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtDni.BackColor = System.Drawing.SystemColors.Window
        Me.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDni.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDni.Location = New System.Drawing.Point(122, 50)
        Me.txtDni.MaxLength = 8
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(122, 25)
        Me.txtDni.TabIndex = 6
        Me.txtDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(80, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 15)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Dni"
        '
        'grpAccion
        '
        Me.grpAccion.Controls.Add(Me.btnCancelar)
        Me.grpAccion.Controls.Add(Me.btnGuardar)
        Me.grpAccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpAccion.Location = New System.Drawing.Point(3, 445)
        Me.grpAccion.Name = "grpAccion"
        Me.grpAccion.Size = New System.Drawing.Size(951, 44)
        Me.grpAccion.TabIndex = 3
        Me.grpAccion.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(493, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 25)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(367, 14)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(118, 25)
        Me.btnGuardar.TabIndex = 28
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'grpRemuneracion
        '
        Me.grpRemuneracion.Controls.Add(Me.Label17)
        Me.grpRemuneracion.Controls.Add(Me.txtNroColegiatura)
        Me.grpRemuneracion.Controls.Add(Me.Label16)
        Me.grpRemuneracion.Controls.Add(Me.cmbGrado)
        Me.grpRemuneracion.Controls.Add(Me.Label28)
        Me.grpRemuneracion.Controls.Add(Me.cmbEstado)
        Me.grpRemuneracion.Controls.Add(Me.txtRNE)
        Me.grpRemuneracion.Controls.Add(Me.Label22)
        Me.grpRemuneracion.Controls.Add(Me.Label21)
        Me.grpRemuneracion.Controls.Add(Me.cmbTipo)
        Me.grpRemuneracion.Controls.Add(Me.Label20)
        Me.grpRemuneracion.Controls.Add(Me.cmbSituacionEspecialidad)
        Me.grpRemuneracion.Controls.Add(Me.Label19)
        Me.grpRemuneracion.Controls.Add(Me.cmbEspecialidad2)
        Me.grpRemuneracion.Controls.Add(Me.Label18)
        Me.grpRemuneracion.Controls.Add(Me.cmbEspecialidad1)
        Me.grpRemuneracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpRemuneracion.Location = New System.Drawing.Point(3, 224)
        Me.grpRemuneracion.Name = "grpRemuneracion"
        Me.grpRemuneracion.Size = New System.Drawing.Size(951, 215)
        Me.grpRemuneracion.TabIndex = 5
        Me.grpRemuneracion.TabStop = False
        Me.grpRemuneracion.Text = "Remuneración"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(389, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 15)
        Me.Label17.TabIndex = 142
        Me.Label17.Text = "N. Colegiatura"
        '
        'txtNroColegiatura
        '
        Me.txtNroColegiatura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtNroColegiatura.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroColegiatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroColegiatura.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroColegiatura.Location = New System.Drawing.Point(478, 57)
        Me.txtNroColegiatura.MaxLength = 350
        Me.txtNroColegiatura.Name = "txtNroColegiatura"
        Me.txtNroColegiatura.Size = New System.Drawing.Size(52, 25)
        Me.txtNroColegiatura.TabIndex = 26
        Me.txtNroColegiatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(427, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 15)
        Me.Label16.TabIndex = 141
        Me.Label16.Text = "Grado"
        '
        'cmbGrado
        '
        Me.cmbGrado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbGrado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbGrado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGrado.FormattingEnabled = True
        Me.cmbGrado.Location = New System.Drawing.Point(478, 32)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(154, 21)
        Me.cmbGrado.TabIndex = 25
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(430, 128)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(42, 15)
        Me.Label28.TabIndex = 152
        Me.Label28.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(478, 126)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(110, 21)
        Me.cmbEstado.TabIndex = 27
        '
        'txtRNE
        '
        Me.txtRNE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtRNE.BackColor = System.Drawing.SystemColors.Window
        Me.txtRNE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRNE.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRNE.Location = New System.Drawing.Point(122, 157)
        Me.txtRNE.MaxLength = 350
        Me.txtRNE.Name = "txtRNE"
        Me.txtRNE.Size = New System.Drawing.Size(122, 25)
        Me.txtRNE.TabIndex = 24
        Me.txtRNE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(75, 162)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 15)
        Me.Label22.TabIndex = 140
        Me.Label22.Text = "RNE"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(74, 128)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 15)
        Me.Label21.TabIndex = 138
        Me.Label21.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(124, 126)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(154, 21)
        Me.cmbTipo.TabIndex = 23
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(28, 99)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 15)
        Me.Label20.TabIndex = 136
        Me.Label20.Text = "Situación Esp."
        '
        'cmbSituacionEspecialidad
        '
        Me.cmbSituacionEspecialidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbSituacionEspecialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSituacionEspecialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSituacionEspecialidad.FormattingEnabled = True
        Me.cmbSituacionEspecialidad.Location = New System.Drawing.Point(124, 95)
        Me.cmbSituacionEspecialidad.Name = "cmbSituacionEspecialidad"
        Me.cmbSituacionEspecialidad.Size = New System.Drawing.Size(154, 21)
        Me.cmbSituacionEspecialidad.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(27, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(81, 15)
        Me.Label19.TabIndex = 134
        Me.Label19.Text = "Especialidad 2"
        '
        'cmbEspecialidad2
        '
        Me.cmbEspecialidad2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbEspecialidad2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbEspecialidad2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEspecialidad2.FormattingEnabled = True
        Me.cmbEspecialidad2.Location = New System.Drawing.Point(124, 64)
        Me.cmbEspecialidad2.Name = "cmbEspecialidad2"
        Me.cmbEspecialidad2.Size = New System.Drawing.Size(233, 21)
        Me.cmbEspecialidad2.TabIndex = 21
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(29, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 15)
        Me.Label18.TabIndex = 132
        Me.Label18.Text = "Especialidad 1 "
        '
        'cmbEspecialidad1
        '
        Me.cmbEspecialidad1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.cmbEspecialidad1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbEspecialidad1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEspecialidad1.FormattingEnabled = True
        Me.cmbEspecialidad1.Location = New System.Drawing.Point(124, 33)
        Me.cmbEspecialidad1.Name = "cmbEspecialidad1"
        Me.cmbEspecialidad1.Size = New System.Drawing.Size(233, 21)
        Me.cmbEspecialidad1.TabIndex = 20
        '
        'frmMedico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 554)
        Me.Controls.Add(Me.tbcOtrosPagos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMedico"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tbcOtrosPagos.ResumeLayout(False)
        Me.tbpListar.ResumeLayout(False)
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpNuevo.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.grpAccion.ResumeLayout(False)
        Me.grpRemuneracion.ResumeLayout(False)
        Me.grpRemuneracion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents tbcOtrosPagos As TabControl
    Friend WithEvents tbpListar As TabPage
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvPagoDctoBasico As DataGridView
    Friend WithEvents tbpNuevo As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents txtCodPer As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents dtpFecIngreso As DateTimePicker
    Friend WithEvents cmbDistrito As ComboBox
    Friend WithEvents txtRUC As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFecNac As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtApellidoMaterno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtApellidoPaterno As TextBox
    Friend WithEvents txtDni As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents grpAccion As GroupBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents grpRemuneracion As GroupBox
    Friend WithEvents Label28 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents txtRNE As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbSituacionEspecialidad As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbEspecialidad2 As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbEspecialidad1 As ComboBox
    Friend WithEvents txtNroColegiatura As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbGrado As ComboBox
    Friend WithEvents IdMedico As DataGridViewTextBoxColumn
    Friend WithEvents CodMed As DataGridViewTextBoxColumn
    Friend WithEvents ApePaterno As DataGridViewTextBoxColumn
    Friend WithEvents ApeMaterno As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Direccion As DataGridViewTextBoxColumn
    Friend WithEvents CodDis As DataGridViewTextBoxColumn
    Friend WithEvents FecNac As DataGridViewTextBoxColumn
    Friend WithEvents Cel As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents RUC As DataGridViewTextBoxColumn
    Friend WithEvents FecIngreso As DataGridViewTextBoxColumn
    Friend WithEvents Grado As DataGridViewTextBoxColumn
    Friend WithEvents NumCol As DataGridViewTextBoxColumn
    Friend WithEvents Sit As DataGridViewTextBoxColumn
    Friend WithEvents RNE As DataGridViewTextBoxColumn
    Friend WithEvents CodEsp1 As DataGridViewTextBoxColumn
    Friend WithEvents CodEsp2 As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
End Class
