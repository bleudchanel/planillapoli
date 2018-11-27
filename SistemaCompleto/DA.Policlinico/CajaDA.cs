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
    public class CajaDA
    {

        public List<CuotasOdontologicas> setPagoCuotaOdonto(int idCredito,int tipo_proc)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_CREDITO_CUOTA_ODONTO", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Credito_Cab", idCredito));
            cmd.Parameters.Add(new SqlParameter("@tipo_proc", tipo_proc));
          
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<CuotasOdontologicas> pList = new List<CuotasOdontologicas>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    CuotasOdontologicas g = new CuotasOdontologicas();
                    g.Nro_Guia = reader.GetInt32(0);
                    g.Procedimiento = reader.GetString(1);
                    g.PrecioProcedimiento = reader.GetDecimal(2);
                    g.Cantidad = reader.GetInt32(3);
                    g.MontoTotal = reader.GetDecimal(4);
                    g.MontoAporte = reader.GetDecimal(5);
                    g.Deuda = reader.GetDecimal(6);
                    g.SubTotal = reader.GetDecimal(7);
                    g.idEstado = reader.GetInt32(8);
                    g.flag = reader.GetInt32(9);
                    g.Turno= reader.GetInt32(10);
                    g.nroOrden= reader.GetInt32(11);
                    g.procImpresion = reader.GetString(12);
                    g.anterior = reader.GetDecimal(13);
                    g.idEsp = reader.GetInt32(14);
                    
                    pList.Add(g);

                }
            }

            cnx.Close();
            return pList;
        }

       

        public int cerrarCaja()
        {
            var result = -1;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();

                SqlCommand cmd = new SqlCommand("USP_CERRAR_CAJA", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public int habilitarGuia(string nroGuia,int tipo)
        {
            var result = -1;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();

                SqlCommand cmd = new SqlCommand("USP_HABILITAR_GUIA", cnx);
                cmd.Parameters.Add(new SqlParameter("@nroGuia", nroGuia));
                cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
                
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public List<CuotasOdontologicas> setCreditoTipo(int idCredito,int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_GUIA_TIPO", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Nro_Guia", idCredito));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<CuotasOdontologicas> pList = new List<CuotasOdontologicas>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    CuotasOdontologicas g = new CuotasOdontologicas();
                    g.Nro_Guia = reader.GetInt32(0);
                    g.Procedimiento = reader.GetString(1);
                    g.PrecioProcedimiento = reader.GetDecimal(2);
                    g.Cantidad = reader.GetInt32(3);
                    g.MontoTotal = reader.GetDecimal(4);
                    g.MontoAporte = reader.GetDecimal(5);
                    g.Deuda = reader.GetDecimal(6);
                    g.SubTotal = reader.GetDecimal(7);
                    g.FechaGuia = reader.GetString(8);
                    g.estAporte = reader.GetInt32(9);
                    g.estGuia = reader.GetInt32(10);
                    pList.Add(g);

                }
            }

            cnx.Close();
            return pList;
        }




          public List<Aportes> getAbonos(int idCredito,int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_ABONOS", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id", idCredito));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<Aportes> pList = new List<Aportes>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Aportes g = new Aportes();
                   g.NroAbono = reader.GetInt32(0);
                    
                    g.Aporte = reader.GetDecimal(1);
                    g.Estado = reader.GetString(2);
                    g.Deuda = reader.GetDecimal(3);                  
                    g.FechaRegistro = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                    g.Usuario = reader.GetString(5);
                    g.idTipoCredito = reader.GetInt32(6);
                    g.NroAbonoEx= g.idTipoCredito == 48 ? g.NroAbono.ToString()+"A": g.NroAbono.ToString();
                    
                    pList.Add(g);

                }
            }

            cnx.Close();
            return pList;
        }


        

       public int setAbono(int idCredito, decimal monto, int idUsuario)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_SET_ABONO_CUOTA_ODONTO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Credito_Cab", idCredito));
            cmd.Parameters.Add(new SqlParameter("@Abono", monto));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            SqlParameter id_cab = new SqlParameter("@flagAporte", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }
        
         public int setAbonoCredito(int idCredito, decimal monto, int idUsuario)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_SET_ABONO_CUOTA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Credito_Cab", idCredito));
            cmd.Parameters.Add(new SqlParameter("@Abono", monto));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            SqlParameter id_cab = new SqlParameter("@flagAporte", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }
        

      
        public int insertarAnulacion(int Id, int idAnulacion, string detalle, int idUsuario, int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_ANULACION_GUIA_ABONO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            //cmd.Parameters.Add(new SqlParameter("@Id_Anulacion", idAnulacion));
            cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", detalle));
            
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));

            int result = cmd.ExecuteNonQuery();

            return result;
        }

        public int verificaAnulacionCaja(int idUsuario, int Aporte, int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_VERIFICAR_ANULACION_CAJA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@Id_Caja_Aporte", Aporte));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            SqlParameter id_cab = new SqlParameter("@flagAnul", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }

        public int verificaAnulacionCajaAporte(int idUsuario, int Aporte, int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_VERIFICAR_ANULACION_CAJA_APORTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@Id_Caja_Aporte", Aporte));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            SqlParameter id_cab = new SqlParameter("@flagAnul", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }

       

        /* public int insertarAnulacion(int Id, int idAnulacion, string detalle, int idUsuario, int tipo)
         {
             SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
             cnx.Open();

             SqlCommand cmd = new SqlCommand("USP_ANULACION_CUOTA", cnx);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add(new SqlParameter("@Id_Credito_Det", Id));
             cmd.Parameters.Add(new SqlParameter("@Id_Anulacion", idAnulacion));
             cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", detalle));
             cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));    

             int result = cmd.ExecuteNonQuery();

             return result;
         }*/

        public PacienteCaja getDatosPacienteCaja(int NroGuia, int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_DATOS_CUOTAS", cnx);
            cmd.Parameters.Add(new SqlParameter("@NroGuia", NroGuia));
            cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            PacienteCaja g = new PacienteCaja();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.CodPaciente = reader.GetString(0);
                    g.nombreCompleto = reader.GetString(1);
                    g.Especialidad = reader.GetString(2);
                    g.Medico = reader.GetString(3);
                    g.FechaRegistro = reader.GetString(4);
                    g.descPacienteExterno = reader.GetString(5);
                    g.flagOrdenExterna = reader.GetInt32(6);
                    g.titularconvenio = reader.GetString(7);
                }
            }

            cnx.Close();
            return g;
        }


        public List<ComboBE> getDatosG( int valor)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_DATOS_GENERAL", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
        
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

        public DataTable getNroGuia(int Tipo, string nroGuia, int flagN)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_MOSTRAR_NRO_GUIA_CAJA_FARM", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Tipo", Tipo));
            cmd.Parameters.Add(new SqlParameter("@NroGuia", nroGuia));
            cmd.Parameters.Add(new SqlParameter("@flagN", flagN));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }
    }
}
