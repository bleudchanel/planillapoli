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
    [Table("AreaAnalisis", Schema = "Planilla")]
    public class AreaAnalisis : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdAreaAnalisis { get; set; }
        [DataMember]
        public string CodArea { get; set; }
        [DataMember(Name = "AreaAnalisis")]
        [Column("AreaAnalisis")]
        public string AreaAnalisisDes { get; set; }
        public int EntityId { get => IdAreaAnalisis; set => IdAreaAnalisis = value; }
    }
}
