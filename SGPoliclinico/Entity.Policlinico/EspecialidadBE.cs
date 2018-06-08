using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Policlinico
{
    public class EspecialidadBE
    {
        private int id=0;
        private string codEsp = "";
        private string descripcion = "";
        private double precioConsulta = 0;
        private double montoMedico = 0;
        private int estado = -1;
        private string estadoDesc = "";
        private DateTime fechaRegistro;
        private DateTime fechaBaja;

        public int Id { get => id; set => id = value; }
        public string CodEsp { get => codEsp; set => codEsp = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double PrecioConsulta { get => precioConsulta; set => precioConsulta = value; }
        public double MontoMedico { get => montoMedico; set => montoMedico = value; }
        public int Estado { get => estado; set => estado = value; }
        public string EstadoDesc { get => estadoDesc; set => estadoDesc = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaBaja { get => fechaBaja; set => fechaBaja = value; }
    }
}
