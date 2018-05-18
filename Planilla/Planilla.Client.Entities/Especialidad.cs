using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planilla.Client.Entities
{

    public class Especialidad
    {
        int _EspecialidadId;
        string _CodEsp;
        string _Descripcion;
        decimal _PrecioConsulta;
        decimal _MontoMedico;

        public int EspecialidadId
        {
            get
            {
                return _EspecialidadId;
            }
            set
            {
                _EspecialidadId = value;
            }
        }

        public string CodEsp { get => _CodEsp; set => _CodEsp = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public decimal PrecioConsulta { get => _PrecioConsulta; set => _PrecioConsulta = value; }
        public decimal MontoMedico { get => _MontoMedico; set => _MontoMedico = value; }
        
    }
}
