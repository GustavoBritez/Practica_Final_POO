using System;

namespace Final
{
    public class PagoEfectivo : Pago
    {
        public override string TipoPago => "Efectivo";

        public PagoEfectivo() : base() { }

        public PagoEfectivo(int id, DateTime fechaVencimiento, decimal importe, string detalle, Organizador organizador, Proveedor proveedor)
            : base(id, fechaVencimiento, importe, detalle, organizador, proveedor)
        {
        }

        public override decimal CalcularRecargo(DateTime fechaPago)
        {
            // Efectivo - Recargo 10% si está vencido
            if (fechaPago.Date > FechaVencimiento.Date)
            {
                return Importe * 0.10m;
            }
            return 0m;
        }
    }
}
