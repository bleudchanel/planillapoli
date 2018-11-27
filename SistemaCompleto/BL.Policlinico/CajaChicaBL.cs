using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Policlinico;
using Entity.CajaChica;
using System.Data;
using System.Data.SqlClient;
using Entity.Policlinico;

namespace BL.Policlinico
{
    public class CajaChicaBL
    {
      CajaChicaDA  g = new CajaChicaDA();
        public DataTable getComboConcepto()
        {
            return g.getComboConcepto();
        }

        public DataTable getComboSubConcepto1(String id)
        {
            return g.getComboSubConcepto1(id);
        }

        public DataTable getComboSubConcepto2(String id)
        {
            return g.getComboSubConcepto2(id);
        }

        public DataTable getComboAutorizado()
        {
            return g.getComboAutorizado();
        }

        public DataTable getComboASolicitado()
        {
            return g.getComboASolicitado();
        }
        
        public DataTable getComboProveedor()
        {
            return g.getComboProveedor();
        }

        public DataTable getObtenerID(int flag)
        {
            return g.getObtenerID(flag);
        }

        public DataTable getDataGvList(int flag) {
            return g.getDataGvList(flag);
        }

        public DataTable getDataGvListEliminar(String anio)
        {
            return g.getDataGvListEliminar(anio);
        }

        public DataTable getDataGvListReporteDet(String fInicial, String fFinal)
        {
            return g.getDataGvListReporteDet(fInicial,fFinal);
        }
        public DataTable getDataGvListReporteResumen(String fInicial, String fFinal,int tipoGasto)
        {
            return g.getDataGvListReporteResumen(fInicial, fFinal,tipoGasto);
        }        

        public int insertUpdConcepto(ConceptoBE concepto,int flag)
        {
            return g.insertUpdConcepto(concepto,flag);
        }

        public int insertUpdProveedor(ProveedorCCBE proveedor, int flag)
        {
            return g.insertUpdProveedor(proveedor, flag);
        }

        public int insertUpdSolicitante(SolicitanteBE solicitante, int flag)
        {
            return g.insertUpdSolicitante(solicitante, flag);
        }


        public int insertRegGastos(GastosBE gastos)
        {
            return g.insertRegGastos(gastos);
        }
        
        public int eliminarConcepto(String id) {
            return g.eliminarConcepto(id);
        }

        public int eliminarProveedor(String id)
        {
            return g.eliminarProveedor(id);
        }

        public int eliminarSolicitante(String id)
        {
            return g.eliminarSolicitante(id);
        }

        public int eliminarVales(String id)
        {
            return g.eliminarVales(id);
        }       

        public int insertUpdSubConcepto1(SubConcepto1BE subConcepto1,int flag)
        {
            return g.insertUpdSubConcepto1(subConcepto1,flag);
        }
        public int insertUpdSubConcepto2(SubConcepto2BE subConcepto2, int flag)
        {
            return g.insertUpdSubConcepto2(subConcepto2, flag);
        }
        
        public String getID() {
            return g.getID();
        }
        
        public int eliminarSub1(String id)
        {
            return g.eliminarSub1(id);
        }

        public int eliminarSub2(String id)
        {
            return g.eliminarSub2(id);
        }

        
    }
}
