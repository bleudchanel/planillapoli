using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Policlinico.Logistica;
using UI.Policlinico.Personal;
using Planilla.Client.Desktop;


namespace UI.Policlinico.Dashboard
{
    public partial class frmPanelControl : Form
    {
        public Form ParentForm { get; set; }
        public frmPanelControl()
        {
            InitializeComponent();
        }

        private void btnPanelLogistica_Click(object sender, EventArgs e)
        {
            var frm = new frmMenuLogistica();         
            frm.Show();
        }

        private void btnPanelPersonal_Click(object sender, EventArgs e)
        {
            var frm = new frmPrincipal();
            frm.Show();

        }

        private void frmPanelControl_Load(object sender, EventArgs e)
        { 
            this.Icon = UI.Policlinico.Properties.Resources.LOGO;
            this.Name = "Policlínico \"Nuestra Señora del Sagrado Corazón\" MENU ACCESOS";
        }
    }
}
