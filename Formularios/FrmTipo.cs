using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    /// <summary>
    /// Formulario para seleccionar el tipo de vehículo a agregar.
    /// </summary>
    public partial class FrmTipo : Form
    {
        private Vehiculo? vehiculo;
        private bool leerTabla;
        private int eleccion;

        public int Eleccion
        {
            get { return this.eleccion; }
            set { this.eleccion = value; }
        }

        /// <summary>
        /// Obtiene el vehículo seleccionado por el usuario.
        /// </summary>
        public Vehiculo? Vehiculo
        {
            get { return this.vehiculo; }
        }

        /// <summary>
        /// Constructor de la clase FrmTipo.
        /// Inicializa una nueva instancia del formulario para seleccionar el tipo de vehículo.
        /// </summary>
        public FrmTipo()
        {
            InitializeComponent();
        }

        public FrmTipo(bool leerTabla): this()
        {
            this.leerTabla = leerTabla;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Cancelar".
        /// Cierra el formulario actual.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar".
        /// Abre el formulario correspondiente al tipo de vehículo seleccionado por el usuario.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            if (this.rdbAuto.Checked)
            {
                eleccion = 0;
                if (leerTabla == true)
                { 
                    FrmAuto frmauto = new FrmAuto();
                    resultado = frmauto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        vehiculo = frmauto.Auto;
                    }
                    this.Hide();
                }
            }
            else if (this.rdbCamion.Checked)
            {
                eleccion = 1;
                if (leerTabla == true)
                {
                    FrmCamion frmcamion = new FrmCamion();
                    resultado = frmcamion.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        vehiculo = frmcamion.Camion;
                    }
                    this.Hide();
                }
            }
            else if (this.rdbMoto.Checked)
            {
                eleccion = 2;
                if (leerTabla == true)
                {
                FrmMoto frmmoto = new FrmMoto();
                resultado = frmmoto.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    vehiculo = frmmoto.Moto;
                }
                this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehículo",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
