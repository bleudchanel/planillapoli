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
    public class ArticulosDA
    {
        
        public int insertUpdArticulo(ArticulosBE medicina)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_ARTICULOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", medicina.Id));

            cmd.Parameters.Add(new SqlParameter("@Descripcion", medicina.Descripcion));

            cmd.Parameters.Add(new SqlParameter("@Id_Categoria", medicina.Id_Categoria));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", medicina.Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Id_Unidad", medicina.Id_Unidad));
            cmd.Parameters.Add(new SqlParameter("@Id_Referencia", medicina.Id_Referencia));
            cmd.Parameters.Add(new SqlParameter("@StockMin", medicina.StockMin));
            cmd.Parameters.Add(new SqlParameter("@StockAct", medicina.StockAct));
            cmd.Parameters.Add(new SqlParameter("@idEstado", medicina.idEstado));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", medicina.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@PreVenta", medicina.PreVenta));

            cmd.Parameters.Add(new SqlParameter("@IdUsuario", medicina.IdUsuario));
            int result = cmd.ExecuteNonQuery();
        
            return result;
        }

        public List<ArticulosBE> getArticulos(int m)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_ARTICULOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", m));
            IDataReader reader = cmd.ExecuteReader();

            List<ArticulosBE> pList = new List<ArticulosBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ArticulosBE g = new ArticulosBE();
                    g.Id = reader.GetInt32(0);                  
                    g.Descripcion = reader.GetString(1);                 
                    g.Id_Tipo = reader.GetInt32(2);
                    g.Id_Categoria = reader.GetInt32(3);
                    g.Id_Unidad = reader.GetInt32(4);
                    g.Id_Referencia = reader.GetInt32(5);
                    g.StockMin = reader.GetInt32(6);
                    g.StockAct = reader.GetInt32(7);
                    g.PreCosto = reader.GetDecimal(8);
                    g.PreVenta = reader.GetDecimal(9);
                    g.tipo = reader.GetString(10);
                    g.unidad = reader.GetString(11);
                    g.categoria = reader.GetString(12);
                    g.referencia = reader.GetString(13);       
                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;
        }
    }
}
