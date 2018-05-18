using Core.Common;
using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Business.Entities
{
    [DataContract]
    [Table("PlanillasRem", Schema = "Planilla")]
    public class PlanillaRemuneracion : EntityBase, IIdentifiableEntity
    {
        public PlanillaRemuneracion(int idPlanilla, string periodo, int? idPersonal, string codPer, int? idCargo, string codCar, int? idFondoPen, string codFon, string tipComAFP, decimal? remBas, decimal? asiFam, decimal? subsidio, decimal? gratif, decimal? remVac, decimal? rieCaj, decimal? reinte, decimal? hE, decimal? otrIng, decimal? totIng, decimal? porONP, decimal? porApoObl, decimal? porPriSeg, decimal? porComVar, decimal? oNP, decimal? apoObl, decimal? priSeg, decimal? comVar, decimal? quinta, decimal? otrDes, decimal? totDes, decimal? neto, decimal? porEssalud, decimal? porSCTR, decimal? essalud, decimal? sCTR, decimal? totApo, int? diasLab, int? horasLab, DateTime? iniVac, DateTime? finVac, int? diasVac, DateTime? iniIncapacidad, DateTime? finIncapacidad, int? diasIncapacidad, DateTime? inicioSinGoceHaber, DateTime? finSinGoceHaber, int? diasSinGoceHaber, string cerrado, string tipoPlan, int entityId)
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
            RemBas = remBas;
            AsiFam = asiFam;
            Subsidio = subsidio;
            Gratif = gratif;
            RemVac = remVac;
            RieCaj = rieCaj;
            Reinte = reinte;
            HE = hE;
            OtrIng = otrIng;
            TotIng = totIng;
            PorONP = porONP;
            PorApoObl = porApoObl;
            PorPriSeg = porPriSeg;
            PorComVar = porComVar;
            ONP = oNP;
            ApoObl = apoObl;
            PriSeg = priSeg;
            ComVar = comVar;
            Quinta = quinta;
            OtrDes = otrDes;
            TotDes = totDes;
            Neto = neto;
            PorEssalud = porEssalud;
            PorSCTR = porSCTR;
            Essalud = essalud;
            SCTR = sCTR;
            TotApo = totApo;
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
            EntityId = entityId;
        }

        public PlanillaRemuneracion()
        {

        }

        [DataMember]
        public int IdPlanilla { get; set; }
        [DataMember]
        public string Periodo { get; set; }
        [DataMember]
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

        public int EntityId { get => IdPlanilla; set => IdPlanilla = value; }
    }
}
