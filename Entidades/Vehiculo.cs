using System.Text.Json.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que representa un vehículo.
    /// </summary>
    public abstract class Vehiculo
    {
        protected string marca;
        protected string modelo;
        protected int añoFabricacion;
        protected ETipoCombustible tipoCombustible;

        /// <summary>
        /// Obtiene o establece la marca del vehículo.
        /// </summary>
        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        /// <summary>
        /// Obtiene o establece el modelo del vehículo.
        /// </summary>
        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        /// <summary>
        /// Obtiene o establece el año de fabricación del vehículo.
        /// </summary>
        public int AñoFabricacion
        {
            get { return this.añoFabricacion; }
            set { this.añoFabricacion = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de combustible del vehículo.
        /// </summary>
        public ETipoCombustible TipoCombustible
        {
            get { return this.tipoCombustible; }
            set { this.tipoCombustible = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de combustible del vehículo.
        /// </summary>
        [JsonConstructor]
        public Vehiculo()
        {
            this.marca = "Default";
            this.modelo = "Default";
            this.añoFabricacion = 2000;
            this.tipoCombustible = ETipoCombustible.Gasolina;
        }

        /// <summary>
        /// Constructor de la clase Vehiculo con marca y modelo.
        /// </summary>
        /// <param name="marca">La marca del vehículo.</param>
        /// <param name="modelo">El modelo del vehículo.</param>
        public Vehiculo(string marca, string modelo)
        {
            this.marca = marca;
            this.modelo = modelo;
        }

        /// <summary>
        /// Constructor de la clase Vehiculo con marca, modelo y año de fabricación.
        /// </summary>
        /// <param name="marca">La marca del vehículo.</param>
        /// <param name="modelo">El modelo del vehículo.</param>
        /// <param name="añoFabricacion">El año de fabricación del vehículo.</param>
        public Vehiculo(string marca, string modelo, int añoFabricacion) : this(marca, modelo)
        {
            this.añoFabricacion = añoFabricacion;
        }

        /// <summary>
        /// Constructor de la clase Vehiculo con marca, modelo, año de fabricación y tipo de combustible.
        /// </summary>
        /// <param name="marca">La marca del vehículo.</param>
        /// <param name="modelo">El modelo del vehículo.</param>
        /// <param name="añoFabricacion">El año de fabricación del vehículo.</param>
        /// <param name="tipoCombustible">El tipo de combustible del vehículo.</param>
        public Vehiculo(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible) 
            : this(marca, modelo, añoFabricacion)
        {
            this.tipoCombustible = tipoCombustible;
        }

        /// <summary>
        /// Arranca el vehículo.
        /// </summary>
        public abstract void Arrancar();

        /// <summary>
        /// Arranca el vehículo.
        /// </summary>
        public virtual void Detener()
        {
            Console.WriteLine("El vehículo se ha detenido.");
        }

        /// <summary>
        /// Convierte el objeto a una representación de cadena.
        /// </summary>
        /// <returns>Una cadena que representa el vehículo.</returns>
        public override string ToString()
        {
            return $"Marca: {Marca}, Modelo: {Modelo}, Año de Fabricación: {AñoFabricacion}, Tipo de Combustible: {TipoCombustible}";
        }

        /// <summary>
        /// Determina si dos vehículos son iguales.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si los vehículos son iguales; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Vehiculo)
            {
                retorno = this == (Vehiculo)obj;
            }
            return retorno;
        }

        /// <summary>
        /// Compara dos vehículos para determinar si son iguales.
        /// </summary>
        /// <param name="v1">El primer vehículo a comparar.</param>
        /// <param name="v2">El segundo vehículo a comparar.</param>
        /// <returns>True si los vehículos son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.marca == v2.marca && v1.modelo == v2.modelo;
        }

        /// <summary>
        /// Compara dos vehículos para determinar si son diferentes.
        /// </summary>
        /// <param name="v1">El primer vehículo a comparar.</param>
        /// <param name="v2">El segundo vehículo a comparar.</param>
        /// <returns>True si los vehículos son diferentes; de lo contrario, false.</returns>
        public static bool operator !=(Vehiculo? v1, Vehiculo? v2)
        {
            if (ReferenceEquals(v1, null) && ReferenceEquals(v2, null))
            {
                return false;
            }
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
            {
                return true; 
            }
            return !(v1 == v2);
        }
    }
}