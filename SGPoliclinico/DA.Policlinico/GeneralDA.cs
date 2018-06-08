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
    public class GeneralDA
    {
        public List<GeneralBE> getGeneralList(int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_GENERAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            IDataReader reader = cmd.ExecuteReader();

            List<GeneralBE> generalList = new List<GeneralBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    GeneralBE g = new GeneralBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);
                    g.TipoDescripcion = reader.GetString(2);
                    g.idServicio = reader.GetInt32(3);
                    generalList.Add(g);
                }
            }

            cnx.Close();
            return generalList;
        }

        public int insertUpdGeneral(GeneralBE general)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_GENERAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", general.Id));
            cmd.Parameters.Add(new SqlParameter("@Descripcion", general.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@idServicio", general.idServicio));

            cmd.Parameters.Add(new SqlParameter("@idUsuario", general.idUsuario));
            cmd.Parameters.Add(new SqlParameter("@flag", general.flag));
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int deleteGeneral(int Id, int flag)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_GENERAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));

            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}
