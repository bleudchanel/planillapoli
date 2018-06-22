using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Data.Contracts
{
    [DataContract]
    public class PlanillaCTS
    {
        public PlanillaCTS()
        {

        }

        public PlanillaCTS(int idPersonal, string codPer, string dni, string nombre, DateTime fechaNacimiento
            , DateTime fechaIngreso, string numCta, decimal totRemuneracion, decimal sextoGratificacion, int mesesLab, string entidad)
        {
            IdPersonal = idPersonal;
            CodPer = codPer;
            Dni = dni;
            Nombre = nombre;
            FechaNacimiento = fechaNacimiento;
            FechaIngreso = fechaIngreso;
            NumCta = numCta;
            TotRemuneracion = totRemuneracion;
            SextoGratificacion = sextoGratificacion;
            RemComputable = TotRemuneracion + SextoGratificacion;
            MesesLab = mesesLab;
            MontoCTS = Math.Round((RemComputable/360) * (MesesLab*30),2,MidpointRounding.AwayFromZero);
            EntidadFinanciera = entidad;
        }

        [DataMember]
        public int IdPersonal { get; set; }
        [DataMember]
        public string CodPer { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public string NumCta { get; set; }
        [DataMember]
        public decimal TotRemuneracion { get; set; }
        [DataMember]
        public decimal SextoGratificacion { get; set; }
        [DataMember]
        public decimal RemComputable { get; set; }
        [DataMember]
        public int MesesLab { get; set; }
        [DataMember]
        public decimal MontoCTS { get; set; }
        [DataMember]
        public string EntidadFinanciera { get; set; }
    }
}
