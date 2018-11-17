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
   public  class SetMedicoDA
    {
       public int insertSet(string Descripcion, int idUsuario)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_SET_MED_CAB", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            int result = cmd.ExecuteNonQuery();

            return result;
        }


 
        public int insertSetDetalle(int idCab,int idProducto, int cantidad,int tipo,int IdDet)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_SET_MED_DET", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Set_Cab", idCab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", idProducto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            cmd.Parameters.Add(new SqlParameter("@IdDet", IdDet));
            
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int deleteSetDetalle(int Id_Det)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_DEL_SET_MED_DET", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Det", Id_Det));

            int result = cmd.ExecuteNonQuery();

            return result;
        }
        public List<DetalleSetBE> getDetalleSet(int idCab)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_DETALLE_SET", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Set_Cab", idCab));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<DetalleSetBE> lista = new List<DetalleSetBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    DetalleSetBE g = new DetalleSetBE();
                    g.Id = reader.GetInt32(0);
                    g.Producto = reader.GetString(1);
                    g.cantidad = reader.GetInt32(2);
                    g.IdP = reader.GetInt32(3);
                    g.stockActual = reader.GetInt32(4);
                    g.flag = reader.GetInt32(5);
                    g.costo = String.Format("{0:0.00}", reader.GetDecimal(6));
                    lista.Add(g);
                }
            }

            cnx.Close();
            return lista;
        }
        public List<DetalleSetCabBE> getCabeceraSet()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_SET_CABECERA", cnx);
       
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<DetalleSetCabBE> lista = new List<DetalleSetCabBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    DetalleSetCabBE g = new DetalleSetCabBE();
                    g.Id = reader.GetInt32(0);
                    g.Descripcion = reader.GetString(1);
                    g.flag = reader.GetInt32(2);
                    g.costo = String.Format("{0:0.00}", reader.GetDecimal(3));

                    lista.Add(g);
                }
            }

            cnx.Close();
            return lista;
        }
    }
}
