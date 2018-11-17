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
    public class MedicinaDA
    {
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

        public List<ComboBE> geTrabajador(int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_USUARIO_MENU", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tipo ", flag));
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


        
        public List<UbigeoBE> getUbigeo(int flag, int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMBO_ART_MED", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@val", valor));
            
          
            IDataReader reader = cmd.ExecuteReader();

            List<UbigeoBE> pList = new List<UbigeoBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    UbigeoBE g = new UbigeoBE();
                    g.Id = reader.GetString(0);
                    g.Descripcion = reader.GetString(1);
                   
                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;
        }
        
        public int insertUpdMedicina(MedicinaBE medicina)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_MEDICAMENTOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", medicina.Id));
            cmd.Parameters.Add(new SqlParameter("@Codigo",""));
            cmd.Parameters.Add(new SqlParameter("@Descripcion", medicina.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", medicina.Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Categoria", medicina.Id_Categoria));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", medicina.Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Id_Unidad", medicina.Id_Unidad));
            cmd.Parameters.Add(new SqlParameter("@Id_Referencia", medicina.Id_Referencia));
            cmd.Parameters.Add(new SqlParameter("@StockMin", medicina.StockMin));
            cmd.Parameters.Add(new SqlParameter("@StockAct", medicina.StockAct));
            cmd.Parameters.Add(new SqlParameter("@idEstado", medicina.idEstado));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", medicina.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@PreVenta", medicina.PreVenta));
            cmd.Parameters.Add(new SqlParameter("@FechaVencimiento", Convert.ToDateTime(medicina.FechaVencimiento)));
            cmd.Parameters.Add(new SqlParameter("@Lote", medicina.Lote ?? ""));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", medicina.IdUsuario));
            cmd.Parameters.Add(new SqlParameter("@flagControlado", medicina.flagControlado));
            int result = cmd.ExecuteNonQuery();
        
            return result;
        }

        public List<MedicinaBE> getMedicina(int m)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_MEDICAMENTOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", m));
            IDataReader reader = cmd.ExecuteReader();

            List<MedicinaBE> pList = new List<MedicinaBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    MedicinaBE g = new MedicinaBE();
                    g.Id = reader.GetInt32(0);
                    g.Codigo = reader.GetString(1);
                    g.Descripcion = reader.GetString(2);
                    g.Id_Proveedor = reader.GetInt32(3);
                    g.Id_Tipo = reader.GetInt32(4);
                    g.Id_Categoria = reader.GetInt32(5);
                    g.Id_Unidad = reader.GetInt32(6);
                    g.Id_Referencia = reader.GetInt32(7);
                    g.StockMin = reader.GetInt32(8);
                    g.StockAct = reader.GetInt32(9);
                    g.PreCosto = reader.GetDecimal(10);
                    g.PreVenta = reader.GetDecimal(11);
                    var fecha = DateTime.Now;
                    var a = reader.GetDateTime(12);
                    g.FechaVencimiento = a.ToShortDateString();
                   // g.FechaVencimiento = DateTime.ParseExact(a.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); 
                    g.Lote = reader.GetString(13);
                    g.proveedor = reader.GetString(14);
                    g.tipo = reader.GetString(15);
                    g.unidad = reader.GetString(16);
                    g.categoria = reader.GetString(17);
                    g.referencia = reader.GetString(18);
                    g.flagControlado = reader.GetInt32(19);  
                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;
        }

        public List<MedicinaBE> busquedaMedicamento(string m,int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_MEDIC", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@desc", m));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            IDataReader reader = cmd.ExecuteReader();

            List<MedicinaBE> pList = new List<MedicinaBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    MedicinaBE g = new MedicinaBE();
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
