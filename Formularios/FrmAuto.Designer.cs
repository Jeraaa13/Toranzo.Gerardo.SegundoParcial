namespace Formularios
{
    partial class FrmAuto
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
            label4 = new Label();
            txtNumPuertas = new TextBox();
            label5 = new Label();
            cbTraccion = new ComboBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.TabIndex = 9;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.TabIndex = 10;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbCombustible
            // 
            cbCombustible.ItemHeight = 15;
            cbCombustible.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(218, 9);
            label4.Name = "label4";
            label4.Size = new Size(109, 15);
            label4.TabIndex = 14;
            label4.Text = "Numero de puertas";
            // 
            // txtNumPuertas
            // 
            txtNumPuertas.Location = new Point(218, 27);
            txtNumPuertas.Name = "txtNumPuertas";
            txtNumPuertas.Size = new Size(202, 23);
            txtNumPuertas.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(218, 71);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 16;
            label5.Text = "Tipo de tracción";
            // 
            // cbTraccion
            // 
            cbTraccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTraccion.FormattingEnabled = true;
            cbTraccion.Location = new Point(218, 89);
            cbTraccion.Name = "cbTraccion";
            cbTraccion.Size = new Size(202, 23);
            cbTraccion.TabIndex = 8;
            // 
            // FrmAuto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 349);
            Controls.Add(cbTraccion);
            Controls.Add(label5);
            Controls.Add(txtNumPuertas);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAuto";
            Text = "Agregar un auto";
            Controls.SetChildIndex(cbCombustible, 0);
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtAñoFabricacion, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnCancelar, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(txtNumPuertas, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(cbTraccion, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox txtNumPuertas;
        private Label label5;
        private ComboBox cbTraccion;
    }
}