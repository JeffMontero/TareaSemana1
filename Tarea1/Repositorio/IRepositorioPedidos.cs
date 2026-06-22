// IRepositorioPedidos.cs
public interface IRepositorioPedidos
{
    void GuardarPedido(string nombreCliente, double total);
    void EliminarPedido(int idPedido);
}