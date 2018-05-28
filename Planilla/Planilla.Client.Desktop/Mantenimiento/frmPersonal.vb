Imports Core.Common.Core
Imports Planilla.Business
Imports Planilla.Business.Entities
Imports Planilla.Business.Managers
Imports Planilla.Client.Utils.clsUtils
Imports System.Net


Public Class frmRemuneracionBasica

    Private bolEsModificar = False
    Private personalManager As New PersonalManager
    Private _personal As IEnumerable(Of Personal)


    Private Sub frmRemuneracionBasica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _personal = personalManager.GetPersonalActivo()
        Controles_En_Load()
        ListaPersonal()

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

        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpListar)
    End Sub


    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        bolEsModificar = True
        If dgvPagoDctoBasico.CurrentRow IsNot Nothing Then
            Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
            Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
            Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
            LlenarDatosPagoDctoBasico()
        End If
    End Sub

    Sub LlenarDatosPagoDctoBasico()


    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        bolEsModificar = False
        Me.tbcOtrosPagos.TabPages.Remove(tbpListar)
        Me.tbcOtrosPagos.TabPages.Remove(tbpNuevo)
        Me.tbcOtrosPagos.TabPages.Insert(0, tbpNuevo)
    End Sub

    Public Sub ListarPagoDctoBasicoPorPersona(ByVal IdPersona As Integer, ByVal IdLegajo As Integer, ByVal IdEstado As Integer)
        Me.dgvPagoDctoBasico.Rows.Clear()


        'Dim ObjPlnPagoDctoBasico As New clsPlnPagoDctoBasicoBUS
        'Dim dtBase As DataTable = ObjPlnPagoDctoBasico.fncListarPagoDctoBasicoPorCamposBUS(-1, IdEstado, -1, IdPersona, IdLegajo)
        'If fncValidaDataTable(dtBase) = True Then
        '    For i As Integer = 0 To dtBase.Rows.Count - 1
        '        dgvPagoDctoBasico.Rows.Add()
        '        With dgvPagoDctoBasico.Rows(i)
        '            .Cells("IdPlnPagoDescuentoBasico").Value = ObtenerValorCelda(dtBase.Rows(i), "IdPlnPagoDescuentoBasico")
        '            .Cells("Descripcion").Value = ObtenerValorCelda(dtBase.Rows(i), "Descripcion")
        '            .Cells("Estado").Value = ObtenerValorCelda(dtBase.Rows(i), "Estado")
        '            .Cells("EsPago").Value = ObtenerValorCelda(dtBase.Rows(i), "EsPago")
        '            .Cells("IdPlnTipoComponente").Value = ObtenerValorCelda(dtBase.Rows(i), "IdPlnTipoComponente")
        '            .Cells("TipoComponente").Value = ObtenerValorCelda(dtBase.Rows(i), "TipoComponente")
        '            .Cells("IdPlnConceptoPagoDctoBasico").Value = ObtenerValorCelda(dtBase.Rows(i), "IdPlnConceptoPagoDctoBasico")
        '            .Cells("ConceptoPDB").Value = ObtenerValorCelda(dtBase.Rows(i), "ConceptoPDB")
        '            .Cells("Monto").Value = String.Format("{0:0,0.00}", ObtenerValorCelda(dtBase.Rows(i), "Monto"))
        '            .Cells("IdPersona").Value = ObtenerValorCelda(dtBase.Rows(i), "IdPersona")
        '            .Cells("IdLegajo").Value = ObtenerValorCelda(dtBase.Rows(i), "IdLegajo")
        '            .Cells("IdPlnDocumento").Value = ObtenerValorCelda(dtBase.Rows(i), "IdPersona")
        '            .Cells("IdLegajo").Value = ObtenerValorCelda(dtBase.Rows(i), "IdLegajo")
        '            .Cells("IdPlnDocumento").Value = ObtenerValorCelda(dtBase.Rows(i), "IdPlnDocumento")
        '            .Cells("Documento").Value = ObtenerValorCelda(dtBase.Rows(i), "Numero") & "-" & ObtenerValorCelda(dtBase.Rows(i), "Documento") & "-" & ObtenerValorCelda(dtBase.Rows(i), "DescripcionDocumento")
        '        End With
        '    Next
        'End If
    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'If Me.txtIdConceptoPagoDctoBasico.Text.Trim.Length = 0 Or Me.txtIdDocumento.Text.Trim.Length = 0 Then
        '    Notificar("Seleccione Concepto y/o Documento")
        '    Exit Sub
        'End If
        'Dim ObjPagoDctoBasico As New clsPlnPagoDctoBasicoBUS
        'Dim ObjDiccionario As New clsPlnDiccionarioOperacionBUS

        'If bolEsModificar = True Then

        '    Dim dtBase As DataTable = ObjPagoDctoBasico.fncConsultarBUS(CInt(Me.txtIdPagoDctoBasico.Text))
        '    If fncValidaDataTable(dtBase) = True Then
        '        With ObjPagoDctoBasico
        '            .fncSetearBUS(dtBase.Rows(0))
        '            .Descripcion = Me.txtDescripcion.Text
        '            .IdPlnDocumento = If(IsNumeric(Me.txtIdDocumento.Text), CInt(Me.txtIdDocumento.Text), DBNull.Value)
        '            .IdPlnConceptoPagoDctoBasico = CInt(Me.txtIdConceptoPagoDctoBasico.Text)
        '            .IdPlnTipoComponente = CInt(Me.txtIdTipoComponente.Text)
        '            .Estado = Me.cmbEstado.SelectedValue
        '            .EsPago = If(Me.rbEsPago.Checked = True, enmEstado.Activo, enmEstado.Inactivo)
        '            .MONTO = CDec(Me.txtMonto.Text)
        '            .FechaModifica = FechaHoraServidor()
        '            .UsuarioModifica = modPlanilla.intPRFid
        '            .DireccionIP = DatosRedIp()
        '            .DireccionMAC = DatosRedMac()
        '            If .fncModificarBUS() > 0 Then
        '                With ObjDiccionario
        '                    Dim dtDiccionario As DataTable = .fncConsultarBUS(CInt(Me.txtIdPlnDiccionario.Text))
        '                    If fncValidaDataTable(dtDiccionario) = True Then
        '                        .fncSetearBUS(dtDiccionario.Rows(0))
        '                        .IdPlnTipoComponente = CInt(Me.txtIdTipoComponente.Text)
        '                        .Estado = cmbEstado.SelectedValue
        '                        If .fncModificarBUS() > 0 Then
        '                            btnCancelar.PerformClick()
        '                        End If
        '                    End If
        '                End With
        '            End If
        '        End With
        '    End If
        'Else
        '    'With ObjDiccionario 
        '    With ObjPagoDctoBasico

        '        'IdPlnPagoDescuentoBasico
        '        'Descripcion
        '        'Estado
        '        'IdPlnTipoComponente
        '        'IdPlnConcepto()
        '        'EsPago
        '        'FechaRegistra()
        '        'FechaModifica()
        '        'UsuarioRegistra()
        '        'UsuarioModifica()
        '        'DireccionIP()
        '        'DireccionMAC()
        '        'Porcentaje()
        '        'Monto
        '        'IdPlnConceptoPagoDctoBasico
        '        'IdPersona
        '        'IdLegajo

        '        .Descripcion = Me.txtDescripcion.Text
        '        .IdPlnDocumento = If(IsNumeric(Me.txtIdDocumento.Text), CInt(Me.txtIdDocumento.Text), DBNull.Value)
        '        .IdPlnTipoComponente = CInt(Me.txtIdTipoComponente.Text)
        '        .IdPlnConceptoPagoDctoBasico = CInt(Me.txtIdConceptoPagoDctoBasico.Text)
        '        .Estado = Me.cmbEstado.SelectedValue
        '        .EsPago = If(Me.rbEsPago.Checked = True, enmEstado.Activo, enmEstado.Inactivo)
        '        .Porcentaje = 0
        '        .IdPlnConcepto = DBNull.Value
        '        .IdLegajo = CInt(Me.txtIdLegajo.Text)
        '        .IdPersona = CInt(Me.txtIdPersona.Text)
        '        .MONTO = CDec(Me.txtMonto.Text)
        '        .FechaModifica = FechaHoraServidor()
        '        .FechaRegistra = FechaHoraServidor()
        '        .UsuarioRegistra = modPlanilla.intPRFid
        '        .UsuarioModifica = modPlanilla.intPRFid
        '        .DireccionIP = DatosRedIp()
        '        .DireccionMAC = DatosRedMac()
        '        If .fncRegistrarBUS() > 0 Then
        '            With ObjDiccionario
        '                .IdPlnOperacion = ObjPagoDctoBasico.IdPlnPagoDescuentoBasico
        '                .Estado = Me.cmbEstado.SelectedValue
        '                .Descripcion = "Pago Descuento Básico"
        '                .IdPlnTipoComponente = CInt(Me.txtIdTipoComponente.Text)
        '                .FechaRegistro = FechaHoraServidor()
        '                If .fncRegistrarBUS() > 0 Then
        '                    Notificar("Ingresado con éxito")
        '                    btnCancelar.PerformClick()
        '                Else
        '                    Notificar("Error")
        '                    Exit Sub
        '                End If
        '            End With
        '        Else
        '            Notificar("Error en registro nuevo")
        '            Exit Sub
        '        End If
        '    End With
        'End If


    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Controles_En_Load()
    End Sub

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
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
                Validar_NumericoV(Me.txtMonto, e.KeyChar, vCapturar)
                e.Handled = vCapturar
            Catch ex As Exception

                e.Handled = True
                Me.txtMonto.Text = "0.00"
            End Try

        End If
    End Sub

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.Leave
        If txtMonto.Text.Trim.Length = 0 Then
            txtMonto.Text = "0.00"
        End If
    End Sub

    Private Sub btnBuscarDocumento_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim ObjFrmHijo As New frmMantenimientoDocumento
        'ObjFrmHijo.strFrmPadre = Me.Name
        'ObjFrmHijo.bolEsBusqueda = True
        'ObjFrmHijo.Owner = Me
        'ObjFrmHijo.ShowDialog()
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        If Me.dgvPagoDctoBasico.CurrentRow IsNot Nothing Then

            'Dim ObjRemuneracionBasica As New clsPlnPagoDctoBasicoBUS
            'Dim dtBase As DataTable = ObjRemuneracionBasica.fncListarPagoDctoBasicoPorCamposBUS(Me.dgvPagoDctoBasico.CurrentRow.Cells("IdPlnPagoDescuentoBasico").Value, _
            '                                                                                    enmEstado.Activo, _
            '                                                                                    -1, _
            '                                                                                    CInt(Me.txtIdPersona.Text), _
            '                                                                                    CInt(Me.txtIdLegajo.Text))


            'If fncValidaDataTable(dtBase) = True Then

            '    If lstComponentes.Contains(ObtenerValorCelda(dtBase.Rows(0), "CodigoComponente")) Then
            '        Select Case strFrmPadre
            '            Case "frmMantenimientoPlanilla"
            '                Dim ObjFrmPadre As frmMantenimientoPlanilla
            '                ObjFrmPadre = CType(Me.Owner, frmMantenimientoPlanilla)

            '                ObjFrmPadre.dgvDetallePersonaExtendido.Rows.Add()
            '                With ObjFrmPadre.dgvDetallePersonaExtendido.Rows(ObjFrmPadre.dgvDetallePersonaExtendido.Rows.Count - 1)
            '                    .Cells("cIdDetallePlanilla").Value = 0
            '                    .Cells("cIdPlanilla").Value = CInt(ObjFrmPadre.txtIdPlanilla.Text)
            '                    .Cells("cIdPlnTipoComponente").Value = ObtenerValorCelda(dtBase.Rows(0), "IdPlnTipoComponente")
            '                    .Cells("cCodigo").Value = ObtenerValorCelda(dtBase.Rows(0), "CodigoComponente")
            '                    .Cells("cIdPlnDiccionario").Value = ObtenerValorCelda(dtBase.Rows(0), "IdPlnDiccionario")
            '                    .Cells("cComponente").Value = ObtenerValorCelda(dtBase.Rows(0), "TipoComponente")
            '                    .Cells("cDetalle").Value = ObtenerValorCelda(dtBase.Rows(0), "Descripcion")
            '                    .Cells("cDetalleOriginal").Value = ObtenerValorCelda(dtBase.Rows(0), "Descripcion")
            '                    .Cells("cMontoCalculado").Value = ObtenerValorCelda(dtBase.Rows(0), "Monto")
            '                    .Cells("cMontoFinal").Value = ObtenerValorCelda(dtBase.Rows(0), "Monto")
            '                    .Cells("cEstado").Value = enmEstado.Activo
            '                    .Cells("cEsIncremento").Value = ObtenerValorCelda(dtBase.Rows(0), "EsPago")
            '                    '.Cells("cEsUnico").Value = Me.dgvOtrosPagos.CurrentRow.Cells("EsUnico").Value
            '                    .Cells("cPorcentajeUsado").Value = "0.00"
            '                    .Cells("cPorcentajeUsadoOriginal").Value = "0.00"
            '                    .Cells("cMontoFinalOriginal").Value = ObtenerValorCelda(dtBase.Rows(0), "Monto")
            '                    .Cells("cDetalleOriginal").Value = ObtenerValorCelda(dtBase.Rows(0), "Descripcion")
            '                    .Cells("cEsCargoEmpleador").Value = ObtenerValorCelda(dtBase.Rows(0), "EsCargoEmpleador")
            '                    .Cells("cEsCargoTrabajador").Value = ObtenerValorCelda(dtBase.Rows(0), "EsCargoTrabajador")
            '                End With
            '                'ObjFrmPadre.GenerarActualizarMontosAfectos(enmTipoComponente.BonificacionesRegulares)
            '                ObjFrmPadre.dgvDetallePersonaExtendido.Refresh()
            '                ObjFrmPadre.dgvDetallePersonaExtendido.ClearSelection()
            '                ObjFrmPadre.ControlesDetalleExtendido(2)
            '                'ObjFrmPadre.CalcularTotalesPersonaExtendida()
            '                Me.Close()



            '        End Select
            '    Else
            '        Notificar("Este tipo de planilla no admite este componente")
            '    End If


            'End If

        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


End Class