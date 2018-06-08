Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net

Public Class frmResumenAnualPlanillas
    Private planillaManager As New PersonalManager
    Private _personal As IEnumerable(Of Personal)

    Private Sub frmResumenAnualPlanillas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtAnioAProgramar.Text = Date.Now.Year
        Me.ActiveControl = Me.txtAnioAProgramar

        _personal = planillaManager.GetPersonalActivo()

        Dim dtPersona As New DataTable
        dtPersona.Columns.Add("Id", GetType(Integer))
        dtPersona.Columns.Add("Descripcion", GetType(String))
        dtPersona.Rows.Add(0, "(Todos)")
        For Each _persona In _personal
            dtPersona.Rows.Add(_persona.IdPersonal, _persona.ApePaterno & " " & _persona.ApeMaterno & ", " & _persona.Nombre & " - " & _persona.CodPer)
        Next

        cmbPersonal.DataSource = dtPersona
        cmbPersonal.DisplayMember = "Descripcion"
        cmbPersonal.ValueMember = "Id"
        cmbPersonal.SelectedValue = 0

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim resumen = planillaManager.GetResumenPlanilla(txtAnioAProgramar.Text, cmbPersonal.SelectedValue)
        Dim normales = resumen("N")
        Dim subnormal = resumen("SN")
        Dim gratis = resumen("G")
        Dim subgrati = resumen("SG")
        Dim total = resumen("T")

        Me.dgvPagoDctoBasico.Rows.Clear()
        IngresarEnGrid("Regulares", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        If normales IsNot Nothing AndAlso normales.Count > 0 Then
            For Each normal In normales
                IngresarEnGrid(fncTextoMesPorIntMes(CInt(normal.Periodo.Substring(4, 2))), FormatearNumero(normal.RemBasica, 2), FormatearNumero(normal.AsigFamiliar, 2),
                               FormatearNumero(normal.Subsidio, 2), FormatearNumero(normal.Gratificacion, 2),
                               FormatearNumero(normal.RemVacacional, 2), FormatearNumero(normal.RiesgoCaja, 2), FormatearNumero(normal.Reintegro, 2), FormatearNumero(normal.HorasExtra, 2),
                               FormatearNumero(normal.OtrosIng, 2), FormatearNumero(normal.TotalIngresos, 2), FormatearNumero(normal.ONP, 2), FormatearNumero(normal.AporteObligatorio, 2),
                               FormatearNumero(normal.PrimarSeguro, 2), FormatearNumero(normal.ComisionVariable, 2), FormatearNumero(normal.QuintaCategoria, 2), FormatearNumero(normal.OtrosDescuentos, 2),
                               FormatearNumero(normal.TotalDescuentos, 2), FormatearNumero(normal.Neto, 2), FormatearNumero(normal.Essalud, 2), FormatearNumero(normal.SCTR, 2), FormatearNumero(normal.TotalAportes, 2))
            Next
        End If

        If subnormal IsNot Nothing AndAlso subnormal.Count > 0 Then
            IngresarEnGrid(subnormal(0).Periodo, FormatearNumero(subnormal(0).RemBasica, 2), FormatearNumero(subnormal(0).AsigFamiliar, 2),
                           FormatearNumero(subnormal(0).Subsidio, 2), FormatearNumero(subnormal(0).Gratificacion, 2),
                           FormatearNumero(subnormal(0).RemVacacional, 2), FormatearNumero(subnormal(0).RiesgoCaja, 2), FormatearNumero(subnormal(0).Reintegro, 2), FormatearNumero(subnormal(0).HorasExtra, 2),
                           FormatearNumero(subnormal(0).OtrosIng, 2), FormatearNumero(subnormal(0).TotalIngresos, 2), FormatearNumero(subnormal(0).ONP, 2), FormatearNumero(subnormal(0).AporteObligatorio, 2),
                           FormatearNumero(subnormal(0).PrimarSeguro, 2), FormatearNumero(subnormal(0).ComisionVariable, 2), FormatearNumero(subnormal(0).QuintaCategoria, 2), FormatearNumero(subnormal(0).OtrosDescuentos, 2),
                           FormatearNumero(subnormal(0).TotalDescuentos, 2), FormatearNumero(subnormal(0).Neto, 2), FormatearNumero(subnormal(0).Essalud, 2), FormatearNumero(subnormal(0).SCTR, 2), FormatearNumero(subnormal(0).TotalAportes, 2))
        End If


        IngresarEnGrid("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        IngresarEnGrid("Gratificaciones", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        If gratis IsNot Nothing AndAlso gratis.Count > 0 Then
            For Each grati In gratis
                IngresarEnGrid(fncTextoMesPorIntMes(CInt(grati.Periodo.Substring(4, 2))), FormatearNumero(grati.RemBasica, 2), FormatearNumero(grati.AsigFamiliar, 2),
                               FormatearNumero(grati.Subsidio, 2), FormatearNumero(grati.Gratificacion, 2),
                               FormatearNumero(grati.RemVacacional, 2), FormatearNumero(grati.RiesgoCaja, 2), FormatearNumero(grati.Reintegro, 2), FormatearNumero(grati.HorasExtra, 2),
                               FormatearNumero(grati.OtrosIng, 2), FormatearNumero(grati.TotalIngresos, 2), FormatearNumero(grati.ONP, 2), FormatearNumero(grati.AporteObligatorio, 2),
                               FormatearNumero(grati.PrimarSeguro, 2), FormatearNumero(grati.ComisionVariable, 2), FormatearNumero(grati.QuintaCategoria, 2), FormatearNumero(grati.OtrosDescuentos, 2),
                               FormatearNumero(grati.TotalDescuentos, 2), FormatearNumero(grati.Neto, 2), FormatearNumero(grati.Essalud, 2), FormatearNumero(grati.SCTR, 2), FormatearNumero(grati.TotalAportes, 2))
            Next
        End If

        If subgrati IsNot Nothing AndAlso subgrati.Count > 0 Then
            IngresarEnGrid(subgrati(0).Periodo, FormatearNumero(subgrati(0).RemBasica, 2), FormatearNumero(subgrati(0).AsigFamiliar, 2),
                           FormatearNumero(subgrati(0).Subsidio, 2), FormatearNumero(subgrati(0).Gratificacion, 2),
                           FormatearNumero(subgrati(0).RemVacacional, 2), FormatearNumero(subgrati(0).RiesgoCaja, 2), FormatearNumero(subgrati(0).Reintegro, 2), FormatearNumero(subgrati(0).HorasExtra, 2),
                           FormatearNumero(subgrati(0).OtrosIng, 2), FormatearNumero(subgrati(0).TotalIngresos, 2), FormatearNumero(subgrati(0).ONP, 2), FormatearNumero(subgrati(0).AporteObligatorio, 2),
                           FormatearNumero(subgrati(0).PrimarSeguro, 2), FormatearNumero(subgrati(0).ComisionVariable, 2), FormatearNumero(subgrati(0).QuintaCategoria, 2), FormatearNumero(subgrati(0).OtrosDescuentos, 2),
                           FormatearNumero(subgrati(0).TotalDescuentos, 2), FormatearNumero(subgrati(0).Neto, 2), FormatearNumero(subgrati(0).Essalud, 2), FormatearNumero(subgrati(0).SCTR, 2), FormatearNumero(subgrati(0).TotalAportes, 2))
        End If

        IngresarEnGrid("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")

        If total IsNot Nothing AndAlso total.Count > 0 Then
            IngresarEnGrid("Total General", FormatearNumero(total(0).RemBasica, 2), FormatearNumero(total(0).AsigFamiliar, 2),
                           FormatearNumero(total(0).Subsidio, 2), FormatearNumero(total(0).Gratificacion, 2),
                           FormatearNumero(total(0).RemVacacional, 2), FormatearNumero(total(0).RiesgoCaja, 2), FormatearNumero(total(0).Reintegro, 2), FormatearNumero(total(0).HorasExtra, 2),
                           FormatearNumero(total(0).OtrosIng, 2), FormatearNumero(total(0).TotalIngresos, 2), FormatearNumero(total(0).ONP, 2), FormatearNumero(total(0).AporteObligatorio, 2),
                           FormatearNumero(total(0).PrimarSeguro, 2), FormatearNumero(total(0).ComisionVariable, 2), FormatearNumero(total(0).QuintaCategoria, 2), FormatearNumero(total(0).OtrosDescuentos, 2),
                           FormatearNumero(total(0).TotalDescuentos, 2), FormatearNumero(total(0).Neto, 2), FormatearNumero(total(0).Essalud, 2), FormatearNumero(total(0).SCTR, 2), FormatearNumero(total(0).TotalAportes, 2))
        End If



    End Sub

    Private Sub IngresarEnGrid(nPeriodo As String, nRemBas As String, nAsigFamiliar As String, nSubsidio As String, nGratificacion As String, nRemVacacional As String,
                               nRiesgoCaja As String, nReintegro As String, nHorasExtra As String, nOtrosIng As String, nTotalIngresos As String, nOnp As String,
                               nAporteOblig As String, nPrimaSeguro As String, nComisionVar As String, nQuinta As String, nOtrosDes As String, nTotalDes As String,
                               nNeto As String, nEssalud As String, nSCTR As String, nTotalAportes As String)
        Me.dgvPagoDctoBasico.Rows.Add()
        With Me.dgvPagoDctoBasico.Rows(Me.dgvPagoDctoBasico.Rows.Count - 1)
            .Cells(Periodo.Name).Value = nPeriodo
            .Cells(RemBasica.Name).Value = nRemBas
            .Cells(AsigFamiliar.Name).Value = nAsigFamiliar
            .Cells(Subsidio.Name).Value = nSubsidio
            .Cells(Gratificacion.Name).Value = nGratificacion
            .Cells(RemVacacional.Name).Value = nRemVacacional
            .Cells(RiesgoCaja.Name).Value = nRiesgoCaja
            .Cells(Reintegro.Name).Value = nReintegro
            .Cells(HorasExtra.Name).Value = nHorasExtra
            .Cells(OtrosIng.Name).Value = nOtrosIng
            .Cells(TotalIngresos.Name).Value = nTotalIngresos
            .Cells(ONP.Name).Value = nOnp
            .Cells(AporteObligatorio.Name).Value = nAporteOblig
            .Cells(PrimaSeguro.Name).Value = nPrimaSeguro
            .Cells(ComisionVariable.Name).Value = nComisionVar
            .Cells(QuintaCategoria.Name).Value = nQuinta
            .Cells(OtrosDescuentos.Name).Value = nOtrosDes
            .Cells(TotalDescuentos.Name).Value = nTotalDes
            .Cells(Neto.Name).Value = nNeto
            .Cells(Essalud.Name).Value = nEssalud
            .Cells(SCTR.Name).Value = nSCTR
            .Cells(TotalAportes.Name).Value = nTotalAportes
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim dtEx = DataGridViewToDataTable(dgvPagoDctoBasico, New List(Of String)(New String() {"IdPersonal"}), "Honk")
        FncDataTable2Excel(dtEx, "Resumen")
    End Sub
End Class