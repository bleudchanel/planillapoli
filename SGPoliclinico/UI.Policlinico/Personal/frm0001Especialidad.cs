using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Policlinico;
using Entity.Policlinico;

namespace UI.Policlinico.Personal
{
    public partial class frm0001Especialidad : Form
    {
        public Form ParentForm { get; set; }

        EspecialidadBL eda = new EspecialidadBL();
        EspecialidadBE ebe = new EspecialidadBE();
        EspecialidadBE ebs = new EspecialidadBE();
        int flagAcc = -1;

        public frm0001Especialidad()
        {
            InitializeComponent();
        }

        private void frmEspecialidad_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = UI.Policlinico.Properties.Resources.PERSONAL;
                this.Name = "Mantenimiento de Especialidad";

                ComboboxItem item0 = new ComboboxItem();
                item0.Text = "--Seleccione--";
                item0.Value = -1;
                cbEstado.Items.Add(item0);
                cbEstadoB.Items.Add(item0);

                ComboboxItem item2 = new ComboboxItem();
                item2.Text = "Inactivo";
                item2.Value = 0;
                cbEstado.Items.Add(item2);
                cbEstadoB.Items.Add(item2);

                ComboboxItem item1 = new ComboboxItem();
                item1.Text = "Activo";
                item1.Value = 1;
                cbEstado.Items.Add(item1);
                cbEstadoB.Items.Add(item1);

                cbEstado.SelectedIndex = 0;
                cbEstadoB.SelectedIndex = 0;

                txtCodigoB.Text = "Ingrese Código";
                txtCodigoB.ForeColor = Color.Gray;
                txtDescripcionB.Text = "Ingrese Especialidad";
                txtDescripcionB.ForeColor = Color.Gray;

                dgvEspecialidades.AutoGenerateColumns = false;
                dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEspecialidades.MultiSelect = false;
                dgvEspecialidades.DataSource = eda.getEspecialidadList(ebs);

