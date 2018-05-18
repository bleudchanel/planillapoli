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
    [Table("Cargo", Schema = "Planilla")]
    public class Cargo : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdCargo { get; set; }
        [DataMember]
        public string CodCar { get; set; }
        [DataMember]
        public string Cargo1 { get; set; }
        [DataMember]
        public Nullable<byte> Estado { get; set; }
        public int EntityId { get => IdCargo; set => IdCargo = value; }
    }
}
