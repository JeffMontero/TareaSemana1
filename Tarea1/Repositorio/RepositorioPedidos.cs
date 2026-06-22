using Microsoft.Data.SqlClient;

namespace Tarea1.Repositorio
{
    public class RepositorioPedidos : IRepositorioPedidos
    {
        private readonly string _cadenaConexion = "Server=DESKTOP-VJ244OG;Database=tienda;Trusted_Connection=True;TrustServerCertificate=True;";
        public void EliminarPedido(int idPedido)
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                var comando = new SqlCommand($"DELETE FROM pedidos WHERE id={idPedido}", conexion);
                comando.ExecuteNonQuery();
            }
        }

        public void GuardarPedido(string nombreCliente, double total)
        {
            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                var comando = new SqlCommand($"INSERT INTO pedidos (cliente, total) VALUES ('{nombreCliente}', {total})", conexion);
                comando.ExecuteNonQuery();
            }
        }
    }
}
