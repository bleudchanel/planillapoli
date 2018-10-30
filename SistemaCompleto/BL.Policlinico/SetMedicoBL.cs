using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
   public  class SetMedicoBL
    {
       SetMedicoDA gl = new SetMedicoDA();
       public int insertSet(string nombre, int idUsuario)
        {
            return gl.insertSet(nombre, idUsuario);
        }
       public int insertSetDetalle(int idCab, int idProducto, int cantidad,int tipo,int IdDet)
        {
            return gl.insertSetDetalle(idCab, idProducto, cantidad,tipo, IdDet);
        }

        public int deleteSetDetalle(int idDet)
        {
            return gl.deleteSetDetalle(idDet);
        }


        public List<DetalleSetBE> getDetalleSet(int idCab)
       {
           return gl.getDetalleSet(idCab);
       }

        public List<DetalleSetCabBE> getCabeceraSet()
        {
            return gl.getCabeceraSet();
        }


        

    }
}
