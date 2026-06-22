namespace Tarea1.Descuentos
{
    public class DescuentoFrecuente : ICalculadorDescuento
    {
        public double CalcularDescuento(double subtotal)
        {
            return subtotal * 0.10;
        }
    }
}
