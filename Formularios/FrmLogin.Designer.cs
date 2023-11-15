namespace Formularios
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(70, 173);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(102, 41);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 9);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Iniciar sesión";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 2;
            label2.Text = "Ingrese su correo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 3;
            label3.Text = "Ingrese su contraseña:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 66);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(219, 23);
            txtCorreo.TabIndex = 4;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(12, 128);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(219, 23);
            txtContraseña.TabIndex = 5;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 226);
            Controls.Add(txtContraseña);
            Controls.Add(txtCorreo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCorreo;
        private TextBox txtContraseña;
    }
}