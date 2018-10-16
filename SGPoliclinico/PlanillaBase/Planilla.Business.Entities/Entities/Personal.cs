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
    [Table("pPersonal", Schema = "Planilla")]
    public class Personal : EntityBase, IIdentifiableEntity
    {
        public Personal(string dNI, string apePaterno, string apeMaterno, string nombre, string direccion, 
            int? idUbigeo, string codDistrito, DateTime? fecNac, string telefono, string celular, string email, 
            string sex, string estadoCivil, byte? numHij, DateTime? fecIngreso, string estudios, string grado, string numCol, 
            int? idAreaServicio, string codAre, int? idCargo, string codCar, int? idFondoPen, string codFon, string tipComAFP, 
            string cUSPP, string eVida, decimal? remBas, decimal? asiFam, decimal? rieCaj, string sCTR, int? horLab, string observacion, 
            string estado, DateTime? fecBaja, string entidadCTS, string numCtaCTS, byte customDiasHoras, byte customDias, byte customHoras)
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
            Sex = sex;
            EstadoCivil = estadoCivil;
            NumHij = numHij;
            FecIngreso = fecIngreso;
            Estudios = estudios;
            Grado = grado;
            NumCol = numCol;
            IdAreaServicio = idAreaServicio;
            CodAre = codAre;
            IdCargo = idCargo;
            CodCar = codCar;
            IdFondoPen = idFondoPen;
            CodFon = codFon;
            TipComAFP = tipComAFP;
            CUSPP = cUSPP;
            EVida = eVida;
            RemBas = remBas;
            AsiFam = asiFam;
            RieCaj = rieCaj;
            SCTR = sCTR;
            HorLab = horLab;
            Observacion = observacion;
            Estado = estado;
            FecBaja = fecBaja;
            EntidadCTS = entidadCTS;
            NumCtaCTS = numCtaCTS;
            
            CustomDiasHoras = customDiasHoras;
            CustomDias = customDias;
            CustomHoras = customHoras;
        }

        public Personal()
        {

        }

        public string GetNombre()
        {
            return ApePaterno + " " + ApeMaterno + ", " + Nombre;
        }

        [DataMember]
        [Column("Id")]
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
        [DataMember]
        public byte CustomDiasHoras { get; set; }
        [DataMember]
        public byte CustomDias { get; set; }
        [DataMember]
        public byte CustomHoras { get; set; }

        public int EntityId { get => IdPersonal; set => IdPersonal = value; }
    }
}
