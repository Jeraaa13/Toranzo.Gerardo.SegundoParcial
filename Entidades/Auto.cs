using System;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un objeto de tipo Auto, que hereda de Vehículo.
    /// </summary>
    public class Auto : Vehiculo
    {
        private int numeroPuertas;
        private ETraccion traccion;

        /// <summary>
        /// Obtiene o establece el número de puertas del Auto.
        /// </summary>
        public int NumeroPuertas
        {
            get { return numeroPuertas; }
            set { this.numeroPuertas = value; }
        }

        /// <summary>
        /// Obtiene o establece la tracción del Auto.
        /// </summary>
        public ETraccion Traccion
        {
            get { return traccion; }
            set { this.traccion = value; }
        }

        /// <summary>
        /// Constructor predeterminado de la clase Auto.
        /// Inicializa el número de puertas en 4 y la tracción como Delantera.
        /// </summary>
        public Auto()
        {
            this.numeroPuertas = 4;
            this.traccion = ETraccion.Delantera;
        }

        /// <summary>
        /// Constructor de la clase Auto que recibe todos los parámetros menos traccion y numero de puertas.
        /// </summary>
        /// <param name="marca">La marca del Auto.</param>
        /// <param name="modelo">El modelo del Auto.</param>
        /// <param name="añoFabricacion">El año de fabricación del Auto.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Auto.</param>
        public Auto(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroPuertas = 4;
            this.traccion = ETraccion.Delantera;
        }

        /// <summary>
        /// Constructor de la clase Auto que recibe todos los parámetros menos traccion.
        /// </summary>
        /// <param name="marca">La marca del Auto.</param>
        /// <param name="modelo">El modelo del Auto.</param>
        /// <param name="añoFabricacion">El año de fabricación del Auto.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Auto.</param>
        /// <param name="numeroPuertas">La cantidad de puertas del Auto</param>
        public Auto(int numeroPuertas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroPuertas = numeroPuertas;
            this.traccion = ETraccion.Delantera;
        }

        /// <summary>
        /// Constructor de la clase Auto que recibe todos los parámetros menos numeroPuertas.
        /// </summary>
        /// <param name="marca">La marca del Auto.</param>
        /// <param name="modelo">El modelo del Auto.</param>
        /// <param name="añoFabricacion">El año de fabricación del Auto.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Auto.</param>
        /// <param name="traccion">El tipo de traccion del Auto</param>
        public Auto(ETraccion traccion, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.traccion = traccion;
            this.numeroPuertas = 4;
        }

        /// <summary>
        /// Constructor de la clase Auto que recibe todos los parámetros.
        /// </summary>
        /// <param name="marca">La marca del Auto.</param>
        /// <param name="modelo">El modelo del Auto.</param>
        /// <param name="añoFabricacion">El año de fabricación del Auto.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Auto.</param>
        /// <param name="numeroPuertas">La cantidad de puertas del Auto</param>
        /// <param name="traccion">El tipo de traccion del Auto</param>
        public Auto(int numeroPuertas, ETraccion traccion, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroPuertas = numeroPuertas;
            this.traccion = traccion;
        }

        /// <summary>
        /// Inicia el Auto.
        /// </summary>
        public override void Arrancar()
        {
            Console.WriteLine("El auto está arrancando.");
        }

        /// <summary>
        /// Devuelve una representación en cadena del objeto Auto.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Auto.</returns>
        public override void Detener()
        {
            Console.WriteLine("El auto se ha detenido.");
        }

        /// <summary>
        /// Devuelve una representación en cadena del objeto Auto.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Auto.</returns>
        public override string ToString()
        {
            return $"Auto - Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Combustible:" +
                    $" {TipoCombustible}, Puertas: {numeroPuertas}, Tracción: {traccion}";
        }

        /// <summary>
        /// Comprueba si un objeto es igual a esta instancia de Auto.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si el objeto es igual a esta instancia, False en caso contrario.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Auto)
            {
                retorno = this == (Auto)obj;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo Auto son iguales.
        /// </summary>
        /// <param name="a1">Primer objeto de tipo Auto.</param>
        /// <param name="a2">Segundo objeto de tipo Auto.</param>
        /// <returns>True si los objetos son iguales, False en caso contrario.</returns>
        public static bool operator ==(Auto a1, Auto a2)
        {
            return a1.marca == a2.marca && a1.modelo == a2.modelo;
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo Auto son diferentes.
        /// </summary>
        /// <param name="a1">Primer objeto de tipo Auto.</param>
        /// <param name="a2">Segundo objeto de tipo Auto.</param>
        /// <returns>True si los objetos son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Auto a1, Auto a2)
        {
            return !(a1 == a2);
        }
    }
}
