using System;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un usuario.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string? apellido { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        public string? nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el número de legajo del usuario.
        /// </summary>
        public int legajo { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        public string? correo { get; set; }

        /// <summary>
        /// Obtiene o establece la clave de acceso del usuario.
        /// </summary>
        public string? clave { get; set; }

        /// <summary>
        /// Obtiene o establece el perfil o rol del usuario.
        /// </summary>
        public string? perfil { get; set; }
    }
}
