using Martin_Orega.Data;
using System;
using System.Data.SqlClient;

namespace Martin_Orega.Services
{
    public class ChatService
    {
        // OBTENER RESPUESTA PRINCIPAL
        public string ObtenerRespuesta(string mensaje)
        {
            string respuesta = "";

            // CONVERTIR MENSAJE A MINÚSCULA
            mensaje = mensaje.ToLower();

            // LISTAR PRODUCTOS
            if (mensaje.Contains("cafes") ||
                mensaje.Contains("café") ||
                mensaje.Contains("productos") ||
                mensaje.Contains("menu"))
            {
                return ListarProductos();
            }

            // BUSCAR PRODUCTO
            string producto = BuscarProducto(mensaje);

            if (!string.IsNullOrEmpty(producto))
            {
                return producto;
            }

            // RESPUESTAS AUTOMÁTICAS
            SqlConnection conn = Conexion.ObtenerConexion();

            conn.Open();

            string query = @"SELECT TOP 1 respuesta
                             FROM respuestas_bot
                             WHERE @mensaje LIKE '%' + palabra_clave + '%'";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@mensaje", mensaje);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                respuesta = reader["respuesta"].ToString();
            }

            conn.Close();

            return respuesta;
        }

        // BUSCAR PRODUCTOS
        public string BuscarProducto(string mensaje)
        {
            string respuesta = "";

            SqlConnection conn = Conexion.ObtenerConexion();

            conn.Open();

            string query = @"SELECT nombre, precio, presentacion
                             FROM productos";

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string nombre = reader["nombre"].ToString().ToLower();

                if (mensaje.Contains(nombre))
                {
                    respuesta =
                        reader["nombre"].ToString() +
                        " presentación " +
                        reader["presentacion"].ToString() +
                        " cuesta $" +
                        reader["precio"].ToString();
                }
            }

            conn.Close();

            return respuesta;
        }

        // LISTAR PRODUCTOS
        public string ListarProductos()
        {
            string respuesta = "Tenemos disponibles:" + Environment.NewLine;

            SqlConnection conn = Conexion.ObtenerConexion();

            conn.Open();

            string query = "SELECT nombre FROM productos";

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                respuesta += "- " +
                             reader["nombre"].ToString() +
                             Environment.NewLine;
            }

            conn.Close();

            return respuesta;
        }

        // GUARDAR CONVERSACIÓN
        public void GuardarConversacion(string usuario, string mensaje, string respuesta)
        {
            SqlConnection conn = Conexion.ObtenerConexion();

            string query = @"INSERT INTO historial_chat
                            (usuario, mensaje_usuario, respuesta_bot)
                            VALUES
                            (@usuario, @mensaje, @respuesta)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@mensaje", mensaje);
            cmd.Parameters.AddWithValue("@respuesta", respuesta);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}