using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Policlinico
{
    public class PersonaBE
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombres { get; set; }
        public int estado { get; set; }
    }
}
