using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un garaje para almacenar vehículos.
    /// </summary>
    public class Garaje
    {
        private List<Vehiculo> vehiculos;

        /// <summary>
        /// Obtiene o establece la lista de vehículos almacenados en el garaje.
        /// </summary>
        public List<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
            set { vehiculos = value; }
        }

        /// <summary>
        /// Constructor predeterminado de la clase Garaje.
        /// Inicializa una nueva instancia del garaje con una lista vacía de vehículos.
        /// </summary>
        public Garaje()
        {
            vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Sobrecarga del operador '+' que permite agregar un vehículo al garaje si no está presente.
        /// </summary>
        /// <param name="g1">Garaje al que se agregará el vehículo.</param>
        /// <param name="v1">Vehículo que se agregará al garaje.</param>
        /// <returns>El garaje con el vehículo agregado, si no estaba presente.</returns>

        public static Garaje operator +(Garaje g1, Vehiculo v1)
        {
            if (!g1.vehiculos.Contains(v1))
            {
                g1.vehiculos.Add(v1);
            }
            return g1;
        }

        /// <summary>
        /// Sobrecarga del operador '-' que permite eliminar un vehículo del garaje si está presente.
        /// </summary>
        /// <param name="g1">Garaje del que se eliminará el vehículo.</param>
        /// <param name="v1">Vehículo que se eliminará del garaje.</param>
        /// <returns>El garaje con el vehículo eliminado, si estaba presente.</returns>
        public static Garaje operator -(Garaje g1, Vehiculo v1)
        {
            if (g1.vehiculos.Contains(v1))
            {
                g1.vehiculos.Remove(v1);
            }
            return g1;
        }

        /// <summary>
        /// Comprueba si un vehículo está presente en el garaje.
        /// </summary>
        /// <param name="g1">Garaje en el que se buscará el vehículo.</param>
        /// <param name="v1">Vehículo que se buscará en el garaje.</param>
        /// <returns>True si el vehículo está presente en el garaje, False en caso contrario.</returns>
        public static bool operator ==(Garaje g1,Vehiculo v1)
        {
            if (g1 is null)
            {
                return false; 
            }

            return g1.vehiculos.Contains(v1);
        }

        /// <summary>
        /// Comprueba si un vehículo no está presente en el garaje.
        /// </summary>
        /// <param name="g1">Garaje en el que se buscará el vehículo.</param>
        /// <param name="v1">Vehículo que se buscará en el garaje.</param>
        /// <returns>True si el vehículo no está presente en el garaje, False en caso contrario.</returns>
        public static bool operator !=(Garaje g1, Vehiculo v1)
        {
            return !(g1 == v1);
        }

        /// <summary>
        /// Ordena la lista de vehículos en el garaje por año de fabricación, de forma ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">True para ordenar de forma ascendente, False para ordenar de forma descendente.</param>
        public void OrdenarPorAñoDeFabricacion(bool ascendente)
        {
            if (ascendente)
            {
                this.vehiculos = this.vehiculos.OrderBy(vehiculo => vehiculo.AñoFabricacion).ToList();
            }
            else
            {
                this.vehiculos = this.vehiculos.OrderByDescending(vehiculo => vehiculo.AñoFabricacion).ToList();
            }
        }

        /// <summary>
        /// Ordena la lista de vehículos en el garaje por marca de forma alfabética, de forma ascendente o descendente.
        /// </summary>
        /// <param name="ascendente">True para ordenar de forma ascendente, False para ordenar de forma descendente.</param>
        public void OrdenarPorMarcaAlfabeticamente(bool ascendente)
        {
            if (ascendente)
            {
                this.vehiculos = this.vehiculos.OrderBy(vehiculo => vehiculo.Marca).ToList();
            }
            else
            {
                this.vehiculos = this.vehiculos.OrderByDescending(vehiculo => vehiculo.Marca).ToList();
            }
        }

    }
}
