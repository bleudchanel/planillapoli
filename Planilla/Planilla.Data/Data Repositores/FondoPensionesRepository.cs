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
    [Export(typeof(IFondoPensionesRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FondoPensionesRepository : DataRepositoryBase<FondoPensiones>, IFondoPensionesRepository
    {
        protected override FondoPensiones AddEntity(PlanillaContext entityContext, FondoPensiones entity)
        {
            return entityContext.FondoPensionesSet.Add(entity);
        }

        protected override IEnumerable<FondoPensiones> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.FondoPensionesSet
                   select e;
        }

        protected override FondoPensiones GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.FondoPensionesSet
                         where e.IdFondoPen == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override FondoPensiones UpdateEntity(PlanillaContext entityContext, FondoPensiones entity)
        {
            return (from e in entityContext.FondoPensionesSet
                    where e.IdFondoPen == entity.IdFondoPen
                    select e).FirstOrDefault();
        }
    }
}
