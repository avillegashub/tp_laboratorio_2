using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
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
            Limpiar();
        }

        private void bt_operar_Click(object sender, EventArgs e)
        {

            Rellenar();
            lb_resultado.Text = Operar(textBox1.Text, textBox2.Text, cbx_operador.Text).ToString();
            bt_convertirDecimal.Enabled = true;
            bt_convertirBinario.Enabled = true;

        }

        private void Limpiar()
        {
            this.lb_resultado.ResetText();
            this.textBox1.ResetText();
            this.textBox2.ResetText();
            this.cbx_operador.SelectedItem = null;
            bt_convertirDecimal.Enabled = true;
            bt_convertirBinario.Enabled = true;
        }

        private void bt_convertirBinario_Click(object sender, EventArgs e)
        {
            if (lb_resultado.Text != "")
            {
                lb_resultado.Text = new Numero(lb_resultado.Text).DecimalBinario(lb_resultado.Text);
            }
            bt_convertirBinario.Enabled = false;
            bt_convertirDecimal.Enabled = true;
        }

        private void bt_convertirDecimal_Click(object sender, EventArgs e)
        {
            if (lb_resultado.Text != "")
            {
                lb_resultado.Text = new Numero(lb_resultado.Text).BinarioDecimal(lb_resultado.Text);
            }
            bt_convertirDecimal.Enabled = false;
            bt_convertirBinario.Enabled = true;
        }

        static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero2), new Numero(numero1), operador);

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            bt_convertirDecimal.Enabled = false;
            bt_convertirBinario.Enabled = false;
            textBox1.TabIndex = 2;
            cbx_operador.TabIndex = 1;
            textBox2.TabIndex = 0;
            bt_operar.TabIndex = 3;
            bt_limpiar.TabIndex = 4;
            bt_cerrar.TabIndex = 5;
            bt_convertirBinario.TabIndex = 6;
            bt_convertirDecimal.TabIndex = 7;
            Limpiar();

        }

        private void Rellenar()
        {
            double aux;

            if (string.IsNullOrEmpty(textBox2.Text) || !(double.TryParse(textBox2.Text, out aux)))
                textBox2.Text = "0";
            if (string.IsNullOrEmpty(textBox1.Text) || !(double.TryParse(textBox1.Text, out aux)))
                textBox1.Text = "0";
            if (string.IsNullOrEmpty(cbx_operador.Text))
                cbx_operador.SelectedItem = cbx_operador.Items[0];
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
          if(  MessageBox.Show("Seguro que quiere salir ?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            
       
        }

        
    }

}
