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
    [Export(typeof(IDiasLaborablesRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DiasLaborablesRepository : DataRepositoryBase<DiasLaborables>, IDiasLaborablesRepository
    {
        protected override DiasLaborables AddEntity(PlanillaContext entityContext, DiasLaborables entity)
        {
            return entityContext.DiasLaborablesSet.Add(entity);
        }

        protected override IEnumerable<DiasLaborables> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.DiasLaborablesSet
                   select e;
        }

        protected override DiasLaborables GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.DiasLaborablesSet
                         where e.IdDiasLaborables == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override DiasLaborables UpdateEntity(PlanillaContext entityContext, DiasLaborables entity)
        {
            return (from e in entityContext.DiasLaborablesSet
                    where e.IdDiasLaborables == entity.IdDiasLaborables
                    select e).FirstOrDefault();
        }

        public DiasLaborables GetDiasPorPeriodo(string CodMes)
        {
            DiasLaborables dias = new DiasLaborables();
            
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                dias = (from e in entityContext.DiasLaborablesSet
                        where e.CodMes == CodMes
                        select e).FirstOrDefault();
            }
            
            if (dias == null)
            {
                dias = new DiasLaborables();
                dias.DiasLab = 27;
                dias.CodMes = CodMes;
            }

            return dias;
        }
    }
}
