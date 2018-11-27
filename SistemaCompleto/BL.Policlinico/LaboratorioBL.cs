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
    public class LaboratorioBL
    {

        LaboratorioDA g = new LaboratorioDA();

        public PacienteBE getGuiaLab(string numGuia)
        {
            return g.getGuiaLab(numGuia);
        }
        public PacienteBE getPacientexDNI(string dni)
        {
            return g.getPacientexDNI(dni);
        }
        public int updatePaciente(PacienteBE pac)
        {
            return g.updatePaciente(pac);
        }
        public List<LabProductoBE> getLabProductoList(string numGuia)
        {
            return g.getLabProductoList(numGuia);
        }

        public List<ConceptosBE> getLabConceptosList()
        {
            return g.getLabConceptosList();
        }

        public List<PacienteBE> getLabPagosList(string numHistoria, string fecha)
        {
            return g.getLabPagosList(numHistoria, fecha);
        }


        public DataTable getLabCuadernoList(string fechaInicio, string fechaFin, string estado)
        {
            return g.getLabCuadernoList(fechaInicio, fechaFin, estado);
        }

        public List<LabProductoBE> getAreaAnalisisList(string numGuia)
        {
            return g.getAreaAnalisisList(numGuia);
        }

        public List<LabAnalisisBE> getLabAnalisisList(string numGuia, string area)
        {
            return g.getLabAnalisisList(numGuia, area);
        }

        public List<LabAnalisisBE> getReferencial(string codana)
        {
            return g.getReferencial(codana);
        }
        public List<PacienteBE> getHistorial(string numDNI)
        {
            return g.getHistorial(numDNI);
        }
        public List<LabProductoBE> getProcedimientosAll()
        {
            return g.getProcedimientosAll();
        }
        public String getarealab_proc(String codpro)
        {
            return g.getarealab_proc(codpro);
        }
        public List<LabProductoBE> getAreaAnalisisAll()
        {
            return g.getAreaAnalisisAll();
        }
        public List<LabProductoBE> getAreaLabAll()
        {
            return g.getAreaLabAll();
        }
        public LabProductoBE getAnalisisMantenimiento(int idAnalisis)
        {
            return g.getAnalisisMantenimiento(idAnalisis);
        }
        public List<LabAnalisisBE> getRefAnalisisMantenimiento(int idAnalisis)
        {
            return g.getRefAnalisisMantenimiento(idAnalisis);
        }
        public List<PacienteBE> getArchivo(string fecha, string fechafinal)
        {
            return g.getArchivo(fecha, fechafinal);
        }
        public List<LabProductoBE> getAllAnalisis(string tipo, string busq)
        {
            return g.getAllAnalisis(tipo, busq);
        }
        public List<PacienteBE> llenarImpresion()
        {
            return g.llenarImpresion();
        }

        public int updateRecepcionDet(string id, string resultado)
        {
            return g.updateRecepcionDet(id, resultado);
        }
        public List<ReporteProduccionBE> getReporteProd(int mes, int anio)
        {
            return g.getReporteProd(mes, anio);
        }
        public int updateValorReferencial(LabAnalisisBE ana)
        {
            return g.updateValorReferencial(ana);
        }
        public int insertValorReferencial(LabAnalisisBE ana)
        {
            return g.insertValorReferencial(ana);
        }

        public int updMantenimientoAnalisis(LabProductoBE pro)
        {
            return g.updMantenimientoAnalisis(pro);
        }
        public string insMantenimientoAnalisis(LabProductoBE pro)
        {
            return g.insMantenimientoAnalisis(pro);
        }
        public int updGuiaCerrado(string numGuia, string estado)
        {
            return g.updGuiaCerrado(numGuia, estado);
        }
        // CITAS
        public PacienteBE getPacienteCitas(string codPac)
        {
            return g.getPacienteCitas(codPac);
        }
        public List<EspecialidadBE> getEspecialidades()
        {
            return g.getEspecialidades();
        }

        public DataTable getEspecialidades1()
        {
            return g.getEspecialidades1();
        }

        public CitaBE getPrecioCita(string codEsp)
        {
            return g.getPrecioCita(codEsp);
        }
        public List<CitaBE> getCitaMedico(string codEsp)
        {
            return g.getCitaMedico(codEsp);
        }

        public List<CitaBE> getAvanceCitas()
        {
            return g.getAvanceCitas();
        }
       
        public List<LabProductoBE> getProcedimientoxEspecialidad(string codesp)
        {
            return g.getProcedimientoxEspecialidad(codesp);
        }

        public string insertGuiaCompra(GuiaCajaCabBE a, GuiaCajaAportes d)
        {
            return g.insertGuiaCompra(a, d);
        }

        public string insertCitaCredito(GuiaCajaCabBE a, GuiaCajaAportes c)
        {
            return g.insertCitaCredito(a, c);
        }

        public List<ComboBE> getComboMedico()
        {
            return g.getComboMedico();
        }

        public List<ComboBE> getComboMedicoFarmacia()
        {
            return g.getComboMedicoFarmacia();
        }

        

        public CitaBE getMontoProc(string IdProc)
        {
            return g.getMontoProc(IdProc);
        }

        public int insertConceptos(ConceptosBE concepto)
        {

            return g.insertConceptos(concepto);
        }

        public DataTable getExamenes(string numguia)
        {
            return g.getExamenes(numguia);
        }

        public DataTable GetReporteCab(String numGuia)
        {

            return g.GetReporteCab(numGuia);
        }
        public DataTable GetReporteCuerpo(String numGuia)
        {

            return g.GetReporteCuerpo(numGuia);
        }

        public int insertRecepcion(String numGuia, int idUsuario, String observacion)
        {
            return g.insertRecepcion(numGuia, idUsuario, observacion);
        }

        public string getImpreso(String numGuia)
        {
            return g.getImpreso(numGuia);
        }
        public PacienteBE getRecepcionPaciente(string numGuia)
        {
            return g.getRecepcionPaciente(numGuia);
        }

        public int updImpresionLab(string numguia)
        {
            return g.updImpresionLab(numguia);
        }

        public int existeRecepcion(string numGuia)
        {
            return g.existeRecepcion(numGuia);
        }
        public int updateImpreso(string numGuia)
        {
            return g.updateImpreso(numGuia);
        }
        public string getObservacion(String numGuia)
        {
            return g.getObservacion(numGuia);
        }
        public int updateEstadoGuia(int numGuia, int idproc,string estado)
        {
            return g.updateEstadoGuia(numGuia, idproc, estado);
        }

        public string getVR(int id)
        {
            return g.getVR(id);
        }

        public int updateVRDetalle(int idDet, String VR)
        {
            return g.updateVRDetalle(idDet, VR);
        }
        public int updateVRMaestra(int idVR, String VR)
        {
            return g.updateVRMaestra(idVR, VR);
        }
        public string getUnidad(int id)
        {
            return g.getUnidad(id);
        }

        public int updateUnidadDetalle(int idDet, String unidad)
        {
            return g.updateUnidadDetalle(idDet, unidad);
        }
    }
}
