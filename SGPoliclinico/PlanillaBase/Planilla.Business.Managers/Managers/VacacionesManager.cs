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
    public class VacacionesManager
    {
        public VacacionesManager()
        {
            ObjectBase.Container = MEFLoader.Init();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public VacacionesManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public VacacionesManager(IBusinessEngineFactory businessEngineFactory)
        {
            _BusinessEngineFactory = businessEngineFactory;
        }

        public VacacionesManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;

        public IEnumerable<VacacionesPersona> GetVacacionesPorPeriodo(int Anio)
        {
            IPersonalEngine personalEngine = _BusinessEngineFactory.GetBusinessEngine<IPersonalEngine>();
            // IVacacionesRepository vacacionesRepository = _DataRepositoryFactory.GetDataRepository<IVacacionesRepository>();
            return personalEngine.GetVacacionesPorPeriodo(Anio);
        }

        public Vacaciones UpdateVacaciones(VacacionesPersona vacacionesPersona)
        {
            IPersonalEngine personalEngine = _BusinessEngineFactory.GetBusinessEngine<IPersonalEngine>();
            return personalEngine.UpdateVacaciones(vacacionesPersona);
        }
    }
}
