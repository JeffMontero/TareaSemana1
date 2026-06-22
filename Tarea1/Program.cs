using Tarea1.Repositorio;

namespace Tarea1
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositorioPedidos repositorio = new RepositorioPedidos();

            GestorPedidos gestor = new GestorPedidos(repositorio);

            // Datos de prueba
            List<string> productos = new List<string> { "Laptop", "Mouse" };
            List<double> precios = new List<double> { 1000.0, 50.0 };
            List<int> cantidades = new List<int> { 1, 2 };

            Console.WriteLine("--- Iniciando Proceso de Pedido (Refactorizado) ---");
            gestor.ProcesarPedido("Juan Perez", "juan@example.com", productos, precios, cantidades, "VIP");

            Console.WriteLine("\n--- Iniciando Cancelación de Pedido (Refactorizado) ---");
            gestor.CancelarPedido("Juan Perez", "juan@example.com", 1);

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}