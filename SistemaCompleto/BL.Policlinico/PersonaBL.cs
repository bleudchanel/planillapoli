using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Policlinico;
using DA.Policlinico;

namespace BL.Policlinico
{
    public class PersonaBL
    {
        PersonaDA personaDA = new PersonaDA();
        public List<PersonaBE> getPersonaList()
        {
            return personaDA.getPersonaList();
        }

        public PersonaBE getPersonabyID(int PersonaID)
        {
            return personaDA.getPersonabyID(PersonaID);
        }

        public int insertPersona(PersonaBE Persona)
        {
            return personaDA.insertPersona(Persona);
        }

        public int editPersona(PersonaBE Persona)
        {
            return personaDA.editPersona(Persona);
        }

        public int deletePersona(int PersonaID)
        {
            return personaDA.deletePersona(PersonaID);
        }
    }
}
