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
    [Export(typeof(ITablaAnalisisVRRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TablaAnalisisVRRepository : DataRepositoryBase<TablaAnalisisVR>, ITablaAnalisisVRRepository
    {
        protected override TablaAnalisisVR AddEntity(PlanillaContext entityContext, TablaAnalisisVR entity)
        {
            return entityContext.TablaAnalisisVRSet.Add(entity);
        }

        protected override IEnumerable<TablaAnalisisVR> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.TablaAnalisisVRSet
                   select e;
        }

        protected override TablaAnalisisVR GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.TablaAnalisisVRSet
                         where e.IdValReferencial == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override TablaAnalisisVR UpdateEntity(PlanillaContext entityContext, TablaAnalisisVR entity)
        {
            return (from e in entityContext.TablaAnalisisVRSet
                    where e.IdValReferencial == entity.IdValReferencial
                    select e).FirstOrDefault();
        }
    }
}
