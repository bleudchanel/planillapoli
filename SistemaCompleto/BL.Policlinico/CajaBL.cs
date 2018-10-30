using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Policlinico
{
    public class CajaBL
    {
        CajaDA gl = new CajaDA();
        public List<CuotasOdontologicas> setPagoCuotaOdonto(int idCredito, int tipo_proc)
        {
            return gl.setPagoCuotaOdonto(idCredito, tipo_proc);
        }

        public List<CuotasOdontologicas> setCreditoTipo(int idCredito, int tipo)
        {
            return gl.setCreditoTipo(idCredito, tipo);
        }
      

        public List<Aportes> getAbonos(int idCredito, int tipo)
        {
            return gl.getAbonos(idCredito, tipo);
        }
        public int setAbono(int idCredito, decimal monto, int idUsuario)
        {
            return gl.setAbono(idCredito, monto, idUsuario);
        }

        public int setAbonoCredito(int idCredito, decimal monto, int idUsuario)
        {
            return gl.setAbonoCredito(idCredito, monto, idUsuario);
        }

        public PacienteCaja getDatosPacienteCaja(int NroGuia, int tipo)
        {
            return gl.getDatosPacienteCaja(NroGuia, tipo);
        }


        public int insertarAnulacion(int p1, int TipoAnulacion, string p3, int idUsuario, int tipo)
        {
            return gl.insertarAnulacion(p1, TipoAnulacion, p3, idUsuario, tipo);
        }

        public int verificaAnulacionCaja(int idUsuario, int Aporte, int tipo)
        {
            return gl.verificaAnulacionCaja(idUsuario, Aporte, tipo);
        }

        public int verificaAnulacionCajaAporte(int idUsuario, int Aporte, int tipo)
        {
            return gl.verificaAnulacionCajaAporte(idUsuario, Aporte, tipo);
        }




        public int cerrarCaja()
        {
            return gl.cerrarCaja();
        }

        public int habilitarGuia(string nroGuia, int tipo)
        {
            return gl.habilitarGuia(nroGuia, tipo);
        }

        public List<ComboBE> getDatosG(int valor)
        {
            return gl.getDatosG(valor);
        }

        public DataTable getNroGuia(int Tipo, string nroGuia, int flagN)
        {
            return gl.getNroGuia(Tipo, nroGuia, flagN);
        }
    }

}
