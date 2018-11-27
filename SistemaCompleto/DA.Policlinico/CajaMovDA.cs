using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Policlinico
{
     public  class CajaMovDA
    {
        public DataTable getMovimientos(int idUsuario,string FechaFin)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_MOVIMIENTOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@FechaFin", Convert.ToDateTime(FechaFin)));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public int deleteMov(int idMov, int idUsuario)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DEL_CAJA_MOV", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@IdMov", idMov));
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int setInsUpdovimientos(int tipo,CajaMovBE b,int idUsuario)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_CAJA_MOV", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IdMov", b.IdMov));
            cmd.Parameters.Add(new SqlParameter("@Id_Cat", b.Id_Cat));
            cmd.Parameters.Add(new SqlParameter("@Id_SC", b.Id_SC));
            
            cmd.Parameters.Add(new SqlParameter("@Monto", b.Monto));
            cmd.Parameters.Add(new SqlParameter("@NroFactura", b.NroFactura));          
            cmd.Parameters.Add(new SqlParameter("@Empresa", b.Empresa));
            cmd.Parameters.Add(new SqlParameter("@PersonaRecepcion", b.PersonaRecepcion));
            cmd.Parameters.Add(new SqlParameter("@idUsuario",idUsuario));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            int result = cmd.ExecuteNonQuery();

            return result;

          
        }
    }
}
