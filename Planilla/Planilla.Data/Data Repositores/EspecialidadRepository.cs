using Core.Common.Utils;
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

        public Especialidad AddEspecialidadComplete(Especialidad entity)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                string newCodEsp = "E001";
                var topEspecialidad = (from e in entityContext.EspecialidadSet
                                       orderby e.CodEsp descending
                                       select e).FirstOrDefault();
                if (topEspecialidad != null)
                {
                    newCodEsp = topEspecialidad.CodEsp.Substring(1, topEspecialidad.CodEsp.Length - 1);
                    int Cod = Convert.ToInt32(newCodEsp) + 1;
                    newCodEsp = 'E' + Utiles.CerosIzquierda(Cod.ToString(), 3);
                }

                entity.CodEsp = newCodEsp;

                return Add(entity);

            }
        }
    }
}
