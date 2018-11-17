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
    public class TransferenciaDA
    {
        public int insertTransferencia( TransfCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertTransfCab(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Transf_Cab = id;
                            insertTransfDet(det, trans, con);
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

        public int insertTransfCab(TransfCab g,SqlTransaction trans,SqlConnection cnx)
        {
                     
            SqlCommand cmd = new SqlCommand("USP_INS_TRANSF_CAB", cnx,trans);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add(new SqlParameter("@Id_Destino", g.Id_Destino));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Transf", DateTime.Parse(g.FechaTransf)));
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@Id_Usuario", g.Id_Usuario));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }

        public int insertTransfDet(TransfDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_TRANSF_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Transf_Cab", g.Id_Transf_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@Stock", g.Stock));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PrecioCosto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));
    
            
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public int insertTransferenciaAlm(TransfCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertTransfAlmCab(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Transf_Cab = id;
                            insertTransfAlmDet(det, trans, con);
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

        public int insertTransfAlmCab(TransfCab g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_TRANSF_ALM_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
  
            cmd.Parameters.Add(new SqlParameter("@Id_Destino", g.Id_Destino));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Transf", DateTime.Parse(g.FechaTransf)));
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@Id_Usuario", g.Id_Usuario));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }

        public int insertTransfAlmDet(TransfDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_TRANSF_ALM_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Transf_Cab", g.Id_Transf_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@Stock", g.Stock));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PrecioCosto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));
          

            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
