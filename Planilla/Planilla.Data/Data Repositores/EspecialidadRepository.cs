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
    [Export(typeof(IEspecialidadRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EspecialidadRepository : DataRepositoryBase<Especialidad>, IEspecialidadRepository
    {
        protected override Especialidad AddEntity(PlanillaContext entityContext, Especialidad entity)
        {
            return entityContext.EspecialidadSet.Add(entity);
        }

        protected override IEnumerable<Especialidad> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.EspecialidadSet
                   select e;
        }

        protected override Especialidad GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.EspecialidadSet
                         where e.IdEspecialidad == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Especialidad UpdateEntity(PlanillaContext entityContext, Especialidad entity)
        {
            return (from e in entityContext.EspecialidadSet
                    where e.IdEspecialidad == entity.IdEspecialidad
                    select e).FirstOrDefault();
        }
    }
}
