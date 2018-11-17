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

        public List<ComboBE> listarCombos_AFT(int tipo_accion, int tipo_ref, int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_TRANS_FARM_ALM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo_accion", tipo_accion));
            cmd.Parameters.Add(new SqlParameter("@tipo_ref", tipo_ref));
            cmd.Parameters.Add(new SqlParameter("@valor", valor));
            IDataReader reader = cmd.ExecuteReader();

            List<ComboBE> generalList = new List<ComboBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);            
                    generalList.Add(g);
                }
            }

            cnx.Close();
            return generalList;
        }

        public List<ComboBE> listarCombos_AFT_MED(int tipo_accion, int tipo_ref, int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_TRANS_FARM_ALM_MED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo_accion", tipo_accion));
            cmd.Parameters.Add(new SqlParameter("@tipo_ref", tipo_ref));
            cmd.Parameters.Add(new SqlParameter("@valor", valor));
            IDataReader reader = cmd.ExecuteReader();

            List<ComboBE> generalList = new List<ComboBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);
                    generalList.Add(g);
                }
            }

            cnx.Close();
            return generalList;
        }


        
        public List<ComboBE> listarCombos_AFC(int tipo_accion, int tipo_ref, int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMPRAS_FARM_ALM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo_accion", tipo_accion));
            cmd.Parameters.Add(new SqlParameter("@tipo_ref", tipo_ref));
            cmd.Parameters.Add(new SqlParameter("@valor", valor));
            IDataReader reader = cmd.ExecuteReader();

            List<ComboBE> generalList = new List<ComboBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                    g.Id = reader.GetInt32(0);
                    g.Id_Proveedor = reader.GetInt32(1);
                    g.Descripcion = reader.GetString(2);            
                    generalList.Add(g);
                }
            }

            cnx.Close();
            return generalList;
        }

        public List<ComboBE> listarCombos_AFC_Venta(int tipo_accion, int tipo_ref, int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMPRAS_FARM_ALM_VENTA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo_accion", tipo_accion));
            cmd.Parameters.Add(new SqlParameter("@tipo_ref", tipo_ref));
            cmd.Parameters.Add(new SqlParameter("@valor", valor));
            IDataReader reader = cmd.ExecuteReader();

            List<ComboBE> generalList = new List<ComboBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                    g.Id = reader.GetInt32(0);
                    g.Id_Proveedor = reader.GetInt32(1);
                    g.Descripcion = reader.GetString(2);
                    generalList.Add(g);
                }
            }

            cnx.Close();
            return generalList;
        }

        public List<ComboBE> getComboM(int flag, int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMBO_ART_MED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@val", valor));


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



        public List<ComboBE> getProveedorbyMed(int Id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_PROVEEDOR_MED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Med", Id));


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
       
    }
}
