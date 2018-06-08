using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Policlinico
{
    public class ProveedorBE
    {

        public int Id { get; set; }
        public string RUC { get; set; }

        public string Razon_Social { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string observacion { get; set; }
        public int idEstado { get; set; }
        public string C_Nombre { get; set; }
        public string C_Telefono { get; set; }
        public string C_Email { get; set; }
        public int Id_Referencia { get; set; }
        public string Descripcion { get; set; }
        public int idUsuario { get; set; }

    }
}
