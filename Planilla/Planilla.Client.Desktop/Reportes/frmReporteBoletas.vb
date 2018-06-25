Imports Microsoft.Reporting.WinForms

Public Class frmReporteBoletas
    Private Sub frmReporteBoletas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
        'Dim parameters() As ReportParameter = {New ReportParameter("TotalPagoPersonal", modPersonal.strTotalPagoPersonas),
        '    New ReportParameter("AFPMonto", modPersonal.strAFPMonto),
        'New ReportParameter("ONP", modPersonal.strONP),
        'New ReportParameter("ESSALUD", modPersonal.strESSALUD),
        'New ReportParameter("RentaQuinta", modPersonal.strRentaQuinta),
        'New ReportParameter("ADepositar", modPersonal.strADepositar),
        'New ReportParameter("SCTR", modPersonal.strSCTR),
        'New ReportParameter("Periodo", modPersonal.strPeriodo)}
        Dim source As New ReportDataSource("DataSet1", dtBoleta)
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(source)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class