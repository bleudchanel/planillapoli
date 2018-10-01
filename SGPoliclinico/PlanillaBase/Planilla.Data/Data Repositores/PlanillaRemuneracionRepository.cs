using Core.Common.Extensions;
using Core.Common;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Utils;

namespace Planilla.Data
{
    [Export(typeof(IPlanillaRemuneracionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlanillaRemuneracionRepository : DataRepositoryBase<PlanillaRemuneracion>, IPlanillaRemuneracionRepository
    {
        protected override PlanillaRemuneracion AddEntity(PlanillaContext entityContext, PlanillaRemuneracion entity)
        {
            return entityContext.PlanillaRemuneracionSet.Add(entity);
        }

        protected override IEnumerable<PlanillaRemuneracion> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.PlanillaRemuneracionSet
                   select e;
        }

        protected override PlanillaRemuneracion GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.PlanillaRemuneracionSet
                         where e.IdPlanilla == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override PlanillaRemuneracion UpdateEntity(PlanillaContext entityContext, PlanillaRemuneracion entity)
        {
            return (from e in entityContext.PlanillaRemuneracionSet
                    where e.IdPlanilla == entity.IdPlanilla
                    select e).FirstOrDefault();
        }

        public IEnumerable<PlanillaRemuneracion> GetPlanillaPorPeriodo(string Periodo, string Tipo, int? IdPersonal = 0)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                var ans = (from e in entityContext.PlanillaRemuneracionSet
                        where e.Periodo == Periodo && e.TipoPlan == Tipo && (IdPersonal == 0 || e.IdPersonal == IdPersonal)
                        orderby e.CodPer ascending
                        select e).ToFullyLoaded();
                foreach(var a in ans)
                {
                    if (a.IniIncapacidad != null && a.FinIncapacidad != null)
                    {
                        a.esIncapacidad = true;
                    }
                    else
                    {
                        a.esIncapacidad = false;
                    }
                }

                return ans;
            }
        }

        public IEnumerable<PlanillaUnico> GetPlanillasAnio(int Anio)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                List<PlanillaUnico> resultado = new List<PlanillaUnico>();
                var lista = (from planilla in entityContext.PlanillaRemuneracionSet
                             where planilla.Periodo.Substring(0, 4) == Anio.ToString()
                             select new
                             {
                                 planilla.Periodo,
                                 planilla.TipoPlan,
                                 planilla.Cerrado
                             }).Distinct();
                foreach(var unico in lista)
                {
                    resultado.Add(new PlanillaUnico(unico.Periodo, unico.TipoPlan, unico.Cerrado));
                }
                return resultado;
            }
        }

        public void EliminarPlanilla(string Periodo, string TipoPlanilla)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                var planilla = (from e in entityContext.PlanillaRemuneracionSet
                                where e.Periodo == Periodo && e.TipoPlan == TipoPlanilla
                                select e);
                if (planilla != null)
                {
                    foreach(var plan in planilla)
                    {
                        Remove(plan);
                    }                    
                }
            }
        }

        public IEnumerable<PlanillaRemuneracion> PlanillasEnPeriodoPorGrati(int Mes, int Anio)
        {

            var Periodos = new string[] { };
               
            string PeriodoHasta = Anio.ToString();

            if (Mes == 7)
            {
                Periodos = new string[] { Anio.ToString() + "01", Anio.ToString() + "02", Anio.ToString() + "03", Anio.ToString() + "04", Anio.ToString() + "05", Anio.ToString() + "06"};
            }
            else
            {
                Periodos = new string[] { Anio.ToString() + "07", Anio.ToString() + "08", Anio.ToString() + "09", Anio.ToString() + "10", Anio.ToString() + "11", Anio.ToString() + "12" };
            }

            using (PlanillaContext entityContext = new PlanillaContext())
            {
                var planilla = (from e in entityContext.PlanillaRemuneracionSet
                                where Periodos.Contains(e.Periodo)
                                select e).ToFullyLoaded();
                return planilla;
            }
        }


        public IEnumerable<PlanillaRemuneracion> PlanillasEnPeriodoPorCTS(int Mes, int Anio)
        {
            int AnioAnterior = Anio - 1;
            var Periodos = new string[] { };
            string PeriodoGrati = (Mes == 5) ? (AnioAnterior + "12") : (Anio + "07");
            string PeriodoHasta = Anio.ToString();
            
            if (Mes == 5)
            {
                Periodos = new string[] { AnioAnterior.ToString() + "11", AnioAnterior.ToString() + "12", Anio.ToString() + "01", Anio.ToString() + "02", Anio.ToString() + "03", Anio.ToString() + "04" };
            }
            else
            {
                Periodos = new string[] { Anio.ToString() + "05", Anio.ToString() + "06", Anio.ToString() + "07", Anio.ToString() + "08", Anio.ToString() + "09", Anio.ToString() + "10" };
            }

            using (PlanillaContext entityContext = new PlanillaContext())
            {
                var planilla = (from e in entityContext.PlanillaRemuneracionSet
                                where (Periodos.Contains(e.Periodo) && e.TipoPlan == "N") || (e.Periodo == PeriodoGrati && e.TipoPlan == "G")
                                select e).ToFullyLoaded();
                return planilla;
            }

        }


        public IEnumerable<PlanillaRemuneracion> GetPlanillaGratificacionSimple(string Periodo)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.PlanillaRemuneracionSet
                        where e.Periodo == Periodo && e.TipoPlan == "G"
                        select e).ToFullyLoaded();
            }
        }
    }
}
