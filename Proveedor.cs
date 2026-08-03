using System;
using System.Collections.Generic;

namespace Final
{
    public class Proveedor
    {
        public int Codigo { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public List<Organizador> Organizadores { get; set; } = new List<Organizador>();

        public Proveedor() { }

        public Proveedor(int codigo, string razonSocial, string telefono)
        {
            Codigo = codigo;
            RazonSocial = razonSocial;
            Telefono = telefono;
        }

        public bool AsociarOrganizador(Organizador org)
        {
            if (org != null && !Organizadores.Contains(org))
            {
                Organizadores.Add(org);
                return true;
            }
            return false;
        }

        public bool DesasociarOrganizador(Organizador org)
        {
            if (org != null && Organizadores.Contains(org))
            {
                Organizadores.Remove(org);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {RazonSocial}";
        }
    }
}
