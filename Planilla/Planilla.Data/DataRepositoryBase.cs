using Core.Common.Contracts;
using Core.Common.Data;
using Planilla.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, PlanillaContext>
        where T : class, IIdentifiableEntity, new()
    {
    
    }
}
