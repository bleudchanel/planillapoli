using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Policlinico
{
    public class TransferenciaBL
    {

        TransferenciaDA gl = new TransferenciaDA();
        public int insertTransferencia(TransfCab g)
        {
            return gl.insertTransferencia(g);
        }

        public int insertTransferenciaAlm(TransfCab g)
        {
            return gl.insertTransferenciaAlm(g);
        }
     
    }
}
