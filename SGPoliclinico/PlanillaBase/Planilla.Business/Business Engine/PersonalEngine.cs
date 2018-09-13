using Core.Common.Contracts;
using Core.Common.Core;
using Planilla.Business.Common;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business
{
    [Export(typeof(IPersonalEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonalEngine : IPersonalEngine
    {
        public PersonalEngine()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        [ImportingConstructor]
        public PersonalEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _DataRepositoryFactory;

        public IEnumerable<Personal> GetPersonalActivo()
        {
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            var result = personalRepository.Get();
            return (from e in result where e.Estado == "A"
                    select e);
        }

        public IEnumerable<VacacionesPersona> GetVacacionesPorPeriodo(int Anio)
        {
            IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();
            var vacaciones = vacacionesRepository.GetVacacionesPorPeriodo(Anio);

            if (vacaciones != null && vacaciones.Count() > 0)
            {
                return vacaciones;
            }

            IEnumerable<Personal> personalActivo = GetPersonalActivo();
            if (personalActivo != null && personalActivo.Count() > 0)
            {
                foreach (Personal personal in personalActivo)
                {
                    vacacionesRepository.Add(new Vacaciones(Anio, personal.IdPersonal, personal.CodPer,"F", "-"));
                }

                return GetVacacionesPorPeriodo(Anio);
            }

            return vacaciones;
           
        }

        public Vacaciones UpdateVacaciones(VacacionesPersona vacacionesPersona)
        {
            IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            Vacaciones vacaciones = vacacionesRepository.Get(vacacionesPersona.IdVacaciones);
            if (vacaciones != null)
            {
                vacaciones.IniProg = vacacionesPersona.IniProg;
                vacaciones.FinProg = vacacionesPersona.FinProg;

                if (((vacaciones.FinProg ?? DateTime.Now) - (vacaciones.IniProg ?? DateTime.Now)).TotalDays > 15)
                {
                    var persona = personalRepository.Get(vacacionesPersona.IdPersonal ?? 0);
                    persona.SCTR = "N";
                    personalRepository.Update(persona);
                }

                return vacacionesRepository.Update(vacaciones);
            }  
            return vacaciones;
        }
    }
}
