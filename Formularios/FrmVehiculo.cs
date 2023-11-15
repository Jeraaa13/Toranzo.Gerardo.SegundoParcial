using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// Formulario base para la entrada de datos comunes de vehículos, que luego hereda graficamente a otros forms.
    /// </summary>
    public partial class FrmVehiculo : Form
    {
        protected string? marca;
        protected string? modelo;
        protected int añoFabricacion;
        protected ETipoCombustible tipoCombustible;

        /// /// <summary>
        /// Constructor de la clase FrmVehiculo.
        /// Inicializa el formulario y llena el combobox de tipos de combustible.
        /// </summary>
        public FrmVehiculo()
        {
            InitializeComponent();
            Array arrayCombustible = Enum.GetValues(typeof(ETipoCombustible));
            foreach (ETipoCombustible tipoCombustible in arrayCombustible)
            {
                this.cbCombustible.Items.Add(tipoCombustible);
            }
        }

        /// <summary>
        /// Valida los datos ingresados en el formulario.
        /// </summary>
        /// <returns>Devuelve true si los datos son válidos, de lo contrario, false.</returns>
        protected bool ValidarDatos()
        {
            marca = txtMarca.Text;
            modelo = txtModelo.Text;


            if (string.IsNullOrWhiteSpace(marca))
            {
                MessageBox.Show("Ingrese una marca válido por favor.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                MessageBox.Show("Ingrese una modelo válido por favor.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtAñoFabricacion.Text, out añoFabricacion))
            {
                MessageBox.Show("Ingrese un año de fabricación válido por favor.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (this.cbCombustible.SelectedItem is not ETipoCombustible tipoCombustible)
            {
                MessageBox.Show("Seleccione un tipo de combustible por favor.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
