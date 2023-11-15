namespace Formularios
{
    partial class FrmVisualizador
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
            lbVisualizador = new ListBox();
            SuspendLayout();
            // 
            // lbVisualizador
            // 
            lbVisualizador.FormattingEnabled = true;
            lbVisualizador.ItemHeight = 15;
            lbVisualizador.Location = new Point(12, 12);
            lbVisualizador.Name = "lbVisualizador";
            lbVisualizador.Size = new Size(491, 214);
            lbVisualizador.TabIndex = 0;
            // 
            // FrmVisualizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 239);
            Controls.Add(lbVisualizador);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVisualizador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizador";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbVisualizador;
    }
}