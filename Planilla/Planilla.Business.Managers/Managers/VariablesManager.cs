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
    public class VariablesManager
    {
        public VariablesManager()
        {
            ObjectBase.Container = MEFLoader.Init();
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public VariablesManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public VariablesManager(IBusinessEngineFactory businessEngineFactory)
        {
            _BusinessEngineFactory = businessEngineFactory;
        }

        public VariablesManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;

        public IEnumerable<AporteEmpleador> GetAportesEmpleador()
        {
            IAporteEmpleadorRepository aporteEmpleadorRepository = _DataRepositoryFactory.GetDataRepository<IAporteEmpleadorRepository>();
            return aporteEmpleadorRepository.Get();
        }

        public AporteEmpleador UpdateAporteEmpleador(AporteEmpleador aporteEmpleador)
        {
            IAporteEmpleadorRepository aporteEmpleadorRepository = _DataRepositoryFactory.GetDataRepository<IAporteEmpleadorRepository>();
            return aporteEmpleadorRepository.Update(aporteEmpleador);
        }

        public IEnumerable<FondoPensiones> GetFondoPensiones()
        {
            IFondoPensionesRepository fondoPensionesRepository = _DataRepositoryFactory.GetDataRepository<IFondoPensionesRepository>();
            return fondoPensionesRepository.Get();
        }

        public IEnumerable<Procedimiento> GetProcedimientos()
        {
            IProcedimientoRepository procedimientoRepository = _DataRepositoryFactory.GetDataRepository<IProcedimientoRepository>();
            return procedimientoRepository.Get();
        }

        public IEnumerable<AreaAnalisis> GetAreaAnalisis()
        {
            IAreaAnalisisRepository analisisRepository = _DataRepositoryFactory.GetDataRepository<IAreaAnalisisRepository>();
            return analisisRepository.Get();
        }

        public IEnumerable<TablaAnalisis> GetTablasAnalisis()
        {
            ITablaAnalisisRepository tablaAnalisis = _DataRepositoryFactory.GetDataRepository<ITablaAnalisisRepository>();
            return tablaAnalisis.Get();
        }

        public IEnumerable<Ubigeo> GetUbigeo()
        {
            IUbigeoRepository UbigeoRepository = _DataRepositoryFactory.GetDataRepository<IUbigeoRepository>();
            return UbigeoRepository.Get();
        }

        public IEnumerable<AreaServicio> GetAreasServicio()
        {
            IAreaServicioRepository areaServicioRepository = _DataRepositoryFactory.GetDataRepository<IAreaServicioRepository>();
            return areaServicioRepository.Get();
        }

        public IEnumerable<Cargo> GetCargos()
        {
            ICargoRepository cargoRepository = _DataRepositoryFactory.GetDataRepository<ICargoRepository>();
            return cargoRepository.Get();
        }

        public FondoPensiones RegistrarFondoPensiones(FondoPensiones fondo)
        {
            IFondoPensionesRepository fondoRepository = _DataRepositoryFactory.GetDataRepository<IFondoPensionesRepository>();
            if (fondo.IdFondoPen > 0)
            {
                return fondoRepository.Update(fondo);
            }
            else
            {
                return fondoRepository.AddFondoPensionesComplete(fondo);
            }
        }

        public Procedimiento RegistrarProcedimiento(Procedimiento procedimiento)
        {
            IProcedimientoRepository procedimientoRepository = _DataRepositoryFactory.GetDataRepository<IProcedimientoRepository>();
            
            if (procedimiento.IdProcedimiento > 0)
            {
             //   procedimiento.CodEsp = 
                return procedimientoRepository.Update(procedimiento);
            }
            else
            {
                return procedimientoRepository.AddProcedimientoComplete(procedimiento);
            }
        }

        public TablaAnalisis RegistrarTablaAnalisis(TablaAnalisis tabla)
        {
            ITablaAnalisisRepository tablaAnalisisRepository = _DataRepositoryFactory.GetDataRepository<ITablaAnalisisRepository>();
            if (tabla.IdAnalisis > 0)
            {
                return tablaAnalisisRepository.Update(tabla);
            }            
            else
            {
                return tablaAnalisisRepository.AddTablaAnalisisComplete(tabla);
            }
        }

    }
}
