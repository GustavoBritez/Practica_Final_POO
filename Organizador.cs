using System;
using System.Collections.Generic;

namespace Final
{
    public class Organizador
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();

        public Organizador() { }

        public Organizador(int codigo, string nombre, string telefono, string direccion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;
        }

        public bool AsociarProveedor(Proveedor prov)
        {
            if (prov != null && !Proveedores.Contains(prov))
            {
                Proveedores.Add(prov);
                return true;
            }
            return false;
        }

        public bool DesasociarProveedor(Proveedor prov)
        {
            if (prov != null && Proveedores.Contains(prov))
            {
                Proveedores.Remove(prov);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {Nombre}";
        }
    }
}
