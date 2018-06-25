Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmGenerarPDT

    Private planillaManager As New PersonalManager
    Private _planillasRemuneracion As List(Of PlanillaRemuneracion)
    Private _planillaActual As PlanillaRemuneracion


    Private Sub frmGenerarPDT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProcComboBoxAMes(cmbMes)
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
    End Sub

    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue)
            Listar()
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue)
            Listar()
        Catch ex As Exception
            Notificar(ex.Message)
        End Try
    End Sub

    Private Sub Listar()
        Me.dgvPlanilla.Rows.Clear()
        For Each _planilla In _planillasRemuneracion
            Me.dgvPlanilla.Rows.Add()
            With dgvPlanilla.Rows(dgvPlanilla.Rows.Count - 1)
                .Cells(IdPlanilla.Name).Value = _planilla.IdPlanilla
                .Cells(Periodo.Name).Value = _planilla.Periodo
                .Cells(Codigo.Name).Value = _planilla.CodPer
                .Cells(Empleado.Name).Value = _planilla.NombrePersona
                .Cells(RemBas.Name).Value = FormatearNumero(_planilla.RemBas, 2)
                .Cells(AsigFam.Name).Value = FormatearNumero(_planilla.AsiFam, 2)
                .Cells(Subsidio.Name).Value = FormatearNumero(_planilla.Subsidio, 2)
                .Cells(Gratif.Name).Value = FormatearNumero(_planilla.Gratif, 2)
                .Cells(RemVac.Name).Value = FormatearNumero(_planilla.RemVac, 2)
                .Cells(RieCaj.Name).Value = FormatearNumero(_planilla.RieCaj, 2)
                .Cells(Reinteg.Name).Value = FormatearNumero(_planilla.Reinte, 2)
                .Cells(HE.Name).Value = FormatearNumero(_planilla.HE, 2)
                .Cells(OtrosIng.Name).Value = FormatearNumero(_planilla.OtrIng, 2)
                .Cells(TotalIng.Name).Value = FormatearNumero(_planilla.TotIng, 2)
                .Cells(ONP.Name).Value = FormatearNumero(_planilla.ONP, 2)
                .Cells(ApoObl.Name).Value = FormatearNumero(_planilla.ApoObl, 2)
                .Cells(Prima.Name).Value = FormatearNumero(_planilla.PriSeg, 2)
                .Cells(Comision.Name).Value = FormatearNumero(_planilla.ComVar, 2)
                .Cells(Quinta.Name).Value = FormatearNumero(_planilla.Quinta, 2)
                .Cells(OtroDes.Name).Value = FormatearNumero(_planilla.OtrDes, 2)
                .Cells(TotDes.Name).Value = FormatearNumero(_planilla.TotDes, 2)
                .Cells(Neto.Name).Value = FormatearNumero(_planilla.Neto, 2)
                .Cells(Essalud.Name).Value = FormatearNumero(_planilla.Essalud, 2)
                .Cells(SCTR.Name).Value = FormatearNumero(_planilla.SCTR, 2)
                .Cells(TotApo.Name).Value = FormatearNumero(_planilla.TotApo, 2)
                .Cells(DiasLab.Name).Value = _planilla.DiasLab
                .Cells(HorasLab.Name).Value = _planilla.HorasLab
                .Cells(IniVac.Name).Value = _planilla.IniVac
                .Cells(FinVac.Name).Value = _planilla.FinVac
                .Cells(IniIncap.Name).Value = _planilla.IniIncapacidad
                .Cells(FinIncap.Name).Value = _planilla.FinIncapacidad
                .Cells(IniSGH.Name).Value = _planilla.InicioSinGoceHaber
                .Cells(FinSGH.Name).Value = _planilla.FinSinGoceHaber
                .Cells(Cerrado.Name).Value = _planilla.Cerrado
            End With
        Next
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If dgvPlanilla.Rows.Count > 0 Then
            Dim dtEx = DataGridViewToDataTable(dgvPlanilla, New List(Of String)(New String() {"IdPersonal"}), "Honk")
            FncDataTable2Excel(dtEx, "Planilla")
        End If
    End Sub

    Private Sub btnSunat_Click(sender As Object, e As EventArgs) Handles btnSunat.Click

    End Sub
End Class