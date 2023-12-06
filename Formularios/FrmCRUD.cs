using Entidades;
using Newtonsoft.Json;
using System;
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
        private AccesoDatos accesoDatos;
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
            this.lblPerfil.Text = "Perfil: " + usuario.perfil;
            this.accesoDatos = new AccesoDatos();

            if (usuario.perfil == "vendedor")
            {
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
                btnVisualizador.Visible = false;
            }
            else if (usuario.perfil == "supervisor")
            {
                btnEliminar.Visible = false;
                btnVisualizador.Visible = false;
            }
        }
        #endregion

        #region Delegados
        public delegate void OperacionCompletadaEventHandler(bool exito, string mensaje);
        #endregion

        #region Eventos
        public event OperacionCompletadaEventHandler OperacionCompletada;
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
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmTipo frmtipo = new FrmTipo(true);

            DialogResult resultado = frmtipo.ShowDialog();
            if (resultado == DialogResult.OK && frmtipo.Vehiculo != null)
            {
                string tipoVehiculo = ObtenerTipoVehiculo(frmtipo.Vehiculo);

                await InsetarVehiculoAsync(frmtipo.Vehiculo);
                OperacionCompletada?.Invoke(true, "Insercion de datos completada exitosamente");
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

                Vehiculo vehiculo = garaje.Vehiculos[index];

                garaje -= vehiculo;

                string tabla = vehiculo.GetType().ToString();

                tabla = tabla.Substring(tabla.LastIndexOf('.') + 1);

                this.accesoDatos.EliminarVehiculo<Vehiculo>(vehiculo, tabla);

                ActualizarLstb();
            }
        }

        /// <summary>
        /// Evento para modificar un vehículo seleccionado.
        /// Permite modificar los detalles del vehículo seleccionado.
        /// </summary>
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.lstbRead.SelectedIndex != -1)
            {
                int index = lstbRead.SelectedIndex;
                object objeto = garaje.Vehiculos[index];

                DialogResult resultado;
                if (objeto is Auto)
                {
                    FrmAuto frmAuto = new FrmAuto((Auto)objeto);
                    this.OperacionCompletada += ManejarOperacionCompletada;

                    resultado = frmAuto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        await ModificarVehiculoAsync(frmAuto.Auto);
                        OperacionCompletada?.Invoke(true, "Modificacion de datos completada exitosamente");
                        garaje.Vehiculos[index] = frmAuto.Auto;
                    }
                }
                else if (objeto is Moto)
                {
                    FrmMoto frmMoto = new FrmMoto((Moto)objeto);
                    this.OperacionCompletada += ManejarOperacionCompletada;


                    resultado = frmMoto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        await ModificarVehiculoAsync(frmMoto.Moto);
                        garaje.Vehiculos[index] = frmMoto.Moto;

                    }
                }
                else if (objeto is Camion)
                {
                    FrmCamion frmCamion = new FrmCamion((Camion)objeto);
                    this.OperacionCompletada += ManejarOperacionCompletada;

                    resultado = frmCamion.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        await ModificarVehiculoAsync(frmCamion.Camion);
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
                listaVehiculos = accesoDatos.LeerListas<Auto>(this.accesoDatos.MapearAuto, "Auto");
            }
            else if (frmtipo.Eleccion == 1)
            {
                listaVehiculos = accesoDatos.LeerListas<Camion>(this.accesoDatos.MapearCamion, "Camion");
            }
            else if (frmtipo.Eleccion == 2)
            {
                listaVehiculos = accesoDatos.LeerListas<Moto>(this.accesoDatos.MapearMoto, "Moto");
            }
            if (listaVehiculos != null && listaVehiculos.Count > 0)
            {
                foreach (Vehiculo vehiculo in listaVehiculos)
                {
                    garaje += vehiculo;
                }
                ActualizarLstb();
            }
            else
            {
                MessageBox.Show("La tabla esta vacia", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Metodos
        private void ManejarOperacionCompletada(bool exito, string mensaje)
        {
            if (exito)
            {
                MessageBox.Show($"{mensaje}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task InsetarVehiculoAsync(Vehiculo vehiculo)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (vehiculo is Auto auto)
                    {
                        this.accesoDatos.InsertarVehiculo<Auto>(auto, "Auto");
                    }
                    else if (vehiculo is Moto moto)
                    {
                        this.accesoDatos.InsertarVehiculo<Moto>(moto, "Moto");
                    }
                    else if (vehiculo is Camion camion)
                    {
                        this.accesoDatos.InsertarVehiculo<Camion>(camion, "Camion");

                    }
                });
            }
            catch (Exception ex)
            {
                OperacionCompletada?.Invoke(false, $"Error al insertar vehiculo: {ex.Message}");
            }
        }
        private async Task ModificarVehiculoAsync(Vehiculo vehiculo)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (vehiculo is Auto auto)
                    {
                        this.accesoDatos.ModificarVehiculo<Auto>(auto, "Auto");
                    }
                    else if (vehiculo is Moto moto)
                    {
                        this.accesoDatos.ModificarVehiculo<Moto>(moto, "Moto");
                    }
                    else if (vehiculo is Camion camion)
                    {
                        this.accesoDatos.ModificarVehiculo<Camion>(camion, "Camion");
                    }
                });
            }
            catch (Exception ex)
            {
                OperacionCompletada?.Invoke(false, $"Error al modificar vehiculo: {ex.Message}");
            }
        }
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
        #endregion
    }
}