Imports Planilla.Client.Utils.clsUtils


Module modPersonal

    ' Parámetros Reporte Resumen Planilla
    Public strTotalPagoPersonas As String
    Public strAFPMonto As String
    Public strONP As String
    Public strESSALUD As String
    Public strRentaQuinta As String
    Public strADepositar As String
    Public strSCTR As String
    Public strPeriodo As String
    ' Fin 

    ' Parámetros Reporte Boletas
    Public dtBoleta As New DataTable
    ' Fin

    Public intIdFacultad As Integer
    Public intIdPtaDependencia As Integer
    Public intIdChoSemestre As Integer
    Public intIdUsuario As Integer
    Public strFacultad As String
    Public datFechaInicio As Date
    Public datFechaFin As Date

    Public intIdPlnPeriodo As Integer
    Public datAsistenciaDesde As Date
    Public datAsistenciaHasta As Date
    Public datCalculaDesde As Date
    Public datCalculaHasta As Date
    Public intMesPlanilla As Integer
    Public strMesPlanilla As String
    Public intAnioPlanilla As Integer
    Public strAnioPlanilla As String
    Public strDescripcionPlanilla As String

    Public strObservacion As String
    Public strSemestre As String

    Public intSISid As Integer
    Public intPRFid As Integer
    Public strPRFnombre As String
    Public intSISadminID As Integer
    'Public Function ObtenerFechaHora() As DateTime
    '    Dim ObjPersona As New clsPersonaBUS
    '    Return ObjPersona.fncConsultarFechaHoraServidorBUS
    'End Function


    Public Sub ProcComboBoxAMes(ByVal pComboBox As ComboBox)
        ' Dim ObjAuxiliar As New clsco2_auxiliarBUS
        ' Dim dmFechaHoy As Date = ObjAuxiliar.fncConsultarFechaHoraServidorBUS
        pComboBox.DataSource = Nothing

        Dim intMes As Integer = FechaHoraServidor.Month

        Dim ObjDataTable As New DataTable
        ObjDataTable.Columns.Add("IdMes", GetType(Integer))
        ObjDataTable.Columns.Add("Nombre", GetType(String))
        ObjDataTable.Rows.Add(1, "ENERO")
        ObjDataTable.Rows.Add(2, "FEBRERO")
        ObjDataTable.Rows.Add(3, "MARZO")
        ObjDataTable.Rows.Add(4, "ABRIL")
        ObjDataTable.Rows.Add(5, "MAYO")
        ObjDataTable.Rows.Add(6, "JUNIO")
        ObjDataTable.Rows.Add(7, "JULIO")
        ObjDataTable.Rows.Add(8, "AGOSTO")
        ObjDataTable.Rows.Add(9, "SEPTIEMBRE")
        ObjDataTable.Rows.Add(10, "OCTUBRE")
        ObjDataTable.Rows.Add(11, "NOVIEMBRE")
        ObjDataTable.Rows.Add(12, "DICIEMBRE")


        pComboBox.DataSource = ObjDataTable
        pComboBox.ValueMember = "IdMes"
        pComboBox.DisplayMember = "Nombre"
        pComboBox.SelectedValue = intMes
    End Sub

    Public Sub ProcComboBoxAAnio(ByVal cmbBase As ComboBox)
        cmbBase.DataSource = Nothing
        Dim intAnio As Integer = FechaHoraServidor.Year
        Dim dtAnio As New DataTable
        dtAnio.Columns.Add("IdAnio", GetType(Integer))
        dtAnio.Columns.Add("Anio", GetType(Integer))

        For i As Integer = 1 To 12
            dtAnio.Rows.Add(intAnio - (6 - i), (intAnio - (6 - i)).ToString)
        Next

        cmbBase.DataSource = dtAnio
        cmbBase.ValueMember = "IdAnio"
        cmbBase.DisplayMember = "Anio"
        cmbBase.SelectedValue = intAnio

    End Sub

    Public Sub ProcComboBoxEstado(ByVal cmbBase As ComboBox)

        cmbBase.DataSource = Nothing
        Dim dtEstado As New DataTable
        dtEstado.Columns.Add("IdEstado", GetType(Integer))
        dtEstado.Columns.Add("Estado", GetType(String))


        Dim items As Array
        items = System.Enum.GetValues(GetType(enmEstado))
        For Each intItem As Integer In items
            dtEstado.Rows.Add(intItem, EstadoPorEntero(intItem))
        Next

        cmbBase.DataSource = dtEstado
        cmbBase.ValueMember = "IdEstado"
        cmbBase.DisplayMember = "Estado"
        cmbBase.SelectedValue = enmEstado.Activo

    End Sub

    Public Sub ProcComboBoxCerrado(ByVal cmbBase As ComboBox)

        cmbBase.DataSource = Nothing
        Dim dtEstado As New DataTable
        dtEstado.Columns.Add("IdCerrado", GetType(Integer))
        dtEstado.Columns.Add("Cerrado", GetType(String))


        Dim items As Array
        items = System.Enum.GetValues(GetType(enmCerrado))
        For Each intItem As Integer In items
            dtEstado.Rows.Add(intItem, CerradoPorEntero(intItem))
        Next

        cmbBase.DataSource = dtEstado
        cmbBase.ValueMember = "IdCerrado"
        cmbBase.DisplayMember = "Cerrado"
        cmbBase.SelectedValue = enmCerrado.Abierto
    End Sub

    Public Sub ProcComboBoxVerdaderoFalso(ByVal cmbBase As ComboBox)
        Dim dtEstado As New DataTable
        dtEstado.Columns.Add("IdVF", GetType(Integer))
        dtEstado.Columns.Add("VF", GetType(String))

        dtEstado.Rows.Add(0, "Falso")
        dtEstado.Rows.Add(1, "Verdadero")

        cmbBase.DataSource = dtEstado
        cmbBase.ValueMember = "IdVF"
        cmbBase.DisplayMember = "VF"
        cmbBase.SelectedValue = 1

    End Sub

    Public Function CerradoPorEntero(ByVal intCerrado As Integer) As String
        Select Case intCerrado
            Case 1
                Return "Cerrado"
            Case 0
                Return "Abierto"
            Case Else
                Return "Otro"
        End Select
    End Function

    Public Function EstadoPorEntero(ByVal intEstado As Integer) As String
        Select Case intEstado
            Case 1
                Return "Activo"
            Case 0
                Return "Inactivo"
            Case Else
                Return "Otro"
        End Select
    End Function

    Public Function fncTextoMesPorIntMes(ByVal intMes As Integer)
        Select Case intMes
            Case 1
                Return "Enero"
            Case 2
                Return "Febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "Mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Setiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
            Case Else
                Return "No Contest"
        End Select
    End Function

    '<Extension()>
    'Public Function ToRtf(ByVal s As String) As String
    '    Return "{\rtf1\ansi" + s + "}"
    'End Function

    '<Extension()>
    'Public Function ToBold(ByVal s As String) As String
    '    Return String.Format("\b {0}\b0 ", s)
    'End Function

    Public Function fncLimpiarNombreEscuela(ByVal strFuente As String) As String
        If strFuente.ToLower.StartsWith("escuela profesional de") Then
            Dim intLenComp As Integer = "escuela profesional de".Length
            Return strFuente.Substring(intLenComp, strFuente.Length - intLenComp)
        ElseIf strFuente.ToLower.StartsWith("escuela profesional de") Then
            Dim intLenComp As Integer = "post-grado en".Length
            Return strFuente.Substring(intLenComp, strFuente.Length - intLenComp)
        ElseIf strFuente.ToLower.StartsWith("administración de") Then
            Dim intLenComp As Integer = "administración de".Length
            Return strFuente.Substring(intLenComp, strFuente.Length - intLenComp)
        Else
            Return fncFormateaContenido(28, strFuente, 1)
        End If
    End Function

    ''' <summary>
    ''' Formatea contenido de rectangulo. 1: Modo titulo
    ''' </summary>
    ''' <param name="intLongitudMax">Long maxima</param>
    ''' <param name="strFuente">str base</param>
    ''' <param name="intCase">identificador</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fncFormateaContenido(ByVal intLongitudMax As Integer, ByVal strFuente As String, ByVal intCase As Integer) As String
        If strFuente.Length() > intLongitudMax Then
            strFuente = strFuente.Substring(0, intLongitudMax)
        End If

        If intCase = 1 Then
            Return StrConv(strFuente, VbStrConv.ProperCase)
        Else
            Return strFuente
        End If
    End Function


    Public Function fncGeneraAbreviacionMovimiento(ByVal strOriginal As String) As String

        Select Case strOriginal
            Case "Incremento"
                Return "Inc"
            Case "Modificado"
                Return "Mod"
            Case "Disminución"
                Return "Dis"
            Case Else
                Return "nul"
        End Select
    End Function


    Public Function fncGeneraAbreviacionModalidad(ByVal strOriginal As String) As String
        '        NOMBRADOS()
        '        CONTRATADOS()
        'LOCACION DE SERVICIOS
        '        POR(PROYECTO)
        '        POR(CONTRATO)
        '        ASIGNATURA(COMUN)
        Dim strRespuesta As String = String.Empty

        Select Case strOriginal
            Case "NOMBRADOS"
                strRespuesta = "NOM"
            Case "CONTRATADOS"
                strRespuesta = "CON"
            Case "LOCACION DE SERVICIOS"
                strRespuesta = "LOC"
            Case "POR PROYECTO"
                strRespuesta = "PPY"
            Case "POR CONTRATO"
                strRespuesta = "PCO"
            Case "ASIGNATURA COMUN"
                strRespuesta = "ASC"
        End Select

        Return strRespuesta

    End Function

    ''' <summary>
    ''' Obtiene la fila actual de un DataGridView en forma de un DataRow
    ''' </summary>
    ''' <param name="dgvFuente">DataGridView fuente</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fncObtenerFilaActual(ByVal dgvFuente As DataGridView) As DataRow
        If dgvFuente.DataSource IsNot Nothing AndAlso dgvFuente.RowCount > 0 Then
            Dim bm As BindingManagerBase = dgvFuente.BindingContext(dgvFuente.DataSource, dgvFuente.DataMember)
            Dim dr As DataRow = CType(bm.Current, DataRowView).Row
            Return dr
        Else
            Return Nothing
        End If
    End Function
End Module
