Imports Microsoft.Reporting.WinForms

Public Class frmReporteResumenPlanilla
    Private Sub frmReporteResumenPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
        Dim parameters() As ReportParameter = {New ReportParameter("TotalPagoPersonal", modPersonal.strTotalPagoPersonas),
            New ReportParameter("AFPMonto", modPersonal.strAFPMonto),
        New ReportParameter("ONP", modPersonal.strONP),
        New ReportParameter("ESSALUD", modPersonal.strESSALUD),
        New ReportParameter("RentaQuinta", modPersonal.strRentaQuinta),
        New ReportParameter("ADepositar", modPersonal.strADepositar),
        New ReportParameter("SCTR", modPersonal.strSCTR),
        New ReportParameter("Periodo", modPersonal.strPeriodo)}
        Me.ReportViewer1.LocalReport.SetParameters(parameters)
        Me.ReportViewer1.RefreshReport()
        ''parameters(0) = New ReportParameter("TotalPagoPersonal", modPersonal.strTotalPagoPersonas)

    End Sub
End Class