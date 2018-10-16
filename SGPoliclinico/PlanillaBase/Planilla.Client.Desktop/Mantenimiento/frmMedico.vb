Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmMedico

    Private bolEsModificar = False
    Private personalManager As New PersonalManager
    Private variableManager As New VariablesManager
    Private _medicos As IEnumerable(Of Medico)
    Private _medicoActual As Medico
    Private _ubigeos As IEnumerable(Of Ubigeo)
    Private _areas As IEnumerable(Of AreaServicio)
    Private _cargos As IEnumerable(Of Cargo)
    Private _fondos As IEnumerable(Of FondoPensiones)
    Private _especialidades As IEnumerable(Of Especialidad)


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

        _ubigeos = variableManager.GetUbigeo()
        Dim dtUbigeo As New DataTable
        dtUbigeo.Columns.Add("IdUbigeo")
        dtUbigeo.Columns.Add("Descripcion")
        dtUbigeo.Rows.Add(0, "--SELECCIONAR--")
        For Each _ubi In _ubigeos
            dtUbigeo.Rows.Add(_ubi.IdUbigeo, _ubi.NOMDIS + " - " + _ubi.CODDIS)
        Next
        cmbDistrito.DataSource = dtUbigeo
        cmbDistrito.DisplayMember = "Descripcion"
        cmbDistrito.ValueMember = "IdUbigeo"
        ''cmbDistrito.SelectedIndex = 1

        Dim dtTipo As New DataTable
        dtTipo.Columns.Add("Id", GetType(String))
        dtTipo.Columns.Add("Descripcion", GetType(String))
        dtTipo.Rows.Add("NN", "--SELECCIONAR--")
        dtTipo.Rows.Add("E", "ENTIDAD")
        dtTipo.Rows.Add("P", "PERSONA")
        cmbTipo.DataSource = dtTipo
        cmbTipo.DisplayMember = "Descripcion"
        cmbTipo.ValueMember = "Id"
        ''cmbTipoComision.SelectedIndex = 1

        Dim dtGrado As New DataTable
        dtGrado.Columns.Add("Id", GetType(Integer))
        dtGrado.Columns.Add("Descripcion", GetType(String))
        dtGrado.Rows.Add(0, "--SELECCIONAR--")
        dtGrado.Rows.Add(1, "CD.")
        dtGrado.Rows.Add(2, "Dr.")
        dtGrado.Rows.Add(3, "Dra.")
        dtGrado.Rows.Add(4, "Lic.")
        dtGrado.Rows.Add(5, "Tec.")
        cmbGrado.DataSource = dtGrado
        cmbGrado.DisplayMember = "Descripcion"
        cmbGrado.ValueMember = "Id"

        Dim dtSituacion As New DataTable
        dtSituacion.Columns.Add("Id", GetType(String))
        dtSituacion.Columns.Add("Descripcion", GetType(String))
        dtSituacion.Rows.Add("NN", "--SELECCIONAR--")
        dtSituacion.Rows.Add("E", "EGRESADO")
        dtSituacion.Rows.Add("T", "TITULADO")
        cmbSituacionEspecialidad.DataSource = dtSituacion
        cmbSituacionEspecialidad.DisplayMember = "Descripcion"
        cmbSituacionEspecialidad.ValueMember = "Id"


        _especialidades = variableManager.GetEspecialidades()
        Dim dtEspecialidad As New DataTable
        dtEspecialidad.Columns.Add("Id", GetType(Integer))
        dtEspecialidad.Columns.Add("Descripcion", GetType(String))
        dtEspecialidad.Rows.Add(0, "--SELECCIONAR--")

        Dim dtEspecialidad2 As New DataTable
        dtEspecialidad2.Columns.Add("Id", GetType(Integer))
        dtEspecialidad2.Columns.Add("Descripcion", GetType(String))
        dtEspecialidad2.Rows.Add(0, "--SELECCIONAR--")

        For Each _esp In _especialidades
            dtEspecialidad.Rows.Add(_esp.IdEspecialidad, _esp.Descripcion)
            dtEspecialidad2.Rows.Add(_esp.IdEspecialidad, _esp.Descripcion)
        Next
        cmbEspecialidad1.DataSource = dtEspecialidad
        cmbEspecialidad1.DisplayMember = "Descripcion"
        cmbEspecialidad1.ValueMember = "Id"

        cmbEspecialidad2.DataSource = dtEspecialidad2
        cmbEspecialidad2.DisplayMember = "Descripcion"
        cmbEspecialidad2.ValueMember = "Id"

    End Sub

    Sub Controles_En_Load()
        _medicos = personalManager.GetMedicos

        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)

        ClearGroup(grpDatos)
        ClearGroup(grpRemuneracion)
        Listar()
    End Sub

    Private Sub frmMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Controles_En_Load()

        ComboBoxBase()

        Me.ActiveControl = dgvPagoDctoBasico
    End Sub

    Private Sub Listar()
        Me.dgvPagoDctoBasico.DataSource = Nothing
        Me.dgvPagoDctoBasico.Rows.Clear()

        '                
        For Each persona In _medicos
            dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells(IdMedico.Name).Value = persona.IdMedico
                .Cells(CodMed.Name).Value = persona.CodMed
                .Cells("ApePaterno").Value = persona.ApePaterno
                .Cells("ApeMaterno").Value = persona.ApeMaterno
                .Cells("Nombre").Value = persona.Nombre
                .Cells("Direccion").Value = persona.Direccion
                .Cells("CodDis").Value = persona.CodDistrito
                .Cells("FecNac").Value = persona.FecNac
                .Cells("Cel").Value = persona.Celular
                .Cells("Email").Value = persona.Email
                .Cells("RUC").Value = persona.RUC
                .Cells("FecIngreso").Value = persona.FecIngreso
                .Cells("Grado").Value = persona.Grado
                .Cells("NumCol").Value = persona.NumCol
                .Cells("Sit").Value = persona.Sit
                .Cells(RNE.Name).Value = persona.RNE
                .Cells(CodEsp1.Name).Value = persona.CodEsp1
                .Cells(CodEsp2.Name).Value = persona.CodEsp2
                .Cells(Estado.Name).Value = persona.Estado
                .Cells(Tipo.Name).Value = persona.Tipo
            End With
            ''dgvPagoDctoBasico.DataSource = _personal
        Next
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bolEsModificar = True
        If _medicos IsNot Nothing AndAlso dgvPagoDctoBasico.CurrentRow IsNot Nothing Then
            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
            Dim mIdPersonal = Me.dgvPagoDctoBasico.CurrentRow.Cells.Item(IdMedico.Name).Value
            ' '_fondoActual.IdFondoPen = Convert.ToInt32(IdFondoPen)
            _medicoActual = (From a In _medicos
                             Where a.IdMedico = mIdPersonal
                             Select a).FirstOrDefault()
            bolEsModificar = True
            LlenarDatos()
        End If
    End Sub

    Sub LlenarDatos()
        If _medicoActual IsNot Nothing Then
            txtCodPer.Text = _medicoActual.CodMed
            txtDni.Text = _medicoActual.DNI
            txtApellidoMaterno.Text = _medicoActual.ApeMaterno
            txtApellidoPaterno.Text = _medicoActual.ApePaterno
            txtNombres.Text = _medicoActual.Nombre
            txtDireccion.Text = _medicoActual.Direccion
            dtpFecNac.Value = If(_medicoActual.FecNac Is Nothing, Date.Now, _medicoActual.FecNac)
            txtTelefono.Text = _medicoActual.Telefono
            txtCelular.Text = _medicoActual.Celular
            txtEmail.Text = _medicoActual.Email
            txtRUC.Text = _medicoActual.RUC
            dtpFecIngreso.Value = If(_medicoActual.FecIngreso Is Nothing, Date.Now, _medicoActual.FecNac)
            cmbDistrito.SelectedValue = If(_medicoActual.IdUbigeo Is Nothing, 0, _medicoActual.IdUbigeo)
            cmbEspecialidad1.SelectedValue = If(_medicoActual.IdEspecialidad1 Is Nothing, 0, _medicoActual.IdEspecialidad1)
            cmbEspecialidad2.SelectedValue = If(_medicoActual.IdEspecialidad2 Is Nothing, 0, _medicoActual.IdEspecialidad2)
            cmbSituacionEspecialidad.SelectedValue = If(_medicoActual.Sit Is Nothing, "NN", _medicoActual.Sit)
            cmbTipo.SelectedValue = If(_medicoActual.Tipo Is Nothing, "NN", _medicoActual.Tipo)
            txtRNE.Text = _medicoActual.RNE
            cmbGrado.SelectedIndex = cmbGrado.FindString(If(_medicoActual.Grado Is Nothing, "", _medicoActual.Grado.Trim))
            txtNroColegiatura.Text = _medicoActual.NumCol
            cmbEstado.SelectedIndex = If(_medicoActual.Estado.Trim = "B", 1, 0)
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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim dtEx = DataGridViewToDataTable(dgvPagoDctoBasico, New List(Of String)(New String() {"IdMedico"}), "Honk")
        FncDataTable2Excel(dtEx, "Medico")
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If bolEsModificar = True Then

            _medicoActual.DNI = Me.txtDni.Text
            _medicoActual.Nombre = txtNombres.Text
            _medicoActual.ApeMaterno = txtApellidoMaterno.Text
            _medicoActual.ApePaterno = txtApellidoPaterno.Text
            _medicoActual.Direccion = txtDireccion.Text
            _medicoActual.FecNac = dtpFecNac.Value
            _medicoActual.Telefono = txtTelefono.Text
            _medicoActual.Celular = txtCelular.Text
            _medicoActual.Email = txtEmail.Text
            _medicoActual.RUC = txtRUC.Text
            _medicoActual.RNE = txtRNE.Text
            _medicoActual.Estado = cmbEstado.SelectedValue.ToString()
            _medicoActual.FecIngreso = dtpFecIngreso.Value

            _medicoActual.IdUbigeo = Nothing
            _medicoActual.CodDistrito = Nothing

            If CInt(Me.cmbDistrito.SelectedValue) > 0 Then
                _medicoActual.IdUbigeo = CInt(Me.cmbDistrito.SelectedValue)
                Dim dis = (From dist In _ubigeos Where dist.IdUbigeo = _medicoActual.IdUbigeo Select dist).FirstOrDefault()
                _medicoActual.CodDistrito = dis.CODDIS
            End If

            _medicoActual.Grado = Nothing
            If cmbGrado.SelectedIndex > 0 Then
                _medicoActual.Grado = cmbGrado.Text
            End If

            _medicoActual.NumCol = txtNroColegiatura.Text.Trim()

            _medicoActual.IdEspecialidad1 = Nothing
            _medicoActual.CodEsp1 = Nothing
            If CInt(cmbEspecialidad1.SelectedValue) > 0 Then
                _medicoActual.IdEspecialidad1 = If(CInt(cmbEspecialidad1.SelectedValue) = 0, Nothing, CInt(cmbEspecialidad1.SelectedValue))
                Dim especialidad1 = (From esp In _especialidades Where esp.IdEspecialidad = _medicoActual.IdEspecialidad1 Select esp).FirstOrDefault()
                _medicoActual.CodEsp1 = If(especialidad1 Is Nothing, Nothing, especialidad1.CodEsp)
            End If


            _medicoActual.IdEspecialidad2 = Nothing
            _medicoActual.CodEsp2 = Nothing
            If CInt(cmbEspecialidad2.SelectedValue) > 0 Then
                _medicoActual.IdEspecialidad2 = If(CInt(cmbEspecialidad2.SelectedValue) = 0, Nothing, CInt(cmbEspecialidad2.SelectedValue))
                Dim especialidad2 = (From esp In _especialidades Where esp.IdEspecialidad = _medicoActual.IdEspecialidad2 Select esp).FirstOrDefault()
                _medicoActual.CodEsp2 = If(especialidad2 Is Nothing, Nothing, especialidad2.CodEsp)
            End If


            _medicoActual.Tipo = If(cmbTipo.SelectedIndex = 0, Nothing, cmbTipo.SelectedValue)
            _medicoActual.Sit = If(cmbSituacionEspecialidad.SelectedIndex = 0, Nothing, cmbSituacionEspecialidad.SelectedValue)

            Dim pers = personalManager.RegistrarMedico(_medicoActual)
        Else
            Dim dis = (From dist In _ubigeos Where dist.IdUbigeo = CInt(cmbDistrito.SelectedValue) Select dist).FirstOrDefault()
            Dim IdUbigeo As Integer? = Nothing
            Dim CodDis As String = Nothing
            Dim IdEspecialidad1 As Integer? = Nothing
            Dim IdEspecialidad2 As Integer? = Nothing
            Dim CodEsp1 As String = Nothing
            Dim CodEsp2 As String = Nothing
            Dim Grado As String = Nothing
            Dim Situacion As String = Nothing

            If CInt(cmbSituacionEspecialidad.SelectedIndex > 0) Then
                Situacion = cmbSituacionEspecialidad.SelectedValue
            End If

            If CInt(Me.cmbDistrito.SelectedValue) > 0 Then
                IdUbigeo = CInt(Me.cmbDistrito.SelectedValue)
                Dim dis_ = (From dist In _ubigeos Where dist.IdUbigeo = IdUbigeo Select dist).FirstOrDefault()
                CodDis = dis_.CODDIS
            End If

            If CInt(cmbEspecialidad1.SelectedValue) > 0 Then
                IdEspecialidad1 = If(CInt(cmbEspecialidad1.SelectedValue) = 0, Nothing, CInt(cmbEspecialidad1.SelectedValue))
                Dim especialidad1_ = (From esp In _especialidades Where esp.IdEspecialidad = IdEspecialidad1 Select esp).FirstOrDefault()
                CodEsp1 = If(especialidad1_ Is Nothing, Nothing, especialidad1_.CodEsp)
            End If

            If CInt(cmbEspecialidad2.SelectedValue) > 0 Then
                IdEspecialidad2 = If(CInt(cmbEspecialidad2.SelectedValue) = 0, Nothing, CInt(cmbEspecialidad2.SelectedValue))
                Dim especialidad2_ = (From esp In _especialidades Where esp.IdEspecialidad = IdEspecialidad2 Select esp).FirstOrDefault()
                CodEsp2 = If(especialidad2_ Is Nothing, Nothing, especialidad2_.CodEsp)
            End If

            If cmbGrado.SelectedIndex > 0 Then
                Grado = cmbGrado.SelectedValue
            End If


            Dim nuevoMedico As New Medico(txtDni.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombres.Text, txtDireccion.Text,
                                    IdUbigeo, CodDis, dtpFecNac.Value, txtTelefono.Text, txtCelular.Text, txtEmail.Text, txtRUC.Text,
                                    dtpFecIngreso.Value, Grado, txtNroColegiatura.Text, Situacion,
                                    txtRNE.Text, IdEspecialidad1, CodEsp1, IdEspecialidad2, CodEsp2,
                                    cmbEstado.SelectedValue.ToString(), If(cmbTipo.SelectedIndex = 0, Nothing, cmbTipo.SelectedValue))

            Dim pers = personalManager.RegistrarMedico(nuevoMedico)
        End If
        _medicos = personalManager.GetMedicos()
        ''_procedimientos = variablesManager.GetProcedimientos()
        Controles_En_Load()
    End Sub

    Private Sub dgvPagoDctoBasico_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPagoDctoBasico.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.btnModificar.PerformClick()
        End If
    End Sub

    'Private Sub txtRUC_Click(sender As Object, e As EventArgs) Handles txtRUC.Click
    '    txtRUC.SelectAll()
    'End Sub

    'Private Sub txtRUC_Enter(sender As Object, e As EventArgs) Handles txtRUC.Enter
    '    txtRUC.SelectAll()
    'End Sub
End Class