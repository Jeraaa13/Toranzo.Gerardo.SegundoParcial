namespace Formularios
{
    partial class FrmMoto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            txtCilindrada = new TextBox();
            label6 = new Label();
            cbRuedas = new ComboBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(218, 9);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 16;
            label5.Text = "Cilindrada";
            // 
            // txtCilindrada
            // 
            txtCilindrada.Location = new Point(218, 27);
            txtCilindrada.Name = "txtCilindrada";
            txtCilindrada.Size = new Size(196, 23);
            txtCilindrada.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(218, 71);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 18;
            label6.Text = "Tipo de ruedas";
            // 
            // cbRuedas
            // 
            cbRuedas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRuedas.FormattingEnabled = true;
            cbRuedas.Location = new Point(218, 89);
            cbRuedas.Name = "cbRuedas";
            cbRuedas.Size = new Size(196, 23);
            cbRuedas.TabIndex = 19;
            // 
            // FrmMoto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 350);
            Controls.Add(cbRuedas);
            Controls.Add(label6);
            Controls.Add(txtCilindrada);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMoto";
            Text = "Agregar una moto";
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtAñoFabricacion, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(cbCombustible, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtCilindrada, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(cbRuedas, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private TextBox txtCilindrada;
        private Label label6;
        private ComboBox cbRuedas;
    }
}