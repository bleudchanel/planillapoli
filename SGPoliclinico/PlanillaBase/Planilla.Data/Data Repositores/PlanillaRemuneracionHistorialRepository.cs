using Core.Common.Extensions;
using Core.Common;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Utils;

namespace Planilla.Data
{
    [Export(typeof(IPlanillaRemuneracionHistorialRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlanillaRemuneracionHistorialRepository : DataRepositoryBase<PlanillaRemuneracionHistorial>, IPlanillaRemuneracionHistorialRepository
    {
        protected override PlanillaRemuneracionHistorial AddEntity(PlanillaContext entityContext, PlanillaRemuneracionHistorial entity)
        {
            return entityContext.PlanillaRemuneracionHistorialSet.Add(entity);
        }

        protected override IEnumerable<PlanillaRemuneracionHistorial> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.PlanillaRemuneracionHistorialSet
                   select e;
        }

        protected override PlanillaRemuneracionHistorial GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.PlanillaRemuneracionHistorialSet 
                         where e.IdPlanilla == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override PlanillaRemuneracionHistorial UpdateEntity(PlanillaContext entityContext, PlanillaRemuneracionHistorial entity)
        {
            return (from e in entityContext.PlanillaRemuneracionHistorialSet 
                    where e.IdPlanilla == entity.IdPlanilla
                    select e).FirstOrDefault();
        }
    }
}
