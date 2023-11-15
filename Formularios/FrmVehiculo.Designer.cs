namespace Formularios
{
    partial class FrmVehiculo
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
            label1 = new Label();
            txtMarca = new TextBox();
            label2 = new Label();
            txtModelo = new TextBox();
            label3 = new Label();
            txtAñoFabricacion = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            cbCombustible = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Marca";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(12, 27);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(200, 23);
            txtMarca.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "Modelo";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(12, 89);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(200, 23);
            txtModelo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 4;
            label3.Text = "Año de fabricacion";
            // 
            // txtAñoFabricacion
            // 
            txtAñoFabricacion.Location = new Point(12, 150);
            txtAñoFabricacion.Name = "txtAñoFabricacion";
            txtAñoFabricacion.Size = new Size(200, 23);
            txtAñoFabricacion.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(83, 306);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(87, 35);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(239, 306);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 35);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbCombustible
            // 
            cbCombustible.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCombustible.FormattingEnabled = true;
            cbCombustible.Location = new Point(14, 218);
            cbCombustible.Name = "cbCombustible";
            cbCombustible.Size = new Size(198, 23);
            cbCombustible.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 15;
            label4.Text = "Tipo de combustible";
            // 
            // FrmVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 353);
            Controls.Add(label4);
            Controls.Add(cbCombustible);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtAñoFabricacion);
            Controls.Add(label3);
            Controls.Add(txtModelo);
            Controls.Add(label2);
            Controls.Add(txtMarca);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVehiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar un vehiculo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        protected TextBox txtMarca;
        private Label label2;
        protected TextBox txtModelo;
        private Label label3;
        protected TextBox txtAñoFabricacion;
        protected Button btnAceptar;
        protected Button btnCancelar;
        protected ComboBox cbCombustible;
        private Label label4;
    }
}