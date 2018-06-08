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
    [Table("Ubigeo", Schema = "Planilla")]
    public class Ubigeo : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdUbigeo { get; set; }
        [DataMember]
        public string NOMDIS { get; set; }
        [DataMember]
        public string NOMPRO { get; set; }
        [DataMember]
        public string NOMDEP { get; set; }
        [DataMember]
        public string CODDIS { get; set; }
        [DataMember]
        public string CODPRO { get; set; }
        [DataMember]
        public string CODDEP { get; set; }
        public int EntityId { get => IdUbigeo; set => IdUbigeo = value; }
    }
}
