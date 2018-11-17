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
  public  class PacienteNuevoDA
    {
        public string insertPersona(PersonaPaciente Persona)
        {
            string result = "";
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_PACIENTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", Persona.CodPac));
            cmd.Parameters.Add(new SqlParameter("@DNI", Persona.NroDoc));
            cmd.Parameters.Add(new SqlParameter("@ApePat", Persona.ApePaterno));
            cmd.Parameters.Add(new SqlParameter("@ApeMat", Persona.ApeMaterno));
            cmd.Parameters.Add(new SqlParameter("@Nom", Persona.Nombre));
            cmd.Parameters.Add(new SqlParameter("@FecNac", DateTime.Parse(Persona.FechaNac)));

            cmd.Parameters.Add(new SqlParameter("@Sex", Persona.Sexo));
            cmd.Parameters.Add(new SqlParameter("@EstCiv", Persona.EstadoCivil));
            cmd.Parameters.Add(new SqlParameter("@Dir", Persona.Direccion));
            cmd.Parameters.Add(new SqlParameter("@CodDis", Persona.Ubigeo));
            cmd.Parameters.Add(new SqlParameter("@Tel", Persona.Telefono));
            cmd.Parameters.Add(new SqlParameter("@Alergias", Persona.flagAlergia));
            cmd.Parameters.Add(new SqlParameter("@Obs", Persona.Observaciones));
            cmd.Parameters.Add(new SqlParameter("@Conv_CodIns", Persona.CodInstitucion));

            cmd.Parameters.Add(new SqlParameter("@Conv_TipoBeneficiario", Persona.TipoBeneficiario));
            cmd.Parameters.Add(new SqlParameter("@Conv_CodTitular", Persona.codTitular));
            cmd.Parameters.Add(new SqlParameter("@AldeaInstitucion", Persona.flagAldeas));

            cmd.Parameters.Add(new SqlParameter("@TipoPaciente", Persona.tipoPaciente));
            cmd.Parameters.Add(new SqlParameter("@TipoDocumento", Persona.tipoDocumento));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.VarChar,21);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
           result = personId.Value.ToString();
            return result;            
        }

        public int verificaPersonaTipo(string codPac, int tipoPac)
        {
            int result = 0;
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_VERIFICA_PACIENTE_NUEVO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPaciente", codPac));
            cmd.Parameters.Add(new SqlParameter("@TipoPac", tipoPac));
            SqlParameter personId = new SqlParameter("@res", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            result =int.Parse( personId.Value.ToString());
            return result;
        }




        public PersonaPaciente getDatosPaciente(string id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_PACIENTE_NUEVO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", id));
            IDataReader reader = cmd.ExecuteReader();

            PersonaPaciente g = new PersonaPaciente();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.CodPac = reader.GetString(0);
                    g.NroDoc = reader.GetString(1);
                    g.ApePaterno = reader.GetString(2);
                    g.ApeMaterno = reader.GetString(3);
                    g.Nombre = reader.GetString(4);
                    g.FechaNac = reader.GetDateTime(5).ToShortDateString();
                    g.Sexo = reader.GetInt32(6);
                    g.EstadoCivil = reader.GetInt32(7);
                    g.Direccion = reader.GetString(8);
                    g.Ubigeo = reader.GetString(9);
                    g.Telefono = reader.GetString(10);
                    g.flagAlergia = reader.GetInt32(11);
                    g.Observaciones = reader.GetString(12);
                    g.CodInstitucion = reader.GetInt32(14);
                    g.Conve_IE = reader.GetString(15);
                    g.TipoBeneficiario = reader.GetInt32(16);
                    g.codTitular = reader.GetString(17);
                    g.titularNombre = reader.GetString(18);
                    g.flagAldeas = reader.GetInt32(19);
                    g.tipoPaciente = reader.GetInt32(20);
                    g.tipoDocumento = reader.GetInt32(21); 
                }
            }

            cnx.Close();
            return g;
        }

        public PersonaPaciente getDatosPacienteByDNI(string id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_POR_DNI", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DNI", id));
            IDataReader reader = cmd.ExecuteReader();

            PersonaPaciente g = new PersonaPaciente();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.CodPac = reader.GetString(0);
                    g.NroDoc = reader.GetString(1);
                    g.ApePaterno = reader.GetString(2);
                    g.ApeMaterno = reader.GetString(3);
                    g.Nombre = reader.GetString(4);
                    g.FechaNac = reader.GetDateTime(5).ToShortDateString();
                    g.Sexo = reader.GetInt32(6);
                    g.EstadoCivil = reader.GetInt32(7);
                    g.Direccion = reader.GetString(8);
                    g.Ubigeo = reader.GetString(9);
                    g.Telefono = reader.GetString(10);
                    g.flagAlergia = reader.GetInt32(11);
                    g.Observaciones = reader.GetString(12);
                    g.CodInstitucion = reader.GetInt32(14);
                    g.Conve_IE = reader.GetString(15);
                    g.TipoBeneficiario = reader.GetInt32(16);
                    g.codTitular = reader.GetString(17);
                    g.titularNombre = reader.GetString(18);
                    g.flagAldeas = reader.GetInt32(19);
                    g.tipoPaciente = reader.GetInt32(20);
                    g.tipoDocumento = reader.GetInt32(21);
                }
            }

            cnx.Close();
            return g;
        }

        



        public int addUsuarioDetalle(string ApePaterno, string ApeMaterno, string nombres, string NroDocumento, string Pass,string idEstado,string guia, List<int> val)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        int id = addUsuario(ApePaterno,  ApeMaterno,  nombres,  NroDocumento,  Pass,  idEstado,guia, trans, con);
                        for (int i = 0; i < val.Count; i++)
                        {
                            addAccesos(id, val[i], trans, con);
                        }
                        res = id;
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }

            return res;
        }

        public int addUsuario(string ApePaterno, string ApeMaterno, string nombres, string NroDocumento, string Pass,string idEstado,string guia, SqlTransaction trans, SqlConnection cnx)
        {


            SqlCommand cmd = new SqlCommand("USP_INS_UPD_USUARIO", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ApePaterno", ApePaterno));
            cmd.Parameters.Add(new SqlParameter("@ApeMaterno", ApeMaterno));
            cmd.Parameters.Add(new SqlParameter("@Nombres", nombres));
            cmd.Parameters.Add(new SqlParameter("@NroDocumento", NroDocumento));
            cmd.Parameters.Add(new SqlParameter("@Contrasenia", Pass));
            cmd.Parameters.Add(new SqlParameter("@Estado", idEstado));
            cmd.Parameters.Add(new SqlParameter("@flagGuia", guia));
            SqlParameter id_cab = new SqlParameter("@Id", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
            /*
             @NombreCompleto varchar(200),@NroDocumento varchar(15),@Contrasenia varchar(20),@Estado int 
             */
        }

        public int addAccesos(int IdPersona,int valor, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_ACCESOS", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IdPersona", IdPersona));
            cmd.Parameters.Add(new SqlParameter("@valor", valor));     
            int result = cmd.ExecuteNonQuery();
            return result;

        }

        public List<Usuario> getUsuario(string DNI)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PERSONAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DNI", DNI));
            IDataReader reader = cmd.ExecuteReader();

            List<Usuario> list = new List<Usuario>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Usuario g = new Usuario();
                    g.Id = reader.GetInt32(0);
                    g.DNI = reader.GetString(1);
                    g.nombreCompleto = reader.GetString(2);
                    g.contrasenia = reader.GetString(3);
                    g.idEstado = reader.GetInt32(4);
                    g.ApePaterno = reader.GetString(5);
                    g.ApeMaterno = reader.GetString(6);
                    g.Nombres = reader.GetString(7);
                    g.flagGuia = reader.GetInt32(8);
                    list.Add(g);
                }
            }

            cnx.Close();
            return list;
        }


        public List<int> getPermisoMenu(string idPersona)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_MENU", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Usuario", idPersona));
            IDataReader reader = cmd.ExecuteReader();

            List<int> list = new List<int>();
            if (reader != null)
            {
                while (reader.Read())
                {              
                    list.Add(reader.GetInt32(0));
                }
            }

            cnx.Close();
            return list;
        }

        public int verificaTitular(string codHistoria)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_VERIFICA_TITULAR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", codHistoria));
            int result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            return result;
        }



        public DataTable getDatosPacienteDT(string id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_PACIENTE_NUEVO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", id));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }

        public DataTable busquedaPaciente(string paciente)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_PACIENTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@paciente", paciente));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();

            return dt;
        }


        /*public List<PersonaPaciente> busquedaPaciente(string paciente)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_BUSCAR_PACIENTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@paciente", paciente));
            IDataReader reader = cmd.ExecuteReader();

            List<PersonaPaciente> list = new List<PersonaPaciente>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    PersonaPaciente g = new PersonaPaciente();
                    g.CodPac = reader.GetString(0);
                    g.NroDoc = reader.GetString(1);
                    g.ApePaterno = reader.GetString(2);
                    g.ApeMaterno = reader.GetString(3);
                    g.Nombre = reader.GetString(4);
                    g.FechaNac = reader.GetDateTime(5).ToShortDateString();
                    g.Sexo = reader.GetInt32(6);
                    g.EstadoCivil = reader.GetInt32(7);
                    g.Direccion = reader.GetString(8);
                    g.Ubigeo = reader.GetString(9);
                    g.Telefono = reader.GetString(10);
                    g.flagAlergia = reader.GetInt32(11);
                    g.Observaciones = reader.GetString(12);
                    g.NombreCompleto = reader.GetString(13);
                    g.CodInstitucion = reader.GetInt32(14);
                    g.Conve_IE = reader.GetString(15);
                    g.TipoBeneficiario = reader.GetInt32(16);
                    g.codTitular = reader.GetString(17);
                    g.titularNombre = reader.GetString(18);
                    g.flagAldeas = reader.GetInt32(19);
                    g.tipoPaciente = reader.GetInt32(20);
                    g.tipoDocumento = reader.GetInt32(21);


                    list.Add(g);
                }
            }

            cnx.Close();
            return list;
        }*/

        public List<PersonaPaciente> getPacienteRegistrado(string fecha)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_PACIENTES_CREADOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FechaRegistro", fecha));
            IDataReader reader = cmd.ExecuteReader();

            List<PersonaPaciente> list = new List<PersonaPaciente>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    PersonaPaciente g = new PersonaPaciente();
                    g.CodPac = reader.GetString(0);
                    g.NroDoc = reader.GetString(1);
                    g.Nombre = reader.GetString(2);
                    g.TipoPac = reader.GetString(3);
                 
                    list.Add(g);
                }
            }

            cnx.Close();
            return list;
        }

        public int eliminaPaciente(string codPaciente)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_ELIMINAR_PACIENTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CodPac", codPaciente));
        
            int result = cmd.ExecuteNonQuery();
            return result;

        }

    }
}
