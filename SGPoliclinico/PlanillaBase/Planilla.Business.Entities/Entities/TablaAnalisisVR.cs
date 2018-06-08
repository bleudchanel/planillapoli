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
    [Table("TablaAnalisisVR", Schema = "Planilla")]
    public class TablaAnalisisVR : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdValReferencial { get; set; }
        [DataMember]
        public string CodVal { get; set; }
        [DataMember]
        public string ValReferencial { get; set; }
        [DataMember]
        public Nullable<int> IdAnalisis { get; set; }
        [DataMember]
        public string CodAna { get; set; }
        public int EntityId { get => IdValReferencial; set => IdValReferencial = value; }
    }
}
