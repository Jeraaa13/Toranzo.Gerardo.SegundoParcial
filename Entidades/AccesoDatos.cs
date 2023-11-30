using Microsoft.Azure.Amqp.Framing;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class AccesoDatos
    {
        #region Atributos
        private SqlConnection conexion;
        private static string connectionStr;
        public SqlCommand comando;
        private SqlDataReader lector;
        #endregion

        #region Constructores       
        static AccesoDatos()
        {
            AccesoDatos.connectionStr = Properties.Resources.miConexion;
        }
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.connectionStr);
        }
        #endregion

        #region Metodo
        public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

        public List<Vehiculo> ObtenerListaVehiculos()
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            using (SqlConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string query = @"
                SELECT 'Auto' AS TipoVehiculo, Id, Marca, Modelo, AñoFabricacion, Combustible, NumeroPuertas, Traccion
                FROM Auto
                UNION
                SELECT 'Moto' AS TipoVehiculo, Id, Marca, Modelo, AñoFabricacion, Combustible, Cilindrada, TipoRuedas
                UNION
                SELECT 'Camion' AS TipoVehiculo, Id, Marca, Modelo, AñoFabricacion, CargaMaxima, NumeroEjes
                FROM Camion";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehiculo vehiculo = Constru
                        }
                    }
                }
            }
            return listaVehiculos;
        }

        public bool InsertarVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo
        {
            bool retorno = false;

            using (SqlConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                string parametros = "";
                string values = "";

                using (SqlCommand comando = new SqlCommand("", conexion))
                {
                    comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                    comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                    comando.Parameters.AddWithValue("@AñoFabricacion", vehiculo.AñoFabricacion);
                    comando.Parameters.AddWithValue("@Combustible", vehiculo.TipoCombustible);

                    if (vehiculo is Auto auto)
                    {
                        parametros = "(Marca, Modelo, AñoFabricacion, Combustible, NumeroPuertas, Traccion)";
                        values = "(@Marca, @Modelo, @AñoFabricacion, @Combustible, @NumeroPuertas, @Traccion)";
                        comando.Parameters.AddWithValue("@NumeroPuertas", auto.NumeroPuertas);
                        comando.Parameters.AddWithValue("@Traccion", auto.Traccion);
                    }
                    else if (vehiculo is Moto moto)
                    {
                        parametros = "(Marca, Modelo, AñoFabricacion, Combustible, Cilindrada, TipoRuedas)";
                        values = "(@Marca, @Modelo, @AñoFabricacion, @Combustible, @Cilindrada, @TipoRuedas)";
                        comando.Parameters.AddWithValue("@Cilindrada", moto.Cilindrada);
                        comando.Parameters.AddWithValue("@TipoRuedas", moto.TipoRuedas);
                    }
                    else if (vehiculo is Camion camion)
                    {
                        parametros = "(Marca, Modelo, AñoFabricacion, Combustible, CargaMaxima, NumeroEjes)";
                        values = "(@Marca, @Modelo, @AñoFabricacion, @Combustible, @CargaMaxima, @NumeroEjes)";
                        comando.Parameters.AddWithValue("@CargaMaxima", camion.CargaMaxima);
                        comando.Parameters.AddWithValue("@NumeroEjes", camion.NumeroEjes);
                    }

                    comando.CommandText = $"INSERT INTO {tabla} {parametros} VALUES {values}";
                    try
                    {
                        comando.ExecuteNonQuery();
                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al insertar vehiculo: {ex.Message}");
                        retorno = false;
                    }
                }
            }
            return retorno;
        }

        public bool ModificarDatos(Vehiculo v)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@marca", v.Marca);
                this.comando.Parameters.AddWithValue("@modelo", v.Modelo);
                this.comando.Parameters.AddWithValue("@añoFabricacion", v.AñoFabricacion);
                this.comando.Parameters.AddWithValue("@tipoCombustible", v.TipoCombustible);
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"UPDATE dato SET marca=@marca,modelo=@modelo,añoFabricacion=@añoFabricacion,tipoCombustible=@tipoCombustible WHERE id = @id";

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error al modificar datos en la base de datos", ex);
            }

            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }
        #endregion
    }
}