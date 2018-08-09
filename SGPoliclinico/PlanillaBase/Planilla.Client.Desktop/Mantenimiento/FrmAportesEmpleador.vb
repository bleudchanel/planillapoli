Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class FrmAportesEmpleador
    Private AporteEmpleadorManager As New VariablesManager
    Private _aportes As IEnumerable(Of AporteEmpleador)

    Private Sub FrmAportesEmpleador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnLoad()
    End Sub

    Private Sub EnLoad()
        _aportes = AporteEmpleadorManager.GetAportesEmpleador()
        Listar()
        Me.ActiveControl = btnGrabar
    End Sub

    Private Sub Listar()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each reg In _aportes
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells("IdAporteEmpleador").Value = reg.IdAporteEmpleador
                .Cells("CodApo").Value = reg.CodApo
                .Cells("Aporte").Value = reg.Aporte
                .Cells("Porcentaje").Value = reg.Porcentaje
            End With
        Next
    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        EnLoad()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If dgvPagoDctoBasico.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPagoDctoBasico.Rows.Count - 1
                Dim Id As Integer = dgvPagoDctoBasico.Rows(i).Cells("IdAporteEmpleador").Value
                If IsNumeric(dgvPagoDctoBasico.Rows(i).Cells("Porcentaje").Value) = False Then
                    Notificar("El valor ingresado : " & dgvPagoDctoBasico.Rows(i).Cells("Porcentaje").Value & " no está permitido.")
                    Continue For
                End If
                Dim porcentaje As Decimal = If(IsNumeric(dgvPagoDctoBasico.Rows(i).Cells("Porcentaje").Value), dgvPagoDctoBasico.Rows(i).Cells("Porcentaje").Value, 0)

                Dim var = (From o In _aportes Where o.IdAporteEmpleador = Id Select o).FirstOrDefault()
                If var IsNot Nothing Then
                    If var.Porcentaje <> porcentaje Then
                        var.Porcentaje = porcentaje
                        AporteEmpleadorManager.UpdateAporteEmpleador(var)
                    End If
                End If
            Next
        End If

        EnLoad()

    End Sub
End Class