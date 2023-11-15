using System;
using System.Security.Policy;
using System.Text.Json;
using Entidades;

namespace Formularios
{
    /// <summary>
    /// Formulario de inicio de sesión.
    /// </summary>
    public partial class FrmLogin : Form
    {
        private Usuario[]? usuarios;

        /// <summary>
        /// Constructor de la clase FrmLogin.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se dispara al cargar el formulario.
        /// </summary>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Cargar usuarios desde un archivo JSON.
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "MOCK_DATA.json");

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    usuarios = JsonSerializer.Deserialize<Usuario[]>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón de inicio de sesión.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool credencialesValidas = false;

            foreach (Usuario usuario in usuarios)
            {
                if (txtCorreo.Text == usuario.correo && txtContraseña.Text == usuario.clave)
                {
                    credencialesValidas = true;

                    FrmCRUD crud = new FrmCRUD(this, usuario);
                    crud.Show();
                    this.Hide();

                    break;
                }
            }

            if (!credencialesValidas)
            {
                MessageBox.Show(
                    "Credenciales inválidas",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtContraseña.Clear();
                txtCorreo.Clear();
            }
        }
    }
}
