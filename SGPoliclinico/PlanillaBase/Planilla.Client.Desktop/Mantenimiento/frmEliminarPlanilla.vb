Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports Planilla.Data.Contracts
Imports System.Net

Public Class frmEliminarPlanilla

    Private planillaManager As New PersonalManager
    Private _planillas As IEnumerable(Of PlanillaUnico)

    Private Sub frmEliminarPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
    End Sub


    Private Sub Listar()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each _planilla In _planillas
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells(Anio.Name).Value = _planilla.Anio
                .Cells(Mes.Name).Value = _planilla.Mes
                .Cells(Tipo.Name).Value = _planilla.TipoPlanilla
                .Cells(TipoExt.Name).Value = _planilla.TipoPlanillaExt
                .Cells(Cerrado.Name).Value = _planilla.Cerrado
                .Cells(Periodo.Name).Value = _planilla.Periodo
            End With
        Next
    End Sub

    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            _planillas = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text)
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

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _planillas = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text)
        Listar()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        _planillas = Nothing
        dgvPagoDctoBasico.Rows.Clear()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Me.dgvPagoDctoBasico.CurrentRow IsNot Nothing Then
            If MsgBox("¿Realmente desea eliminar esta planilla?", vbYesNo) = vbYes Then
                planillaManager.EliminarPlanilla(Me.dgvPagoDctoBasico.CurrentRow.Cells(Periodo.Name).Value, Me.dgvPagoDctoBasico.CurrentRow.Cells(Tipo.Name).Value)
                _planillas = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text)
                Listar()
            End If
        End If

    End Sub
End Class