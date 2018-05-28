using Core.Common.Contracts;
using Core.Common.Core;
using Core.Common.Utils;
using Planilla.Business.Common;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business
{
    [Export(typeof(IPlanillaEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlanillaEngine : IPlanillaEngine
    {
        public PlanillaEngine()
        {
            //ObjectBase.Container = MEFLoader.Init();
            //ObjectBase.Container.SatisfyImportsOnce(this);
        }

        [ImportingConstructor]
        public PlanillaEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _DataRepositoryFactory;


        public IEnumerable<PlanillaRemuneracion> GetPlanillaNormalPorPeriodo(int Anio, int Mes)
        {
            IPlanillaRemuneracionRepository planillaRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();
            IFondoPensionesRepository fondoPensionesRepository = _DataRepositoryFactory.GetDataRepository<IFondoPensionesRepository>();

            string Periodo = Anio.ToString() + Utiles.CerosIzquierda(Mes.ToString(),2);
            var planilla = planillaRepository.GetPlanillaPorPeriodo(Periodo);

            IEnumerable<VacacionesPersona> vacaciones = vacacionesRepository.GetVacacionesPorPeriodo(Anio);
            if (vacaciones == null || vacaciones.Count() == 0)
            {
                throw new InvalidOperationException("No se han registrado las vacaciones para este periodo. Imposible continuar con la operación.");
            }

            if (planilla != null && planilla.Count() > 0)
            {
                var personal = personalRepository.Get();
                var fondoPen = fondoPensionesRepository.Get();
                foreach(PlanillaRemuneracion registro in planilla)
                {
                    var persona = personal.Where(o => o.IdPersonal == registro.IdPersonal).FirstOrDefault();
                    var fondo = fondoPen.Where(o => o.IdFondoPen == registro.IdFondoPen).FirstOrDefault();
                    registro.NombrePersona = persona.ApePaterno + " " + persona.ApeMaterno + ", " + persona.Nombre;
                    registro.VacacionesPeriodo = vacacionesRepository.GetVacacionesPorPeriodoPersona(Anio, registro.IdPersonal ?? 0);
                    registro.ApellidoPaterno = persona.ApePaterno;
                    registro.ApellidoMaterno = persona.ApeMaterno;
                    registro.Nombre = persona.Nombre;
                    registro.CUSPP = persona.CUSPP;
                    registro.Dni = persona.DNI;
                    registro.AFP = fondo.Entidad;
                }
                //planilla = planilla.OrderBy(o => o.NombrePersona);
                return planilla;
            }

            IEnumerable<PlanillaRemuneracion> planillas = GenerarPlanilla(Periodo);
            if (planillas != null && planillas.Count() > 0)
            {
                foreach (PlanillaRemuneracion _planilla in planillas)
                {
                     planillaRepository.Add(_planilla);
                }

                return GetPlanillaNormalPorPeriodo(Anio, Mes);
            }

            return planilla;

        }


        public IEnumerable<PlanillaRemuneracion> GenerarPlanilla(string Periodo)
        {



            int Anio = Convert.ToInt32(Periodo.Substring(0, 4));
            int Mes = Convert.ToInt32(Periodo.Substring(4, 2));
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            IFondoPensionesRepository fondoRepository = _DataRepositoryFactory.GetDataRepository<IFondoPensionesRepository>();
            IAporteEmpleadorRepository aportesRepository = _DataRepositoryFactory.GetDataRepository<IAporteEmpleadorRepository>();
            IDiasLaborablesRepository diasRepository = _DataRepositoryFactory.GetDataRepository<IDiasLaborablesRepository>();
            IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();

           
            List<PlanillaRemuneracion> remuneracion = new List<PlanillaRemuneracion>();
            IEnumerable<Personal> personalActivo = personalRepository.GetPersonalActivo();
            foreach(Personal personal in personalActivo)
            {
                FondoPensiones fondoPensiones = fondoRepository.Get(personal.IdFondoPen ?? 0);
                AporteEmpleador aporteEmpleadorESSALUD = aportesRepository.Get(1);
                AporteEmpleador aporteEmpleadorSCTR = aportesRepository.Get(2);
                DiasLaborables diasLaborables = diasRepository.GetDiasPorPeriodo(Periodo);
                Vacaciones vacacionesInicio = vacacionesRepository.GetVacacionesInicioPeriodoPersona(personal.IdPersonal, Anio, Mes);
                Vacaciones vacacionesFin = vacacionesRepository.GetVacacionesFinPeriodoPersona(personal.IdPersonal, Anio, Mes);
                Vacaciones vacacionesPeriodo = vacacionesRepository.GetVacacionesPorPeriodoPersona(Anio, personal.IdPersonal);
                decimal porcentajeApoObl = ((personal.TipComAFP == "F") ? fondoPensiones.ApoOblF : fondoPensiones.ApoOblM) ?? 0;
                decimal porcentajeComVar = ((personal.TipComAFP == "F") ? fondoPensiones.ComVarF : fondoPensiones.ComVarM) ?? 0;
                decimal porcentajePriSeg = ((personal.TipComAFP == "F") ? fondoPensiones.PriSegF : fondoPensiones.PriSegM) ?? 0;
                //decimal TotalIngreso = personal.RemBas + personal.AsiFam + personal.RieCaj; //terminar
                //decimal MontoOnp = (personal.RemBas * fondoPensiones.PorONP) ?? 0;
                //decimal MontoAporteObl = (personal.RemBas * porcentajeApoObl) ?? 0;
                //decimal MontoComVar = (personal.RemBas * porcentajeComVar) ?? 0;
                //decimal MontoPriSeg = (personal.RemBas * porcentajePriSeg) ?? 0;
                //decimal totalDescuento = MontoOnp + MontoAporteObl + MontoComVar + MontoPriSeg;
                
                decimal porcentajeSCTR = ((personal.SCTR == "N") ? 0 : aporteEmpleadorSCTR.Porcentaje) ?? 0;
                decimal porcentajeESSALUD = (aporteEmpleadorESSALUD.Porcentaje) ?? 0;
                decimal montoESSALUD = (personal.RemBas * aporteEmpleadorESSALUD.Porcentaje) ?? 0;
                decimal montoSCTR = (personal.RemBas * porcentajeSCTR) ?? 0;
               // decimal totalAporte = montoESSALUD + montoSCTR;

                PlanillaRemuneracion planillaPersona = new PlanillaRemuneracion(0, Periodo, personal.IdPersonal, personal.CodPer, personal.IdCargo ?? null,
                    personal.CodCar, personal.IdFondoPen ?? null, personal.CodFon, personal.TipComAFP, personal.RemBas, personal.AsiFam, 0, 0, 0, personal.RieCaj,
                    0, 0, 0, fondoPensiones.PorONP, porcentajeApoObl, porcentajePriSeg, porcentajeComVar, 0 
                    , 0, aporteEmpleadorESSALUD.Porcentaje, porcentajeSCTR, diasLaborables.DiasLab, personal.HorLab, null, null, null, null, null, null, null, null, null, "F", "N");
                planillaPersona.VacacionesPeriodo = vacacionesPeriodo;
                remuneracion.Add(planillaPersona);


            }

            return remuneracion;
        }
    }
}
