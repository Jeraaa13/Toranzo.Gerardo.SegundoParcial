using System;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un objeto de tipo Auto, que hereda de Vehículo.
    /// </summary>
    public class Auto : Vehiculo
    {
        public int NumeroPuertas { get; set; } = 4;
        public ETraccion Traccion { get; set; } = ETraccion.Delantera;

        public Auto() : base()
        {
        }

        public Auto(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
        }

        public Auto(int numeroPuertas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            NumeroPuertas = numeroPuertas;
        }

        public Auto(ETraccion traccion, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            Traccion = traccion;
        }

        public Auto(int numeroPuertas, ETraccion traccion, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            NumeroPuertas = numeroPuertas;
            Traccion = traccion;
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
            return $"Auto - {base.ToString()}, Puertas: {NumeroPuertas}, Traccion: {Traccion}";
        }

        /// <summary>
        /// Comprueba si un objeto es igual a esta instancia de Auto.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si el objeto es igual a esta instancia, False en caso contrario.</returns>
        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Auto auto && this == auto;
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
