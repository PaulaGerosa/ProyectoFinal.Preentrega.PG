using System.Data;
using System.Data.SqlClient;

namespace PreEntrega.ProyectoFinal
{
    internal class ProductoVendido
    {

        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido()
        {
            var ProductosVendidos = new List<ProductoVendido>();
        }

        public List<ProductoVendido> ListarProductosVendidos()
        {
            string connectionString = "Server=<LAPTOP-VU14H4RS\\SQLEXPRESS01> ; Database=<SistemaGestion>;Trusted_Connection=True;";
            var query = "SELECT Id,Stock,IdProducto,IdVenta  FROM ProductoVendido";
            var listaProductosVendidos = new List<ProductoVendido>();

            using SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        var productovendido = new ProductoVendido();
                        productovendido.Id = Convert.ToInt32(dr.GetString("Id"));
                        productovendido.Stock = Convert.ToInt32(dr.GetString("Stock"));
                        productovendido.IdProducto = Convert.ToInt32(dr.GetString("IdProducto"));
                        productovendido.IdVenta = Convert.ToInt32(dr.GetString("IdVenta"));

                        listaProductosVendidos.Add(productovendido);
                    }
                }

                connection.Close();
            }

            return listaProductosVendidos;

        }

    }



}
