using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un objeto de tipo Camion, que hereda de Vehículo.
    /// </summary>
    public class Camion : Vehiculo
    {
        private double cargaMaxima;
        private int numeroEjes;

        /// <summary>
        /// Clase que representa un objeto de tipo Camion, que hereda de Vehículo.
        /// </summary>
        public double CargaMaxima
        {
            get { return cargaMaxima; }
            set { this.cargaMaxima = value; }
        }

        /// <summary>
        /// Obtiene o establece el número de ejes del Camion.
        /// </summary>
        public int NumeroEjes
        {
            get { return numeroEjes; }
            set { this.numeroEjes = value; }
        }

        /// <summary>
        /// Constructor predeterminado de la clase Camion.
        /// Inicializa la carga máxima en 17000 kilos y el número de ejes en 2.
        /// </summary>
        public Camion()
        {
            this.cargaMaxima = 17000;
            this.numeroEjes = 2;
        }

        /// <summary>
        /// Constructor de la clase Camion que recibe todos los parámetros basicos.
        /// </summary>
        /// <param name="marca">La marca del Camion.</param>
        /// <param name="modelo">El modelo del Camion.</param>
        /// <param name="añoFabricacion">El año de fabricación del Camion.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Camion.</param>
        public Camion(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cargaMaxima = 17000;
            this.numeroEjes = 2;
        }

        /// <summary>
        /// Constructor de la clase Camion que recibe todos los parámetros menos el numero de ejes.
        /// </summary>
        /// <param name="marca">La marca del Camion.</param>
        /// <param name="modelo">El modelo del Camion.</param>
        /// <param name="añoFabricacion">El año de fabricación del Camion.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Camion.</param>
        /// <param name="cargaMaxima">La cantidad de carga maxima</param>
        public Camion(double cargaMaxima, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cargaMaxima = cargaMaxima;
            this.numeroEjes = 2;
        }

        /// <summary>
        /// Constructor de la clase Camion que recibe todos los parámetros menos carga maxima.
        /// </summary>
        /// <param name="marca">La marca del Camion.</param>
        /// <param name="modelo">El modelo del Camion.</param>
        /// <param name="añoFabricacion">El año de fabricación del Camion.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Camion.</param>
        /// <param name="numeroEjes">Cantidad de ejes del Camion</param>
        public Camion(int numeroEjes, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroEjes = numeroEjes;
            this.cargaMaxima = 17000;
        }

        /// <summary>
        /// Constructor de la clase Camion que recibe todos parámetros.
        /// </summary>
        /// <param name="marca">La marca del Camion.</param>
        /// <param name="modelo">El modelo del Camion.</param>
        /// <param name="añoFabricacion">El año de fabricación del Camion.</param>
        /// <param name="tipoCombustible">El tipo de combustible del Camion.</param>
        /// <param name="numeroEjes">Cantiadad de ejes del Camion</param>
        /// <param name="cargaMaxima">Carga maxima del Camion</param>
        public Camion(double cargaMaxima, int numeroEjes, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cargaMaxima = cargaMaxima;
            this.numeroEjes = numeroEjes;
        }

        /// <summary>
        /// Inicia el Camion.
        /// </summary>
        public override void Arrancar()
        {
            Console.WriteLine("El camión está arrancando.");
        }

        /// <summary>
        /// Detiene el Camion.
        /// </summary>
        public override void Detener()
        {
            Console.WriteLine("El camión se ha detenido.");
        }

        /// <summary>
        /// Devuelve una representación en cadena del objeto Camion.
        /// </summary>
        /// <returns>Una cadena que representa el objeto Camion.</returns>
        public override string ToString()
        {
            return $"Camión - Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Combustible: {TipoCombustible}, Carga Máxima: {cargaMaxima} toneladas, Ejes: {numeroEjes}";
        }

        /// <summary>
        /// Comprueba si un objeto es igual a esta instancia de Camion.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si el objeto es igual a esta instancia, False en caso contrario.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Camion)
            {
                retorno = this == (Camion)obj;
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo Camion son iguales.
        /// </summary>
        /// <param name="c1">Primer objeto de tipo Camion.</param>
        /// <param name="c2">Segundo objeto de tipo Camion.</param>
        /// <returns>True si los objetos son iguales, False en caso contrario.</returns>
        public static bool operator ==(Camion c1, Camion c2)
        {
            return c1.numeroEjes == c2.numeroEjes && c1.cargaMaxima == c2.cargaMaxima;
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo Camion son diferentes.
        /// </summary>
        /// <param name="c1">Primer objeto de tipo Camion.</param>
        /// <param name="c2">Segundo objeto de tipo Camion.</param>
        /// <returns>True si los objetos son diferentes, False en caso contrario.</returns>
        public static bool operator !=(Camion camion1, Camion camion2)
        {
            return !(camion1 == camion2);
        }
    }
}