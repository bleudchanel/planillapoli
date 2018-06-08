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
    public class MedicinaDA
    {
        public List<ComboBE> getComboM(int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_COMBO_MEDICINA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
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
        public int insertUpdMedicina(MedicinaBE medicina)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_MEDICAMENTOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", medicina.Id));
            cmd.Parameters.Add(new SqlParameter("@Codigo", medicina.Codigo));
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
            cmd.Parameters.Add(new SqlParameter("@FechaVencimiento", medicina.FechaVencimiento??""));
            cmd.Parameters.Add(new SqlParameter("@Lote", medicina.Lote ?? ""));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", medicina.IdUsuario));
            int result = cmd.ExecuteNonQuery();
        
            return result;
        }
    }
}
