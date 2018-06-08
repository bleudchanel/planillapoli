
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

    public partial class frmProveedor : Form
    {
        public Form ParentForm { get; set; }
        ProveedorBL pbl = new ProveedorBL();
        GeneralBL generalBL = new GeneralBL();
        public frmProveedor()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.DataSource = pbl.getProveedorList();




            cbServicios.DataSource = generalBL.getGeneralList(1);
            cbServicios.DisplayMember = "Descripcion";
            cbServicios.ValueMember = "Id";
            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            ProveedorBE pbe = new ProveedorBE();
            pbe.Id = lblCodigo.Text == "" ? 0 : int.Parse(lblCodigo.Text);
            pbe.RUC = txtRUC.Text;

            pbe.Razon_Social = txtRS.Text;
            pbe.Direccion = txtDireccion.Text;
            pbe.Telefono = txtTelefono.Text;
            pbe.Email = txtEmail.Text;
            pbe.observacion = "";
            pbe.idEstado = Convert.ToInt32(cboEstado.SelectedValue);
            pbe.C_Nombre = txtNombreContacto.Text;
            pbe.C_Telefono = txtTelefonoContacto.Text;
            pbe.C_Email = txtEmailContacto.Text;
            pbe.Id_Referencia = Convert.ToInt32(cbServicios.SelectedValue);
            pbe.idUsuario = LoginInfo.UserID;


            pbl.insertUpdProveedor(pbe);
            limpiar();
            Inicializar();
        }


        public void limpiar()
        {
            lblCodigo.Text = "";
            txtRUC.Text = "";
            txtRS.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNombreContacto.Text = "";
            txtTelefonoContacto.Text = "";
            txtEmailContacto.Text = "";
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvProveedores.ClearSelection();
            limpiar();
        }



        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvProveedores.CurrentRow;

            lblCodigo.Text = row.Cells["Id"].Value.ToString();
            txtRUC.Text = row.Cells["RUC"].Value.ToString();
            txtRS.Text = row.Cells["Razon_Social"].Value.ToString();
            txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
        //    txtNombreContacto.Text = row.Cells["C_Nombre"].Value.ToString();
           // txtTelefonoContacto.Text = row.Cells["C_Telefono"].Value.ToString();
          //  txtEmailContacto.Text = row.Cells["C_Email"].Value.ToString();
           

            cbServicios.SelectedValue = Convert.ToInt32(row.Cells["idServicio"].Value.ToString());

        }

        private void dgvProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                int activeRow = dgvProveedores.CurrentCell.RowIndex;
                if ((activeRow + 1) < dgvProveedores.RowCount)
                {
                    dgvProveedores.CurrentCell = dgvProveedores.Rows[activeRow + 1].Cells[0];
                }
            }

            if (e.KeyCode == Keys.Delete)
            {

                int activeRow = dgvProveedores.CurrentCell.RowIndex;
                if ((activeRow + 1) < dgvProveedores.RowCount)
                {
                    dgvProveedores.CurrentCell = dgvProveedores.Rows[activeRow + 1].Cells[0];
                }
            }
        }

        private void dgvProveedores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProveedores.ClearSelection();
            limpiar();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
