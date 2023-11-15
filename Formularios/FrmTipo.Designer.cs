namespace Formularios
{
    partial class FrmTipo
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            rdbAuto = new RadioButton();
            rdbMoto = new RadioButton();
            rdbCamion = new RadioButton();
            grpVehiculo = new GroupBox();
            grpVehiculo.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 126);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(104, 126);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo de vehiculo:";
            // 
            // rdbAuto
            // 
            rdbAuto.AutoSize = true;
            rdbAuto.Location = new Point(6, 22);
            rdbAuto.Name = "rdbAuto";
            rdbAuto.Size = new Size(51, 19);
            rdbAuto.TabIndex = 3;
            rdbAuto.TabStop = true;
            rdbAuto.Text = "Auto";
            rdbAuto.UseVisualStyleBackColor = true;
            // 
            // rdbMoto
            // 
            rdbMoto.AutoSize = true;
            rdbMoto.Location = new Point(6, 47);
            rdbMoto.Name = "rdbMoto";
            rdbMoto.Size = new Size(54, 19);
            rdbMoto.TabIndex = 4;
            rdbMoto.TabStop = true;
            rdbMoto.Text = "Moto";
            rdbMoto.UseVisualStyleBackColor = true;
            // 
            // rdbCamion
            // 
            rdbCamion.AutoSize = true;
            rdbCamion.Location = new Point(6, 72);
            rdbCamion.Name = "rdbCamion";
            rdbCamion.Size = new Size(67, 19);
            rdbCamion.TabIndex = 5;
            rdbCamion.TabStop = true;
            rdbCamion.Text = "Camion";
            rdbCamion.UseVisualStyleBackColor = true;
            // 
            // grpVehiculo
            // 
            grpVehiculo.Controls.Add(rdbAuto);
            grpVehiculo.Controls.Add(rdbCamion);
            grpVehiculo.Controls.Add(rdbMoto);
            grpVehiculo.Location = new Point(12, 27);
            grpVehiculo.Name = "grpVehiculo";
            grpVehiculo.Size = new Size(167, 93);
            grpVehiculo.TabIndex = 6;
            grpVehiculo.TabStop = false;
            grpVehiculo.Text = "Vehiculos";
            // 
            // FrmTipo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(191, 155);
            Controls.Add(grpVehiculo);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "FrmTipo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar un vehiculo";
            grpVehiculo.ResumeLayout(false);
            grpVehiculo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
        private RadioButton rdbAuto;
        private RadioButton rdbMoto;
        private RadioButton rdbCamion;
        private GroupBox grpVehiculo;
    }
}