using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace Planilla.Data.Test
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_Medico()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();
            Medico medico = factoryTest.GetMedico(1);
            Assert.IsTrue(medico != null);
        }

        [TestMethod]
        public void test_GenerarPlanilla()
        {
            RepositoryBusinessEngineFactory engineFactory = new RepositoryBusinessEngineFactory();
            IEnumerable<PlanillaRemuneracion> planilla = engineFactory.GenerarPlanilla("201805");
            Assert.IsTrue(planilla != null);
        }
    }

    public class RepositoryBusinessEngineFactory
    {
        public RepositoryBusinessEngineFactory()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryBusinessEngineFactory(IBusinessEngineFactory businessEngineFactory)
        {
            _businessEngineFactory = businessEngineFactory;
        }

        [Import]
        IBusinessEngineFactory _businessEngineFactory;

        public IEnumerable<PlanillaRemuneracion> GenerarPlanilla(string Periodo)
        {
            IPlanillaEngine planillaEngine = _businessEngineFactory.GetBusinessEngine<IPlanillaEngine>();
            IEnumerable<PlanillaRemuneracion> planilla = planillaEngine.GenerarPlanilla(Periodo);
            return planilla;
        }
    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        public Medico GetMedico(int IdMedico)
        {
            IMedicoRepository medicoRepository = _DataRepositoryFactory.GetDataRepository<IMedicoRepository>();
            Medico medico = medicoRepository.Get(IdMedico);
            return medico;
        }
    }
}
