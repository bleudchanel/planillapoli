<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFondoPensiones
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.tbcOtrosPagos = New System.Windows.Forms.TabControl()
        Me.tbpListar = New System.Windows.Forms.TabPage()
        Me.txtBusqueda = New System.Windows.Forms.TextBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvPagoDctoBasico = New System.Windows.Forms.DataGridView()
        Me.tbpNuevo = New System.Windows.Forms.TabPage()
        Me.grpManagement = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtONP = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMixtaPrimaSeg = New System.Windows.Forms.TextBox()
        Me.txtFlujoPrimaSeg = New System.Windows.Forms.TextBox()
        Me.txtMixtaComisionVar = New System.Windows.Forms.TextBox()
        Me.txtFlujoComisionVar = New System.Windows.Forms.TextBox()
        Me.txtMixtaAporteOblig = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEntidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtFlujoAporteOblig = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpAccion = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cmbDistrito = New System.Windows.Forms.ComboBox()
        Me.txtSexo = New System.Windows.Forms.TextBox()
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
        Me.IdFondoPensiones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodFon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApoOblF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComVarF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriSegF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApoOblM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComVarM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriSegM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorONP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.tbcOtrosPagos.SuspendLayout()
        Me.tbpListar.SuspendLayout()
        CType(Me.dgvPagoDctoBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpNuevo.SuspendLayout()
        Me.grpManagement.SuspendLayout()
        Me.grpAccion.SuspendLayout()
        Me.grpDatos.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(827, 52)
        Me.Panel1.TabIndex = 88
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(17, 12)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(155, 25)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Fondo Pensiones"
        '
        'tbcOtrosPagos
        '
        Me.tbcOtrosPagos.Controls.Add(Me.tbpListar)
        Me.tbcOtrosPagos.Controls.Add(Me.tbpNuevo)
        Me.tbcOtrosPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcOtrosPagos.Location = New System.Drawing.Point(0, 52)
        Me.tbcOtrosPagos.Name = "tbcOtrosPagos"
        Me.tbcOtrosPagos.SelectedIndex = 0
        Me.tbcOtrosPagos.Size = New System.Drawing.Size(827, 410)
        Me.tbcOtrosPagos.TabIndex = 89
        '
        'tbpListar
        '
        Me.tbpListar.Controls.Add(Me.txtBusqueda)
        Me.tbpListar.Controls.Add(Me.btnModificar)
        Me.tbpListar.Controls.Add(Me.btnNuevo)
        Me.tbpListar.Controls.Add(Me.dgvPagoDctoBasico)
        Me.tbpListar.Location = New System.Drawing.Point(4, 24)
        Me.tbpListar.Name = "tbpListar"
        Me.tbpListar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpListar.Size = New System.Drawing.Size(819, 382)
        Me.tbpListar.TabIndex = 0
        Me.tbpListar.Text = "Listar"
        Me.tbpListar.UseVisualStyleBackColor = True
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BackColor = System.Drawing.SystemColors.Window
        Me.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqueda.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Location = New System.Drawing.Point(7, 7)
        Me.txtBusqueda.MaxLength = 350
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(299, 25)
        Me.txtBusqueda.TabIndex = 107
        Me.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.BackColor = System.Drawing.Color.White
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(180, 334)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(163, 35)
        Me.btnModificar.TabIndex = 37
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackColor = System.Drawing.Color.White
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(8, 334)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(163, 35)
        Me.btnNuevo.TabIndex = 36
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
        Me.dgvPagoDctoBasico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdFondoPensiones, Me.CodFon, Me.Entidad, Me.ApoOblF, Me.ComVarF, Me.PriSegF, Me.ApoOblM, Me.ComVarM, Me.PriSegM, Me.PorONP})
        Me.dgvPagoDctoBasico.EnableHeadersVisualStyles = False
        Me.dgvPagoDctoBasico.Location = New System.Drawing.Point(8, 38)
        Me.dgvPagoDctoBasico.MultiSelect = False
        Me.dgvPagoDctoBasico.Name = "dgvPagoDctoBasico"
        Me.dgvPagoDctoBasico.ReadOnly = True
        Me.dgvPagoDctoBasico.RowHeadersVisible = False
        Me.dgvPagoDctoBasico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagoDctoBasico.Size = New System.Drawing.Size(800, 289)
        Me.dgvPagoDctoBasico.TabIndex = 34
        '
        'tbpNuevo
        '
        Me.tbpNuevo.Controls.Add(Me.grpManagement)
        Me.tbpNuevo.Controls.Add(Me.grpAccion)
        Me.tbpNuevo.Controls.Add(Me.grpDatos)
        Me.tbpNuevo.Location = New System.Drawing.Point(4, 24)
        Me.tbpNuevo.Name = "tbpNuevo"
        Me.tbpNuevo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpNuevo.Size = New System.Drawing.Size(819, 382)
        Me.tbpNuevo.TabIndex = 1
        Me.tbpNuevo.Text = "Nuevo"
        Me.tbpNuevo.UseVisualStyleBackColor = True
        '
        'grpManagement
        '
        Me.grpManagement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpManagement.Controls.Add(Me.cmbEstado)
        Me.grpManagement.Controls.Add(Me.Label19)
        Me.grpManagement.Controls.Add(Me.txtONP)
        Me.grpManagement.Controls.Add(Me.Label18)
        Me.grpManagement.Controls.Add(Me.Label17)
        Me.grpManagement.Controls.Add(Me.Label16)
        Me.grpManagement.Controls.Add(Me.Label15)
        Me.grpManagement.Controls.Add(Me.txtMixtaPrimaSeg)
        Me.grpManagement.Controls.Add(Me.txtFlujoPrimaSeg)
        Me.grpManagement.Controls.Add(Me.txtMixtaComisionVar)
        Me.grpManagement.Controls.Add(Me.txtFlujoComisionVar)
        Me.grpManagement.Controls.Add(Me.txtMixtaAporteOblig)
        Me.grpManagement.Controls.Add(Me.Label14)
        Me.grpManagement.Controls.Add(Me.Label8)
        Me.grpManagement.Controls.Add(Me.txtEntidad)
        Me.grpManagement.Controls.Add(Me.Label4)
        Me.grpManagement.Controls.Add(Me.txtCodigo)
        Me.grpManagement.Controls.Add(Me.txtFlujoAporteOblig)
        Me.grpManagement.Controls.Add(Me.Label9)
        Me.grpManagement.Location = New System.Drawing.Point(3, 7)
        Me.grpManagement.Name = "grpManagement"
        Me.grpManagement.Size = New System.Drawing.Size(808, 303)
        Me.grpManagement.TabIndex = 4
        Me.grpManagement.TabStop = False
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(582, 126)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 15)
        Me.Label19.TabIndex = 120
        Me.Label19.Text = "% O.N.P."
        '
        'txtONP
        '
        Me.txtONP.AccessibleName = "Money4"
        Me.txtONP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtONP.BackColor = System.Drawing.SystemColors.Window
        Me.txtONP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtONP.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtONP.Location = New System.Drawing.Point(642, 122)
        Me.txtONP.MaxLength = 350
        Me.txtONP.Name = "txtONP"
        Me.txtONP.Size = New System.Drawing.Size(95, 25)
        Me.txtONP.TabIndex = 119
        Me.txtONP.Text = "0.0000"
        Me.txtONP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(155, 163)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 15)
        Me.Label18.TabIndex = 117
        Me.Label18.Text = "Mixta"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(142, 126)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 15)
        Me.Label17.TabIndex = 116
        Me.Label17.Text = "Por Flujo"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(441, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 13)
        Me.Label16.TabIndex = 115
        Me.Label16.Text = "Prima de Seguro"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(320, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Comisión Variable"
        '
        'txtMixtaPrimaSeg
        '
        Me.txtMixtaPrimaSeg.AccessibleName = "Money4"
        Me.txtMixtaPrimaSeg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMixtaPrimaSeg.BackColor = System.Drawing.SystemColors.Window
        Me.txtMixtaPrimaSeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMixtaPrimaSeg.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMixtaPrimaSeg.Location = New System.Drawing.Point(439, 157)
        Me.txtMixtaPrimaSeg.MaxLength = 350
        Me.txtMixtaPrimaSeg.Name = "txtMixtaPrimaSeg"
        Me.txtMixtaPrimaSeg.Size = New System.Drawing.Size(95, 25)
        Me.txtMixtaPrimaSeg.TabIndex = 113
        Me.txtMixtaPrimaSeg.Text = "0.0000"
        Me.txtMixtaPrimaSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFlujoPrimaSeg
        '
        Me.txtFlujoPrimaSeg.AccessibleName = "Money4"
        Me.txtFlujoPrimaSeg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtFlujoPrimaSeg.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlujoPrimaSeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFlujoPrimaSeg.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlujoPrimaSeg.Location = New System.Drawing.Point(439, 122)
        Me.txtFlujoPrimaSeg.MaxLength = 350
        Me.txtFlujoPrimaSeg.Name = "txtFlujoPrimaSeg"
        Me.txtFlujoPrimaSeg.Size = New System.Drawing.Size(95, 25)
        Me.txtFlujoPrimaSeg.TabIndex = 112
        Me.txtFlujoPrimaSeg.Text = "0.0000"
        Me.txtFlujoPrimaSeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMixtaComisionVar
        '
        Me.txtMixtaComisionVar.AccessibleName = "Money4"
        Me.txtMixtaComisionVar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMixtaComisionVar.BackColor = System.Drawing.SystemColors.Window
        Me.txtMixtaComisionVar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMixtaComisionVar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMixtaComisionVar.Location = New System.Drawing.Point(323, 157)
        Me.txtMixtaComisionVar.MaxLength = 350
        Me.txtMixtaComisionVar.Name = "txtMixtaComisionVar"
        Me.txtMixtaComisionVar.Size = New System.Drawing.Size(95, 25)
        Me.txtMixtaComisionVar.TabIndex = 111
        Me.txtMixtaComisionVar.Text = "0.0000"
        Me.txtMixtaComisionVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFlujoComisionVar
        '
        Me.txtFlujoComisionVar.AccessibleName = "Money4"
        Me.txtFlujoComisionVar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtFlujoComisionVar.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlujoComisionVar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFlujoComisionVar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlujoComisionVar.Location = New System.Drawing.Point(323, 122)
        Me.txtFlujoComisionVar.MaxLength = 350
        Me.txtFlujoComisionVar.Name = "txtFlujoComisionVar"
        Me.txtFlujoComisionVar.Size = New System.Drawing.Size(95, 25)
        Me.txtFlujoComisionVar.TabIndex = 110
        Me.txtFlujoComisionVar.Text = "0.0000"
        Me.txtFlujoComisionVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMixtaAporteOblig
        '
        Me.txtMixtaAporteOblig.AccessibleName = "Money4"
        Me.txtMixtaAporteOblig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMixtaAporteOblig.BackColor = System.Drawing.SystemColors.Window
        Me.txtMixtaAporteOblig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMixtaAporteOblig.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMixtaAporteOblig.Location = New System.Drawing.Point(207, 157)
        Me.txtMixtaAporteOblig.MaxLength = 350
        Me.txtMixtaAporteOblig.Name = "txtMixtaAporteOblig"
        Me.txtMixtaAporteOblig.Size = New System.Drawing.Size(95, 25)
        Me.txtMixtaAporteOblig.TabIndex = 108
        Me.txtMixtaAporteOblig.Text = "0.0000"
        Me.txtMixtaAporteOblig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(154, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 15)
        Me.Label14.TabIndex = 109
        Me.Label14.Text = "Estado"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(154, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Entidad"
        '
        'txtEntidad
        '
        Me.txtEntidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtEntidad.BackColor = System.Drawing.SystemColors.Window
        Me.txtEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntidad.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntidad.Location = New System.Drawing.Point(207, 53)
        Me.txtEntidad.MaxLength = 350
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.Size = New System.Drawing.Size(327, 25)
        Me.txtEntidad.TabIndex = 106
        Me.txtEntidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(155, 28)
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
        Me.txtCodigo.Location = New System.Drawing.Point(207, 22)
        Me.txtCodigo.MaxLength = 350
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(61, 25)
        Me.txtCodigo.TabIndex = 104
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFlujoAporteOblig
        '
        Me.txtFlujoAporteOblig.AccessibleName = "Money4"
        Me.txtFlujoAporteOblig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtFlujoAporteOblig.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlujoAporteOblig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFlujoAporteOblig.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlujoAporteOblig.Location = New System.Drawing.Point(207, 122)
        Me.txtFlujoAporteOblig.MaxLength = 350
        Me.txtFlujoAporteOblig.Name = "txtFlujoAporteOblig"
        Me.txtFlujoAporteOblig.Size = New System.Drawing.Size(95, 25)
        Me.txtFlujoAporteOblig.TabIndex = 18
        Me.txtFlujoAporteOblig.Text = "0.0000"
        Me.txtFlujoAporteOblig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(203, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Aporte Obligatorio"
        '
        'grpAccion
        '
        Me.grpAccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAccion.Controls.Add(Me.btnCancelar)
        Me.grpAccion.Controls.Add(Me.btnGuardar)
        Me.grpAccion.Location = New System.Drawing.Point(6, 309)
        Me.grpAccion.Name = "grpAccion"
        Me.grpAccion.Size = New System.Drawing.Size(808, 70)
        Me.grpAccion.TabIndex = 3
        Me.grpAccion.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(399, 22)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(167, 42)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "C&ancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGuardar.BackColor = System.Drawing.Color.White
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(228, 22)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(167, 42)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'grpDatos
        '
        Me.grpDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDatos.Controls.Add(Me.cmbDistrito)
        Me.grpDatos.Controls.Add(Me.txtSexo)
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
        Me.grpDatos.Location = New System.Drawing.Point(9, 18)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(516, 0)
        Me.grpDatos.TabIndex = 2
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Documento"
        '
        'cmbDistrito
        '
        Me.cmbDistrito.FormattingEnabled = True
        Me.cmbDistrito.Location = New System.Drawing.Point(741, 209)
        Me.cmbDistrito.Name = "cmbDistrito"
        Me.cmbDistrito.Size = New System.Drawing.Size(399, 23)
        Me.cmbDistrito.TabIndex = 120
        '
        'txtSexo
        '
        Me.txtSexo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSexo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSexo.Location = New System.Drawing.Point(978, 29)
        Me.txtSexo.MaxLength = 350
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.Size = New System.Drawing.Size(60, 25)
        Me.txtSexo.TabIndex = 118
        Me.txtSexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(885, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 15)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "Sexo (F/M)"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(547, 170)
        Me.txtEmail.MaxLength = 350
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(303, 25)
        Me.txtEmail.TabIndex = 116
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(456, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 15)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "E-mail"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.SystemColors.Window
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelular.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(547, 128)
        Me.txtCelular.MaxLength = 350
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(165, 25)
        Me.txtCelular.TabIndex = 114
        Me.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(456, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 15)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Celular"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Window
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(547, 87)
        Me.txtTelefono.MaxLength = 350
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(165, 25)
        Me.txtTelefono.TabIndex = 112
        Me.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(456, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 15)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Teléfono"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(442, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 15)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Fec. Nacim."
        '
        'dtpFecNac
        '
        Me.dtpFecNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecNac.Location = New System.Drawing.Point(547, 29)
        Me.dtpFecNac.Name = "dtpFecNac"
        Me.dtpFecNac.Size = New System.Drawing.Size(149, 23)
        Me.dtpFecNac.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(124, 210)
        Me.txtDireccion.MaxLength = 350
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(607, 25)
        Me.txtDireccion.TabIndex = 108
        Me.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Ap. Paterno"
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.Location = New System.Drawing.Point(124, 170)
        Me.txtNombres.MaxLength = 350
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(198, 25)
        Me.txtNombres.TabIndex = 106
        Me.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Ap. Paterno"
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.BackColor = System.Drawing.SystemColors.Window
        Me.txtApellidoMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidoMaterno.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(124, 128)
        Me.txtApellidoMaterno.MaxLength = 350
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(198, 25)
        Me.txtApellidoMaterno.TabIndex = 104
        Me.txtApellidoMaterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Ap. Paterno"
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.BackColor = System.Drawing.SystemColors.Window
        Me.txtApellidoPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidoPaterno.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(124, 87)
        Me.txtApellidoPaterno.MaxLength = 350
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(198, 25)
        Me.txtApellidoPaterno.TabIndex = 102
        Me.txtApellidoPaterno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDni
        '
        Me.txtDni.BackColor = System.Drawing.SystemColors.Window
        Me.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDni.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDni.Location = New System.Drawing.Point(124, 35)
        Me.txtDni.MaxLength = 350
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(165, 25)
        Me.txtDni.TabIndex = 11
        Me.txtDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(59, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 15)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "DNI"
        '
        'IdFondoPensiones
        '
        Me.IdFondoPensiones.HeaderText = "IdFondoPensiones"
        Me.IdFondoPensiones.Name = "IdFondoPensiones"
        Me.IdFondoPensiones.ReadOnly = True
        Me.IdFondoPensiones.Visible = False
        '
        'CodFon
        '
        Me.CodFon.HeaderText = "CodFon"
        Me.CodFon.Name = "CodFon"
        Me.CodFon.ReadOnly = True
        Me.CodFon.Width = 60
        '
        'Entidad
        '
        Me.Entidad.HeaderText = "Entidad"
        Me.Entidad.Name = "Entidad"
        Me.Entidad.ReadOnly = True
        Me.Entidad.Width = 250
        '
        'ApoOblF
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ApoOblF.DefaultCellStyle = DataGridViewCellStyle15
        Me.ApoOblF.HeaderText = "ApoOblF"
        Me.ApoOblF.Name = "ApoOblF"
        Me.ApoOblF.ReadOnly = True
        Me.ApoOblF.Width = 65
        '
        'ComVarF
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ComVarF.DefaultCellStyle = DataGridViewCellStyle16
        Me.ComVarF.HeaderText = "ComVarF"
        Me.ComVarF.Name = "ComVarF"
        Me.ComVarF.ReadOnly = True
        Me.ComVarF.Width = 65
        '
        'PriSegF
        '
        Me.PriSegF.HeaderText = "PriSegF"
        Me.PriSegF.Name = "PriSegF"
        Me.PriSegF.ReadOnly = True
        Me.PriSegF.Width = 65
        '
        'ApoOblM
        '
        Me.ApoOblM.HeaderText = "ApoOblM"
        Me.ApoOblM.Name = "ApoOblM"
        Me.ApoOblM.ReadOnly = True
        Me.ApoOblM.Width = 65
        '
        'ComVarM
        '
        Me.ComVarM.HeaderText = "ComVarM"
        Me.ComVarM.Name = "ComVarM"
        Me.ComVarM.ReadOnly = True
        Me.ComVarM.Width = 65
        '
        'PriSegM
        '
        Me.PriSegM.HeaderText = "PriSegM"
        Me.PriSegM.Name = "PriSegM"
        Me.PriSegM.ReadOnly = True
        Me.PriSegM.Width = 65
        '
        'PorONP
        '
        Me.PorONP.HeaderText = "PorONP"
        Me.PorONP.Name = "PorONP"
        Me.PorONP.ReadOnly = True
        Me.PorONP.Width = 65
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(206, 199)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(209, 23)
        Me.cmbEstado.TabIndex = 121
        '
        'frmFondoPensiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 462)
        Me.Controls.Add(Me.tbcOtrosPagos)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmFondoPensiones"
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
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
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
    Friend WithEvents tbpNuevo As TabPage
    Friend WithEvents grpManagement As GroupBox
    Friend WithEvents txtMixtaAporteOblig As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEntidad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtFlujoAporteOblig As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents grpAccion As GroupBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents cmbDistrito As ComboBox
    Friend WithEvents txtSexo As TextBox
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
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtMixtaPrimaSeg As TextBox
    Friend WithEvents txtFlujoPrimaSeg As TextBox
    Friend WithEvents txtMixtaComisionVar As TextBox
    Friend WithEvents txtFlujoComisionVar As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtONP As TextBox
    Friend WithEvents IdFondoPensiones As DataGridViewTextBoxColumn
    Friend WithEvents CodFon As DataGridViewTextBoxColumn
    Friend WithEvents Entidad As DataGridViewTextBoxColumn
    Friend WithEvents ApoOblF As DataGridViewTextBoxColumn
    Friend WithEvents ComVarF As DataGridViewTextBoxColumn
    Friend WithEvents PriSegF As DataGridViewTextBoxColumn
    Friend WithEvents ApoOblM As DataGridViewTextBoxColumn
    Friend WithEvents ComVarM As DataGridViewTextBoxColumn
    Friend WithEvents PriSegM As DataGridViewTextBoxColumn
    Friend WithEvents PorONP As DataGridViewTextBoxColumn
    Friend WithEvents cmbEstado As ComboBox
End Class
