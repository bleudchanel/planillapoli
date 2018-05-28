using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Contracts
{
    [DataContract]
    public class VacacionesPersona
    {
        public VacacionesPersona()
        {

        }

        public VacacionesPersona(int idVacaciones, int? año, int? idPersonal, string codPer, string nombrePersona, string area, DateTime? iniProg, DateTime? finProg, DateTime? iniEje1, DateTime? finEje1, DateTime? iniEje2, DateTime? finEje2, DateTime? iniEje3, DateTime? finEje3, string completo, string obs)
        {
            IdVacaciones = idVacaciones;
            Año = año;
            IdPersonal = idPersonal;
            CodPer = codPer;
            NombrePersona = nombrePersona;
            Area = area;
            IniProg = iniProg;
            FinProg = finProg;
            IniEje1 = iniEje1;
            FinEje1 = finEje1;
            IniEje2 = iniEje2;
            FinEje2 = finEje2;
            IniEje3 = iniEje3;
            FinEje3 = finEje3;
            Completo = completo;
            Obs = obs;
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
        public string NombrePersona { get; set; }
        [DataMember]
        public string Area { get; set; }
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
    }
}
