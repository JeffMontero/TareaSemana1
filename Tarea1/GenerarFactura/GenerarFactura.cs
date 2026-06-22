public static class GeneradorFactura
{
    public static void Generar(string nombreCliente, List<string> productos, List<int> cantidades,
                               List<double> precios, double subtotal, double descuento,
                               double impuesto, double total)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("factura_" + nombreCliente + ".txt"))
            {
                writer.WriteLine("FACTURA");
                writer.WriteLine("Cliente: " + nombreCliente);
                for (int i = 0; i < productos.Count; i++)
                {
                    writer.WriteLine($"{productos[i]} x {cantidades[i]} = ${precios[i] * cantidades[i]}");
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
    }
}