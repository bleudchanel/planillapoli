using Core.Common.Contracts;
using Planilla.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business.Common
{
    public interface IPlanillaEngine : IBusinessEngine
    {
        IEnumerable<PlanillaRemuneracion> GenerarPlanilla(string Periodo);
    }
}
