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
    public class ProveedorDA
    {
        public List<ProveedorBE> getProveedorList()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_PROVEEDORES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<ProveedorBE> pList = new List<ProveedorBE>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ProveedorBE g = new ProveedorBE();
                    g.Id = reader.GetInt32(0);
                    g.RUC = reader.GetString(1);
                    g.Razon_Social = reader.GetString(2);
                    g.Direccion = reader.GetString(3);
                    g.Telefono = reader.GetString(4);
                    g.Email = reader.GetString(5);
                    g.observacion = reader.GetString(6);
                    g.idEstado = reader.GetInt32(7);
                    g.C_Nombre = reader.GetString(8);
                    g.C_Telefono = reader.GetString(9);
                    g.C_Email = reader.GetString(10);
                    g.Id_Referencia = reader.GetInt32(11);
                    g.Descripcion = reader.GetString(12);
                    g.DescEstado = reader.GetString(13);
                    pList.Add(g);
                }
            }

            cnx.Close();
            return pList;
        }



        public int insertUpdProveedor(ProveedorBE Proveedor)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_UPD_PROVEEDOR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Proveedor.Id));
            cmd.Parameters.Add(new SqlParameter("@RUC", Proveedor.RUC));
            cmd.Parameters.Add(new SqlParameter("@Razon_Social", Proveedor.Razon_Social));
            cmd.Parameters.Add(new SqlParameter("@Direccion", Proveedor.Direccion));
            cmd.Parameters.Add(new SqlParameter("@Telefono", Proveedor.Telefono));
            cmd.Parameters.Add(new SqlParameter("@Email", Proveedor.Email));
            cmd.Parameters.Add(new SqlParameter("@Obs", Proveedor.observacion));
            cmd.Parameters.Add(new SqlParameter("@idEstado", Proveedor.idEstado));
            cmd.Parameters.Add(new SqlParameter("@C_Nombre", Proveedor.C_Nombre));
            cmd.Parameters.Add(new SqlParameter("@C_Telefono", Proveedor.C_Telefono));
            cmd.Parameters.Add(new SqlParameter("@C_Email", Proveedor.C_Email));
            cmd.Parameters.Add(new SqlParameter("@Id_Referencia", Proveedor.Id_Referencia));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", Proveedor.idUsuario));
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int deleteProveedor(int ProveedorID)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_PROVEEDOR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", ProveedorID));

            int result = cmd.ExecuteNonQuery();

            return result;
        }


        public ProveedorBE getProveedorById(int ProveedorID)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATA_PROVEEDOR_BY_ID", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add(new SqlParameter("@Id", ProveedorID));
            IDataReader reader = cmd.ExecuteReader();

            ProveedorBE g = new ProveedorBE();
            if (reader != null)
            {
                while (reader.Read())
                {          
              
                    g.RUC = reader.GetString(0);                  
                    g.Direccion = reader.GetString(1);          
             
                }
            }

            cnx.Close();
            return g;
        }

        
    }
}
