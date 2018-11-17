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
    public class ReportesDA
    {
        public List<ReportesComprasFarmacia> repCompraFarmacia(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo,int estado)
        {
           
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_COMPRAS_FARMACIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio",DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesComprasFarmacia> lista = new List<ReportesComprasFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesComprasFarmacia g = new ReportesComprasFarmacia();
                    g.Id_Guia_Cab = reader.GetInt32(0);
                    g.Razon_Social = reader.GetString(1);
                    g.Descripcion = reader.GetString(2);
                    g.Nro_Doc = reader.GetString(3);
                    g.IdM = reader.GetInt32(4);
                    
                    g.Medicamento = reader.GetString(5);
                    g.PreCosto = reader.GetDecimal(6);
                    g.Cantidad = reader.GetInt32(7);
                    g.SubTotal = reader.GetDecimal(8);
                    g.FechaVencimiento = reader.GetDateTime(9).ToShortDateString();
                    g.Lote = reader.GetString(10);
                    g.FechaRecepcion = reader.GetDateTime(11).ToShortDateString();
                    g.Tipo = reader.GetString(12);
                    g.idEstado = reader.GetInt32(13);
                    lista.Add(g);
                }
            }
      

            cnx.Close();
            return lista;
        }

        public List<ReportesComprasFarmacia> repCompraAlmacen(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo,int estado)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_COMPRAS_ALMACEN", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesComprasFarmacia> lista = new List<ReportesComprasFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesComprasFarmacia g = new ReportesComprasFarmacia();
                    g.Id_Guia_Cab = reader.GetInt32(0);
                    g.Razon_Social = reader.GetString(1);
                    g.Descripcion = reader.GetString(2);
                    g.Nro_Doc = reader.GetString(3);
                    g.IdM = reader.GetInt32(4);

                    g.Medicamento = reader.GetString(5);
                    g.PreCosto = reader.GetDecimal(6);
                    g.Cantidad = reader.GetInt32(7);
                    g.SubTotal = reader.GetDecimal(8);
                    g.FechaVencimiento = reader.GetDateTime(9).ToShortDateString();
                    g.Lote = reader.GetString(10);
                    g.FechaRecepcion = reader.GetDateTime(11).ToShortDateString();
                    g.Tipo = reader.GetString(12);
                    g.idEstado = reader.GetInt32(13);
                    lista.Add(g);
                }
            }


            cnx.Close();
            return lista;
        }

        public List<ReportesTransfFarmacia> repTransFarmacia(int Id_Destino, int Id_Medicina, int Id_Tipo, string Fecha_Inicio, string Fecha_Fin, int Guia,int estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_TRANSF_FARMACIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Destino", Id_Destino));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio",DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesTransfFarmacia> lista = new List<ReportesTransfFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesTransfFarmacia g = new ReportesTransfFarmacia();
                    g.Id_Transf_Cab = reader.GetInt32(0);
                    g.Destino = reader.GetString(1);
                 
                    g.IdM = reader.GetInt32(2);

                    g.Medicina = reader.GetString(3);
                    g.PreCosto = reader.GetDecimal(4);
                    g.Cantidad = reader.GetInt32(5);
                    g.SubTotal = reader.GetDecimal(6);
                    g.Fecha_Transf = reader.GetDateTime(7).ToShortDateString();
                 
                    g.Tipo = reader.GetString(8);
                 
                    lista.Add(g);
                }
           
            }
      

            cnx.Close();
            return lista;
        }


        public List<ReportesTransfFarmacia> repTransAlmacen(int Id_Destino, int Id_Medicina, int Id_Tipo, string Fecha_Inicio, string Fecha_Fin, int Guia,int estado)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_TRANSF_ALMACEN", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Destino", Id_Destino));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.Parameters.Add(new SqlParameter("@estado", estado));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesTransfFarmacia> lista = new List<ReportesTransfFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesTransfFarmacia g = new ReportesTransfFarmacia();
                    g.Id_Transf_Cab = reader.GetInt32(0);
                    g.Destino = reader.GetString(1);

                    g.IdM = reader.GetInt32(2);

                    g.Medicina = reader.GetString(3);
                    g.PreCosto = reader.GetDecimal(4);
                    g.Cantidad = reader.GetInt32(5);
                    g.SubTotal = reader.GetDecimal(6);
                    g.Fecha_Transf = reader.GetDateTime(7).ToShortDateString();

                    g.Tipo = reader.GetString(8);

                    lista.Add(g);
                }

            }


            cnx.Close();
            return lista;
        }

        public List<ReportesComprasFarmacia> repCompraGeneralFarmacia(int Id_Proveedor, string Fecha_Inicio, string Fecha_Fin, int Guia, int flag)
        {

            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REP_GENERAL_COMPRAS", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.Parameters.Add(new SqlParameter("@flag", flag));
            
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesComprasFarmacia> lista = new List<ReportesComprasFarmacia>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesComprasFarmacia g = new ReportesComprasFarmacia();
                    g.Id_Guia_Cab = reader.GetInt32(0);
                    g.FechaRecepcion = reader.GetDateTime(1).ToShortDateString();
                    g.Razon_Social = reader.GetString(2);                  
                    g.Nro_Doc = reader.GetString(3);                  
                    g.SubTotal = reader.GetDecimal(4);          
                    g.Tipo = reader.GetString(5);                
                    lista.Add(g);
                }
            }


            cnx.Close();
            return lista;
        }



        public List<ReportesBotiquines> repVentaBotiquines(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
        {
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_VENTAS_BOTIQUIN", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesBotiquines> lista = new List<ReportesBotiquines>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesBotiquines g = new ReportesBotiquines();
                    g.Id_Farmacia_Cab = reader.GetInt32(0);
                    g.IdM = reader.GetInt32(1);
                    g.Medicina = reader.GetString(2);
                   
                    g.PreCosto = reader.GetDecimal(3);
                    g.Cantidad = reader.GetInt32(4);
                    g.SubTotal = reader.GetDecimal(5);
                    g.FechaRegistro = reader.GetDateTime(6).ToShortDateString();
                    g.Deuda = reader.GetDecimal(7);
                    g.Estado = reader.GetString(8);
                    g.Tipo = reader.GetString(9);
                   
                    lista.Add(g);
                }
            }
        

            cnx.Close();
            return lista;
        }

        public List<ReporteDevoluciones> repDevoluciones(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia)
        {


            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_DEVOLUCIONES", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
          
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReporteDevoluciones> lista = new List<ReporteDevoluciones>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReporteDevoluciones g = new ReporteDevoluciones();
                    g.Id_Devolucion_Cab = reader.GetInt32(0);
                    g.Razon_Social = reader.GetString(1);                    
                    g.IdM = reader.GetInt32(2);
                    g.Medicina = reader.GetString(3);
                    g.PreCosto = reader.GetDecimal(4);
                    g.Cantidad = reader.GetInt32(5);
                    g.SubTotal = reader.GetDecimal(6);
             
                   
                    lista.Add(g);
                }
            }


            cnx.Close();
            return lista;
        }

        public List<ReporteMedControlados> repMedControlados(int Tipo, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia)
        {


            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_FARMACIA_CONTROLADOS", cnx);
            cmd.Parameters.Add(new SqlParameter("@Tipo", Tipo));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
          
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReporteMedControlados> lista = new List<ReporteMedControlados>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReporteMedControlados g = new ReporteMedControlados();
                    g.Id_Farmacia_Cab = reader.GetInt32(0);
                    g.Medicina = reader.GetString(1);
                    g.Cantidad = reader.GetInt32(2);
                    g.Cod_Paciente = reader.GetString(3);
                    g.DNI = reader.GetString(4);
                    g.xApePatMatNom = reader.GetString(5);
                    g.Doctor = reader.GetString(6);
                  
             
                   
                    lista.Add(g);
                }
            }

            cnx.Close();
            return lista;
        }

        public DataTable repRegistrosFarmacia(int idEstado, int idUsuario, string fecha)
        {

            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REGISTROS_FARMACIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@idEstado", idEstado));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@fecha",Convert.ToDateTime(fecha)));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }

        public DataTable repRegistrosCaja(int idEstado, int idUsuario, string fecha)
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_GET_REGISTROS_CAJA", cnx);
            cmd.Parameters.Add(new SqlParameter("@idEstado", idEstado));
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            cmd.Parameters.Add(new SqlParameter("@fecha", Convert.ToDateTime(fecha)));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }





        public List<ReportesVentasMedicamentos> repVentaMedicamentos(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
        {


            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_VENTA_MED", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesVentasMedicamentos> lista = new List<ReportesVentasMedicamentos>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesVentasMedicamentos g = new ReportesVentasMedicamentos();
                    g.Id_Guia_Cab = reader.GetInt32(0);
                    g.IdM = reader.GetInt32(1);
                    g.Medicamento = reader.GetString(2);
                    g.PreVenta = reader.GetDecimal(3);
                    g.Cantidad = reader.GetInt32(4);
                  
                   
                   
                    g.FechaRegistro = reader.GetDateTime(5).ToShortDateString();
                    g.Estado = reader.GetString(6);
                    g.Deuda = reader.GetDecimal(7);
                    g.SubTotal = reader.GetDecimal(8);
                    lista.Add(g);
                }
            }
           
            cnx.Close();
            return lista;
        }

        public DataTable repMedicamentosValorizados(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
        {

            DataTable dt=new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_MED_VAL", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;

            /* IDataReader reader = cmd.ExecuteReader();

             List<ReportesMedicamentosValorizado> lista = new List<ReportesMedicamentosValorizado>();
             if (reader != null)
             {
                 while (reader.Read())
                 {
                     ReportesMedicamentosValorizado g = new ReportesMedicamentosValorizado();
                     g.IdM = reader.GetInt32(0);
                     g.Medicamento = reader.GetString(1);
                     g.Cantidad = reader.GetInt32(2).ToString();
                     g.PreCostoProm = reader.GetDecimal(3).ToString();
                     g.PreVentaProm = reader.GetDecimal(4).ToString();
                     g.SubTotalCosto = reader.GetDecimal(5).ToString();
                     g.SubTotalVenta = reader.GetDecimal(6).ToString();
                     g.AportePoliclinico = reader.GetDecimal(7).ToString();
                     lista.Add(g);
                 }
             }


             cnx.Close();
             return lista; */
        }

        public List<ReportesGuiasAnuladas> repGuiasAnuladas(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
        {


            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_GUIAS_VENTAS_ANULADAS", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesGuiasAnuladas> lista = new List<ReportesGuiasAnuladas>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesGuiasAnuladas g = new ReportesGuiasAnuladas();
                    g.Id_Farmacia_Cab = reader.GetInt32(0);
                    g.IdM = reader.GetInt32(1);
                    g.Medicamento = reader.GetString(2);
                    g.PreVenta = reader.GetDecimal(3);
                    g.SubTotal = reader.GetDecimal(4);
                    g.Cantidad = reader.GetInt32(5);
                    g.FechaRegistro = reader.GetDateTime(6).ToShortDateString();
                    g.DetAnulacion = reader.GetString(7);
                    lista.Add(g);
                }
            }
             
            cnx.Close();
            return lista;
        }

        public List<ReportesResumenCompras> repResumenCompras(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
        {


            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_RESUMEN_COMPRAS_FARMACIA", cnx);
            cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Id_Proveedor));
            cmd.Parameters.Add(new SqlParameter("@Id_Medicina", Id_Medicina));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo", Id_Tipo));
            cmd.Parameters.Add(new SqlParameter("@Guia", Guia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Inicio", DateTime.Parse(Fecha_Inicio)));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Fin", DateTime.Parse(Fecha_Fin)));
            cmd.CommandType = CommandType.StoredProcedure;

            IDataReader reader = cmd.ExecuteReader();

            List<ReportesResumenCompras> lista = new List<ReportesResumenCompras>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    ReportesResumenCompras g = new ReportesResumenCompras();
                    g.Id_Guia_Cab = reader.GetInt32(0);
                    g.Razon_Social = reader.GetString(1);
                    g.Total = reader.GetDecimal(2);
                    g.Doc = reader.GetString(3);
                    g.Tipo = reader.GetString(4);
                    g.FechaRecepcion = reader.GetDateTime(5).ToShortDateString();
                
                    lista.Add(g);
                }
            }

            cnx.Close();
            return lista;
        }

        public DataTable getReporteStockFinal()
        {
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(ConexionDA.getConexion());
            cnx.Open();
            SqlCommand cmd = new SqlCommand("USP_REPORTE_STOCK_FINAL", cnx);
          
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cnx.Close();
            return dt;
        }

        
    }
}
