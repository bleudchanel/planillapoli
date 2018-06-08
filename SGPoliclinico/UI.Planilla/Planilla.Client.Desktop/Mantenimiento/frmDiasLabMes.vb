Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmDiasLabMes

    Private diasManager As New DiasLaboralesManager
    Private _dias As IEnumerable(Of DiasLaborables)

    Private Sub frmDiasLabMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
    End Sub


    Private Sub Listar()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each dia In _dias
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells("IdDiasLaborales").Value = dia.IdDiasLaborables
                .Cells("CodMes").Value = dia.CodMes
                .Cells("Anio").Value = dia.Año
                .Cells("Mes").Value = dia.Mes
                .Cells("DiasLaborados").Value = dia.DiasLab
                .Cells("Cerrado").Value = dia.Cerrado
            End With
        Next
    End Sub

    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            _dias = diasManager.GetDiasLaborales(txtAnioAProgramar.Text)
            Listar()
        End If
    End Sub

    Private Sub txtAnioAProgramar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnioAProgramar.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        _dias = diasManager.GetDiasLaborales(txtAnioAProgramar.Text)
        Listar()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If dgvPagoDctoBasico.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPagoDctoBasico.Rows.Count - 1
                Dim Id As Integer = dgvPagoDctoBasico.Rows(i).Cells("IdDiasLaborales").Value
                Dim NroDias As Integer = If(IsNumeric(dgvPagoDctoBasico.Rows(i).Cells("DiasLaborados").Value), dgvPagoDctoBasico.Rows(i).Cells("DiasLaborados").Value, 0)

                Dim var = (From o In _dias Where o.IdDiasLaborables = Id Select o).FirstOrDefault()
                If var IsNot Nothing Then
                    If var.DiasLab <> NroDias Then
                        var.DiasLab = NroDias
                        diasManager.Update(var)
                    End If
                End If
            Next
        End If

        _dias = diasManager.GetDiasLaborales(txtAnioAProgramar.Text)
        Listar()

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _dias = diasManager.GetDiasLaborales(txtAnioAProgramar.Text)
        Listar()
    End Sub
End Class