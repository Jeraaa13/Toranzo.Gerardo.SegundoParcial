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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Formularios
{
    /// <summary>
    /// Formulario para la creación y edición de datos de motos.
    /// </summary>
    public partial class FrmMoto : FrmVehiculo
    {
        private Moto moto;

        /// <summary>
        /// Obtiene o establece el objeto Moto creado o editado en el formulario.
        /// </summary>
        public Moto Moto
        {
            get { return this.moto; }
            set { this.moto = value; }
        }
        /// <summary>
        /// Constructor predeterminado del formulario.
        /// </summary>
        public FrmMoto()
        {
            InitializeComponent();
            Array arrayRuedas = Enum.GetValues(typeof(ETipoRuedas));
            foreach (ETipoRuedas ruedas in arrayRuedas)
            {
                this.cbRuedas.Items.Add(ruedas);
            }

            moto = new Moto();
        }

        /// <summary>
        /// Constructor sobrecargado que permite editar una Moto existente.
        /// </summary>
        public FrmMoto(Moto moto) : this()
        {
            this.txtMarca.Text = moto.Marca;
            this.txtModelo.Text = moto.Modelo;
            this.txtAñoFabricacion.Text = moto.AñoFabricacion.ToString();
            this.cbCombustible.Text = moto.TipoCombustible.ToString();
            this.txtCilindrada.Text = moto.Cilindrada.ToString();
            this.cbRuedas.Text = moto.TipoRuedas.ToString();
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
        /// Valida los datos ingresados y crea una instancia de Moto.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            if (!int.TryParse(this.txtCilindrada.Text, out int cilindrada))
            {
                MessageBox.Show("Ingrese una cilindrada válida por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            if (this.cbRuedas.SelectedItem is not ETipoRuedas ruedas)
            {
                MessageBox.Show("Seleccione un tipo de ruedas por favor.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            añoFabricacion = int.Parse(txtAñoFabricacion.Text);
            tipoCombustible = (ETipoCombustible)cbCombustible.SelectedItem;

            moto = new Moto(cilindrada, ruedas, marca, modelo, añoFabricacion, tipoCombustible);

            DialogResult = DialogResult.OK;
        }
    }

}