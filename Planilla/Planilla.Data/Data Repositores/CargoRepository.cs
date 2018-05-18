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
    [Export(typeof(ICargoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CargoRepository : DataRepositoryBase<Cargo>, ICargoRepository
    {
        protected override Cargo AddEntity(PlanillaContext entityContext, Cargo entity)
        {
            return entityContext.CargoSet.Add(entity);
        }

        protected override IEnumerable<Cargo> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.CargoSet
                   select e;
        }

        protected override Cargo GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.CargoSet
                         where e.IdCargo == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Cargo UpdateEntity(PlanillaContext entityContext, Cargo entity)
        {
            return (from e in entityContext.CargoSet
                    where e.IdCargo == entity.IdCargo
                    select e).FirstOrDefault();
        }
    }
}
