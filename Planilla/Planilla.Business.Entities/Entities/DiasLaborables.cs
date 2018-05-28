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
    [Table("DiasLaborables", Schema = "Planilla")]
    public class DiasLaborables : EntityBase, IIdentifiableEntity
    {
        public DiasLaborables()
        {

        }

        public DiasLaborables(string codMes, string mes, int? año, byte? diasLab, string cerrado)
        {            
            CodMes = codMes;
            Mes = mes;
            Año = año;
            DiasLab = diasLab;
            Cerrado = cerrado;
        }

        [DataMember]
        public int IdDiasLaborables { get; set; }
        [DataMember]
        public string CodMes { get; set; }
        [DataMember]
        public string Mes { get; set; }
        [DataMember]
        public Nullable<int> Año { get; set; }
        [DataMember]
        public Nullable<byte> DiasLab { get; set; }
        [DataMember]
        public string Cerrado { get; set; }
        public int EntityId { get => IdDiasLaborables; set => IdDiasLaborables = value; }
    }
}
