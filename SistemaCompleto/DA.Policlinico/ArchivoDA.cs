using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
namespace DA.Policlinico
{
    public class ArchivoDA
    {
        public List<CitasDia> getCitasDia(string m)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_CITAS_DIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro", m));
            IDataReader reader = cmd.ExecuteReader();

            List<CitasDia> pList = new List<CitasDia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    CitasDia g = new CitasDia();
                    g.CodPac = reader.GetString(0);
                    g.paciente = reader.GetString(1);
                    g.Especialidad = reader.GetString(2);

                    g.Medico = reader.GetString(3);
                    g.turno = reader.GetString(4);
                   //
                    g.fecha = reader.GetString(5);
                    g.nroOrden = reader.GetInt32(6).ToString();
                    pList.Add(g);

               
                }
            }

            cnx.Close();
            return pList;
        }

        public DataTable getRecepcionRes1(string m, string fechaFin, int tipo)
        {
            
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_USP_LISTAR_RESULTADOS_LAB", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro", Convert.ToDateTime(m)));
            cmd.Parameters.Add(new SqlParameter("@FechaFin", Convert.ToDateTime(fechaFin)));
            cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getCitasMedico(string idMedico, string fecha)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_USP_MOSTRAR_REP_MEDICOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));
            cmd.Parameters.Add(new SqlParameter("@IdMed", idMedico));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;

            /* List<CitasDia> pList = new List<CitasDia>();
             if (reader != null)
             {
                 while (reader.Read())
                 {
                     CitasDia g = new CitasDia();
                     g.CodPac = reader.GetString(1);
                     g.paciente = reader.GetString(2);
                     g.Especialidad = reader.GetString(3);

                     g.Medico = reader.GetString(4);
                     g.turno = reader.GetString(6);
                      g.nroOrden = reader.GetInt32(5).ToString();
                     g.fecha = reader.GetString(7);

                     pList.Add(g);


                 }
             }

             cnx.Close();
             return pList;*/
        }

        public int imprimirHistorias()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("ARC_USP_IMP_HISTORIAS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;  
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataTable getReportes(string fechaInicio, string fechaFin, string estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_USP_GET_REPORTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getCitasPaciente(string m, string CodPac)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_CITAS_PACIENTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;        
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro",m));
            cmd.Parameters.Add(new SqlParameter("@CodPac", CodPac));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
            /*IDataReader reader = cmd.ExecuteReader();

            List<CitasDia> pList = new List<CitasDia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    CitasDia g = new CitasDia();
                    g.CodPac = reader.GetString(0);
                    g.paciente = reader.GetString(1);
                    g.Especialidad = reader.GetString(2);

                    g.Medico = reader.GetString(3);
                    g.turno = reader.GetString(4);
                   // 
                    g.fecha = reader.GetString(5);
                    g.nroOrden = reader.GetInt32(6).ToString();
                    pList.Add(g);

               
                }
            }

            cnx.Close();
            return pList;*/
        }
        
        public List<CitasDia> getImpresion()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_IMPRESION_FALTANTES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
         
            IDataReader reader = cmd.ExecuteReader();

            List<CitasDia> pList = new List<CitasDia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    CitasDia g = new CitasDia();
                    g.CodPac = reader.GetString(0);
                    g.paciente = reader.GetString(1);
        

                    g.Medico = reader.GetString(3);
                    g.turno = reader.GetString(4);
                    // g.nroOrden = reader.GetInt32(5);
                    g.fecha = reader.GetString(5);

                    pList.Add(g);


                }
            }

            cnx.Close();
            return pList;
        }

        public DataTable getRecepcionRes(string m,string FechaFin, int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_USP_LISTAR_RESULTADOS_LAB", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro",Convert.ToDateTime(m)));
            cmd.Parameters.Add(new SqlParameter("@FechaFin", Convert.ToDateTime(FechaFin)));
            cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
            /*
            IDataReader reader = cmd.ExecuteReader();

            List<ResultadosLab> pList = new List<ResultadosLab>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ResultadosLab g = new ResultadosLab();
                    g.Guia = reader.GetString(0);
                    g.CodPac = reader.GetString(1);
                    g.paciente = reader.GetString(2);
                    g.FechaLab = reader.GetString(3);
                    g.FechaArc = reader.GetString(4);
                 
                    pList.Add(g);


                }
            }

            cnx.Close();
            return pList;*/
        }

        public int insResultadoLab(string nroGuia)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("ARC_USP_INS_RESULTADO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NumGuia", nroGuia));   
            int result = cmd.ExecuteNonQuery();        
            return result;
        }

        public int insMovHistorias(string CodPac, string estado, string fecha)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("ARC_USP_INS_MOV_HISTORIAS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", CodPac));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            int result = cmd.ExecuteNonQuery();        
            return result;
        }

        public int insMovHistoriasPrestamo(string CodPac,string idEspecialidad, string estado, string fecha)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("ARC_USP_INS_MOV_HISTORIAS_PRESTAMOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", CodPac));
            cmd.Parameters.Add(new SqlParameter("@idEspecialidad", idEspecialidad));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        



        public DataTable getCitasCuaderno(string m, string estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_CUADERNO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro", m));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }
   

        public DataTable getHistoriasPrestamos(string fechaInicio, string fechaFin, string estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_USP_GET_HISTORIAS_PRESTAMOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;

            /*
            IDataReader reader = cmd.ExecuteReader();

            List<CitasDia> pList = new List<CitasDia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    CitasDia g = new CitasDia();
                    g.CodPac = reader.GetString(0);
                    g.paciente = reader.GetString(1);
                    g.Especialidad = reader.GetString(2);                
                    g.fecha = reader.GetString(3);
                    g.estado = reader.GetString(4);
                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;*/
        }
    }
}


