using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Policlinico;
using Entity.Policlinico;
using UI.Policlinico.Code;
using UI.Policlinico.Dashboard;

namespace UI.Policlinico.Login
{
    public partial class frmLogin : Form
    {
        LoginBL loginBL = new LoginBL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nroDocumento = txtUsuario.Text;
            string passUser = txtContrasenia.Text;

            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            int idUser = loginBL.getUsuarioIdbyLogin(nroDocumento, passUser, localIP);

            if(idUser > 0)
            {
                LoginBE loginBE;// = new LoginBE();
                loginBE = loginBL.getSimpleDataUsuario(idUser);

                MantenedorSession.User= idUser.ToString();
                MantenedorSession.Nombres = loginBE.nombreCompleto;
                MantenedorSession.Rol = loginBE.Rol; 
                MantenedorSession.FechaIngreso = "FECHA DE INGRESO "+ DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                LoginInfo.UserID = idUser;
                LoginInfo.UserIP = localIP;
                LoginInfo.nombreCompleto = loginBE.nombreCompleto;
                LoginInfo.Rol = loginBE.Rol;


                var frm = new frmPanelControl();
                frm.ParentForm = this;
                frm.Show();

                this.Hide();
         
            }
            else
            {
                MessageBox.Show("No se ha podido iniciar sesión, intentélo nuevamente");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        { 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = UI.Policlinico.Properties.Resources.LOGO;
            this.Name = "Policlínico \"Nuestra Señora del Sagrado Corazón\" ACCESOS AL SGPOLICLINICO";
        }

        private void lblAcerca_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void imagFondo_Click(object sender, EventArgs e)
        {

        }
    }
}
