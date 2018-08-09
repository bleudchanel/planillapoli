Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports Planilla.Data.Contracts
Imports System.Net

Public Class frmPlanillaCTS

    Private planillaManager As New PersonalManager
    Private _planillasCTS As List(Of PlanillaCTS)

    Private Sub frmPlanillaCTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtCts As New DataTable
        dtCts.Columns.Add("Id", GetType(Integer))
        dtCts.Columns.Add("Mes", GetType(String))
        dtCts.Rows.Add(5, "05 Mayo")
        dtCts.Rows.Add(11, "11 Noviembre")

        Me.cmbMes.DataSource = dtCts
        Me.cmbMes.ValueMember = "Id"
        Me.cmbMes.DisplayMember = "Mes"
        Me.cmbMes.SelectedValue = 5

        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _planillasCTS = planillaManager.GetPlanillaCTS(Me.txtAnioAProgramar.Text, cmbMes.SelectedValue)
        Listar()
    End Sub

    Private Sub Listar()
        Dim decTotalRemuneracion As Decimal = 0
        Dim decTotalSextoGrati As Decimal = 0
        Dim decRemComputable As Decimal = 0
        Dim decMontoCTS As Decimal = 0
        Dim intCantidad As Integer = 0
        If (_planillasCTS IsNot Nothing AndAlso _planillasCTS.Count > 0) Then
            dgvPlanilla.Rows.Clear()
            For Each _planilla In _planillasCTS
                intCantidad += 1
                decTotalRemuneracion += _planilla.TotRemuneracion
                decTotalSextoGrati += _planilla.SextoGratificacion
                decRemComputable += _planilla.RemComputable
                decMontoCTS += _planilla.MontoCTS
                Me.dgvPlanilla.Rows.Add()
                With dgvPlanilla.Rows(dgvPlanilla.Rows.Count - 1)
                    .Cells(IdPersonal.Name).Value = _planilla.IdPersonal
                    .Cells(CodPer.Name).Value = _planilla.CodPer
                    .Cells(Dni.Name).Value = _planilla.Dni
                    .Cells(Empleado.Name).Value = _planilla.Nombre
                    .Cells(FechaNac.Name).Value = _planilla.FechaNacimiento
                    .Cells(FechaIng.Name).Value = _planilla.FechaIngreso
                    .Cells(NumCta.Name).Value = _planilla.NumCta
                    .Cells(TotRemuneracion.Name).Value = _planilla.TotRemuneracion
                    .Cells(SextoGrati.Name).Value = _planilla.SextoGratificacion
                    .Cells(RemComputable.Name).Value = _planilla.RemComputable
                    .Cells(MesesLab.Name).Value = _planilla.MesesLab
                    .Cells(MontoCTS.Name).Value = _planilla.MontoCTS
                    .Cells(EntidadFinanciera.Name).Value = _planilla.EntidadFinanciera
                End With
            Next
        Else
            dgvPlanilla.Rows.Clear()

        End If

        Me.txtTotalRemuneracion.Text = FormatearNumero(decTotalRemuneracion, 2)
        Me.txtSextoGrati.Text = FormatearNumero(decTotalSextoGrati, 2)
        Me.txtRemComputable.Text = FormatearNumero(decRemComputable, 2)
        Me.txtMontoCts.Text = FormatearNumero(decMontoCTS, 2)
        Me.lblCantidad.Text = "Total Trabajadores : " & intCantidad

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If dgvPlanilla.Rows.Count > 0 Then
            Dim dtEx = DataGridViewToDataTable(dgvPlanilla, New List(Of String)(New String() {"IdPersonal"}), "Honk")
            FncDataTable2Excel(dtEx, "Planilla")
        End If

    End Sub

    Private Sub cmbMes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = txtAnioAProgramar
        End If
    End Sub

    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnGenerar.PerformClick()
        End If
    End Sub
End Class