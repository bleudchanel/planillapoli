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
    public partial class frmMedicamentos : Form
    {
        MedicinaBL medicinaBL = new MedicinaBL();
        public Form ParentForm { get; set; }
        public frmMedicamentos()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvMedicamentos.AutoGenerateColumns = false;
            dgvMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicamentos.MultiSelect = false;
            //dgvMedicamentos.DataSource = generalBL.getGeneralList(2);
            
            List<ComboBE> comboProv=medicinaBL.getComboM(1);
            List<ComboBE> comboTip=medicinaBL.getComboM(2);
            List<ComboBE> comboCat=medicinaBL.getComboM(3);
            List<ComboBE> comboUM=medicinaBL.getComboM(4);

            var comboRef = new List<ComboBE>();
            comboRef.Add(new ComboBE() { Id = 1, Descripcion = "Farmacia" });
            comboRef.Add(new ComboBE() { Id = 2, Descripcion = "Transferencia" });
            comboRef.Add(new ComboBE() { Id = 3, Descripcion = "Farmacia / Transferencia" });

            llenarCMB(cmbProveedor, comboProv);
            llenarCMB(cmbTipo, comboTip);
            llenarCMB(cmbCategoria, comboCat);
            llenarCMB(cmbUnidad, comboUM);
            llenarCMB(cmbReferencia, comboRef);

        }
        public void llenarCMB(ComboBox cmb,List<ComboBE> combo) {

            cmb.DataSource = combo;
            cmb.DisplayMember = "Descripcion";
            cmb.ValueMember = "Id";
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            MedicinaBE g = new MedicinaBE();
            g.Codigo=txtCodigo.Text;
          g.Descripcion=txtMedicamento.Text;
          g.Id_Proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
          g.Id_Tipo = Convert.ToInt32(cmbTipo.SelectedValue);
          g.Id_Categoria = Convert.ToInt32(cmbCategoria.SelectedValue);
          g.Id_Unidad = Convert.ToInt32(cmbUnidad.SelectedValue);
          g.Id_Referencia = Convert.ToInt32(cmbReferencia.SelectedValue);
          g.StockMin = int.Parse(txtStockMinimo.Text == "" ? "0" : txtStockMinimo.Text);
          g.StockAct = int.Parse(txtStockActual.Text == "" ? "0" : txtStockActual.Text);
          g.PreCosto = decimal.Parse(txtPrecioCosto.Text == "" ? "0" : txtPrecioCosto.Text);
          g.PreVenta = decimal.Parse(txtPrecioVenta.Text == "" ? "0" : txtPrecioVenta.Text);
          g.FechaVencimiento=null;
          g.Lote=null;
          g.IdUsuario=LoginInfo.UserID;
    

            medicinaBL.insertUpdMedicina(g);
         //   limpiar();

            Inicializar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
