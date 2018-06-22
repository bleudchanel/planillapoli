using Core.Common.Contracts;
using Planilla.Business.Entities;
using Planilla.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business.Common
{
    public interface IPlanillaEngine : IBusinessEngine
    {
        List<PlanillaRemuneracion> GenerarPlanilla(string Periodo);
        IEnumerable<PlanillaRemuneracion> GetPlanillaNormalPorPeriodo(int Anio, int Mes);
        IEnumerable<PlanillaRemuneracion> GetPlanillaGratificacion(int Anio, int Mes);
        Dictionary<String, IEnumerable<ResumenPlanilla>> GetPlanillasNormalesResumen(int Anio, int? IdPersonal = 0);
        IEnumerable<PlanillaCTS> GenerarPlanillaCTS(int Anio, int Mes);
    }
}
