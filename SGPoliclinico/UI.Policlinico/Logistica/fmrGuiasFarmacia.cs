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
    public partial class fmrGuiasFarmacia : Form
    {
        MedicinaBL medicinaBL = new MedicinaBL();

        GuiaCompraFVBL gcompra = new GuiaCompraFVBL();
        public Form ParentForm { get; set; }
        GeneralBL generalBL = new GeneralBL();
        decimal Total = 0;
        int TipoCompra = 0;
        int TipoDoc = 0;
        public fmrGuiasFarmacia()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            dgvFormato.AutoGenerateColumns = false;
            dgvFormato.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormato.MultiSelect = false;
            
            List<ComboBE> comboProv = medicinaBL.getComboM(1);
            List<ComboBE> comboServ = medicinaBL.getComboM(5);
            List<ComboBE> comboMed = medicinaBL.getComboM(6);  
            llenarCMB(cmbProveedor, comboProv);
            llenarCMB(cmbServicio, comboServ);
            llenarCMB(cmbMedicamento, comboMed);
        }
        public void limpiar() {
            txtNroBoleta.Text = "";
          lblRUC.Text="-";
          lblDireccion.Text = "-";
           cmbMedicamento.SelectedValue="0";
           cmbProveedor.SelectedValue = "0";
           cmbServicio.SelectedValue = "0";
           txtTotal.Text = "Total S/.";
           txtStock.Text="";
           txtPreCosto.Text="";
           txtPrecioVenta.Text="";
           txtCantidad.Text="";
           dtpFechaRecepcion.Value = DateTime.Now;
            dtpVencimiento.Value=DateTime.Now;
            txtLote.Text="";
            dgvFormato.Rows.Clear();
            dgvFormato.Refresh();
          //  dgvFormato.ClearSelection();
        }

        public void llenarCMB(ComboBox cmb, List<ComboBE> combo)
        {

            cmb.DataSource = combo;
            cmb.DisplayMember = "Descripcion";
            cmb.ValueMember = "Id";
           // cmb.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GuiaCompraFVBE g = new GuiaCompraFVBE();

            g.NumGuiaCom =1;
            g.Tipo_Compra = TipoCompra;
           g.Id_Proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
           g.Tipo_Doc = TipoDoc;
           g.Num_Doc=txtNroBoleta.Text;
           g.Fecha_Recepcion = dtpFechaRecepcion.Value.ToString("dd/MM/yyyy"); 
           
           g.FechaVencimiento =  dtpVencimiento.Value.ToString("dd/MM/yyyy"); 
           g.Lote =txtLote.Text;
           g.Id_Servicio =Convert.ToInt32(cmbServicio.SelectedValue);

           g.Contado = 0;
           g.Id_Usuario =LoginInfo.UserID;

           foreach (DataGridViewRow row in dgvFormato.Rows)
           {

               g.Id_Medicamento =  Convert.ToInt32(row.Cells[1].Value);
               g.StockPrevio = Convert.ToInt32(row.Cells[2].Value);
               g.PreCosto = Convert.ToDecimal(row.Cells[3].Value);
               g.PreVenta = Convert.ToDecimal(row.Cells[4].Value);
               g.Cantidad = Convert.ToInt32(row.Cells[5].Value);
               g.SubTotal = Convert.ToDecimal(row.Cells[6].Value);
               gcompra.insertUpdGuiaCompra(g);
            }
           
           
          limpiar();

            Inicializar();
        }
        private void rbtNormal_CheckedChanged(object sender, EventArgs e)
        {
            TipoCompra = 1;
        }
        private void rbtDonacion_CheckedChanged(object sender, EventArgs e)
        {
            TipoCompra = 2;
        }  

        private void rbtFactura_CheckedChanged(object sender, EventArgs e)
        {
            TipoDoc = 3;
        }

        private void rbtBoleta_CheckedChanged(object sender, EventArgs e)
        {
            TipoDoc = 4;
        }
        private void rbtOtro_CheckedChanged(object sender, EventArgs e)
        {
            TipoDoc = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            decimal subTotal=0;
            subTotal = int.Parse(txtCantidad.Text) * Convert.ToDecimal(txtPreCosto.Text);
            Total += subTotal;
            txtTotal.Text = "Total S/.: " + Total.ToString();
            string med = cmbMedicamento.Text.ToString();
            string cod = cmbMedicamento.SelectedValue.ToString();
            string stock = txtStock.Text;
            string precosto =txtPreCosto.Text;
            string preventa = txtPrecioVenta.Text;
            string cant = txtCantidad.Text;
            string subtotal = subTotal.ToString();
            string fecVen = dtpVencimiento.Value.ToString("dd/MM/yyyy");
            string Lote = txtLote.Text;
            string[] row = { med, cod, stock, precosto, preventa, cant, subtotal, fecVen, Lote };
            dgvFormato.Rows.Add(row);
        }

        private void btnMedicina_Click(object sender, EventArgs e)
        {
            var frm = new frmMedicamentos();
            frm.ParentForm = this;
            frm.Show();
        }

        private void btnActM_Click(object sender, EventArgs e)
        {
            List<ComboBE> comboMed = medicinaBL.getComboM(6);
      
            llenarCMB(cmbMedicamento, comboMed);
        }

        private void dgvFormato_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFormato.ClearSelection();
        }
    }
}
