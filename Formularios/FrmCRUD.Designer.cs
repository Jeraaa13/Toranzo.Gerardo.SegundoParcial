namespace Formularios
{
    partial class FrmCRUD
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            lstbRead = new ListBox();
            lblUsuario = new Label();
            lblFecha = new Label();
            btnOrdenar = new Button();
            btnVisualizador = new Button();
            btnSerializar = new Button();
            btnDeserializar = new Button();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 238);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(89, 52);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(150, 238);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 52);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(274, 238);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 52);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lstbRead
            // 
            lstbRead.FormattingEnabled = true;
            lstbRead.ItemHeight = 15;
            lstbRead.Location = new Point(12, 33);
            lstbRead.Name = "lstbRead";
            lstbRead.Size = new Size(595, 199);
            lstbRead.TabIndex = 3;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(12, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(94, 15);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Logueado como";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(194, 9);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(43, 15);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Hoy es";
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(407, 238);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(88, 52);
            btnOrdenar.TabIndex = 6;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnVisualizador
            // 
            btnVisualizador.Location = new Point(528, 4);
            btnVisualizador.Name = "btnVisualizador";
            btnVisualizador.Size = new Size(79, 23);
            btnVisualizador.TabIndex = 7;
            btnVisualizador.Text = "Visualizador";
            btnVisualizador.UseVisualStyleBackColor = true;
            btnVisualizador.Click += btnVisualizador_Click;
            // 
            // btnSerializar
            // 
            btnSerializar.Location = new Point(532, 238);
            btnSerializar.Name = "btnSerializar";
            btnSerializar.Size = new Size(75, 23);
            btnSerializar.TabIndex = 8;
            btnSerializar.Text = "Serializar";
            btnSerializar.UseVisualStyleBackColor = true;
            btnSerializar.Click += btnSerializar_Click;
            // 
            // btnDeserializar
            // 
            btnDeserializar.Location = new Point(532, 267);
            btnDeserializar.Name = "btnDeserializar";
            btnDeserializar.Size = new Size(75, 23);
            btnDeserializar.TabIndex = 9;
            btnDeserializar.Text = "Deserializar";
            btnDeserializar.UseVisualStyleBackColor = true;
            btnDeserializar.Click += btnDeserializar_Click;
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 297);
            Controls.Add(btnDeserializar);
            Controls.Add(btnSerializar);
            Controls.Add(btnVisualizador);
            Controls.Add(btnOrdenar);
            Controls.Add(lblFecha);
            Controls.Add(lblUsuario);
            Controls.Add(lstbRead);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRUD";
            FormClosing += FrmCRUD_FormClosing;
            FormClosed += FrmCRUD_FormClosed;
            Load += FrmCRUD_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button btnAgregar;
        protected Button btnModificar;
        protected Button btnEliminar;
        protected ListBox lstbRead;
        private Label lblUsuario;
        private Label lblFecha;
        private Button btnOrdenar;
        private Button btnVisualizador;
        private Button btnSerializar;
        private Button btnDeserializar;
    }
}