using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Contracts
{
    [DataContract]
    public class ResumenPlanilla
    {
        public ResumenPlanilla(string periodo, decimal remBasica, decimal asigFamiliar, decimal subsidio, decimal gratificacion, decimal remVacacional, decimal riesgoCaja, decimal reintegro, decimal horasExtra, decimal otrosIng, decimal totalIngresos, decimal oNP, decimal aporteObligatorio, decimal primarSeguro, decimal comisionVariable, decimal quintaCategoria, decimal otrosDescuentos, decimal totalDescuentos, decimal neto, decimal essalud, decimal sCTR, decimal totalAportes)
        {
            Periodo = periodo;
            RemBasica = remBasica;
            AsigFamiliar = asigFamiliar;
            Subsidio = subsidio;
            Gratificacion = gratificacion;
            RemVacacional = remVacacional;
            RiesgoCaja = riesgoCaja;
            Reintegro = reintegro;
            HorasExtra = horasExtra;
            OtrosIng = otrosIng;
            TotalIngresos = totalIngresos;
            ONP = oNP;
            AporteObligatorio = aporteObligatorio;
            PrimarSeguro = primarSeguro;
            ComisionVariable = comisionVariable;
            QuintaCategoria = quintaCategoria;
            OtrosDescuentos = otrosDescuentos;
            TotalDescuentos = totalDescuentos;
            Neto = neto;
            Essalud = essalud;
            SCTR = sCTR;
            TotalAportes = totalAportes;
        }

        public ResumenPlanilla()
        {

        }

        public string Periodo { get; set; }
        public decimal RemBasica { get; set; }
        public decimal AsigFamiliar { get; set; }
        public decimal Subsidio { get; set; }
        public decimal Gratificacion { get; set; }
        public decimal RemVacacional { get; set; }
        public decimal RiesgoCaja { get; set; }
        public decimal Reintegro { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal OtrosIng { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal ONP { get; set; }
        public decimal AporteObligatorio { get; set; }
        public decimal PrimarSeguro { get; set; }
        public decimal ComisionVariable { get; set; }
        public decimal QuintaCategoria { get; set; }
        public decimal OtrosDescuentos { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal Neto { get; set; }
        public decimal Essalud { get; set; }
        public decimal SCTR { get; set; }
        public decimal TotalAportes { get; set; }
    }
}
