using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;

namespace DA.Policlinico
{
    public class GerenciaDA
    {
        public DataTable getIngresosDiarios(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_ING_DIARIOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt; 
        }

        public List<ComboBE> getMedicos(int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_MEDICOS_GERENCIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));



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

        public DataTable repPagoMedicoRes(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PAGO_MEDICO_RES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable repPagoMedicoDet(string fechaInicio, string fechaFin, int idDoctor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PAGO_MEDICO_DET", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@Id_Medico", idDoctor));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable repPagoOdontoRes(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PAGO_ODONTO_RES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable repPagoOdontoDet(string fechaInicio, string fechaFin, int idDoctor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PAGO_ODONTO_DET", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@Id_Medico", idDoctor));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getIngresosPagoMedico(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_ING_PAGO_MEDICO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;


        }

        public DataTable getIngresosPagoOdonto(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_ING_PAGO_ODONTO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            //cmd.Parameters.Add(new SqlParameter("@Id_Medico", fechaFin));
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;


        }

        public DataTable getIngresosDiariosFarm(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_ING_DIARIOS_FARM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getReporteEspMed(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_ESP_MED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getReporteRecetasFarm(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_RECETAS_FARM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getReporteServGenercIndic(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_SERV_GENERAC_INDIC", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getReporteStockVal(int IdRef)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_STOCK_VAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IdRef", IdRef));
     
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepProdEspProced(int mes,int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_PROD_ESP_PROCED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepProdEsp(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_PROD_ESP", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepProdEspProcedAnual(int idEsp, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_PROD_ESP_ANUAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEsp", idEsp));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepAtencEspProced(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_ATENC_ESP_PROCED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepAtencEsp(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_ATENC_ESP", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepAtencEspProcedAnual(int idEsp, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_ATENC_ESP_ANUAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idEsp", idEsp));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepAtencPacMensual(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_ATENC_PAC_MENSUAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepGuiasEmit(int mes, int anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_GUIAS_EMITIDAS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepDiarioCajaEfect(string FechaRegistro)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_DIARIO_CAJA_EFECT", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro", FechaRegistro));
   

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getRepDiarioFarmEfect(string FechaRegistro)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_DIARIO_FARM_EFECT", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro", FechaRegistro));


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getGuiaAnulCajaServ(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_GUIA_ANUL_USU_SERV", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getGuiaAnulCajaFarm(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_GUIA_ANUL_USU_FARM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getGuiaAnulMedServ(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_GUIA_ANUL_MED_SERV", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getGuiaAnulMedFarm(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_GUIA_ANUL_MED_FARM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getGuiaAnulMotServ(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_GUIA_ANUL_MOTIVO_SERV", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getGuiaAnulMotFarm(string fechaInicio, string fechaFin)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_GUIA_ANUL_MOTIVO_FARM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable repPagoMedicoBol(string fechaInicio, string fechaFin, int idDoctor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PAGO_MEDICO_BOL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@Id_Medico", idDoctor));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable repPagoOdontoBol(string fechaInicio, string fechaFin, int idDoctor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REPORTE_PAGO_ODONTO_BOL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@Id_Medico", idDoctor));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }
    }
}
