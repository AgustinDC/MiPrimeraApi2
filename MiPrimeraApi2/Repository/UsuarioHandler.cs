using MiPrimeraApi2.Model;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class UsuarioHandler
    {
        public const string ConnectionString = "Server = DESKTOP-II66TRU; Database = SistemaGestion; Trusted_connection=true";
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> Resultado = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Usuario Usuario = new Usuario();

                                Usuario.Id = Convert.ToInt32(sqlreader["Id"]);
                                Usuario.Nombre = sqlreader["Nombre"].ToString();
                                Usuario.Apellido = sqlreader["Apellido"].ToString();
                                Usuario.NombreUsuario = sqlreader["NombreUsuario"].ToString();
                                Usuario.Contraseña = sqlreader["Contraseña"].ToString();
                                Usuario.Mail = sqlreader["Mail"].ToString();

                                Resultado.Add(Usuario);
                            }
                        }
                    }
                }
            }
            return Resultado;
        }

        public static bool UsuarioConContraseña(string user,string pass)
        {
            String sqlQuery = $"SELECT * FROM Usuario WHERE NombreUsuario = '{user}' AND Contraseña = '{pass}'";

            bool Resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Usuario Usuario = new Usuario();

                                Usuario.Id = Convert.ToInt32(sqlreader["Id"]);
                                Usuario.Nombre = sqlreader["Nombre"].ToString();
                                Usuario.Apellido = sqlreader["Apellido"].ToString();
                                Usuario.NombreUsuario = sqlreader["NombreUsuario"].ToString();
                                Usuario.Contraseña = sqlreader["Contraseña"].ToString();
                                Usuario.Mail = sqlreader["Mail"].ToString();

                            }
                            Resultado = true;
                        }
                    }
                }
            }
            return Resultado;
        }

        public static void Actualizar(Usuario user)
        {
            string sqlQuery = "UPDATE Usuario " +
                "SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contraseña, Mail = @mail " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", user.Id);
                sqlCommand.Parameters.AddWithValue("@nombre", user.Nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", user.Apellido);
                sqlCommand.Parameters.AddWithValue("@nombreUsuario", user.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", user.Contraseña);
                sqlCommand.Parameters.AddWithValue("@mail", user.Mail);

                sqlConnection.Open();
                int numberOfRows = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public static void Crear(Usuario user)
        {
            string sqlQuery = "INSERT INTO [SistemaGestion].[dbo].[Producto] " +
                              "(Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                              "VALUES(@Id, @Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                sqlCommand.Parameters.AddWithValue("@Nombre", user.Nombre);
                sqlCommand.Parameters.AddWithValue("@Apellido", user.Apellido);
                sqlCommand.Parameters.AddWithValue("@NombreUsuario", user.NombreUsuario);
                sqlCommand.Parameters.AddWithValue("@Contraseña", user.Contraseña);
                sqlCommand.Parameters.AddWithValue("@Mail", user.Mail);
                
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        internal static void Eliminar(int id)
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
    }
}
