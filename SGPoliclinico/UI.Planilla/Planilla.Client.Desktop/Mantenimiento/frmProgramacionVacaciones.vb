Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports Planilla.Data.Contracts
Imports System.Globalization
Imports System.Net
Imports System.Threading

Public Class frmProgramacionVacaciones

    Private vacacionesManager As New VacacionesManager
    Private _vacaciones As IEnumerable(Of VacacionesPersona)

    Private Sub frmProgramacionVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar
    End Sub

    Private Sub txtAnioAProgramar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnioAProgramar.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAnioAProgramar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnioAProgramar.KeyDown
        If e.KeyCode = Keys.Enter Then
            _vacaciones = vacacionesManager.GetVacacionesPorPeriodo(txtAnioAProgramar.Text)
            Listar()
        End If
    End Sub


    Private Sub Listar()
        Me.dgvPagoDctoBasico.Rows.Clear()
        For Each vacacion In _vacaciones
            Me.dgvPagoDctoBasico.Rows.Add()
            With dgvPagoDctoBasico.Rows(dgvPagoDctoBasico.Rows.Count - 1)
                .Cells(IdVacaciones.Name).Value = vacacion.IdVacaciones
                .Cells(Anio.Name).Value = vacacion.Año
                .Cells(Codigo.Name).Value = vacacion.CodPer
                .Cells(Empleado.Name).Value = vacacion.NombrePersona
                .Cells(Area.Name).Value = vacacion.Area
                .Cells("IniProg").Value = vacacion.IniProg
                .Cells("FinProg").Value = vacacion.FinProg
                .Cells("IniEje1").Value = vacacion.IniEje1
                .Cells("FinEje1").Value = vacacion.FinEje1
                .Cells("IniEje2").Value = vacacion.IniEje2
                .Cells("FinEje2").Value = vacacion.FinEje2
                .Cells("IniEje3").Value = vacacion.IniEje3
                .Cells("FinEje3").Value = vacacion.FinEje3
            End With
        Next
        lblCantidadEmpleados.Text = "Cantidad de Empleados: " & _vacaciones.Count()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If dgvPagoDctoBasico.Rows.Count > 0 Then
            For i As Integer = 0 To dgvPagoDctoBasico.Rows.Count - 1
                Dim Id As Integer = dgvPagoDctoBasico.Rows(i).Cells(IdVacaciones.Name).Value
                ''Dim NroDias As Integer = If(IsNumeric(dgvPagoDctoBasico.Rows(i).Cells("DiasLaborados").Value), dgvPagoDctoBasico.Rows(i).Cells("DiasLaborados").Value, 0)
                Dim _iniProg As DateTime = "01/01/0001"
                Dim _finProg As DateTime = "01/01/0001"

                '' Thread.CurrentThread.CurrentCulture = New CultureInfo("pt-BR")

                DateTime.TryParse(dgvPagoDctoBasico.Rows(i).Cells(IniProg.Name).Value, _iniProg)
                DateTime.TryParse(dgvPagoDctoBasico.Rows(i).Cells(FinProg.Name).Value, _finProg)

                'If IsDate(dgvPagoDctoBasico.Rows(i).Cells(IniProg.Name).Value) Then
                '    _iniProg = CDate(dgvPagoDctoBasico.Rows(i).Cells(IniProg.Name).Value)
                'End If
                'If IsDate(dgvPagoDctoBasico.Rows(i).Cells(FinProg.Name).Value) Then
                '    _finProg = CDate(dgvPagoDctoBasico.Rows(i).Cells(FinProg.Name).Value)
                'End If

                Dim var = (From o In _vacaciones Where o.IdVacaciones = Id Select o).FirstOrDefault()
                If var IsNot Nothing And (_iniProg.Year <> 1 Or _finProg.Year <> 1) Then
                    If (var.IniProg Is Nothing Or var.IniProg <> _iniProg) AndAlso _iniProg.Year <> 1901 Then
                        var.IniProg = _iniProg
                        ''vacacionesManager.Update(var)
                    End If

                    If (var.FinProg Is Nothing Or var.FinProg <> _finProg) AndAlso _finProg.Year <> 1901 Then
                        var.FinProg = _finProg
                        ''vacacionesManager.Update(var)
                    End If

                    vacacionesManager.UpdateVacaciones(var)

                End If
            Next
        End If

        _vacaciones = vacacionesManager.GetVacacionesPorPeriodo(txtAnioAProgramar.Text)
        Listar()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        lblCantidadEmpleados.Text = "Cantidad de Empleados: 0"
        _vacaciones = New List(Of VacacionesPersona)
        Me.dgvPagoDctoBasico.Rows.Clear()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim dtEx = DataGridViewToDataTable(dgvPagoDctoBasico, New List(Of String)(New String() {"IdVacaciones"}), "Honk")
        FncDataTable2Excel(dtEx, "Vacaciones")
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _vacaciones = vacacionesManager.GetVacacionesPorPeriodo(txtAnioAProgramar.Text)
        Listar()
    End Sub
End Class