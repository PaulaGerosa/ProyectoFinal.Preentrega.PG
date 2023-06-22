using System.Data;
using System.Data.SqlClient;

namespace PreEntrega.ProyectoFinal
{
    internal class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }

        public Venta()
        {
            var Ventas = new List<Venta>();
        }

        public List<Venta> ListarVentas()
        {
            string connectionString = "Server=<LAPTOP-VU14H4RS\\SQLEXPRESS01> ; Database=<SistemaGestion>;Trusted_Connection=True;";
            var query = "SELECT Id,Comentarios  FROM Venta";
            var listaVenta = new List<Venta>();

            using SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        var venta = new Venta();
                        venta.Id = Convert.ToInt32(dr.GetString("Id"));
                        venta.Comentarios = dr.GetString("Comentarios");


                        listaVenta.Add(venta);
                    }
                }

                connection.Close();
            }

            return listaVenta;

        }