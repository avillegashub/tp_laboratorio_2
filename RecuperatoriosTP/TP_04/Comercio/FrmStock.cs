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
using System.Xml.Linq;
using Funcionalidades;


namespace Comercio
{
    public partial class FrmStock : Form
    {
        string directory = AppDomain.CurrentDomain.BaseDirectory;

        public FrmStock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            this.Text = Establecimiento.NombreEstablecimiento;
            dgv_ListaProductos.RowsDefaultCellStyle.BackColor = Color.White;
            dgv_ListaProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            GridRefresh();
            bt_nuevoProducto.Show();
            bt_anadir.Enabled = false;
        }

        private void dgvDibujar(List<Producto> listaProductos)
        {
            dgv_ListaProductos.Rows.Clear();
            foreach (Producto item in listaProductos)
            {
                dgv_ListaProductos.Rows.Add(GetImagen(item), item.Id, item.Nombre, item.Precio, item.Stock);
            }
        }

        private Image GetImagen(Producto p)
        {
            try
            {
                return Image.FromFile(directory + @"\Imagenes\" + p.Nombre + ".png");
            }
            catch (Exception)
            {
                return Image.FromFile(directory + @"\Imagenes\" + "NoImage" + ".png");
            }
        }

        private void MostrarProducto(Producto producto)
        {
            txbx_codigo.Text = producto.Id.ToString();
            txbxPrecio.Text = producto.Precio.ToString("n2");
            txbx_stock.Text = producto.Stock.ToString();
            txbx_nombre.Text = producto.Nombre;
            pcbx_imagenProducto.Image = GetImagen(producto);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            MostrarProducto(Establecimiento.GetProducto((int)dgv_ListaProductos.CurrentRow.Cells["dgv_columnaId"].Value));
        }

        private void txbx_codigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarProducto(Establecimiento.GetProducto(int.Parse(txbx_codigo.Text)));
                bt_nuevoProducto.Enabled = false;
                bt_anadir.Enabled = true;
            }
            catch (FormatException)
            {
                txbx_codigo.Text = null;
                LimpiarTextos();
            }
            catch (Exception)
            {
                LimpiarTextos();
            }
        }

        private void LimpiarTextos()
        {
            txbx_nombre.Text = "";
            txbx_stock.Text = "";
            LimpiarPrecio();
            pcbx_imagenProducto.Image = null;
            pcbx_imagenProducto.Refresh();
            bt_nuevoProducto.Enabled = true;
            bt_anadir.Enabled = false;
        }

        private void LimpiarCodigo()
        {
            txbx_codigo.Text = "";
        }

        private void LimpiarPrecio()
        {
            txbxPrecio.Text = "";
        }

        private void bt_anadir_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.UpdateProducto(int.Parse(txbx_codigo.Text), (Establecimiento.GetProducto(int.Parse(txbx_codigo.Text)).Stock + int.Parse(cbox_Agregar.Text)).ToString());
                GridRefresh();
                MostrarProducto(Establecimiento.GetProducto(int.Parse(txbx_codigo.Text)));
            }
            catch (FormatException)
            {
                cbox_Agregar.Text = "0";
            }
        }

        private void bt_filtrar_Click(object sender, EventArgs e)
        {
            List<Producto> productosFiltro;
            try
            {
                if (!(string.IsNullOrEmpty(cbox_Filtrar.Text)))
                {
                    int.Parse(cbox_Filtrar.Text);
                    productosFiltro = new List<Producto>();
                    foreach (Producto item in Establecimiento.Productos)
                    {
                        if (item.Stock <= int.Parse(cbox_Filtrar.Text))
                        {
                            productosFiltro.Add(item);
                        }
                    }
                    limpiarGridStock();
                    dgvDibujar(productosFiltro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiarGridStock()
        {
            dgv_ListaProductos.Rows.Clear();
            dgv_ListaProductos.Refresh();
            dgv_ListaProductos.Update();
        }

        private void txbx_codigo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txbx_codigo.Text)))
                    int.Parse(txbx_codigo.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Codigo Inválido");
                LimpiarCodigo();
            }
        }

        private void txbxPrecio_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txbxPrecio.Text)))
                    int.Parse(txbxPrecio.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Precio Inválido");
                LimpiarPrecio();
            }
        }

        private void bt_clean_Click(object sender, EventArgs e)
        {
           
            pcbx_imagenProducto.Image = null;
            pcbx_imagenProducto.Refresh();
            GridRefresh();
            LimpiarCodigo();
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                int.Parse(cbox_Agregar.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero");
                cbox_Agregar.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_nuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Establecimiento.AgregarProducto(txbx_nombre.Text, txbxPrecio.Text);
            }
            catch (ExcepcionNombreRepetido)
            {
                Establecimiento.AgregarProducto(txbx_nombre.Text + "1", txbxPrecio.Text);
            }
            finally
            {
                GridRefresh();
                MostrarProducto(Establecimiento.Productos[Establecimiento.Productos.Count - 1]);
            }
        }

        private void GridRefresh()
        {
            limpiarGridStock();
            dgvDibujar(Establecimiento.Productos);
        }

    }




}

