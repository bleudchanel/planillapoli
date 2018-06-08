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
    public partial class frmTipo : Form
    {
        public Form ParentForm { get; set; }
        GeneralBL generalBL = new GeneralBL();
        public frmTipo()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvTipos.AutoGenerateColumns = false;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.MultiSelect = false;
            dgvTipos.DataSource = generalBL.getGeneralList(3);
            dgvTipos.Rows[0].Cells[0].Selected = false;



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
            general.flag = 3;

            generalBL.insertUpdGeneral(general);
            limpiar();

            Inicializar();

        }

        public void limpiar()
        {
            lblCodigo.Text = "";
            txtTipo.Text = "";
        }

        private void dgvTipos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvTipos_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvTipos.CurrentRow;

            txtTipo.Text = row.Cells["Descripcion"].Value.ToString();
            lblCodigo.Text = row.Cells["Id"].Value.ToString();

            cbServicios.SelectedValue = Convert.ToInt32(row.Cells["idServicio"].Value.ToString());

        }

        private void dgvTipos_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dgvTipos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTipos.ClearSelection();
            limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvTipos.ClearSelection();
            limpiar();
        }





    }
}
