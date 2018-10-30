using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;
using DA.Policlinico;
using System.Data;

namespace BL.Policlinico
{
    public class PacienteNuevoBL
    {
        PacienteNuevoDA p =  new PacienteNuevoDA();
        public string addPaciente(PersonaPaciente Persona)
        {
            return p.insertPersona(Persona);
        }

        public int verificaPersonaTipo(string codPac, int tipoPac)
        {
            return p.verificaPersonaTipo(codPac, tipoPac);
        }

            public PersonaPaciente getDatosPaciente(string id)
        {
            return p.getDatosPaciente(id);
        }

        public DataTable getDatosPacienteDT(string id)
        {
            return p.getDatosPacienteDT(id);
        }

        public List<PersonaPaciente> getPacienteRegistrado(string fecha)
        {
            return p.getPacienteRegistrado(fecha);
        }




        public DataTable busquedaPaciente(string paciente)
        {
            return p.busquedaPaciente(paciente);
        }

        public int addUsuarioDetalle(string ApePaterno, string ApeMaterno, string nombres, string NroDocumento, string Pass, string idEstado,string guia, List<int> val)
        {

            return p.addUsuarioDetalle(ApePaterno, ApeMaterno, nombres, NroDocumento, Pass, idEstado, guia, val);
        }

        public List<Usuario> getUsuario(string DNI)
        {
            return p.getUsuario(DNI);
        }

        public List<int> getPermisoMenu(string idPersona)
        {
            return p.getPermisoMenu(idPersona);
        }

        public int verificaTitular(string codHistoria)
        {
            return p.verificaTitular(codHistoria);
        }


        public int eliminaPaciente(string codHistoria)
        {
            return p.eliminaPaciente(codHistoria);
        }

        
    }
}
