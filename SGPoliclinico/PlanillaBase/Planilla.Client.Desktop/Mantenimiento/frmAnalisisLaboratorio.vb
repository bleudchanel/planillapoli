Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmAnalisisLaboratorio

    Private bolEsModificar = False
    Private variablesManager As New VariablesManager
    Private especialidadManager As New EspecialidadManager
    Private _procedimientos As IEnumerable(Of Procedimiento)
    Private _areasAnalisis As IEnumerable(Of AreaAnalisis)
    Private _tablasAnalisis As IEnumerable(Of TablaAnalisis)
    Private _tablaAnalisisActual As TablaAnalisis

    Private Sub frmAnalisisLaboratorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim var = variablesManager.GetProcedimientos()
        _procedimientos = (From a In var Where a.CodEsp = "E026" Select a)
        Dim dtProce As New DataTable
        dtProce.Columns.Add("IdProcedimiento", GetType(Integer))
        dtProce.Columns.Add("Procedimiento", GetType(String))
        For Each proc In _procedimientos
            dtProce.Rows.Add(proc.IdProcedimiento, proc.Procedimiento1)
        Next

        cmbProcedimiento.DataSource = dtProce
        cmbProcedimiento.DisplayMember = "Procedimiento"
        cmbProcedimiento.ValueMember = "IdProcedimiento"

        _areasAnalisis = variablesManager.GetAreaAnalisis()
        Dim dtArea As New DataTable
        dtArea.Columns.Add("IdAreaAnalisis", GetType(Integer))
        dtArea.Columns.Add("AreaAnalisis", GetType(String))

        For Each _area In _areasAnalisis
            dtArea.Rows.Add(_area.IdAreaAnalisis, _area.AreaAnalisisDes.Trim)
        Next

        cmbAreaAnalisis.DataSource = dtArea
        cmbAreaAnalisis.DisplayMember = "AreaAnalisis"
        cmbAreaAnalisis.ValueMember = "IdAreaAnalisis"

        _tablasAnalisis = variablesManager.GetTablasAnalisis()
        Controles_En_Load()
    End Sub


    Sub Controles_En_Load()
        ClearGroup(grpManagement)
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)
        Lista()
        bolEsModificar = False
        Me.ActiveControl = Me.txtBusqueda
        _tablaAnalisisActual = New TablaAnalisis()
    End Sub

    Sub Lista()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each _tabla In _tablasAnalisis
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells(IdAnalisis.Name).Value = _tabla.IdAnalisis
                .Cells(CodAna.Name).Value = _tabla.CodAna
                .Cells(Analisis.Name).Value = _tabla.Analisis
                .Cells(Unidad.Name).Value = _tabla.Unidad
                .Cells(Titulo.Name).Value = _tabla.Titulo
                .Cells(CodPro.Name).Value = _tabla.CodPro
                .Cells(Procedimiento.Name).Value = _tabla.Procedimiento
                .Cells(CodPro.Name).Value = _tabla.CodPro
                .Cells(AreaLaboratorio.Name).Value = _tabla.AreaLaboratorio
                .Cells(AreaAnalisis.Name).Value = _tabla.AreaAnalisis
            End With
        Next

    End Sub

    Private Sub txtBusqueda_TextChanged(sender As Object, e As EventArgs) Handles txtBusqueda.TextChanged
        For i As Integer = 0 To dgvPagoDctoBasico.Rows.Count - 1
            If Me.dgvPagoDctoBasico.Rows(i).Cells(CodAna.Name).Value.ToString.StartsWith(Me.txtBusqueda.Text, StringComparison.InvariantCultureIgnoreCase) Or
                Me.dgvPagoDctoBasico.Rows(i).Cells(Analisis.Name).Value.ToString.StartsWith(Me.txtBusqueda.Text, StringComparison.InvariantCultureIgnoreCase) Then
                'Me.dgvPagoDctoBasico.Rows(i).Cells("Descripcion").Selected = True
                'Me.dgvPagoDctoBasico.CurrentCell = dgvPagoDctoBasico.SelectedCells(1)
                Me.dgvPagoDctoBasico.CurrentCell = dgvPagoDctoBasico.Item(2, i)
                Me.dgvPagoDctoBasico.FirstDisplayedScrollingRowIndex = i

                Exit For
            End If
        Next
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bolEsModificar = False
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.dgvPagoDctoBasico.CurrentRow IsNot Nothing Then

            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)

            ClearGroup(grpManagement)
            Dim IdAreaAnalisis = Me.dgvPagoDctoBasico.CurrentRow.Cells.Item(IdAnalisis.Name).Value
            _tablaAnalisisActual = (From a In _tablasAnalisis
                                    Where a.IdAnalisis = IdAreaAnalisis
                                    Select a).FirstOrDefault()

            bolEsModificar = True
            RegistroData()
        End If
    End Sub


    Private Sub RegistroData()

        If _tablaAnalisisActual IsNot Nothing AndAlso _tablaAnalisisActual.IdAnalisis > 0 Then

            Me.txtCodigo.Text = _tablaAnalisisActual.CodAna
            Me.txtAnalisis.Text = _tablaAnalisisActual.Analisis
            Me.txtUnidad.Text = _tablaAnalisisActual.Unidad
            Me.cmbProcedimiento.SelectedValue = _tablaAnalisisActual.IdProcedimiento
            Me.cmbAreaAnalisis.SelectedIndex = cmbAreaAnalisis.FindString(_tablaAnalisisActual.AreaAnalisis.Trim)
            Me.txtAreaLaboratorio.Text = _tablaAnalisisActual.AreaLaboratorio
            'Me.txtEspecialidad.Text = _especialidadActual.Descripcion
            'Me.txtMontoMedico.Text = FormatearNumero(_especialidadActual.MontoMedico, 2)
            'Me.txtPrecioConsulta.Text = FormatearNumero(_especialidadActual.PrecioConsulta, 2)
        End If


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Controles_En_Load()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If bolEsModificar = True Then

            _tablaAnalisisActual.Analisis = txtAnalisis.Text
            _tablaAnalisisActual.Unidad = txtUnidad.Text
            _tablaAnalisisActual.IdProcedimiento = Me.cmbProcedimiento.SelectedValue
            Dim var = (From a In _procedimientos Where a.IdProcedimiento = _tablaAnalisisActual.IdProcedimiento).FirstOrDefault()
            _tablaAnalisisActual.CodPro = var.CodPro
            _tablaAnalisisActual.Procedimiento = var.Procedimiento1
            _tablaAnalisisActual.AreaAnalisis = Me.cmbAreaAnalisis.Text
            Dim tabl = variablesManager.RegistrarTablaAnalisis(_tablaAnalisisActual)
            'Notificar(especialidad.CodEsp & ": Modificado", "")
        Else
            Dim var = (From a In _procedimientos Where a.IdProcedimiento = Me.cmbProcedimiento.SelectedValue).FirstOrDefault()
            Dim nuevoTablaAnalisis As TablaAnalisis = New TablaAnalisis(Me.txtAnalisis.Text, Me.txtUnidad.Text, var.IdProcedimiento, var.CodPro, var.Procedimiento1, cmbAreaAnalisis.Text)
            Dim tabl = variablesManager.RegistrarTablaAnalisis(nuevoTablaAnalisis)
        End If
        _tablasAnalisis = variablesManager.GetTablasAnalisis()
        ''_procedimientos = variablesManager.GetProcedimientos()
        Controles_En_Load()
    End Sub
End Class