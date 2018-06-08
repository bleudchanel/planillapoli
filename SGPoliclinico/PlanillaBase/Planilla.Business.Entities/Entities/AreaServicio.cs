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
    [Table("AreaServicio", Schema = "Planilla")]
    public class AreaServicio : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdAreaServicio { get; set; }
        [DataMember]
        public string CodAre { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public Nullable<byte> Estado { get; set; }
        public int EntityId { get => IdAreaServicio; set => IdAreaServicio = value; }
    }
}
