Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmEspecialidad

    Private bolEsModificar = False
    Private especialidadManager As New EspecialidadManager
    Private _especialidades As IEnumerable(Of Especialidad)
    Private _especialidadActual As Especialidad
    ''Private _IdEspecialidadActual As Integer = 0


#Region "Text Monto"

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMontoMedico.KeyDown, txtPrecioConsulta.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            Dim oTextBox As TextBox = DirectCast(sender, TextBox)
            oTextBox.Text = "0.00"
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

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontoMedico.Leave, txtPrecioConsulta.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.00"
        End If
    End Sub





#End Region


    Private Sub frmEspecialidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _especialidades = especialidadManager.GetEspecialidades()
        Controles_En_Load()
    End Sub

    Sub Controles_En_Load()
        ClearGroup(grpManagement)
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)
        ListaEspecialidades()
        bolEsModificar = False
        Me.ActiveControl = Me.txtBusqueda
        _especialidadActual = New Especialidad()
    End Sub

    Sub ListaEspecialidades()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each _especialidad In _especialidades
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells("IdEspecialidad").Value = _especialidad.IdEspecialidad
                .Cells("CodEsp").Value = _especialidad.CodEsp
                .Cells("Descripcion").Value = _especialidad.Descripcion
                .Cells("PrecioCons").Value = FormatearNumero(_especialidad.PrecioConsulta, 2)
                .Cells("MontoMedi").Value = FormatearNumero(_especialidad.MontoMedico, 2)
            End With
        Next

    End Sub



    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPagoDctoBasico.CurrentRow IsNot Nothing Then

            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)

            ClearGroup(grpManagement)
            Dim IdEspecialidad = Me.dgvPagoDctoBasico.CurrentRow.Cells.Item("IdEspecialidad").Value
            _especialidadActual.IdEspecialidad = Convert.ToInt32(IdEspecialidad)
            bolEsModificar = True
            RegistroData()
        End If
    End Sub

    Private Sub RegistroData()


        If _especialidades IsNot Nothing AndAlso _especialidadActual IsNot Nothing AndAlso _especialidadActual.IdEspecialidad > 0 Then
            _especialidadActual = (From e In _especialidades
                                   Where e.IdEspecialidad = _especialidadActual.IdEspecialidad
                                   Select e).FirstOrDefault

            Me.txtCodigo.Text = _especialidadActual.CodEsp
            Me.txtEspecialidad.Text = _especialidadActual.Descripcion
            Me.txtMontoMedico.Text = FormatearNumero(_especialidadActual.MontoMedico, 2)
            Me.txtPrecioConsulta.Text = FormatearNumero(_especialidadActual.PrecioConsulta, 2)
        End If


    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bolEsModificar = False
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Controles_En_Load()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If bolEsModificar = True Then
            _especialidadActual.Descripcion = txtEspecialidad.Text
            _especialidadActual.MontoMedico = txtMontoMedico.Text
            _especialidadActual.PrecioConsulta = txtPrecioConsulta.Text
            Dim especialidad = especialidadManager.Registrar(_especialidadActual)
            'Notificar(especialidad.CodEsp & ": Modificado", "")
        Else
            Dim nuevaEspecialidad As Especialidad = New Especialidad(0, String.Empty,
                                                                     txtEspecialidad.Text,
                                                                     If(txtPrecioConsulta.Text.Length = 0, 0, txtPrecioConsulta.Text),
                                                                     If(txtMontoMedico.Text.Length = 0, 0, txtMontoMedico.Text), 0)
            Dim especialidad = especialidadManager.Registrar(nuevaEspecialidad)
        End If
        _especialidades = especialidadManager.GetEspecialidades()
        Controles_En_Load()



    End Sub

    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        For i As Integer = 0 To dgvPagoDctoBasico.Rows.Count - 1
            If Me.dgvPagoDctoBasico.Rows(i).Cells("Descripcion").Value.ToString.StartsWith(Me.txtBusqueda.Text, StringComparison.InvariantCultureIgnoreCase) Or
                Me.dgvPagoDctoBasico.Rows(i).Cells("CodEsp").Value.ToString.StartsWith(Me.txtBusqueda.Text, StringComparison.InvariantCultureIgnoreCase) Then
                'Me.dgvPagoDctoBasico.Rows(i).Cells("Descripcion").Selected = True
                'Me.dgvPagoDctoBasico.CurrentCell = dgvPagoDctoBasico.SelectedCells(1)
                Me.dgvPagoDctoBasico.CurrentCell = dgvPagoDctoBasico.Item(2, i)
                Me.dgvPagoDctoBasico.FirstDisplayedScrollingRowIndex = i

                Exit For
            End If
        Next
    End Sub
End Class