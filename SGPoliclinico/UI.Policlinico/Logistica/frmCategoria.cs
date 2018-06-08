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
    public partial class frmCategoria : Form
    {
        public Form ParentForm { get; set; }
        GeneralBL generalBL = new GeneralBL();
        public frmCategoria()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvCategoria.AutoGenerateColumns = false;
            dgvCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategoria.MultiSelect = false;
            dgvCategoria.DataSource = generalBL.getGeneralList(2);




            cbServicios.DataSource = generalBL.getGeneralList(1);
            cbServicios.DisplayMember = "Descripcion";
            cbServicios.ValueMember = "Id";
            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            GeneralBE general = new GeneralBE();


            general.Id = lblCodigo.Text == "" ? 0 : int.Parse(lblCodigo.Text);
            general.Descripcion = txtTipo.Text;
            general.idServicio = Convert.ToInt32(cbServicios.SelectedValue);
            general.idUsuario = LoginInfo.UserID;
            general.flag = 2;

            generalBL.insertUpdGeneral(general);
            limpiar();

            Inicializar();

        }

        public void limpiar()
        {
            lblCodigo.Text = "";
            txtTipo.Text = "";
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            GeneralBE general = new GeneralBE();
            int Id = int.Parse(lblCodigo.Text == "" ? "0" : lblCodigo.Text);

            int val = Id > 0 ? generalBL.deleteGeneral(Id, 3) : 0;
            string msj = val == 0 ? "No se pudo eliminar el elemento seleccionado" : "Se eliminó correctamente";

            MessageBox.Show(msj);
            limpiar();
            Inicializar();
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvCategoria.ClearSelection();
            limpiar();
        }

        private void dgvCategoria_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCategoria.ClearSelection();
            limpiar();
        }

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvCategoria.CurrentRow;

            txtTipo.Text = row.Cells["Descripcion"].Value.ToString();
            lblCodigo.Text = row.Cells["Id"].Value.ToString();

            cbServicios.SelectedValue = Convert.ToInt32(row.Cells["idServicio"].Value.ToString());

        }

        private void dgvCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                dgvCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                int activeRow = dgvCategoria.CurrentCell.RowIndex;
                if ((activeRow + 1) < dgvCategoria.RowCount)
                {
                    dgvCategoria.CurrentCell = dgvCategoria.Rows[activeRow + 1].Cells[0];
                }
            }

            if (e.KeyCode == Keys.Delete)
            {

                int activeRow = dgvCategoria.CurrentCell.RowIndex;
                if ((activeRow + 1) < dgvCategoria.RowCount)
                {
                    dgvCategoria.CurrentCell = dgvCategoria.Rows[activeRow + 1].Cells[0];
                }
            }
        }



    }
}
