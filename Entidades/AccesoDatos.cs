using Microsoft.Azure.Amqp.Framing;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

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

        #region Delegados
        public delegate T DelegadoMapear<T>(SqlDataReader reader);
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

        public List<Vehiculo> LeerListas(Func<SqlDataReader, Vehiculo> mapeador, string tabla)
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            using (SqlConnection conexion = new SqlConnection(connectionStr))
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM {tabla}";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                try
                {
                    this.lector = this.comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Vehiculo vehiculo = mapeador(lector);
                        listaVehiculos.Add(vehiculo);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer la base de datos: {ex.Message}");
                }
                finally
                {
                    if (this.conexion.State == ConnectionState.Open)
                    {
                        this.conexion.Close();
                    }
                }
            }
            return listaVehiculos;
        }


        public Auto MapearAuto(SqlDataReader reader)
        {
            Auto auto = new Auto();
            auto.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            auto.Marca = reader.GetString(reader.GetOrdinal("Marca"));
            auto.Modelo = reader.GetString(reader.GetOrdinal("Modelo"));
            auto.AñoFabricacion = reader.GetInt32(reader.GetOrdinal("AñoFabricacion"));
            auto.TipoCombustible = (ETipoCombustible)reader.GetInt32(reader.GetOrdinal("Combustible"));
            auto.NumeroPuertas = reader.GetInt32(reader.GetOrdinal("NumeroPuertas"));
            auto.Traccion = (ETraccion)reader.GetInt32(reader.GetOrdinal("Traccion"));
            return auto;
        }

        public Camion MapearCamion(SqlDataReader reader)
        {
            Camion camion = new Camion();
            camion.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            camion.Marca = reader.GetString(reader.GetOrdinal("Marca"));
            camion.Modelo = reader.GetString(reader.GetOrdinal("Modelo"));
            camion.AñoFabricacion = reader.GetInt32(reader.GetOrdinal("AñoFabricacion"));
            camion.TipoCombustible = (ETipoCombustible)reader.GetInt32(reader.GetOrdinal("Combustible"));
            camion.CargaMaxima = reader.GetInt32(reader.GetOrdinal("CargaMaxima"));
            camion.NumeroEjes = reader.GetInt32(reader.GetOrdinal("NumeroEjes"));
            return camion;
        }

        public Moto MapearMoto(SqlDataReader reader)
        {
            Moto moto = new Moto();
            moto.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            moto.Marca = reader.GetString(reader.GetOrdinal("Marca"));
            moto.Modelo = reader.GetString(reader.GetOrdinal("Modelo"));
            moto.AñoFabricacion = reader.GetInt32(reader.GetOrdinal("AñoFabricacion"));
            moto.TipoCombustible = (ETipoCombustible)reader.GetInt32(reader.GetOrdinal("Combustible"));
            moto.Cilindrada = reader.GetInt32(reader.GetOrdinal("Cilindrada"));
            moto.TipoRuedas = (ETipoRuedas)reader.GetInt32(reader.GetOrdinal("TipoRuedas"));
            return moto;
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