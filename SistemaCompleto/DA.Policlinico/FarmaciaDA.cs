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
    public class FarmaciaDA
    {
        public int insertguiaGuiaFarmacia(GuiaFarmaciaCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertGFCab(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Farmacia_Cab = id;
                            insertGFDet(det, trans, con);
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


        public int insertguiaGuiaFarmaciaBot(GuiaFarmaciaCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertGFCab(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Farmacia_Cab = id;
                            insertGFDet(det, trans, con);
                        }
                        var ad = setCreditoBot( id,  a.Total,  a.Id_Usuario, 35, trans, con);
                    
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
        

        public int insertGFCab(GuiaFarmaciaCab g, SqlTransaction trans, SqlConnection cnx)
        {

        
            SqlCommand cmd = new SqlCommand("USP_INS_GF_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Tipo_Cliente", g.Tipo_Cliente));
            cmd.Parameters.Add(new SqlParameter("@Cod_Paciente", g.Cod_Paciente));
            cmd.Parameters.Add(new SqlParameter("@Cod_Institucion", g.Cod_Institucion));
            cmd.Parameters.Add(new SqlParameter("@Cod_Pepasico", g.Cod_Pepasico));
            cmd.Parameters.Add(new SqlParameter("@Id_Medico", g.Id_Medico));
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", g.Id_Usuario));
            cmd.Parameters.Add(new SqlParameter("@TipoRegistro", g.TipoRegistro));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }

        public int insertGFDet(GuiaFarmaciaDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_GF_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Farmacia_Cab", g.Id_Farmacia_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@StockPrevio", g.StockPrevio));
            cmd.Parameters.Add(new SqlParameter("@PreVenta", g.PreVenta)); 
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PreCosto));       
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));
         
            int result = cmd.ExecuteNonQuery();
            return result;

        }

        public List<RecetaFarmacia> getRecetaFarmacia(int Id_Guia, int tipo, int flag, int Busq)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATO_RECETA_FARMACIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Farmacia_Cab", Id_Guia));
            cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@Busq", Busq));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<RecetaFarmacia> pList = new List<RecetaFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    RecetaFarmacia g = new RecetaFarmacia();
                    g.Id_Farmacia_Cab = reader.GetInt32(0);
                    g.NroDocumento = reader.GetString(1);
                    g.nombres = reader.GetString(2);
                    g.Cod_Tipo_Cliente = reader.GetInt32(3);
                    
                    g.Cod_Paciente = reader.GetInt32(4);
                    g.Cod_Institucion = reader.GetInt32(5);
                    g.Cod_Pepasico = reader.GetInt32(6);
                    g.Total = reader.GetDecimal(7);
                    g.medicamento = reader.GetString(8);
                    g.stock = reader.GetInt32(9);
                    g.PreCosto = reader.GetDecimal(10);
                    g.Cantidad = reader.GetInt32(11);
                    g.SubTotal = reader.GetDecimal(12);
                    g.FechaRegistro = reader.GetDateTime(13).ToString("dd/MM/yyyy");
                    g.Id_Producto = reader.GetInt32(14);
                    g.idEstado = reader.GetInt32(15);

                    g.flagSet = reader.GetInt32(16);
                    g.NombreSet=reader.GetString(18);
                    g.TipoRegistro= reader.GetInt32(19);
                    pList.Add(g);
                 
                }
            }

            cnx.Close();
            return pList;
        }

        public List<RecetaFarmacia> getRecetaFarmaciaCred(int Id_Guia, int tipo, int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATO_RECETA_FARMACIA_CRED", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Farmacia_Cab", Id_Guia));
            cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            List<RecetaFarmacia> pList = new List<RecetaFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    RecetaFarmacia g = new RecetaFarmacia();
                    g.Id_Farmacia_Cab = reader.GetInt32(0);
                    g.NroDocumento = reader.GetString(1);
                    g.nombres = reader.GetString(2);
                    g.Cod_Tipo_Cliente = reader.GetInt32(3);

                    g.Cod_Paciente = reader.GetInt32(4);
                    g.Cod_Institucion = reader.GetInt32(5);
                    g.Cod_Pepasico = reader.GetInt32(6);
                    g.Total = reader.GetDecimal(7);
                    g.medicamento = reader.GetString(8);
                    g.stock = reader.GetInt32(9);
                    g.PreCosto = reader.GetDecimal(10);
                    g.Cantidad = reader.GetInt32(11);
                    g.SubTotal = reader.GetDecimal(12);
                    g.FechaRegistro = reader.GetDateTime(13).ToString("dd/MM/yyyy");
                    g.Id_Producto = reader.GetInt32(14);
                    g.idEstado = reader.GetInt32(15);
                    pList.Add(g);

                }
            }

            cnx.Close();
            return pList;
        }

        public int updEstado(int Id_Guia, int estado,int idUsuario)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_UPD_ESTADO_RECETA_FARMACIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Farmacia_Cab", Id_Guia));
            cmd.Parameters.Add(new SqlParameter("@IdEstado", estado));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            int result = cmd.ExecuteNonQuery();
        
            return result;
        }


        public int insertarAnulacion(int Id, int flag, int idAnulacion, string detalle, int idUsuario, int TipoBusqueda)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_INS_ANULACION_RECETA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
         ///   cmd.Parameters.Add(new SqlParameter("@Id_Anulacion", idAnulacion));
            cmd.Parameters.Add(new SqlParameter("@MotivoAnulacion", detalle));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@Tipo", TipoBusqueda));
            
            int result = cmd.ExecuteNonQuery();

            return result;
        }



        public List<DatosCredito> setCredito(int Id_Guia, decimal Total, int idUsuario, int idEstado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_UPD_CREDITO_RECETA_FARMACIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Farmacia_Cab", Id_Guia));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@total", Total));
            cmd.Parameters.Add(new SqlParameter("@idEstado", idEstado));
            /*int result = cmd.ExecuteNonQuery();

            return result;*/

            IDataReader reader = cmd.ExecuteReader();

            List<DatosCredito> pList = new List<DatosCredito>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    DatosCredito g = new DatosCredito();
                    g.IdGuiaCab = reader.GetInt32(0);
                    g.IdCredito = reader.GetInt32(1);
                    //g.Fecha = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                  
                    pList.Add(g);

                }
            }

            cnx.Close();
            return pList;
        }

      


        public int setCreditoBot(int Id_Guia, decimal Total, int idUsuario, int idEstado, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_UPD_CREDITO_RECETA_FARMACIA", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Farmacia_Cab", Id_Guia));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@total", Total));
            cmd.Parameters.Add(new SqlParameter("@idEstado", idEstado));
            int result = cmd.ExecuteNonQuery();

            return result;
        } 

        public DatosPaciente getDatos(string CodPac)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_PACIENTE", cnx);
            cmd.Parameters.Add(new SqlParameter("@CodPac", CodPac));         
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            DatosPaciente g = new DatosPaciente();
            if (reader != null)
            {
                while (reader.Read())
                {
                
                    g.nombreCompleto = reader.GetString(0);
                    g.Convenio = reader.GetString(1);
                    g.CodInst = reader.GetInt32(2);
                    g.TitularNombre = reader.GetString(3);
                    g.TitularDni = reader.GetString(4);
                           
                   
                }
            }

            cnx.Close();
            return g;
        }

        public PacienteGuiaBE getDatosGuia(string CodPac,int Busq)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_GUIA_PACIENTE", cnx);
            cmd.Parameters.Add(new SqlParameter("@NroGuia", CodPac));
            cmd.Parameters.Add(new SqlParameter("@Busq", Busq));
            
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            PacienteGuiaBE g = new PacienteGuiaBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.tipoCliente = reader.GetInt32(0);
                    g.nombreCompleto = reader.GetString(1);
                    g.Convenio = reader.GetString(2);
                    g.CodInst = reader.GetInt32(3);
                    g.TitularNombre = reader.GetString(4);
                    g.TitularDni = reader.GetString(5);
                    g.CodPepasico = reader.GetInt32(6);
                    g.FechaGuia = reader.GetDateTime(7).ToString("dd/MM/yyyy");
                    g.nroHistoria = reader.GetInt32(8);
                    g.flagConvenio = reader.GetString(9);
                    
                }
            }

            cnx.Close();
            return g;

        }

        public PacienteGuiaBE getDatosGuiaSet(string CodPac)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_GUIA_PACIENTE_SET", cnx);
            cmd.Parameters.Add(new SqlParameter("@NroGuia", CodPac));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            PacienteGuiaBE g = new PacienteGuiaBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.tipoCliente = reader.GetInt32(0);
                    g.nombreCompleto = reader.GetString(1);
                    g.Convenio = reader.GetString(2);
                    g.CodInst = reader.GetInt32(3);
                    g.TitularNombre = reader.GetString(4);
                    g.TitularDni = reader.GetString(5);
                    g.CodPepasico = reader.GetInt32(6);
                    g.FechaGuia = reader.GetDateTime(7).ToString("dd/MM/yyyy");
                    g.nroHistoria = reader.GetInt32(8);

                }
            }

            cnx.Close();
            return g;

        }

        public PacienteGuiaBE getDatosGuiaCredito(string Guia)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_DATOS_GUIA_PACIENTE_CREDITO", cnx);
            cmd.Parameters.Add(new SqlParameter("@NroGuia", Guia));
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();

            PacienteGuiaBE g = new PacienteGuiaBE();
            if (reader != null)
            {
                while (reader.Read())
                {
                    g.tipoCliente = reader.GetInt32(0);
                    g.nombreCompleto = reader.GetString(1);
                    g.Convenio = reader.GetString(2);
                    g.CodInst = reader.GetInt32(3);
                    g.TitularNombre = reader.GetString(4);
                    g.TitularDni = reader.GetString(5);
                    g.CodPepasico = reader.GetInt32(6);
                    g.FechaGuia = reader.GetDateTime(7).ToString("dd/MM/yyyy");
                    g.nroHistoria = reader.GetInt32(8);

                }
            }

            cnx.Close();
            return g;

        }
        public List<ComboBE> getDatosPepasico(int CodInst)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_PEPASICOS", cnx);
            cmd.Parameters.Add(new SqlParameter("@CodInst", CodInst));         
            cmd.CommandType = CommandType.StoredProcedure;
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


        public int insertaDevolucion(GuiaCompraCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertDevCab(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Guia_Cab = id;
                            insertDevDet(det, trans, con);
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

        public int insertDevCab(GuiaCompraCab g, SqlTransaction trans, SqlConnection cnx)
        {


            SqlCommand cmd = new SqlCommand("USP_INS_DEV_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", g.Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Nro_Doc_Ref", g.Nro_Doc));
            cmd.Parameters.Add(new SqlParameter("@FechaDevolucion", Convert.ToDateTime(g.Fecha_Recepcion)));    
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", g.Id_Usuario));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }

        public int insertDevDet(GuiaCompraDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_DEV_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Devolucion_Cab", g.Id_Guia_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@StockPrevio", g.StockPrevio));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));

            int result = cmd.ExecuteNonQuery();
            return result;

        }

        public int insertaDevolucionArt(GuiaCompraCab a)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertDevCabArt(a, trans, con);
                        foreach (var det in a.detalle)
                        {
                            det.Id_Guia_Cab = id;
                            insertDevDetArt(det, trans, con);
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

        public int insertDevCabArt(GuiaCompraCab g, SqlTransaction trans, SqlConnection cnx)
        {


            SqlCommand cmd = new SqlCommand("USP_INS_DEV_ART_CAB", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", g.Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Nro_Doc_Ref", g.Nro_Doc));
            cmd.Parameters.Add(new SqlParameter("@FechaDevolucion", Convert.ToDateTime(g.Fecha_Recepcion)));
            cmd.Parameters.Add(new SqlParameter("@Total", g.Total));
            cmd.Parameters.Add(new SqlParameter("@IdUsuario", g.Id_Usuario));
            SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);
            cmd.ExecuteNonQuery();
            int result = (int)personId.Value;
            return result;
        }

        public int insertDevDetArt(GuiaCompraDet g, SqlTransaction trans, SqlConnection cnx)
        {

            SqlCommand cmd = new SqlCommand("USP_INS_DEV_ART_DET", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id_Devolucion_Cab", g.Id_Guia_Cab));
            cmd.Parameters.Add(new SqlParameter("@Id_Producto", g.Id_Producto));
            cmd.Parameters.Add(new SqlParameter("@StockPrevio", g.StockPrevio));
            cmd.Parameters.Add(new SqlParameter("@PreCosto", g.PreCosto));
            cmd.Parameters.Add(new SqlParameter("@Cantidad", g.Cantidad));
            cmd.Parameters.Add(new SqlParameter("@SubTotal", g.SubTotal));

            int result = cmd.ExecuteNonQuery();
            return result;

        }




        public int realizarReposicion()
        {
            var result = -1;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();

                SqlCommand cmd = new SqlCommand("USP_REPONER_STOCK", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public int getGuiaCredito(int nroGuia)
        {

            var result = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
                cnx.Open();
                SqlCommand cmd = new SqlCommand("USP_NRO_GUIA_CREDITO", cnx);
                cmd.Parameters.Add(new SqlParameter("@idGuia", nroGuia));
                cmd.CommandType = CommandType.StoredProcedure;
                result = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public int verificaAnulacionFarmacia(int idUsuario, int IdNroGuia, int tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();

            SqlCommand cmd = new SqlCommand("USP_VERIFICAR_ANULACION_FARMACIA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@IdNroGuia", IdNroGuia));
            cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
            SqlParameter id_cab = new SqlParameter("@flagAnul", SqlDbType.Int);
            id_cab.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(id_cab);
            cmd.ExecuteNonQuery();
            int result = (int)id_cab.Value;
            return result;
        }
    }
}
