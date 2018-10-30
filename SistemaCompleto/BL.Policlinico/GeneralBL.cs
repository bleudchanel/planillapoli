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

        public List<ComboBE> listarCombos_AFT(int  tipo_accion ,int tipo_ref ,int valor )
        {
            return g.listarCombos_AFT(tipo_accion, tipo_ref, valor);
        }

        public List<ComboBE> listarCombos_AFT_MED(int tipo_accion, int tipo_ref, int valor)
        {
            return g.listarCombos_AFT_MED(tipo_accion, tipo_ref, valor);
        }
        
        public List<ComboBE> listarCombos_AFC(int tipo_accion, int tipo_ref, int valor)
        {
            return g.listarCombos_AFC(tipo_accion, tipo_ref, valor);
        }


        public List<ComboBE> listarCombos_AFC_Venta(int tipo_accion, int tipo_ref, int valor)
        {
            return g.listarCombos_AFC_Venta(tipo_accion, tipo_ref, valor);
        }
        

        public List<ComboBE> getComboM(int flag, int valor)
        {
            return g.getComboM(flag, valor);
        }

        public List<ComboBE> getProveedorbyMed(int Id)
        {
            return g.getProveedorbyMed(Id);
        }
        
        
    }
}
