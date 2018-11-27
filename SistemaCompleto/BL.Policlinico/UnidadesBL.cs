using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Policlinico
{
   public class UnidadesBL
    {

       UnidadesDA g = new UnidadesDA();

       public List<UnidadesBE> getUnidadesList( )
        {
            return g.getUnidadesList();
        }



       public int insertUpdUnidades(UnidadesBE Unidades)
        {
            return g.insertUpdUnidades(Unidades);
        }



        public int deleteUnidades(int UnidadesID)
        {
            return g.deleteUnidades(UnidadesID);
        }
    }
}
