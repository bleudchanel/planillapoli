using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Policlinico;
using Entity.Policlinico;

namespace UI.Policlinico
{
    public partial class PersonaAddEdit : Form
    {
        public Form ParentForm { get; set; }
        public int PersonaID { get; set; }
        PersonaBL personaBL = new PersonaBL();
        public PersonaAddEdit(int PersonaID = 0)
        {
            InitializeComponent();

            if (PersonaID != 0)
            {
                this.PersonaID = PersonaID;
                FillData(PersonaID);
                btnAceptar.Text = "Editar";
            }
            else
            {
                btnAceptar.Text = "Guardar";
            }
        }

        public void FillData(int PersonaID)
        {
            PersonaBE persona = new PersonaBE();
            persona = personaBL.getPersonabyID(PersonaID);
            txtDNI.Text = persona.dni;
            txtPaterno.Text = persona.paterno;
            txtMaterno.Text = persona.materno;
            txtNombres.Text = persona.nombres;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PersonaBE persona = new PersonaBE();
            persona.dni = txtDNI.Text;
            persona.paterno = txtPaterno.Text;
            persona.materno = txtMaterno.Text;
            persona.nombres = txtNombres.Text;

            if (this.PersonaID > 0)
            {
                persona.id = this.PersonaID;

                personaBL.editPersona(persona);
                MessageBox.Show("La Persona se actualizó correctamente");
            }
            else //Es un nuevo registro de Usuario
            {
                personaBL.insertPersona(persona);
                MessageBox.Show("Se ha registrado a la Persona correctamente");
            }

            //Refresh la lista
            var frm = (Persona)this.ParentForm;
            frm.Inicializar();

            this.Close();
        }
    }
}
