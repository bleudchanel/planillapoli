using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;
using DA.Policlinico;

namespace BL.Policlinico
{
    public class EspecialidadBL
    {
        EspecialidadDA EspecialidadDA = new EspecialidadDA();
        public List<EspecialidadBE> getEspecialidadList(EspecialidadBE Bespeciali)
        {
            try
            {
                return EspecialidadDA.getEspecialidadList(Bespeciali);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EspecialidadBE getEspecialidadbyID(EspecialidadBE Bespeciali)
        {
            try
            {
                return EspecialidadDA.getEspecialidadbyID(Bespeciali);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insertEspecialidad(EspecialidadBE Especialidad)
        {
            try
            {
                return EspecialidadDA.insertEspecialidad(Especialidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int editEspecialidad(EspecialidadBE Especialidad)
        {
            try
            {
                return EspecialidadDA.editEspecialidad(Especialidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteEspecialidad(EspecialidadBE Bespeciali)
        {
            try
            {
                return EspecialidadDA.deleteEspecialidad(Bespeciali);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EspecialidadBE getEspecialidadCod()
        {
            try
            {
                return EspecialidadDA.getEspecialidadCod();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
