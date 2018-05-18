using Core.Common.Extensions;
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
    [Export(typeof(IPersonalRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonalRepository : DataRepositoryBase<Personal>, IPersonalRepository
    {
        protected override Personal AddEntity(PlanillaContext entityContext, Personal entity)
        {
            return entityContext.PersonalSet.Add(entity);
        }

        protected override IEnumerable<Personal> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.PersonalSet
                   select e;
        }

        protected override Personal GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.PersonalSet
                         where e.IdPersonal == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Personal UpdateEntity(PlanillaContext entityContext, Personal entity)
        {
            return (from e in entityContext.PersonalSet
                    where e.IdPersonal == entity.IdPersonal
                    select e).FirstOrDefault();
        }

        public IEnumerable<Personal> GetPersonalActivo()
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.PersonalSet
                        where e.Estado == "A"
                        orderby e.CodPer descending
                        select e).ToFullyLoaded();
            }
        }

    }
}
