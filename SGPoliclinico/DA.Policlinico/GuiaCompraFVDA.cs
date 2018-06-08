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
   public class GuiaCompraFVDA
    {
        public int insertUpdGuiaCompra(GuiaCompraFVBE g)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_GUIA_COMPRA_FV", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NumGuiaCom", g.NumGuiaCom));
            cmd.Parameters.Add(new SqlParameter("@Tipo_Compra", g.Tipo_Compra));
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", g.Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Tipo_Doc", g.Tipo_Doc));

            cmd.Parameters.Add(new SqlParameter("@Num_Doc", g.Num_Doc));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Recepcion", DateTime.Parse(g.Fecha_Recepcion)));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicamento", g.Id_Medicamento));
            cmd.Parameters.Add(new SqlParameter("@StockPrevio", g.StockPrevio));

            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@PreVenta", g.PreVenta));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));

            cmd.Parameters.Add(new SqlParameter("@FechaVencimiento", DateTime.Parse(g.FechaVencimiento)));
            cmd.Parameters.Add(new SqlParameter("@Lote", g.Lote));
            cmd.Parameters.Add(new SqlParameter("@Id_Servicio", g.Id_Servicio));
            cmd.Parameters.Add(new SqlParameter("@Contado", g.Contado));

            cmd.Parameters.Add(new SqlParameter("@Id_Usuario", g.Id_Usuario));
          
            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}

