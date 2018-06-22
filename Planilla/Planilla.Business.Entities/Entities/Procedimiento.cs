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
    [Table("Procedimiento", Schema = "Planilla")]
    public class Procedimiento : EntityBase, IIdentifiableEntity
    {
        public Procedimiento(string tipPro, string procedimiento1, 
            int? idEspecialidad, string codEsp, decimal? precioProcedimiento,
            decimal? montoMedico, string observacion, string proImprimir)
        {            
            TipPro = tipPro;
            Procedimiento1 = procedimiento1;
            IdEspecialidad = idEspecialidad;
            CodEsp = codEsp;
            PrecioProcedimiento = precioProcedimiento;
            MontoMedico = montoMedico;
            Observacion = observacion;
            ProImprimir = proImprimir;
            IdAreaLaboratorio = null;
            AreaLaboratorio = null;
        }

        public Procedimiento()
        {

        }

        [DataMember]
        [Column("Id_Procedimiento")]
        public int IdProcedimiento { get; set; }
        [DataMember]
        public string CodPro { get; set; }
        [DataMember]
        public string TipPro { get; set; }
        [DataMember(Name = "Procedimiento")]
        [Column("Procedimiento")]
        public string Procedimiento1 { get; set; }
        [DataMember]
        [Column("Id_Especialidades")]
        public Nullable<int> IdEspecialidad { get; set; }
        [DataMember]
        public string CodEsp { get; set; }
        [DataMember]
        public Nullable<decimal> PrecioProcedimiento { get; set; }
        [DataMember]
        public Nullable<decimal> MontoMedico { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string ProImprimir { get; set; }
        [DataMember]
        public Nullable<int> IdAreaLaboratorio { get; set; }
        [DataMember]
        public string AreaLaboratorio { get; set; }
        public int EntityId { get => IdProcedimiento; set => IdProcedimiento = value; }
    }
}
