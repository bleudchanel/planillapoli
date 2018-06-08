using Core.Common.Contracts;
using Core.Common.Core;
using Planilla.Business.Bootstrapper;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace Planilla.Business.Managers
{
    public class DiasLaboralesManager
    {
        public DiasLaboralesManager()
        {
            ObjectBase.Container = MEFLoader.Init();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public DiasLaboralesManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public DiasLaboralesManager(IBusinessEngineFactory businessEngineFactory)
        {
            _BusinessEngineFactory = businessEngineFactory;
        }

        public DiasLaboralesManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;

        [OperationBehavior(TransactionScopeRequired = true)]
        public IEnumerable<DiasLaborables> GetDiasLaborales(int Anio)
        {
            IDiasLaborablesRepository diasLaborablesRepository = _DataRepositoryFactory.GetDataRepository<IDiasLaborablesRepository>();
            return diasLaborablesRepository.GetDiasPorPeriodo(Anio);
        }

        public DiasLaborables Update(DiasLaborables dias)
        {
            IDiasLaborablesRepository diasLaborablesRepository = _DataRepositoryFactory.GetDataRepository<IDiasLaborablesRepository>();
            return diasLaborablesRepository.Update(dias);
        }        

    }
}
