public static class ServicioNotificaciones
{
    public static void EnviarConfirmacion(string email, string nombre, double total)
    {
        Console.WriteLine("Enviando correo a " + email + "...");
        Console.WriteLine("Asunto: Confirmacion de pedido");
        Console.WriteLine("Cuerpo: Estimado " + nombre + ", su pedido por $" + total + " ha sido procesado.");
    }

    public static void EnviarNotificacionCancelacion(string email, string nombre, int idPedido)
    {
        Console.WriteLine("Enviando correo a " + email + "...");
        Console.WriteLine("Asunto: Cancelacion de pedido");
        Console.WriteLine("Cuerpo: Estimado " + nombre + ", su pedido #" + idPedido + " ha sido cancelado.");
    }
}