namespace Formularios
{
    partial class FrmOrdenarPor
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
            rbAñoDeFabrica = new RadioButton();
            rbMarca = new RadioButton();
            gbRadios = new GroupBox();
            cbAscDesc = new ComboBox();
            btnAceptar = new Button();
            gbRadios.SuspendLayout();
            SuspendLayout();
            // 
            // rbAñoDeFabrica
            // 
            rbAñoDeFabrica.AutoSize = true;
            rbAñoDeFabrica.Location = new Point(6, 22);
            rbAñoDeFabrica.Name = "rbAñoDeFabrica";
            rbAñoDeFabrica.Size = new Size(102, 19);
            rbAñoDeFabrica.TabIndex = 0;
            rbAñoDeFabrica.TabStop = true;
            rbAñoDeFabrica.Text = "Año de fabrica";
            rbAñoDeFabrica.UseVisualStyleBackColor = true;
            // 
            // rbMarca
            // 
            rbMarca.AutoSize = true;
            rbMarca.Location = new Point(114, 22);
            rbMarca.Name = "rbMarca";
            rbMarca.Size = new Size(58, 19);
            rbMarca.TabIndex = 1;
            rbMarca.TabStop = true;
            rbMarca.Text = "Marca";
            rbMarca.UseVisualStyleBackColor = true;
            // 
            // gbRadios
            // 
            gbRadios.Controls.Add(rbAñoDeFabrica);
            gbRadios.Controls.Add(rbMarca);
            gbRadios.Location = new Point(12, 12);
            gbRadios.Name = "gbRadios";
            gbRadios.Size = new Size(200, 49);
            gbRadios.TabIndex = 2;
            gbRadios.TabStop = false;
            gbRadios.Text = "Ordenar por";
            // 
            // cbAscDesc
            // 
            cbAscDesc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAscDesc.FormattingEnabled = true;
            cbAscDesc.Items.AddRange(new object[] { "Ascedente", "Descendente" });
            cbAscDesc.Location = new Point(18, 67);
            cbAscDesc.Name = "cbAscDesc";
            cbAscDesc.Size = new Size(182, 23);
            cbAscDesc.TabIndex = 2;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(18, 101);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(182, 23);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmOrdenarPor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 136);
            Controls.Add(btnAceptar);
            Controls.Add(cbAscDesc);
            Controls.Add(gbRadios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmOrdenarPor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ordenar";
            gbRadios.ResumeLayout(false);
            gbRadios.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton rbAñoDeFabrica;
        private RadioButton rbMarca;
        private GroupBox gbRadios;
        private ComboBox cbAscDesc;
        private Button btnAceptar;
    }
}