                flagAcc = -1;
                btnNuevo.Visible = true;
                BtnGrabar.Visible = false;
                btnCancelar.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtDescripcionB_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDescripcionB.Equals("Ingrese Código"))
            {
                txtDescripcionB.Text = "";
                txtDescripcionB.ForeColor = Color.Black;
            }
        }

        private void txtCodigoB_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCodigoB.Equals("Ingrese Código"))
            {
                txtCodigoB.Text = "";
                txtCodigoB.ForeColor = Color.Black;
            }
        }

        private void dgvEspecialidades_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (flagAcc == -1)
                {
                    var row = dgvEspecialidades.CurrentRow;
                    ebe.Id = int.Parse(row.Cells["Id"].Value.ToString());
                    lblCodido.Text = row.Cells["CodEsp"].Value.ToString();
                    txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                    txtPrecCon.Text = double.Parse(row.Cells["PrecioConsulta"].Value.ToString()).ToString("0.00");
                    txtMontMedic.Text = double.Parse(row.Cells["MontoMedico"].Value.ToString()).ToString("0.00");
                    cbEstado.SelectedIndex = int.Parse(row.Cells["estado"].Value.ToString());

                    flagAcc = 2;
                    btnNuevo.Visible = false;
                    BtnGrabar.Visible = true;
                    btnCancelar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            { 
                ebs = new EspecialidadBE();

                if (txtCodigoB.Equals("Ingrese Código"))
                    ebs.CodEsp = txtCodigoB.Text;
                else
                    ebs.CodEsp = "";

                if (txtDescripcionB.Equals("Ingrese Código"))
                    ebs.Descripcion = txtDescripcionB.Text;
                else
                    ebs.Descripcion = "";

                ebs.Estado = int.Parse(cbEstadoB.SelectedIndex.ToString())-1;

                dgvEspecialidades.AutoGenerateColumns = false;
                dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEspecialidades.MultiSelect = false;
                dgvEspecialidades.DataSource = eda.getEspecialidadList(ebs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ebe = new EspecialidadBE();
            flagAcc = -1;
            lblCodido.Text = "-";
            txtDescripcion.Text = "";
            txtPrecCon.Text = "0.00";
            txtMontMedic.Text = "0.00";
            cbEstado.SelectedIndex = 0;

            btnNuevo.Visible = true;
            BtnGrabar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                flagAcc = 1;
                ebe = new EspecialidadBE();
                ebe = eda.getEspecialidadCod();
                lblCodido.Text = ebe.CodEsp;

                btnNuevo.Visible = false;
                BtnGrabar.Visible = true;
                btnCancelar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                double PrecCon = 0, MonMed = 0;
                Boolean ValN = double.TryParse(txtPrecCon.Text, out PrecCon) && double.TryParse(txtMontMedic.Text, out MonMed);

                if (flagAcc == 1 && !txtDescripcion.Text.Equals("") && int.Parse(cbEstado.SelectedIndex.ToString()) != -1 && ValN)
                {
                    ebe.Descripcion = txtDescripcion.Text;
                    ebe.Estado = int.Parse(cbEstado.SelectedIndex.ToString());
                    ebe.MontoMedico = MonMed;
                    ebe.PrecioConsulta = PrecCon;

                    eda.insertEspecialidad(ebe);

                    ebe = new EspecialidadBE();
                    flagAcc = -1;
                    lblCodido.Text = "-";
                    txtDescripcion.Text = "";
                    txtPrecCon.Text = "0.00";
                    txtMontMedic.Text = "0.00";
                    cbEstado.SelectedIndex = 0;

                    btnNuevo.Visible = true;
                    BtnGrabar.Visible = false;
                    btnCancelar.Visible = false;

                    ebs = new EspecialidadBE();

                    if (txtCodigoB.Equals("Ingrese Código"))
                        ebs.CodEsp = txtCodigoB.Text;
                    else
                        ebs.CodEsp = "";

                    if (txtDescripcionB.Equals("Ingrese Código"))
                        ebs.Descripcion = txtDescripcionB.Text;
                    else
                        ebs.Descripcion = "";

                    ebs.Estado = int.Parse(cbEstadoB.SelectedIndex.ToString()) - 1;

                    dgvEspecialidades.AutoGenerateColumns = false;
                    dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEspecialidades.MultiSelect = false;
                    dgvEspecialidades.DataSource = eda.getEspecialidadList(ebs);

                    MessageBox.Show("Especialidad Resgistrada.", "ESTADO REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (flagAcc == 2 && !txtDescripcion.Text.Equals("") && int.Parse(cbEstado.SelectedIndex.ToString()) != -1 && ValN)
                {
                    ebe.Descripcion = txtDescripcion.Text;
                    ebe.Estado = int.Parse(cbEstado.SelectedIndex.ToString());
                    ebe.MontoMedico = MonMed;
                    ebe.PrecioConsulta = PrecCon;

                    eda.editEspecialidad(ebe);

                    ebe = new EspecialidadBE();
                    flagAcc = -1;
                    lblCodido.Text = "-";
                    txtDescripcion.Text = "";
                    txtPrecCon.Text = "0.00";
                    txtMontMedic.Text = "0.00";
                    cbEstado.SelectedIndex = 0;

                    btnNuevo.Visible = true;
                    BtnGrabar.Visible = false;
                    btnCancelar.Visible = false;

                    ebs = new EspecialidadBE();

                    if (txtCodigoB.Equals("Ingrese Código"))
                        ebs.CodEsp = txtCodigoB.Text;
                    else
                        ebs.CodEsp = "";

                    if (txtDescripcionB.Equals("Ingrese Código"))
                        ebs.Descripcion = txtDescripcionB.Text;
                    else
                        ebs.Descripcion = "";

                    ebs.Estado = int.Parse(cbEstadoB.SelectedIndex.ToString()) - 1;

                    dgvEspecialidades.AutoGenerateColumns = false;
                    dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEspecialidades.MultiSelect = false;
                    dgvEspecialidades.DataSource = eda.getEspecialidadList(ebs);

                    MessageBox.Show("Especialidad Actualizada.", "ESTADO REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("Debe Ingresar una Descripcion.", "ESTADO REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (int.Parse(cbEstado.SelectedIndex.ToString()) != -1)
                    {
                        MessageBox.Show("Debe Seleccionar un Estado.", "ESTADO REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (double.TryParse(txtPrecCon.Text, out PrecCon))
                    {
                        MessageBox.Show("Debe Seleccionar un Precio Consulta.", "ESTADO REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (double.TryParse(txtMontMedic.Text, out MonMed))
                    {
                        MessageBox.Show("Debe Seleccionar un Monto Medico.", "ESTADO REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }

    class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
