using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Policlinico
{
    public class AnulacionBL
    {

          AnulacionDA g = new AnulacionDA();

          public List<AnulacionBE> getDatosAnulacion(int NroGuia, int flag)
          {
              return g.getDatosAnulacion(NroGuia,flag);
          }

          public int  insertarAnulacion(int Id, int flag, int idAnulacion, string detalle, int idUsuario, List<AnulacionBE> data)
        {
              return g.insertarAnulacion(Id, flag, idAnulacion, detalle, idUsuario,data);
          }
    }
}
