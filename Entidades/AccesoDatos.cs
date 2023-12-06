using Microsoft.Azure.Amqp.Framing;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
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

        public DelegadoConfigurarParametros configurarParametrosAuto;
        public DelegadoConfigurarParametros configurarParametrosMoto;
        public DelegadoConfigurarParametros configurarParametrosCamion;

        #endregion

        #region Constructores       
        public AccesoDatos()
        {
            connectionStr = Properties.Resources.miConexion;
            conexion = new SqlConnection(connectionStr);

            configurarParametrosAuto = (vehiculo) => SetearParametrosAuto((Auto)vehiculo);
            configurarParametrosMoto = (vehiculo) => SetearParametrosMoto((Moto)vehiculo);
            configurarParametrosCamion = (vehiculo) => SetearParametrosCamion((Camion)vehiculo);
        }

        #endregion

        #region Delegados
        public delegate T DelegadoMapear<T>(SqlDataReader reader);
        public delegate void DelegadoConfigurarParametros(Vehiculo vehiculo);
        #endregion

        #region Metodo
        public List<Vehiculo> LeerListas<T>(Func<SqlDataReader, T> mapeador, string tabla) where T : Vehiculo
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM {tabla}";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (lector.Read())
                {
                    T vehiculo = mapeador(lector);
                    listaVehiculos.Add(vehiculo);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al leer la base de datos: {ex.Message}");
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
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
            string parametros = "(marca, modelo, añoFabricacion, combustible,";
            string values = "(@marca, @modelo, @añoFabricacion, @combustible,";

            if (ExisteVehiculo<Vehiculo>(vehiculo, tabla))
            {
                Console.WriteLine("El vehiculo ya existe en la base de datos");
                return false;
            }

            if (vehiculo is Auto auto)
            {
                parametros += " numeroPuertas, traccion)";
                values += " @numeroPuertas, @traccion)";
                configurarParametrosAuto(auto);
            }
            else if (vehiculo is Moto moto)
            {
                parametros += " cilindrada, tipoRuedas)";
                values += " @cilindrada, @tipoRuedas)";
                configurarParametrosMoto(moto);
            }
            else if (vehiculo is Camion camion)
            {
                parametros += " cargaMaxima, numeroEjes)";
                values += " @cargaMaxima, @numeroEjes)";
                configurarParametrosCamion(camion);
            }
            try
            {
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"INSERT INTO {tabla} {parametros} VALUES {values}";
                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    int ultimoId = ObtenerUltimoIdDesdeBaseDeDatos(tabla);
                    vehiculo.Id += ultimoId;

                    retorno = true;
                }
            }
            catch(SqlException sqlex)
            {
                Console.WriteLine($"Error al insertar vehiculo: {sqlex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar vehiculo: {ex.Message}");
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
        private int ObtenerUltimoIdDesdeBaseDeDatos(string tabla)
        {
            int ultimoId = 0;

            try
            {
                this.comando.Connection.Open();

                this.comando.CommandText = $"SELECT MAX(Id) FROM {tabla}";

                object resultado = this.comando.ExecuteScalar();

                if(resultado != null && int.TryParse(resultado.ToString(), out ultimoId))
                {

                }
                else
                {
                    ultimoId = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener ultimo ID: {ex.Message}");
            }
            finally
            {
                if (this.comando.Connection.State == ConnectionState.Open)
                {
                    this.comando.Connection.Close();
                }
            }
            return ultimoId;
        }
        private bool ExisteVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.Clear();
                this.comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                this.comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                this.comando.Connection = this.conexion;
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"SELECT COUNT(*) FROM {tabla} WHERE Marca = @Marca AND Modelo = @Modelo";

                this.conexion.Open();

                int filasAfectadas = (int)this.comando.ExecuteScalar();

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al seleccionar de la tabla: {ex.Message}");
                return false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        public bool ModificarVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo
        {
            bool retorno = false;
            string values = "marca = @marca, modelo = @modelo, añoFabricacion = @añoFabricacion, combustible = @combustible,";

            if (vehiculo is Auto auto)
            {
                values += " numeroPuertas = @numeroPuertas, traccion = @traccion";
                configurarParametrosAuto(auto);
            }
            else if (vehiculo is Moto moto)
            {
                values += " cilindrada = @cilindrada, tipoRuedas = @tipoRuedas";
                configurarParametrosMoto(moto);
            }
            else if (vehiculo is Camion camion)
            {
                values += " cargaMaxima = @cargaMaxima, numeroEjes = @numeroEjes";
                configurarParametrosCamion(camion);
            }

            try
            {
                this.comando.Parameters.AddWithValue("@Id", ObtenerUltimoIdDesdeBaseDeDatos(tabla));
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"UPDATE {tabla} SET {values} WHERE id = @id";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Error al modificar vehiculo: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar vehiculo: {ex.Message}");
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
        public bool EliminarVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo
        {
            bool retorno = false;

            try
            {
                this.comando.Parameters.Clear();
                this.comando.Parameters.AddWithValue("@Id", ObtenerUltimoIdDesdeBaseDeDatos(tabla));
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"DELETE FROM {tabla} WHERE id = @id";

                this.comando.Connection = conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine($"Error al eliminar vehiculo de la base de datos: {sqlex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error al eliminar el vehiculo en la base de datos", ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return retorno;
        }
        public void SetearParametrosVehiculo(Vehiculo vehiculo)
        {
            this.comando.Parameters.Clear();
            this.comando.Parameters.AddWithValue("@Marca", vehiculo.Marca);
            this.comando.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
            this.comando.Parameters.AddWithValue("@AñoFabricacion", vehiculo.AñoFabricacion);
            this.comando.Parameters.AddWithValue("@Combustible", vehiculo.TipoCombustible);
        }
        public void SetearParametrosAuto(Auto auto)
        {
            SetearParametrosVehiculo(auto);
            this.comando.Parameters.AddWithValue("@NumeroPuertas", auto.NumeroPuertas);
            this.comando.Parameters.AddWithValue("@Traccion", auto.Traccion);
        }
        public void SetearParametrosMoto(Moto moto)
        {
            SetearParametrosVehiculo(moto);
            this.comando.Parameters.AddWithValue("@Cilindrada", moto.Cilindrada);
            this.comando.Parameters.AddWithValue("@TipoRuedas", moto.TipoRuedas);
        }
        public void SetearParametrosCamion(Camion camion)
        {
            SetearParametrosVehiculo(camion);
            this.comando.Parameters.AddWithValue("@CargaMaxima", camion.CargaMaxima);
            this.comando.Parameters.AddWithValue("@NumeroEjes", camion.NumeroEjes);
        }
        #endregion
    }
}