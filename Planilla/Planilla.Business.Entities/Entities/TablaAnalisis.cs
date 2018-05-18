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
    [Table("TablaAnalisis", Schema = "Planilla")]
    public class TablaAnalisis : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int IdAnalisis { get; set; }
        [DataMember]
        public string CodAna { get; set; }
        [DataMember]
        public string Analisis { get; set; }
        [DataMember]
        public string Unidad { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public Nullable<int> IdProcedimiento { get; set; }
        [DataMember]
        public string CodPro { get; set; }
        [DataMember]
        public string Procedimiento { get; set; }
        [DataMember]
        public string AreaLaboratorio { get; set; }
        [DataMember]
        public string AreaAnalisis { get; set; }
        [DataMember]
        public string TituloPerfil { get; set; }
        public int EntityId { get => IdAnalisis; set => IdAnalisis = value; }
    }
}
