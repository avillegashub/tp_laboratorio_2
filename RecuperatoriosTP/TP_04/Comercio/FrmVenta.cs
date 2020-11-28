using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;

namespace Comercio
{
    public partial class FrmVenta : Form
    {
        //Evento Refrescar Grids
        public delegate void RefreshGrids();
        public  event RefreshGrids ActivarRefresh;

        SoundPlayer sonidoVenta = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + @"\Imagenes\cash2.wav");
        List<Producto> productosVenta;
        float totalFinal = 0;
        float subTotal = 0;

        Thread hiloTiempo;

        public FrmVenta()
        {
            InitializeComponent();
        }
        public FrmVenta(FrmMenu parent)// Contructor con el parent para refencia
        {   
            InitializeComponent();
            //Asocio el Evento en el constructor, para mantener referencia del Form Parent(frmMenu)
            parent.VentanasRefresh -= VentanasGridRefresh;
           parent.VentanasRefresh += VentanasGridRefresh;
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            subTotal = 0;
            totalFinal = 0;
            LimpiarCodigo();
            productosVenta = new List<Producto>();
            this.dgv_ListaInventario.DataSource = null;
            this.dgv_ListaInventario.DataSource = Establecimiento.Productos;
            this.dgv_ListaInventario.Columns[0].Width = 75;
            this.dgv_ListaInventario.Columns[1].Width = 150;
            this.dgv_ListaInventario.Columns[2].Width = 100;
            this.dgv_ListaInventario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_ListaInventario.Columns[3].Width = 100;
            this.dgv_ListaInventario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_ListaVenta.Rows.Clear();
            lb_Subtotal.Text = "0";
            lb_descuento.Text = "0";
            lb_totalFinal.Text = "0";
            this.lbTiempo.Text = "0";
            TiempoVentana();


        }

        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void dgv_ListaInventario_MouseDown(object sender, MouseEventArgs e)
        {
            this.dgv_ListaInventario.DoDragDrop(dgv_ListaInventario.CurrentRow.Cells[0].Value, DragDropEffects.Copy);
        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            if (Establecimiento.GetProducto((int)e.Data.GetData(typeof(int))).Stock > 0)
            {
                if (productosVenta + Establecimiento.GetProducto((int)e.Data.GetData(typeof(int))))
                {
                    this.dgvDibujar(productosVenta);
                }
            }
        }

        private void dgvDibujar(List<Producto> lista)
        {
            dgv_ListaVenta.Rows.Clear();

            foreach (Producto item in lista)
            {
                this.dgv_ListaVenta.Rows.Add(item.Id, item.Nombre, item.Precio.ToString("n2"), item.Stock);
            }
            CalcularSubtotal();
            lb_Subtotal.Text = subTotal.ToString("n2");
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            FrmIngresaCantidad frmIngresaCantidad = new FrmIngresaCantidad();
            if (dgv_ListaVenta.Rows.Count > 0 && dgv_ListaVenta.CurrentCell.RowIndex > -1)
            {
                if (dgv_ListaVenta.CurrentCell.ColumnIndex == 3)
                {
                    ModificarCantidad();
                }
                else if (dgv_ListaVenta.CurrentCell.ColumnIndex == 4)
                {
                    RemoverProducto();
                }
            }
            this.dgvDibujar(productosVenta);
        }

        private void ModificarCantidad()
        {
            int cantidad;
            FrmIngresaCantidad frmIngresaCantidad = new FrmIngresaCantidad();
            frmIngresaCantidad.ShowDialog();
            cantidad = frmIngresaCantidad.cantidad;
            if (cantidad > 0)
                Producto.AgregarCantidad(productosVenta, int.Parse(dgv_ListaVenta.CurrentRow.Cells[0].Value.ToString()), cantidad);
        }

        private void RemoverProducto()
        {
            productosVenta.Remove(productosVenta[dgv_ListaVenta.CurrentRow.Index]);
        }

        public void CalcularSubtotal()
        {
            this.subTotal = 0;
            foreach (Producto productoEnLista in productosVenta)
            {
                this.subTotal += productoEnLista.Precio * productoEnLista.Stock;
            }
            CalcularTotal();
        }

        public void CalcularTotal()
        {
            totalFinal = subTotal;
            lb_totalFinal.Text = totalFinal.ToString("n2");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!(string.IsNullOrEmpty(txbx_dniCliente.Text)) && productosVenta.Count > 0)
            {
                try
                {
                    Establecimiento.AgregarCliente(txbx_nombreCliente.Text, txbx_apellidoCliente.Text, txbx_dniCliente.Text);
                    Establecimiento.HacerVenta(txbx_dniCliente.Text, productosVenta);
                    sonidoVenta.Play();
                    MessageBox.Show("“Gracias!! Vuelva prontosss”");
                    ActivarRefresh(); // Activa el Refresh con cada Venta.
                    Venta_Load(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("“Venta invalida”");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Establecimiento.GetCliente(int.Parse(txbx_dniCliente.Text));
                MostrarCliente();
                txbx_nombreCliente.Enabled = false;
                txbx_apellidoCliente.Enabled = false;
            }
            catch (Exception)
            {
                LimpiarTextos();
            }
            this.dgvDibujar(productosVenta);
        }

        private void LimpiarCodigo()
        {
            LimpiarTextos();
            txbx_dniCliente.Text = "";
        }

        private void LimpiarTextos()
        {
            txbx_nombreCliente.Text = null;
            txbx_apellidoCliente.Text = null;
            txbx_nombreCliente.Enabled = true;
            txbx_apellidoCliente.Enabled = true;
            lb_descuento.Text = "";
        }

        private void MostrarCliente()
        {
            txbx_nombreCliente.Text = Establecimiento.GetCliente(int.Parse(txbx_dniCliente.Text)).Nombre;
            txbx_apellidoCliente.Text = Establecimiento.GetCliente(int.Parse(txbx_dniCliente.Text)).Apellido;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int aux;
            if (!(string.IsNullOrEmpty(txbx_dniCliente.Text.ToString())))
                if (!(int.TryParse(txbx_dniCliente.Text, out aux)))
                {
                    txbx_dniCliente.Text = "";
                    MessageBox.Show("Dni Inválido");
                }
        }

        private void bt_salida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanasGridRefresh()
        {
            dgv_ListaInventario.DataSource = null;
            dgv_ListaInventario.DataSource = Establecimiento.Productos;
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hiloTiempo.IsAlive)
            {
                hiloTiempo.Abort();
            }
        }

        #region Thread
        private void TiempoVentana()
        {
            if (hiloTiempo is null)
            {
                this.hiloTiempo = new Thread(EtiquetaTiempo);
                hiloTiempo.Start();
            }
            else if (hiloTiempo.IsAlive)
            {
                hiloTiempo.Abort();
                hiloTiempo = new Thread(EtiquetaTiempo);
                hiloTiempo.Start();
            }
        }

        private void EtiquetaTiempo()
        {
          
                if (this.lbTiempo.InvokeRequired)
                {
                    this.lbTiempo.BeginInvoke((MethodInvoker)delegate ()
                    {

                        this.lbTiempo.Text = (int.Parse(this.lbTiempo.Text) + 1).ToString();

                    });
                }
                else
                {
                    this.lbTiempo.Text = (int.Parse(this.lbTiempo.Text) + 1).ToString();
                }
          
            Thread.Sleep(1000);
            EtiquetaTiempo();
        }

        #endregion
    }
}
