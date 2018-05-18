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
    [Export(typeof(IUbigeoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UbigeoRepository : DataRepositoryBase<Ubigeo>, IUbigeoRepository
    {
        protected override Ubigeo AddEntity(PlanillaContext entityContext, Ubigeo entity)
        {
            return entityContext.UbigeoSet.Add(entity);
        }

        protected override IEnumerable<Ubigeo> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.UbigeoSet
                   select e;
        }

        protected override Ubigeo GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.UbigeoSet
                         where e.IdUbigeo == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Ubigeo UpdateEntity(PlanillaContext entityContext, Ubigeo entity)
        {
            return (from e in entityContext.UbigeoSet
                    where e.IdUbigeo == entity.IdUbigeo
                    select e).FirstOrDefault();
        }
    }
}
