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
    public interface IPersonalEngine : IBusinessEngine
    {
        IEnumerable<VacacionesPersona> GetVacacionesPorPeriodo(int Anio);
        IEnumerable<Personal> GetPersonalActivo();
        Vacaciones UpdateVacaciones(VacacionesPersona vacacionesPersona);
    }
}
