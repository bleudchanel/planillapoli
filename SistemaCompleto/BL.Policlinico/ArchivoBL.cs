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
    public class ArchivoBL
    {
        ArchivoDA g = new ArchivoDA();
        public List<CitasDia> getCitasDia(string m)
        {
            return g.getCitasDia(m);
        }

        /*public List<CitasDia> getCitasMedico(string idMedico,string Fecha)
        {
            return g.getCitasMedico( idMedico,  Fecha);
        }*/

        public DataTable getCitasMedico(string idMedico, string Fecha)
        {
            return g.getCitasMedico(idMedico, Fecha);
        }

        public DataTable getCitasPaciente(string m, string CodPac)
        {
            return g.getCitasPaciente(m, CodPac);
        }


        public List<CitasDia> getImpresion()
        {
            return g.getImpresion();
        }

        public DataTable getRecepcionRes1(string m, string FechaFin, int tipo)
        {
            return g.getRecepcionRes1(m,FechaFin,tipo);
        }

        public DataTable getRecepcionRes(string m, string FechaFin, int tipo)
        {
            return g.getRecepcionRes(m, FechaFin, tipo);
        }
        public int insResultadoLab(string nroGuia)
        {
            return g.insResultadoLab(nroGuia);
        }

        public int insMovHistorias(string CodPac, string estado, string fecha)
        {
            return g.insMovHistorias( CodPac,  estado,  fecha);
        }

        public int imprimirHistorias()
        {
            return g.imprimirHistorias();
        }

        public DataTable getCitasCuaderno(string m, string estado)
        {
            return g.getCitasCuaderno(m, estado);
        }

        public DataTable getReportes(string fechaInicio, string fechaFin, string estado)
        {
            return g.getReportes(fechaInicio,  fechaFin, estado);
        }

        public DataTable getHistoriasPrestamos(string fechaInicio, string fechaFin, string estado)
        {
            return g.getHistoriasPrestamos(fechaInicio, fechaFin, estado);
        }

        public int insMovHistoriasPrestamo(string CodPac,string idEspecialidad, string estado, string fecha)
        {
            return g.insMovHistoriasPrestamo(CodPac, idEspecialidad,estado, fecha);
        }

    }
}
