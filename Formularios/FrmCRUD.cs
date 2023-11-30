using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Formularios
{
    /// <summary>
    /// Formulario principal de la aplicación para realizar operaciones CRUD en vehículos.
    /// </summary>
    public partial class FrmCRUD : Form
    {
        private Usuario usuario;
        private FrmLogin login;
        private Garaje garaje = new Garaje();
        private AccesoDatos accesoDatos = new AccesoDatos();

        /// <summary>
        /// Constructor de la clase FrmCRUD.
        /// </summary>
        /// <param name="login">Formulario de inicio de sesión.</param>
        /// <param name="usuario">Usuario autenticado.</param>
        public FrmCRUD(FrmLogin login, Usuario usuario)
        {
            InitializeComponent();

            this.login = login;
            this.usuario = usuario;
        }

        /// <summary>
        /// Evento que se dispara al cerrar el formulario.
        /// Cierra el formulario de inicio de sesión.
        /// </summary>
        private void FrmCRUD_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.login.Close();
        }

        /// <summary>
        /// Evento para agregar un nuevo vehículo.
        /// Muestra un formulario para ingresar los detalles del vehículo y lo agrega al garaje.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmTipo frmtipo = new FrmTipo();

            DialogResult resultado = frmtipo.ShowDialog();
            if (resultado == DialogResult.OK && frmtipo.Vehiculo != null)
            {
                if (frmtipo.Vehiculo is Auto)
                {
                    Auto auto = (Auto)frmtipo.Vehiculo;
                    accesoDatos.InsertarVehiculo(auto, "Auto");
                }
                else if (frmtipo.Vehiculo is Moto)
                {
                    Moto moto = (Moto)frmtipo.Vehiculo;
                    accesoDatos.InsertarVehiculo(moto, "Moto");
                }
                else if(frmtipo.Vehiculo is Camion)
                {
                    Camion camion = (Camion)frmtipo.Vehiculo;
                    accesoDatos.InsertarVehiculo(camion, "Camion");
                }
            }
            ActualizarLstb();
        }

        /// <summary>
        /// Evento que se dispara al cerrar el formulario.
        /// Pregunta al usuario si está seguro de cerrar la aplicación.
        /// </summary>
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro que desea cerrar?",
                                    "Advertencia",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning
                                    );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Evento para eliminar un vehículo seleccionado.
        /// Elimina el vehículo seleccionado del garaje.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstbRead.SelectedIndex != -1)
            {
                int index = lstbRead.SelectedIndex;
                garaje -= garaje.Vehiculos[index];
            }
            ActualizarLstb();
        }

        /// <summary>
        /// Evento para modificar un vehículo seleccionado.
        /// Permite modificar los detalles del vehículo seleccionado.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.lstbRead.SelectedIndex != -1)
            {
                int index = lstbRead.SelectedIndex;
                object objeto = garaje.Vehiculos[index];

                DialogResult resultado;
                if (objeto is Auto)
                {
                    FrmAuto frmAuto = new FrmAuto((Auto)objeto);

                    resultado = frmAuto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmAuto.Auto;
                    }
                }
                else if (objeto is Moto)
                {
                    FrmMoto frmMoto = new FrmMoto((Moto)objeto);

                    resultado = frmMoto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmMoto.Moto;

                    }
                }
                else if (objeto is Camion)
                {
                    FrmCamion frmCamion = new FrmCamion((Camion)objeto);

                    resultado = frmCamion.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmCamion.Camion;
                    }
                }
                ActualizarLstb();
            }
        }

        /// <summary>
        /// Actualiza el contenido de la lista de vehículos en el formulario.
        /// </summary>
        private void ActualizarLstb()
        {
            this.lstbRead.Items.Clear();

            List<Vehiculo> listaVehiculos = accesoObtenerListaDeVehiculos();
        }

        /// <summary>
        /// Evento que se dispara al cargar el formulario.
        /// Realiza inicializaciones y carga de datos.
        /// </summary>
        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            this.lblUsuario.Text = "Logueado como: " + usuario.nombre + " " + usuario.apellido;
            this.lblFecha.Text = "Hoy es: " + DateTime.Now.ToShortDateString();

            ArchivarDatos();
        }

        /// <summary>
        /// Evento para ordenar los vehículos en el garaje.
        /// Permite al usuario seleccionar un criterio de ordenación.
        /// </summary>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (lstbRead.Items.Count > 1)
            {
                FrmOrdenarPor frmOrdenar = new FrmOrdenarPor(garaje);

                DialogResult resultado = frmOrdenar.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    this.garaje = frmOrdenar.Garaje;
                    ActualizarLstb();
                }
            }
            else
            {
                MessageBox.Show("Hay menos de dos objetos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Guarda un registro de acceso del usuario en un archivo de registro.
        /// </summary>
        private void ArchivarDatos()
        {
            string logPath = "usuarios.log";
            using (StreamWriter sw = File.AppendText(logPath))
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Usuario: {usuario.nombre} {usuario.apellido} accedió a la aplicación";
                sw.WriteLine(logEntry);
            }
        }

        /// <summary>
        /// Muestra el formulario para visualizar registros de acceso.
        /// </summary>
        private void btnVisualizador_Click(object sender, EventArgs e)
        {
            string logPath = "usuarios.log";
            FrmVisualizador frmVisualizador = new FrmVisualizador(logPath);

            frmVisualizador.Show();
        }

        /// <summary>
        /// Guarda la colección de vehículos en un archivo JSON.
        /// </summary>
        private void btnSerializar_Click(object sender, EventArgs e)
        {
            ArchivarColeccion();
        }

        /// <summary>
        /// Carga una colección de vehículos desde un archivo JSON.
        /// </summary>
        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            CargarColeccion();
        }

        /// <summary>
        /// Guarda un registro de acceso del usuario en un archivo de registro.
        /// </summary>
        private void ArchivarColeccion()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Archivos JSON|*.json";
            fileDialog.Title = "Guardar la colección";
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    };

                    string json = JsonConvert.SerializeObject(garaje, settings);

                    string rutaArchivo = fileDialog.FileName;

                    File.WriteAllText(rutaArchivo, json);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar los datos a JSON", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga una colección de vehículos desde un archivo JSON.
        /// </summary>
        private void CargarColeccion()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archivos JSON|*.json";
            fileDialog.Title = "Cargar la colección";

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = fileDialog.FileName;

                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    string json = File.ReadAllText(rutaArchivo);
                    garaje = JsonConvert.DeserializeObject<Garaje>(json, settings);

                    ActualizarLstb();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos desde JSON", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}