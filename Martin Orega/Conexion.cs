using System.Configuration;
using System.Data.SqlClient;

namespace Martin_Orega.Data
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            string conexion =
                ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            SqlConnection conn = new SqlConnection(conexion);

            return conn;
        }
    }
}