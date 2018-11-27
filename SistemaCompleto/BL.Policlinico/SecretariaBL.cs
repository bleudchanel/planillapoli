using DA.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
    public class SecretariaBL
    {
        SecretariaDA bl = new SecretariaDA();
        public DataTable GetDatosPaciente(string fechaInicio, string fechaFin, string codPaciente)
        {
            return bl.GetDatosPaciente(fechaInicio,  fechaFin,  codPaciente);
        }
    }
}
