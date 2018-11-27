Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmProcedimientoLaboratorio

    Private bolEsModificar = False
    Private variablesManager As New VariablesManager
    Private especialidadManager As New EspecialidadManager
    Private _procedimientos As IEnumerable(Of Procedimiento)
    Private _especialidades As IEnumerable(Of Especialidad)
    Private _procedimientoActual As Procedimiento



#Region "Text Monto"

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMontoMedico.KeyDown, txtPrecioProcedimiento.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoMedico.KeyPress, txtMontoMedico.KeyPress

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

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontoMedico.Leave, txtPrecioProcedimiento.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.00"
        End If
    End Sub





#End Region


    Private Sub frmProcedimientoLaboratorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _especialidades = especialidadManager.GetEspecialidades()
        _procedimientos = variablesManager.GetProcedimientosLaboratorio()
        Controles_En_Load()

        Dim dtAreaLab As New DataTable
        dtAreaLab.Columns.Add("Descripcion", GetType(String))
        dtAreaLab.Columns.Add("Id", GetType(String))
        dtAreaLab.Rows.Add("ANATOMIA PATOLOGICA", "G")
        dtAreaLab.Rows.Add("BIOQUIMICA", "B")
        dtAreaLab.Rows.Add("HEMATOLOGIA", "H")
        dtAreaLab.Rows.Add("INMUNOLOGIA", "I")
        dtAreaLab.Rows.Add("MICROBIOLOGIA", "M")
        dtAreaLab.Rows.Add("ORINA COMPLETA", "O")
        dtAreaLab.Rows.Add("PARASITOLOGIA", "P")
        dtAreaLab.Rows.Add("VARIOS", "V")
        dtAreaLab.Rows.Add("VARIOS PROCEDIMIENTOS", "X")

        Me.cmbAreaLaboratorio.DataSource = dtAreaLab
        Me.cmbAreaLaboratorio.DisplayMember = "Descripcion"
        Me.cmbAreaLaboratorio.ValueMember = "Id"

        Dim dtConsultaPro As New DataTable
        dtConsultaPro.Columns.Add("Id", GetType(Integer))
        dtConsultaPro.Columns.Add("Descripcion", GetType(String))
        dtConsultaPro.Rows.Add(43, "Consulta")
        dtConsultaPro.Rows.Add(44, "Procedimiento")



        Me.cmbConsultaPro.DataSource = dtConsultaPro
        Me.cmbConsultaPro.DisplayMember = "Descripcion"
        Me.cmbConsultaPro.ValueMember = "Id"

        Dim dtEspecialidades As New DataTable
        dtEspecialidades.Columns.Add("IdEspecialidad", GetType(Integer))
        dtEspecialidades.Columns.Add("Descripcion", GetType(String))
        For Each _espe In _especialidades
            dtEspecialidades.Rows.Add(_espe.IdEspecialidad, _espe.Descripcion)
            ''Me.cmbEspecialidad.Items.Add(_espe)
        Next

        Me.cmbEspecialidad.DataSource = dtEspecialidades
        Me.cmbEspecialidad.DisplayMember = "Descripcion"
        Me.cmbEspecialidad.ValueMember = "IdEspecialidad"

        Me.ActiveControl = Me.txtBusqueda

    End Sub

    Sub Controles_En_Load()
        ClearGroup(grpManagement)
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)
        ListaEspecialidades()
        bolEsModificar = False
        Me.ActiveControl = Me.txtBusqueda
        _procedimientoActual = New Procedimiento()
    End Sub



    Sub ListaEspecialidades()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each _proce In _procedimientos
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells(IdProcedimiento.Name).Value = _proce.IdProcedimiento
                .Cells(CodPro.Name).Value = _proce.CodPro
                .Cells(TipPro.Name).Value = If(_proce.TipPro = 43, "C", "P")
                .Cells(Procedimiento.Name).Value = _proce.Procedimiento1
                .Cells(IdEspecialidad.Name).Value = _proce.IdEspecialidad
                .Cells(CodEsp.Name).Value = _proce.CodEsp
                .Cells(PrecioProcedimiento.Name).Value = _proce.PrecioProcedimiento
                .Cells(MontoMedico.Name).Value = _proce.MontoMedico
                .Cells(Observacion.Name).Value = _proce.Observacion
                .Cells(ProImprimir.Name).Value = _proce.ProImprimir
                .Cells(AreaLaboratorio.Name).Value = _proce.AreaLaboratorio
            End With
        Next

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPagoDctoBasico.CurrentRow IsNot Nothing Then

            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)

            ClearGroup(grpManagement)
            Dim IdProcedimiento = Me.dgvPagoDctoBasico.CurrentRow.Cells.Item("IdProcedimiento").Value
            _procedimientoActual = (From a In _procedimientos
                                    Where a.IdProcedimiento = IdProcedimiento
                                    Select a).FirstOrDefault()

            bolEsModificar = True
            RegistroData()
        End If
    End Sub

    Private Sub RegistroData()

        If _procedimientoActual IsNot Nothing AndAlso _procedimientoActual.IdProcedimiento > 0 Then

            Me.txtCodigo.Text = _procedimientoActual.CodPro
            Me.txtProcedimiento.Text = _procedimientoActual.Procedimiento1
            Me.txtMontoMedico.Text = FormatearNumero(_procedimientoActual.MontoMedico, 2)
            Me.txtPrecioProcedimiento.Text = FormatearNumero(_procedimientoActual.PrecioProcedimiento, 2)
            Me.cmbConsultaPro.SelectedValue = _procedimientoActual.TipPro
            Me.cmbAreaLaboratorio.SelectedValue = _procedimientoActual.AreaLaboratorio
            Me.cmbEspecialidad.SelectedValue = _procedimientoActual.IdEspecialidad
            Me.txtNombreCorto.Text = _procedimientoActual.ProImprimir
            Me.txtObservacion.Text = _procedimientoActual.Observacion

            'Me.txtEspecialidad.Text = _especialidadActual.Descripcion
            'Me.txtMontoMedico.Text = FormatearNumero(_especialidadActual.MontoMedico, 2)
            'Me.txtPrecioConsulta.Text = FormatearNumero(_especialidadActual.PrecioConsulta, 2)
        End If


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Controles_En_Load()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bolEsModificar = False
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If bolEsModificar = True Then

            _procedimientoActual.Procedimiento1 = txtProcedimiento.Text
            _procedimientoActual.MontoMedico = txtMontoMedico.Text
            _procedimientoActual.PrecioProcedimiento = txtPrecioProcedimiento.Text
            _procedimientoActual.IdEspecialidad = Me.cmbEspecialidad.SelectedValue
            Dim var = (From a In _especialidades Where a.IdEspecialidad = _procedimientoActual.IdEspecialidad).FirstOrDefault()
            _procedimientoActual.CodEsp = var.CodEsp
            _procedimientoActual.Observacion = Me.txtObservacion.Text
            _procedimientoActual.ProImprimir = Me.txtNombreCorto.Text
            _procedimientoActual.TipPro = Me.cmbConsultaPro.SelectedValue
            _procedimientoActual.AreaLaboratorio = Me.cmbAreaLaboratorio.SelectedValue
            Dim proc = variablesManager.RegistrarProcedimiento(_procedimientoActual)
            'Notificar(especialidad.CodEsp & ": Modificado", "")
        Else
            Dim var = (From a In _especialidades Where a.IdEspecialidad = Me.cmbEspecialidad.SelectedValue).FirstOrDefault()
            Dim nuevoProcedimiento As Procedimiento = New Procedimiento(Me.cmbConsultaPro.SelectedValue, Me.txtProcedimiento.Text, Me.cmbEspecialidad.SelectedValue,
                var.CodEsp, Me.txtPrecioProcedimiento.Text, Me.txtMontoMedico.Text, Me.txtObservacion.Text, Me.txtNombreCorto.Text)
            nuevoProcedimiento.AreaLaboratorio = cmbAreaLaboratorio.SelectedValue
            Dim proc = variablesManager.RegistrarProcedimiento(nuevoProcedimiento)
        End If
        _especialidades = especialidadManager.GetEspecialidades()
        _procedimientos = variablesManager.GetProcedimientosLaboratorio()
        Controles_En_Load()
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        For i As Integer = 0 To dgvPagoDctoBasico.Rows.Count - 1
            If Me.dgvPagoDctoBasico.Rows(i).Cells(Procedimiento.Name).Value.ToString.StartsWith(Me.txtBusqueda.Text, StringComparison.InvariantCultureIgnoreCase) Or
                Me.dgvPagoDctoBasico.Rows(i).Cells(CodPro.Name).Value.ToString.StartsWith(Me.txtBusqueda.Text, StringComparison.InvariantCultureIgnoreCase) Then
                'Me.dgvPagoDctoBasico.Rows(i).Cells("Descripcion").Selected = True
                'Me.dgvPagoDctoBasico.CurrentCell = dgvPagoDctoBasico.SelectedCells(1)
                Me.dgvPagoDctoBasico.CurrentCell = dgvPagoDctoBasico.Item(2, i)
                Me.dgvPagoDctoBasico.FirstDisplayedScrollingRowIndex = i

                Exit For
            End If
        Next
    End Sub
End Class