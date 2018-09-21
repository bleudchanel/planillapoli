using Core.Common;
using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Planilla.Business.Entities
{
    [DataContract]
    [Table("PlanillasRem", Schema = "Planilla")]
    public class PlanillaRemuneracion : EntityBase, IIdentifiableEntity
    {
        public PlanillaRemuneracion(int idPlanilla, 
            string periodo, int? idPersonal, string codPer, int? idCargo, string codCar, int? idFondoPen, string codFon, string tipComAFP, 
            decimal? remBas, decimal? asiFam, decimal? subsidio, decimal? gratif, decimal? remVac, decimal? rieCaj, decimal? reinte, decimal? hE, decimal? otrIng, 
            decimal? porONP, decimal? porApoObl, decimal? porPriSeg, decimal? porComVar, decimal? quinta, decimal? otrDes, decimal? 
            porEssalud, decimal? porSCTR, int? 
            diasLab, int? horasLab, DateTime? iniVac, DateTime? finVac, int? diasVac, 
            DateTime? iniIncapacidad, DateTime? finIncapacidad, int? diasIncapacidad, 
            DateTime? inicioSinGoceHaber, DateTime? finSinGoceHaber, int? diasSinGoceHaber, 
            string cerrado, string tipoPlan)
        {
            IdPlanilla = idPlanilla;
            Periodo = periodo;
            IdPersonal = idPersonal;
            CodPer = codPer;
            IdCargo = idCargo;
            CodCar = codCar;
            IdFondoPen = idFondoPen;
            CodFon = codFon;
            TipComAFP = tipComAFP;
            // Ingresos
            RemBas = remBas;
            AsiFam = asiFam;
            Subsidio = subsidio;
            Gratif = gratif;
            RemVac = remVac;
            RieCaj = rieCaj;
            Reinte = reinte;
            HE = hE;
            OtrIng = otrIng;
            TotIng = (RemBas + AsiFam + Subsidio + Gratif + RemVac + RieCaj + Reinte + HE + OtrIng);
            decimal sueldo = Properties.Settings.Default.SueldoMinimo;
            //Descuentos
            PorONP = porONP;
            PorApoObl = porApoObl;
            PorPriSeg = porPriSeg;
            PorComVar = porComVar;
            ONP = Math.Round((TotIng ?? 0) * (PorONP ?? 0),2,MidpointRounding.AwayFromZero);
            ApoObl = Math.Round((TotIng ?? 0) * (PorApoObl ?? 0), 2, MidpointRounding.AwayFromZero);
            PriSeg = Math.Round((TotIng ?? 0) * (PorPriSeg ?? 0), 2, MidpointRounding.AwayFromZero);
            ComVar = Math.Round((TotIng ?? 0) * (PorComVar ?? 0), 2, MidpointRounding.AwayFromZero);
            Quinta = quinta;
            OtrDes = otrDes;
            TotDes = (ONP + ApoObl + PriSeg + ComVar + Quinta + OtrDes);


            Neto = TotIng - TotDes;

            //Aportes
            PorEssalud = porEssalud;
            PorSCTR = porSCTR;
            Essalud = Math.Round(((TotIng ?? 0) > sueldo ? (TotIng ?? 0) : sueldo) * (PorEssalud ?? 0), 2, MidpointRounding.AwayFromZero);
            SCTR = Math.Round((TotIng ?? 0) * (PorSCTR ?? 0), 2, MidpointRounding.AwayFromZero);
            TotApo = Essalud + SCTR;

            DiasLab = diasLab;
            HorasLab = horasLab;
            IniVac = iniVac;
            FinVac = finVac;
            DiasVac = diasVac;
            IniIncapacidad = iniIncapacidad;
            FinIncapacidad = finIncapacidad;
            DiasIncapacidad = diasIncapacidad;
            InicioSinGoceHaber = inicioSinGoceHaber;
            FinSinGoceHaber = finSinGoceHaber;
            DiasSinGoceHaber = diasSinGoceHaber;
            Cerrado = cerrado;
            TipoPlan = tipoPlan;

            Aumento = 0;
            NuevaRem = 0;
            Corregido = "F";
        }

        public PlanillaRemuneracion()
        {

        }

        public PlanillaRemuneracion(PlanillaRemuneracion planillaBase)
        {
            IdPlanilla = planillaBase.IdPlanilla;
            Periodo = planillaBase.Periodo;
            IdPersonal = planillaBase.IdPersonal;
            CodPer = planillaBase.CodPer;
            IdCargo = planillaBase.IdCargo;
            CodCar = planillaBase.CodCar;
            IdFondoPen = planillaBase.IdFondoPen;
            CodFon = planillaBase.CodFon;
            TipComAFP = planillaBase.TipComAFP;
            RemBas = planillaBase.RemBas;
            AsiFam = planillaBase.AsiFam;
            Subsidio = planillaBase.Subsidio;
            Gratif = planillaBase.Gratif;
            RemVac = planillaBase.RemVac;
            RieCaj = planillaBase.RieCaj;
            Reinte = planillaBase.Reinte;
            HE = planillaBase.HE;
            OtrIng = planillaBase.OtrIng;
            TotIng = planillaBase.TotIng;
            PorONP = planillaBase.PorONP;
            PorApoObl = planillaBase.PorApoObl;
            PorPriSeg = planillaBase.PorPriSeg;
            PorComVar = planillaBase.PorComVar;
            ONP = planillaBase.ONP;
            ApoObl = planillaBase.ApoObl;
            PriSeg = planillaBase.PriSeg;
            ComVar = planillaBase.ComVar;
            Quinta = planillaBase.Quinta;
            OtrDes = planillaBase.OtrDes;
            TotDes = planillaBase.TotDes;
            Neto = planillaBase.Neto;
            PorEssalud = planillaBase.PorEssalud;
            PorSCTR = planillaBase.PorSCTR;
            Essalud = planillaBase.Essalud;
            SCTR = planillaBase.SCTR;
            TotApo = planillaBase.TotApo;
            DiasLab = planillaBase.DiasLab;
            HorasLab = planillaBase.HorasLab;
            IniVac = planillaBase.IniVac;
            FinVac = planillaBase.FinVac;
            DiasVac = planillaBase.DiasVac;
            IniIncapacidad = planillaBase.IniIncapacidad;
            FinIncapacidad = planillaBase.FinIncapacidad;
            DiasIncapacidad = planillaBase.DiasIncapacidad;
            InicioSinGoceHaber = planillaBase.InicioSinGoceHaber;
            FinSinGoceHaber = planillaBase.FinSinGoceHaber;
            DiasSinGoceHaber = planillaBase.DiasSinGoceHaber;
            Cerrado = planillaBase.Cerrado;
            TipoPlan = planillaBase.TipoPlan;
            NombrePersona = planillaBase.NombrePersona;
            VacacionesPeriodo = planillaBase.VacacionesPeriodo;
            Aumento = planillaBase.Aumento;
            NuevaRem = planillaBase.RemBas ?? 0;
            Corregido = planillaBase.Corregido;
        }

        public void SetRemBas(decimal remBas)
        {
            this.RemBas = remBas;
            Recalc();
        }

        public void SetAumento(decimal aumento)
        {
            this.Aumento = aumento;
            this.NuevaRem += aumento;
            Recalc();
        }

        public void SetAsiFam(decimal asiFam)
        {
            this.AsiFam = asiFam;
            Recalc();
        }

        public void SetSubsidio(decimal subsidio)
        {
            this.Subsidio = subsidio;
            Recalc();
        }

        public void SetGratif(decimal gratif)
        {
            this.Gratif = gratif;
            Recalc();
        }

        public void SetRemVac(decimal remVac)
        {
            this.RemVac = remVac;
            Recalc();
        }

        public void SetRieCaj(decimal rieCaj)
        {
            this.RieCaj = rieCaj;
            Recalc();
        }

        public void SetReinte(decimal reinte)
        {
            this.Reinte = reinte;
            Recalc();
        }

        public void SetHE(decimal he)
        {
            this.HE = he;
            Recalc();
        }

        public void SetOtroIng(decimal otroIng)
        {
            this.OtrIng = otroIng;
            Recalc();
        }

        public void SetOtroDescuento(decimal otroDes)
        {
            this.OtrDes = otroDes;
            this.TotDes = (ONP + ApoObl + PriSeg + ComVar + Quinta + OtrDes);
            this.Neto = TotIng - TotDes;
        }

        public void SetQuinta(decimal quinta)
        {
            this.Quinta = quinta;
            this.TotDes = (ONP + ApoObl + PriSeg + ComVar + Quinta + OtrDes);
            this.Neto = TotIng - TotDes;
        }

        private void Recalc()
        {
            TotIng = (RemBas + AsiFam + Subsidio + Gratif + RemVac + RieCaj + Reinte + HE + OtrIng + Aumento);

            ONP = Math.Round((TotIng ?? 0) * (PorONP ?? 0), 2, MidpointRounding.AwayFromZero);
            ApoObl = Math.Round((TotIng ?? 0) * (PorApoObl ?? 0), 2, MidpointRounding.AwayFromZero);
            PriSeg = Math.Round((TotIng ?? 0) * (PorPriSeg ?? 0), 2, MidpointRounding.AwayFromZero);
            ComVar = Math.Round((TotIng ?? 0) * (PorComVar ?? 0), 2, MidpointRounding.AwayFromZero);

            TotDes = (ONP + ApoObl + PriSeg + ComVar + Quinta + OtrDes);

            Neto = TotIng - TotDes;
            decimal sueldo = Properties.Settings.Default.SueldoMinimo;
            Essalud = Math.Round(((TotIng ?? 0) > sueldo ? (TotIng ?? 0) : sueldo) * (PorEssalud ?? 0), 2, MidpointRounding.AwayFromZero);
            SCTR = Math.Round((TotIng ?? 0) * (PorSCTR ?? 0), 2, MidpointRounding.AwayFromZero);
            TotApo = Essalud + SCTR;

        }

        [DataMember]
        public int IdPlanilla { get; set; }
        [DataMember]
        public string Periodo { get; set; }
        [DataMember]
        [Column("Id")]
        public Nullable<int> IdPersonal { get; set; }
        [DataMember]
        public string CodPer { get; set; }
        [DataMember]
        public Nullable<int> IdCargo { get; set; }
        [DataMember]
        public string CodCar { get; set; }
        [DataMember]
        public Nullable<int> IdFondoPen { get; set; }
        [DataMember]
        public string CodFon { get; set; }
        [DataMember]
        public string TipComAFP { get; set; }
        [DataMember]
        public Nullable<decimal> RemBas { get; set; }
        [DataMember]
        public Nullable<decimal> AsiFam { get; set; }
        [DataMember]
        public Nullable<decimal> Subsidio { get; set; }
        [DataMember]
        public Nullable<decimal> Gratif { get; set; }
        [DataMember]
        public Nullable<decimal> RemVac { get; set; }
        [DataMember]
        public Nullable<decimal> RieCaj { get; set; }
        [DataMember]
        public Nullable<decimal> Reinte { get; set; }
        [DataMember]
        public Nullable<decimal> HE { get; set; }
        [DataMember]
        public Nullable<decimal> OtrIng { get; set; }
        [DataMember]
        public Nullable<decimal> TotIng { get; set; }
        [DataMember]
        public Nullable<decimal> PorONP { get; set; }
        [DataMember]
        public Nullable<decimal> PorApoObl { get; set; }
        [DataMember]
        public Nullable<decimal> PorPriSeg { get; set; }
        [DataMember]
        public Nullable<decimal> PorComVar { get; set; }
        [DataMember]
        public Nullable<decimal> ONP { get; set; }
        [DataMember]
        public Nullable<decimal> ApoObl { get; set; }
        [DataMember]
        public Nullable<decimal> PriSeg { get; set; }
        [DataMember]
        public Nullable<decimal> ComVar { get; set; }
        [DataMember]
        public Nullable<decimal> Quinta { get; set; }
        [DataMember]
        public Nullable<decimal> OtrDes { get; set; }
        [DataMember]
        public Nullable<decimal> TotDes { get; set; }
        [DataMember]
        public Nullable<decimal> Neto { get; set; }
        [DataMember]
        public Nullable<decimal> PorEssalud { get; set; }
        [DataMember]
        public Nullable<decimal> PorSCTR { get; set; }
        [DataMember]
        public Nullable<decimal> Essalud { get; set; }
        [DataMember]
        public Nullable<decimal> SCTR { get; set; }
        [DataMember]
        public Nullable<decimal> TotApo { get; set; }
        [DataMember]
        public Nullable<int> DiasLab { get; set; }
        [DataMember]
        public Nullable<int> HorasLab { get; set; }
        [DataMember]
        public Nullable<System.DateTime> IniVac { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinVac { get; set; }
        [DataMember]
        public Nullable<int> DiasVac { get; set; }
        [DataMember]
        public Nullable<System.DateTime> IniIncapacidad { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinIncapacidad { get; set; }
        [DataMember]
        public Nullable<int> DiasIncapacidad { get; set; }
        [DataMember]
        public Nullable<System.DateTime> InicioSinGoceHaber { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinSinGoceHaber { get; set; }
        [DataMember]
        public Nullable<int> DiasSinGoceHaber { get; set; }
        [DataMember]
        public string Cerrado { get; set; }
        [DataMember]
        public string TipoPlan { get; set; }
        [DataMember]
        public string Corregido { get; set; }


        public string NombrePersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string CUSPP { get; set; }
        public string Dni { get; set; }
        public string AFP { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public decimal Aumento { get; set; }
        public decimal NuevaRem { get; set; }

        public Vacaciones VacacionesPeriodo { get; set; }

        public int EntityId { get => IdPlanilla; set => IdPlanilla = value; }
    }
}
