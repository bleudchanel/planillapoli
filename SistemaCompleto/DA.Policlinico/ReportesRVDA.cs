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
   public class ReportesRVDA
    {
        public DataTable GetDatosPaciente()
        {
            
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_GET_PACIENTES_HISTORIA_IMP", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
           
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable getCitasMedico(string idMedico, string fecha)
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("ARC_USP_MOSTRAR_REP_MEDICOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));
            cmd.Parameters.Add(new SqlParameter("@IdMed", idMedico));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }
    }
}
