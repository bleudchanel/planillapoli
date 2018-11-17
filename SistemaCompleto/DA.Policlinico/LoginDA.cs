using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity.Policlinico;

namespace DA.Policlinico
{
    public class LoginDA
    {
        public int getUsuarioIdbyLogin(string nroDocumento, string passUser, string ipUser)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LOGIN_USER", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nroDocumento", nroDocumento));
            cmd.Parameters.Add(new SqlParameter("@passUser", passUser));
            cmd.Parameters.Add(new SqlParameter("@ip", ipUser));

            IDataReader reader = cmd.ExecuteReader();

            int Id = 0;
            if (reader != null)
            {
                while (reader.Read())
                {
                    Id = reader.GetInt32(0);
                }
            }

            cnx.Close();
            return Id;
        }

        public LoginBE getSimpleDataUsuario(int idUser)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_SIMPLE_DATA_PERSONA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUser));

            IDataReader reader = cmd.ExecuteReader();

            LoginBE loginBE = new LoginBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    loginBE.nroDocumento = reader.GetString(0);
                    loginBE.nombreCompleto = reader.GetString(1);
                    loginBE.Rol = reader.GetString(2);
                }
            }

            cnx.Close();
            return loginBE;
        }

    }
}
