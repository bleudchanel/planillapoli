using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Policlinico.Code;

namespace UI.Policlinico.Personal
{
    public partial class frm0000MenuPersonal : Form
    {
        public frm0000MenuPersonal()
        {
            InitializeComponent();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frm0001Especialidad();
            frm.ParentForm = this;
            frm.Show();
        }

        private void procedimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProcedimientos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void procedimientosDeLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProcedimientosLaboratorios();
            frm.ParentForm = this;
            frm.Show();
        }

        private void analisisDeLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAnalisisLaboratorio();
            frm.ParentForm = this;
            frm.Show();
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmMedicos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPersonal();
            frm.ParentForm = this;
            frm.Show();
        }

        private void reportesDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmReporteVacaciones();
            frm.ParentForm = this;
            frm.Show();
        }

        private void programacionYEjecuciónDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProgramacionVacaciones();
            frm.ParentForm = this;
            frm.Show();
        }

        private void especificacionesDeDiasLaborablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDiaLaborales();
            frm.ParentForm = this;
            frm.Show();
        }

        private void conceptosAportesEmpleadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmConceptoAportes();
            frm.ParentForm = this;
            frm.Show();
        }

        private void entidadesFondoDePensionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEntidadesFondoPensiones();
            frm.ParentForm = this;
            frm.Show();
        }

        private void areasServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAreasServicios();
            frm.ParentForm = this;
            frm.Show();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCargos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void generarPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGenerarPlanilla();
            frm.ParentForm = this;
            frm.Show();
        }

        private void imprimirPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmImprimirPlanilla();
            frm.ParentForm = this;
            frm.Show();
        }

        private void eliminarPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEliminarPlanilla();
            frm.ParentForm = this;
            frm.Show();
        }

        private void generarPlanillaDeGratificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGenerarPlanillaGratificaciones();
            frm.ParentForm = this;
            frm.Show();
        }

        private void imprimirPlanillaDeGratificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmImprimirPlanillaGratificaciones();
            frm.ParentForm = this;
            frm.Show();
        }

        private void generarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGenerarArchivo();
            frm.ParentForm = this;
            frm.Show();

        }

        private void resumenAnualDePlanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmResumenAnualDePlanillas();
            frm.ParentForm = this;
            frm.Show();
        }

        private void proyecciónDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProyeccionDePagos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void pDTPLAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPFTPlame();
            frm.ParentForm = this;
            frm.Show();
        }

        private void gestionDeContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGestionDeContratos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void gestionDeCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmGestionDeCTS();
            frm.ParentForm = this;
            frm.Show();
        }

        private void resumenCTSPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmResumenCTSPorPeriodo();
            frm.ParentForm = this;
            frm.Show();
        }

        private void MedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmMedicos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void PersonalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new frmPersonal();
            frm.ParentForm = this;
            frm.Show();
        }

        private void frmMenuPersonal_Load(object sender, EventArgs e)
        {
            imagFondo.Width = this.Width;
            imagFondo.Height = this.Height;
            UserDToolStripStatus.Text = MantenedorSession.Nombres;
            DateToolStripStatus.Text = MantenedorSession.FechaIngreso;
            this.Icon = UI.Policlinico.Properties.Resources.PERSONAL;
            this.Name = "Policlínico \"Nuestra Señora del Sagrado Corazón\" - Módulo de PERSONAL";
        }
    }
}
