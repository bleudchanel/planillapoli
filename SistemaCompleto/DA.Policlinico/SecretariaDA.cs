using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Policlinico
{
    public class SecretariaDA
    {
        public DataTable GetDatosPaciente(string fechaInicio, string fechaFin, string codPaciente)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_PACIENTE_SECRETARIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@codPaciente", codPaciente));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }
    }
}
