using MiPrimeraApi2.Model;
using System.Data.SqlClient;
using MiPrimeraApi2.Controllers.DTO;

namespace MiPrimeraApi2.Repository
{
    public class ProductoHandler
    {
        public const string ConnectionString = "Server = DESKTOP-II66TRU; Database = SistemaGestion; Trusted_connection=true";

        public static List<Producto> GetProductos()
        {
            List<Producto> Productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Producto Producto = new Producto();

                                Producto.Id = Convert.ToInt32(sqlreader["Id"]);
                                Producto.Descripciones = sqlreader["Descripcion"].ToString();
                                Producto.Costo = Convert.ToDouble(sqlreader["Costo"]);
                                Producto.PrecioVenta = Convert.ToDouble(sqlreader["PrecioVenta"]);
                                Producto.Stock = Convert.ToInt32(sqlreader["Stock"]);
                                Producto.IdUsuario = Convert.ToInt32(sqlreader["IdUsuario"]);

                                Productos.Add(Producto);
                            }
                        }
                    }
                }
            }

            return Productos;
        }

        public static void Actualizar(PutProducto producto)
        {
            string sqlQuery = "UPDATE Producto " +
                "SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", producto.Id);
                sqlCommand.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public static void Borrar(int id)
        {
            string sqlQuery = "DELETE * FROM Producto WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }

        internal static void ActualizarDesdeVenta(Producto producto)
        {
            string sqlQuery = "UPDATE Producto SET Stock = Stock - @stock WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        internal static void Crear(PostProducto producto)
        {
            string sqlQuery = "INSERT INTO [SistemaGestion].[dbo].[Producto] " + 
                              "(Descripcion, Costo, PrecioDeVenta, Stock, IdUsuario) " +
                              "VALUES(@descripncion, @costo, @precioDeVenta, @stock, @idUsuario)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("@costo", producto.Costo);
                sqlCommand.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@stock", producto.Stock);
                sqlCommand.Parameters.AddWithValue("@idusuario", producto.IdUsuario);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
