Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmGenerarPlanilla

    Private planillaManager As New PersonalManager
    Private _planillasRemuneracion As List(Of PlanillaRemuneracion)
    Private _planillaActual As PlanillaRemuneracion



#Region "Text Monto"

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemuneracionBasica.KeyDown, txtAsigFam.KeyDown, txtSubsidio.KeyDown, txtGrati.KeyDown, txtRemVacac.KeyDown, txtRiesgoCaja.KeyDown, txtReintegro.KeyDown, txtHorasExtra.KeyDown, txtOtrosIngresos.KeyDown, txtTotalIng.KeyDown, txtONP.KeyDown, txtAporteObl.KeyDown, txtPrimaSeg.KeyDown, txtComVar.KeyDown, txtQuinta.KeyDown, txtOtroDesc.KeyDown, txtTotalDesc.KeyDown, txtNeto.KeyDown, txtESSALUD.KeyDown, txtSCTR.KeyDown
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
        If e.KeyCode = Keys.Enter And oTextBox.Name = txtRemuneracionBasica.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetRemBas(Me.txtRemuneracionBasica.Text)
                VerPlanillaPersona()
            End If
        ElseIf e.KeyCode = Keys.Enter And oTextBox.Name = txtSubsidio.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetSubsidio(Me.txtSubsidio.Text)
                VerPlanillaPersona()
            End If
        ElseIf e.KeyCode = Keys.Enter And oTextBox.Name = txtRemVacac.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetRemVac(Me.txtRemVacac.Text)
                VerPlanillaPersona()
            End If
        ElseIf e.KeyCode = Keys.Enter And oTextBox.Name = txtHorasExtra.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetHE(Me.txtHorasExtra.Text)
                VerPlanillaPersona()
            End If
        ElseIf e.KeyCode = Keys.Enter And oTextBox.Name = txtOtrosIngresos.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetOtroIng(Me.txtOtrosIngresos.Text)
                VerPlanillaPersona()
            End If
        ElseIf e.KeyCode = Keys.Enter And oTextBox.Name = txtQuinta.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetQuinta(Me.txtQuinta.Text)
                VerPlanillaPersona()
            End If
        ElseIf e.KeyCode = Keys.Enter And oTextBox.Name = txtOtroDesc.Name Then
            If _planillaActual IsNot Nothing Then
                _planillaActual.SetOtroDescuento(Me.txtOtroDesc.Text)
                VerPlanillaPersona()
            End If
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemuneracionBasica.KeyPress, txtAsigFam.KeyPress, txtSubsidio.KeyPress, txtGrati.KeyPress, txtRemVacac.KeyPress, txtRiesgoCaja.KeyPress, txtReintegro.KeyPress, txtHorasExtra.KeyPress, txtOtrosIngresos.KeyPress, txtTotalIng.KeyPress, txtONP.KeyPress, txtAporteObl.KeyPress, txtPrimaSeg.KeyPress, txtComVar.KeyPress, txtQuinta.KeyPress, txtOtroDesc.KeyPress, txtTotalDesc.KeyPress, txtNeto.KeyPress, txtESSALUD.KeyPress, txtSCTR.KeyPress

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

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemuneracionBasica.Leave, txtAsigFam.Leave, txtSubsidio.Leave, txtGrati.Leave, txtRemVacac.Leave, txtRiesgoCaja.Leave, txtReintegro.Leave, txtHorasExtra.Leave, txtOtrosIngresos.Leave, txtTotalIng.Leave, txtONP.Leave, txtAporteObl.Leave, txtPrimaSeg.Leave, txtComVar.Leave, txtQuinta.Leave, txtOtroDesc.Leave, txtTotalDesc.Leave, txtNeto.Leave, txtESSALUD.Leave, txtSCTR.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.00"
        End If
        If _planillaActual IsNot Nothing Then
            If oTextBox.Name = txtRemuneracionBasica.Name Then
                If CDec(txtRemuneracionBasica.Text) <> _planillaActual.RemBas Then
                    txtRemuneracionBasica.Text = FormatearNumero(_planillaActual.RemBas, 2)
                End If
            ElseIf oTextBox.Name = txtSubsidio.Name Then
                If CDec(txtSubsidio.Text) <> _planillaActual.Subsidio Then
                    txtSubsidio.Text = FormatearNumero(_planillaActual.Subsidio, 2)
                End If
            ElseIf oTextBox.Name = txtRemVacac.Name Then
                If CDec(txtRemVacac.Text) <> _planillaActual.RemVac Then
                    txtRemVacac.Text = FormatearNumero(_planillaActual.RemVac, 2)
                End If
            ElseIf oTextBox.Name = txtHorasExtra.Name Then
                If CDec(txtHorasExtra.Text) <> _planillaActual.HE Then
                    txtHorasExtra.Text = FormatearNumero(_planillaActual.HE, 2)
                End If
            ElseIf oTextBox.Name = txtHorasExtra.Name Then
                If CDec(txtHorasExtra.Text) <> _planillaActual.HE Then
                    txtHorasExtra.Text = FormatearNumero(_planillaActual.HE, 2)
                End If
            ElseIf oTextBox.Name = txtOtrosIngresos.Name Then
                If CDec(txtOtrosIngresos.Text) <> _planillaActual.OtrIng Then
                    txtOtrosIngresos.Text = FormatearNumero(_planillaActual.OtrIng, 2)
                End If
            ElseIf oTextBox.Name = txtQuinta.Name Then
                If CDec(txtQuinta.Text) <> _planillaActual.Quinta Then
                    txtQuinta.Text = FormatearNumero(_planillaActual.Quinta, 2)
                End If
            ElseIf oTextBox.Name = txtOtroDesc.Name Then
                If CDec(txtOtroDesc.Text) <> _planillaActual.OtrDes Then
                    txtOtroDesc.Text = FormatearNumero(_planillaActual.OtrDes, 2)
                End If
            End If


        End If


    End Sub





