using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
