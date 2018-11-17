using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;
using System.Data.SqlClient;
using System.Data;


namespace DA.Policlinico
{
    public class LaboratorioDA
    {

        public PacienteBE getGuiaLab(String numGuia)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_GUIALAB_CAB", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            PacienteBE UnidadesList = new PacienteBE();
            PacienteBE g = new PacienteBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.fechaGuia = reader.GetString(0);
                    g.numHistoria = reader.GetString(1);
                    g.paterno = reader.GetString(2);
                    g.materno = reader.GetString(3);
                    g.nombres = reader.GetString(4);
                    g.fechaNc = reader.GetString(5);
                    g.edad = reader.GetInt32(6);
                    g.dni = reader.GetString(7);
                    g.sexo = reader.GetString(8);
                    g.cerrado = reader.GetString(9);
                    g.tipoPaciente = reader.GetInt32(10);
                    g.descTipoPaciente = reader.GetString(11);
                }
            }

            cnx.Close();
            return g;
        }
        public PacienteBE getPacientexDNI(String dni)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PACIENTEXDNI", cnx);
            cmd.Parameters.Add(new SqlParameter("@dni", dni));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            PacienteBE g = new PacienteBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.paterno = reader.GetString(0);
                    g.materno = reader.GetString(1);
                    g.nombres = reader.GetString(2);
                    g.fechaNc = reader.GetString(3);
                    g.sexo = reader.GetString(4);
                    g.dni = reader.GetString(5);

                }
            }

            cnx.Close();
            return g;
        }
        public int updatePaciente(PacienteBE pac)
        {
            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();

                SqlCommand cmd = new SqlCommand("USP_UPD_PACIENTE", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codPac", pac.numHistoria));
                cmd.Parameters.Add(new SqlParameter("@dni", pac.dni));
                cmd.Parameters.Add(new SqlParameter("@paterno", pac.paterno));
                cmd.Parameters.Add(new SqlParameter("@materno", pac.materno));
                cmd.Parameters.Add(new SqlParameter("@nombres", pac.nombres));
                cmd.Parameters.Add(new SqlParameter("@fecha", pac.fechaNc));
                cmd.Parameters.Add(new SqlParameter("@sex", pac.sexo));
                cmd.Parameters.Add(new SqlParameter("@tipoPaciente", pac.tipoPaciente));
                result = cmd.ExecuteNonQuery();

                return result;

            }
            catch (Exception)
            {

                return result;

            }
         
        }

        public List<LabProductoBE> getLabProductoList(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_GUIALAB_DET", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> labProductolista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.id = reader.GetInt32(0);// aqui antes estaba el codpro
                    producto.procedimiento = reader.GetString(1);
                    producto.cantidad = reader.GetInt32(2).ToString();
                    producto.codarea = reader.GetString(3);
                    producto.arealab = reader.GetString(4);
                    producto.estado= reader.GetString(5);
                    labProductolista.Add(producto);
                }
            }

            cnx.Close();
            return labProductolista;
        }

        public List<CitaBE> getAvanceCitas()
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_AVANCE_CITAS", cnx);
          
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<CitaBE> listaMedicos = new List<CitaBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    CitaBE medico = new CitaBE();
                    medico.id_med = reader.GetString(0);
                    medico.codmed = reader.GetString(1);
                    medico.medico = reader.GetString(2);
                    medico.manana = reader.GetString(3);
                    medico.tarde = reader.GetString(4);
                    listaMedicos.Add(medico);
                }
            }
            cnx.Close();
            return listaMedicos;
        }

        public List<LabProductoBE> getAreaAnalisisList(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_AREAS_BYGUIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> labProductolista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.areaAnalisis = reader.GetString(0);
                    labProductolista.Add(producto);
                }
            }
            cnx.Close();
            return labProductolista;
        }


        public List<ConceptosBE> getLabConceptosList()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_CONCEPTOS", cnx);
            //cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ConceptosBE> conceptoslista = new List<ConceptosBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ConceptosBE concepto = new ConceptosBE();
                    concepto.idConcepto = reader.GetInt32(0);
                    concepto.tipo = reader.GetString(1);
                    concepto.concepto = reader.GetString(2);


                    conceptoslista.Add(concepto);
                }
            }

            cnx.Close();
            return conceptoslista;
        }
        public List<PacienteBE> getLabPagosList(String numHistoria, String fecha)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PAGOS_BYHISTORIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@numHistoria", numHistoria));
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<PacienteBE> listaPacientes = new List<PacienteBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    PacienteBE pac = new PacienteBE();
                    pac.numGuia = reader.GetString(0);
                    pac.numHistoria = reader.GetString(1);
                    pac.nombreCompleto = reader.GetString(2);
                    pac.procedimiento = reader.GetString(3);
                    pac.turno = reader.GetString(4);
                    pac.numOrden = reader.GetString(5);
                    pac.fechaGuia = reader.GetString(6);
                    listaPacientes.Add(pac);
                }
            }

            cnx.Close();
            return listaPacientes;
        }

        public DataTable getLabCuadernoList(string fechaInicio, string fechaFin, string estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_CUADERNO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio1", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@estadoCerrado", estado));
            var dataReader = cmd.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(dataReader);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            cnx.Close();

            return dataTable;

        }


        public List<LabAnalisisBE> getLabAnalisisList(string numguia, string areaAnalisis)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_ANALISIBYAREA", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.Parameters.Add(new SqlParameter("@areaAnalisis", areaAnalisis));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabAnalisisBE> labAnalisislista = new List<LabAnalisisBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabAnalisisBE analisis = new LabAnalisisBE();
                    analisis.id = reader.GetInt32(0);
                    analisis.analisis = reader.GetString(1);
                    analisis.resultado = reader.GetString(2);
                    analisis.unidad = reader.GetString(3);
                    analisis.codAna = reader.GetString(4);
                    labAnalisislista.Add(analisis);
                }
            }

            cnx.Close();
            return labAnalisislista;
        }

        public List<PacienteBE> getHistorial(String numDNI)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_HISTORIAL", cnx);
            cmd.Parameters.Add(new SqlParameter("@numDNI", numDNI));

            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<PacienteBE> listaPacientes = new List<PacienteBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    PacienteBE pac = new PacienteBE();
                    pac.numGuia = reader.GetString(0);
                    pac.fechaGuia = reader.GetString(1);
                    pac.paterno = reader.GetString(2);
                    pac.areaLab = reader.GetString(3);

                    listaPacientes.Add(pac);
                }
            }

            cnx.Close();
            return listaPacientes;
        }

        public List<LabProductoBE> getProcedimientosAll()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PROCEDIMIENTOS", cnx);
            //cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> procedimientolista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.codpro = reader.GetString(0);
                    producto.procedimiento = reader.GetString(1);
                    procedimientolista.Add(producto);
                }
            }
            cnx.Close();
            return procedimientolista;
        }
        public String getarealab_proc(string codpro)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_AREALAB_PROC", cnx);
            cmd.Parameters.Add(new SqlParameter("@codpro", codpro));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();
            String areaLab = "";

            if (reader != null)
            {
                while (reader.Read())
                {

                    areaLab = reader.GetString(0);

                }
            }
            cnx.Close();
            return areaLab;
        }


        public List<LabProductoBE> getAreaAnalisisAll()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_AREA_ANALISIS", cnx);
            //cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> areaAnalisislista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.codarea = reader.GetString(0);
                    producto.areaAnalisis = reader.GetString(1);
                    areaAnalisislista.Add(producto);
                }
            }
            cnx.Close();
            return areaAnalisislista;
        }
        public List<LabProductoBE> getAreaLabAll()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_AREA_LAB", cnx);
            //cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> areaAnalisislista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.codarea = reader.GetString(0);
                    producto.arealab = reader.GetString(1);
                    areaAnalisislista.Add(producto);
                }
            }
            cnx.Close();
            return areaAnalisislista;
        }

        public LabProductoBE getAnalisisMantenimiento(int idAnalisis)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_ANALISIS", cnx);
            cmd.Parameters.Add(new SqlParameter("@idanalisis", idAnalisis));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            // List<LabProductoBE> listaAnalisis = new List<LabProductoBE>();
            LabProductoBE producto = new LabProductoBE();
            if (reader != null)
            {
                while (reader.Read())
                {

                    producto.id = reader.GetInt32(0);
                    producto.codana = reader.GetString(1);
                    producto.analisis = reader.GetString(2);
                    producto.unidad = reader.GetString(3);
                    producto.procedimiento = reader.GetString(4);
                    producto.arealab = reader.GetString(5);
                    producto.areaAnalisis = reader.GetString(6);
                    producto.codpro = reader.GetString(7);
                }
            }
            cnx.Close();
            return producto;
        }
        public List<LabAnalisisBE> getRefAnalisisMantenimiento(int idAnalisis)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GETREF_ANALISIS", cnx);
            cmd.Parameters.Add(new SqlParameter("@idanalisis", idAnalisis));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabAnalisisBE> listaAnalisis = new List<LabAnalisisBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    LabAnalisisBE refe = new LabAnalisisBE();
                    refe.idvalreferencial = reader.GetInt32(0);
                    refe.codvalreferencial = reader.GetString(1);
                    refe.valreferencial = reader.GetString(2);
                    listaAnalisis.Add(refe);
                }
            }
            cnx.Close();
            return listaAnalisis;
        }
        public List<PacienteBE> getArchivo(String fechaini,String fechafin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_ARCHIVO", cnx);
            cmd.Parameters.Add(new SqlParameter("@fechaInicial", fechaini));
            cmd.Parameters.Add(new SqlParameter("@fechaFinal", fechafin));

            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<PacienteBE> listaPacientes = new List<PacienteBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    PacienteBE pac = new PacienteBE();
                    pac.numGuia = reader.GetString(0);
                    pac.numHistoria = reader.GetString(1);
                    pac.paterno = reader.GetString(2);
                    pac.fechaRecLab = reader.GetString(3);
                    pac.fechaRecArc = reader.GetString(4);

                    listaPacientes.Add(pac);
                }
            }

            cnx.Close();
            return listaPacientes;
        }

        public List<LabProductoBE> getAllAnalisis(string tipo, string busq)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_ALLANALISIS", cnx);
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            cmd.Parameters.Add(new SqlParameter("@busq", busq));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> listaAnalisis = new List<LabProductoBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.id = reader.GetInt32(0);
                    producto.codana = reader.GetString(1);
                    producto.analisis = reader.GetString(2);
                    producto.unidad = reader.GetString(3);
                    producto.titulo = reader.GetString(4);
                    producto.codpro = reader.GetString(5);
                    producto.procedimiento = reader.GetString(6);
                    producto.arealab = reader.GetString(7);
                    producto.areaAnalisis = reader.GetString(8);
                    listaAnalisis.Add(producto);
                }
            }
            cnx.Close();
            return listaAnalisis;
        }

        public List<LabAnalisisBE> getReporte(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE1", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));

            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabAnalisisBE> labAnalisislista = new List<LabAnalisisBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabAnalisisBE analisis = new LabAnalisisBE();
                    analisis.areaAnalisis = reader.GetString(0);
                    analisis.analisis = reader.GetString(1);
                    analisis.resultado = reader.GetString(2);
                    analisis.unidad = reader.GetString(3);
                    analisis.valreferencial = reader.GetString(4);

                    labAnalisislista.Add(analisis);
                }
            }

            cnx.Close();
            return labAnalisislista;
        }
        public List<LabAnalisisBE> getReferencial(string codAna)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_VALREFERENCIAL", cnx);
            cmd.Parameters.Add(new SqlParameter("@codAna", codAna));

            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabAnalisisBE> labAnalisislista = new List<LabAnalisisBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabAnalisisBE analisis = new LabAnalisisBE();
                    analisis.valreferencial = reader.GetString(0);
                    labAnalisislista.Add(analisis);
                }
            }
            cnx.Close();
            return labAnalisislista;
        }
        public int updateRecepcionDet(string id, string resultado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_UPD_RECEPCIONDET", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@resultado", resultado));

            int result = cmd.ExecuteNonQuery();

            return result;
        }
        public int updateValorReferencial(LabAnalisisBE ana)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_UPD_VR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", ana.idvalreferencial));
            cmd.Parameters.Add(new SqlParameter("@ValReferencial", ana.valreferencial));
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        public int insertValorReferencial(LabAnalisisBE ana)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_VR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ValReferencial", ana.valreferencial));
            cmd.Parameters.Add(new SqlParameter("@CodAna", ana.codAna));
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public List<ReporteProduccionBE> getReporteProd(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PROD", cnx);
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReporteProduccionBE> lista = new List<ReporteProduccionBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    ReporteProduccionBE reporte = new ReporteProduccionBE();
                    reporte.areaAnalisis = reader.GetString(0);
                    reporte.analisis = reader.GetString(1);
                    reporte.uno = reader.GetInt32(2);
                    reporte.dos = reader.GetInt32(3);
                    reporte.tres = reader.GetInt32(4);
                    reporte.cuatro = reader.GetInt32(5);
                    reporte.cinco = reader.GetInt32(6);
                    reporte.seis = reader.GetInt32(7);
                    reporte.siete = reader.GetInt32(8);
                    reporte.ocho = reader.GetInt32(9);
                    reporte.nueve = reader.GetInt32(10);
                    reporte.diez = reader.GetInt32(11);
                    reporte.once = reader.GetInt32(12);
                    reporte.doce = reader.GetInt32(13);
                    reporte.trece = reader.GetInt32(14);
                    reporte.catorce = reader.GetInt32(15);
                    reporte.quince = reader.GetInt32(16);
                    reporte.d6 = reader.GetInt32(17);
                    reporte.d7 = reader.GetInt32(18);
                    reporte.d8 = reader.GetInt32(19);
                    reporte.d9 = reader.GetInt32(20);
                    reporte.v = reader.GetInt32(21);
                    reporte.v1 = reader.GetInt32(22);
                    reporte.v2 = reader.GetInt32(23);
                    reporte.v3 = reader.GetInt32(24);
                    reporte.v4 = reader.GetInt32(25);
                    reporte.v5 = reader.GetInt32(26);
                    reporte.v6 = reader.GetInt32(27);
                    reporte.v7 = reader.GetInt32(28);
                    reporte.v8 = reader.GetInt32(29);
                    reporte.v9 = reader.GetInt32(30);
                    reporte.t = reader.GetInt32(31);
                    reporte.t1 = reader.GetInt32(32);
                    reporte.subtotal = reader.GetInt32(33);
                    lista.Add(reporte);
                }
            }

            cnx.Close();
            return lista;
        }
        public int updMantenimientoAnalisis(LabProductoBE pro)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_UPD_MANTANALISIS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", pro.id));
            cmd.Parameters.Add(new SqlParameter("@analisis", pro.analisis));
            cmd.Parameters.Add(new SqlParameter("@unidad", pro.unidad));
            cmd.Parameters.Add(new SqlParameter("@codpro", pro.codpro));
            cmd.Parameters.Add(new SqlParameter("@procedimiento", pro.procedimiento));
            cmd.Parameters.Add(new SqlParameter("@arealab", pro.arealab));
            cmd.Parameters.Add(new SqlParameter("@areaana", pro.areaAnalisis));
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public string insMantenimientoAnalisis(LabProductoBE pro)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_MANTANALISIS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.Add(new SqlParameter("@id", pro.id));
            cmd.Parameters.Add(new SqlParameter("@analisis", pro.analisis));
            cmd.Parameters.Add(new SqlParameter("@unidad", pro.unidad));
            cmd.Parameters.Add(new SqlParameter("@codpro", pro.codpro));
            cmd.Parameters.Add(new SqlParameter("@procedimiento", pro.procedimiento));
            cmd.Parameters.Add(new SqlParameter("@arealab", pro.arealab));
            cmd.Parameters.Add(new SqlParameter("@areaana", pro.areaAnalisis));

            SqlParameter id = new SqlParameter("@codana", SqlDbType.VarChar, 10);
            id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            string result = (string)id.Value;
            return result;

        }

        public int updGuiaCerrado(string numGuia, string estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();


            SqlCommand cmd = new SqlCommand("USP_UPD_GUIACERRADO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));


            int result = cmd.ExecuteNonQuery();

            return result;
        }

        //CITAS

        public PacienteBE getPacienteCitas(String codPac)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PACIENTE_CITA", cnx);
            cmd.Parameters.Add(new SqlParameter("@numhistoria", codPac));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            PacienteBE paciente = new PacienteBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    paciente.nombreCompleto = reader.GetString(0);
                    paciente.direccion = reader.GetString(1);
                    paciente.dni = reader.GetString(2);
                    paciente.sexo = reader.GetString(3);
                    paciente.fechaNc = reader.GetString(4);
                    paciente.edad = reader.GetInt32(5);

                    paciente.idConvenio = reader.GetString(6);
                    paciente.titularConvenio = reader.GetString(7);
                    paciente.deConvenio = reader.GetString(8);
                    paciente.descTipoPaciente = reader.GetString(9);
                    paciente.flagConvenio = reader.GetString(10);
                    
                }
            }

            cnx.Close();
            return paciente;
        }

        public List<EspecialidadBE> getEspecialidades()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_ESPECIALIDADES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<EspecialidadBE> listaEspecialidades = new List<EspecialidadBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    EspecialidadBE especialidad = new EspecialidadBE();
                    especialidad.id_esp = reader.GetString(0);
                    especialidad.Especialidad = reader.GetString(1);
                    listaEspecialidades.Add(especialidad);
                }
            }
            cnx.Close();
            return listaEspecialidades;
        }

        public DataTable getEspecialidades1()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_ESPECIALIDADES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }

        public List<CitaBE> getCitaMedico(String id_Esp)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_MEDICO_CITA", cnx);
            cmd.Parameters.Add(new SqlParameter("@id_esp", id_Esp));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<CitaBE> listaMedicos = new List<CitaBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    CitaBE medico = new CitaBE();
                    medico.id_med = reader.GetString(0);
                    medico.codmed = reader.GetString(1);
                    medico.medico = reader.GetString(2);
                    medico.manana = reader.GetString(3);
                    medico.tarde = reader.GetString(4);
                    listaMedicos.Add(medico);
                }
            }
            cnx.Close();
            return listaMedicos;
        }
        public CitaBE getPrecioCita(String id_esp)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PRECIO_CITA", cnx);
            cmd.Parameters.Add(new SqlParameter("@id_esp", id_esp));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();


            CitaBE cita = new CitaBE();
            if (reader != null)
            {
                while (reader.Read())
                {

                    cita.precioconsulta = reader.GetDecimal(0);
                    cita.preciomedico = reader.GetDecimal(1);
                    cita.id_procedimiento = reader.GetString(2);
                }
            }
            cnx.Close();
            return cita;
        }

        public List<LabProductoBE> getProcedimientoxEspecialidad(string id_esp)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PROC_XESP", cnx);
            cmd.Parameters.Add(new SqlParameter("@id_esp", id_esp));

            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> listaprocedimientos = new List<LabProductoBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE procedimiento = new LabProductoBE();
                    procedimiento.id_pro = reader.GetString(0);
                    procedimiento.codpro = reader.GetString(1);
                    procedimiento.procedimiento = reader.GetString(2);
                    procedimiento.precioprocedimiento = reader.GetDecimal(3);
                    procedimiento.montoMedico = reader.GetDecimal(4);
                    procedimiento.tipoProcedimiento = reader.GetString(5);

                    procedimiento.cantidadP = reader.GetString(6);
                    procedimiento.monto =reader.GetString(7);
                    procedimiento.procImpresion = reader.GetString(8);
                    listaprocedimientos.Add(procedimiento);
                }
            }
            cnx.Close();
            return listaprocedimientos;
        }


        public string insertGuiaCompra(GuiaCajaCabBE a, GuiaCajaAportes credcab)
        {
            string val = "";
            char cero = '0';
            int numOrden = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        string procedimientos = "";

                        if (a.NumOrden == 0)
                        {
                             numOrden = insertarTurno(a.Id_Medico, a.Id_Turno, trans, con);
                            a.NumOrden = numOrden;
                        }
                        
                        var id = insertCajaCab(a, trans, con);
                        int flag = 0;
                        foreach (var det in a.detalle)
                        {
                            det.Id_Guia_Caja_Cab = id;
                            insertCajaDet(det, trans, con);
                            credcab.Id_Guia_Caja_Cab = id;

                            if (a.id_estado == "48")
                            {
                                var idcred = insertCajaAportes(credcab, trans, con);
                            }

                         

                           // flag = flag + verifAnalisis(det.Id_Procedimiento, trans, con);

                        }


                        /*if (flag > 0)
                        {
                            insertLabCab(id.ToString().PadLeft(10, cero), a.idUsuario, trans, con);
                            insertLabDet(id.ToString().PadLeft(10, cero), a.idUsuario, trans, con);

                        }*/

                        var idEsp=int.Parse(a.Id_Especialidad);
                        if (idEsp != 26 || idEsp != 19 || idEsp != 27 || idEsp != 29)
                        {
                            insertCuaderno(a, a.Id_Especialidad, id, trans, con);
                        }

                       



                        val = id.ToString() + "-"+ numOrden.ToString();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        val = ex.Message.ToString();
                        trans.Rollback();
                    }
                }
            }

            return val;
        }

       public void insertCuaderno(GuiaCajaCabBE g,string CodEsp,int id, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INSERTAR_CUADERNO", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NumGuia", id));
            cmd.Parameters.Add(new SqlParameter("@CodEsp", CodEsp));
            cmd.Parameters.Add(new SqlParameter("@CodMed", g.Id_Medico));
            cmd.Parameters.Add(new SqlParameter("@CodPac", g.Cod_Paciente));            
            cmd.Parameters.Add(new SqlParameter("@Turno", g.Id_Turno));
            cmd.Parameters.Add(new SqlParameter("@NumOrden", g.NumOrden));           
           
            int result = cmd.ExecuteNonQuery();
            
        }

        public int insertarTurno(string CodMed, string flag,  SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_NRO_ORDEN_MED", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodMed", CodMed));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            SqlParameter id_cab = new SqlParameter("@Id", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;

        }

        public int insertCajaCab(GuiaCajaCabBE g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_CONTADO_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Cod_Paciente", g.Cod_Paciente));
            cmd.Parameters.Add(new SqlParameter("@Id_Especialidad", g.Id_Especialidad));
            cmd.Parameters.Add(new SqlParameter("@Id_Medico", g.Id_Medico));
            cmd.Parameters.Add(new SqlParameter("@Id_Turno", g.Id_Turno));
            cmd.Parameters.Add(new SqlParameter("@NumOrden", g.NumOrden));
            cmd.Parameters.Add(new SqlParameter("@Aporte", Convert.ToDecimal(g.Aporte)));
            cmd.Parameters.Add(new SqlParameter("@Monto_total", Convert.ToDecimal(g.Monto_total)));
            cmd.Parameters.Add(new SqlParameter("@id_estado", g.id_estado));
            cmd.Parameters.Add(new SqlParameter("@id_medico_receta", g.id_medico_receta));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", g.idUsuario));
            cmd.Parameters.Add(new SqlParameter("@flagProc", g.flagProc));
            cmd.Parameters.Add(new SqlParameter("@flagOrdenExt", g.flagOrden));
            SqlParameter id_cab = new SqlParameter("@Id", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }

        public int insertCajaAportes(GuiaCajaAportes g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_APORTE", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Guia_Caja_Cab", g.Id_Guia_Caja_Cab));
            cmd.Parameters.Add(new SqlParameter("@Aporte", Convert.ToDecimal( g.Aporte)));
            cmd.Parameters.Add(new SqlParameter("@Deuda", Convert.ToDecimal(g.Deuda)));
            cmd.Parameters.Add(new SqlParameter("@idTipoCredito", g.idTipoCredito));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", g.idUsuario));
            SqlParameter id_cab = new SqlParameter("@flagAporte", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }
        public int insertCajaDet(GuiaCajaDetBE g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_CONTADO_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_caja_cab", g.Id_Guia_Caja_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo_Proc", g.Id_Tipo_Proc));
            cmd.Parameters.Add(new SqlParameter("@Id_Procedimiento", g.Id_Procedimiento));
           // cmd.Parameters.Add(new SqlParameter("@Id_Especialidad", g.Id_Especialidad));
            cmd.Parameters.Add(new SqlParameter("@PrecioProcedimiento",Convert.ToDecimal( g.PrecioProcedimiento)));

            cmd.Parameters.Add(new SqlParameter("@MontoMedico", Convert.ToDecimal(g.MontoMedico)));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", Convert.ToDecimal(g.SubTotal)));
            int result = cmd.ExecuteNonQuery();
            return result;
        }


        public int insertLabCab(string Id, int idusuario, String observacion, SqlTransaction trans, SqlConnection cnx)
        {
            SqlCommand cmd = new SqlCommand("USP_INS_LAB_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NumGuia", Id));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idusuario));
            cmd.Parameters.Add(new SqlParameter("@observacion", observacion));
            int result = cmd.ExecuteNonQuery();
            return result;
        }


        public int insertLabDet(string Id, int idusuario, SqlTransaction trans, SqlConnection cnx)
        {
            SqlCommand cmd = new SqlCommand("USP_INS_LAB_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NumGuia", Id));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idusuario));
            int result = cmd.ExecuteNonQuery();
            return result;
        }


        public int verifAnalisis(string idprocedimiento, SqlTransaction trans, SqlConnection cnx)
        {
            SqlCommand cmd = new SqlCommand("USP_VERIF_ANALISIS", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPro", idprocedimiento));
            SqlParameter total = new SqlParameter("@total", SqlDbType.Int);
            total.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(total);
            cmd.ExecuteNonQuery();
            int result = (int)total.Value;
            return result;
        }



        public string insertCitaCredito(GuiaCajaCabBE a, GuiaCajaAportes credcab)
        {
            string val = "";
            int idCred = 0;
            char cero = '0';
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        int flag = 0;
                        var numOrden = insertarTurno(a.Id_Medico, a.Id_Turno, trans, con);
                        a.NumOrden = numOrden;
               
                        var id = insertCajaCab(a, trans, con);

                        foreach (var det in a.detalle)
                        {
                            det.Id_Guia_Caja_Cab = id;
                            insertCajaDet(det, trans, con);
                           // flag = flag + verifAnalisis(det.Id_Procedimiento, trans, con);
                        }
                        credcab.Id_Guia_Caja_Cab = id;

                        if (a.id_estado == "48")
                        {
         
                            idCred = insertCajaAportes(credcab, trans, con);
                            val = id.ToString()+"-"+ numOrden.ToString()+"-"+ idCred.ToString();
                        }
                        else
                        {
                            val = id.ToString() + "-" + numOrden.ToString();
                        }

                       /* if (flag > 0)
                        {
                            insertLabCab(id.ToString().PadLeft(10, cero), a.idUsuario, trans, con);
                            insertLabDet(id.ToString().PadLeft(10, cero), a.idUsuario, trans, con);

                        }*/

                        var idEsp = int.Parse(a.Id_Especialidad);

                        if (idEsp != 26 || idEsp != 19 || idEsp != 27 || idEsp != 29)
                        {
                            insertCuaderno(a, a.Id_Especialidad, id, trans, con);
                        }

                        
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }

            return val;
        }
        public int insertCajaCreditoCab(GuiaCajaCreditoCabBE g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_CREDITO_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Guia_Caja_Cab", g.Id_Guia_Caja_Cab));
            cmd.Parameters.Add(new SqlParameter("@MontoTotal", g.MontoTotal));
            cmd.Parameters.Add(new SqlParameter("@TotalAporte", g.TotalAporte));
            cmd.Parameters.Add(new SqlParameter("@UltimoAporte", g.UltimoAporte));
            cmd.Parameters.Add(new SqlParameter("@Deuda", g.Deuda));

            SqlParameter id_cab = new SqlParameter("@Id", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }
        public int insertCajaCreditoDet(GuiaCajaCreditoDetBE g, SqlTransaction trans, SqlConnection cnx)
        {


            SqlCommand cmd = new SqlCommand("USP_INS_CREDITO_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_credito_Cab", g.Id_credito_Cab));
            cmd.Parameters.Add(new SqlParameter("@aporte", g.aporte));
            cmd.Parameters.Add(new SqlParameter("@deuda", g.deuda));
            cmd.Parameters.Add(new SqlParameter("@idTipoCredito", g.idTipoCredito));

            int result = cmd.ExecuteNonQuery();
            return result;
        }
        public List<ComboBE> getComboMedico()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMBO_MEDICO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@flag", flag));
            IDataReader reader = cmd.ExecuteReader();

            List<ComboBE> pList = new List<ComboBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);

                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;
        }

        public List<ComboBE> getComboMedicoFarmacia()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMBO_MEDICO_FARMACIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@flag", flag));
            IDataReader reader = cmd.ExecuteReader();

            List<ComboBE> pList = new List<ComboBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);

                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;
        }
        public List<PacienteBE> llenarImpresion()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_IMPRESION", cnx);

            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<PacienteBE> listaPacientes = new List<PacienteBE>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    PacienteBE pac = new PacienteBE();
                    pac.numGuia = reader.GetString(0);
                    pac.fechaGuia = reader.GetString(1);
                    pac.filasDetalle = reader.GetInt32(2);

                    listaPacientes.Add(pac);
                }
            }

            cnx.Close();
            return listaPacientes;
        }

        public CitaBE getMontoProc(string IdProc)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_MONTO_PROC", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Procedimiento", Convert.ToInt32(IdProc)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            CitaBE pac = new CitaBE();

            if (reader != null)
            {
                while (reader.Read())
                {

                    pac.precioconsulta = reader.GetDecimal(0);
                    pac.preciomedico = reader.GetDecimal(1);


                }
            }

            cnx.Close();
            return pac;
        }
                
        // agregado para conceptos
        public int insertConceptos(ConceptosBE concepto)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_CONCEPTO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo", concepto.tipo));
            cmd.Parameters.Add(new SqlParameter("@concepto", concepto.concepto));
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public int updImpresionLab(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("LAB_USP_UPD_IMPRESION", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NumGuia", numguia));
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        
       /* public List<LabProductoBE> getExamenes(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_EXAMENES", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<LabProductoBE> labProductolista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    LabProductoBE producto = new LabProductoBE();
                    producto.procedimiento = reader.GetString(0); 
                    producto.Observacion = reader.GetString(1);
                    labProductolista.Add(producto);
                }
            }
            cnx.Close();
            return labProductolista;
        }*/

        public DataTable getExamenes(string numGuia)
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_EXAMENES", cnx);
     
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }


        public DataTable GetReporteCab(String numGuia)
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_GUIALAB_CAB", cnx);
            //SqlCommand cmd = new SqlCommand("USP_GET_REPORTEIMPRIMIR", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }
        public DataTable GetReporteMas(String numGuia)
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
           
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTEIMPRIMIR", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }
        public DataTable GetReporteCuerpo(String numGuia)
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE1", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }

        public int insertRecepcion(String numGuia, int idUsuario, String observacion)
        {

            int val = 0;

            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        val = insertLabCab(numGuia, idUsuario, observacion, trans, con);
                        if (val > 0)
                        {
                            val = insertLabDet(numGuia, idUsuario, trans, con);
                            if (val > 0)
                            {
                                trans.Commit();
                            }
                            else
                            {
                                trans.Rollback();
                            }
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            return val;
        }

        public String getImpreso(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_OBTENER_IMPRESO", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();
            String impreso = "N";
            List<LabProductoBE> labProductolista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    impreso = reader.GetString(0);
                }
            }
            cnx.Close();
            return impreso;
        }
        public PacienteBE getRecepcionPaciente(String numGuia)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_RECEPCIONPAC", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            PacienteBE UnidadesList = new PacienteBE();
            PacienteBE g = new PacienteBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.fechaGuia = reader.GetString(0);
                    g.numHistoria = reader.GetString(1);
                    g.paterno = reader.GetString(2);
                    g.materno = reader.GetString(3);
                    g.nombres = reader.GetString(4);
                    g.fechaNc = reader.GetString(5);
                    g.edad = reader.GetInt32(6);
                    g.dni = reader.GetString(7);
                    g.sexo = reader.GetString(8);
                    g.fechaRec = reader.GetString(10);
                    g.personaRecep = reader.GetString(11);
                }
            }

            cnx.Close();
            return g;
        }

        public int existeRecepcion(string numGuia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_VERIF_RECEPCION", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@numGuia", numGuia));
            SqlParameter total = new SqlParameter("@total", SqlDbType.Int);
            total.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(total);
            cmd.ExecuteNonQuery();
            int result = (int)total.Value;
            cnx.Close();
            return result;
        }
        public int updateImpreso(string numguia)
        {
            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();

                SqlCommand cmd = new SqlCommand("USP_UPD_IMPRESO", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));

                result = cmd.ExecuteNonQuery();

                return result;

            }
            catch (Exception)
            {
                return result;
            }

        }
        public String getObservacion(string numguia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_OBTENER_OBSERVACION", cnx);
            cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();
            String observacion = "";
            List<LabProductoBE> labProductolista = new List<LabProductoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    observacion = reader.GetString(0);
                }
            }
            cnx.Close();
            return observacion;
        }
        public int updateEstadoGuia(int numguia, int idproc,string estado)
        {
            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();

                SqlCommand cmd = new SqlCommand("USP_UPD_ESTADOGUIA", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@numGuia", numguia));
                cmd.Parameters.Add(new SqlParameter("@idproc", idproc));
                cmd.Parameters.Add(new SqlParameter("@estado", estado));
                result = cmd.ExecuteNonQuery();

                return result;

            }
            catch (Exception)
            {
                return result;
            }

        }

        public String getVR(int id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_VRDET", cnx);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();
            String vr = "";
            if (reader != null)
            {
                while (reader.Read())
                {
                    vr = reader.GetString(0);
                }
            }
            cnx.Close();
            return vr;
        }

        public int updateVRDetalle(int idDetalle, string VR)
        {
            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("USP_UPD_VRDETALLE", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idDetalle", idDetalle));
                cmd.Parameters.Add(new SqlParameter("@VR", VR));
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
        public int updateVRMaestra(int idVR, string VR)
        {
            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("USP_UPD_VRMAESTRA", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idVR", idVR));
                cmd.Parameters.Add(new SqlParameter("@VR", VR));
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public String getUnidad(int id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_UNIDAD", cnx);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();
            String unidad = "";
            if (reader != null)
            {
                while (reader.Read())
                {
                    unidad = reader.GetString(0);
                }
            }
            cnx.Close();
            return unidad;
        }
        public int updateUnidadDetalle(int idDetalle, string unidad)
        {
            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("USP_UPD_UNIDAD", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idDetalle", idDetalle));
                cmd.Parameters.Add(new SqlParameter("@unidad", unidad));
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
