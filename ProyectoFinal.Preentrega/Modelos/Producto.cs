using System.Data;
using System.Data.SqlClient;


namespace PreEntrega.ProyectoFinal
{

    internal class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
            var Productos = new List<Producto>();
        }

        public List<Producto> ListarProductos()
        {
            string connectionString = "Server=<LAPTOP-VU14H4RS\\SQLEXPRESS01> ; Database=<SistemaGestion>;Trusted_Connection=True;";
            var query = "SELECT Id,Descripciones,Costo,PrecioVenta,Stock,IdUsuario  FROM Producto";
            var listaProductos = new List<Producto>();

            using SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        var producto = new Producto();
                        producto.Id = Convert.ToInt32(dr.GetString("Id"));
                        producto.Descripciones = dr.GetString("Descripciones");
                        producto.Costo = Convert.ToDouble(dr.GetString("Costo"));
                        producto.PrecioVenta = Convert.ToDouble(dr.GetString("PrecioVenta"));
                        producto.Stock = Convert.ToInt32(dr.GetString("Stock"));
                        producto.IdUsuario = Convert.ToInt32(dr.GetString("IdUsuario"));

                        listaProductos.Add(producto);
                    }
                }

                connection.Close();
            }

            return listaProductos;

        }

    }


}
