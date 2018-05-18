using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Data_Repositores
{
    [Export(typeof(IVacacionesRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VacacionesRepository : DataRepositoryBase<Vacaciones>, IVacacionesRepository
    {
        protected override Vacaciones AddEntity(PlanillaContext entityContext, Vacaciones entity)
        {
            return entityContext.VacacionesSet.Add(entity);
        }

        protected override IEnumerable<Vacaciones> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.VacacionesSet
                   select e;
        }

        protected override Vacaciones GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.VacacionesSet
                         where e.IdVacaciones == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Vacaciones UpdateEntity(PlanillaContext entityContext, Vacaciones entity)
        {
            return (from e in entityContext.VacacionesSet
                    where e.IdVacaciones == entity.IdVacaciones
                    select e).FirstOrDefault();
        }

        public Vacaciones GetVacacionesInicioPeriodoPersona(int IdPersonal, int Anio, int Mes)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.VacacionesSet
                        where e.IdPersonal == IdPersonal
                        && e.Año == Anio
                        && e.IniProg.Value.Month == Mes
                        select e).FirstOrDefault();
            }
        }

        public Vacaciones GetVacacionesFinPeriodoPersona(int IdPersonal, int Anio, int Mes)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.VacacionesSet
                        where e.IdPersonal == IdPersonal
                        && e.Año == Anio
                        && e.FinProg.Value.Month == Mes
                        select e).FirstOrDefault();
            }
        }

    }
}
