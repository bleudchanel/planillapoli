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
        public List<ComboBE> getComboM(int flag,int valor)
        {
            return g.getComboM(flag,valor);
        }

        public List<ComboBE> geTrabajador(int flag)
        {
            return g.geTrabajador(flag);
        }

        public List<UbigeoBE> getUbigeo(int flag, int valor)
        {
            return g.getUbigeo(flag, valor);
        }

        

        public int insertUpdMedicina(MedicinaBE m)
        {
            return g.insertUpdMedicina(m);
        }
        public List<MedicinaBE> getMedicina(int m)
        {
            return g.getMedicina(m);
        }

         public List<MedicinaBE> busquedaMedicamento(string producto,int tipo)
        {
            return g.busquedaMedicamento(producto, tipo);
        }

    }
}
