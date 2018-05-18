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
    [Export(typeof(IProcedimientoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProcedimientoRepository : DataRepositoryBase<Procedimiento>, IProcedimientoRepository
    {
        protected override Procedimiento AddEntity(PlanillaContext entityContext, Procedimiento entity)
        {
            return entityContext.ProcedimientoSet.Add(entity);
        }

        protected override IEnumerable<Procedimiento> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.ProcedimientoSet
                   select e;
        }

        protected override Procedimiento GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.ProcedimientoSet
                         where e.IdProcedimiento == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Procedimiento UpdateEntity(PlanillaContext entityContext, Procedimiento entity)
        {
            return (from e in entityContext.ProcedimientoSet
                    where e.IdProcedimiento == entity.IdProcedimiento
                    select e).FirstOrDefault();
        }
    }
}
