using Core.Common.Contracts;
using Planilla.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Contracts
{
    public interface IPlanillaRemuneracionRepository : IDataRepository<PlanillaRemuneracion>
    {
        IEnumerable<PlanillaRemuneracion> GetPlanillaPorPeriodo(string Periodo, string Tipo, int? IdPersonal = 0);
        IEnumerable<PlanillaUnico> GetPlanillasAnio(int Anio);
        void EliminarPlanilla(string Periodo, string TipoPlanilla);
        IEnumerable<PlanillaRemuneracion> PlanillasEnPeriodoPorGrati(int Mes, int Anio);
        IEnumerable<PlanillaRemuneracion> GetPlanillaGratificacionSimple(string Periodo);
        IEnumerable<PlanillaRemuneracion> PlanillasEnPeriodoPorCTS(int Mes, int Anio);
    }
}
