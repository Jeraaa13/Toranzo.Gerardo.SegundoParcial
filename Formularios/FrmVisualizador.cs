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
    /// Formulario para visualizar registros de actividad de usuarios.
    /// </summary>
    public partial class FrmVisualizador : Form
    {
        /// <summary>
        /// Constructor de la clase FrmVisualizador.
        /// Carga y muestra registros de actividad de usuarios desde un archivo de registro especificado.
        /// </summary>
        /// <param name="logPath">Ruta del archivo de registro de actividad de usuarios.</param>
        public FrmVisualizador(string logPath)
        {
            InitializeComponent();

            if (File.Exists(logPath))
            {
                string[] archivo = File.ReadAllLines(logPath);
                this.lbVisualizador.Items.AddRange(archivo);
            }
            else
            {
                lbVisualizador.Items.Add("El archivo de registro no existe.");
            }
        }
    }
}
