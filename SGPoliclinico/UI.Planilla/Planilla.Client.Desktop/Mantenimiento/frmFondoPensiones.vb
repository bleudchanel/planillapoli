Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmFondoPensiones

    Private bolEsModificar = False
    Private variablesManager As New VariablesManager
    Private _fondoPensiones As IEnumerable(Of FondoPensiones)
    Private _fondoActual As FondoPensiones


#Region "Text Monto"

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFlujoAporteOblig.KeyDown, txtFlujoComisionVar.KeyDown, txtFlujoPrimaSeg.KeyDown, txtMixtaAporteOblig.KeyDown, txtMixtaComisionVar.KeyDown, txtMixtaPrimaSeg.KeyDown, txtONP.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFlujoAporteOblig.KeyPress, txtFlujoComisionVar.KeyPress, txtFlujoPrimaSeg.KeyPress, txtMixtaAporteOblig.KeyPress, txtMixtaComisionVar.KeyPress, txtMixtaPrimaSeg.KeyPress, txtONP.KeyPress

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
                Validar_NumericoV4(oTextBox, e.KeyChar, vCapturar)
                e.Handled = vCapturar
            Catch ex As Exception

                e.Handled = True
                oTextBox.Text = "0.0000"
            End Try

        End If
    End Sub

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFlujoAporteOblig.Leave, txtFlujoComisionVar.Leave, txtFlujoPrimaSeg.Leave, txtMixtaAporteOblig.Leave, txtMixtaComisionVar.Leave, txtMixtaPrimaSeg.Leave, txtONP.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.0000"
        End If
    End Sub





