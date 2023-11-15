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
    /// Obtiene o establece el objeto Camion creado o editado en el formulario.
    /// </summary>
    public partial class FrmCamion : FrmVehiculo
    {
        private Camion camion;

        /// <summary>
        /// Obtiene o establece el objeto Camion creado o editado en el formulario.
        /// </summary>
        public Camion Camion
        {
            get { return this.camion; }
            set { this.camion = value; }
        }

        /// <summary>
        /// Constructor predeterminado del formulario.
        /// </summary>
        public FrmCamion()
        {
            InitializeComponent();

            camion = new Camion();
        }

        /// <summary>
        /// Constructor sobrecargado que permite editar un Camion existente.
        /// </summary>
        /// <param name="camion">El camión a editar.</param>
        public FrmCamion(Camion camion) : this()
        {
            this.txtMarca.Text = camion.Marca;
            this.txtModelo.Text = camion.Modelo;
            this.txtAñoFabricacion.Text = camion.AñoFabricacion.ToString();
            this.cbCombustible.Text = camion.TipoCombustible.ToString();
            this.txtCargaMaxima.Text = camion.CargaMaxima.ToString();
            this.txtNumEjes.Text = camion.NumeroEjes.ToString();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Cancelar".
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar".
        /// Valida los datos ingresados y crea una instancia de Camion.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            if (!double.TryParse(this.txtCargaMaxima.Text, out double cargaMaxima))
            {
                MessageBox.Show("Ingrese una carga maxima valida por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(this.txtNumEjes.Text, out int numeroEjes))
            {
                MessageBox.Show("Ingrese un numero de ejes valido por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            añoFabricacion = int.Parse(txtAñoFabricacion.Text);
            tipoCombustible = (ETipoCombustible)cbCombustible.SelectedItem;


            camion = new Camion(cargaMaxima, numeroEjes, marca, modelo, añoFabricacion, tipoCombustible);

            DialogResult = DialogResult.OK;
        }
    }
}
