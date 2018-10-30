using DA.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Policlinico
{
  public  class FarmaciaBL
    {
      FarmaciaDA gl = new FarmaciaDA();
      public int insertguiaGuiaFarmacia(GuiaFarmaciaCab g)
        {
            return gl.insertguiaGuiaFarmacia(g);
        }

      public int insertguiaGuiaFarmaciaBot(GuiaFarmaciaCab g)
      {
          return gl.insertguiaGuiaFarmaciaBot(g);
      }

      public int insertaDevolucion(GuiaCompraCab g)
        {
            return gl.insertaDevolucion(g);
        }

        public int insertaDevolucionArt(GuiaCompraCab g)
        {
            return gl.insertaDevolucionArt(g);
        }

        public List<RecetaFarmacia> getRecetaFarmacia(int Id_Guia, int tipo, int flag,int Busq)
      {
          return gl.getRecetaFarmacia(Id_Guia,  tipo,  flag, Busq);
      }

      public List<RecetaFarmacia> getRecetaFarmaciaCred(int Id_Guia, int tipo, int flag)
      {
          return gl.getRecetaFarmaciaCred(Id_Guia, tipo, flag);
      }

      public int updEstado(int Id_Guia, int estado, int idUsuario)
      {
          return gl.updEstado(Id_Guia, estado,idUsuario);
      }

      public List<DatosCredito> setCredito(int Id_Guia, decimal Total, int idUsuario, int idEstado)
      {
          return gl.setCredito(Id_Guia, Total, idUsuario, idEstado);
      }
      
      public int insertarAnulacion(int Id, int flag, int idAnulacion, string detalle, int idUsuario,int TipoBusqueda)
      {
          return gl.insertarAnulacion(Id, flag, idAnulacion, detalle, idUsuario, TipoBusqueda);
      }



      public DatosPaciente getDatos(string p)
      {
          return gl.getDatos(p);
      }

      public PacienteGuiaBE getDatosGuia(string p, int Busq)
      {
          return gl.getDatosGuia(p,Busq);
      }
        public PacienteGuiaBE getDatosGuiaSet(string p)
        {
            return gl.getDatosGuiaSet(p);
        }

        public PacienteGuiaBE getDatosGuiaCredito(string p)
      {
          return gl.getDatosGuiaCredito(p);
      }

      
      public List<ComboBE> getDatosPepasico(int p)
      {
          return gl.getDatosPepasico(p);
      }


      public int realizarReposicion()
      {
          return gl.realizarReposicion();
      }

      public int getGuiaCredito(int nroGuia)
      {
          return gl.getGuiaCredito(nroGuia);
      }

        public int verificaAnulacionFarmacia(int idUsuario, int IdNroGuia, int tipo)
        {
            return gl.verificaAnulacionFarmacia(idUsuario, IdNroGuia, tipo);
        }
    }

}
