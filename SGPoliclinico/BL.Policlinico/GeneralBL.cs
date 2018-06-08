using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
    public class GeneralBL
    {

        GeneralDA g = new GeneralDA();

        public List<GeneralBE> getGeneralList(int flag)
        {
            return g.getGeneralList(flag);
        }



        public int insertUpdGeneral(GeneralBE general)
        {
            return g.insertUpdGeneral(general);
        }



        public int deleteGeneral(int generalID, int flag)
        {
            return g.deleteGeneral(generalID, flag);
        }
    }
}
