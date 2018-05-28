using Core.Common.Extensions;
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

        public IEnumerable<DiasLaborables> GetDiasPorPeriodo(int Anio)
        {

            using(PlanillaContext entityContext = new PlanillaContext())
            {
                var lab = (from e in entityContext.DiasLaborablesSet
                           where e.Año == Anio
                           orderby e.CodMes ascending
                           select e).ToFullyLoaded();
                if (lab != null && lab.Count() > 0)
                {
                    return lab;
                }
                else
                {
                    Add(new DiasLaborables("01", "01 ENERO", Anio, 0, "F"));
                    Add(new DiasLaborables("02", "02 FEBRERO", Anio, 0, "F"));
                    Add(new DiasLaborables("03", "03 MARZO", Anio, 0, "F"));
                    Add(new DiasLaborables("04", "04 ABRIL", Anio, 0, "F"));
                    Add(new DiasLaborables("05", "05 MAYO", Anio, 0, "F"));
                    Add(new DiasLaborables("06", "06 JUNIO", Anio, 0, "F"));
                    Add(new DiasLaborables("07", "07 JULIO", Anio, 0, "F"));
                    Add(new DiasLaborables("08", "08 AGOSTO", Anio, 0, "F"));
                    Add(new DiasLaborables("09", "09 SETIEMBRE", Anio, 0, "F"));
                    Add(new DiasLaborables("10", "10 OCTUBRE", Anio, 0, "F"));
                    Add(new DiasLaborables("11", "11 NOVIEMBRE", Anio, 0, "F"));
                    Add(new DiasLaborables("12", "12 DICIEMBRE", Anio, 0, "F"));

                    return GetDiasPorPeriodo(Anio);
                }
            }
        }
    }
}
