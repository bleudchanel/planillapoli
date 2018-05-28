using Core.Common.Contracts;
using Planilla.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Contracts
{
    public interface IVacacionesRepository : IDataRepository<Vacaciones>
    {
        Vacaciones GetVacacionesInicioPeriodoPersona(int IdPersonal, int Anio, int Mes);
        Vacaciones GetVacacionesFinPeriodoPersona(int IdPersonal, int Anio, int Mes);
        IEnumerable<VacacionesPersona> GetVacacionesPorPeriodo(int Anio);
        Vacaciones GetVacacionesPorPeriodoPersona(int Anio, int IdPersonal);
    }
}
