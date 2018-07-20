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
    [Table("dMedicos", Schema = "Planilla")]
    public class Medico : EntityBase, IIdentifiableEntity
    {
        public Medico(string dNI, string apePaterno, string apeMaterno, string nombre, string direccion, int? idUbigeo, string codDistrito, DateTime? fecNac, string telefono, string celular, string email, string rUC, DateTime? fecIngreso, string grado, string numCol, string sit, string rNE, int? idEspecialidad1, string codEsp1, int? idEspecialidad2, string codEsp2, string estado, string tipo)
        {
            DNI = dNI;
            ApePaterno = apePaterno;
            ApeMaterno = apeMaterno;
            Nombre = nombre;
            Direccion = direccion;
            IdUbigeo = idUbigeo;
            CodDistrito = codDistrito;
            FecNac = fecNac;
            Telefono = telefono;
            Celular = celular;
            Email = email;
            RUC = rUC;
            FecIngreso = fecIngreso;
            Grado = grado;
            NumCol = numCol;
            Sit = sit;
            RNE = rNE;
            IdEspecialidad1 = idEspecialidad1;
            CodEsp1 = codEsp1;
            IdEspecialidad2 = idEspecialidad2;
            CodEsp2 = codEsp2;
            Estado = estado;
            Tipo = tipo;
        }

        public Medico()
        {
        }

        [DataMember]
        [Column("Id_Medico")]
        public int IdMedico { get; set; }
        [DataMember]
        public string CodMed { get; set; }
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
        public string RUC { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FecIngreso { get; set; }
        [DataMember]
        public string Grado { get; set; }
        [DataMember]
        public string NumCol { get; set; }
        [DataMember]
        public string Sit { get; set; }
        [DataMember]
        public string RNE { get; set; }
        [DataMember]
        [Column("Id_Especialidades1")]
        public Nullable<int> IdEspecialidad1 { get; set; }
        [DataMember]
        public string CodEsp1 { get; set; }
        [DataMember]
        [Column("Id_Especialidades2")]
        public Nullable<int> IdEspecialidad2 { get; set; }
        [DataMember]
        public string CodEsp2 { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        public int EntityId { get => IdMedico; set => IdMedico = value; }
    }
}
