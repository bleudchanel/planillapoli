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
    public class AnulacionDA
    {
        public List<AnulacionBE> getDatosAnulacion(int NroGuia, int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_DATOS_ANULACION", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@NroGuia", NroGuia));
            cmd.Parameters.Add(new SqlParameter("@flag", flag ));

            IDataReader reader = cmd.ExecuteReader();

            List<AnulacionBE> anulacionList = new List<AnulacionBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    AnulacionBE g = new AnulacionBE();
            
                    g.Usuario = reader.GetString(0);
                    g.Nro_Doc = reader.GetString(1);
                    g.Fecha = reader.GetDateTime(2).ToShortDateString();
                    g.Total = reader.GetDecimal(3);
                    g.Descripcion = reader.GetString(4);
                    g.StockAct = reader.GetInt32(5);
                    g.PreCosto = reader.GetDecimal(6);
                    g.Cantidad = reader.GetInt32(7);
                    g.SubTotal = reader.GetDecimal(8);
                    g.Codigo = reader.GetInt32(9);
                    g.Tipo_Doc = reader.GetString(10);
                    g.idEstado = reader.GetInt32(11);
                    
                    anulacionList.Add(g);
                }
            }

            cnx.Close();
            return anulacionList;
        }

       /* public int insertarAnulacion(int Id, int flag, int idAnulacion, string detalle,int idUsuario)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_ANULACION", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Parameters.Add(new SqlParameter("@Id_Anulacion", idAnulacion));
            cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", detalle));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
          
            int result = cmd.ExecuteNonQuery();

            return result;
        }*/

        public int insertarAnulacion(int Id, int flag, int idAnulacion, string detalle, int idUsuario, List<AnulacionBE> data)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = anularCabecera(Id,  flag,  idAnulacion,  detalle,  idUsuario, trans, con);
                        foreach (var det in data)
                        {
                           
                            anularDetalle(det.Codigo,  det.Cantidad,  flag, trans, con);
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

        public int anularCabecera(int Id, int flag, int idAnulacion, string detalle, int idUsuario, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_ANULACION_CAB", cnx, trans);
         
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Parameters.Add(new SqlParameter("@Id_Anulacion", idAnulacion));
            cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", detalle));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public int anularDetalle(int Id_Producto, int Cantidad , int flag , SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_ANULACION_DETALLE", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Id_Producto", Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));

            int result = cmd.ExecuteNonQuery();
            return result;

        }
    }
}
