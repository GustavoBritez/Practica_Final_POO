using System;

namespace Final
{
    public abstract class Pago
    {
        public int ID { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public decimal Recargo { get; protected set; }
        public decimal Neto { get; protected set; }
        public DateTime? FechaPago { get; set; }
        public string Detalle { get; set; } = string.Empty;
        public bool Pagado { get; set; } = false;
        public Organizador Organizador { get; set; } = null!;
        public Proveedor Proveedor { get; set; } = null!;

        public abstract string TipoPago { get; }

        public Pago() { }

        public Pago(int id, DateTime fechaVencimiento, decimal importe, string detalle, Organizador organizador, Proveedor proveedor)
        {
            ID = id;
            FechaVencimiento = fechaVencimiento;
            Importe = importe;
            Detalle = detalle;
            Organizador = organizador;
            Proveedor = proveedor;
            Recargo = 0m;
            Neto = importe;
            Pagado = false;
        }

        public abstract decimal CalcularRecargo(DateTime fechaPago);

        public virtual void RealizarPago(DateTime fechaPago)
        {
            FechaPago = fechaPago;
            Pagado = true;
            Recargo = CalcularRecargo(fechaPago);
            Neto = Importe + Recargo;
        }
    }
}
