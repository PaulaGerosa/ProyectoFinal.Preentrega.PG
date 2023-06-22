using PreEntrega.ProyectoFinal;
using System.Data;
using System.Data.SqlClient;

public class Usuario
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string nombreUsuario { get; set; }
    public string contrasena { get; set; }
    public string mail { get; set; }

    public Usuario()
    {
        var Usuarios = new List<Producto>();
    }

    private readonly string connectionString;

    public Usuario(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Usuario ObtenerUsuarioPorId(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 
                                                   FROM Usuario WHERE Id = @Id";

            using (var command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@Id", id);


                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.id = reader.GetInt32(0);
                        usuario.nombre = reader.GetString(1);
                        usuario.apellido = reader.GetString(2);
                        usuario.nombreUsuario = reader.GetString(3);
                        usuario.contrasena = reader.GetString(4);
                        usuario.mail = reader.GetString(5);


                    }



                    else
                    {

                        return null;
                    }
                }
            }
        }
    }
}
