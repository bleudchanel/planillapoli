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

        public IEnumerable<Medico> GetMedicos()
        {
            IMedicoRepository medicoRepository = _DataRepositoryFactory.GetDataRepository<IMedicoRepository>();
            return medicoRepository.Get();
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

        public IEnumerable<PlanillaCTS> GetPlanillaCTS(int Anio, int Mes)
        {
            IEnumerable<PlanillaCTS> resultado = new List<PlanillaCTS>();
            IPlanillaEngine planillaEngine = _BusinessEngineFactory.GetBusinessEngine<IPlanillaEngine>();
            resultado = planillaEngine.GenerarPlanillaCTS(Anio, Mes);
            return resultado;
        }

        public IEnumerable<PlanillaRemuneracion> GetPlanillaGratificacion(int Anio, int Mes)
        {
            IEnumerable<PlanillaRemuneracion> resultado = new List<PlanillaRemuneracion>();
            IPlanillaEngine planillaEngine = _BusinessEngineFactory.GetBusinessEngine<IPlanillaEngine>();
            resultado = planillaEngine.GetPlanillaGratificacion(Anio, Mes);
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

        public IEnumerable<PlanillaUnico> GetPlanillaPeriodo(int Anio)
        {
            IPlanillaRemuneracionRepository remuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            return remuneracionRepository.GetPlanillasAnio(Anio);
        }

        

        public void EliminarPlanilla(string Periodo, string TipoPlanilla)
        {
            IPlanillaRemuneracionRepository remuneracionRepository = _DataRepositoryFactory.GetDataRepository<IPlanillaRemuneracionRepository>();
            remuneracionRepository.EliminarPlanilla(Periodo, TipoPlanilla);
        }


        public Personal RegistrarPersonal(Personal personal)
        {
            IPersonalRepository personalRepository = _DataRepositoryFactory.GetDataRepository<IPersonalRepository>();
            if (personal.IdPersonal > 0)
            {
                return personalRepository.Update(personal);
            }
            else
            {
                return personalRepository.AddPersonalComplete(personal);
            }
        }

        public Medico RegistrarMedico(Medico medico)
        {
            IMedicoRepository medicoRepository = _DataRepositoryFactory.GetDataRepository<IMedicoRepository>();
            if (medico.IdMedico> 0)
            {
                return medicoRepository.Update(medico);
            }
            else
            {
                return medicoRepository.AddPersonalComplete(medico);
            }
        }


        public Dictionary<String, IEnumerable<ResumenPlanilla>> GetResumenPlanilla(int Anio, int? IdPersonal = 0)
        {
            IPlanillaEngine planillaEngine = _BusinessEngineFactory.GetBusinessEngine<IPlanillaEngine>();
            return planillaEngine.GetPlanillasNormalesResumen(Anio, IdPersonal);
        }

        public List<PlanillaRemuneracion> GetPlanillaSimple(string Periodo)
        {
            IPlanillaEngine planillaEngine = _BusinessEngineFactory.GetBusinessEngine<IPlanillaEngine>();
            return planillaEngine.GenerarPlanilla(Periodo);
        }
    }
}
