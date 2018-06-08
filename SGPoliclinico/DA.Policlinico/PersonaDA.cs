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
    public class PersonaDA
    {
        public List<PersonaBE> getPersonaList()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LIST_PERSONA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<PersonaBE> personaList = new List<PersonaBE>();
            if(reader != null)
            {
                while(reader.Read())
                {
                    PersonaBE persona = new PersonaBE();
                    persona.id = reader.GetInt32(0);
                    persona.dni = reader.GetString(1);
                    persona.paterno = reader.GetString(2);
                    persona.materno = reader.GetString(3);
                    persona.nombres = reader.GetString(4);
                    persona.estado = reader.GetInt32(5);

                    personaList.Add(persona);
                }
            }

            cnx.Close();
            return personaList;
        }

        public PersonaBE getPersonabyID(int PersonaID)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PERSONA_BY_ID", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", PersonaID));

            IDataReader reader = cmd.ExecuteReader();

            PersonaBE persona = new PersonaBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    persona.id = reader.GetInt32(0);
                    persona.dni = reader.GetString(1);
                    persona.paterno = reader.GetString(2);
                    persona.materno = reader.GetString(3);
                    persona.nombres = reader.GetString(4);
                    persona.estado = reader.GetInt32(5);
                }
            }

            cnx.Close();
            return persona;
        }

        public int insertPersona(PersonaBE Persona)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INSERT_PERSONA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@dni", Persona.dni));
            cmd.Parameters.Add(new SqlParameter("@paterno", Persona.paterno));
            cmd.Parameters.Add(new SqlParameter("@materno", Persona.materno));
            cmd.Parameters.Add(new SqlParameter("@nombres", Persona.nombres));

            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int editPersona(PersonaBE Persona)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_EDIT_PERSONA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", Persona.id));
            cmd.Parameters.Add(new SqlParameter("@dni", Persona.dni));
            cmd.Parameters.Add(new SqlParameter("@paterno", Persona.paterno));
            cmd.Parameters.Add(new SqlParameter("@materno", Persona.materno));
            cmd.Parameters.Add(new SqlParameter("@nombres", Persona.nombres));

            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int deletePersona(int PersonaID)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_PERSONA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", PersonaID));

            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}
