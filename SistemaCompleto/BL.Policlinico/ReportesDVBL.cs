using DA.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
    public class ReportesDVBL
    {
        ReportesRVDA bl = new ReportesRVDA();
        public DataTable GetDatosPaciente()
        {
            return bl.GetDatosPaciente();
        }

        public DataTable getCitasMedico(string idMedico, string Fecha)
        {
            return bl.getCitasMedico(idMedico, Fecha);
        }
    }
}
