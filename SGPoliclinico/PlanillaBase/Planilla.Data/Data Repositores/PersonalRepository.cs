using Core.Common.Extensions;
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

        public IEnumerable<Personal> GetPersonalActivo(int Anio, int Mes)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.PersonalSet
                        where e.Estado == "A" && e.FecBaja <= new DateTime(Anio,Mes,DateTime.DaysInMonth(Anio,Mes))
                        orderby e.CodPer descending
                        select e).ToFullyLoaded();
            }
        }

        public void BajaPersonal()
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                DateTime dateCompare = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                IEnumerable<Personal> personal = (from e in entityContext.PersonalSet where e.Estado == "A" && e.FecBaja >= dateCompare select e).ToFullyLoaded();
                if (personal != null && personal.Count() > 0)
                {
                    foreach (var persona in personal)
                    {
                        if (persona.FecBaja >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)))
                        {
                            persona.Estado = "B";
                            Update(persona);
                        }
                    }
                }                
            }
        }

        public Personal AddPersonalComplete(Personal entity)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                string nCodPer = "P001";
                var topPersonal = (from e in entityContext.PersonalSet
                                orderby e.CodPer descending
                                select e).FirstOrDefault();
                if (topPersonal != null)
                {
                    nCodPer = topPersonal.CodPer.Substring(1, topPersonal.CodPer.Length - 1);
                    int Cod = Convert.ToInt32(nCodPer) + 1;
                    nCodPer = 'P' + Utiles.CerosIzquierda(Cod.ToString(), 3);
                }

                entity.CodPer = nCodPer;

                return Add(entity);

            }
        }

    }
}
