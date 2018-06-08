using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
    public class ProveedorBL
    {

        ProveedorDA g = new ProveedorDA();

        public List<ProveedorBE> getProveedorList()
        {
            return g.getProveedorList();
        }

        public int insertUpdProveedor(ProveedorBE Proveedor)
        {
            return g.insertUpdProveedor(Proveedor);
        }



        public int deleteProveedor(int ProveedorID)
        {
            return g.deleteProveedor(ProveedorID);
        }
    }
}
