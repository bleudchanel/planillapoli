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
    public class GerenciaBL
    {
        GerenciaDA g = new GerenciaDA();

        public List<ComboBE> getMedicos(int tipo)
        {
            return g.getMedicos(tipo);
        }
        public DataTable getIngresosDiarios(int mes, int anio)
        {
            return g.getIngresosDiarios(mes, anio);
        }

        public DataTable repPagoMedicoRes(string fechaInicio, string fechaFin)
        {
            return g.repPagoMedicoRes(fechaInicio, fechaFin);
        }
        public DataTable repPagoMedicoDet(string fechaInicio, string fechaFin, int idDoctor)
        {
            return g.repPagoMedicoDet(fechaInicio, fechaFin, idDoctor);
        }
        public DataTable repPagoOdontoRes(string fechaInicio, string fechaFin)
        {
            return g.repPagoOdontoRes(fechaInicio, fechaFin);
        }
        public DataTable repPagoOdontoDet(string fechaInicio, string fechaFin, int idDoctor)
        {
            return g.repPagoOdontoDet(fechaInicio, fechaFin, idDoctor);
        }

        public DataTable getIngresosPagoMedico(string fechaInicio, string fechaFin)
        {
            return g.getIngresosPagoMedico(fechaInicio, fechaFin);
        }
        public DataTable getIngresosPagoOdonto(string fechaInicio, string fechaFin)
        {
            return g.getIngresosPagoOdonto(fechaInicio, fechaFin);
        }
        
        public DataTable getIngresosDiariosFarm(int mes, int anio)
        {
            return g.getIngresosDiariosFarm(mes, anio);
        }

        public DataTable getReporteEspMed(string fechaInicio, string fechaFin)
        {
            return g.getReporteEspMed(fechaInicio, fechaFin);
        }

        public DataTable getReporteRecetasFarm(string fechaInicio, string fechaFin)
        {
            return g.getReporteRecetasFarm(fechaInicio, fechaFin);
        }
        public DataTable getReporteServGenercIndic(string fechaInicio, string fechaFin)
        {
            return g.getReporteServGenercIndic(fechaInicio, fechaFin);
        }

        public DataTable getReporteStockVal(int IdRef)
        {
            return g.getReporteStockVal(IdRef);
        }
        public DataTable getRepProdEspProced(int mes, int anio)
        {
            return g.getRepProdEspProced(mes,  anio);
        }

        public DataTable getRepProdEsp(int mes, int anio)
        {
            return g.getRepProdEsp(mes, anio);
        }

        public DataTable getRepProdEspProcedAnual(int idEsp, int anio)
        {
            return g.getRepProdEspProcedAnual(idEsp, anio);
        }

        public DataTable getRepAtencEspProced(int mes, int anio)
        {
            return g.getRepAtencEspProced(mes, anio);
        }

        public DataTable getRepAtencEsp(int mes, int anio)
        {
            return g.getRepAtencEsp(mes, anio);
        }

        public DataTable getRepAtencEspProcedAnual(int idEsp, int anio)
        {
            return g.getRepAtencEspProcedAnual(idEsp, anio);
        }

        public DataTable getRepAtencPacMensual(int mes, int anio)
        {
            return g.getRepAtencPacMensual(mes, anio);
        }

        public DataTable getRepGuiasEmit(int mes, int anio)
        {
            return g.getRepGuiasEmit(mes, anio);
        }

        public DataTable getRepDiarioCajaEfect(string fecha)
        {
            return g.getRepDiarioCajaEfect(fecha);
        }
        public DataTable getRepDiarioFarmEfect(string fecha)
        {
            return g.getRepDiarioFarmEfect(fecha);
        }

        public DataTable getGuiaAnulCajaServ(string fechaInicio, string fechaFin)
        {
            return g.getGuiaAnulCajaServ(fechaInicio, fechaFin);
        }

        public DataTable getGuiaAnulCajaFarm(string fechaInicio, string fechaFin)
        {
            return g.getGuiaAnulCajaFarm(fechaInicio, fechaFin);
        }

        public DataTable getGuiaAnulMedServ(string fechaInicio, string fechaFin)
        {
            return g.getGuiaAnulMedServ(fechaInicio, fechaFin);
        }

        public DataTable getGuiaAnulMedFarm(string fechaInicio, string fechaFin)
        {
            return g.getGuiaAnulMedFarm(fechaInicio, fechaFin);
        }
        public DataTable getGuiaAnulMotServ(string fechaInicio, string fechaFin)
        {
            return g.getGuiaAnulMotServ(fechaInicio, fechaFin);
        }

        public DataTable getGuiaAnulMotFarm(string fechaInicio, string fechaFin)
        {
            return g.getGuiaAnulMotFarm(fechaInicio, fechaFin);
        }

        public DataTable repPagoMedicoBol(string fechaInicio, string fechaFin, int idDoctor)
        {
            return g.repPagoMedicoBol(fechaInicio, fechaFin, idDoctor);
        }

        public DataTable repPagoOdontoBol(string fechaInicio, string fechaFin, int idDoctor)
        {
            return g.repPagoOdontoBol(fechaInicio, fechaFin, idDoctor);
        }
    }
}
