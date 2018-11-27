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
       public int insertGuiaCompra(GuiaCompraCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertGCfCab(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Guia_Cab = id;
                            insertGCDet(det, trans, con);
                        }
                        val = id;
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }

            return val;
        }

        public int insertGCfCab(GuiaCompraCab g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_GC_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idTipo_Guia", g.Id_Tipo_Guia));
            cmd.Parameters.Add(new SqlParameter("@Tipo_Compra", g.Tipo_Compra));
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", g.Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Tipo_Doc", g.Tipo_Doc));
            cmd.Parameters.Add(new SqlParameter("@Nro_Doc", g.Nro_Doc));
          
            cmd.Parameters.Add(new SqlParameter("@FechaRecepcion", DateTime.Parse(g.Fecha_Recepcion)));
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", g.Id_Usuario));
            cmd.Parameters.Add(new SqlParameter("@Id_Servicio", g.Id_Servicio));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }
    
        public int insertGCDet(GuiaCompraDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_GC_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@Id_Guia_Cab", g.Id_Guia_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@StockPrevio", g.StockPrevio));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@PreVenta", g.PreVenta));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));
            cmd.Parameters.Add(new SqlParameter("@FechaVencimiento", DateTime.ParseExact(g.FechaVencimiento.ToString(), "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture)));
            cmd.Parameters.Add(new SqlParameter("@Lote", g.Lote));     
            int result = cmd.ExecuteNonQuery();
            return result;

        }


        public int insertGuiaCompraAlm(GuiaCompraCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertGCfCabAlm(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Guia_Cab = id;
                            insertGCDetAlm(det, trans, con);
                        }
                        val = id;
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }

            return val;
        }

        public int insertGCfCabAlm(GuiaCompraCab g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_GC_ALM_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add(new SqlParameter("@Tipo_Compra", g.Tipo_Compra));
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", g.Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Tipo_Doc", g.Tipo_Doc));
            cmd.Parameters.Add(new SqlParameter("@Nro_Doc", g.Nro_Doc));

            cmd.Parameters.Add(new SqlParameter("@FechaRecepcion", DateTime.Parse(g.Fecha_Recepcion)));
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", g.Id_Usuario));
     
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }

        public int insertGCDetAlm(GuiaCompraDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_GC_ALM_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@Id_Guia_Cab", g.Id_Guia_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@StockPrevio", g.StockPrevio));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@PreVenta", g.PreVenta));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));
         
            int result = cmd.ExecuteNonQuery();
            return result;

        }
    }
}
