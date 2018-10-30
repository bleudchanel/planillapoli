using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Policlinico
{
  public  class ReportesBL
    {

      ReportesDA gl = new ReportesDA();
      public List<ReportesComprasFarmacia> repCompraFarmacia(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo,int estado)
      {

          return gl.repCompraFarmacia(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo, estado);
      }

      

      public List<ReportesComprasFarmacia> repCompraAlmacen(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo,int estado)
      {

          return gl.repCompraAlmacen(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo, estado);
      }
      
      public List<ReportesTransfFarmacia> repTransFarmacia(int Id_Destino, int Id_Medicina, int Id_Tipo, string Fecha_Inicio, string Fecha_Fin, int Guia,int estado)
      {
      
          return gl.repTransFarmacia( Id_Destino,  Id_Medicina,  Id_Tipo,  Fecha_Inicio,  Fecha_Fin,  Guia, estado);
      }

      public List<ReportesTransfFarmacia> repTransAlmacen(int Id_Destino, int Id_Medicina, int Id_Tipo, string Fecha_Inicio, string Fecha_Fin, int Guia,int estado)
      {

          return gl.repTransAlmacen(Id_Destino, Id_Medicina, Id_Tipo, Fecha_Inicio, Fecha_Fin, Guia, estado);
      }


      public List<ReportesComprasFarmacia> repCompraGeneralFarmacia(int idProveedor, string FechaInicio, string FechaFin, int Guia, int flag)
      {
          return gl.repCompraGeneralFarmacia(idProveedor, FechaInicio, FechaFin, Guia,flag);
      }

      public List<ReportesBotiquines> repVentaBotiquines(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
      {
          return gl.repVentaBotiquines(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo);
      }


      public List<ReporteMedControlados> repMedControlados(int Tipo, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia)
      {
          return gl.repMedControlados(Tipo, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia);
      }

      public List<ReporteDevoluciones> repDevoluciones(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia)
      {
          return gl.repDevoluciones(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia);
      }

      public DataTable repRegistrosFarmacia(int idEstado, int idUsuario,string fecha )
      {
          return gl.repRegistrosFarmacia(idEstado, idUsuario,fecha);
      }

      public DataTable repRegistrosCaja(int idEstado, int idUsuario, string fecha)
      {
          return gl.repRegistrosCaja(idEstado, idUsuario,fecha);
      }

      public List<ReportesVentasMedicamentos> repVentaMedicamentos(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
      {

          return gl.repVentaMedicamentos(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo);
      }

      public DataTable repMedicamentosValorizados(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
      {

          return gl.repMedicamentosValorizados(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo);
      }

      public List<ReportesGuiasAnuladas> repGuiasAnuladas(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
      {

          return gl.repGuiasAnuladas(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo);

      }

      public List<ReportesResumenCompras> repResumenCompras(int Id_Proveedor, int Id_Medicina, string Fecha_Inicio, string Fecha_Fin, int Guia, int Id_Tipo)
      {

          return gl.repResumenCompras(Id_Proveedor, Id_Medicina, Fecha_Inicio, Fecha_Fin, Guia, Id_Tipo);
      }

        public DataTable getReporteStockFinal()
        {

            return gl.getReporteStockFinal();
        }
        

    }
}
