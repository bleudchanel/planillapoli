Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net
Imports System.Text

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
        pdtEstructruraBasic()
        pdtEstructruraComplete()
    End Sub


    Private Sub pdtEstructruraComplete()
        If _planillasRemuneracion Is Nothing Or _planillasRemuneracion.Count = 0 Then
            MsgBox("No existe informacion para la generacion del archivo")
            Exit Sub
        End If


        ''''''''''''''''''''''''''''''''''GENERAR A PARTIR DE GRILLA'''''''''''''''''''''''''''''''''''''''
        Dim strLinea As String = String.Empty
        Dim swrArchivo As System.IO.StreamWriter
        Dim strNombreArchivo As String = String.Empty
        Dim sfdGuardarArchivo As New SaveFileDialog

        If _planillasRemuneracion.Count > 0 Then
            strNombreArchivo = "0601" & _planillasRemuneracion.Item(0).Periodo & "20339833011"  '"LE20119917698" & CmbAnio.Text & If(CmbMes.SelectedValue.ToString < 10, "0" & CmbMes.SelectedValue.ToString, CmbMes.SelectedValue.ToString) & "00140100001" & "1" & "11"
        Else
            strNombreArchivo = "TxtCuarta"  '"LE20119917698" & CmbAnio.Text & If(CmbMes.SelectedValue.ToString < 10, "0" & CmbMes.SelectedValue.ToString, CmbMes.SelectedValue.ToString) & "00140100001" & "0" & "11"
        End If

        sfdGuardarArchivo.Title = "GENERAR ARCHIVO DE TEXTO REGISTRO VENTAS E INGRESOS"
        sfdGuardarArchivo.FileName = strNombreArchivo
        sfdGuardarArchivo.Filter = "Archivos de renta de cuarta (*.rem)|*.rem"
        sfdGuardarArchivo.FilterIndex = 1
        sfdGuardarArchivo.RestoreDirectory = True


        Dim nombres As String()
        Dim Ap As String
        Dim Am As String
        Dim Nombre As String = ""

        If sfdGuardarArchivo.ShowDialog = DialogResult.OK Then
            swrArchivo = New System.IO.StreamWriter(sfdGuardarArchivo.OpenFile, Encoding.Default)
            If (swrArchivo IsNot Nothing) Then
                If _planillasRemuneracion.Count > 0 Then
                    For Each _planilla In _planillasRemuneracion

                        If _planilla.RemBas IsNot Nothing AndAlso _planilla.RemBas > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0121|" & Format(_planilla.RemBas, "#.##") & "|" & Format(_planilla.RemBas, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.RemVac IsNot Nothing AndAlso _planilla.RemVac > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0118|" & Format(_planilla.RemVac, "#.##") & "|" & Format(_planilla.RemVac, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.AsiFam IsNot Nothing AndAlso _planilla.AsiFam > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0201|" & Format(_planilla.AsiFam, "#.##") & "|" & Format(_planilla.AsiFam, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.RieCaj IsNot Nothing AndAlso _planilla.RieCaj > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0304|" & Format(_planilla.RieCaj, "#.##") & "|" & Format(_planilla.RieCaj, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.ComVar IsNot Nothing AndAlso _planilla.ComVar > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0601|" & Format(_planilla.ComVar, "#.##") & "|" & Format(_planilla.ComVar, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.PriSeg IsNot Nothing AndAlso _planilla.PriSeg > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0606|" & Format(_planilla.PriSeg, "#.##") & "|" & Format(_planilla.PriSeg, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.ApoObl IsNot Nothing AndAlso _planilla.ApoObl > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0608|" & Format(_planilla.ApoObl, "#.##") & "|" & Format(_planilla.ApoObl, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        If _planilla.Quinta IsNot Nothing AndAlso _planilla.Quinta > 0 Then
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0605|" & Format(_planilla.Quinta, "#.##") & "|" & Format(_planilla.Quinta, "#.##")
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        Else
                            strLinea = strLinea & "01|" & _planilla.Dni & "|0605|0|0"
                            swrArchivo.WriteLine(strLinea)
                            strLinea = String.Empty
                        End If

                        ''strLinea = strLinea & "01|" & _planilla.Dni & "|" & _planilla.HorasLab * _planilla.DiasLab & "|0|0|0|"
                        '    If(dvrRegistroVentaIngreso.Cells("RucDni").Value.ToString.Length = 11, "06", "01") & "|" &
                        '                    dvrRegistroVentaIngreso.Cells("RucDni").Value.ToString & "|" &
                        '                 Ap & "|" &
                        '                 Am & "|" &
                        '               RTrim(LTrim(Nombre)) & "|" &
                        '                "1|" &
                        '                "0|"
                        'Nombre = ""
                        'swrArchivo.WriteLine(strLinea)
                        'strLinea = String.Empty
                    Next
                End If

                swrArchivo.Close()
            End If
            MessageBox.Show("Generación Completa.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub pdtEstructruraBasic()
        If _planillasRemuneracion Is Nothing Or _planillasRemuneracion.Count = 0 Then
            MsgBox("No existe informacion para la generacion del archivo")
            Exit Sub
        End If


        ''''''''''''''''''''''''''''''''''GENERAR A PARTIR DE GRILLA'''''''''''''''''''''''''''''''''''''''
        Dim strLinea As String = String.Empty
        Dim swrArchivo As System.IO.StreamWriter
        Dim strNombreArchivo As String = String.Empty
        Dim sfdGuardarArchivo As New SaveFileDialog

        If _planillasRemuneracion.Count > 0 Then
            strNombreArchivo = "0601" & _planillasRemuneracion.Item(0).Periodo & "20339833011"  '"LE20119917698" & CmbAnio.Text & If(CmbMes.SelectedValue.ToString < 10, "0" & CmbMes.SelectedValue.ToString, CmbMes.SelectedValue.ToString) & "00140100001" & "1" & "11"
        Else
            strNombreArchivo = "TxtCuarta"  '"LE20119917698" & CmbAnio.Text & If(CmbMes.SelectedValue.ToString < 10, "0" & CmbMes.SelectedValue.ToString, CmbMes.SelectedValue.ToString) & "00140100001" & "0" & "11"
        End If

        sfdGuardarArchivo.Title = "GENERAR ARCHIVO DE TEXTO REGISTRO VENTAS E INGRESOS"
        sfdGuardarArchivo.FileName = strNombreArchivo
        sfdGuardarArchivo.Filter = "Archivos de renta de cuarta (*.jor)|*.jor"
        sfdGuardarArchivo.FilterIndex = 1
        sfdGuardarArchivo.RestoreDirectory = True


        Dim nombres As String()
        Dim Ap As String
        Dim Am As String
        Dim Nombre As String = ""

        If sfdGuardarArchivo.ShowDialog = DialogResult.OK Then
            swrArchivo = New System.IO.StreamWriter(sfdGuardarArchivo.OpenFile, Encoding.Default)
            If (swrArchivo IsNot Nothing) Then
                If _planillasRemuneracion.Count > 0 Then
                    For Each _planilla In _planillasRemuneracion
                        ' NUEVO

                        'nombres = dvrRegistroVentaIngreso.Cells("Razon").Value.ToString.Split(" ")

                        'Ap = nombres(0)
                        'Am = nombres(1)
                        'If Am = "-" Then
                        '    Am = ""
                        'End If

                        'For i As Integer = 2 To nombres.Length - 1
                        '    Nombre = Nombre & nombres(i)
                        '    If i < nombres.Length Then
                        '        Nombre = Nombre & " "
                        '    End If
                        'Next

                        strLinea = strLinea & "01|" & _planilla.Dni & "|" & _planilla.HorasLab * _planilla.DiasLab & "|0|0|0|"
                        '    If(dvrRegistroVentaIngreso.Cells("RucDni").Value.ToString.Length = 11, "06", "01") & "|" &
                        '                    dvrRegistroVentaIngreso.Cells("RucDni").Value.ToString & "|" &
                        '                 Ap & "|" &
                        '                 Am & "|" &
                        '               RTrim(LTrim(Nombre)) & "|" &
                        '                "1|" &
                        '                "0|"
                        'Nombre = ""
                        swrArchivo.WriteLine(strLinea)
                        strLinea = String.Empty
                    Next
                End If

                swrArchivo.Close()
            End If
            MessageBox.Show("Generación Completa.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class