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
    public partial class frmUnidadesMedida : Form
    {
         public Form ParentForm { get; set; }
         UnidadesBL generalBL = new UnidadesBL();
        public frmUnidadesMedida()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dvgUnidades.AutoGenerateColumns = false;
            dvgUnidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUnidades.MultiSelect = false;
            dvgUnidades.DataSource = generalBL.getUnidadesList();
           



        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            UnidadesBE general = new UnidadesBE();


            general.Id = lblCodigo.Text == "" ? 0 : int.Parse(lblCodigo.Text);
            general.Descripcion = txtDescripcion.Text;
            general.Abreviatura = txtAbreviatura.Text;
            general.idUsuario = LoginInfo.UserID;
         

            generalBL.insertUpdUnidades(general);
            limpiar();

            Inicializar();

        }

        public void limpiar()
        {
            lblCodigo.Text = "";
            txtDescripcion.Text = "";
            txtAbreviatura.Text = "";
        }

        private void dvgUnidades_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dvgUnidades_SelectionChanged(object sender, EventArgs e)
        {
            var row = dvgUnidades.CurrentRow;

            txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
            lblCodigo.Text = row.Cells["Id"].Value.ToString();

            txtAbreviatura.Text = row.Cells["Abreviatura"].Value.ToString();
        

        }

        private void dvgUnidades_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dgvTipos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dvgUnidades.ClearSelection();
            limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dvgUnidades.ClearSelection();
            limpiar();
        }





    }
}

