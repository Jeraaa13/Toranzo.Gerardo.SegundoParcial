using Entidades;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Formularios
{
    /// <summary>
    /// Formulario principal de la aplicación para realizar operaciones CRUD en vehículos.
    /// </summary>
    public partial class FrmCRUD : Form
    {
        #region Atributos
        private Usuario usuario;
        private FrmLogin login;
        private Garaje garaje = new Garaje();
        private AccesoDatos accesoDatos = new AccesoDatos();
        #endregion

        #region Constructores
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
        #endregion

        #region Delegados
        public delegate Vehiculo MapeadorVehiculo(SqlDataReader reader);
        #endregion

        #region Eventos
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
            FrmTipo frmtipo = new FrmTipo(true);

            DialogResult resultado = frmtipo.ShowDialog();
            if (resultado == DialogResult.OK && frmtipo.Vehiculo != null)
            {
                string tipoVehiculo = ObtenerTipoVehiculo(frmtipo.Vehiculo);

                accesoDatos.InsertarVehiculo(frmtipo.Vehiculo, tipoVehiculo);
                garaje += frmtipo.Vehiculo;
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
                        accesoDatos.ModificarDatos(frmAuto.Auto, "Auto");
                        garaje.Vehiculos[index] = frmAuto.Auto;
                    }
                }
                else if (objeto is Moto)
                {
                    FrmMoto frmMoto = new FrmMoto((Moto)objeto);

                    resultado = frmMoto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        accesoDatos.ModificarDatos(frmMoto.Moto, "Moto");
                        garaje.Vehiculos[index] = frmMoto.Moto;

                    }
                }
                else if (objeto is Camion)
                {
                    FrmCamion frmCamion = new FrmCamion((Camion)objeto);

                    resultado = frmCamion.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        accesoDatos.ModificarDatos(frmCamion.Camion, "Camion");
                        garaje.Vehiculos[index] = frmCamion.Camion;
                    }
                }
                ActualizarLstb();
            }
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
        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            List<Vehiculo> listaVehiculos = null;

            FrmTipo frmtipo = new FrmTipo(false);

            DialogResult resultado = frmtipo.ShowDialog();

            if (resultado == DialogResult.Cancel)
            {
                return;
            }
            if (frmtipo.Eleccion == 0)
            {
                listaVehiculos = accesoDatos.LeerListas(this.accesoDatos.MapearAuto, "Auto");
            }
            else if (frmtipo.Eleccion == 1)
            {
                listaVehiculos = accesoDatos.LeerListas(this.accesoDatos.MapearCamion, "Camion");
            }
            else if (frmtipo.Eleccion == 2)
            {
                listaVehiculos = accesoDatos.LeerListas(this.accesoDatos.MapearMoto, "Moto");
            }
            if (listaVehiculos != null)
            {
                foreach (Vehiculo vehiculo in listaVehiculos)
                {
                    garaje += vehiculo;
                }
                ActualizarLstb();
            }
        }
        #endregion

        #region Metodos
        private string ObtenerTipoVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo is Auto)
                return "Auto";
            else if (vehiculo is Moto)
                return "Moto";
            else if (vehiculo is Camion)
                return "Camion";

            throw new InvalidOperationException("Tipo de vehiculo indefinido");
        }

        /// <summary>
        /// Actualiza el contenido de la lista de vehículos en el formulario.
        /// </summary>
        private void ActualizarLstb()
        {
            this.lstbRead.Items.Clear();

            foreach (Vehiculo vehiculo in garaje.Vehiculos)
            {
                this.lstbRead.Items.Add(vehiculo.ToString());
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

        #endregion
    }
}