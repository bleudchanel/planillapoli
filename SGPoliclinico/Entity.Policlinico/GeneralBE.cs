using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Policlinico
{
    public class GeneralBE
    {
        public int Id { get; set; }

        public string TipoDescripcion { get; set; }
        public string Descripcion { get; set; }
        public int idEstado { get; set; }
        public int idServicio { get; set; }
        public int flag { get; set; }
        public int idUsuario { get; set; }

    }
}
