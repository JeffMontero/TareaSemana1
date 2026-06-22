public static class CalculadoraFinanciera
{
    public static (double subtotal, double descuento, double impuesto, double total) CalcularTotales(
        List<double> precios, List<int> cantidades, ICalculadorDescuento estrategia)
    {
        double subtotal = 0;
        for (int i = 0; i < precios.Count; i++)
        {
            subtotal += precios[i] * cantidades[i];
        }

        double descuento = estrategia.CalcularDescuento(subtotal);
        double impuesto = (subtotal - descuento) * 0.12;
        double total = subtotal - descuento + impuesto;

        return (subtotal, descuento, impuesto, total);
    }
}