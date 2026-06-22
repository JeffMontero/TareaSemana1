using Microsoft.Data.SqlClient;

public class GestorPedidos
{
    private readonly IRepositorioPedidos _repositorio;

    // Inyectamos la dependencia
    public GestorPedidos(IRepositorioPedidos repositorio)
    {
        _repositorio = repositorio;
    }

    public void ProcesarPedido(string nombreCliente, string emailCliente,
                               List<string> nombresProductos,
                               List<double> preciosProductos,
                               List<int> cantidades,
                               string tipoCliente)
    {
        if (string.IsNullOrWhiteSpace(nombreCliente))
        {
            Console.WriteLine("Error: nombre de cliente invalido");
            return;
        }

        if (string.IsNullOrWhiteSpace(emailCliente) || !emailCliente.Contains("@"))
        {
            Console.WriteLine("Error: email invalido");
            return;
        }

        double subtotal = 0;
        for (int i = 0; i < nombresProductos.Count; i++)
        {
            subtotal += preciosProductos[i] * cantidades[i];
        }

        double descuento = 0;
        if (tipoCliente == "VIP") descuento = subtotal * 0.20;
        else if (tipoCliente == "FRECUENTE") descuento = subtotal * 0.10;
        else if (tipoCliente == "REGULAR") descuento = subtotal * 0.05;
        else if (tipoCliente == "NUEVO") descuento = 0;

        double impuesto = (subtotal - descuento) * 0.12;
        double total = subtotal - descuento + impuesto;

        _repositorio.GuardarPedido(nombreCliente, total);

        try
        {
            using (StreamWriter writer = new StreamWriter("factura_" + nombreCliente + ".txt"))
            {
                writer.WriteLine("FACTURA");
                writer.WriteLine("Cliente: " + nombreCliente);
                for (int i = 0; i < nombresProductos.Count; i++)
                {
                    writer.WriteLine($"{nombresProductos[i]} x {cantidades[i]} = ${preciosProductos[i] * cantidades[i]}");
                }
                writer.WriteLine($"Subtotal: ${subtotal}");
                writer.WriteLine($"Descuento: ${descuento}");
                writer.WriteLine($"Impuesto: ${impuesto}");
                writer.WriteLine($"TOTAL: ${total}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error al generar la factura: " + e.Message);
        }

        Console.WriteLine("Enviando correo a " + emailCliente + "...");
        Console.WriteLine("Asunto: Confirmacion de pedido");
        Console.WriteLine("Cuerpo: Estimado " + nombreCliente + ", su pedido por $" + total + " ha sido procesado.");
        Console.WriteLine("[LOG] Pedido procesado para " + nombreCliente);
    }

    public void CancelarPedido(string nombreCliente, string emailCliente, int idPedido)
    {
        if (string.IsNullOrWhiteSpace(nombreCliente) || string.IsNullOrWhiteSpace(emailCliente) || !emailCliente.Contains("@"))
        {
            Console.WriteLine("Error: datos de cliente invalidos");
            return;
        }

        _repositorio.EliminarPedido(idPedido);

        Console.WriteLine("Enviando correo a " + emailCliente + "...");
        Console.WriteLine("Asunto: Cancelacion de pedido");
        Console.WriteLine("Cuerpo: Estimado " + nombreCliente + ", su pedido #" + idPedido + " ha sido cancelado.");
    }
}