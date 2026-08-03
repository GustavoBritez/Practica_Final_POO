using System;

namespace Final
{
    public class PagoTarjeta : Pago
    {
        public override string TipoPago => "Tarjeta";

        public PagoTarjeta() : base() { }

        public PagoTarjeta(int id, DateTime fechaVencimiento, decimal importe, string detalle, Organizador organizador, Proveedor proveedor)
            : base(id, fechaVencimiento, importe, detalle, organizador, proveedor)
        {
        }

        public override decimal CalcularRecargo(DateTime fechaPago)
        {
            // Tarjeta - Recargo 20% si está vencido
            if (fechaPago.Date > FechaVencimiento.Date)
            {
                return Importe * 0.20m;
            }
            return 0m;
        }
    }
}
