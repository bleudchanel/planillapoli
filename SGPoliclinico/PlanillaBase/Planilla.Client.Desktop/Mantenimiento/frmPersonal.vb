Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net


Public Class frmRemuneracionBasica

    Private bolEsModificar = False
    Private personalManager As New PersonalManager
    Private variableManager As New VariablesManager
    Private _personal As IEnumerable(Of Personal)
    Private _personaActual As Personal
    Private _ubigeos As IEnumerable(Of Ubigeo)
    Private _areas As IEnumerable(Of AreaServicio)
    Private _cargos As IEnumerable(Of Cargo)
    Private _fondos As IEnumerable(Of FondoPensiones)
    Private _grados As List(Of String)

#Region "Text Monto"

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemuneracionBasica.KeyDown, txtRiesgoCaja.KeyDown, txtAsignacionFamiliar.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemuneracionBasica.KeyPress, txtRiesgoCaja.KeyPress, txtAsignacionFamiliar.KeyPress

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

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemuneracionBasica.Leave, txtRiesgoCaja.Leave, txtAsignacionFamiliar.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.0000"
        End If
    End Sub





#End Region


    Private Sub frmRemuneracionBasica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Controles_En_Load()

        ComboBoxBase()
        Me.ActiveControl = dgvPagoDctoBasico
        _grados = New List(Of String)

        _grados.Add("Técnico")
        _grados.Add("Técnico Superior")
        _grados.Add("Licenciado")
        _grados.Add("Doctor")
        _grados.Add("Doctora")
        _grados.Add("Otro")
    End Sub

    Private Sub ComboBoxBase()
        Dim dtEstado As New DataTable
        dtEstado.Columns.Add("Id", GetType(String))
        dtEstado.Columns.Add("Estado", GetType(String))
        dtEstado.Rows.Add("A", "ACTIVO")
        dtEstado.Rows.Add("B", "BAJA")

        cmbEstado.DataSource = dtEstado
        cmbEstado.DisplayMember = "Estado"
        cmbEstado.ValueMember = "Id"
        cmbEstado.SelectedValue = 1

        Dim dtEstadoCivil As New DataTable
        dtEstadoCivil.Columns.Add("Id", GetType(String))
        dtEstadoCivil.Columns.Add("EstadoCivil", GetType(String))
        dtEstadoCivil.Rows.Add("A", "CASADO(A)")
        dtEstadoCivil.Rows.Add("D", "DIVORCIADO(A)")
        dtEstadoCivil.Rows.Add("S", "SOLTERO(A)")
        dtEstadoCivil.Rows.Add("V", "VIUDO(A)")

        cmbEstadoCivil.DataSource = dtEstadoCivil
        cmbEstadoCivil.DisplayMember = "EstadoCivil"
        cmbEstadoCivil.ValueMember = "Id"
        cmbEstadoCivil.SelectedValue = 1

        Dim dtGrado As New DataTable
        dtGrado.Columns.Add("Id", GetType(String))
        dtGrado.Columns.Add("Descripcion", GetType(String))
        dtGrado.Rows.Add("Técnico", "Técnico")
        dtGrado.Rows.Add("Técnico Superior", "Técnico Superior")
        dtGrado.Rows.Add("Licenciado", "Licenciado")
        dtGrado.Rows.Add("Doctor", "Doctor")
        dtGrado.Rows.Add("Doctora", "Doctora")
        dtGrado.Rows.Add("Otro", "Otro")
        cmbGrado.DataSource = dtGrado
        cmbGrado.ValueMember = "Id"
        cmbGrado.DisplayMember = "Descripcion"




        _ubigeos = variableManager.GetUbigeo()
        Dim dtUbigeo As New DataTable
        dtUbigeo.Columns.Add("IdUbigeo")
        dtUbigeo.Columns.Add("Descripcion")
        For Each _ubi In _ubigeos
            dtUbigeo.Rows.Add(_ubi.IdUbigeo, _ubi.NOMDIS + " - " + _ubi.CODDIS)
        Next
        cmbDistrito.DataSource = dtUbigeo
        cmbDistrito.DisplayMember = "Descripcion"
        cmbDistrito.ValueMember = "IdUbigeo"
        ''cmbDistrito.SelectedIndex = 1

        Dim dtEstudios As New DataTable
        dtEstudios.Columns.Add("Id", GetType(Integer))
        dtEstudios.Columns.Add("Descripcion", GetType(String))
        dtEstudios.Rows.Add(1, "PRIMARIA")
        dtEstudios.Rows.Add(2, "SECUNDARIA COMPLETA")
        dtEstudios.Rows.Add(3, "SECUNDARIA INCOMPLETA")
        dtEstudios.Rows.Add(4, "SUPERIOR COMPLETA")
        dtEstudios.Rows.Add(5, "SUPERIOR INCOMPLETA")
        dtEstudios.Rows.Add(6, "TECNICO COMPLETO")
        dtEstudios.Rows.Add(7, "TECNICO INCOMPLETO")
        cmbEstudios.DataSource = dtEstudios
        cmbEstudios.DisplayMember = "Descripcion"
        cmbEstudios.ValueMember = "Id"
        '' cmbEstudios.SelectedIndex = 1

        Dim dtTipoComision As New DataTable
        dtTipoComision.Columns.Add("Id", GetType(String))
        dtTipoComision.Columns.Add("Descripcion", GetType(String))
        dtTipoComision.Rows.Add("F", "FLUJO")
        dtTipoComision.Rows.Add("M", "MIXTA")
        cmbTipoComision.DataSource = dtTipoComision
        cmbTipoComision.DisplayMember = "Descripcion"
        cmbTipoComision.ValueMember = "Id"
        ''cmbTipoComision.SelectedIndex = 1

        _areas = variableManager.GetAreasServicio()
        Dim dtAreaServicio As New DataTable
        dtAreaServicio.Columns.Add("IdAreaServicio")
        dtAreaServicio.Columns.Add("Descripcion")
        For Each _area In _areas
            dtAreaServicio.Rows.Add(_area.IdAreaServicio, _area.Area + " - " + _area.CodAre)
        Next
        cmbArea.DataSource = dtAreaServicio
        cmbArea.DisplayMember = "Descripcion"
        cmbArea.ValueMember = "IdAreaServicio"
        '' cmbArea.SelectedIndex = 1

        _cargos = variableManager.GetCargos()
        Dim dtCargo As New DataTable
        dtCargo.Columns.Add("IdCargo")
        dtCargo.Columns.Add("Descripcion")
        For Each _cargo In _cargos
            dtCargo.Rows.Add(_cargo.IdCargo, _cargo.Cargo1 + " - " + _cargo.CodCar)
        Next
        cmbCargo.DataSource = dtCargo
        cmbCargo.DisplayMember = "Descripcion"
        cmbCargo.ValueMember = "IdCargo"
        ''cmbCargo.SelectedIndex = 1

        _fondos = variableManager.GetFondoPensiones()
        Dim dtFondoPen As New DataTable
        dtFondoPen.Columns.Add("IdFondo")
        dtFondoPen.Columns.Add("Descripcion")
        For Each _fondo In _fondos
            dtFondoPen.Rows.Add(_fondo.IdFondoPen, _fondo.Entidad + " - " + _fondo.CodFon)
        Next
        cmbFondoPen.DataSource = dtFondoPen
        cmbFondoPen.DisplayMember = "Descripcion"
        cmbFondoPen.ValueMember = "IdFondo"
        '' cmbFondoPen.SelectedIndex = 1

    End Sub

    Sub ListaPersonal()
        Me.dgvPagoDctoBasico.DataSource = Nothing
        Me.dgvPagoDctoBasico.Rows.Clear()

        '                
        For Each persona In _personal
            dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells("IdPersonal").Value = persona.IdPersonal
                .Cells("CodPer").Value = persona.CodPer
                .Cells("ApePaterno").Value = persona.ApePaterno
                .Cells("ApeMaterno").Value = persona.ApeMaterno
                .Cells("Nombre").Value = persona.Nombre
                .Cells("Direccion").Value = persona.Direccion
                .Cells("CodDis").Value = persona.CodDistrito
                .Cells("FecNac").Value = persona.FecNac
                .Cells("Cel").Value = persona.Celular
                .Cells("Email").Value = persona.Email
                .Cells("Sex").Value = persona.Sex
                .Cells("EstCivil").Value = persona.EstadoCivil
                .Cells("NumHijo").Value = persona.NumHij
                .Cells("FecIngreso").Value = persona.FecIngreso
                .Cells("Estudios").Value = persona.Estudios
                .Cells("Grado").Value = persona.Grado
                .Cells("NumCol").Value = persona.NumCol
                .Cells("CodAre").Value = persona.CodAre
                .Cells("CodCar").Value = persona.CodCar
                .Cells("CodFon").Value = persona.CodFon
                .Cells("TipComAFP").Value = persona.TipComAFP
                .Cells("CUSPP").Value = persona.CUSPP
                .Cells("EVida").Value = persona.EVida
                .Cells("RemBas").Value = persona.RemBas
                .Cells("AsiFam").Value = persona.AsiFam
                .Cells("RiesgoCaja").Value = persona.RieCaj
                .Cells("SCTR").Value = persona.SCTR
                .Cells("HorLab").Value = persona.HorLab
                .Cells("Obs").Value = persona.Observacion
                .Cells("Estado").Value = persona.Estado
                .Cells("FechaBaja").Value = persona.FecBaja
                .Cells("EntidadCTS").Value = persona.EntidadCTS
                .Cells("NumCtaCTS").Value = persona.NumCtaCTS
            End With
            ''dgvPagoDctoBasico.DataSource = _personal
        Next
    End Sub

    Sub Controles_En_Load()
        _personal = personalManager.GetPersonalActivo()
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)

        ClearGroup(grpDatos)
        ClearGroup(grpRemuneracion)
        ClearGroup(grpEstudios)
        Me.chkCustomDiasHoras.CheckState = CheckState.Unchecked
        ListaPersonal()
    End Sub


    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        bolEsModificar = True
        If _personal IsNot Nothing AndAlso dgvPagoDctoBasico.CurrentRow IsNot Nothing Then
            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
            Dim mIdPersonal = Me.dgvPagoDctoBasico.CurrentRow.Cells.Item(IdPersonal.Name).Value
            ' '_fondoActual.IdFondoPen = Convert.ToInt32(IdFondoPen)
            _personaActual = (From a In _personal
                              Where a.IdPersonal = mIdPersonal
                              Select a).FirstOrDefault()
            bolEsModificar = True
            LlenarDatos()
        End If
    End Sub

    Sub LlenarDatos()
        If _personaActual IsNot Nothing Then
            txtCodPer.Text = _personaActual.CodPer
            txtDni.Text = _personaActual.DNI
            txtApellidoMaterno.Text = _personaActual.ApeMaterno
            txtApellidoPaterno.Text = _personaActual.ApePaterno
            txtNombres.Text = _personaActual.Nombre
            txtDireccion.Text = _personaActual.Direccion
            dtpFecNac.Value = _personaActual.FecNac
            txtTelefono.Text = _personaActual.Telefono
            txtCelular.Text = _personaActual.Celular
            txtEmail.Text = _personaActual.Email
            txtSexo.Text = _personaActual.Sex
            cmbEstadoCivil.SelectedValue = If(_personaActual.EstadoCivil Is Nothing, "S", _personaActual.EstadoCivil)  ''cmbEstadoCivil.FindString(_personaActual.EstadoCivil.Trim)
            txtNumHijos.Text = _personaActual.NumHij
            dtpFecIngreso.Value = _personaActual.FecIngreso
            cmbDistrito.SelectedValue = If(_personaActual.IdUbigeo Is Nothing, 0, _personaActual.IdUbigeo)
            cmbEstudios.SelectedIndex = cmbEstudios.FindString(_personaActual.Estudios.Trim)
            If (_grados.Contains(_personaActual.Grado)) Then
                cmbGrado.SelectedValue = _personaActual.Grado
                txtGrado.Visible = False
            Else
                cmbGrado.SelectedValue = "Otro"
                txtGrado.Text = _personaActual.Grado
                txtGrado.Visible = True
            End If

            txtNroColegiatura.Text = _personaActual.NumCol
            cmbArea.SelectedValue = _personaActual.IdAreaServicio
            cmbCargo.SelectedValue = _personaActual.IdCargo
            cmbFondoPen.SelectedValue = _personaActual.IdFondoPen
            cmbTipoComision.SelectedIndex = cmbTipoComision.FindString(_personaActual.TipComAFP.Trim)
            txtCUSPP.Text = _personaActual.CUSPP
            txtEVida.Text = _personaActual.EVida
            txtRemuneracionBasica.Text = FormatearNumero(_personaActual.RemBas, 2)
            txtAsignacionFamiliar.Text = FormatearNumero(_personaActual.AsiFam, 2)
            txtRiesgoCaja.Text = FormatearNumero(_personaActual.RieCaj, 2)
            txtSCTR.Text = _personaActual.SCTR
            txtHorasLaborales.Text = _personaActual.HorLab
            cmbEstado.SelectedIndex = If(_personaActual.Estado.Trim = "B", 1, 0)
            txtEntidadCTS.Text = _personaActual.EntidadCTS
            txtCuentaCTS.Text = _personaActual.NumCtaCTS
            txtObservacion.Text = _personaActual.Observacion
            dtpFechaBaja.Value = _personaActual.FecBaja
            chkCustomDiasHoras.CheckState = If(_personaActual.CustomDiasHoras > 0, CheckState.Checked, CheckState.Unchecked)
            Me.grpCustom.Enabled = If(_personaActual.CustomDiasHoras > 0, CheckState.Checked, CheckState.Unchecked)
            nudDias.Value = _personaActual.CustomDias
            nudHoras.Value = _personaActual.CustomHoras
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        bolEsModificar = False
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
        Me.chkCustomDiasHoras.CheckState = CheckState.Unchecked
        Me.grpCustom.Enabled = False
    End Sub




    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If bolEsModificar = True Then
            Try
                _personaActual.DNI = Me.txtDni.Text
                _personaActual.Nombre = txtNombres.Text
                _personaActual.ApeMaterno = txtApellidoMaterno.Text
                _personaActual.ApePaterno = txtApellidoPaterno.Text
                _personaActual.Direccion = txtDireccion.Text
                _personaActual.FecNac = dtpFecNac.Value
                _personaActual.Telefono = txtTelefono.Text
                _personaActual.Celular = txtCelular.Text
                _personaActual.Email = txtEmail.Text
                _personaActual.Sex = txtSexo.Text
                _personaActual.EstadoCivil = cmbEstadoCivil.SelectedValue
                _personaActual.NumHij = txtNumHijos.Text
                _personaActual.FecIngreso = dtpFecIngreso.Value
                If CInt(Me.cmbDistrito.SelectedValue) > 0 Then
                    _personaActual.IdUbigeo = CInt(Me.cmbDistrito.SelectedValue)
                End If
                Dim dis = (From dist In _ubigeos Where dist.IdUbigeo = _personaActual.IdUbigeo Select dist).FirstOrDefault()
                If IsNothing(dis) = False Then
                    _personaActual.CodDistrito = dis.CODDIS
                Else
                    _personaActual.CodDistrito = "260101"
                End If

                _personaActual.Estudios = cmbEstudios.Text
                _personaActual.Grado = IIf(cmbGrado.SelectedValue = "Otro", txtGrado.Text, cmbGrado.Text)
                _personaActual.NumCol = txtNroColegiatura.Text.Trim()
                _personaActual.IdAreaServicio = CInt(cmbArea.SelectedValue)
                Dim area = (From are In _areas Where are.IdAreaServicio = _personaActual.IdAreaServicio Select are).FirstOrDefault()
                _personaActual.CodAre = area.CodAre
                _personaActual.IdCargo = CInt(cmbCargo.SelectedValue)
                Dim cargo = (From car In _cargos Where car.IdCargo = _personaActual.IdCargo Select car).FirstOrDefault()
                _personaActual.CodCar = cargo.CodCar
                _personaActual.IdFondoPen = CInt(cmbFondoPen.SelectedValue)
                Dim fondo = (From fon In _fondos Where fon.IdFondoPen = _personaActual.IdFondoPen Select fon).FirstOrDefault()
                _personaActual.CodFon = fondo.CodFon
                _personaActual.TipComAFP = cmbTipoComision.SelectedValue.ToString()
                _personaActual.CUSPP = txtCUSPP.Text
                _personaActual.EVida = If(txtEVida.Text.Length > 0, txtEVida.Text.Substring(0, 1), "N")
                _personaActual.RemBas = txtRemuneracionBasica.Text
                _personaActual.AsiFam = txtAsignacionFamiliar.Text
                _personaActual.RieCaj = txtRiesgoCaja.Text
                _personaActual.SCTR = txtSCTR.Text.Substring(0, 1)
                _personaActual.HorLab = txtHorasLaborales.Text
                _personaActual.Estado = cmbEstado.SelectedValue.ToString()
                _personaActual.EntidadCTS = txtEntidadCTS.Text.Trim()
                _personaActual.NumCtaCTS = txtCuentaCTS.Text.Trim()
                _personaActual.Observacion = txtObservacion.Text
                _personaActual.FecBaja = dtpFechaBaja.Value
                _personaActual.CustomDiasHoras = IIf(Me.chkCustomDiasHoras.CheckState = CheckState.Checked, 1, 0)
                _personaActual.CustomDias = IIf(Me.chkCustomDiasHoras.CheckState = CheckState.Checked, nudDias.Value, 0)
                _personaActual.CustomHoras = IIf(Me.chkCustomDiasHoras.CheckState = CheckState.Checked, nudHoras.Value, 0)
                Dim pers = personalManager.RegistrarPersonal(_personaActual)
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End Try

        Else
            Dim dis = (From dist In _ubigeos Where dist.IdUbigeo = CInt(cmbDistrito.SelectedValue) Select dist).FirstOrDefault()
            Dim area = (From are In _areas Where are.IdAreaServicio = CInt(cmbArea.SelectedValue) Select are).FirstOrDefault()
            Dim cargo = (From car In _cargos Where car.IdCargo = CInt(cmbCargo.SelectedValue) Select car).FirstOrDefault()
            Dim fondo = (From fon In _fondos Where fon.IdFondoPen = CInt(cmbFondoPen.SelectedValue) Select fon).FirstOrDefault()
            Dim nuevoPersonal As New Personal(txtDni.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombres.Text, txtDireccion.Text,
                                              dis.IdUbigeo, dis.CODDIS, dtpFecNac.Value, txtTelefono.Text, txtCelular.Text, txtEmail.Text, txtSexo.Text, cmbEstadoCivil.SelectedValue,
                                              txtNumHijos.Text, dtpFecIngreso.Value, cmbEstudios.Text,
                                              IIf(cmbGrado.SelectedValue = "Otro", txtGrado.Text, cmbGrado.Text),
                                              txtNroColegiatura.Text, area.IdAreaServicio, area.CodAre,
                                              cargo.IdCargo, cargo.CodCar, fondo.IdFondoPen, fondo.CodFon, cmbTipoComision.SelectedValue.ToString(), txtCUSPP.Text, txtEVida.Text, txtRemuneracionBasica.Text,
                                              txtAsignacionFamiliar.Text, txtRiesgoCaja.Text, txtSCTR.Text, txtHorasLaborales.Text, txtObservacion.Text, cmbEstado.SelectedValue.ToString(), dtpFechaBaja.Value,
                                              txtEntidadCTS.Text, txtCuentaCTS.Text, IIf(Me.chkCustomDiasHoras.CheckState = CheckState.Checked, 1, 0), IIf(Me.chkCustomDiasHoras.CheckState = CheckState.Checked, nudDias.Value, 0),
                                              IIf(Me.chkCustomDiasHoras.CheckState = CheckState.Checked, nudHoras.Value, 0))

            Dim pers = personalManager.RegistrarPersonal(nuevoPersonal)
        End If
        _personal = personalManager.GetPersonalActivo()
        ''_procedimientos = variablesManager.GetProcedimientos()
        Controles_En_Load()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Controles_En_Load()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim dtEx = DataGridViewToDataTable(dgvPagoDctoBasico, New List(Of String)(New String() {"IdPersonal"}), "Honk")
        FncDataTable2Excel(dtEx, "Personal")
    End Sub

    Private Sub chkCustomDiasHoras_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustomDiasHoras.CheckedChanged
        Me.grpCustom.Enabled = chkCustomDiasHoras.Checked
    End Sub

    Private Sub cmbGrado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbGrado.SelectionChangeCommitted
        If cmbGrado.SelectedValue = "Otro" Then
            txtGrado.Visible = True
            Me.ActiveControl = txtGrado
        Else
            txtGrado.Visible = False
        End If
    End Sub

    Private Sub dgvPagoDctoBasico_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPagoDctoBasico.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.btnModificar.PerformClick()

        End If
    End Sub
End Class