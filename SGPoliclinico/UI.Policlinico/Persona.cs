using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity.Policlinico;
using BL.Policlinico;

namespace UI.Policlinico
{
    public partial class Persona : Form
    {
        PersonaBL personaBL = new PersonaBL();
        public Persona()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvPersona.DataSource = personaBL.getPersonaList();
            dgvPersona.Columns[0].Visible = false;
        }

        private void btnNuevaPersona_Click(object sender, EventArgs e)
        {
            var frm = new PersonaAddEdit();
            frm.ParentForm = this;
            frm.Show();
        }

        private void btnEditarPersona_Click(object sender, EventArgs e)
        {
            if (dgvPersona.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvPersona.SelectedRows[0].Cells["id"].Value);

                var frm = new PersonaAddEdit(id);
                frm.ParentForm = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No hay Usuario seleccionado");
            }
        }

        private void btnEliminarPersona_Click(object sender, EventArgs e)
        {
            if (dgvPersona.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvPersona.SelectedRows[0].Cells["id"].Value);

                var confirm = MessageBox.Show("¿Está seguro de Eliminar la fila seleccionada?",
                                     "Mensaje del Sistema",
                                     MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var persona = new PersonaBE();
                    personaBL.deletePersona(id);
                    MessageBox.Show("Eliminado correctamente");
                    Inicializar();
                }
            }
            else
            {
                MessageBox.Show("No hay Usuario seleccionado");
            }
        }
    }
}
