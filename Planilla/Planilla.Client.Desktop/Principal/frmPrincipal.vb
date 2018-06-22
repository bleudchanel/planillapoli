Imports System.Windows.Forms

Public Class frmPrincipal



    Private Function SingletonForm(ByVal FormUnico As Form) As Boolean
        Dim Rpta As Boolean = True
        Dim ctl As Form
        For Each ctl In MdiChildren
            If ctl.Name = FormUnico.Name Then
                Rpta = False
                Exit For
            Else
                Rpta = True
            End If
        Next
        Return Rpta
    End Function


    Private Sub DevolverEnfoque(ByRef Formu As Form)
        For Each OpenForm As Form In Me.MdiChildren
            If OpenForm.Name = Formu.Name Then
                OpenForm.Activate()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'modPlanilla.intPRFid = 1 ' Reemplazar
        'btnPeriodo.PerformClick()
    End Sub

    Private Sub PersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonalToolStripMenuItem.Click
        If SingletonForm(frmRemuneracionBasica) = True Then
            Dim ChildForm As New frmRemuneracionBasica

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmRemuneracionBasica)
        End If
    End Sub

    Private Sub EspecialidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspecialidadToolStripMenuItem.Click
        If SingletonForm(frmEspecialidad) = True Then
            Dim ChildForm As New frmEspecialidad

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmEspecialidad)
        End If
    End Sub

    Private Sub ProcedimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcedimientoToolStripMenuItem.Click
        If SingletonForm(frmProcedimiento) = True Then
            Dim ChildForm As New frmProcedimiento

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmProcedimiento)
        End If
    End Sub

    Private Sub AnálisisDeLaboratorioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnálisisDeLaboratorioToolStripMenuItem.Click
        If SingletonForm(frmAnalisisLaboratorio) = True Then
            Dim ChildForm As New frmAnalisisLaboratorio

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmAnalisisLaboratorio)
        End If
    End Sub

    Private Sub GenerarPlanillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarPlanillaToolStripMenuItem.Click
        If SingletonForm(frmGenerarPlanilla) = True Then
            Dim ChildForm As New frmGenerarPlanilla

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmGenerarPlanilla)
        End If
    End Sub

    Private Sub ImprimirPlanillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirPlanillaToolStripMenuItem.Click
        If SingletonForm(frmImprimirPlanilla) = True Then
            Dim ChildForm As New frmImprimirPlanilla

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmImprimirPlanilla)
        End If
    End Sub

    Private Sub EliminarPlanillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarPlanillaToolStripMenuItem.Click
        If SingletonForm(frmEliminarPlanilla) = True Then
            Dim ChildForm As New frmEliminarPlanilla

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmEliminarPlanilla)
        End If
    End Sub

    Private Sub GenerarPlanillaDeGratificacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarPlanillaDeGratificacionesToolStripMenuItem.Click
        If SingletonForm(frmGenerarPlanillaGratificacion) = True Then
            Dim ChildForm As New frmGenerarPlanillaGratificacion

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmGenerarPlanillaGratificacion)
        End If
    End Sub

    Private Sub ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramaciónYEjecuciónDeVacacionesToolStripMenuItem.Click
        If SingletonForm(frmProgramacionVacaciones) = True Then
            Dim ChildForm As New frmProgramacionVacaciones

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmProgramacionVacaciones)
        End If
    End Sub

    Private Sub EspecificaciónDeDíasLaborablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EspecificaciónDeDíasLaborablesToolStripMenuItem.Click
        If SingletonForm(frmDiasLabMes) = True Then
            Dim ChildForm As New frmDiasLabMes

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmDiasLabMes)
        End If
    End Sub

    Private Sub ConceptosAportesEmpleadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConceptosAportesEmpleadorToolStripMenuItem.Click
        If SingletonForm(FrmAportesEmpleador) = True Then
            Dim ChildForm As New FrmAportesEmpleador

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(FrmAportesEmpleador)
        End If
    End Sub

    Private Sub EntidadesFondosDePensionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntidadesFondosDePensionesToolStripMenuItem.Click
        If SingletonForm(frmFondoPensiones) = True Then
            Dim ChildForm As New frmFondoPensiones

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmFondoPensiones)
        End If
    End Sub

    Private Sub GenerarArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarArchivoToolStripMenuItem.Click
        If SingletonForm(frmGenerarAFPNet) = True Then
            Dim ChildForm As New frmGenerarAFPNet

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmGenerarAFPNet)
        End If
    End Sub

    Private Sub ResumenAnualDePlanillasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenAnualDePlanillasToolStripMenuItem.Click
        If SingletonForm(frmResumenAnualPlanillas) = True Then
            Dim ChildForm As New frmResumenAnualPlanillas

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmResumenAnualPlanillas)
        End If
    End Sub

    Private Sub PDTPLAMEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDTPLAMEToolStripMenuItem.Click
        If SingletonForm(frmGenerarPDT) = True Then
            Dim ChildForm As New frmGenerarPDT

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmGenerarPDT)
        End If
    End Sub

    Private Sub GestiónDeCTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestiónDeCTSToolStripMenuItem.Click
        If SingletonForm(frmPlanillaCTS) = True Then
            Dim ChildForm As New frmPlanillaCTS

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmPlanillaCTS)
        End If
    End Sub

    Private Sub ProyecciónDePagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyecciónDePagosToolStripMenuItem.Click
        If SingletonForm(frmProyeccionPago) = True Then
            Dim ChildForm As New frmProyeccionPago

            ChildForm.StartPosition = FormStartPosition.Manual
            ChildForm.Left = 0
            ChildForm.Top = 0
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            DevolverEnfoque(frmProyeccionPago)
        End If
    End Sub




    'Private Sub ConceptoOtroPagoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptoOtroPagoToolStripMenuItem1.Click
    '    If SingletonForm(frmMantenimientoConceptoOtroPago) = True Then
    '        Dim ChildForm As New frmMantenimientoConceptoOtroPago

    '        ChildForm.StartPosition = FormStartPosition.Manual
    '        ChildForm.Left = 0
    '        ChildForm.Top = 0
    '        ChildForm.MdiParent = Me
    '        ChildForm.Show()
    '    Else
    '        DevolverEnfoque(frmMantenimientoConceptoOtroPago)
    '    End If
    'End Sub

End Class
