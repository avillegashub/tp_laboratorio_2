using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void bt_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_limpiar_Click(object sender, EventArgs e)
        {
            this.lb_resultado.Text = " ";
            this.textBox1.Text = " ";
            this.textBox2.Text = " ";
            this.cbx_operador.Text = null;
        }

        private void bt_operar_Click(object sender, EventArgs e)
        {
            string operador;
            if ( cbx_operador.SelectedItem == null)
            {
                operador = "+";
                cbx_operador.Text = "+";
            }
            else
            {
                
            operador = cbx_operador.SelectedItem.ToString();
            }
            
            Numero num1 = new Numero(this.textBox1.Text);
            Numero num2 = new Numero(this.textBox2.Text);
           
            switch(operador)
            {
                
                case "-":
            lb_resultado.Text = (num2 - num1).ToString();
                    break;
                case "/":
            lb_resultado.Text = (num1 / num2).ToString();
                    break;
                case "*":
            lb_resultado.Text = (num1 * num2).ToString();
                    break;
                case "+":
                default:

                    lb_resultado.Text = (num1 + num2).ToString();
                    break;
            }




        }

        private void bt_convertirBinario_Click(object sender, EventArgs e)
        {
            string resultado;
            Numero aux = new Numero();
            if(lb_resultado.Text == "")
            {
                resultado = aux.DecimalBinario("0");
            }
            else
            {
            resultado = aux.DecimalBinario(lb_resultado.Text);

            }
            lb_resultado.Text = resultado;


        }

        private void bt_convertirDecimal_Click(object sender, EventArgs e)
        {
            string resultado;
            Numero aux = new Numero();
            if (lb_resultado.Text == "")
            {
                resultado = aux.BinarioDecimal("0");
            }
            else
            {
                resultado = aux.BinarioDecimal(lb_resultado.Text);

            }
            lb_resultado.Text = resultado;
        }
    }
}
