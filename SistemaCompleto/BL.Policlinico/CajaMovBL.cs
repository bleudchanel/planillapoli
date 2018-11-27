using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
    public class CajaMovBL
    {
        CajaMovDA g = new CajaMovDA();

        public DataTable getMovimientos(int idUsuario,string FechaFin)
        {
            return g.getMovimientos(idUsuario, FechaFin);
        }

        public int setInsUpdovimientos(int tipo, CajaMovBE b, int idUsuario)
        {
            return g.setInsUpdovimientos(tipo, b, idUsuario);
        }

        public int deleteMov(int IdMov, int idUsuario)
        {
            return g.deleteMov(IdMov, idUsuario);
        }
    }
}
