using System.Data.SqlClient;

namespace SistemaVentas.Datos
{
    // Clase que maneja la conexion a SQL Server usando ADO.NET
    public static class ConexionBD
    {
        // Cadena de conexion a SQL Server Express local
        private static readonly string _cadenaConexion =
            @"Server=localhost\SQLEXPRESS;Database=SistemaVentasDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Retorna una nueva conexion abierta a SQL Server
        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_cadenaConexion);
            conexion.Open();
            return conexion;
        }

        // Retorna la cadena de conexion sin base de datos (para crearla)
        public static string CadenaConexionMaster()
        {
            return @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
