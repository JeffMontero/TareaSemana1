namespace Tarea1.Descuentos
{
    public class DescuentoRegular : ICalculadorDescuento
    {
        public double CalcularDescuento(double subtotal)
        {
            return subtotal * 0.05;
        }
    }
}
