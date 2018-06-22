Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmProyeccionPago

    Private planillaManager As New PersonalManager
    Private _planillasRemuneracion As List(Of PlanillaRemuneracion)

    Private _planillaActual As PlanillaRemuneracion

    Dim decRemBasica As Decimal = 0
    Dim decAsigFam As New Decimal
    Dim decRieCaj As New Decimal
    Dim decTotIngreso As New Decimal
    Dim decONP As New Decimal
    Dim decAporteObl As New Decimal
    Dim decPrimaSeg As New Decimal
    Dim decComision As New Decimal
    Dim decQuinta As New Decimal
    Dim decTotalDescuento As New Decimal
    Dim decNeto As New Decimal
    Dim decESSALUD As New Decimal
    Dim decSCTR As New Decimal
    Dim decTotalAportes As New Decimal
    Dim decTotalAumento As New Decimal




#Region "Text Monto"

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAumentar.KeyDown
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
        If e.KeyCode = Keys.Enter Then
            btnCalcular.PerformClick()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAumentar.KeyPress

        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        Else
            Try
                Dim vCapturar As Boolean = False
                Dim vCharCode As Char = ""
                Validar_NumericoV(oTextBox, e.KeyChar, vCapturar)
                e.Handled = vCapturar
            Catch ex As Exception

                e.Handled = True
                oTextBox.Text = "0.00"
            End Try

        End If
    End Sub

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAumentar.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.00"
        End If
    End Sub





