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


        public IEnumerable<PlanillaCTS> GenerarPlanillaCTS(int Anio, int Mes)
        {
            IPlanillaRemuneracionRepository planillaRemuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            string Periodo = Anio.ToString() + Utiles.CerosIzquierda((Mes - 1).ToString(), 2);
            List<PlanillaCTS> resultado = new List<PlanillaCTS>();

            var planillasPeriodo = planillaRemuneracionRepository.PlanillasEnPeriodoPorCTS(Mes, Anio);
            IEnumerable<Personal> personalActivo = personalRepository.GetPersonalActivo();
            foreach(Personal personal in personalActivo)
            {
                var planillas = planillasPeriodo.Where(o => o.IdPersonal == personal.IdPersonal && o.TipoPlan == "N");
                var planillaGrati = planillasPeriodo.Where(o => o.IdPersonal == personal.IdPersonal && o.TipoPlan == "G");
                var UltimoIngresoValido = planillasPeriodo.Where(o => o.IdPersonal == personal.IdPersonal && o.TipoPlan == "N" && o.Periodo == Periodo).FirstOrDefault();
                decimal UltimoSueldo = UltimoIngresoValido != null ? UltimoIngresoValido.TotIng ?? 0 : 0; // UltimoIngresoValido.TotIng ?? 0;
                int nroPlanillas = planillas != null ? planillas.Count() : 0;
                int nroGratis = planillaGrati != null ? planillaGrati.Count() : 0;
                decimal TotalIngresos = planillas.Sum(o => o.TotIng ?? 0);
                decimal TotalGrati = planillaGrati.Sum(o => o.Gratif ?? 0);
                decimal SextoGrati = Math.Round(TotalGrati / 6,2,MidpointRounding.AwayFromZero);

                resultado.Add(new PlanillaCTS(personal.IdPersonal, personal.CodPer, personal.DNI, personal.GetNombre(), personal.FecNac ?? DateTime.Now, personal.FecIngreso ?? DateTime.Now, personal.NumCtaCTS,
                    UltimoSueldo, SextoGrati, nroPlanillas, personal.EntidadCTS));

            }

            return resultado;

        }

        private IEnumerable<PlanillaRemuneracion> GenerarPlanillaGratificacion(int Anio, int Mes)
        {
            IPlanillaRemuneracionRepository planillaRemuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            string Periodo = Anio.ToString() + Utiles.CerosIzquierda(Mes.ToString(), 2);
            List<PlanillaRemuneracion> resultado = new List<PlanillaRemuneracion>();

            var planillasPeriodo = planillaRemuneracionRepository.PlanillasEnPeriodoPorGrati(Mes, Anio);
            IEnumerable<Personal> personalActivo = personalRepository.GetPersonalActivo();
            foreach (Personal personal in personalActivo)
            {
                var planillas = planillasPeriodo.Where(o => o.IdPersonal == personal.IdPersonal && o.TipoPlan == "N");
                int nroPlanillas = planillas.Count();
                decimal TotalIngresos = planillas.Sum(o => o.TotIng ?? 0);
                decimal Gratificacion = Math.Round(TotalIngresos / nroPlanillas, 2, MidpointRounding.AwayFromZero);
                decimal Extra =Convert.ToDecimal(Math.Round(Convert.ToDouble(Gratificacion) * 0.09, 2, MidpointRounding.AwayFromZero));
                PlanillaRemuneracion gratificacion = new PlanillaRemuneracion(0, Periodo, personal.IdPersonal, personal.CodPer, personal.IdCargo,
                    personal.CodCar, personal.IdFondoPen, personal.CodFon, personal.TipComAFP, 0, 0, 0, Gratificacion, 0, 0, 0, 0, 
                    Extra, 0, 0, 0, 0, 0, 0, 0, 0, 27, 216, null, null, 0, null, null, 0, null, null, 0, "F", "G");
                resultado.Add(gratificacion);
            }



            return resultado;
        }

        public IEnumerable<PlanillaRemuneracion> GetPlanillaGratificacion(int Anio, int Mes)
        {
            IPlanillaRemuneracionRepository planillaRemuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            var planillaGrati = planillaRemuneracionRepository.GetPlanillaGratificacionSimple(Anio.ToString() + Utiles.CerosIzquierda(Mes.ToString(),2));

            if (planillaGrati != null && planillaGrati.Count() > 0)
            {
                var personal = personalRepository.Get();
                foreach (PlanillaRemuneracion registro in planillaGrati)
                {
                    var persona = personal.Where(o => o.IdPersonal == registro.IdPersonal).FirstOrDefault();
                    registro.NombrePersona = persona.ApePaterno + " " + persona.ApeMaterno + ", " + persona.Nombre;
                    //registro.VacacionesPeriodo = vacacionesRepository.GetVacacionesPorPeriodoPersona(Anio, registro.IdPersonal ?? 0);
                    registro.ApellidoPaterno = persona.ApePaterno;
                    registro.ApellidoMaterno = persona.ApeMaterno;
                    registro.Nombre = persona.Nombre;
                    registro.CUSPP = persona.CUSPP;
                    registro.Dni = persona.DNI;
                    registro.FechaIngreso = persona.FecIngreso ?? DateTime.Now;
                }
                return planillaGrati;
            }

            IEnumerable<PlanillaRemuneracion> planillaGratiNuevo = GenerarPlanillaGratificacion(Anio, Mes);
            if (planillaGratiNuevo != null && planillaGratiNuevo.Count() > 0)
            {
                foreach (PlanillaRemuneracion _planilla in planillaGratiNuevo)
                {
                    planillaRemuneracionRepository.Add(_planilla);
                }

                return GetPlanillaGratificacion(Anio, Mes);
            }

            return planillaGrati;
        }


        public IEnumerable<PlanillaRemuneracion> GetPlanillaNormalPorPeriodo(int Anio, int Mes)
        {
            IPlanillaRemuneracionRepository planillaRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();
            IFondoPensionesRepository fondoPensionesRepository = _DataRepositoryFactory.GetDataRepository<IFondoPensionesRepository>();
            IAreaServicioRepository areaServicioRepository = _DataRepositoryFactory.GetDataRepository<IAreaServicioRepository>();
            ICargoRepository cargoRepository = _DataRepositoryFactory.GetDataRepository<ICargoRepository>();

            string Periodo = Anio.ToString() + Utiles.CerosIzquierda(Mes.ToString(),2);
            var planilla = planillaRepository.GetPlanillaPorPeriodo(Periodo, "N");

            IEnumerable<VacacionesPersona> vacaciones = vacacionesRepository.GetVacacionesPorPeriodo(Anio);
            if (vacaciones == null || vacaciones.Count() == 0)
            {
                throw new InvalidOperationException("No se han registrado las vacaciones para este periodo. Imposible continuar con la operación.");
            }

            if (planilla != null && planilla.Count() > 0)
            {
                var personal = personalRepository.Get();
                var fondoPen = fondoPensionesRepository.Get();
                var areasServicio = areaServicioRepository.Get();
                var cargos = cargoRepository.Get();
                foreach(PlanillaRemuneracion registro in planilla)
                {
                    var persona = personal.Where(o => o.IdPersonal == registro.IdPersonal).FirstOrDefault();
                    var fondo = fondoPen.Where(o => o.IdFondoPen == registro.IdFondoPen).FirstOrDefault();
                    var area = areasServicio.Where(o => o.IdAreaServicio == persona.IdAreaServicio).FirstOrDefault();
                    var cargo = cargos.Where(o => o.IdCargo == persona.IdCargo).FirstOrDefault();
                    registro.NombrePersona = persona.ApePaterno + " " + persona.ApeMaterno + ", " + persona.Nombre;
                    registro.VacacionesPeriodo = vacacionesRepository.GetVacacionesPorPeriodoPersona(Anio, registro.IdPersonal ?? 0);
                    registro.ApellidoPaterno = persona.ApePaterno;
                    registro.ApellidoMaterno = persona.ApeMaterno;
                    registro.Nombre = persona.Nombre;
                    registro.CUSPP = persona.CUSPP;
                    registro.Dni = persona.DNI;
                    registro.FechaIngreso = persona.FecIngreso ?? DateTime.Now;
                    registro.AFP = fondo.Entidad;
                    registro.Cargo = cargo.Cargo1;
                    registro.Area = area.Area;
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

        //public void EliminarPlanilla(string Periodo, string TipoPlanilla)
        //{
        //    IPlanillaRemuneracionRepository planillaRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();

        //}



        public List<PlanillaRemuneracion> GenerarPlanilla(string Periodo)
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
                    , 0, aporteEmpleadorESSALUD.Porcentaje, porcentajeSCTR, (personal.CustomDiasHoras > 0 ? personal.CustomDias : diasLaborables.DiasLab),
                    (personal.CustomDiasHoras > 0 ? personal.CustomHoras : personal.HorLab), null, null, null, null, null, null, null, null, null, "F", "N");
                planillaPersona.VacacionesPeriodo = vacacionesPeriodo;
                planillaPersona.NombrePersona = personal.GetNombre();
                remuneracion.Add(planillaPersona);


            }

            return remuneracion;
        }

        public Dictionary<String, IEnumerable<ResumenPlanilla>> GetPlanillasNormalesResumen(int Anio, int? IdPersonal = 0)
        {
            IPlanillaRemuneracionRepository planillaRemuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            Dictionary<String, IEnumerable<ResumenPlanilla>> resultado = new Dictionary<string, IEnumerable<ResumenPlanilla>>();
            List<ResumenPlanilla> todo = new List<ResumenPlanilla>();
            List<ResumenPlanilla> normal = new List<ResumenPlanilla>();
            List<ResumenPlanilla> SubNormal = new List<ResumenPlanilla>();
            List<ResumenPlanilla> gratificacion = new List<ResumenPlanilla>();
            List<ResumenPlanilla> SubGrati = new List<ResumenPlanilla>();
            List<ResumenPlanilla> Total = new List<ResumenPlanilla>();
            //List<ResumenPlanilla> resultado = new List<ResumenPlanilla>();
            var planillas = planillaRemuneracionRepository.GetPlanillasAnio(Anio);

            decimal RemBas = 0;
            decimal AsigFam = 0;
            decimal SubSidio = 0;
            decimal RemVac = 0;
            decimal RieCaj = 0;
            decimal Reintegro = 0;
            decimal horasExtra = 0;
            decimal otroIngresos = 0;
            decimal grati = 0;
            decimal totalIngresos = 0;
            decimal onp = 0;
            decimal aporteObligatorio = 0;
            decimal priSeg = 0;
            decimal comVar = 0;
            decimal quintaCat =0;
            decimal otrosDescuentos = 0;
            decimal totalDescuentos = 0;
            decimal neto = 0;
            decimal totApo = 0;
            decimal essalud = 0;
            decimal sctr = 0;

            foreach (var planilla in planillas)
            {
                if (planilla.TipoPlanilla == "N")
                {
                    IEnumerable<PlanillaRemuneracion> remuneraciones = planillaRemuneracionRepository.GetPlanillaPorPeriodo(planilla.Periodo, planilla.TipoPlanilla, IdPersonal);
                    if (remuneraciones != null && remuneraciones.Count() > 0)
                    {
                        RemBas = (from o in remuneraciones select o.RemBas ?? 0).Sum();
                        AsigFam = (from o in remuneraciones select o.AsiFam ?? 0).Sum();
                        SubSidio = (from o in remuneraciones select o.Subsidio ?? 0).Sum();
                        RemVac = (from o in remuneraciones select o.RemVac ?? 0).Sum();
                        RieCaj = (from o in remuneraciones select o.RieCaj ?? 0).Sum();
                        Reintegro = (from o in remuneraciones select o.Reinte ?? 0).Sum();
                        horasExtra = (from o in remuneraciones select o.HE ?? 0).Sum();
                        grati = (from o in remuneraciones select o.Gratif ?? 0).Sum();
                        otroIngresos = (from o in remuneraciones select o.OtrIng ?? 0).Sum();
                        totalIngresos = (from o in remuneraciones select o.TotIng ?? 0).Sum();
                        onp = (from o in remuneraciones select o.ONP ?? 0).Sum();
                        aporteObligatorio = (from o in remuneraciones select o.ApoObl ?? 0).Sum();
                        priSeg = (from o in remuneraciones select o.PriSeg ?? 0).Sum();
                        comVar = (from o in remuneraciones select o.ComVar ?? 0).Sum();
                        quintaCat = (from o in remuneraciones select o.Quinta ?? 0).Sum();
                        otrosDescuentos = (from o in remuneraciones select o.OtrDes ?? 0).Sum();
                        totalDescuentos = (from o in remuneraciones select o.TotDes ?? 0).Sum();
                        neto = (from o in remuneraciones select o.Neto ?? 0).Sum();
                        totApo = (from o in remuneraciones select o.TotApo ?? 0).Sum();
                        essalud = (from o in remuneraciones select o.Essalud ?? 0).Sum();
                        sctr = (from o in remuneraciones select o.SCTR ?? 0).Sum();
                        ResumenPlanilla resumen = new ResumenPlanilla(planilla.Periodo, RemBas, AsigFam, SubSidio, grati
                            , RemVac, RieCaj, Reintegro, horasExtra, otroIngresos, totalIngresos, onp, aporteObligatorio
                            , priSeg, comVar, quintaCat, otrosDescuentos, totalDescuentos, neto, essalud, sctr, totApo);
                        normal.Add(resumen);
                        todo.Add(resumen);
                    }
                   
                }

                if (planilla.TipoPlanilla == "G")
                {
                    IEnumerable<PlanillaRemuneracion> remuneraciones = planillaRemuneracionRepository.GetPlanillaPorPeriodo(planilla.Periodo, planilla.TipoPlanilla);
                    if(remuneraciones != null && remuneraciones.Count() > 0)
                    {
                        RemBas = (from o in remuneraciones select o.RemBas ?? 0).Sum();
                        AsigFam = (from o in remuneraciones select o.AsiFam ?? 0).Sum();
                        SubSidio = (from o in remuneraciones select o.Subsidio ?? 0).Sum();
                        RemVac = (from o in remuneraciones select o.RemVac ?? 0).Sum();
                        RieCaj = (from o in remuneraciones select o.RieCaj ?? 0).Sum();
                        Reintegro = (from o in remuneraciones select o.Reinte ?? 0).Sum();
                        horasExtra = (from o in remuneraciones select o.HE ?? 0).Sum();
                        otroIngresos = (from o in remuneraciones select o.OtrIng ?? 0).Sum();
                        grati = (from o in remuneraciones select o.Gratif ?? 0).Sum();
                        totalIngresos = (from o in remuneraciones select o.TotIng ?? 0).Sum();
                        onp = (from o in remuneraciones select o.ONP ?? 0).Sum();
                        aporteObligatorio = (from o in remuneraciones select o.ApoObl ?? 0).Sum();
                        priSeg = (from o in remuneraciones select o.PriSeg ?? 0).Sum();
                        comVar = (from o in remuneraciones select o.ComVar ?? 0).Sum();
                        quintaCat = (from o in remuneraciones select o.Quinta ?? 0).Sum();
                        otrosDescuentos = (from o in remuneraciones select o.OtrDes ?? 0).Sum();
                        totalDescuentos = (from o in remuneraciones select o.TotDes ?? 0).Sum();
                        neto = (from o in remuneraciones select o.Neto ?? 0).Sum();
                        totApo = (from o in remuneraciones select o.TotApo ?? 0).Sum();
                        essalud = (from o in remuneraciones select o.Essalud ?? 0).Sum();
                        sctr = (from o in remuneraciones select o.SCTR ?? 0).Sum();
                        ResumenPlanilla resumen = new ResumenPlanilla(planilla.Periodo, RemBas, AsigFam, SubSidio, grati
                            , RemVac, RieCaj, Reintegro, horasExtra, otroIngresos, totalIngresos, onp, aporteObligatorio
                            , priSeg, comVar, quintaCat, otrosDescuentos, totalDescuentos, neto, essalud, sctr, totApo);
                        gratificacion.Add(resumen);
                        todo.Add(resumen);
                    }
                   
                }

            }

            if (normal != null && normal.Count() > 0)
            {
                RemBas = (from o in normal select o.RemBasica).Sum();
                AsigFam = (from o in normal select o.AsigFamiliar).Sum();
                SubSidio = (from o in normal select o.Subsidio).Sum();
                RemVac = (from o in normal select o.RemVacacional).Sum();
                RieCaj = (from o in normal select o.RiesgoCaja).Sum();
                Reintegro = (from o in normal select o.Reintegro).Sum();
                horasExtra = (from o in normal select o.HorasExtra).Sum();
                otroIngresos = (from o in normal select o.OtrosIng).Sum();
                grati = (from o in normal select o.Gratificacion).Sum();
                totalIngresos = (from o in normal select o.TotalIngresos).Sum();
                onp = (from o in normal select o.ONP).Sum();
                aporteObligatorio = (from o in normal select o.AporteObligatorio).Sum();
                priSeg = (from o in normal select o.PrimarSeguro).Sum();
                comVar = (from o in normal select o.ComisionVariable).Sum();
                quintaCat = (from o in normal select o.QuintaCategoria).Sum();
                otrosDescuentos = (from o in normal select o.OtrosDescuentos).Sum();
                totalDescuentos = (from o in normal select o.TotalDescuentos).Sum();
                neto = (from o in normal select o.Neto).Sum();
                totApo = (from o in normal select o.TotalAportes).Sum();
                essalud = (from o in normal select o.Essalud).Sum();
                sctr = (from o in normal select o.SCTR).Sum();

                ResumenPlanilla subNormal = new ResumenPlanilla("SubTotal", RemBas, AsigFam, SubSidio, grati
                            , RemVac, RieCaj, Reintegro, horasExtra, otroIngresos, totalIngresos, onp, aporteObligatorio
                            , priSeg, comVar, quintaCat, otrosDescuentos, totalDescuentos, neto, essalud, sctr, totApo);
                SubNormal.Add(subNormal);
            }

            if (gratificacion != null && gratificacion.Count() > 0)
            {
                RemBas = (from o in gratificacion select o.RemBasica).Sum();
                AsigFam = (from o in gratificacion select o.AsigFamiliar).Sum();
                SubSidio = (from o in gratificacion select o.Subsidio).Sum();
                RemVac = (from o in gratificacion select o.RemVacacional).Sum();
                RieCaj = (from o in gratificacion select o.RiesgoCaja).Sum();
                Reintegro = (from o in gratificacion select o.Reintegro).Sum();
                horasExtra = (from o in gratificacion select o.HorasExtra).Sum();
                otroIngresos = (from o in gratificacion select o.OtrosIng).Sum();
                grati = (from o in gratificacion select o.Gratificacion).Sum();
                totalIngresos = (from o in gratificacion select o.TotalIngresos).Sum();
                onp = (from o in gratificacion select o.ONP).Sum();
                aporteObligatorio = (from o in gratificacion select o.AporteObligatorio).Sum();
                priSeg = (from o in gratificacion select o.PrimarSeguro).Sum();
                comVar = (from o in gratificacion select o.ComisionVariable).Sum();
                quintaCat = (from o in gratificacion select o.QuintaCategoria).Sum();
                otrosDescuentos = (from o in gratificacion select o.OtrosDescuentos).Sum();
                totalDescuentos = (from o in gratificacion select o.TotalDescuentos).Sum();
                neto = (from o in gratificacion select o.Neto).Sum();
                totApo = (from o in gratificacion select o.TotalAportes).Sum();
                essalud = (from o in gratificacion select o.Essalud).Sum();
                sctr = (from o in gratificacion select o.SCTR).Sum();

                ResumenPlanilla subGrati = new ResumenPlanilla("SubTotal", RemBas, AsigFam, SubSidio, grati
                            , RemVac, RieCaj, Reintegro, horasExtra, otroIngresos, totalIngresos, onp, aporteObligatorio
                            , priSeg, comVar, quintaCat, otrosDescuentos, totalDescuentos, neto, essalud, sctr, totApo);
                SubGrati.Add(subGrati);
            }


            if (todo != null && todo.Count() > 0)
            {
                RemBas = (from o in todo select o.RemBasica).Sum();
                AsigFam = (from o in todo select o.AsigFamiliar).Sum();
                SubSidio = (from o in todo select o.Subsidio).Sum();
                RemVac = (from o in todo select o.RemVacacional).Sum();
                RieCaj = (from o in todo select o.RiesgoCaja).Sum();
                Reintegro = (from o in todo select o.Reintegro).Sum();
                horasExtra = (from o in todo select o.HorasExtra).Sum();
                otroIngresos = (from o in todo select o.OtrosIng).Sum();
                grati = (from o in todo select o.Gratificacion).Sum();
                totalIngresos = (from o in todo select o.TotalIngresos).Sum();
                onp = (from o in todo select o.ONP).Sum();
                aporteObligatorio = (from o in todo select o.AporteObligatorio).Sum();
                priSeg = (from o in todo select o.PrimarSeguro).Sum();
                comVar = (from o in todo select o.ComisionVariable).Sum();
                quintaCat = (from o in todo select o.QuintaCategoria).Sum();
                otrosDescuentos = (from o in todo select o.OtrosDescuentos).Sum();
                totalDescuentos = (from o in todo select o.TotalDescuentos).Sum();
                neto = (from o in todo select o.Neto).Sum();
                totApo = (from o in todo select o.TotalAportes).Sum();
                essalud = (from o in todo select o.Essalud).Sum();
                sctr = (from o in todo select o.SCTR).Sum();

                ResumenPlanilla total = new ResumenPlanilla("TotalGeneral", RemBas, AsigFam, SubSidio, grati
                            , RemVac, RieCaj, Reintegro, horasExtra, otroIngresos, totalIngresos, onp, aporteObligatorio
                            , priSeg, comVar, quintaCat, otrosDescuentos, totalDescuentos, neto, essalud, sctr, totApo);
                Total.Add(total);
            }


               

            resultado.Add("N", normal);
            resultado.Add("SN", SubNormal);
            resultado.Add("G", gratificacion);
            resultado.Add("SG", SubGrati);
            resultado.Add("T", Total);

            return resultado;
        }
    }
}
