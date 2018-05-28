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
