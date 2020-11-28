using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Funcionalidades;

namespace Comercio
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();

        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.validaUsuario(int.Parse(txbx_Usuario.Text), txbx_password.Text);
                FrmMenu menu = new FrmMenu();
                timer1.Enabled = false;
                this.Hide();
                menu.ShowDialog();
                this.Show();
                timer1.Enabled = true;
                ResetTextBoxes();
            }
            catch (Exception)
            {
                MessageBox.Show("Usuario o Clave inválidos");
                txbx_Usuario.Text = null;
                txbx_password.Text = null;
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                pb_Logo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\Imagenes\logo.png");
                txbx_Usuario.Text = 12345678.ToString();
                txbx_password.Text = "asdasdasd";
                this.Text = Establecimiento.NombreEstablecimiento;
                DataBase.TraerProductos();
                DataBase.TraerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ResetTextBoxes()
        {
            txbx_Usuario.Text = null;
            txbx_password.Text = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
