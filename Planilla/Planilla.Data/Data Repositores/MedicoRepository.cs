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
    [Export(typeof(IMedicoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MedicoRepository : DataRepositoryBase<Medico>, IMedicoRepository
    {
        protected override Medico AddEntity(PlanillaContext entityContext, Medico entity)
        {
            return entityContext.MedicoSet.Add(entity);
        }

        protected override IEnumerable<Medico> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.MedicoSet
                   select e;
        }

        protected override Medico GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.MedicoSet
                         where e.IdMedico == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Medico UpdateEntity(PlanillaContext entityContext, Medico entity)
        {
            return (from e in entityContext.MedicoSet
                    where e.IdMedico == entity.IdMedico
                    select e).FirstOrDefault();
        }

        public Medico AddPersonalComplete(Medico entity)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                string nCodPer = "M001";
                var topPersonal = (from e in entityContext.MedicoSet
                                   orderby e.CodMed descending
                                   select e).FirstOrDefault();
                if (topPersonal != null)
                {
                    nCodPer = topPersonal.CodMed.Substring(1, topPersonal.CodMed.Length - 1);
                    int Cod = Convert.ToInt32(nCodPer) + 1;
                    nCodPer = 'M' + Utiles.CerosIzquierda(Cod.ToString(), 3);
                }

                entity.CodMed = nCodPer;

                return Add(entity);

            }

        }
    }
}
