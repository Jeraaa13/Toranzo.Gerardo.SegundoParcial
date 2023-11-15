namespace Formularios
{
    partial class FrmCamion
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
            label6 = new Label();
            txtCargaMaxima = new TextBox();
            txtNumEjes = new TextBox();
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
            label5.Size = new Size(84, 15);
            label5.TabIndex = 16;
            label5.Text = "Carga maxima";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(218, 71);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 17;
            label6.Text = "Numero de ejes";
            // 
            // txtCargaMaxima
            // 
            txtCargaMaxima.Location = new Point(218, 27);
            txtCargaMaxima.Name = "txtCargaMaxima";
            txtCargaMaxima.Size = new Size(200, 23);
            txtCargaMaxima.TabIndex = 18;
            // 
            // txtNumEjes
            // 
            txtNumEjes.Location = new Point(218, 89);
            txtNumEjes.Name = "txtNumEjes";
            txtNumEjes.Size = new Size(200, 23);
            txtNumEjes.TabIndex = 19;
            // 
            // FrmCamion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 349);
            Controls.Add(txtNumEjes);
            Controls.Add(txtCargaMaxima);
            Controls.Add(label6);
            Controls.Add(label5);
            Name = "FrmCamion";
            Text = "Agregar un camion";
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtAñoFabricacion, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(cbCombustible, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(txtCargaMaxima, 0);
            Controls.SetChildIndex(txtNumEjes, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label6;
        private TextBox txtCargaMaxima;
        private TextBox txtNumEjes;
    }
}