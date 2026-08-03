using System;
using System.Collections.Generic;
using System.Linq;

namespace Final
{
    public class Empresa : ISujeto
    {
        private readonly List<IObservador> _observadores = new List<IObservador>();

        public List<Organizador> Organizadores { get; set; } = new List<Organizador>();
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
        public List<Pago> Pagos { get; set; } = new List<Pago>();

        // Evento requerido
        public event EventHandler<MayorDiezMilEventArgs>? MayorDiezMil;

        // Implementación de ISujeto (Observer Pattern)
        public void AgregarObservador(IObservador observador)
        {
            if (observador != null && !_observadores.Contains(observador))
            {
                _observadores.Add(observador);
            }
        }

        public void QuitarObservador(IObservador observador)
        {
            if (observador != null && _observadores.Contains(observador))
            {
                _observadores.Remove(observador);
            }
        }

        public void Notificar()
        {
            foreach (var obs in _observadores)
            {
                obs.Actualizar();
            }
        }

        // Operaciones ABM Organizadores
        public bool AgregarOrganizador(Organizador org, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (Organizadores.Any(o => o.Codigo == org.Codigo))
            {
                mensajeError = $"Ya existe un organizador con el código {org.Codigo}.";
                return false;
            }
            Organizadores.Add(org);
            Notificar();
            return true;
        }

        public bool EliminarOrganizador(Organizador org, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (org == null) return false;

            // Regla: Solo se puede eliminar un organizador si no tiene pagos pendientes
            bool tienePagosPendientes = Pagos.Any(p => p.Organizador == org && !p.Pagado);
            if (tienePagosPendientes)
            {
                mensajeError = "No se puede eliminar el organizador porque posee pagos pendientes.";
                return false;
            }

            // Desasociar de proveedores
            foreach (var prov in Proveedores)
            {
                prov.DesasociarOrganizador(org);
            }

            // Eliminar pagos ya liquidados asociados si corresponde, o simplemente remover organizador
            Organizadores.Remove(org);
            Notificar();
            return true;
        }

        // Operaciones ABM Proveedores
        public bool AgregarProveedor(Proveedor prov, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (Proveedores.Any(p => p.Codigo == prov.Codigo))
            {
                mensajeError = $"Ya existe un proveedor con el código {prov.Codigo}.";
                return false;
            }
            Proveedores.Add(prov);
            Notificar();
            return true;
        }

        public bool EliminarProveedor(Proveedor prov, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (prov == null) return false;

            // Regla: Solo se puede eliminar un proveedor si no tiene ningún organizador asociado
            if (prov.Organizadores.Count > 0)
            {
                mensajeError = "No se puede eliminar el proveedor porque tiene organizadores asociados.";
                return false;
            }

            Proveedores.Remove(prov);
            Notificar();
            return true;
        }

        // Asociación Organizador - Proveedor
        public bool AsociarOrganizadorProveedor(Organizador org, Proveedor prov, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (org == null || prov == null)
            {
                mensajeError = "Debe seleccionar un organizador y un proveedor válidos.";
                return false;
            }

            bool op1 = org.AsociarProveedor(prov);
            bool op2 = prov.AsociarOrganizador(org);

            if (!op1 && !op2)
            {
                mensajeError = "El organizador y el proveedor ya estaban asociados previamente.";
                return false;
            }

            Notificar();
            return true;
        }

        // Gestión de Pagos
        public void AgregarPago(Pago pago)
        {
            Pagos.Add(pago);

            // Disparar evento si el importe supera los 10.000
            if (pago.Importe > 10000m)
            {
                MayorDiezMil?.Invoke(this, new MayorDiezMilEventArgs(pago.Importe, pago, $"¡Atención! Se agregó un pago de ${pago.Importe:N2} que supera los $10.000 (ID Pago: {pago.ID})."));
            }

            Notificar();
        }

        public bool RealizarPago(Pago pago, DateTime fechaPago, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (pago == null)
            {
                mensajeError = "Debe seleccionar un pago válido.";
                return false;
            }

            if (pago.Pagado)
            {
                mensajeError = "El pago seleccionado ya ha sido abonado previamente.";
                return false;
            }

            pago.RealizarPago(fechaPago);
            Notificar();
            return true;
        }

        // Métodos de consulta con LINQ para las Grillas

        // Grilla 3: Proveedores asociados al organizador seleccionado en grilla 1
        public List<Proveedor> ObtenerProveedoresDeOrganizador(Organizador? org)
        {
            if (org == null) return new List<Proveedor>();
            return org.Proveedores.OrderBy(p => p.Codigo).ToList();
        }

        // Grilla 4: Organizadores asociados al proveedor seleccionado en grilla 2
        public List<Organizador> ObtenerOrganizadoresDeProveedor(Proveedor? prov)
        {
            if (prov == null) return new List<Organizador>();
            return prov.Organizadores.OrderBy(o => o.Codigo).ToList();
        }

        // Grilla 5: Pagos que tienen en común el organizador (Grilla 1) y el proveedor (Grilla 3)
        public List<Pago> ObtenerPagosEnComun(Organizador? org, Proveedor? prov)
        {
            if (org == null || prov == null) return new List<Pago>();
            return Pagos
                .Where(p => p.Organizador.Codigo == org.Codigo && p.Proveedor.Codigo == prov.Codigo)
                .OrderBy(p => p.FechaVencimiento)
                .ToList();
        }

        // Grilla 6: Todos los pagos ordenados por código de organizador y fecha (LINQ)
        public List<object> ObtenerTodosLosPagosOrdenados()
        {
            return Pagos
                .OrderBy(p => p.Organizador.Codigo)
                .ThenBy(p => p.FechaVencimiento)
                .Select(p => new
                {
                    ID_Pago = p.ID,
                    Cod_Organizador = p.Organizador.Codigo,
                    Organizador = p.Organizador.Nombre,
                    RazonSocial_Proveedor = p.Proveedor.RazonSocial,
                    Tipo_Pago = p.TipoPago,
                    Vencimiento = p.FechaVencimiento.ToString("dd/MM/yyyy"),
                    Importe = p.Importe,
                    Recargo = p.Recargo,
                    Total_Neto = p.Neto,
                    Estado = p.Pagado ? "PAGADO" : "PENDIENTE",
                    Fecha_Pago = p.FechaPago.HasValue ? p.FechaPago.Value.ToString("dd/MM/yyyy") : "-",
                    Detalle = p.Detalle
                })
                .Cast<object>()
                .ToList();
        }
    }
}
