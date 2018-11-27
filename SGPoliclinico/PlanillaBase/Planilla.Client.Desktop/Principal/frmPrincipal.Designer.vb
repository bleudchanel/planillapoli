<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MédicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablaHonorariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EspecialidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcedimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnálisisDeLaboratorioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablasPlanillasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EspecificaciónDeDíasLaborablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConceptosAportesEmpleadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntidadesFondosDePensionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablaPlanillasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarPlanillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirPlanillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarPlanillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GenerarPlanillaDeGratificacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AFPNetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnálisisYProyeccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumenAnualDePlanillasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProyecciónDePagosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SUNATToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDTPLAMEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestiónDeCTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SueldoMínimoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblPrDatos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProcedimientosDeLaboratorioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SistemaToolStripMenuItem, Me.PersonaToolStripMenuItem, Me.TablaHonorariosToolStripMenuItem, Me.TablasPlanillasToolStripMenuItem, Me.TablaPlanillasToolStripMenuItem, Me.AFPNetToolStripMenuItem, Me.AnálisisYProyeccionesToolStripMenuItem, Me.SUNATToolStripMenuItem, Me.CTSToolStripMenuItem, Me.ConfiguraciónToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1127, 29)
        Me.MenuStrip.TabIndex = 5
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(77, 25)
        Me.SistemaToolStripMenuItem.Text = "&Sistema"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(111, 26)
        Me.SalirToolStripMenuItem.Text = "S&alir"
        '
        'PersonaToolStripMenuItem
        '
        Me.PersonaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonalToolStripMenuItem, Me.MédicoToolStripMenuItem})
        Me.PersonaToolStripMenuItem.Name = "PersonaToolStripMenuItem"
        Me.PersonaToolStripMenuItem.Size = New System.Drawing.Size(77, 25)
        Me.PersonaToolStripMenuItem.Text = "Persona"
        '
        'PersonalToolStripMenuItem
        '
        Me.PersonalToolStripMenuItem.Name = "PersonalToolStripMenuItem"
        Me.PersonalToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.PersonalToolStripMenuItem.Text = "Personal"
        '
        'MédicoToolStripMenuItem
        '
        Me.MédicoToolStripMenuItem.Name = "MédicoToolStripMenuItem"
        Me.MédicoToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.MédicoToolStripMenuItem.Text = "Médico"
        '
        'TablaHonorariosToolStripMenuItem
        '
        Me.TablaHonorariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EspecialidadToolStripMenuItem, Me.ProcedimientoToolStripMenuItem, Me.ToolStripSeparator1, Me.ProcedimientosDeLaboratorioToolStripMenuItem, Me.AnálisisDeLaboratorioToolStripMenuItem})
        Me.TablaHonorariosToolStripMenuItem.Name = "TablaHonorariosToolStripMenuItem"
        Me.TablaHonorariosToolStripMenuItem.Size = New System.Drawing.Size(139, 25)
        Me.TablaHonorariosToolStripMenuItem.Text = "Tabla Honorarios"
        '
        'EspecialidadToolStripMenuItem
        '
        Me.EspecialidadToolStripMenuItem.Name = "EspecialidadToolStripMenuItem"
        Me.EspecialidadToolStripMenuItem.Size = New System.Drawing.Size(294, 26)
        Me.EspecialidadToolStripMenuItem.Text = "Especialidad"
        '
        'ProcedimientoToolStripMenuItem
        '
        Me.ProcedimientoToolStripMenuItem.Name = "ProcedimientoToolStripMenuItem"
        Me.ProcedimientoToolStripMenuItem.Size = New System.Drawing.Size(294, 26)
        Me.ProcedimientoToolStripMenuItem.Text = "Procedimiento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(291, 6)
        '
        'AnálisisDeLaboratorioToolStripMenuItem
        '
        Me.AnálisisDeLaboratorioToolStripMenuItem.Name = "AnálisisDeLaboratorioToolStripMenuItem"
        Me.AnálisisDeLaboratorioToolStripMenuItem.Size = New System.Drawing.Size(294, 26)
        Me.AnálisisDeLaboratorioToolStripMenuItem.Text = "Análisis de Laboratorio"
        '
        'TablasPlanillasToolStripMenuItem
        '
        Me.TablasPlanillasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem, Me.EspecificaciónDeDíasLaborablesToolStripMenuItem, Me.ToolStripSeparator3, Me.ConceptosAportesEmpleadorToolStripMenuItem, Me.EntidadesFondosDePensionesToolStripMenuItem})
        Me.TablasPlanillasToolStripMenuItem.Name = "TablasPlanillasToolStripMenuItem"
        Me.TablasPlanillasToolStripMenuItem.Size = New System.Drawing.Size(125, 25)
        Me.TablasPlanillasToolStripMenuItem.Text = "Tablas Planillas"
        '
        'ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem
        '
        Me.ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem.Name = "ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem"
        Me.ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem.Text = "Programación y Ejecución de Vacaciones"
        '
        'EspecificaciónDeDíasLaborablesToolStripMenuItem
        '
        Me.EspecificaciónDeDíasLaborablesToolStripMenuItem.Name = "EspecificaciónDeDíasLaborablesToolStripMenuItem"
        Me.EspecificaciónDeDíasLaborablesToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.EspecificaciónDeDíasLaborablesToolStripMenuItem.Text = "Especificación de Días Laborables"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(357, 6)
        '
        'ConceptosAportesEmpleadorToolStripMenuItem
        '
        Me.ConceptosAportesEmpleadorToolStripMenuItem.Name = "ConceptosAportesEmpleadorToolStripMenuItem"
        Me.ConceptosAportesEmpleadorToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.ConceptosAportesEmpleadorToolStripMenuItem.Text = "Conceptos Aportes Empleador"
        '
        'EntidadesFondosDePensionesToolStripMenuItem
        '
        Me.EntidadesFondosDePensionesToolStripMenuItem.Name = "EntidadesFondosDePensionesToolStripMenuItem"
        Me.EntidadesFondosDePensionesToolStripMenuItem.Size = New System.Drawing.Size(360, 26)
        Me.EntidadesFondosDePensionesToolStripMenuItem.Text = "Entidades Fondos de Pensiones"
        '
        'TablaPlanillasToolStripMenuItem
        '
        Me.TablaPlanillasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarPlanillaToolStripMenuItem, Me.ImprimirPlanillaToolStripMenuItem, Me.EliminarPlanillaToolStripMenuItem, Me.ToolStripSeparator2, Me.GenerarPlanillaDeGratificacionesToolStripMenuItem})
        Me.TablaPlanillasToolStripMenuItem.Name = "TablaPlanillasToolStripMenuItem"
        Me.TablaPlanillasToolStripMenuItem.Size = New System.Drawing.Size(84, 25)
        Me.TablaPlanillasToolStripMenuItem.Text = "Procesos"
        '
        'GenerarPlanillaToolStripMenuItem
        '
        Me.GenerarPlanillaToolStripMenuItem.Name = "GenerarPlanillaToolStripMenuItem"
        Me.GenerarPlanillaToolStripMenuItem.Size = New System.Drawing.Size(317, 26)
        Me.GenerarPlanillaToolStripMenuItem.Text = "Generar Planilla"
        '
        'ImprimirPlanillaToolStripMenuItem
        '
        Me.ImprimirPlanillaToolStripMenuItem.Name = "ImprimirPlanillaToolStripMenuItem"
        Me.ImprimirPlanillaToolStripMenuItem.Size = New System.Drawing.Size(317, 26)
        Me.ImprimirPlanillaToolStripMenuItem.Text = "Imprimir Planilla"
        '
        'EliminarPlanillaToolStripMenuItem
        '
        Me.EliminarPlanillaToolStripMenuItem.Name = "EliminarPlanillaToolStripMenuItem"
        Me.EliminarPlanillaToolStripMenuItem.Size = New System.Drawing.Size(317, 26)
        Me.EliminarPlanillaToolStripMenuItem.Text = "Eliminar Planilla"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(314, 6)
        '
        'GenerarPlanillaDeGratificacionesToolStripMenuItem
        '
        Me.GenerarPlanillaDeGratificacionesToolStripMenuItem.Name = "GenerarPlanillaDeGratificacionesToolStripMenuItem"
        Me.GenerarPlanillaDeGratificacionesToolStripMenuItem.Size = New System.Drawing.Size(317, 26)
        Me.GenerarPlanillaDeGratificacionesToolStripMenuItem.Text = "Generar Planilla de Gratificaciones"
        '
        'AFPNetToolStripMenuItem
        '
        Me.AFPNetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarArchivoToolStripMenuItem})
        Me.AFPNetToolStripMenuItem.Name = "AFPNetToolStripMenuItem"
        Me.AFPNetToolStripMenuItem.Size = New System.Drawing.Size(78, 25)
        Me.AFPNetToolStripMenuItem.Text = "AFP Net"
        '
        'GenerarArchivoToolStripMenuItem
        '
        Me.GenerarArchivoToolStripMenuItem.Name = "GenerarArchivoToolStripMenuItem"
        Me.GenerarArchivoToolStripMenuItem.Size = New System.Drawing.Size(193, 26)
        Me.GenerarArchivoToolStripMenuItem.Text = "Generar Archivo"
        '
        'AnálisisYProyeccionesToolStripMenuItem
        '
        Me.AnálisisYProyeccionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResumenAnualDePlanillasToolStripMenuItem, Me.ProyecciónDePagosToolStripMenuItem})
        Me.AnálisisYProyeccionesToolStripMenuItem.Name = "AnálisisYProyeccionesToolStripMenuItem"
        Me.AnálisisYProyeccionesToolStripMenuItem.Size = New System.Drawing.Size(182, 25)
        Me.AnálisisYProyeccionesToolStripMenuItem.Text = "Análisis y Proyecciones"
        '
        'ResumenAnualDePlanillasToolStripMenuItem
        '
        Me.ResumenAnualDePlanillasToolStripMenuItem.Name = "ResumenAnualDePlanillasToolStripMenuItem"
        Me.ResumenAnualDePlanillasToolStripMenuItem.Size = New System.Drawing.Size(271, 26)
        Me.ResumenAnualDePlanillasToolStripMenuItem.Text = "Resumen Anual de Planillas"
        '
        'ProyecciónDePagosToolStripMenuItem
        '
        Me.ProyecciónDePagosToolStripMenuItem.Name = "ProyecciónDePagosToolStripMenuItem"
        Me.ProyecciónDePagosToolStripMenuItem.Size = New System.Drawing.Size(271, 26)
        Me.ProyecciónDePagosToolStripMenuItem.Text = "Proyección de Pagos"
        '
        'SUNATToolStripMenuItem
        '
        Me.SUNATToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PDTPLAMEToolStripMenuItem})
        Me.SUNATToolStripMenuItem.Name = "SUNATToolStripMenuItem"
        Me.SUNATToolStripMenuItem.Size = New System.Drawing.Size(71, 25)
        Me.SUNATToolStripMenuItem.Text = "SUNAT"
        '
        'PDTPLAMEToolStripMenuItem
        '
        Me.PDTPLAMEToolStripMenuItem.Name = "PDTPLAMEToolStripMenuItem"
        Me.PDTPLAMEToolStripMenuItem.Size = New System.Drawing.Size(160, 26)
        Me.PDTPLAMEToolStripMenuItem.Text = "PDT PLAME"
        '
        'CTSToolStripMenuItem
        '
        Me.CTSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestiónDeCTSToolStripMenuItem})
        Me.CTSToolStripMenuItem.Name = "CTSToolStripMenuItem"
        Me.CTSToolStripMenuItem.Size = New System.Drawing.Size(49, 25)
        Me.CTSToolStripMenuItem.Text = "CTS"
        '
        'GestiónDeCTSToolStripMenuItem
        '
        Me.GestiónDeCTSToolStripMenuItem.Name = "GestiónDeCTSToolStripMenuItem"
        Me.GestiónDeCTSToolStripMenuItem.Size = New System.Drawing.Size(185, 26)
        Me.GestiónDeCTSToolStripMenuItem.Text = "Gestión de CTS"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SueldoMínimoToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(120, 25)
        Me.ConfiguraciónToolStripMenuItem.Text = "Configuración"
        '
        'SueldoMínimoToolStripMenuItem
        '
        Me.SueldoMínimoToolStripMenuItem.Name = "SueldoMínimoToolStripMenuItem"
        Me.SueldoMínimoToolStripMenuItem.Size = New System.Drawing.Size(186, 26)
        Me.SueldoMínimoToolStripMenuItem.Text = "Sueldo Mínimo"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPrDatos})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 873)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1127, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblPrDatos
        '
        Me.lblPrDatos.Name = "lblPrDatos"
        Me.lblPrDatos.Size = New System.Drawing.Size(37, 17)
        Me.lblPrDatos.Text = "Datos"
        '
        'ProcedimientosDeLaboratorioToolStripMenuItem
        '
        Me.ProcedimientosDeLaboratorioToolStripMenuItem.Name = "ProcedimientosDeLaboratorioToolStripMenuItem"
        Me.ProcedimientosDeLaboratorioToolStripMenuItem.Size = New System.Drawing.Size(294, 26)
        Me.ProcedimientosDeLaboratorioToolStripMenuItem.Text = "Procedimientos de Laboratorio"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 895)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents SistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPrDatos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PersonalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TablaHonorariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EspecialidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcedimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AnálisisDeLaboratorioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TablaPlanillasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerarPlanillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirPlanillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarPlanillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GenerarPlanillaDeGratificacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TablasPlanillasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EspecificaciónDeDíasLaborablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ConceptosAportesEmpleadorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EntidadesFondosDePensionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AFPNetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerarArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnálisisYProyeccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResumenAnualDePlanillasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SUNATToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PDTPLAMEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CTSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestiónDeCTSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProyecciónDePagosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MédicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguraciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SueldoMínimoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcedimientosDeLaboratorioToolStripMenuItem As ToolStripMenuItem
End Class
