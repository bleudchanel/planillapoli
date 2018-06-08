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
    [Export(typeof(IAporteEmpleadorRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AporteEmpleadorRepository : DataRepositoryBase<AporteEmpleador>, IAporteEmpleadorRepository
    {
        protected override AporteEmpleador AddEntity(PlanillaContext entityContext, AporteEmpleador entity)
        {
            return entityContext.AporteEmpleadorSet.Add(entity);
        }

        protected override IEnumerable<AporteEmpleador> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.AporteEmpleadorSet
                   select e;
        }

        protected override AporteEmpleador GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.AporteEmpleadorSet
                         where e.IdAporteEmpleador == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override AporteEmpleador UpdateEntity(PlanillaContext entityContext, AporteEmpleador entity)
        {
            return (from e in entityContext.AporteEmpleadorSet
                    where e.IdAporteEmpleador == entity.IdAporteEmpleador
                    select e).FirstOrDefault();
        }
    }
}
