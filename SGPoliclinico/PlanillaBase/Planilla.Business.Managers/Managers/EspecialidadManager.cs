using Core.Common.Contracts;
using Core.Common.Core;
using Planilla.Business.Bootstrapper;
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
    public class EspecialidadManager
    {
        public EspecialidadManager()
        {
            ObjectBase.Container = MEFLoader.Init();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public EspecialidadManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public EspecialidadManager(IBusinessEngineFactory businessEngineFactory)
        {
            _BusinessEngineFactory = businessEngineFactory;
        }

        public EspecialidadManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;

        public IEnumerable<Especialidad> GetEspecialidades()
        {
            IEspecialidadRepository especialidadRepository = _DataRepositoryFactory.GetDataRepository<IEspecialidadRepository>();
            return especialidadRepository.Get();
        }

        public Especialidad Registrar(Especialidad especialidad)
        {
            IEspecialidadRepository especialidadRepository  = _DataRepositoryFactory.GetDataRepository<IEspecialidadRepository>();
            if (especialidad.IdEspecialidad > 0)
            {
                return especialidadRepository.Update(especialidad);
            }
            else
            {                
                return especialidadRepository.AddEspecialidadComplete(especialidad);
            }
        }
    }
}
