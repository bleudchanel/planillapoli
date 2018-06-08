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
    [Export(typeof(IAreaServicioRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AreaServicioRepository : DataRepositoryBase<AreaServicio>, IAreaServicioRepository
    {
        protected override AreaServicio AddEntity(PlanillaContext entityContext, AreaServicio entity)
        {
            return entityContext.AreaServicioSet.Add(entity);
        }

        protected override IEnumerable<AreaServicio> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.AreaServicioSet
                   select e;
        }

        protected override AreaServicio GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.AreaServicioSet
                         where e.IdAreaServicio == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override AreaServicio UpdateEntity(PlanillaContext entityContext, AreaServicio entity)
        {
            return (from e in entityContext.AreaServicioSet
                    where e.IdAreaServicio == entity.IdAreaServicio
                    select e).FirstOrDefault();
        }
    }
}
