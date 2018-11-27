using Entity.CajaChica;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Policlinico
{
    public class CajaChicaDA
    {
        public DataTable getComboConcepto() {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBO_CONCEPTO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;           
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }

        public DataTable getComboSubConcepto1(String id)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBO_SUBCONCEPTO1", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id",Convert.ToInt32(id)));
            /*List<ComboBE> pList = new List<ComboBE>();*/
            /*if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                   // g.Id = reader.GetString(0);
                    g.Descripcion = reader.GetString(0) +"-" +reader.GetString(1);

                    pList.Add(g);
                }
            }*/
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }

        public DataTable getComboSubConcepto2(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBO_SUBCONCEPTO2", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();
            return dt;
        }

        public DataTable getComboAutorizado()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBO_AUTORIZADO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();
            return dt;
        }

        public DataTable getComboASolicitado()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBO_SOLICITADO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();
            return dt;
        }
        public DataTable getComboProveedor()
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBO_PROVEEDOR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();
            return dt;
        }
        
        public DataTable getObtenerID(int flag)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_OBTENER_ID", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            /* IDataReader reader = cmd.ExecuteReader();*/
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            /*List<ComboBE> pList = new List<ComboBE>();*/
            /*if (reader != null)
            {
                while (reader.Read())
                {
                    ComboBE g = new ComboBE();
                   // g.Id = reader.GetString(0);
                    g.Descripcion = reader.GetString(0) +"-" +reader.GetString(1);

                    pList.Add(g);
                }
            }*/
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }
        
        public DataTable getDataGvList(int flag) {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_GRID_VIEW", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            /* IDataReader reader = cmd.ExecuteReader();*/
            cmd.Parameters.Add(new SqlParameter("@flag", flag));            
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }

        public DataTable getDataGvListEliminar(String anio)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_GRID_VIEW_ELIMINACION_VALES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            /* IDataReader reader = cmd.ExecuteReader();*/
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }

        public DataTable getDataGvListReporteDet(String fInicial, String fFinal)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_GRID_VIEW_REPORTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fInicial", fInicial));
            cmd.Parameters.Add(new SqlParameter("@fFinal", fFinal));
            /* IDataReader reader = cmd.ExecuteReader();*/
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }

        public DataTable getDataGvListReporteResumen(String fInicial, String fFinal,int tipoGasto)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_GRID_VIEW_REPORTE_RES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fInicial", fInicial));
            cmd.Parameters.Add(new SqlParameter("@fFinal", fFinal));
            cmd.Parameters.Add(new SqlParameter("@tipoGasto", tipoGasto));
            /* IDataReader reader = cmd.ExecuteReader();*/
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            var dt = ds.Tables[0];
            cnx.Close();

            return dt;
        }
        
        public int insertUpdConcepto(ConceptoBE concepto,int flag) {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_CONCEPTO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag",flag));
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(concepto.idCon)));
            cmd.Parameters.Add(new SqlParameter("@Concepto", concepto.Concepto));
            cmd.Parameters.Add(new SqlParameter("@estado", concepto.estado));
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int insertUpdProveedor(ProveedorCCBE proveedor, int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_PROVEEDOR_CC", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idProv", proveedor.idProv));
            cmd.Parameters.Add(new SqlParameter("@NRS", proveedor.NRS));
            cmd.Parameters.Add(new SqlParameter("@estado", proveedor.Estado));
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int insertUpdSolicitante(SolicitanteBE solicitante, int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_SOLICITANTES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idSol", solicitante.idSol));
            cmd.Parameters.Add(new SqlParameter("@solicitante", solicitante.Solicitante));
            cmd.Parameters.Add(new SqlParameter("@estado", solicitante.Estado));
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int insertRegGastos(GastosBE gastos)
        {
            int val = 0;
            using (SqlConnection con = new SqlConnection(ConexionDA.getConexion()))
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        var id = insertRegGastos(gastos, trans, con);
                        
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

            /*SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_REG_GASTOS", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;*/

        }
        public int insertRegGastos(GastosBE g, SqlTransaction trans, SqlConnection cnx)
        {



            SqlCommand cmd = new SqlCommand("USP_INS_REG_GASTOS", cnx, trans);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@numValEgr", g.numValEgr));
            cmd.Parameters.Add(new SqlParameter("@codAut", g.codAut));
            cmd.Parameters.Add(new SqlParameter("@idSol", g.idSol));
            cmd.Parameters.Add(new SqlParameter("@tipDoc", g.tipDoc));
            cmd.Parameters.Add(new SqlParameter("@numDoc", g.numDoc));
            cmd.Parameters.Add(new SqlParameter("@idProv", g.idProv));
            cmd.Parameters.Add(new SqlParameter("@fecha", g.fecha));
            cmd.Parameters.Add(new SqlParameter("@idCon", g.idCon));
            cmd.Parameters.Add(new SqlParameter("@idSub1", g.idSub1));
            cmd.Parameters.Add(new SqlParameter("@idSub2", g.idSub2));
            cmd.Parameters.Add(new SqlParameter("@detalle", g.detalle));
            cmd.Parameters.Add(new SqlParameter("@monto", Convert.ToDecimal(g.monto)));

            cmd.Parameters.Add(new SqlParameter("@codUsu", g.codUsu));
            cmd.Parameters.Add(new SqlParameter("@anulado", g.anulado));
            cmd.Parameters.Add(new SqlParameter("@motivoAnulacion", g.motivoAnulacion));

            /*SqlParameter personId = new SqlParameter("@Id", SqlDbType.Int);
            personId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(personId);*/
            int result = cmd.ExecuteNonQuery();
            // int result = (int)personId.Value;
            return result;
        }



        public int eliminarConcepto(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_CONCEPTO", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idCon", Convert.ToInt32(id)));

            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int eliminarVales(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_VALES", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@NumValEgr", id));

            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }        

        public int insertUpdSubConcepto1(SubConcepto1BE subConcepto1,int flag)
        {
           SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_SUBCONCEPTO1", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idSub1", subConcepto1.idSub1));
            cmd.Parameters.Add(new SqlParameter("@SubConcepto1", subConcepto1.subConcepto1));
            cmd.Parameters.Add(new SqlParameter("@idCon", subConcepto1.idCon));
            cmd.Parameters.Add(new SqlParameter("@estado", subConcepto1.estado));
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int insertUpdSubConcepto2(SubConcepto2BE subConcepto2, int flag)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_INS_UPD_SUBCONCEPTO2", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            cmd.Parameters.Add(new SqlParameter("@idSub1", subConcepto2.idSub1));
            cmd.Parameters.Add(new SqlParameter("@idSub2", subConcepto2.idSub2));
            cmd.Parameters.Add(new SqlParameter("@SubConcepto2", subConcepto2.subConcepto2));
            cmd.Parameters.Add(new SqlParameter("@idCon", subConcepto2.idCon));
            cmd.Parameters.Add(new SqlParameter("@estado", subConcepto2.estado));
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }
        
        public int eliminarSub1(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_SUBCONCEPTO1", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@idSub1", id));
            
            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public String getID() {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("SP_OBTENER_ID", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            int j = 0;
            IDataReader reader = cmd.ExecuteReader(); 
            if (reader != null)
            {
                while (reader.Read())
                {
                    j = Convert.ToInt32(reader.GetString(0));
                    

                }
            }


            cnx.Close();
            return Convert.ToString(j);
        }
        public int eliminarSub2(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_SUBCONCEPTO2", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idSub2", id));

            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int eliminarProveedor(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_PROVEEDOR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idProv", id));

            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }

        public int eliminarSolicitante(String id)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_DELETE_SOLICITANTE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idSol", id));

            int result = cmd.ExecuteNonQuery();
            cnx.Close();
            return result;

        }


    }
    
}
