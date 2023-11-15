using System;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un vehículo de tipo moto.
    /// </summary>
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private ETipoRuedas tipoRuedas;

        /// <summary>
        /// Obtiene o establece la cilindrada de la moto en centímetros cúbicos (cc).
        /// </summary>
        public int Cilindrada
        {
            get { return cilindrada; }
            set { this.cilindrada = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de ruedas de la moto.
        /// </summary>
        public ETipoRuedas TipoRuedas
        {
            get { return tipoRuedas; }
            set { this.tipoRuedas = value; }
        }

        /// <summary>
        /// Constructor predeterminado de la clase Moto.
        /// Inicializa una nueva instancia de moto con cilindrada de 125 cc y ruedas normales.
        /// </summary>
        public Moto()
        {
            this.cilindrada = 125;
            this.tipoRuedas = ETipoRuedas.RuedasNormales;
        }

        /// <summary>
        /// Constructor de la clase Moto con parámetros.
        /// Inicializa una nueva instancia de moto con los parámetros basicos especificados.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="modelo">Modelo de la moto.</param>
        /// <param name="añoFabricacion">Año de fabricación de la moto.</param>
        /// <param name="tipoCombustible">Tipo de combustible de la moto.</param>
        public Moto(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cilindrada = 125;
            this.tipoRuedas = ETipoRuedas.RuedasNormales;
        }

        /// <summary>
        /// Constructor de la clase Moto con parámetros.
        /// Inicializa una nueva instancia de moto con todos los parámetros menos el tipo de ruedas.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="modelo">Modelo de la moto.</param>
        /// <param name="añoFabricacion">Año de fabricación de la moto.</param>
        /// <param name="tipoCombustible">Tipo de combustible de la moto.</param>
        /// <param name="cilindrada">La cilindrada de la moto</param>
        public Moto(int cilindrada, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cilindrada = cilindrada;
            this.tipoRuedas = ETipoRuedas.RuedasNormales;
        }

        /// <summary>
        /// Constructor de la clase Moto con parámetros.
        /// Inicializa una nueva instancia de moto con todos los parámetros menos la cilindrada.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="modelo">Modelo de la moto.</param>
        /// <param name="añoFabricacion">Año de fabricación de la moto.</param>
        /// <param name="tipoCombustible">Tipo de combustible de la moto.</param>
        /// <param name="tipoRuedas">El tipo de ruedas de la moto</param>
        public Moto(ETipoRuedas tipoRuedas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.tipoRuedas = tipoRuedas;
            this.cilindrada = 125;
        }

        /// <summary>
        /// Constructor de la clase Moto con parámetros.
        /// Inicializa una nueva instancia de moto con todos los parámetros.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="modelo">Modelo de la moto.</param>
        /// <param name="añoFabricacion">Año de fabricación de la moto.</param>
        /// <param name="tipoCombustible">Tipo de combustible de la moto.</param>
        /// <param name="tipoRuedas">El tipo de ruedas de la moto.</param>
        /// <param name="cilindrada">La cilindrada de la moto.</param>
        public Moto(int cilindrada, ETipoRuedas tipoRuedas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cilindrada = cilindrada;
            this.tipoRuedas = tipoRuedas;
        }

        /// <summary>
        /// Constructor de la clase Moto con parámetros.
        /// Inicializa una nueva instancia de moto con todos los parámetros menos el tipo de ruedas.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="modelo">Modelo de la moto.</param>
        /// <param name="añoFabricacion">Año de fabricación de la moto.</param>
        /// <param name="tipoCombustible">Tipo de combustible de la moto.</param>
        public override void Arrancar()
        {
            Console.WriteLine("La moto está arrancando.");
        }

        /// <summary>
        /// Simula el proceso de detener la moto.
        /// </summary>
        public override void Detener()
        {
            Console.WriteLine("La moto se ha detenido.");
        }

        /// <summary>
        /// Devuelve una representación en formato de cadena de la moto.
        /// </summary>
        /// <returns>Una cadena que representa la moto con sus propiedades.</returns>
        public override string ToString()
        {
            return $"Moto - Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Combustible: {TipoCombustible}, Cilindrada: {cilindrada} cc, Tipo: {tipoRuedas}";
        }

        /// <summary>
        /// Compara si dos motos son iguales basándose en su cilindrada y tipo de ruedas.
        /// </summary>
        /// <param name="obj">El objeto a comparar con la moto actual.</param>
        /// <returns>True si las motos son iguales, False en caso contrario.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Moto)
            {
                retorno = this == (Moto)obj;
            }
            return retorno;
        }

        /// <summary>
        /// Compara si dos motos son diferentes basándose en su cilindrada y tipo de ruedas.
        /// </summary>
        /// <param name="m1">La primera moto a comparar.</param>
        /// <param name="m2">La segunda moto a comparar.</param>
        /// <returns>True si las motos son diferentes, False en caso contrario.</returns>
        public static bool operator ==(Moto m1, Moto m2)
        {
            return m1.cilindrada == m2.cilindrada && m1.tipoRuedas == m2.tipoRuedas;
        }

        /// <summary>
        /// Compara si dos motos son iguales basándose en su cilindrada y tipo de ruedas.
        /// </summary>
        /// <param name="m1">La primera moto a comparar.</param>
        /// <param name="m2">La segunda moto a comparar.</param>
        /// <returns>True si las motos son iguales, False en caso contrario.</returns>
        public static bool operator !=(Moto m1, Moto m2)
        {
            return !(m1 == m2);
        }
    }
}
