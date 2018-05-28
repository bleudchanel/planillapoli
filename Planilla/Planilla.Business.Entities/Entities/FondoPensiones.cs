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
    [Table("FondoPensiones", Schema = "Planilla")]
    public class FondoPensiones : EntityBase, IIdentifiableEntity
    {
        public FondoPensiones()
        {

        }

        public FondoPensiones(string codFon, string entidad, decimal? apoOblF, decimal? comVarF, decimal? priSegF, decimal? apoOblM, decimal? comVarM, decimal? priSegM, decimal? porONP)
        {
            CodFon = codFon;
            Entidad = entidad;
            ApoOblF = apoOblF;
            ComVarF = comVarF;
            PriSegF = priSegF;
            ApoOblM = apoOblM;
            ComVarM = comVarM;
            PriSegM = priSegM;
            PorONP = porONP;
            Estado = 1;            
        }

        [DataMember]
        public int IdFondoPen { get; set; }
        [DataMember]
        public string CodFon { get; set; }
        [DataMember]
        public string Entidad { get; set; }
        [DataMember]
        public Nullable<decimal> ApoOblF { get; set; }
        [DataMember]
        public Nullable<decimal> ComVarF { get; set; }
        [DataMember]
        public Nullable<decimal> PriSegF { get; set; }
        [DataMember]
        public Nullable<decimal> ApoOblM { get; set; }
        [DataMember]
        public Nullable<decimal> ComVarM { get; set; }
        [DataMember]
        public Nullable<decimal> PriSegM { get; set; }
        [DataMember]
        public Nullable<decimal> PorONP { get; set; }
        [DataMember]
        public Nullable<byte> Estado { get; set; }
        public int EntityId { get => IdFondoPen; set => IdFondoPen = value; }
    }
}
