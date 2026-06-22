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
                               ICalculadorDescuento estrategiaDescuento)
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

        double descuento = estrategiaDescuento.CalcularDescuento(subtotal);

        double impuesto = (subtotal - descuento) * 0.12;
        double total = subtotal - descuento + impuesto;

        _repositorio.GuardarPedido(nombreCliente, total);

        GeneradorFactura.Generar(nombreCliente, nombresProductos, cantidades, preciosProductos, subtotal, descuento, impuesto, total);

        ServicioNotificaciones.EnviarConfirmacion(emailCliente, nombreCliente, total);
    }

    public void CancelarPedido(string nombreCliente, string emailCliente, int idPedido)
    {
        if (string.IsNullOrWhiteSpace(nombreCliente) || string.IsNullOrWhiteSpace(emailCliente) || !emailCliente.Contains("@"))
        {
            Console.WriteLine("Error: datos de cliente invalidos");
            return;
        }

        _repositorio.EliminarPedido(idPedido);

        ServicioNotificaciones.EnviarNotificacionCancelacion(emailCliente, nombreCliente, idPedido);
    }
}