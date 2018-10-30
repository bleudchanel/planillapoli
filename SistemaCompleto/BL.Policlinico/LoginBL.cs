using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Policlinico;
using Entity.Policlinico;

namespace BL.Policlinico
{
    public class LoginBL
    {
        LoginDA loginDA = new LoginDA();
        public int getUsuarioIdbyLogin(string nroDocumento, string passUser, string ipUser)
        {
            return loginDA.getUsuarioIdbyLogin(nroDocumento, passUser, ipUser);
        }

        public LoginBE getSimpleDataUsuario(int idUser)
        {
            return loginDA.getSimpleDataUsuario(idUser);
        }
    }
}
