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
    [Table("Especialidad", Schema = "Planilla")]
    public class Especialidad : EntityBase, IIdentifiableEntity
    {
        public Especialidad()
        {

        }

        public Especialidad(int idEspecialidad, string codEsp, string descripcion, decimal precioConsulta, decimal montoMedico, int entityId)
        {
            IdEspecialidad = idEspecialidad;
            CodEsp = codEsp;
            Descripcion = descripcion;
            PrecioConsulta = precioConsulta;
            MontoMedico = montoMedico;
            EntityId = entityId;
        }

        [DataMember]
        public int IdEspecialidad { get; set; }
        [DataMember]
        public string CodEsp { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal PrecioConsulta { get; set; }
        [DataMember]
        public decimal MontoMedico { get; set; }
        public int EntityId { get => IdEspecialidad; set => IdEspecialidad = value; }
    }
}
