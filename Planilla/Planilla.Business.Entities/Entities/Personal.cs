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
    [Table("Personal", Schema = "Planilla")]
    public class Personal : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdPersonal { get; set; }
        [DataMember]
        public string CodPer { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public string ApePaterno { get; set; }
        [DataMember]
        public string ApeMaterno { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public Nullable<int> IdUbigeo { get; set; }
        [DataMember]
        public string CodDistrito { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FecNac { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Celular { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public string EstadoCivil { get; set; }
        [DataMember]
        public Nullable<byte> NumHij { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FecIngreso { get; set; }
        [DataMember]
        public string Estudios { get; set; }
        [DataMember]
        public string Grado { get; set; }
        [DataMember]
        public string NumCol { get; set; }
        [DataMember]
        public Nullable<int> IdAreaServicio { get; set; }
        [DataMember]
        public string CodAre { get; set; }
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
        public string CUSPP { get; set; }
        [DataMember]
        public string EVida { get; set; }
        [DataMember]
        public Nullable<decimal> RemBas { get; set; }
        [DataMember]
        public Nullable<decimal> AsiFam { get; set; }
        [DataMember]
        public Nullable<decimal> RieCaj { get; set; }
        [DataMember]
        public string SCTR { get; set; }
        [DataMember]
        public Nullable<int> HorLab { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FecBaja { get; set; }
        [DataMember]
        public string EntidadCTS { get; set; }
        [DataMember]
        public string NumCtaCTS { get; set; }
        public int EntityId { get => IdPersonal; set => IdPersonal = value; }
    }
}
