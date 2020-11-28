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

namespace Comercio
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load_1(object sender, EventArgs e)
        {
            
            CargaVentas();
        }

        private void CleanTextos()
        {
            
            txbx_dniCliente.Text = "";
            txbx_nombreCliente.Text = "";
            txbx_apellidoCliente.Text = "";
            cbox_Ventas.Text = "";
            dgv_listaProductos.Rows.Clear();
        }

        private void CargaVentas()
        {
            foreach (Venta v in Establecimiento.Ventas)
            {
                cbox_Ventas.Items.Add(v.Id);
            }
        }

        private void LoadData(Venta venta)
        {
            dgvDibujar(venta.Productos);
            txbx_apellidoCliente.Text = venta.Cliente.Apellido;
            txbx_dniCliente.Text = venta.Cliente.Dni.ToString();
            txbx_nombreCliente.Text = venta.Cliente.Nombre;
            
        }

        private void dgvDibujar(List<Producto> lista)
        {
            dgv_listaProductos.Rows.Clear();
            foreach (Producto item in lista)
            {
                this.dgv_listaProductos.Rows.Add(item.Id, item.Nombre, item.Precio.ToString("n2"), item.Stock);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbox_Ventas_TextChanged_1(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(cbox_Ventas.Text)))
            {
                foreach (Venta v in Establecimiento.Ventas)
                {
                    if (v.Id == int.Parse(cbox_Ventas.Text))
                    {
                        LoadData(v);
                        break;
                    }
                }
            }
        }
    }
}

