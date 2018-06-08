using BL.Policlinico;
using Entity.Policlinico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Policlinico.Logistica
{
    public partial class frmServicio : Form
    {
        public Form ParentForm { get; set; }
        GeneralBL generalBL = new GeneralBL();
        public frmServicio()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvServicio.AutoGenerateColumns = false;
            dgvServicio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicio.MultiSelect = false;
            dgvServicio.DataSource = generalBL.getGeneralList(1);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GeneralBE general = new GeneralBE();


            general.Id = txtCodigo.Text == "" ? 0 : int.Parse(txtCodigo.Text);
            general.Descripcion = txtServicio.Text;
            general.idServicio = 0;
            general.idUsuario = LoginInfo.UserID;
            general.flag = 1;

            generalBL.insertUpdGeneral(general);
            limpiar();
            MessageBox.Show("Se ha registrado correctamente");
            Inicializar();

        }

        public void limpiar()
        {
            txtCodigo.Text = "";
            txtServicio.Text = "";
        }

        private void dgvServicio_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtServicio.Text = dgvServicio.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            txtCodigo.Text = dgvServicio.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }

        private void dgvServicio_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvServicio.CurrentRow;

            txtServicio.Text = row.Cells["Descripcion"].Value.ToString();
            txtCodigo.Text = row.Cells["Id"].Value.ToString();

        }

        private void dgvServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                dgvServicio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                int activeRow = dgvServicio.CurrentCell.RowIndex;
                if ((activeRow + 1) < dgvServicio.RowCount)
                {
                    dgvServicio.CurrentCell = dgvServicio.Rows[activeRow + 1].Cells[0];
                }
            }

            if (e.KeyCode == Keys.Delete)
            {

                int activeRow = dgvServicio.CurrentCell.RowIndex;
                if ((activeRow + 1) < dgvServicio.RowCount)
                {
                    dgvServicio.CurrentCell = dgvServicio.Rows[activeRow + 1].Cells[0];
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            GeneralBE general = new GeneralBE();
            int Id = int.Parse(txtCodigo.Text == "" ? "0" : txtCodigo.Text);

            int val = Id > 0 ? generalBL.deleteGeneral(Id, 1) : 0;
            string msj = val == 0 ? "No se pudo eliminar el elemento seleccionado" : "Se eliminó correctamente";

            MessageBox.Show(msj);
            limpiar();
            Inicializar();
        }

    }
}
