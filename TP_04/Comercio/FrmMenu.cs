using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Comercio
{
    public partial class FrmMenu : Form
    {
        //Evento Refrescar Grids
        public delegate void RefrescarVentanas(); 
        public RefrescarVentanas VentanasRefresh;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.Text = Establecimiento.NombreEstablecimiento;
            pb_Logo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\Imagenes\logo.png");
        }

        private void bt_Stock_Click(object sender, EventArgs e)
        {
            FrmStock stock = new FrmStock();
            this.Hide();
            stock.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmVenta frmVenta = new FrmVenta(this);
            frmVenta.ActivarRefresh += RefrescarGrids;
            frmVenta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_reportes_Click(object sender, EventArgs e)
        {
            FrmReporte reportes = new FrmReporte();
            this.Hide();
            reportes.ShowDialog();
            this.Show();
        }

        private void RefrescarGrids()
        {
            VentanasRefresh();
           
        }



    }
}
