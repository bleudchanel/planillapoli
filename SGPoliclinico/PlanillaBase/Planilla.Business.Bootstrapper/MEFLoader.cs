using Planilla.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MedicoRepository).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(PlanillaEngine).Assembly));
            //catalog.Catalogs.Add
            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }
    }
}
