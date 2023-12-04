using Microsoft.Azure.Amqp.Framing;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
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
        DelegadoConfigurarParametros configurarParametrosAuto = (comando, vehiculo) => SetearParametrosAuto(comando, (Auto)vehiculo);
        DelegadoConfigurarParametros configurarParametrosMoto = (comando, vehiculo) => SetearParametrosMoto(comando, (Moto)vehiculo);
        DelegadoConfigurarParametros configurarParametrosCamion = (comando, vehiculo) => SetearParametrosCamion(comando, (Camion)vehiculo);
        #endregion

        #region Constructores       
        public AccesoDatos()
        {
            connectionStr = Properties.Resources.miConexion;
            conexion = new SqlConnection(connectionStr);
        }
        #endregion

        #region Delegados
        public delegate T DelegadoMapear<T>(SqlDataReader reader);
        public delegate void DelegadoConfigurarParametros(SqlCommand comando, Vehiculo vehiculo);
        #endregion

        #region Metodo
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
            string parametros = "(Marca, Modelo, AñoFabricacion, Combustible,";
            string values = "(@Marca, @Modelo, @AñoFabricacion, @Combustible,";

            using (SqlConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                if (ExisteVehiculo(vehiculo, tabla))
                {
                    Console.WriteLine("El vehiculo ya existe en la base de datos");
                    return false;
                }

                if (comando == null)
                {
                    comando = new SqlCommand("", conexion);
                }
                else
                {
                    comando.Connection = conexion;
                }

                if (vehiculo is Auto auto)
                {
                    parametros += " NumeroPuertas, Traccion)";
                    values += " @NumeroPuertas, @Traccion)";
                    configurarParametrosAuto(comando, auto);
                }
                else if (vehiculo is Moto moto)
                {
                    parametros += " Cilindrada, TipoRuedas)";
                    values += " @Cilindrada, @TipoRuedas)";
                    configurarParametrosMoto(comando, moto);
                }
                else if (vehiculo is Camion camion)
                {
                    parametros += " CargaMaxima, NumeroEjes)";
                    values += " @CargaMaxima, @NumeroEjes)";
                    configurarParametrosCamion(comando, camion);
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
            return retorno;
        }
        private bool ExisteVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo
        {
            using (SqlConnection conexion = new SqlConnection(connectionStr))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand("", conexion))
                {
                    comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                    comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);

                    comando.CommandText = $"SELECT COUNT(*) FROM {tabla} WHERE Marca = @Marca AND Modelo = @Modelo";

                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
        public bool ModificarDatos(Vehiculo vehiculo, string tabla)
        {
            bool retorno = false;

            string values = "Marca = @Marca, Modelo = @Modelo, AñoFabricacion = @AñoFabricacion, Combustible = @Combustible,";

            using (SqlCommand comando = new SqlCommand())
            {
                comando.CommandType = CommandType.Text;

                if (vehiculo is Auto auto)
                {
                    values += " numeroPuertas = @numeroPuertas, traccion = @traccion";
                    configurarParametrosAuto(comando, auto);
                }
                else if (vehiculo is Moto moto)
                {
                    values += " cilindrada = @cilindrada, tipoRuedas = @tipoRuedas";
                    configurarParametrosMoto(comando, moto);
                }
                else if (vehiculo is Camion camion)
                {
                    values += " cargaMaxima = @cargaMaxima, numeroEjes = @numeroEjes";
                    configurarParametrosCamion(comando, camion);
                }

                try
                {
                    comando.CommandText = $"UPDATE {tabla} SET {values} WHERE id = @id";

                    comando.Connection = conexion;

                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();

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
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }

            return retorno;
        }

        public static void SetearParametrosVehiculo(SqlCommand comando, Vehiculo vehiculo)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@Id", vehiculo.Id);
            comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
            comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
            comando.Parameters.AddWithValue("@AñoFabricacion", vehiculo.AñoFabricacion);
            comando.Parameters.AddWithValue("@Combustible", vehiculo.TipoCombustible);
        }
        public static void SetearParametrosAuto(SqlCommand comando, Auto auto)
        {
            SetearParametrosVehiculo(comando, auto);
            comando.Parameters.AddWithValue("@NumeroPuertas", auto.NumeroPuertas);
            comando.Parameters.AddWithValue("@Traccion", auto.Traccion);
        }
        public static void SetearParametrosMoto(SqlCommand comando, Moto moto)
        {
            SetearParametrosVehiculo(comando, moto);
            comando.Parameters.AddWithValue("@Cilindrada", moto.Cilindrada);
            comando.Parameters.AddWithValue("@TipoRuedas", moto.TipoRuedas);
        }
        public static void SetearParametrosCamion(SqlCommand comando,  Camion camion)
        {
            SetearParametrosVehiculo(comando, camion);
            comando.Parameters.AddWithValue("@CargaMaxima", camion.CargaMaxima);
            comando.Parameters.AddWithValue("@NumeroEjes", camion.NumeroEjes);
        }
        #endregion
    }
}