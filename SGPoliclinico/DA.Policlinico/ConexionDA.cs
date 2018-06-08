using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DA.Policlinico
{
    public class ConexionDA
    {
        public static string getConexion()
        {
            string conexion = String.Empty;

            conexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

            return conexion;
        }
    }
}
