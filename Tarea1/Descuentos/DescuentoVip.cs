namespace Tarea1.Descuentos
{
    public class DescuentoVip : ICalculadorDescuento
    {
        public double CalcularDescuento(double subtotal)
        {
            return subtotal * 0.20;
        }
    }
}
