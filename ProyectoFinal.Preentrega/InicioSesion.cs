using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace PreEntrega.ProyectoFinal
{
    internal class InicioSesion
    {
        static string connectionString = "Server=<LAPTOP-VU14H4RS\\SQLEXPRESS01> ; Database=<SistemaGestion>;Trusted_Connection=True;";
        public static Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contrasena, Mail FROM Usuario WHERE NombreUsuario = @nombreUsuario AND Contrasena = @contrasena";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@contrasena", contrasena);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                id = Convert.ToInt32(reader[0]),
                                nombre = reader.GetString(1),
                                apellido = reader.GetString(2),
                                nombreUsuario = reader.GetString(3),
                                contrasena = reader.GetString(4),
                                mail = reader.GetString(5)
                            };
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
}


