namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_resultado = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_convertirBinario = new System.Windows.Forms.Button();
            this.bt_limpiar = new System.Windows.Forms.Button();
            this.bt_convertirDecimal = new System.Windows.Forms.Button();
            this.bt_operar = new System.Windows.Forms.Button();
            this.bt_cerrar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbx_operador = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lb_resultado
            // 
            this.lb_resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_resultado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_resultado.Location = new System.Drawing.Point(18, 9);
            this.lb_resultado.Name = "lb_resultado";
            this.lb_resultado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_resultado.Size = new System.Drawing.Size(679, 46);
            this.lb_resultado.TabIndex = 0;
            this.lb_resultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_resultado.UseMnemonic = false;
            this.lb_resultado.UseWaitCursor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(446, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 53);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_convertirBinario
            // 
            this.bt_convertirBinario.Location = new System.Drawing.Point(18, 237);
            this.bt_convertirBinario.Name = "bt_convertirBinario";
            this.bt_convertirBinario.Size = new System.Drawing.Size(336, 109);
            this.bt_convertirBinario.TabIndex = 7;
            this.bt_convertirBinario.Text = "Convertir a Binario";
            this.bt_convertirBinario.UseVisualStyleBackColor = true;
            this.bt_convertirBinario.Click += new System.EventHandler(this.bt_convertirBinario_Click);
            // 
            // bt_limpiar
            // 
            this.bt_limpiar.Location = new System.Drawing.Point(249, 149);
            this.bt_limpiar.Name = "bt_limpiar";
            this.bt_limpiar.Size = new System.Drawing.Size(217, 79);
            this.bt_limpiar.TabIndex = 9;
            this.bt_limpiar.Text = "Limpiar";
            this.bt_limpiar.UseVisualStyleBackColor = true;
            this.bt_limpiar.Click += new System.EventHandler(this.bt_limpiar_Click);
            // 
            // bt_convertirDecimal
            // 
            this.bt_convertirDecimal.Location = new System.Drawing.Point(371, 237);
            this.bt_convertirDecimal.Name = "bt_convertirDecimal";
            this.bt_convertirDecimal.Size = new System.Drawing.Size(327, 109);
            this.bt_convertirDecimal.TabIndex = 11;
            this.bt_convertirDecimal.Text = "Convertir a decimal";
            this.bt_convertirDecimal.UseVisualStyleBackColor = true;
            this.bt_convertirDecimal.Click += new System.EventHandler(this.bt_convertirDecimal_Click);
            // 
            // bt_operar
            // 
            this.bt_operar.Location = new System.Drawing.Point(18, 149);
            this.bt_operar.Name = "bt_operar";
            this.bt_operar.Size = new System.Drawing.Size(217, 79);
            this.bt_operar.TabIndex = 12;
            this.bt_operar.Text = "Operar";
            this.bt_operar.UseVisualStyleBackColor = true;
            this.bt_operar.Click += new System.EventHandler(this.bt_operar_Click);
            // 
            // bt_cerrar
            // 
            this.bt_cerrar.Location = new System.Drawing.Point(480, 149);
            this.bt_cerrar.Name = "bt_cerrar";
            this.bt_cerrar.Size = new System.Drawing.Size(217, 79);
            this.bt_cerrar.TabIndex = 13;
            this.bt_cerrar.Text = "Cerrar";
            this.bt_cerrar.UseVisualStyleBackColor = true;
            this.bt_cerrar.Click += new System.EventHandler(this.bt_cerrar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(18, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 53);
            this.textBox2.TabIndex = 14;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbx_operador
            // 
            this.cbx_operador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_operador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_operador.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_operador.FormattingEnabled = true;
            this.cbx_operador.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cbx_operador.Location = new System.Drawing.Point(295, 77);
            this.cbx_operador.Name = "cbx_operador";
            this.cbx_operador.Size = new System.Drawing.Size(121, 54);
            this.cbx_operador.TabIndex = 15;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 380);
            this.Controls.Add(this.cbx_operador);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.bt_cerrar);
            this.Controls.Add(this.bt_operar);
            this.Controls.Add(this.bt_convertirDecimal);
            this.Controls.Add(this.bt_limpiar);
            this.Controls.Add(this.bt_convertirBinario);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lb_resultado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Alvaro Villegas del currso 2ºD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalculadora_FormClosing);
            this.Load += new System.EventHandler(this.FormCalculadora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_resultado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_convertirBinario;
        private System.Windows.Forms.Button bt_limpiar;
        private System.Windows.Forms.Button bt_convertirDecimal;
        private System.Windows.Forms.Button bt_operar;
        private System.Windows.Forms.Button bt_cerrar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cbx_operador;
    }
}

