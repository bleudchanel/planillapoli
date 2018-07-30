Public Class frmRepositorioReportevb
    Private Sub frmRepositorioReportevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Public Sub ConstruirReporteBoleta(ByVal dtBase As DataTable, ByVal strTitulo As String)
        Dim repBase As New BoletasCR
        repBase.SetDataSource(dtBase)
        ''repBase.SetParameterValue("Periodicidad", strTitulo)
        Me.CrystalReportViewer1.ReportSource = repBase
        Me.CrystalReportViewer1.Refresh()
    End Sub
End Class