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
    [Table("Lab_AreasLaboratorio", Schema = "Planilla")]
    public class AreaLaboratorio : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdAreaLaboratorio { get; set; }
        [DataMember]
        public string CodAre { get; set; }
        [DataMember]
        public string AreaLab { get; set; }
        public int EntityId { get => IdAreaLaboratorio; set => IdAreaLaboratorio = value; }
    }
}
