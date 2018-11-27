using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
   public class GuiaCompraFVBL
    {
       GuiaCompraFVDA gl = new GuiaCompraFVDA();
        public int insertGuiaCompra(GuiaCompraCab g)
        {
            return gl.insertGuiaCompra(g);
        }
        public int insertGuiaCompraAlm(GuiaCompraCab g)
        {
            return gl.insertGuiaCompraAlm(g);
        }
    }
}
