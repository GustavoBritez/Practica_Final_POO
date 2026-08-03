using System;

namespace Final
{
    public class MayorDiezMilEventArgs : EventArgs
    {
        public decimal Importe { get; set; }
        public Pago Pago { get; set; }
        public string Mensaje { get; set; }

        public MayorDiezMilEventArgs(decimal importe, Pago pago, string mensaje = "¡El importe del pago supera los $10.000!")
        {
            Importe = importe;
            Pago = pago;
            Mensaje = mensaje;
        }
    }
}
