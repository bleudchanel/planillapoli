Imports System.Windows.Forms
Imports System.Net
Imports System.Threading
Imports Microsoft.Office.Interop
Imports System.Globalization
Imports System.Configuration
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Reflection
Imports Planilla.Business.Entities

Public Class clsUtils


    Public Enum enmDenominadorRentaQuinta
        Enero = 12
        Febrero = 12
        Marzo = 12
        Abril = 9
        Mayo = 8
        Junio = 8
        Julio = 8
        Agosto = 5
        Setiembre = 4
        Octubre = 4
        Noviembre = 4
        Diciembre = 1
    End Enum

    Public Enum enmVariablesGenerales
        MinutosRemuneracion = 60
        MinutosPorHoraAcademica = 50
        DiasMesRemunerativo = 30
        HorasPorTiempoCompleto = 40
    End Enum

    Public Enum enmTipoComponente
        RemuneracionJornalBasico = 76 ' Remuneración o Jornal Básico
        BonificacionesRegulares = 96
        DescuentoJudicial = 48
        AsignacionesOtorgadasRegularmente = 94 ' Para Bonificaciones al cargo
        OtrosDescuentosDeduciblesDeLaBaseImponible = 51 ' Para otros Pagos en caso de Descuento
        Tardanzas = 49 ' Tardanzas
        Inasistencias = 50 ' Inasistencias
        PermisoPorLactancia = 79 ' Remuneración por Hora de Lactancia
        MovilidadALibreDisposicion = 28
        AsignacionFamiliar = 13
        BonificacionPorTiempoServicios = 18 ' QUINQUENIO
        BonificacionPorRiesgoCaja = 17
        IncrementoSNP33 = 64
        IncrementoAfiliacionAFP1023 = 65
        IncrementoAfiliacionAFP300 = 66

        RentaQuintaCategoria = 33
        LicenciaConGoceDeHaber = 115
        TrabajoSobretiempoHoraExtra25 = 9
        TrabajoSobretiempoHoraExtra35 = 10


    End Enum

    Public Enum enmCprDiccionarioCalculos
        SueldoPorResolución = 1
        AumentoPorResolucion = 2
        BonificaciónAlCargo = 3
        Quinquenio = 4
        AsignaciónFamiliar = 5
        HorasExtra25 = 6
        HoraExtra35 = 7
        Inasistencias = 8
        Tardanzas = 9
        HoraDeLactancia = 10
        LicenciaConGoce = 11
    End Enum

    Public Enum enmCodigoTipoComponente
        Tardanzas = 704
        Inasistencias = 705
        DescuentoJudicial = 703
    End Enum

    Public Enum enmCodigoBaseAfecta
        SPP_ComisionPorcentual = 601
        SPP_PrimaDeSeguro = 606
        SPP_AportacionObligatoria = 608
        SNP_DL19990 = 607
        ESSALUD_SeguroRegular_Pensionista = 610
        RentaQuintaCategoria = 605
    End Enum

    Public Enum enmCodigoBaseSueldo
        AsignacionFamiliar = 201
        BonificacionPorRiesgoDeCaja = 304
        BonificacionPorTiempoDeServicios = 305
    End Enum

    Public Shared Function IsDate(input As String) As Boolean

        Dim result As DateTime
        Return DateTime.TryParseExact(input, "dd/mm/yyyy", CultureInfo.CreateSpecificCulture("es-PE"), DateTimeStyles.None, result)
    End Function

    Public Shared Function fncColeccionCodigosRemOrdinaria() As List(Of String)
        Dim lstCodigos As New List(Of String)
        Dim values() As Integer = CType([Enum].GetValues(GetType(enmCodigoRemuneracionOrdinaria)), Integer())

        For Each intValue As Integer In values
            lstCodigos.Add(intValue.ToString)
        Next

        Return lstCodigos
    End Function

    Public Shared Function fncColeccionCodigosRemExtraOrdinaria() As List(Of String)
        Dim lstCodigos As New List(Of String)
        Dim values() As Integer = CType([Enum].GetValues(GetType(enmCodigoRemuneracionExtraordinaria)), Integer())

        For Each intValue As Integer In values
            lstCodigos.Add(intValue.ToString)
        Next

        Return lstCodigos
    End Function

    '    End Enum

    ''' <summary>
    ''' 0 Inicio Mes || 1 Fin Mes
    ''' </summary>
    ''' <param name="intMes"></param>
    ''' <param name="intAnio"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fncInicioFinMes(ByVal intMes As Integer, ByVal intAnio As Integer) As List(Of Date)
        Dim lstDate As New List(Of Date)
        Dim dateRemDesde As New Date
        Dim dateRemHasta As New Date

        Dim dateMesActual As New DateTime(intAnio, intMes, 1)

        dateRemDesde = dateMesActual
        dateRemHasta = dateMesActual.AddMonths(1).AddDays(-1)


        lstDate.Add(dateRemDesde)
        lstDate.Add(dateRemHasta)

        Return lstDate
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strPeriodo"></param>
    ''' <returns>1 : Anio
    ''' 2 : Mes</returns>
    Public Shared Function ParsePeriodo(strPeriodo As String) As Tuple(Of Integer, Integer)
        Return New Tuple(Of Integer, Integer)(CInt(strPeriodo.Substring(4, 2)), CInt(strPeriodo.Substring(0, 4)))
    End Function


    Public Shared Sub ProcComboBoxAGrati(ByVal pComboBox As ComboBox)
        pComboBox.DataSource = Nothing

        Dim intMes As Integer = FechaHoraServidor.Month

        Dim ObjDataTable As New DataTable
        ObjDataTable.Columns.Add("IdMes", GetType(Integer))
        ObjDataTable.Columns.Add("Nombre", GetType(String))
        ObjDataTable.Rows.Add(7, "07 JULIO")
        ObjDataTable.Rows.Add(12, "12 DICIEMBRE")

        pComboBox.DataSource = ObjDataTable
        pComboBox.ValueMember = "IdMes"
        pComboBox.DisplayMember = "Nombre"
        pComboBox.SelectedValue = intMes

    End Sub

    Public Sub ProcComboBoxAMes(ByVal pComboBox As ComboBox)
        ' Dim ObjAuxiliar As New clsco2_auxiliarBUS
        ' Dim dmFechaHoy As Date = ObjAuxiliar.fncConsultarFechaHoraServidorBUS
        pComboBox.DataSource = Nothing

        Dim intMes As Integer = FechaHoraServidor.Month

        Dim ObjDataTable As New DataTable
        ObjDataTable.Columns.Add("IdMes", GetType(Integer))
        ObjDataTable.Columns.Add("Nombre", GetType(String))
        ObjDataTable.Rows.Add(1, "01 ENERO")
        ObjDataTable.Rows.Add(2, "02 FEBRERO")
        ObjDataTable.Rows.Add(3, "03 MARZO")
        ObjDataTable.Rows.Add(4, "04 ABRIL")
        ObjDataTable.Rows.Add(5, "05 MAYO")
        ObjDataTable.Rows.Add(6, "06 JUNIO")
        ObjDataTable.Rows.Add(7, "07 JULIO")
        ObjDataTable.Rows.Add(8, "08 AGOSTO")
        ObjDataTable.Rows.Add(9, "09 SETIEMBRE")
        ObjDataTable.Rows.Add(10, "10 OCTUBRE")
        ObjDataTable.Rows.Add(11, "11 NOVIEMBRE")
        ObjDataTable.Rows.Add(12, "12 DICIEMBRE")


        pComboBox.DataSource = ObjDataTable
        pComboBox.ValueMember = "IdMes"
        pComboBox.DisplayMember = "Nombre"
        pComboBox.SelectedValue = intMes
    End Sub

    Public Shared Function ClearGroup(ByVal Gb As GroupBox)
        For Each Ctr As Control In Gb.Controls
            If (TypeOf Ctr Is TextBox) Then
                If CType(Ctr, TextBox).AccessibleName = "Money" Then
                    CType(Ctr, TextBox).Text = "0.00"
                ElseIf CType(Ctr, TextBox).AccessibleName = "Money4" Then
                    CType(Ctr, TextBox).Text = "0.0000"
                Else
                    CType(Ctr, TextBox).Text = String.Empty
                End If
            End If
            If (TypeOf Ctr Is ComboBox) Then
                CType(Ctr, ComboBox).SelectedItem = 0
            End If
        Next
    End Function

    'Public Shared Sub CopyAllToClipBoard(ByVal dgv As DataGridView)
    '    dgv.SelectAll()
    '    If dataObj IsNot Nothing Then Clipboard.SetDataObject(dataObj)
    'End Sub

    'Public Shared Sub ExportClipboard(ByVal dgv As DataGridView)
    '    CopyAllToClipBoard(dgv)
    '    Dim xlexcel As Microsoft.Office.Interop.Excel.Application
    '    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
    '    Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    xlexcel = New Excel.Application()
    '    xlexcel.Visible = True
    '    xlWorkBook = xlexcel.Workbooks.Add(misValue)
    '    xlWorkSheet = CType(xlWorkBook.Worksheets.Item(1), Excel.Worksheet)
    '    Dim CR As Excel.Range = CType(xlWorkSheet.Cells(1, 1), Excel.Range)
    '    CR.[Select]()
    '    xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, True)
    'End Sub

    Public Shared Function RedondeoBCR(ByVal Valor As Decimal) As Decimal
        Dim Redondeado As Decimal = 0
        If (Valor - Math.Round(Valor, 1)) * 100 > 5 Then
            Redondeado = Math.Round(Valor, 1) + 0.05
        ElseIf (Valor - Math.Round(Valor, 1)) * 100 < 5 Then
            Redondeado = Math.Round(Valor, 1)
        Else
            Redondeado = Valor
        End If
        Return Redondeado
    End Function

    ' ''' <summary>
    ' ''' Define los Id de Tipo Operacion
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Enum enumTipoOperacion As Integer

    Public Shared Sub fncIngresaEnReportePlanilla(ByRef dtResultado As DataTable,
                                              ByVal planilla As PlanillaRemuneracion)

        Dim cm As CultureInfo = New CultureInfo("es-ES")
        Dim format As String = "dd/MM/yyyy"
        dtResultado.Rows.Add()
        With dtResultado.Rows(dtResultado.Rows.Count - 1)
            .Item("COD") = planilla.CodPer
            .Item("APEPAT") = planilla.ApellidoPaterno
            .Item("APEMAT") = planilla.ApellidoMaterno
            .Item("NOMBRES") = planilla.Nombre
            .Item("DNI") = planilla.Dni
            .Item("F.INGRESO") = planilla.FechaIngreso.ToString("dd/MM/yyyy")
            .Item("CARGO") = planilla.Cargo
            .Item("AREA") = planilla.Area
            .Item("REGIMEN PENSIONES") = planilla.AFP
            .Item("CUSPP") = planilla.CUSPP
            .Item("FLUJO/MIXTA") = planilla.TipComAFP
            .Item("REM BASICA") = planilla.RemBas
            .Item("ASIG FAMILIAR") = planilla.AsiFam
            .Item("SUBSIDIO") = planilla.Subsidio
            .Item("GRATIFICACION") = planilla.Gratif
            .Item("REM VACACIONAL") = planilla.RemVac
            .Item("RIESGO CAJA") = planilla.RieCaj
            .Item("REINTEGRO") = planilla.Reinte
            .Item("HORAS EXTRA") = planilla.HE
            .Item("OTROS INGRESOS") = planilla.OtrIng
            .Item("TOTAL INGRESOS") = planilla.TotIng
            .Item("ONP") = planilla.ONP
            .Item("APORTE OBLIGATORIO") = planilla.ApoObl
            .Item("PRIMA DE SEGURO") = planilla.PriSeg
            .Item("COMISION VARIABLE") = planilla.ComVar
            .Item("QUINTA CATEGORIA") = planilla.Quinta
            .Item("OTROS DESCUENTOS") = planilla.OtrDes
            .Item("TOTAL DESCUENTOS") = planilla.TotDes
            .Item("NETO A PAGAR") = planilla.Neto
            .Item("ESSALUD") = planilla.Essalud
            .Item("SCTR") = planilla.SCTR
            .Item("TOTAL APORTES") = planilla.TotApo
            .Item("DIAS LAB") = planilla.DiasLab
            .Item("HORAS LAB") = planilla.HorasLab
            .Item("INI VAC") = If(planilla.IniVac IsNot Nothing, CDate(planilla.IniVac).ToString("dd/MM/yyyy"), " ")
            .Item("FIN VAC") = If(planilla.FinVac IsNot Nothing, CDate(planilla.FinVac).ToString("dd/MM/yyyy"), " ")
            .Item("INI INCAP") = If(planilla.IniIncapacidad IsNot Nothing, CDate(planilla.IniIncapacidad).ToString("dd/MM/yyyy"), " ")
            .Item("FIN INCAP") = If(planilla.FinIncapacidad IsNot Nothing, CDate(planilla.FinIncapacidad).ToString("dd/MM/yyyy"), " ")
            .Item("INI SGH") = If(planilla.InicioSinGoceHaber IsNot Nothing, CDate(planilla.InicioSinGoceHaber).ToString("dd/MM/yyyy"), " ")
            .Item("FIN SGH") = If(planilla.FinSinGoceHaber IsNot Nothing, CDate(planilla.FinSinGoceHaber).ToString("dd/MM/yyyy"), " ")
        End With

    End Sub

    Public Shared Function fncDataTableReportePlanilla() As DataTable
        Dim dtResultado As New DataTable
        dtResultado.Columns.Add("COD", GetType(String))
        dtResultado.Columns.Add("APEPAT", GetType(String))
        dtResultado.Columns.Add("APEMAT", GetType(String))
        dtResultado.Columns.Add("NOMBRES", GetType(String))
        dtResultado.Columns.Add("DNI", GetType(String))
        dtResultado.Columns.Add("F.INGRESO", GetType(String))
        dtResultado.Columns.Add("CARGO", GetType(String))
        dtResultado.Columns.Add("AREA", GetType(String))
        dtResultado.Columns.Add("REGIMEN PENSIONES", GetType(String))
        dtResultado.Columns.Add("CUSPP", GetType(String))
        dtResultado.Columns.Add("FLUJO/MIXTA", GetType(String))
        dtResultado.Columns.Add("REM BASICA", GetType(Decimal))
        dtResultado.Columns.Add("ASIG FAMILIAR", GetType(Decimal))
        dtResultado.Columns.Add("SUBSIDIO", GetType(Decimal))
        dtResultado.Columns.Add("GRATIFICACION", GetType(Decimal))
        dtResultado.Columns.Add("REM VACACIONAL", GetType(Decimal))
        dtResultado.Columns.Add("RIESGO CAJA", GetType(Decimal))
        dtResultado.Columns.Add("REINTEGRO", GetType(Decimal))
        dtResultado.Columns.Add("HORAS EXTRA", GetType(Decimal))
        dtResultado.Columns.Add("OTROS INGRESOS", GetType(Decimal))
        dtResultado.Columns.Add("TOTAL INGRESOS", GetType(Decimal))
        dtResultado.Columns.Add("ONP", GetType(Decimal))
        dtResultado.Columns.Add("APORTE OBLIGATORIO", GetType(Decimal))
        dtResultado.Columns.Add("PRIMA DE SEGURO", GetType(Decimal))
        dtResultado.Columns.Add("COMISION VARIABLE", GetType(Decimal))
        dtResultado.Columns.Add("QUINTA CATEGORIA", GetType(Decimal))
        dtResultado.Columns.Add("OTROS DESCUENTOS", GetType(Decimal))
        dtResultado.Columns.Add("TOTAL DESCUENTOS", GetType(Decimal))
        dtResultado.Columns.Add("NETO A PAGAR", GetType(Decimal))
        dtResultado.Columns.Add("ESSALUD", GetType(Decimal))
        dtResultado.Columns.Add("SCTR", GetType(Decimal))
        dtResultado.Columns.Add("TOTAL APORTES", GetType(Decimal))
        dtResultado.Columns.Add("DIAS LAB", GetType(Decimal))
        dtResultado.Columns.Add("HORAS LAB", GetType(Decimal))
        dtResultado.Columns.Add("INI VAC", GetType(String))
        dtResultado.Columns.Add("FIN VAC", GetType(String))
        dtResultado.Columns.Add("INI INCAP", GetType(String))
        dtResultado.Columns.Add("FIN INCAP", GetType(String))
        dtResultado.Columns.Add("INI SGH", GetType(String))
        dtResultado.Columns.Add("FIN SGH", GetType(String))

        Return dtResultado
    End Function

    Public Shared Function fncDataTableAFP() As DataTable
        Dim dtResultado As New DataTable
        dtResultado.Columns.Add("N", GetType(Integer))
        dtResultado.Columns.Add("CUSPP", GetType(String))
        dtResultado.Columns.Add("TIP DOC", GetType(String))
        dtResultado.Columns.Add("NUMDOC", GetType(String))
        dtResultado.Columns.Add("APEPAT", GetType(String))
        dtResultado.Columns.Add("APEMAT", GetType(String))
        dtResultado.Columns.Add("NOM", GetType(String))
        dtResultado.Columns.Add("COD MOV", GetType(String))
        dtResultado.Columns.Add("FECHA MOV", GetType(String))
        dtResultado.Columns.Add("REM ASEGURABLE", GetType(Decimal))
        dtResultado.Columns.Add("APORT VOL CON FIN PREVIS", GetType(Decimal))
        dtResultado.Columns.Add("APORT VOL SIN FIN PREVIS", GetType(Decimal))
        dtResultado.Columns.Add("APORT VOL DEL EMPLEADOR", GetType(Decimal))
        dtResultado.Columns.Add("TIPO TRABAJADOR", GetType(String))
        dtResultado.Columns.Add("AFP", GetType(String))
        dtResultado.Columns.Add("AFP (USO INTERNO)", GetType(String))
        Return dtResultado
    End Function


    Public Shared Sub fncIngresaEnAFP(ByRef dtResultado As DataTable,
                                              ByVal strCUSPP As String,
                                              ByVal strNumDoc As String,
                                              ByVal strApePat As String,
                                              ByVal strApeMat As String,
                                              ByVal strNombre As String,
                                              ByVal decRemAsegurable As Decimal,
                                              ByVal strAFP As String)
        dtResultado.Rows.Add()
        With dtResultado.Rows(dtResultado.Rows.Count - 1)
            .Item("N") = dtResultado.Rows.Count
            .Item("CUSPP") = strCUSPP
            .Item("TIP DOC") = "0"
            .Item("NUMDOC") = strNumDoc
            .Item("APEPAT") = strApePat
            .Item("APEMAT") = strApeMat
            .Item("NOM") = strNombre
            .Item("COD MOV") = String.Empty
            .Item("FECHA MOV") = String.Empty
            .Item("REM ASEGURABLE") = decRemAsegurable
            .Item("APORT VOL CON FIN PREVIS") = 0
            .Item("APORT VOL SIN FIN PREVIS") = 0
            .Item("APORT VOL DEL EMPLEADOR") = 0
            .Item("TIPO TRABAJADOR") = "N"
            .Item("AFP") = String.Empty
            .Item("AFP (USO INTERNO)") = strAFP
        End With

    End Sub


    Public Shared Function fncDataTableBaseCalculo() As DataTable
        Dim dtResultado As New DataTable
        dtResultado.Columns.Add("Index", GetType(Integer))
        dtResultado.Columns.Add("IdPlnDetallePlanilla", GetType(Integer))
        dtResultado.Columns.Add("IdPlnTipoComponente", GetType(Integer))
        dtResultado.Columns.Add("IdPlnDiccionario", GetType(Integer))
        dtResultado.Columns.Add("MontoCalculado", GetType(Decimal))
        dtResultado.Columns.Add("PorcentajeUsado", GetType(Decimal))
        dtResultado.Columns.Add("IdPersona", GetType(Integer))
        dtResultado.Columns.Add("IdLegajo", GetType(Integer))
        dtResultado.Columns.Add("IdPlnConcepto", GetType(Integer))
        dtResultado.Columns.Add("Descripcion", GetType(String))
        dtResultado.Columns.Add("CantidadMinutos", GetType(Object))
        Return dtResultado
    End Function

    Public Shared Sub fncIngresaEnBaseCalculo(ByRef dtResultado As DataTable,
                                              ByVal IdPlnDetallePlanilla As Integer,
                                              ByVal IdPlnTipoComponente As Integer,
                                              ByVal IdPlnDiccionario As Integer,
                                              ByVal MontoCalculado As Decimal,
                                              ByVal PorcentajeUsado As Decimal,
                                              ByVal IdPersona As Integer,
                                              ByVal IdLegajo As Integer,
                                              ByVal IdPlnConcepto As Integer,
                                              ByVal Descripcion As String,
                                              ByVal CantidadMinutos As Integer)
        dtResultado.Rows.Add()
        With dtResultado.Rows(dtResultado.Rows.Count - 1)
            .Item("Index") = dtResultado.Rows.Count
            .Item("IdPlnDetallePlanilla") = IdPlnDetallePlanilla
            .Item("IdPlnTipoComponente") = IdPlnTipoComponente
            .Item("IdPlnDiccionario") = IdPlnDiccionario
            .Item("MontoCalculado") = RedondeoBCR(MontoCalculado)
            .Item("PorcentajeUsado") = PorcentajeUsado
            .Item("IdPersona") = IdPersona
            .Item("IdLegajo") = IdLegajo
            .Item("IdPlnConcepto") = IdPlnConcepto
            .Item("Descripcion") = Descripcion
            .Item("CantidadMinutos") = CantidadMinutos
        End With

    End Sub


    Public Shared Function fncDataEstructuraBaseReporte() As DataTable
        Dim dtResultado As New DataTable
        dtResultado.Columns.Add("IdPersona", GetType(Integer))
        dtResultado.Columns.Add("IdLegajo", GetType(Integer))
        dtResultado.Columns.Add("ApellidosNombres", GetType(String))
        dtResultado.Columns.Add("NivelCategoria", GetType(String))
        dtResultado.Columns.Add("NC", GetType(String))
        dtResultado.Columns.Add("CargoOcupacion", GetType(String))
        dtResultado.Columns.Add("RemSegunPeriodo", GetType(Decimal))
        dtResultado.Columns.Add("HorasSemana", GetType(Integer))
        dtResultado.Columns.Add("ValorHora", GetType(Decimal))
        ' TOTAL JORNADA
        dtResultado.Columns.Add("Dias", GetType(Integer))
        dtResultado.Columns.Add("Horas", GetType(Integer))
        dtResultado.Columns.Add("HoraSobretiempo", GetType(Decimal))
        ' REMUNERACION
        dtResultado.Columns.Add("JornadaLaboral", GetType(Decimal))
        dtResultado.Columns.Add("Sobretiempo", GetType(Decimal))
        dtResultado.Columns.Add("DiasDescanso", GetType(Decimal))

        dtResultado.Columns.Add("AsignacionFamiliar", GetType(Decimal))
        dtResultado.Columns.Add("BonCargoRiesgoCaja", GetType(Decimal))
        dtResultado.Columns.Add("HoraLactancia", GetType(Decimal))
        ' DL 25897 AFP
        dtResultado.Columns.Add("SNP33", GetType(Decimal))
        dtResultado.Columns.Add("AFP1023", GetType(Decimal))
        dtResultado.Columns.Add("AFP300", GetType(Decimal))
        ' OTROS PAGOS
        dtResultado.Columns.Add("OtrosPagos", GetType(Decimal))
        ' TOTAL REMUNERACION
        dtResultado.Columns.Add("TotalRemuneracion", GetType(Decimal))
        ' RETENCION A CARGO DEL TRABAJADOR
        dtResultado.Columns.Add("SNP", GetType(Decimal))
        dtResultado.Columns.Add("SPP", GetType(Decimal))
        dtResultado.Columns.Add("IR", GetType(Decimal))
        dtResultado.Columns.Add("Judicial", GetType(Decimal))
        dtResultado.Columns.Add("Varios", GetType(Decimal))
        ' REEMBOLSOS
        dtResultado.Columns.Add("Reembolsos", GetType(Decimal))

        dtResultado.Columns.Add("TotalDeduccion", GetType(Decimal))
        dtResultado.Columns.Add("NetoAPagar", GetType(Decimal))

        ' APORTES DEL EMPLEADOR
        dtResultado.Columns.Add("ESSALUD", GetType(Decimal))
        dtResultado.Columns.Add("EPS", GetType(Decimal))
        dtResultado.Columns.Add("IE", GetType(Decimal))
        dtResultado.Columns.Add("Total", GetType(Decimal))

        ' VACACIONES
        dtResultado.Columns.Add("VacacionesSalida", GetType(Object))
        dtResultado.Columns.Add("VacacionesRetorno", GetType(Object))

        ' DOCENTES
        dtResultado.Columns.Add("IdPtaFacAdscrito", GetType(Integer))
        dtResultado.Columns.Add("FacultadAdscrito", GetType(String))

        Return dtResultado
    End Function

    Public Shared Sub fncIngresaEnEstructuraBaseReporte(ByRef dtResultado As DataTable _
                                                        , ByVal IdPersona As Integer _
                                                        , ByVal IdLegajo As Integer _
                                                        , ByVal ApellidosNombres As String _
                                                        , ByVal NivelCategoria As String _
                                                        , ByVal NC As String _
                                                        , ByVal CargoOcupacion As String _
                                                        , ByVal RemSegunPeriodo As Decimal _
                                                        , ByVal HorasSemana As Decimal _
                                                        , ByVal ValorHora As Decimal _
                                                        , ByVal Dias As Integer _
                                                        , ByVal Horas As Decimal _
                                                        , ByVal HorasSobretiempo As Decimal _
                                                        , ByVal JornadaLaboral As Decimal _
                                                        , ByVal SobreTiempo As Decimal _
                                                        , ByVal DiasDescanso As Decimal _
                                                        , ByVal AsignacionFamiliar As Decimal _
                                                        , ByVal BonCargoRiesgoCaja As Decimal _
                                                        , ByVal DL25897_SNP33 As Decimal _
                                                        , ByVal DL25897_AFP1023 As Decimal _
                                                        , ByVal DL25897_AFP300 As Decimal _
                                                        , ByVal OtrosPagos As Decimal _
                                                        , ByVal TotalRemuneracion As Decimal _
                                                        , ByVal SNP As Decimal _
                                                        , ByVal SPP As Decimal _
                                                        , ByVal IR As Decimal _
                                                        , ByVal Judicial As Decimal _
                                                        , ByVal Varios As Decimal _
                                                        , ByVal Reembolsos As Decimal _
                                                        , ByVal TotalDeduccion As Decimal _
                                                        , ByVal NetoAPagar As Decimal _
                                                        , ByVal ESSALUD As Decimal _
                                                        , ByVal EPS As Decimal _
                                                        , ByVal IE As Decimal _
                                                        , ByVal Total As Decimal _
                                                        , ByVal VacacionesSalida As String _
                                                        , ByVal VacacionesRetorno As String _
                                                        , ByVal HoraLactancia As Decimal _
                                                        , ByVal IdPtaFacAdscrito As Integer _
                                                        , ByVal strFacultadAdscrito As String)
        dtResultado.Rows.Add()
        With dtResultado.Rows(dtResultado.Rows.Count - 1)
            .Item("IdPersona") = IdPersona
            .Item("IdLegajo") = IdLegajo
            .Item("ApellidosNombres") = ApellidosNombres
            .Item("NivelCategoria") = NivelCategoria
            .Item("NC") = NC
            .Item("CargoOcupacion") = CargoOcupacion
            .Item("RemSegunPeriodo") = RemSegunPeriodo
            .Item("HorasSemana") = HorasSemana
            .Item("ValorHora") = ValorHora
            ' TOTAL JORNADA
            .Item("Dias") = Dias
            .Item("Horas") = Horas
            .Item("HoraSobretiempo") = HorasSobretiempo
            ' REMUNERACION
            .Item("JornadaLaboral") = JornadaLaboral
            .Item("Sobretiempo") = SobreTiempo
            .Item("DiasDescanso") = DiasDescanso

            .Item("AsignacionFamiliar") = AsignacionFamiliar
            .Item("BonCargoRiesgoCaja") = BonCargoRiesgoCaja
            .Item("HoraLactancia") = HoraLactancia
            'HoraLactancia()
            ' DL 25897 AFP
            .Item("SNP33") = DL25897_SNP33
            .Item("AFP1023") = DL25897_AFP1023
            .Item("AFP300") = DL25897_AFP300
            ' OTROS PAGOS
            .Item("OtrosPagos") = OtrosPagos
            ' TOTAL REMUNERACION
            .Item("TotalRemuneracion") = TotalRemuneracion
            ' RETENCION A CARGO DEL TRABAJADOR
            .Item("SNP") = SNP
            .Item("SPP") = SPP
            .Item("IR") = IR
            .Item("Judicial") = Judicial
            .Item("Varios") = Varios

            .Item("Reembolsos") = Reembolsos
            .Item("TotalDeduccion") = TotalDeduccion
            .Item("NetoAPagar") = NetoAPagar

            ' APORTES DEL EMPLEADOR
            .Item("ESSALUD") = ESSALUD
            .Item("EPS") = EPS
            .Item("IE") = IE
            .Item("Total") = Total

            ' VACACIONES
            .Item("VacacionesSalida") = VacacionesSalida
            .Item("VacacionesRetorno") = VacacionesRetorno

            .Item("IdPtaFacAdscrito") = IdPtaFacAdscrito
            .Item("FacultadAdscrito") = strFacultadAdscrito
        End With



    End Sub


    'End Enum

    Public Enum enmCprTipoOperacionHoraExtra

        ''MATRIX SERVIDOR DE PRUEBA
        HoraExtra = 41 ' Registro de Horas Extra
        CambioHorario = 23
        Feriado = 1 'Feriado
        HorasExtraCompesadas = 42
        HorasExtraPagadas = 43

        AnularRegistroHorasExtra = 44

        TipoMarcaManual = 3 ' Marcado Manual

        IdTipoHorarioPesonalizado = 47 ' Para Tipo Horario Personalizado
        IdTipoHorarioJornadaExtraordinaria = 48 ' Jornada Extraordinaria


        ' ZUES SERVIDOR PRINCIPAL!!!
        'HoraExtra = 31 ' Registro de Horas Extra
        'CambioHorario = 19
        'HorasExtraCompesadas = 32
        'HorasExtraPagadas = 33
        'AnularRegistroHorasExtra = 34
        'TipoMarcaManual = 3 ' Marcado Manual
        'IdTipoHorarioPesonalizado = 36 ' Para Tipo Horario Personalizado
        'IdTipoHorarioJornadaExtraordinaria = 37 ' Jornada Extraordinaria
        'Feriado = 1 'Feriado
    End Enum

    Public Enum enmCodigoRemuneracionOrdinaria
        AlimentacionPrincipalEnDinero = 101
        AlimentacionPrincipalEnEspecia = 102
        VacacionesTruncas = 114
        AsignacionFamiliar = 201
        BonificacionPorRiesgoDeCaja = 304
        BonificacionPorTiempoDeServicios = 305
        IncrementoSNP33 = 108
        IncrementoAfiliacionAFP1023 = 109
        IncrementoAfiliacionAFP300 = 110
        RemuneracionVacacional = 118
        RemuneracionJornalBasico = 121
        RemuneracionPermanente = 122
        AsignacionesOtorgadasRegularmente = 213
        LicenciaConGoceDeHaber = 907
        HoraDeLactancia = 124
    End Enum

    Public Enum enmCodigoRemuneracionExtraordinaria
        TrabajoSobreTiempoHoraExtra25 = 105
        TrabajoSobreTiempoHoraExtra35 = 106
        TrabajoEnDiaFeriado_DiaDeDescanso = 107
        RemuneracionDiaDescanso_Feriado = 115
        BonificacionesRegulares = 306
        BonificacionExtraordinariaTemporal_Ley29351 = 312
        BonificacionExtraordinariaProporcional_Ley29351 = 313
    End Enum

    Public Enum enmRegimenPensionario
        SinRegimenPensionario = 12
        SistemaNacionalDePensiones = 1
    End Enum

    ''' <summary>
    ''' De Tabla Cpr_TipoTurno
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmTipoTurno
        Entrada = 1
        Salida = 2
    End Enum

    ''' <summary>
    ''' Cpr_TipoOperacion
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmCprTipoOperacion
        DescansoPorMaternidad = 8
        PartoMultiple = 9
        AdelantoORetrasoDeParto = 10
        PermisoPorLactancia = 11
        DescansoPorAdopcionDeMenor = 12
        AmpliacionDeHorasDeLactanciaMaterna = 13
        DescansoPorPaternidad = 14
        ExtensionDeDescansoPosnatalDeMadreTrabajadora = 15
        LicenciaATrabajadoresConFamiliaresGraves = 16
        LicenciaPorFallecimientoDeFamiliar_Local = 17
        LicenciaPorFallecimientoDeFamiliar_NoLocal = 18
        LicenciaSinGoceDeHaber = 19
        LicenciaConGocePorOnomastico = 20
        LicenciaMedica = 21
        Subsidio = 34
        LicenciaConGoceDeHaber = 49
    End Enum

    ''' <summary>
    ''' Tardanzas de Cpr_Tardanza
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmTipoTardanza
        AsistenciaRegular = 0
        TardanzaRegular = 1
        InasistenciaPorTardanza = 2
        InasistenciaInjustificada = 3
        InasistenciaJustificada = 4
    End Enum

    Public Enum enmTipoDocumento
        Resolucion = 2
        Oficio = 1
    End Enum

    Public Enum enmEstamento
        Administrativo = 3
        Docente = 2
    End Enum

    Public Enum enmModalidad
        Nombrado = 1
        Contratados = 2
    End Enum

    Public Enum enmDedicacion
        TiempoCompleto = 2
        TiempoParcial = 3
    End Enum
    ''' <summary>
    ''' Define estado de variables del sistema
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enmEstado
        Activo = 1
        Inactivo = 0
    End Enum

    Public Enum enmCerrado
        Cerrado = 1
        Abierto = 0
    End Enum

    Public Enum enmEstadoProceso
        Pendiente = 1
        Pagado = 2
    End Enum

    ''' <summary>
    ''' Obtener la Fecha y Hora del Servidor
    ''' </summary>
    ''' <returns>DateTime</returns>
    ''' <remarks></remarks>
    Public Shared Function FechaHoraServidor() As DateTime
        Return Date.Now
    End Function


    ''' <summary>
    ''' Valida si un dataTable tiene datos
    ''' </summary>
    ''' <param name="dtBase">DataTable a tratar</param>
    ''' <returns>True or False</returns>
    ''' <remarks></remarks>
    ''' <author>Wilmer</author>
    Public Shared Function fncValidaDataTable(ByVal dtBase As DataTable) As Boolean
        If dtBase IsNot Nothing AndAlso dtBase.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function fncSiMenorACeroEsDbNull(ByVal intValor As Integer) As Object
        If intValor > 0 Then
            Return intValor
        Else
            Return DBNull.Value
        End If
    End Function


    ''' <summary>
    ''' Setea un ComboBox con un datatable
    ''' </summary>
    ''' <param name="cmbTarget">ComboBox a Setear</param>
    ''' <param name="dtBase">DataTable base</param>
    ''' <param name="strDisplayMember">DisplayMember para el combobox</param>
    ''' <param name="strValueMember">ValueMember para el combobox</param>
    ''' <remarks></remarks>
    Public Shared Sub SetComboBox(ByVal cmbTarget As ComboBox, ByVal dtBase As DataTable, ByVal strDisplayMember As String, ByVal strValueMember As String)
        cmbTarget.DataSource = Nothing
        If dtBase IsNot Nothing AndAlso dtBase.Rows.Count > 0 Then
            cmbTarget.DataSource = dtBase
            cmbTarget.DisplayMember = strDisplayMember
            cmbTarget.ValueMember = strValueMember
            cmbTarget.SelectedIndex = If(cmbTarget.Items.Count > 0, 0, -1)
        Else
            MsgBox("No existe data para llenar el ComboBox: " & cmbTarget.Name & " -  Verifique el contenido de acuerdo a los siguientes parámetros: " & vbNewLine &
                strDisplayMember & " - " & strValueMember, MsgBoxStyle.Information)
        End If

    End Sub

    Public Shared Sub SetComboBox(ByVal cmbTarget As ComboBox, ByVal dtBase As DataTable, ByVal strDisplayMember As String, ByVal strValueMember As String, ByVal strDefaultMember As String)
        cmbTarget.DataSource = Nothing
        If dtBase IsNot Nothing AndAlso dtBase.Rows.Count > 0 Then

            Dim dtTratado As New DataTable
            dtTratado.Columns.Add(strValueMember, GetType(Object))
            dtTratado.Columns.Add(strDisplayMember, GetType(Object))

            For Each row As DataRow In dtBase.Rows
                dtTratado.Rows.Add(ObtenerValorCelda(row, strValueMember), ObtenerValorCelda(row, strDisplayMember))
            Next

            dtTratado.Rows.Add(-1, strDefaultMember)
            cmbTarget.DataSource = dtTratado
            cmbTarget.DisplayMember = strDisplayMember
            cmbTarget.ValueMember = strValueMember
            cmbTarget.SelectedValue = -1
        Else
            MsgBox("No existe data para llenar el ComboBox: " & cmbTarget.Name & " -  Verifique el contenido de acuerdo a los siguientes parámetros: " & vbNewLine &
                strDisplayMember & " - " & strValueMember, MsgBoxStyle.Information)
        End If
    End Sub

    'Public Shared Sub NotificarError(ByVal xExcepcion As Exception, Optional ByVal xCodigo As String = "", Optional ByVal xUsuario As Integer = 0)
    '    Dim Mensaje As String = xExcepcion.Message

    '    Dim Ubicacion As String = ""
    '    Dim Contador As Integer = 0
    '    For i As Integer = 0 To xExcepcion.StackTrace.Length - 4
    '        If xExcepcion.StackTrace.Substring(i, 4) = " en " Then
    '            Contador += 1
    '        End If
    '        If Contador = 3 Then
    '            Ubicacion = xExcepcion.StackTrace.Substring(i + 4)
    '            Exit For
    '        End If
    '    Next

    '    Dim Detalle As String = xCodigo.PadLeft(6, "0"c) & " : " & xExcepcion.Message & vbCrLf & "[" & Ubicacion & "]"
    '    Dim frm As New frmNotificarError(Mensaje, "Error", Detalle)
    '    frm.ShowDialog()

    '    Dim host = Dns.GetHostEntry(Dns.GetHostName())
    '    Dim ip = host.AddressList.FirstOrDefault(Function(x As IPAddress) _
    '        x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
    '    Dim networkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
    '    Dim firstNetwork = networkInterface.FirstOrDefault(Function(x As System.Net.NetworkInformation.NetworkInterface) _
    '        x.OperationalStatus = System.Net.NetworkInformation.OperationalStatus.Up)
    '    Dim firstMacAddressOfWorkingNetworkAdapter = firstNetwork.GetPhysicalAddress()

    '    'Registro de incidencia
    '    Dim objIncidencia As New clsSeg_IncidenciaBUS
    '    objIncidencia.CodigoError = xCodigo
    '    objIncidencia.IP = ip.ToString
    '    objIncidencia.MAC = firstMacAddressOfWorkingNetworkAdapter.ToString
    '    objIncidencia.Mensaje = Mensaje & xExcepcion.StackTrace
    '    objIncidencia.Usuario = xUsuario

    '    objIncidencia.fncRegistrarBUS()
    'End Sub

    ''' <summary>
    ''' Notifica un mensaje de exito
    ''' </summary>
    ''' <param name="xMensaje"></param>
    ''' Descripcion del mensaje
    ''' <param name="xTitulo"></param>
    ''' Titulo del mensaje
    ''' <remarks></remarks>
    Public Shared Sub Notificar(ByVal xMensaje As String, Optional ByVal xTitulo As String = "")
        If xTitulo.Trim = "" Then
            xTitulo = "Operacion Exitosa"
        End If

        MessageBox.Show(xMensaje, xTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Visualiza un mensaje de autorizacion que confirma o no la accion. Devuelve True o False
    ''' </summary>
    ''' <param name="xMensaje"></param>
    ''' Descripcion del mensaje
    ''' <param name="xTitulo"></param>
    ''' Titulo del mensaje
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Autorizar(ByVal xMensaje As String, Optional ByVal xTitulo As String = "") As Boolean
        Dim booRespuesta As Boolean = False

        If xTitulo.Trim = "" Then
            xTitulo = "¿Esta Seguro?"
        End If

        If MessageBox.Show(xMensaje, xTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            booRespuesta = True
        End If

        Return booRespuesta
    End Function

    ''' <summary>
    ''' Obtiene el valor de una celda en un datarow por el nombre del campo. Devuelve un objeto
    ''' </summary>
    ''' <param name="xdrRegistro"></param>
    ''' Objeto DataRow que contiene los datos
    ''' <param name="xstrCampo"></param>
    ''' Nombre de la columna
    ''' <param name="xbooAnulable"></param>
    ''' Confirma si el campo acepta valores nulos
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ObtenerValorCelda(ByVal xdrRegistro As DataRow, ByVal xstrCampo As String, Optional ByVal xbooAnulable As Boolean = False) As Object
        If xdrRegistro.Table.Columns.Contains(xstrCampo) Then
            If xbooAnulable Then
                Return xdrRegistro(xstrCampo)
            Else
                If IsDBNull(xdrRegistro(xstrCampo)) Then
                    Return ObtenerValorCampoDefecto(xdrRegistro.Table.Columns(xstrCampo).DataType)
                Else
                    Return xdrRegistro(xstrCampo)
                End If
            End If
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Obtiene el valor por defecto de un tipo de datos. Devuelve un objeto
    ''' </summary>
    ''' <param name="xobjTipo"></param>
    ''' Tipo de dato
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ObtenerValorCampoDefecto(ByVal xobjTipo As Object) As Object
        Select Case xobjTipo.Name
            Case "String"
                Return ""
            Case "Integer", "Double", "Int16", "Int32", "Int64"
                Return 0
            Case "Date"
                Return Now
            Case "Boolean"
                Return False
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Obtiene un array de objetos con los valores diferentes de un campo de tabla. Devuelve un List(Of Object)
    ''' </summary>
    ''' <param name="xtbvTabla"></param>
    ''' Objeto DataTable que contiene los datos
    ''' <param name="xstrCampo"></param>
    ''' Nombre de la columna
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ObtenerValoresUnicosCampo(ByVal xtbvTabla As DataView, ByVal xstrCampo As String) As List(Of Object)
        Dim objRespuesta As List(Of Object) = New List(Of Object)

        If xtbvTabla IsNot Nothing AndAlso xtbvTabla.Count > 0 Then
            If xtbvTabla.Table.Columns.Contains(xstrCampo) Then
                Dim objValorActual As Object = Nothing

                For i As Integer = 0 To xtbvTabla.Count - 1
                    If Not objValorActual = xtbvTabla.Item(i).Item(xstrCampo) Then
                        objValorActual = xtbvTabla.Item(i).Item(xstrCampo)

                        objRespuesta.Add(objValorActual)
                    End If
                Next
            End If
        End If

        Return objRespuesta
    End Function

    ''' <summary>
    ''' Devuelve un objeto imagen como array de bytes
    ''' </summary>
    ''' <param name="xImagen"></param>
    ''' Objeto de imagen
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertirImagen2Bytes(ByVal xImagen As Object) As Object
        Dim Respuesta As Object = DBNull.Value

        Try
            If xImagen IsNot Nothing Then
                If xImagen.GetType.FullName.Contains("System.Drawing") Then
                    Dim dibujo As System.Drawing.Image = New Drawing.Bitmap(CType(xImagen, Drawing.Image))
                    Dim mesFormatoImagen As System.IO.MemoryStream = New System.IO.MemoryStream

                    mesFormatoImagen.SetLength(7999)
                    dibujo.Save(mesFormatoImagen, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Respuesta = mesFormatoImagen.GetBuffer()
                ElseIf xImagen.GetType.FullName = "System.Byte[]" Then
                    Respuesta = xImagen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Respuesta
    End Function

    ''' <summary>
    ''' Devuelve un array de bytes como objeto imagen
    ''' </summary>
    ''' <param name="xBytes"></param>
    ''' Objeto Array de Bytes
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertirBytes2Imagen(ByVal xBytes As Object) As Object
        Dim Respuesta As Object = DBNull.Value

        Try
            If xBytes IsNot Nothing AndAlso xBytes.GetType.FullName = "System.Byte[]" Then
                If xBytes.Length > 0 Then
                    Dim Memoria As System.IO.MemoryStream = New System.IO.MemoryStream(CType(xBytes, Byte()))
                    Respuesta = New System.Drawing.Bitmap(Memoria)
                Else
                    Respuesta = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Respuesta
    End Function

    ''' <summary>
    ''' Formatear un Numero indicando el numero de decimales Ej. 126,152.00 (con 2 decimales)
    ''' </summary>
    ''' <param name="Numero"></param>
    ''' <param name="Decimales"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatearNumero(ByVal Numero As Double, Optional ByVal Decimales As Integer = 2) As String
        Dim rs As String = ""

        rs = Format(Numero, "###,##0" & ".".PadRight(Decimales + 1, "0"c))

        Return rs
    End Function

    ''' <summary>
    ''' Devuelve un objeto como Double
    ''' </summary>
    ''' <param name="xValor"></param>
    ''' Valor a convertir
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function [Double](ByVal xValor As Object) As Double
        If IsDBNull(xValor) Then
            Return 0.0
        Else
            Return xValor
        End If
    End Function

    ''' <summary>
    ''' Obtiene un texto alineado indicando la longitud del texto
    ''' </summary>
    ''' <param name="xTexto"></param>
    ''' Texto a alinear
    ''' <param name="xLongitud"></param>
    ''' Longitud del texto a devolver
    ''' <param name="xAlineacion"></param>
    ''' Alineacion: Izquierda (I), Derecha (D) o Centrada (C)
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function AlinearTexto(ByVal xTexto As Object, ByVal xLongitud As Integer, Optional ByVal xAlineacion As String = "I") As String
        If IsDBNull(xTexto) Then
            xTexto = ""
        Else
            xTexto = CStr(xTexto)
        End If

        Dim Respuesta As String = xTexto.ToString

        If xTexto.Length > xLongitud Then
            Respuesta = xTexto.Substring(0, xLongitud)
        ElseIf xTexto.Length < xLongitud Then
            If xAlineacion = "I" Then
                Respuesta = xTexto.PadRight(xLongitud, " "c)
            ElseIf xAlineacion = "D" Then
                Respuesta = xTexto.PadLeft(xLongitud, " "c)
            ElseIf xAlineacion = "C" Then
                Dim Diferencia As Integer = xLongitud - xTexto.Length
                If Diferencia > 0 Then
                    Dim EspacioIzquierda As Integer = CInt(Diferencia / 2)
                    If Diferencia Mod 2 = 1 Then
                        EspacioIzquierda += 1
                    End If

                    Respuesta = xTexto.PadLeft(xTexto.ToString.Length + EspacioIzquierda, " "c).PadRight(xLongitud, " "c)
                Else
                    Respuesta = xTexto
                End If
            End If
        End If

        Return Respuesta
    End Function

    Shared Function Formatear(ByVal xObjeto As Object, ByVal xFormato As String, Optional ByVal xDefecto As String = "") As String
        Dim Respuesta As String = xDefecto

        If Not IsDBNull(xObjeto) AndAlso xObjeto IsNot Nothing Then
            Respuesta = Format(xObjeto, xFormato)
        End If

        Return Respuesta
    End Function
    Public Shared Function IfNullObj(ByVal o As Object, Optional ByVal DefaultValue As String = "") As String
        Dim ret As String = ""
        Try
            If o Is DBNull.Value Then
                ret = DefaultValue
            Else
                ret = o.ToString
            End If
            Return ret
        Catch ex As Exception
            Return ret
        End Try
    End Function

    Public Shared Function DataGridViewToDataTable(ByVal dtg As DataGridView, ByVal ignore As List(Of String),
    Optional ByVal DataTableName As String = "myDataTable") As DataTable
        Try
            Dim dt As New DataTable(DataTableName)
            Dim row As DataRow
            Dim TotalDatagridviewColumns As Integer = dtg.ColumnCount - 1
            'Add Datacolumn
            For Each c As DataGridViewColumn In dtg.Columns
                If Not ignore.Contains(c.Name) Then
                    Dim idColumn As DataColumn = New DataColumn()
                    idColumn.ColumnName = c.Name
                    dt.Columns.Add(idColumn)
                End If
            Next

            '' TotalDatagridviewColumns = dt.Columns.Count - 1
            'Now Iterate thru Datagrid and create the data row
            For Each dr As DataGridViewRow In dtg.Rows
                'Iterate thru datagrid
                row = dt.NewRow 'Create new row
                'Iterate thru Column 1 up to the total number of columns
                Dim iRowCount As Integer = 0
                For cn As Integer = 0 To TotalDatagridviewColumns
                    If Not ignore.Contains(dtg.Columns(dr.Cells(cn).ColumnIndex).Name) Then
                        row.Item(iRowCount) = IfNullObj(dr.Cells(cn).Value) ' This Will handle error datagridviewcell on NULL Values
                        iRowCount += 1
                    End If
                Next
                'Now add the row to Datarow Collection
                dt.Rows.Add(row)
            Next
            'Now return the data table
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Sub Validar_NumericoV(ByVal txt As TextBox, ByVal CharCode As Char, ByRef Var As Boolean)
        ' Dim Pos As Integer = 0
        If txt.Text.Length > txt.MaxLength Then
            txt.Text = "0.00"
            Var = True
            Exit Sub
        End If
        'Exit Sub
        Dim PosA As Integer = txt.SelectionStart

        If Chr(8) <> CharCode Then
            Dim Tecla As String = Asc(CharCode)

            If txt.Text.Trim.Length = 0 Then
                txt.Text = Format(0, "0.00")
                txt.SelectionStart = 0
            Else
                If txt.SelectionStart = 0 Then
                    Var = True
                    Dim TextoIzq As String = ""
                    Dim TextoDer As String = txt.Text.Substring(1)
                    'Me.txtCantidad.Text = ""
                    If Chr(Tecla) <> "." Then txt.Text = Chr(Tecla) & TextoDer
                Else
                    If CharCode = "." Then
                        If txt.Text.IndexOf(".") = txt.SelectionStart Then
                            Var = True
                            txt.SelectionStart = txt.Text.IndexOf(".") + 1
                        Else
                            Var = True
                            'e.Handled = True
                            'Me.txtCantidad.SelectionStart = Me.txtCantidad.Text.IndexOf(".") + 1
                        End If

                    Else
                        Var = True
                        Dim Pos As Integer = txt.SelectionStart
                        Dim Extension As String = ""
                        'Me.txtCantidad.Text = Me.txtCantidad.Text.Insert(Me.txtCantidad.SelectionStart, e.KeyChar)
                        'Extension = Mid(Me.txtCantidad.Text, Me.txtCantidad.Text.IndexOf(".") + 1, 4)
                        'Me.txtCantidad.Text = Mid(Me.txtCantidad.Text, 1, IIf(Extension.Length = 4, Me.txtCantidad.Text.Length + 1, Me.txtCantidad.Text.Length - 1))
                        txt.Text = txt.Text.Insert(txt.SelectionStart, CharCode)
                        Extension = Mid(txt.Text, txt.Text.IndexOf(".") + 1)
                        txt.Text = Mid(txt.Text, 1, IIf(Extension.Length = 3, txt.Text.Length, txt.Text.Length - 1))
                        If Extension.Length = 3 Then
                            txt.SelectionStart = Pos + 1
                        Else
                            txt.SelectionStart = Pos
                        End If


                    End If
                End If
            End If
        Else
            txt.Text = "0.00"
            txt.SelectionStart = 0
            txt.SelectionLength = 0
            Var = True
            Exit Sub
            'PosA = 1
        End If
        txt.Text = Format(CDec(txt.Text), "0.00")
        txt.SelectionStart = PosA + 1
    End Sub


    Public Shared Sub Validar_NumericoV4(ByVal txt As TextBox, ByVal CharCode As Char, ByRef Var As Boolean)
        ' Dim Pos As Integer = 0
        If txt.Text.Length > txt.MaxLength Then
            txt.Text = "0.0000"
            Var = True
            Exit Sub
        End If
        'Exit Sub
        Dim PosA As Integer = txt.SelectionStart

        If Chr(8) <> CharCode Then
            Dim Tecla As String = Asc(CharCode)

            If txt.Text.Trim.Length = 0 Then
                txt.Text = Format(0, "0.0000")
                txt.SelectionStart = 0
            Else
                If txt.SelectionStart = 0 Then
                    Var = True
                    Dim TextoIzq As String = ""
                    Dim TextoDer As String = txt.Text.Substring(1)
                    'Me.txtCantidad.Text = ""
                    If Chr(Tecla) <> "." Then txt.Text = Chr(Tecla) & TextoDer
                Else
                    If CharCode = "." Then
                        If txt.Text.IndexOf(".") = txt.SelectionStart Then
                            Var = True
                            txt.SelectionStart = txt.Text.IndexOf(".") + 1
                        Else
                            Var = True
                            'e.Handled = True
                            'Me.txtCantidad.SelectionStart = Me.txtCantidad.Text.IndexOf(".") + 1
                        End If

                    Else
                        Var = True
                        Dim Pos As Integer = txt.SelectionStart
                        Dim Extension As String = ""
                        'Me.txtCantidad.Text = Me.txtCantidad.Text.Insert(Me.txtCantidad.SelectionStart, e.KeyChar)
                        'Extension = Mid(Me.txtCantidad.Text, Me.txtCantidad.Text.IndexOf(".") + 1, 4)
                        'Me.txtCantidad.Text = Mid(Me.txtCantidad.Text, 1, IIf(Extension.Length = 4, Me.txtCantidad.Text.Length + 1, Me.txtCantidad.Text.Length - 1))
                        txt.Text = txt.Text.Insert(txt.SelectionStart, CharCode)
                        Extension = Mid(txt.Text, txt.Text.IndexOf(".") + 1)
                        txt.Text = Mid(txt.Text, 1, IIf(Extension.Length = 3, txt.Text.Length, txt.Text.Length - 1))
                        If Extension.Length = 3 Then
                            txt.SelectionStart = Pos + 1
                        Else
                            txt.SelectionStart = Pos
                        End If


                    End If
                End If
            End If
        Else
            txt.Text = "0.0000"
            txt.SelectionStart = 0
            txt.SelectionLength = 0
            Var = True
            Exit Sub
            'PosA = 1
        End If
        txt.Text = Format(CDec(txt.Text), "0.0000")
        txt.SelectionStart = PosA + 1
    End Sub

    ''' <summary>
    ''' Formatea la Columna de un DataGridView 0: DateTime - 1: Decimal - 2: Ocultar
    ''' </summary>
    ''' <param name="dgvTarget">DataGridView objetivo</param>
    ''' <param name="strColumn">Array de columnas</param>
    ''' <param name="intTipo">0: Date - 1: Decimal - 2: Ocultar</param>
    ''' <remarks></remarks>
    Public Shared Sub FormateaColumna(ByVal dgvTarget As DataGridView,
                                      ByVal strColumn() As String,
                                      ByVal intTipo As Integer)
        For Each strCol As String In strColumn
            If dgvTarget.Columns(strCol) IsNot Nothing Then
                Select Case intTipo
                    Case 0
                        dgvTarget.Columns(strCol).DefaultCellStyle.Format = "dd/MM/yyyy"
                        dgvTarget.Columns(strCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 1
                        dgvTarget.Columns(strCol).DefaultCellStyle.Format = "n2"
                        dgvTarget.Columns(strCol).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 2
                        dgvTarget.Columns(strCol).Visible = False
                End Select
            End If
        Next
    End Sub

    ''' <summary>
    ''' Ordena las Columnas en el Grid empezando en DisplayIndex: 0
    ''' </summary>
    ''' <param name="dgvTarget">DataGridView Objetivo</param>
    ''' <param name="strColumn">Array de Columnas en orden</param>
    ''' <remarks></remarks>
    Public Shared Sub FormateaGridOrden(ByVal dgvTarget As DataGridView,
                                        ByVal strColumn() As String)
        Dim intOrden As Integer = 0
        For Each strCol As String In strColumn
            If dgvTarget.Columns(strCol) IsNot Nothing Then
                dgvTarget.Columns(strCol).DisplayIndex = intOrden
                intOrden += 1
            End If
        Next
    End Sub

    ''' <summary>
    ''' Agrega Filas desde un datatable existente [dtFuente] a otro datatable [dtTarget]
    ''' </summary>
    ''' <param name="dtTarget">dt Objetivo</param>
    ''' <param name="dtFuente">dt Origen</param>
    ''' <remarks></remarks>
    Public Shared Sub AddRowsToDatatable(ByVal dtTarget As DataTable, ByVal dtFuente As DataTable)


        Dim strTargetCols As New List(Of String)
        ' Captura nombres de columnas
        If Not (dtTarget IsNot Nothing AndAlso dtTarget.Rows.Count > 0) Then
            Exit Sub
        End If
        For Each column As DataColumn In dtTarget.Columns
            'column.DataType = GetType(Object)
            strTargetCols.Add(column.ColumnName)
        Next
        ' Agrega Nuevas filas a existente

        If Not (dtFuente IsNot Nothing AndAlso dtFuente.Rows.Count > 0) Then
            Exit Sub
        End If

        For Each row As DataRow In dtFuente.Rows
            Dim drTarget As DataRow = dtTarget.NewRow
            For Each item As String In strTargetCols
                Dim strItem As String = ObtenerValorCelda(row, item)
                drTarget.Item(item) = strItem
            Next
            dtTarget.Rows.Add(drTarget)
        Next
    End Sub

    ''' <summary>
    ''' Limpia todos los textbox en determinado formulario
    ''' </summary>
    ''' <param name="root">form o group, conjunto que agrupa los textbox</param>
    ''' <remarks></remarks>
    Public Shared Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub

    'preoband

    Public Shared Function DatosRedIp() As String
        'Datos Privados
        Dim host = Dns.GetHostEntry(Dns.GetHostName())
        Dim ip = host.AddressList.FirstOrDefault(Function(x As IPAddress) _
            x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)

        Return ip.ToString
    End Function

    Public Shared Function DatosRedMac() As String
        Dim networkinterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        Dim firstnetwork = networkinterface.FirstOrDefault(Function(x As System.Net.NetworkInformation.NetworkInterface) _
            x.OperationalStatus = System.Net.NetworkInformation.OperationalStatus.Up)
        Dim firstmacaddressofworkingnetworkadapter = firstnetwork.GetPhysicalAddress()
        Return firstmacaddressofworkingnetworkadapter.ToString
    End Function

    Public Shared Function fncValidarCaracteresAlfabeticos(ByVal strBase As String)
        For i = 0 To strBase.Length - 1
            If Char.IsLetter(strBase.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Shared Sub ShowMessageBox(ByVal message As Object)
        MessageBox.Show(message.ToString())
    End Sub



    ' Encryption 

    Private Shared m_strPassPhrase As String = "MyPriv@Password!$$"    '---- any text string is good here
    Private Shared m_strHashAlgorithm As String = "MD5"                '--- we are doing MD5 encryption - can be "SHA1"
    Private Shared m_strPasswordIterations As Integer = 2              '--- can be any number
    Private Shared m_strInitVector As String = "@1B2c3D4e5F6g7H8"      '--- must be 16 bytes
    Private Shared m_intKeySize As Integer = 256                       '--- can be 192 or 128


    Public Shared Function EncryptPasswordMD5(ByVal plainText As String, ByVal p_strSaltValue As String) As String

        Dim strReturn As String = String.Empty

        ' Convert strings into byte arrays.
        ' Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8 
        ' encoding.

        Try
            Dim initVectorBytes As Byte()
            initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector)

            Dim saltValueBytes As Byte()
            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(p_strSaltValue)

            ' Convert our plaintext into a byte array.
            ' Let us assume that plaintext contains UTF8-encoded characters.
            Dim plainTextBytes As Byte()
            plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)

            ' First, we must create a password, from which the key will be derived.
            ' This password will be generated from the specified passphrase and 
            ' salt value. The password will be created using the specified hash 
            ' algorithm. Password creation can be done in several iterations.

            Dim password As Rfc2898DeriveBytes

            password = New Rfc2898DeriveBytes(m_strPassPhrase,
                                          saltValueBytes,
                                          m_strPasswordIterations)

            ' Use the password to generate pseudo-random bytes for the encryption
            ' key. Specify the size of the key in bytes (instead of bits).
            Dim keyBytes As Byte()
            Dim intKeySize As Integer = 0

            intKeySize = CType((m_intKeySize / 8), Integer)

            keyBytes = password.GetBytes(intKeySize)

            ' Create uninitialized Rijndael encryption object.
            Dim symmetricKey As System.Security.Cryptography.RijndaelManaged
            symmetricKey = New System.Security.Cryptography.RijndaelManaged

            ' It is reasonable to set encryption mode to Cipher Block Chaining
            ' (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC

            'symmetricKey.Padding = PaddingMode.Zeros


            ' Generate encryptor from the existing key bytes and initialization 
            ' vector. Key size will be defined based on the number of the key 
            ' bytes.
            Dim encryptor As System.Security.Cryptography.ICryptoTransform
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim memoryStream As System.IO.MemoryStream
            memoryStream = New System.IO.MemoryStream

            ' Define cryptographic stream (always use Write mode for encryption).
            Dim cryptoStream As System.Security.Cryptography.CryptoStream
            cryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream,
                                            encryptor,
                                            System.Security.Cryptography.CryptoStreamMode.Write)
            ' Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)

            ' Finish encrypting.
            cryptoStream.FlushFinalBlock()

            ' Convert our encrypted data from a memory stream into a byte array.
            Dim cipherTextBytes As Byte()
            cipherTextBytes = memoryStream.ToArray()

            ' Close both streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Convert encrypted data into a base64-encoded string.
            Dim cipherText As String
            cipherText = Convert.ToBase64String(cipherTextBytes)

            ' Return encrypted string.
            strReturn = cipherText

        Catch ex As Exception
            strReturn = Nothing
        End Try

        Return strReturn

    End Function

    'Decrypt Function: 

    Public Shared Function DecryptPasswordMD5(ByVal cipherText As String, ByVal p_strSaltValue As String) As String

        Dim strReturn As String = String.Empty

        ' Convert strings defining encryption key characteristics into byte
        ' arrays. Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        ' encoding.

        Try

            Dim initVectorBytes As Byte()
            initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector)

            Dim saltValueBytes As Byte()
            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(p_strSaltValue)

            ' Convert our ciphertext into a byte array.
            Dim cipherTextBytes As Byte()
            cipherTextBytes = Convert.FromBase64String(cipherText)

            ' First, we must create a password, from which the key will be 
            ' derived. This password will be generated from the specified 
            ' passphrase and salt value. The password will be created using
            ' the specified hash algorithm. Password creation can be done in
            ' several iterations.

            Dim password As Rfc2898DeriveBytes

            password = New Rfc2898DeriveBytes(m_strPassPhrase,
                                            saltValueBytes,
                                            m_strPasswordIterations)

            ' Use the password to generate pseudo-random bytes for the encryption
            ' key. Specify the size of the key in bytes (instead of bits).
            Dim keyBytes As Byte()
            Dim intKeySize As Integer

            intKeySize = CType((m_intKeySize / 8), Integer)

            keyBytes = password.GetBytes(intKeySize)

            ' Create uninitialized Rijndael encryption object.
            Dim symmetricKey As System.Security.Cryptography.RijndaelManaged
            symmetricKey = New System.Security.Cryptography.RijndaelManaged

            ' It is reasonable to set encryption mode to Cipher Block Chaining
            ' (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC

            'symmetricKey.Padding = PaddingMode.Zeros

            ' Generate decryptor from the existing key bytes and initialization 
            ' vector. Key size will be defined based on the number of the key 
            ' bytes.
            Dim decryptor As System.Security.Cryptography.ICryptoTransform
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim memoryStream As System.IO.MemoryStream
            memoryStream = New System.IO.MemoryStream(cipherTextBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim cryptoStream As System.Security.Cryptography.CryptoStream
            cryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream,
                                            decryptor,
                                            System.Security.Cryptography.CryptoStreamMode.Read)

            ' Since at this point we don't know what the size of decrypted data
            ' will be, allocate the buffer long enough to hold ciphertext;
            ' plaintext is never longer than ciphertext.
            Dim plainTextBytes As Byte()
            ReDim plainTextBytes(cipherTextBytes.Length)

            ' Start decrypting.
            Dim decryptedByteCount As Integer
            decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                0,
                                                plainTextBytes.Length)

            ' Close both streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Convert decrypted data into a string. 
            ' Let us assume that the original plaintext string was UTF8-encoded.
            Dim plainText As String
            plainText = System.Text.Encoding.UTF8.GetString(plainTextBytes,
                                                0,
                                                decryptedByteCount)

            ' Return decrypted string.
            strReturn = plainText

        Catch ex As Exception
            strReturn = Nothing
        End Try

        Return strReturn


    End Function

    'Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
    '    Dim table As New DataTable()
    '    Dim fields() As FieldInfo = GetType(T).GetFields()
    '    For Each field As FieldInfo In fields
    '        table.Columns.Add(field.Name, field.FieldType)
    '    Next
    '    For Each item As T In list
    '        Dim row As DataRow = table.NewRow()
    '        For Each field As FieldInfo In fields
    '            row(field.Name) = field.GetValue(item)
    '        Next
    '        table.Rows.Add(row)
    '    Next
    '    Return table
    'End Function


    Public Shared Sub FncDataTable2Excel(ByVal dtContenido As DataTable, ByVal strRepTitulo As String)
        '' ByVal dtContenido As DataTable
        Dim arr As Object(,) = New Object(dtContenido.Rows.Count - 1, dtContenido.Columns.Count - 1) {}
        Dim arrTipos As Object() = New Object(dtContenido.Columns.Count - 1) {}
        Dim arrTitulos As Object() = New Object(dtContenido.Columns.Count - 1) {}

        'For i As Integer = 0 To dtContenido.Columns.Count - 1
        '    arrTipos(i) = dtContenido.Columns(i).DataType
        '    '      arrTitulos(i) = dtContenido.Columns(i).ColumnName
        'Next

        For r As Integer = 0 To dtContenido.Rows.Count - 1
            Dim dr As DataRow = dtContenido.Rows(r)
            For c As Integer = 0 To dtContenido.Columns.Count - 1
                If r = 0 Then
                    arrTipos(c) = dtContenido.Columns(c).DataType
                    arrTitulos(c) = dtContenido.Columns(c).ColumnName
                End If
                arr(r, c) = dr(c).ToString
            Next
        Next

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        'Añadimos el Libro al programa, y la hoja al libro
        exLibro = exApp.Workbooks.Add
        exHoja = exLibro.Worksheets.Add()
        ' Imprimiendo Cabecera
        ' 1 = topRow

        For j As Integer = 0 To arrTipos.Length - 1
            Dim ColumnRange1 As Excel.Range = DirectCast(exHoja.Cells(1, j + 1), Excel.Range)
            Dim ColumnRange2 As Excel.Range = DirectCast(exHoja.Cells(dtContenido.Rows.Count + 1, j + 1), Excel.Range)
            Dim rangeColumna As Excel.Range = exHoja.Range(ColumnRange1, ColumnRange2)
            rangeColumna.NumberFormat = FormatoPorColumnaTipo(arrTipos(j).ToString)
        Next

        Dim t1 As Excel.Range = DirectCast(exHoja.Cells(1, 1), Excel.Range)
        Dim t2 As Excel.Range = DirectCast(exHoja.Cells(1, dtContenido.Columns.Count), Excel.Range)
        Dim rangeTitulo As Excel.Range = exHoja.Range(t1, t2)

        rangeTitulo.Value = arrTitulos

        Dim c1 As Excel.Range = DirectCast(exHoja.Cells(2, 1), Excel.Range)
        Dim c2 As Excel.Range = DirectCast(exHoja.Cells(1 + dtContenido.Rows.Count, dtContenido.Columns.Count), Excel.Range)
        Dim range As Excel.Range = exHoja.Range(c1, c2)

        range.Value = arr

        'Aplicación visible
        exApp.Application.Visible = True

    End Sub

    Public Shared Function FormatoPorColumnaTipo(ByVal strTipo As String)
        ' Dim strFormato As String = String.Empty
        Select Case strTipo
            Case "System.Int64", "System.Int32"
                Return "##"
            Case "System.String"
                Return "@"
            Case Else
                Return "#.0#"
        End Select
    End Function

End Class
