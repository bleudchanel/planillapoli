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
    [Table("Vacaciones", Schema = "Planilla")]
    public class Vacaciones : EntityBase, IIdentifiableEntity
    {
        public Vacaciones(int? año, int? idPersonal, string codPer, string completo, string obs)
        {
            Año = año;
            IdPersonal = idPersonal;
            CodPer = codPer;
            IniProg = null;
            FinProg = null;
            IniEje1 = null;
            FinEje1 = null;
            IniEje2 = null;
            FinEje2 = null;
            IniEje3 = null;
            FinEje3 = null;
            Completo = completo;
            Obs = obs;
        }

        public Vacaciones()
        {

        }

        [DataMember]
        public int IdVacaciones { get; set; }
        [DataMember]
        public Nullable<int> Año { get; set; }
        [DataMember]
        public Nullable<int> IdPersonal { get; set; }
        [DataMember]
        public string CodPer { get; set; }
        [DataMember]
        public Nullable<System.DateTime> IniProg { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinProg { get; set; }
        [DataMember]
        public Nullable<System.DateTime> IniEje1 { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinEje1 { get; set; }
        [DataMember]
        public Nullable<System.DateTime> IniEje2 { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinEje2 { get; set; }
        [DataMember]
        public Nullable<System.DateTime> IniEje3 { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FinEje3 { get; set; }
        [DataMember]
        public string Completo { get; set; }
        [DataMember]
        public string Obs { get; set; }
        public int EntityId { get => IdVacaciones; set => IdVacaciones = value; }
    }
}
