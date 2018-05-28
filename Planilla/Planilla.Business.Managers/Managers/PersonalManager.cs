using Core.Common.Contracts;
using Core.Common.Core;
using Planilla.Business.Bootstrapper;
using Planilla.Business.Common;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business.Managers
{
    public class PersonalManager
    {
        public PersonalManager()
        {
            ObjectBase.Container = MEFLoader.Init();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }
        public PersonalManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public PersonalManager(IBusinessEngineFactory businessEngineFactory)
        {
            _BusinessEngineFactory = businessEngineFactory;
        }

        public PersonalManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;


        public IEnumerable<Personal> GetPersonalActivo()
        {
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            var result = personalRepository.Get();
            return (from e in result
                    //where e.Estado == "A"
                    select e);
        }

        public IEnumerable<PlanillaRemuneracion> GetPlanillaPeriodo(int Anio, int Mes)
        {
            IEnumerable<PlanillaRemuneracion> resultado = new List<PlanillaRemuneracion>();
            try
            {
                IPlanillaEngine planillaEngine = _BusinessEngineFactory.GetBusinessEngine<IPlanillaEngine>();
                resultado = planillaEngine.GetPlanillaNormalPorPeriodo(Anio, Mes);
            }
            catch(InvalidOperationException Ex)
            {
                throw Ex;
            }

            return resultado;
            
        }

        public PlanillaRemuneracion UpdatePlanilla(PlanillaRemuneracion planillaRemuneracion)
        {
            IPlanillaRemuneracionRepository remuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();
            var Persona = remuneracionRepository.Update(planillaRemuneracion);
            Persona.VacacionesPeriodo = vacacionesRepository.Update(planillaRemuneracion.VacacionesPeriodo);
            return Persona;
        }
    }
}
