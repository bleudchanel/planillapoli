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
    public class UnidadesDA
    {
        public List<UnidadesBE> getUnidadesList()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_UNIDADES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            
            IDataReader reader = cmd.ExecuteReader();

            List<UnidadesBE> UnidadesList = new List<UnidadesBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    UnidadesBE g = new UnidadesBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);
                    g.Abreviatura = reader.GetString(2);
                    UnidadesList.Add(g);
                }
            }

            cnx.Close();
            return UnidadesList;
        }

        public int insertUpdUnidades(UnidadesBE Unidades)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_UNIDADES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Unidades.Id));
            cmd.Parameters.Add(new SqlParameter("@Descripcion", Unidades.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@Abreviatura", Unidades.Abreviatura));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", Unidades.idUsuario));    
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int deleteUnidades(int Id)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_UNIDADES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));


            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}
