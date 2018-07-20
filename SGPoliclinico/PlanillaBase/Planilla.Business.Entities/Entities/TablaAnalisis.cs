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
    [Table("Lab_TablaAnalisis", Schema = "Planilla")]
    public class TablaAnalisis : EntityBase, IIdentifiableEntity
    {
        public TablaAnalisis(string analisis, string unidad, int? idProcedimiento, string codPro, string procedimiento, string areaAnalisis)
        {
            Analisis = analisis;
            Unidad = unidad;
            Titulo = "";
            IdProcedimiento = idProcedimiento;
            CodPro = codPro;
            Procedimiento = procedimiento;
            AreaLaboratorio = areaAnalisis;
            AreaAnalisis = areaAnalisis;
            TituloPerfil = "Empty";            
        }

        public TablaAnalisis()
        { }

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
        [Column("Id_Procedimiento")]
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