#End Region


    Private Sub frmGenerarPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProcComboBoxAMes(cmbMes)
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
        ControlesEnLoad()
    End Sub


    Private Sub ControlesEnLoad()
        Me.grpControles.Enabled = False
        Me.grpIncapacidad.Enabled = False
        ''Me.grpPeriodoVacaciones.Enabled = False
        btnAddEjecucion.Enabled = False
        Me.grpVacaciones.Enabled = False
        Me.grpPlanilla.Enabled = False
        Me.grpSinGoce.Enabled = False
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


    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue)
            Listar()
        End If
    End Sub

    'Async Sub RefreshDatos()
    '    Dim data = ParsePeriodo(_planillaActual.Periodo)
    '    _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(data.Item1, data.Item2)
    'End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue)
            Listar()
        Catch ex As Exception
            Notificar(ex.Message)
        End Try
    End Sub

    Private Sub dgvPlanilla_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPlanilla.KeyDown
        If e.KeyCode = Keys.Enter Then
            MostrarEnPlanilla()
        End If
    End Sub

    Sub MostrarEnPlanilla()
        Me.dgvVacaciones.Rows.Clear()
        If dgvPlanilla.CurrentRow IsNot Nothing AndAlso dgvPlanilla.Rows.Count > 0 Then
            Dim IdPlanillaActual As Integer = Me.dgvPlanilla.CurrentRow.Cells.Item(IdPlanilla.Name).Value
            _planillaActual = New PlanillaRemuneracion((From o In _planillasRemuneracion Where o.IdPlanilla = IdPlanillaActual Select o).FirstOrDefault())
            VerPlanillaPersona()
            Me.grpPlanilla.Enabled = False
            Me.grpControles.Enabled = True
            Me.dgvPlanilla.Enabled = False
            Me.btnGuardar.Enabled = False
            Me.btnAddEjecucion.Enabled = False
            Me.btnGenerar.Enabled = False
            Me.btnCerrarPlanilla.Enabled = False

            Me.dgvVacaciones.Rows.Add()
            With Me.dgvVacaciones.Rows(Me.dgvVacaciones.Rows.Count - 1)
                .Cells(Vacaciones.Name).Value = "Programado"
                .Cells(Inicio.Name).Value = _planillaActual.VacacionesPeriodo.IniProg
                .Cells(Fin.Name).Value = _planillaActual.VacacionesPeriodo.FinProg
            End With

            Me.dgvVacaciones.Rows.Add()
            With Me.dgvVacaciones.Rows(Me.dgvVacaciones.Rows.Count - 1)
                .Cells(Vacaciones.Name).Value = "Ejecutado1"
                .Cells(Inicio.Name).Value = _planillaActual.VacacionesPeriodo.IniEje1
                .Cells(Fin.Name).Value = _planillaActual.VacacionesPeriodo.FinEje1
            End With

            Me.dgvVacaciones.Rows.Add()
            With Me.dgvVacaciones.Rows(Me.dgvVacaciones.Rows.Count - 1)
                .Cells(Vacaciones.Name).Value = "Ejecutado2"
                .Cells(Inicio.Name).Value = _planillaActual.VacacionesPeriodo.IniEje2
                .Cells(Fin.Name).Value = _planillaActual.VacacionesPeriodo.FinEje2
            End With

            Me.dgvVacaciones.Rows.Add()
            With Me.dgvVacaciones.Rows(Me.dgvVacaciones.Rows.Count - 1)
                .Cells(Vacaciones.Name).Value = "Ejecutado3"
                .Cells(Inicio.Name).Value = _planillaActual.VacacionesPeriodo.IniEje3
                .Cells(Fin.Name).Value = _planillaActual.VacacionesPeriodo.FinEje3
            End With
        End If
    End Sub

    Private Sub UpdateUnico(IdPlanillaRemuneracion As Integer)
        If dgvPlanilla.Rows.Count > 0 AndAlso _planillaActual IsNot Nothing Then
            Dim Ubicacion As Integer = 0
            For i As Integer = 0 To dgvPlanilla.Rows.Count - 1
                If dgvPlanilla.Rows(i).Cells.Item(IdPlanilla.Name).Value = IdPlanillaRemuneracion Then
                    Ubicacion = i
                    Exit For
                End If
            Next

            If Ubicacion > 0 Then
                With dgvPlanilla.Rows(Ubicacion)
                    .Cells(IdPlanilla.Name).Value = _planillaActual.IdPlanilla
                    .Cells(Periodo.Name).Value = _planillaActual.Periodo
                    .Cells(Codigo.Name).Value = _planillaActual.CodPer
                    .Cells(Empleado.Name).Value = _planillaActual.NombrePersona
                    .Cells(RemBas.Name).Value = FormatearNumero(_planillaActual.RemBas, 2)
                    .Cells(AsigFam.Name).Value = FormatearNumero(_planillaActual.AsiFam, 2)
                    .Cells(Subsidio.Name).Value = FormatearNumero(_planillaActual.Subsidio, 2)
                    .Cells(Gratif.Name).Value = FormatearNumero(_planillaActual.Gratif, 2)
                    .Cells(RemVac.Name).Value = FormatearNumero(_planillaActual.RemVac, 2)
                    .Cells(RieCaj.Name).Value = FormatearNumero(_planillaActual.RieCaj, 2)
                    .Cells(Reinteg.Name).Value = FormatearNumero(_planillaActual.Reinte, 2)
                    .Cells(HE.Name).Value = FormatearNumero(_planillaActual.HE, 2)
                    .Cells(OtrosIng.Name).Value = FormatearNumero(_planillaActual.OtrIng, 2)
                    .Cells(TotalIng.Name).Value = FormatearNumero(_planillaActual.TotIng, 2)
                    .Cells(ONP.Name).Value = FormatearNumero(_planillaActual.ONP, 2)
                    .Cells(ApoObl.Name).Value = FormatearNumero(_planillaActual.ApoObl, 2)
                    .Cells(Prima.Name).Value = FormatearNumero(_planillaActual.PriSeg, 2)
                    .Cells(Comision.Name).Value = FormatearNumero(_planillaActual.ComVar, 2)
                    .Cells(Quinta.Name).Value = FormatearNumero(_planillaActual.Quinta, 2)
                    .Cells(OtroDes.Name).Value = FormatearNumero(_planillaActual.OtrDes, 2)
                    .Cells(TotDes.Name).Value = FormatearNumero(_planillaActual.TotDes, 2)
                    .Cells(Neto.Name).Value = FormatearNumero(_planillaActual.Neto, 2)
                    .Cells(Essalud.Name).Value = FormatearNumero(_planillaActual.Essalud, 2)
                    .Cells(SCTR.Name).Value = FormatearNumero(_planillaActual.SCTR, 2)
                    .Cells(TotApo.Name).Value = FormatearNumero(_planillaActual.TotApo, 2)
                    .Cells(DiasLab.Name).Value = _planillaActual.DiasLab
                    .Cells(HorasLab.Name).Value = _planillaActual.HorasLab
                    .Cells(IniVac.Name).Value = _planillaActual.IniVac
                    .Cells(FinVac.Name).Value = _planillaActual.FinVac
                    .Cells(IniIncap.Name).Value = _planillaActual.IniIncapacidad
                    .Cells(FinIncap.Name).Value = _planillaActual.FinIncapacidad
                    .Cells(IniSGH.Name).Value = _planillaActual.InicioSinGoceHaber
                    .Cells(FinSGH.Name).Value = _planillaActual.FinSinGoceHaber
                    .Cells(Cerrado.Name).Value = _planillaActual.Cerrado
                End With
                'Dim task = New Task(AddressOf RefreshDatos)
                'task.Start()

                Me.dgvPlanilla.CurrentCell = dgvPlanilla.Item(2, Ubicacion)
                ''Me.dgvPlanilla.FirstDisplayedScrollingRowIndex = Ubicacion
            Else
                _planillasRemuneracion = planillaManager.GetPlanillaPeriodo(txtAnioAProgramar.Text, cmbMes.SelectedValue)
                Listar()
            End If
        End If
    End Sub

    Private Sub VerPlanillaPersona()
        If _planillaActual IsNot Nothing Then
            ClearGroup(grpPlanilla)

            Me.grpPlanilla.Text = _planillaActual.CodPer & " : " & _planillaActual.NombrePersona
            Me.txtRemuneracionBasica.Text = FormatearNumero(_planillaActual.RemBas, 2)
            Me.txtAsigFam.Text = FormatearNumero(_planillaActual.AsiFam, 2)
            Me.txtSubsidio.Text = FormatearNumero(_planillaActual.Subsidio, 2)
            Me.txtGrati.Text = FormatearNumero(_planillaActual.Gratif, 2)
            Me.txtRemVacac.Text = FormatearNumero(_planillaActual.RemVac, 2)
            Me.txtRiesgoCaja.Text = FormatearNumero(_planillaActual.RieCaj, 2)
            Me.txtReintegro.Text = FormatearNumero(_planillaActual.Reinte, 2)
            Me.txtHorasExtra.Text = FormatearNumero(_planillaActual.HE, 2)
            Me.txtOtrosIngresos.Text = FormatearNumero(_planillaActual.OtrIng, 2)
            Me.txtTotalIng.Text = FormatearNumero(_planillaActual.TotIng, 2)
            Me.txtONP.Text = FormatearNumero(_planillaActual.ONP, 2)
            Me.txtAporteObl.Text = FormatearNumero(_planillaActual.ApoObl, 2)
            Me.txtPrimaSeg.Text = FormatearNumero(_planillaActual.PriSeg, 2)
            Me.txtComVar.Text = FormatearNumero(_planillaActual.ComVar, 2)
            Me.txtQuinta.Text = FormatearNumero(_planillaActual.Quinta, 2)
            Me.txtOtroDesc.Text = FormatearNumero(_planillaActual.OtrDes, 2)
            Me.txtTotalDesc.Text = FormatearNumero(_planillaActual.TotDes, 2)
            Me.txtNeto.Text = FormatearNumero(_planillaActual.Neto, 2)
            Me.txtESSALUD.Text = FormatearNumero(_planillaActual.Essalud, 2)
            Me.txtSCTR.Text = FormatearNumero(_planillaActual.SCTR, 2)
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Me.grpPlanilla.Enabled = True
        Me.btnGuardar.Enabled = True
        Me.btnModificar.Enabled = False
        If _planillaActual.VacacionesPeriodo.IniProg IsNot Nothing Then
            Me.btnAddEjecucion.Enabled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.btnGuardar.Enabled = True
        Me.btnCancelar.Enabled = True
        Me.btnModificar.Enabled = True
        Me.grpPlanilla.Enabled = False
        Me.grpControles.Enabled = False
        Me.dgvPlanilla.Enabled = True
        Me.btnCerrarPlanilla.Enabled = True
        Me.btnGenerar.Enabled = True
        Me.dgvVacaciones.Rows.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If _planillaActual IsNot Nothing Then
            _planillaActual = planillaManager.UpdatePlanilla(_planillaActual)
            ''Dim base = _planillasRemuneracion.Find(From o In _planillasRemuneracion Where o.IdPlanilla = _planillaActual.IdPlanilla Select o)
            ''  base = _planillaActual
            For i As Integer = 0 To _planillasRemuneracion.Count - 1
                If _planillasRemuneracion(i).IdPlanilla = _planillaActual.IdPlanilla Then
                    _planillasRemuneracion(i) = _planillaActual
                End If
            Next
            UpdateUnico(_planillaActual.IdPlanilla)
        End If
        Me.btnModificar.Enabled = True
        Me.btnGuardar.Enabled = True
        Me.btnCancelar.Enabled = True
        Me.grpControles.Enabled = False
        Me.grpPlanilla.Enabled = False
        Me.dgvPlanilla.Enabled = True
        Me.btnCerrarPlanilla.Enabled = True
        Me.btnGenerar.Enabled = True
        Me.dgvVacaciones.Rows.Clear()
    End Sub

    Private Sub dgvPlanilla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlanilla.CellDoubleClick
        MostrarEnPlanilla()
    End Sub

    Private Sub btnAddEjecucion_Click(sender As Object, e As EventArgs) Handles btnAddEjecucion.Click
        Me.grpVacaciones.Enabled = True

        Dim tuple = ParsePeriodo(_planillaActual.Periodo)
        Dim Fechas = fncInicioFinMes(tuple.Item1, tuple.Item2)
        Me.dtpInicioVacaciones.Value = Fechas.Item(0)
        Me.dtpFinVacaciones.Value = Fechas.Item(1)
    End Sub

    Private Sub btnGuardarVacaciones_Click(sender As Object, e As EventArgs) Handles btnGuardarVacaciones.Click
        MsgBox("Actualice Remuneración Básica. Presione ENTER luego de hacer un cambio.")
        Me.grpVacaciones.Enabled = False
        Me.ActiveControl = Me.txtRemuneracionBasica

        If _planillaActual.VacacionesPeriodo.IniEje1 Is Nothing Then
            _planillaActual.VacacionesPeriodo.IniEje1 = dtpInicioVacaciones.Value
            _planillaActual.VacacionesPeriodo.FinEje1 = dtpFinVacaciones.Value
            _planillaActual.IniVac = dtpInicioVacaciones.Value
            _planillaActual.FinVac = dtpFinVacaciones.Value
        ElseIf _planillaActual.VacacionesPeriodo.IniEje2 Is Nothing Then
            _planillaActual.VacacionesPeriodo.IniEje2 = dtpInicioVacaciones.Value
            _planillaActual.VacacionesPeriodo.FinEje2 = dtpFinVacaciones.Value
            _planillaActual.IniVac = dtpInicioVacaciones.Value
            _planillaActual.FinVac = dtpFinVacaciones.Value
        ElseIf _planillaActual.VacacionesPeriodo.IniEje3 Is Nothing Then
            _planillaActual.VacacionesPeriodo.IniEje3 = dtpInicioVacaciones.Value
            _planillaActual.VacacionesPeriodo.FinEje3 = dtpFinVacaciones.Value
            _planillaActual.IniVac = dtpInicioVacaciones.Value
            _planillaActual.FinVac = dtpFinVacaciones.Value
        Else
            MsgBox("Todas las ejecuciones de vacaciones para esta persona están completas.")
        End If

    End Sub

    Private Sub btnIncapacidad_Click(sender As Object, e As EventArgs) Handles btnIncapacidad.Click
        Me.grpIncapacidad.Enabled = True
        Me.ActiveControl = Me.dtpInicioIncapacidad
    End Sub

    Private Sub btnSinGoce_Click(sender As Object, e As EventArgs) Handles btnSinGoce.Click
        Me.grpSinGoce.Enabled = True
        Me.ActiveControl = Me.dtpInicioDiasSinGoce
    End Sub

    Private Sub btnGuardarPerIncapacidad_Click(sender As Object, e As EventArgs) Handles btnGuardarPerIncapacidad.Click
        MsgBox("Actualice Remuneración Básica. Presione ENTER luego de hacer un cambio.")
        _planillaActual.IniIncapacidad = dtpInicioIncapacidad.Value
        _planillaActual.FinIncapacidad = dtpFinIncapacidad.Value
        Me.grpIncapacidad.Enabled = False
        Me.ActiveControl = Me.txtRemuneracionBasica
    End Sub

    Private Sub btnGuardarPerDiasSinGoce_Click(sender As Object, e As EventArgs) Handles btnGuardarPerDiasSinGoce.Click
        MsgBox("Actualice Remuneración Básica. Presione ENTER luego de hacer un cambio.")
        _planillaActual.InicioSinGoceHaber = dtpInicioDiasSinGoce.Value
        _planillaActual.FinSinGoceHaber = dtpFinDiasSinGoce.Value
        Me.grpSinGoce.Enabled = False
        Me.ActiveControl = Me.txtRemuneracionBasica
    End Sub

    Private Sub btnCerrarPlanilla_Click(sender As Object, e As EventArgs) Handles btnCerrarPlanilla.Click
        For Each var In _planillasRemuneracion
            var.Cerrado = "V"
            var = planillaManager.UpdatePlanilla(var)
        Next
        Notificar("Se ha cerrado la planilla.")
        Listar()
    End Sub

    Private Sub txtAnioAProgramar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnioAProgramar.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If dgvPlanilla.Rows.Count > 0 Then
            Dim dtEx = DataGridViewToDataTable(dgvPlanilla, New List(Of String)(New String() {"IdPersonal"}), "Honk")
            FncDataTable2Excel(dtEx, "Planilla")
        End If

    End Sub

    'Private Sub dgvPlanilla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlanilla.CellDoubleClick
    '    If dgvPlanilla.CurrentRow IsNot Nothing AndAlso dgvPlanilla.Rows.Count > 0 Then
    '        Dim IdPlanillaActual As Integer = Me.dgvPlanilla.CurrentRow.Cells.Item(IdPlanilla.Name).Value
    '        _planillaActual = (From o In _planillasRemuneracion Where o.IdPlanilla = IdPlanillaActual Select o).FirstOrDefault()
    '        VerPlanillaPersona()
    '    End If
    'End Sub
End Class