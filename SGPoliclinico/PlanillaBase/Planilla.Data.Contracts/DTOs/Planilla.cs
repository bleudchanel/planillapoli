using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Utils;

namespace Planilla.Data.Contracts
{
    [DataContract]
    public class PlanillaUnico
    {
        public PlanillaUnico(string periodo, string tipoPlanilla, string cerrado)
        {
            Periodo = periodo;
            Anio = Convert.ToInt32(periodo.Substring(0,4));
            Mes = Utiles.MesUnico(Convert.ToInt32(periodo.Substring(4, 2)));
            TipoPlanilla = tipoPlanilla;
            Cerrado = cerrado;
            TipoPlanillaExt = (tipoPlanilla == "N") ? "Normal" : "Gratificación";
        }

        [DataMember]
        public string Periodo { get; set; }
        [DataMember]
        public int Anio { get; set; }
        [DataMember]
        public string Mes { get; set; }
        [DataMember]
        public string TipoPlanilla { get; set; }
        [DataMember]
        public string Cerrado { get; set; }
        [DataMember]
        public string TipoPlanillaExt { get; set; }

    }
}
