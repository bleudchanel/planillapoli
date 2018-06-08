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
    public partial class frmMenuLogistica : Form
    {
        public frmMenuLogistica()
        {
            InitializeComponent();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProveedor();
            frm.ParentForm = this;
            frm.Show();
        }

        private void medicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmMedicamentos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmServicio();
            frm.ParentForm = this;
            frm.Show();
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmTipo();
            frm.ParentForm = this;
            frm.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCategoria();
            frm.ParentForm = this;
            frm.Show();
        }

        private void unidadesDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUnidadesMedida();
            frm.ParentForm = this;
            frm.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

            var frm = new fmrGuiasFarmacia();
            frm.ParentForm = this;
            frm.Show();
        }
    }
}
