using Core.Common.Contracts;
using Planilla.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Contracts
{
    public interface IPersonalRepository : IDataRepository<Personal>
    {
        IEnumerable<Personal> GetPersonalActivo(int Anio, int Mes);
        Personal AddPersonalComplete(Personal entity);
        void BajaPersonal();
    }
}