#End Region


    Private Sub frmFondoPensiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _fondoPensiones = variablesManager.GetFondoPensiones()
        Controles_En_Load()
    End Sub


    Sub Controles_En_Load()
        ClearGroup(grpManagement)
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)
        Listar()
        ProcComboBoxEstado(cmbEstado)
        bolEsModificar = False
        Me.ActiveControl = Me.txtBusqueda
        _fondoActual = New FondoPensiones()
    End Sub


    Sub Listar()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each _fondo In _fondoPensiones
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells(IdFondoPensiones.Name).Value = _fondo.IdFondoPen
                .Cells(CodFon.Name).Value = _fondo.CodFon
                .Cells(Entidad.Name).Value = _fondo.Entidad
                .Cells(ApoOblF.Name).Value = FormatearNumero(_fondo.ApoOblF, 4)
                .Cells(ComVarF.Name).Value = FormatearNumero(_fondo.ComVarF, 4)
                .Cells(PriSegF.Name).Value = FormatearNumero(_fondo.PriSegF, 4)
                .Cells(ApoOblM.Name).Value = FormatearNumero(_fondo.ApoOblM, 4)
                .Cells(ComVarM.Name).Value = FormatearNumero(_fondo.ComVarM, 4)
                .Cells(PriSegM.Name).Value = FormatearNumero(_fondo.PriSegM, 4)
                .Cells(PorONP.Name).Value = FormatearNumero(_fondo.PorONP, 4)
            End With
        Next

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPagoDctoBasico.CurrentRow IsNot Nothing Then

            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)

            ClearGroup(grpManagement)
            Dim IdFondoPen = Me.dgvPagoDctoBasico.CurrentRow.Cells.Item(IdFondoPensiones.Name).Value
            _fondoActual.IdFondoPen = Convert.ToInt32(IdFondoPen)
            bolEsModificar = True
            RegistroData()
        End If
    End Sub

    Private Sub RegistroData()


        If _fondoPensiones IsNot Nothing AndAlso _fondoActual IsNot Nothing AndAlso _fondoActual.IdFondoPen > 0 Then
            _fondoActual = (From e In _fondoPensiones
                            Where e.IdFondoPen = _fondoActual.IdFondoPen
                            Select e).FirstOrDefault

            Me.txtCodigo.Text = _fondoActual.CodFon
            Me.txtEntidad.Text = _fondoActual.Entidad
            Me.txtFlujoAporteOblig.Text = FormatearNumero(_fondoActual.ApoOblF, 4)
            Me.txtFlujoComisionVar.Text = FormatearNumero(_fondoActual.ComVarF, 4)
            Me.txtFlujoPrimaSeg.Text = FormatearNumero(_fondoActual.PriSegF, 4)
            Me.txtMixtaAporteOblig.Text = FormatearNumero(_fondoActual.ApoOblM, 4)
            Me.txtMixtaComisionVar.Text = FormatearNumero(_fondoActual.ComVarM, 4)
            Me.txtMixtaPrimaSeg.Text = FormatearNumero(_fondoActual.PriSegM, 4)
            Me.txtONP.Text = FormatearNumero(_fondoActual.PorONP, 4)
            Me.cmbEstado.SelectedValue = _fondoActual.Estado

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
            _fondoActual.Entidad = txtEntidad.Text
            _fondoActual.ApoOblF = If(CDec(txtFlujoAporteOblig.Text) <> _fondoActual.ApoOblF, CDec(txtFlujoAporteOblig.Text), _fondoActual.ApoOblF)
            _fondoActual.ComVarF = If(CDec(txtFlujoComisionVar.Text) <> _fondoActual.ComVarF, CDec(txtFlujoComisionVar.Text), _fondoActual.ComVarF)
            _fondoActual.PriSegF = If(CDec(txtFlujoPrimaSeg.Text) <> _fondoActual.PriSegF, CDec(txtFlujoPrimaSeg.Text), _fondoActual.PriSegF)
            _fondoActual.ApoOblM = If(CDec(txtMixtaAporteOblig.Text) <> _fondoActual.ApoOblM, CDec(txtMixtaAporteOblig.Text), _fondoActual.ApoOblM)
            _fondoActual.ComVarM = If(CDec(txtMixtaComisionVar.Text) <> _fondoActual.ComVarM, CDec(txtMixtaComisionVar.Text), _fondoActual.ComVarM)
            _fondoActual.PriSegM = If(CDec(txtMixtaPrimaSeg.Text) <> _fondoActual.PriSegM, CDec(txtMixtaPrimaSeg.Text), _fondoActual.PriSegM)
            _fondoActual.PorONP = If(CDec(txtONP.Text) <> _fondoActual.PorONP, CDec(txtONP.Text), _fondoActual.PorONP)
            _fondoActual.Estado = If(cmbEstado.SelectedValue <> _fondoActual.Estado, CByte(cmbEstado.SelectedValue), _fondoActual.Estado)
            Dim fondoPen = variablesManager.RegistrarFondoPensiones(_fondoActual)

        Else
            Dim nuevoFondoPensiones As FondoPensiones = New FondoPensiones(String.Empty,
                                                                     txtEntidad.Text,
                                                                     If(txtFlujoAporteOblig.Text.Length = 0, 0, txtFlujoAporteOblig.Text),
                                                                     If(txtFlujoComisionVar.Text.Length = 0, 0, txtFlujoComisionVar.Text),
                                                                     If(txtFlujoPrimaSeg.Text.Length = 0, 0, txtFlujoPrimaSeg.Text),
                                                                           If(txtMixtaAporteOblig.Text.Length = 0, 0, txtMixtaAporteOblig.Text),
                                                                           If(txtMixtaComisionVar.Text.Length = 0, 0, txtMixtaComisionVar.Text),
                                                                           If(txtMixtaPrimaSeg.Text.Length = 0, 0, txtMixtaPrimaSeg.Text),
                                                                           If(txtONP.Text.Length = 0, 0, txtONP.Text))
            Dim fondoPen = variablesManager.RegistrarFondoPensiones(nuevoFondoPensiones)
        End If
        _fondoPensiones = variablesManager.GetFondoPensiones()
        Controles_En_Load()

    End Sub
End Class