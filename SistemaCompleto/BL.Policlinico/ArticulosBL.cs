using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Policlinico
{
    public class ArticulosBL
    {
        ArticulosDA g = new ArticulosDA();
      


        public int insertUpdArticulo(ArticulosBE m)
        {
            return g.insertUpdArticulo(m);
        }
        public List<ArticulosBE> getArticulos(int m)
        {
            return g.getArticulos(m);
        }



    }
}
