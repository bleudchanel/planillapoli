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
    [Export(typeof(ITablaAnalisisRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TablaAnalisisRepository : DataRepositoryBase<TablaAnalisis>, ITablaAnalisisRepository
    {
        protected override TablaAnalisis AddEntity(PlanillaContext entityContext, TablaAnalisis entity)
        {
            return entityContext.TablaAnalisisSet.Add(entity);
        }

        protected override IEnumerable<TablaAnalisis> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.TablaAnalisisSet
                   select e;
        }

        protected override TablaAnalisis GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.TablaAnalisisSet
                         where e.IdAnalisis == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override TablaAnalisis UpdateEntity(PlanillaContext entityContext, TablaAnalisis entity)
        {
            return (from e in entityContext.TablaAnalisisSet
                    where e.IdAnalisis == entity.IdAnalisis
                    select e).FirstOrDefault();
        }
    }
}
