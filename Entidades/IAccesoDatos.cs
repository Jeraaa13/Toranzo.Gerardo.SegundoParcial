using System.Data.SqlClient;
using static Entidades.AccesoDatos;

namespace Entidades
{
    internal interface IAccesoDatos
    {
        List<Vehiculo> LeerListas<T>(Func<SqlDataReader, T> mapeador, string tabla) where T : Vehiculo;

        Auto MapearAuto(SqlDataReader reader);
        Camion MapearCamion(SqlDataReader reader);
        Moto MapearMoto(SqlDataReader reader);
        bool InsertarVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo;

        int ObtenerUltimoIdDesdeBaseDeDatos(string tabla);

        bool ExisteVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo;

        bool ModificarVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo;

        bool EliminarVehiculo<T>(T vehiculo, string tabla) where T : Vehiculo;

        void SetearParametrosVehiculo(Vehiculo vehiculo);
        void SetearParametrosAuto(Auto auto);
        void SetearParametrosMoto(Moto moto);

        void SetearParametrosCamion(Camion camion);
    }
}
