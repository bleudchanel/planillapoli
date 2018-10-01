Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Data
Imports System.Net

Public Class frmImprimirPlanilla

    Private planillaManager As New PersonalManager
    Private _planillasRemuneracion As List(Of PlanillaRemuneracion)
    Private _planillaActual As PlanillaRemuneracion

    Private decTotalPlanilla As Decimal
    Private decTotalONP As Decimal
    Private decTotalAFP As Decimal
    Private decTotalESSALUD As Decimal
    Private decTotalRentaQuinta As Decimal
    Private decTotalADepositar As Decimal
    Private decTotalSCTR As Decimal

    Private Sub frmImprimirPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProcComboBoxAMes(cmbMes)
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
    End Sub


    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue).OrderBy(Function(x) x.NombrePersona).ToList()
            Listar()
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        'Try
        _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue).OrderBy(Function(x) x.NombrePersona).ToList()
            Listar()
        'Catch ex As Exception
        '    Notificar(ex.Message)
        'End Try
    End Sub

    Private Sub Listar()
        decTotalPlanilla = 0
        decTotalONP = 0
        decTotalAFP = 0
        decTotalESSALUD = 0
        decTotalRentaQuinta = 0
        decTotalADepositar = 0
        decTotalSCTR = 0

        Me.dgvPlanilla.Rows.Clear()
        For Each _planilla In _planillasRemuneracion

            decTotalAFP += (_planilla.ApoObl + _planilla.ComVar + _planilla.PriSeg)
            decTotalONP += _planilla.ONP
            decTotalESSALUD += _planilla.Essalud
            decTotalSCTR += _planilla.SCTR
            decTotalRentaQuinta += _planilla.Quinta
            decTotalPlanilla += _planilla.Neto

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

        decTotalADepositar = decTotalONP + decTotalESSALUD + decTotalRentaQuinta

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If _planillasRemuneracion IsNot Nothing Then
            Dim dtbase As DataTable = fncDataTableReportePlanilla()
            For Each _planilla In _planillasRemuneracion
                fncIngresaEnReportePlanilla(dtbase, _planilla)
            Next

            FncDataTable2Excel(dtbase, "Reporte Planilla: ")

        End If
    End Sub

    Private Sub btnResumen_Click(sender As Object, e As EventArgs) Handles btnResumen.Click
        If _planillasRemuneracion IsNot Nothing AndAlso _planillasRemuneracion.Count > 0 Then
            If _planillasRemuneracion.Item(0).Cerrado = "F" Then
                Notificar("La planilla debe estar cerrada.")
                Exit Sub
            End If
            modPersonal.strADepositar = FormatearNumero(decTotalADepositar, 2)
            modPersonal.strAFPMonto = FormatearNumero(decTotalAFP, 2)
            modPersonal.strESSALUD = FormatearNumero(decTotalESSALUD, 2)
            modPersonal.strONP = FormatearNumero(decTotalONP, 2)
            modPersonal.strTotalPagoPersonas = FormatearNumero(decTotalPlanilla, 2)
            modPersonal.strSCTR = FormatearNumero(decTotalSCTR, 2)
            modPersonal.strRentaQuinta = FormatearNumero(decTotalRentaQuinta, 2)
            modPersonal.strPeriodo = fncTextoMesPorIntMes(cmbMes.SelectedValue) & " " & txtAnioAProgramar.Text
            Dim frm As New frmReporteResumenPlanilla()
            frm.Show()
        End If
    End Sub

    Private Sub btnBoletas_Click(sender As Object, e As EventArgs) Handles btnBoletas.Click
        If Not (_planillasRemuneracion IsNot Nothing AndAlso _planillasRemuneracion.Count > 0) Then
            Notificar("Planilla vacía.")
            Exit Sub
        End If

        If _planillasRemuneracion.Item(0).Cerrado = "F" Then
            Notificar("La planilla debe estar cerrada.")
            Exit Sub
        End If

        Dim dtBoletasPre As New DataTable
        dtBoletasPre.Columns.Add("CodPer")
        dtBoletasPre.Columns.Add("Nombre")
        dtBoletasPre.Columns.Add("FechaIngreso")
        dtBoletasPre.Columns.Add("DocIdentidad")
        dtBoletasPre.Columns.Add("Cargo")
        dtBoletasPre.Columns.Add("MesAnio")
        dtBoletasPre.Columns.Add("DiasLab")
        dtBoletasPre.Columns.Add("HorasLab")
        dtBoletasPre.Columns.Add("AFPCUSPP")
        dtBoletasPre.Columns.Add("FechaPago")
        dtBoletasPre.Columns.Add("DiasVac")
        dtBoletasPre.Columns.Add("RemBasica")
        dtBoletasPre.Columns.Add("AsigFamiliar")
        dtBoletasPre.Columns.Add("Subsidio")
        dtBoletasPre.Columns.Add("Gratificacion")
        dtBoletasPre.Columns.Add("RemVacacional")
        dtBoletasPre.Columns.Add("RiesgoCaja")
        dtBoletasPre.Columns.Add("Reintegro")
        dtBoletasPre.Columns.Add("HorasExtra")
        dtBoletasPre.Columns.Add("OtrosIngresos")
        dtBoletasPre.Columns.Add("TotalRem")
        dtBoletasPre.Columns.Add("AFPAporteObl")
        dtBoletasPre.Columns.Add("AFPComVar")
        dtBoletasPre.Columns.Add("AFPPrimaSeg")
        dtBoletasPre.Columns.Add("ONP")
        dtBoletasPre.Columns.Add("RentaQuinta")
        dtBoletasPre.Columns.Add("OtrosDesc")
        dtBoletasPre.Columns.Add("TotalDesc")
        dtBoletasPre.Columns.Add("ESSALUD")
        dtBoletasPre.Columns.Add("SCTR")
        dtBoletasPre.Columns.Add("TotalAporte")
        dtBoletasPre.Columns.Add("NetoRecibir")
        dtBoletasPre.Columns.Add("PorApoObl")
        dtBoletasPre.Columns.Add("PorComVar")
        dtBoletasPre.Columns.Add("PorPriSeg")
        dtBoletasPre.Columns.Add("PorONP")
        dtBoletasPre.Columns.Add("PorEssalud")
        dtBoletasPre.Columns.Add("PorSCTR")

        For Each _planilla In _planillasRemuneracion
            Dim diasLab As Int16 = _planilla.DiasLab - (If(_planilla.DiasIncapacidad Is Nothing, 0, _planilla.DiasIncapacidad) +
                If(_planilla.DiasSinGoceHaber Is Nothing, 0, _planilla.DiasSinGoceHaber) + If(_planilla.DiasVac Is Nothing, 0, _planilla.DiasVac))
            dtBoletasPre.Rows.Add(_planilla.CodPer,
                                  _planilla.NombrePersona,
                                  _planilla.FechaIngreso.ToString("dd/MM/yy"),
                                  _planilla.Dni,
                                  _planilla.Cargo,
                                   _planilla.Periodo,
                                   diasLab,
                                   _planilla.HorasLab * diasLab,
                                   _planilla.AFP + " " + _planilla.CUSPP,
                                   Date.Now.ToString("dd/MM/yy"),
                                   If(_planilla.DiasVac Is Nothing, 0, _planilla.DiasVac),
                                   FormatearNumero(_planilla.RemBas, 2),
                                   FormatearNumero(_planilla.AsiFam, 2),
                                   FormatearNumero(_planilla.Subsidio, 2),
                                   FormatearNumero(_planilla.Gratif, 2),
                                   FormatearNumero(_planilla.RemVac, 2),
                                   FormatearNumero(_planilla.RieCaj, 2),
                                   FormatearNumero(_planilla.Reinte, 2),
                                   FormatearNumero(_planilla.HE, 2),
                                   FormatearNumero(_planilla.OtrIng, 2),
                                   FormatearNumero(_planilla.TotIng, 2),
                                   FormatearNumero(_planilla.ApoObl, 2),
                                   FormatearNumero(_planilla.ComVar, 2),
                                   FormatearNumero(_planilla.PriSeg, 2),
                                   FormatearNumero(_planilla.ONP, 2),
                                   FormatearNumero(_planilla.Quinta, 2),
                                   FormatearNumero(_planilla.OtrDes, 2),
                                   FormatearNumero(_planilla.TotDes, 2),
                                   FormatearNumero(_planilla.Essalud, 2),
                                   FormatearNumero(_planilla.SCTR, 2),
                                   FormatearNumero(_planilla.TotApo, 2),
                                   FormatearNumero(_planilla.Neto, 2),
FormatearNumero(_planilla.PorApoObl * 100, 2) + " %",
FormatearNumero(_planilla.PorComVar * 100, 2) + " %",
FormatearNumero(_planilla.PorPriSeg * 100, 2) + " %",
FormatearNumero(_planilla.PorONP * 100, 2) + " %",
FormatearNumero(_planilla.PorEssalud * 100, 2) + " %",
FormatearNumero(_planilla.PorSCTR * 100, 2) + " %")

        Next

        If dtBoletasPre IsNot Nothing AndAlso dtBoletasPre.Rows.Count > 0 Then
            Dim frmReporte As New frmRepositorioReportevb
            frmReporte.ConstruirReporteBoleta(dtBoletasPre, "Honk")
            frmReporte.Show()
        End If

        'modPersonal.dtBoleta = dtBoletasPre
        'Dim frm As New frmReporteBoletas
        'frm.Show()

    End Sub

    Private Sub cmbMes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ActiveControl = txtAnioAProgramar
        End If
    End Sub
End Class