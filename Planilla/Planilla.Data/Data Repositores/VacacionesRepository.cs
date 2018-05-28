using Core.Common.Extensions;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Data_Repositores
{
    [Export(typeof(IVacacionesRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VacacionesRepository : DataRepositoryBase<Vacaciones>, IVacacionesRepository
    {
        protected override Vacaciones AddEntity(PlanillaContext entityContext, Vacaciones entity)
        {
            return entityContext.VacacionesSet.Add(entity);
        }

        protected override IEnumerable<Vacaciones> GetEntities(PlanillaContext entityContext)
        {
            return from e in entityContext.VacacionesSet
                   select e;
        }

        protected override Vacaciones GetEntity(PlanillaContext entityContext, int id)
        {
            var query = (from e in entityContext.VacacionesSet
                         where e.IdVacaciones == id
                         select e);
            var results = query.FirstOrDefault();

            return results;
        }

        protected override Vacaciones UpdateEntity(PlanillaContext entityContext, Vacaciones entity)
        {
            return (from e in entityContext.VacacionesSet
                    where e.IdVacaciones == entity.IdVacaciones
                    select e).FirstOrDefault();
        }

        public Vacaciones GetVacacionesInicioPeriodoPersona(int IdPersonal, int Anio, int Mes)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.VacacionesSet
                        where e.IdPersonal == IdPersonal
                        && e.Año == Anio
                        && e.IniProg.Value.Month == Mes
                        select e).FirstOrDefault();
            }
        }

        public Vacaciones GetVacacionesFinPeriodoPersona(int IdPersonal, int Anio, int Mes)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                return (from e in entityContext.VacacionesSet
                        where e.IdPersonal == IdPersonal
                        && e.Año == Anio
                        && e.FinProg.Value.Month == Mes
                        select e).FirstOrDefault();
            }
        }

        public Vacaciones GetVacacionesPorPeriodoPersona(int Anio, int IdPersonal)
        {
            Vacaciones resultado = new Vacaciones();
            using(PlanillaContext entityContext = new PlanillaContext())
            {
                resultado = (from e in entityContext.VacacionesSet
                        where e.Año == Anio && e.IdPersonal == IdPersonal
                        select e).FirstOrDefault();
                return resultado;
            }
        }

        public IEnumerable<VacacionesPersona> GetVacacionesPorPeriodo(int Anio)
        {
            using (PlanillaContext entityContext = new PlanillaContext())
            {
                List<VacacionesPersona> resultado = new List<VacacionesPersona>();
                var lista = (from vacaciones in entityContext.VacacionesSet
                        join personal in entityContext.PersonalSet on vacaciones.IdPersonal equals personal.IdPersonal
                        join area in entityContext.AreaServicioSet on personal.IdAreaServicio equals area.IdAreaServicio
                        where vacaciones.Año == Anio
                        select new
                        {
                            vacaciones.IdVacaciones,
                            vacaciones.Año,
                            vacaciones.IdPersonal,
                            personal.CodPer,
                            NombrePersona = personal.ApePaterno + " " + personal.ApeMaterno + ", " + personal.Nombre,
                            area.Area,
                            vacaciones.IniProg,
                            vacaciones.FinProg,
                            vacaciones.IniEje1,
                            vacaciones.FinEje1,
                            vacaciones.IniEje2,
                            vacaciones.FinEje2,
                            vacaciones.IniEje3,
                            vacaciones.FinEje3,
                            vacaciones.Completo,
                            vacaciones.Obs
                        });
                foreach(var unico in lista)
                {
                    resultado.Add(new VacacionesPersona(unico.IdVacaciones, unico.Año, unico.IdPersonal, unico.CodPer, unico.NombrePersona, unico.Area, unico.IniProg, unico.FinProg, unico.IniEje1, unico.FinEje1, unico.IniEje2, unico.FinEje2, unico.IniEje3, unico.FinEje3, "", ""));
                }

                return resultado;
            }
        }

    }
}