#End Region


    Private Sub frmProyeccionPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ActiveControl = Me.txtAumentar
        _planillasRemuneracion = planillaManager.GetPlanillaSimple("201801")
        Listar()
    End Sub

    Private Sub Listar()


        Me.dgvPlanilla.Rows.Clear()
        For Each _planilla In _planillasRemuneracion
            Me.dgvPlanilla.Rows.Add()
            With dgvPlanilla.Rows(dgvPlanilla.Rows.Count - 1)
                '.Cells(IdPlanilla.Name).Value = _planilla.IdPlanilla
                '.Cells(Periodo.Name).Value = _planilla.Periodo
                .Cells(Codigo.Name).Value = _planilla.CodPer
                .Cells(Empleado.Name).Value = _planilla.NombrePersona
                .Cells(RemBas.Name).Value = FormatearNumero(_planilla.RemBas, 2)
                decRemBasica += (_planilla.RemBas)
                .Cells(AsigFam.Name).Value = FormatearNumero(_planilla.AsiFam, 2)
                decAsigFam += _planilla.AsiFam
                '.Cells(Subsidio.Name).Value = FormatearNumero(_planilla.Subsidio, 2)
                '.Cells(Gratif.Name).Value = FormatearNumero(_planilla.Gratif, 2)
                '.Cells(RemVac.Name).Value = FormatearNumero(_planilla.RemVac, 2)
                .Cells(RieCaj.Name).Value = FormatearNumero(_planilla.RieCaj, 2)
                decRieCaj += _planilla.RieCaj
                '.Cells(Reinteg.Name).Value = FormatearNumero(_planilla.Reinte, 2)
                '.Cells(HE.Name).Value = FormatearNumero(_planilla.HE, 2)
                '.Cells(OtrosIng.Name).Value = FormatearNumero(_planilla.OtrIng, 2)
                .Cells(TotalIng.Name).Value = FormatearNumero(_planilla.TotIng, 2)
                decTotIngreso += _planilla.TotIng
                decTotalAumento += _planilla.Aumento
                .Cells(ONP.Name).Value = FormatearNumero(_planilla.ONP, 2)
                decONP += _planilla.ONP
                .Cells(ApoObl.Name).Value = FormatearNumero(_planilla.ApoObl, 2)
                decAporteObl += _planilla.ApoObl
                .Cells(Prima.Name).Value = FormatearNumero(_planilla.PriSeg, 2)
                decPrimaSeg += _planilla.PriSeg
                .Cells(Comision.Name).Value = FormatearNumero(_planilla.ComVar, 2)
                decComision += _planilla.ComVar
                .Cells(Quinta.Name).Value = FormatearNumero(_planilla.Quinta, 2)
                decQuinta += _planilla.Quinta
                '.Cells(OtroDes.Name).Value = FormatearNumero(_planilla.OtrDes, 2)
                .Cells(TotDes.Name).Value = FormatearNumero(_planilla.TotDes, 2)
                decTotalDescuento += _planilla.TotDes
                .Cells(Neto.Name).Value = FormatearNumero(_planilla.Neto, 2)
                decNeto += _planilla.Neto
                .Cells(Essalud.Name).Value = FormatearNumero(_planilla.Essalud, 2)
                decESSALUD += _planilla.Essalud
                .Cells(SCTR.Name).Value = FormatearNumero(_planilla.SCTR, 2)
                decSCTR += _planilla.SCTR
                .Cells(TotApo.Name).Value = FormatearNumero(_planilla.TotApo, 2)
                decTotalAportes += _planilla.TotApo
                '.Cells(DiasLab.Name).Value = _planilla.DiasLab
                '.Cells(HorasLab.Name).Value = _planilla.HorasLab
                '.Cells(IniVac.Name).Value = _planilla.IniVac
                '.Cells(FinVac.Name).Value = _planilla.FinVac
                '.Cells(IniIncap.Name).Value = _planilla.IniIncapacidad
                '.Cells(FinIncap.Name).Value = _planilla.FinIncapacidad
                '.Cells(IniSGH.Name).Value = _planilla.InicioSinGoceHaber
                '.Cells(FinSGH.Name).Value = _planilla.FinSinGoceHaber
                '.Cells(Cerrado.Name).Value = _planilla.Cerrado
            End With
        Next

        txtRemuneracionBasica.Text = FormatearNumero(decRemBasica, 2)
        txtAsigFam.Text = FormatearNumero(decAsigFam, 2)
        txtRiesgoCaja.Text = FormatearNumero(decRieCaj, 2)
        txtTotalIng.Text = FormatearNumero(decTotIngreso, 2)
        txtONP.Text = FormatearNumero(decONP, 2)
        txtAporteObl.Text = FormatearNumero(decAporteObl, 2)
        txtPrimaSeg.Text = FormatearNumero(decPrimaSeg, 2)
        txtComision.Text = FormatearNumero(decComision, 2)
        txtQuintaCategoria.Text = FormatearNumero(decQuinta, 2)
        txtTotalDesc.Text = FormatearNumero(decTotalDescuento, 2)
        txtNeto.Text = FormatearNumero(decNeto, 2)
        txtESSALUD.Text = FormatearNumero(decESSALUD, 2)
        txtSCTR.Text = FormatearNumero(decSCTR, 2)
        txtTotalAportes.Text = FormatearNumero(decTotalAportes, 2)

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If dgvPlanilla.Rows.Count > 0 Then
            Dim dtEx = DataGridViewToDataTable(dgvPlanilla, New List(Of String)(New String() {"IdPersonal"}), "Honk")
            FncDataTable2Excel(dtEx, "Planilla")
        End If
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If _planillasRemuneracion IsNot Nothing AndAlso _planillasRemuneracion.Count > 0 Then
            Dim _planillasCalc As List(Of PlanillaRemuneracion) = New List(Of PlanillaRemuneracion)
            Dim decAumento As Decimal = txtAumentar.Text
            For Each _planilla In _planillasRemuneracion
                Dim nuevoPlanilla As PlanillaRemuneracion = New PlanillaRemuneracion(_planilla)
                nuevoPlanilla.SetAumento(decAumento)
                _planillasCalc.Add(nuevoPlanilla)
            Next

            Dim decpRemBasica As Decimal = 0
            Dim decpAsigFam As New Decimal
            Dim decpRieCaj As New Decimal
            Dim decpTotIngreso As New Decimal
            Dim decpONP As New Decimal
            Dim decpAporteObl As New Decimal
            Dim decpPrimaSeg As New Decimal
            Dim decpComision As New Decimal
            Dim decpQuinta As New Decimal
            Dim decpTotalDescuento As New Decimal
            Dim decpNeto As New Decimal
            Dim decpESSALUD As New Decimal
            Dim decpSCTR As New Decimal
            Dim decpTotalAportes As New Decimal
            Dim decpTotalAumento As New Decimal

            Me.dgvPlanilla.Rows.Clear()
            For Each _planilla In _planillasCalc
                Me.dgvPlanilla.Rows.Add()
                With dgvPlanilla.Rows(dgvPlanilla.Rows.Count - 1)
                    .Cells(Codigo.Name).Value = _planilla.CodPer
                    .Cells(Empleado.Name).Value = _planilla.NombrePersona
                    .Cells(RemBas.Name).Value = FormatearNumero(_planilla.RemBas, 2)
                    .Cells(Aumento.Name).Value = FormatearNumero(_planilla.Aumento, 2)
                    .Cells(NuevaRem.Name).Value = FormatearNumero(_planilla.NuevaRem, 2)
                    decpRemBasica += (_planilla.NuevaRem)
                    .Cells(AsigFam.Name).Value = FormatearNumero(_planilla.AsiFam, 2)
                    decpAsigFam += _planilla.AsiFam
                    .Cells(RieCaj.Name).Value = FormatearNumero(_planilla.RieCaj, 2)
                    decpRieCaj += _planilla.RieCaj
                    .Cells(TotalIng.Name).Value = FormatearNumero(_planilla.TotIng, 2)
                    decpTotIngreso += _planilla.TotIng
                    decpTotalAumento += _planilla.Aumento
                    .Cells(ONP.Name).Value = FormatearNumero(_planilla.ONP, 2)
                    decpONP += _planilla.ONP
                    .Cells(ApoObl.Name).Value = FormatearNumero(_planilla.ApoObl, 2)
                    decpAporteObl += _planilla.ApoObl
                    .Cells(Prima.Name).Value = FormatearNumero(_planilla.PriSeg, 2)
                    decpPrimaSeg += _planilla.PriSeg
                    .Cells(Comision.Name).Value = FormatearNumero(_planilla.ComVar, 2)
                    decpComision += _planilla.ComVar
                    .Cells(Quinta.Name).Value = FormatearNumero(_planilla.Quinta, 2)
                    decpQuinta += _planilla.Quinta
                    .Cells(TotDes.Name).Value = FormatearNumero(_planilla.TotDes, 2)
                    decpTotalDescuento += _planilla.TotDes
                    .Cells(Neto.Name).Value = FormatearNumero(_planilla.Neto, 2)
                    decpNeto += _planilla.Neto
                    .Cells(Essalud.Name).Value = FormatearNumero(_planilla.Essalud, 2)
                    decpESSALUD += _planilla.Essalud
                    .Cells(SCTR.Name).Value = FormatearNumero(_planilla.SCTR, 2)
                    decpSCTR += _planilla.SCTR
                    .Cells(TotApo.Name).Value = FormatearNumero(_planilla.TotApo, 2)
                    decpTotalAportes += _planilla.TotApo
                End With
            Next

            txtpRemBas.Text = FormatearNumero(decpRemBasica, 2)
            txtpAsigFam.Text = FormatearNumero(decpAsigFam, 2)
            txtpRieCaj.Text = FormatearNumero(decpRieCaj, 2)
            txtpTotIng.Text = FormatearNumero(decpTotIngreso, 2)
            txtpONP.Text = FormatearNumero(decpONP, 2)
            txtpAporteObl.Text = FormatearNumero(decpAporteObl, 2)
            txtpPrimaSeg.Text = FormatearNumero(decpPrimaSeg, 2)
            txtpComision.Text = FormatearNumero(decpComision, 2)
            txtpQuinta.Text = FormatearNumero(decpQuinta, 2)
            txtpTotDesc.Text = FormatearNumero(decpTotalDescuento, 2)
            txtpneto.Text = FormatearNumero(decpNeto, 2)
            txtpESSALUD.Text = FormatearNumero(decpESSALUD, 2)
            txtpSCTR.Text = FormatearNumero(decpSCTR, 2)
            txtpTotAportes.Text = FormatearNumero(decpTotalAportes, 2)
            txtTotalAumento.Text = FormatearNumero(decpTotalAumento, 2)

            txtvRemBas.Text = FormatearNumero(decpRemBasica - decRemBasica, 2)
            txtvAsigFam.Text = FormatearNumero(decpAsigFam - decAsigFam, 2)
            txtvRieCaj.Text = FormatearNumero(decpRieCaj - decRieCaj, 2)
            txtvTotIng.Text = FormatearNumero(decpTotIngreso - decTotIngreso, 2)
            txtvONP.Text = FormatearNumero(decpONP - decONP, 2)
            txtvAporteObl.Text = FormatearNumero(decpAporteObl - decAporteObl, 2)
            txtvPrimaSeg.Text = FormatearNumero(decpPrimaSeg - decPrimaSeg, 2)
            txtvComision.Text = FormatearNumero(decpComision - decComision, 2)
            txtvQuinta.Text = FormatearNumero(decpQuinta - decQuinta, 2)
            txtvTotalDcto.Text = FormatearNumero(decpTotalDescuento - decTotalDescuento, 2)
            txtvNeto.Text = FormatearNumero(decpNeto - decNeto, 2)
            txtvESSALUD.Text = FormatearNumero(decpESSALUD - decESSALUD, 2)
            txtvSCTR.Text = FormatearNumero(decpSCTR - decSCTR, 2)
            txtvTotApo.Text = FormatearNumero(decpTotalAportes - decTotalAportes, 2)
            txtTotalAumento.Text = FormatearNumero(decpTotalAumento - decTotalAumento, 2)
        End If
    End Sub
End Class