using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// Formulario para seleccionar las opciones de ordenamiento.
    /// </summary>
    public partial class FrmOrdenarPor : Form
    {
        private bool ascendente;
        private Garaje garaje;

        /// <summary>
        /// Obtiene o establece el objeto Garaje en el que se realizará el ordenamiento.
        /// </summary>
        public Garaje Garaje
        {
            get { return garaje; }
            set { this.garaje = value; }
        }

        /// <summary>
        /// Obtiene un valor que indica si el ordenamiento es ascendente.
        /// </summary>
        public bool Ascendente
        {
            get { return ascendente; }
        }

        /// <summary>
        /// Constructor de la clase FrmOrdenarPor.
        /// Inicializa una nueva instancia del formulario de ordenamiento por año o marca.
        /// </summary>
        public FrmOrdenarPor(Garaje garaje)
        {
            InitializeComponent();

            this.garaje = garaje;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Aceptar".
        /// Realiza el ordenamiento de los vehículos según la opción seleccionada.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.rbAñoDeFabrica.Checked)
            {
                if (cbAscDesc.SelectedIndex != -1)
                {
                    ascendente = (cbAscDesc.SelectedIndex == 0) ? true : false;
                    garaje.OrdenarPorAñoDeFabricacion(ascendente);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una forma de ordenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (this.rbMarca.Checked)
            {
                if (cbAscDesc.SelectedIndex != -1)
                {
                    ascendente = (cbAscDesc.SelectedIndex == 0) ? true : false;
                    garaje.OrdenarPorMarcaAlfabeticamente(ascendente);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una forma de ordenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una forma de ordenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
