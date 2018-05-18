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
    [Table("AporteEmpleador",Schema = "Planilla")]
    public class AporteEmpleador : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdAporteEmpleador { get; set; }
        [DataMember]
        public string CodApo { get; set; }
        [DataMember]
        public string Aporte { get; set; }
        [DataMember]
        public Nullable<decimal> Porcentaje { get; set; }
        public int EntityId { get => IdAporteEmpleador; set => IdAporteEmpleador = value; }
    }
}
