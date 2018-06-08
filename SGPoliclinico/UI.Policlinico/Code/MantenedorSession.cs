using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Policlinico.Code
{
    public static class MantenedorSession
    {
        private static string user;
        private static string nombres;
        private static string rol;
        private static string fechaIngreso;

        public static string User { get => user; set => user = value; }
        public static string Nombres { get => nombres; set => nombres = value; }
        public static string Rol { get => rol; set => rol = value; }
        public static string FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
    }
}
