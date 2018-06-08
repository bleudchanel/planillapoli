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
    [Export(typeof(IAreaAnalisisRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AreaAnalisisRepository : DataRepositoryBase<AreaAnalisis>, IAreaAnalisisRepository
    {
        protected override AreaAnalisis AddEntity(PlanillaContext entityContext, AreaAnalisis entity)
        {
            return entityContext.AreaAnalisisSet.Add(entity);
        }

        protected override IEnumerable<AreaAnalisis> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.AreaAnalisisSet
                   select e;
        }

        protected override AreaAnalisis GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.AreaAnalisisSet
                         where e.IdAreaAnalisis == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override AreaAnalisis UpdateEntity(PlanillaContext entityContext, AreaAnalisis entity)
        {
            return (from e in entityContext.AreaAnalisisSet
                    where e.IdAreaAnalisis == entity.IdAreaAnalisis
                    select e).FirstOrDefault();
        }
    }
}
