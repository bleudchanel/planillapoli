using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Policlinico
{
    public class MedicinaBL
    {
        MedicinaDA g = new MedicinaDA();
        public List<ComboBE> getComboM(int flag)
        {
            return g.getComboM(flag);
        }


        public int insertUpdMedicina(MedicinaBE m)
        {
            return g.insertUpdMedicina(m);
        }
    }
}
