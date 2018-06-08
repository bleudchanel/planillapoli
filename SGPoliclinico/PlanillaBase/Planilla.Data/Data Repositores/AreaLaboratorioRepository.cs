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
    [Export(typeof(IAreaLaboratorioRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AreaLaboratorioRepository : DataRepositoryBase<AreaLaboratorio>, IAreaLaboratorioRepository
    {
        protected override AreaLaboratorio AddEntity(PlanillaContext entityContext, AreaLaboratorio entity)
        {
            return entityContext.AreaLaboratorioSet.Add(entity);
        }

        protected override IEnumerable<AreaLaboratorio> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.AreaLaboratorioSet
                   select e;
        }

        protected override AreaLaboratorio GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.AreaLaboratorioSet
                         where e.IdAreaLaboratorio == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override AreaLaboratorio UpdateEntity(PlanillaContext entityContext, AreaLaboratorio entity)
        {
            return (from e in entityContext.AreaLaboratorioSet
                    where e.IdAreaLaboratorio == entity.IdAreaLaboratorio
                    select e).FirstOrDefault();
        }
    }
}
