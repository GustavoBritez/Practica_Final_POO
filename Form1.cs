using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Final
{
    public partial class Form1 : Form, IObservador
    {
        private readonly Empresa _empresa = new Empresa();
        private int _pagoIdContador = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Suscribir observador al sujeto
            _empresa.AgregarObservador(this);

            // Suscribir evento de pago mayor a 10.000
            _empresa.MayorDiezMil += Empresa_MayorDiezMil;

            // Pre-cargar datos iniciales de prueba para facilitar la evaluación
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // Organizadores
            var org1 = new Organizador(101, "Eventos Argentina S.A.", "11-4444-5555", "Av. Corrientes 1234");
            var org2 = new Organizador(102, "Fiestas & Catering Co.", "11-8888-9999", "Calle Florida 500");
            _empresa.AgregarOrganizador(org1, out _);
            _empresa.AgregarOrganizador(org2, out _);

            // Proveedores
            var prov1 = new Proveedor(201, "Gourmet Catering SRL", "11-2222-3333");
            var prov2 = new Proveedor(202, "Sonido & Iluminación Pro", "11-6666-7777");
            _empresa.AgregarProveedor(prov1, out _);
            _empresa.AgregarProveedor(prov2, out _);

            // Asociaciones
            _empresa.AsociarOrganizadorProveedor(org1, prov1, out _);
            _empresa.AsociarOrganizadorProveedor(org1, prov2, out _);
            _empresa.AsociarOrganizadorProveedor(org2, prov1, out _);

            // Pagos iniciales
            // Pago 1: Vencido -> Tarjeta (Recargo 20% al pagar)
            var p1 = new PagoTarjeta(_pagoIdContador++, DateTime.Today.AddDays(-5), 5000m, "Catering fiesta de fin de año", org1, prov1);
            _empresa.AgregarPago(p1);

            // Pago 2: Supera $10.000 -> Dispara Evento MayorDiezMil
            var p2 = new PagoEfectivo(_pagoIdContador++, DateTime.Today.AddDays(10), 15000m, "Alquiler luces y sonido", org1, prov2);
            _empresa.AgregarPago(p2);

            // Pago 3: Vencido -> Efectivo (Recargo 10% al pagar)
            var p3 = new PagoEfectivo(_pagoIdContador++, DateTime.Today.AddDays(-3), 8000m, "Vajilla y mantelería", org2, prov1);
            _empresa.AgregarPago(p3);

            Actualizar();
        }

        // Manejador del Evento MayorDiezMil
        private void Empresa_MayorDiezMil(object? sender, MayorDiezMilEventArgs e)
        {
            MessageBox.Show(
                $"{e.Mensaje}\n\nDetalle: {e.Pago.Detalle}\nImporte: ${e.Importe:N2}",
                "¡Evento: Pago Mayor a $10.000!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        // Método de la Interfaz IObservador (Patrón Observer)
        public void Actualizar()
        {
            // Grilla 1: ABM Organizadores
            ActualizarGrilla1();

            // Grilla 2: ABM Proveedores
            ActualizarGrilla2();

            // Grilla 3 y 4 (Dependen de las selecciones de Grilla 1 y 2)
            ActualizarGrillasSecundarias();

            // Grilla 6: Todos los pagos ordenados por código de organizador con LINQ
            ActualizarGrilla6();
        }

        private void ActualizarGrilla1()
        {
            int selectedId = GetSelectedRowId(dgvOrganizadores, "Codigo");
            dgvOrganizadores.DataSource = null;
            dgvOrganizadores.DataSource = _empresa.Organizadores.Select(o => new
            {
                o.Codigo,
                o.Nombre,
                o.Telefono,
                o.Direccion,
                ProveedoresAsociados = o.Proveedores.Count
            }).ToList();

            RestoreSelection(dgvOrganizadores, "Codigo", selectedId);
        }

        private void ActualizarGrilla2()
        {
            int selectedId = GetSelectedRowId(dgvProveedores, "Codigo");
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = _empresa.Proveedores.Select(p => new
            {
                p.Codigo,
                p.RazonSocial,
                p.Telefono,
                OrganizadoresAsociados = p.Organizadores.Count
            }).ToList();

            RestoreSelection(dgvProveedores, "Codigo", selectedId);
        }

        private void ActualizarGrillasSecundarias()
        {
            var orgSel = ObtenerOrganizadorSeleccionadoG1();
            var provSelG2 = ObtenerProveedorSeleccionadoG2();

            // Grilla 3: Proveedores asociados al organizador seleccionado en Grilla 1
            dgvProvDeOrg.DataSource = null;
            if (orgSel != null)
            {
                dgvProvDeOrg.DataSource = _empresa.ObtenerProveedoresDeOrganizador(orgSel).Select(p => new
                {
                    p.Codigo,
                    p.RazonSocial,
                    p.Telefono
                }).ToList();
            }

            // Grilla 4: Organizadores asociados al proveedor seleccionado en Grilla 2
            dgvOrgDeProv.DataSource = null;
            if (provSelG2 != null)
            {
                dgvOrgDeProv.DataSource = _empresa.ObtenerOrganizadoresDeProveedor(provSelG2).Select(o => new
                {
                    o.Codigo,
                    o.Nombre,
                    o.Telefono,
                    o.Direccion
                }).ToList();
            }

            // Grilla 5: Pagos en común (Organizador Grilla 1 + Proveedor Grilla 3)
            ActualizarGrilla5();
        }

        private void ActualizarGrilla5()
        {
            var orgSel = ObtenerOrganizadorSeleccionadoG1();
            var provSelG3 = ObtenerProveedorSeleccionadoG3();

            dgvPagosEnComun.DataSource = null;
            if (orgSel != null && provSelG3 != null)
            {
                dgvPagosEnComun.DataSource = _empresa.ObtenerPagosEnComun(orgSel, provSelG3).Select(p => new
                {
                    p.ID,
                    Tipo = p.TipoPago,
                    Vencimiento = p.FechaVencimiento.ToString("dd/MM/yyyy"),
                    Importe = p.Importe,
                    Recargo = p.Recargo,
                    TotalNeto = p.Neto,
                    Estado = p.Pagado ? "PAGADO" : "PENDIENTE",
                    FechaPago = p.FechaPago.HasValue ? p.FechaPago.Value.ToString("dd/MM/yyyy") : "-",
                    p.Detalle
                }).ToList();
            }
        }

        private void ActualizarGrilla6()
        {
            dgvTodosLosPagos.DataSource = null;
            dgvTodosLosPagos.DataSource = _empresa.ObtenerTodosLosPagosOrdenados();
        }

        // Selección de filas
        private Organizador? ObtenerOrganizadorSeleccionadoG1()
        {
            if (dgvOrganizadores.CurrentRow != null)
            {
                int cod = Convert.ToInt32(dgvOrganizadores.CurrentRow.Cells["Codigo"].Value);
                return _empresa.Organizadores.FirstOrDefault(o => o.Codigo == cod);
            }
            return null;
        }

        private Proveedor? ObtenerProveedorSeleccionadoG2()
        {
            if (dgvProveedores.CurrentRow != null)
            {
                int cod = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["Codigo"].Value);
                return _empresa.Proveedores.FirstOrDefault(p => p.Codigo == cod);
            }
            return null;
        }

        private Proveedor? ObtenerProveedorSeleccionadoG3()
        {
            if (dgvProvDeOrg.CurrentRow != null)
            {
                int cod = Convert.ToInt32(dgvProvDeOrg.CurrentRow.Cells["Codigo"].Value);
                return _empresa.Proveedores.FirstOrDefault(p => p.Codigo == cod);
            }
            return null;
        }

        private Pago? ObtenerPagoSeleccionado()
        {
            // Intentar primero desde Grilla 5
            if (dgvPagosEnComun.CurrentRow != null && dgvPagosEnComun.CurrentRow.Cells["ID"] != null)
            {
                int id = Convert.ToInt32(dgvPagosEnComun.CurrentRow.Cells["ID"].Value);
                return _empresa.Pagos.FirstOrDefault(p => p.ID == id);
            }

            // Si no, intentar desde Grilla 6
            if (dgvTodosLosPagos.CurrentRow != null && dgvTodosLosPagos.CurrentRow.Cells["ID_Pago"] != null)
            {
                int id = Convert.ToInt32(dgvTodosLosPagos.CurrentRow.Cells["ID_Pago"].Value);
                return _empresa.Pagos.FirstOrDefault(p => p.ID == id);
            }

            return null;
        }

        // Eventos de selección de grillas
        private void dgvOrganizadores_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarGrillasSecundarias();
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarGrillasSecundarias();
        }

        private void dgvProvDeOrg_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarGrilla5();
        }

        // Eventos Botones ABM Organizador
        private void btnAgregarOrg_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOrgCodigo.Text, out int cod) || string.IsNullOrWhiteSpace(txtOrgNombre.Text))
            {
                MessageBox.Show("Ingrese un código numérico y nombre válido para el organizador.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var org = new Organizador(cod, txtOrgNombre.Text.Trim(), txtOrgTelefono.Text.Trim(), txtOrgDireccion.Text.Trim());
            if (_empresa.AgregarOrganizador(org, out string error))
            {
                txtOrgCodigo.Clear();
                txtOrgNombre.Clear();
                txtOrgTelefono.Clear();
                txtOrgDireccion.Clear();
            }
            else
            {
                MessageBox.Show(error, "Error al Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarOrg_Click(object sender, EventArgs e)
        {
            var orgSel = ObtenerOrganizadorSeleccionadoG1();
            if (orgSel == null)
            {
                MessageBox.Show("Seleccione un organizador de la Grilla 1.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_empresa.EliminarOrganizador(orgSel, out string error))
            {
                MessageBox.Show(error, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // Eventos Botones ABM Proveedor
        private void btnAgregarProv_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProvCodigo.Text, out int cod) || string.IsNullOrWhiteSpace(txtProvRazonSocial.Text))
            {
                MessageBox.Show("Ingrese un código numérico y razón social válida para el proveedor.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var prov = new Proveedor(cod, txtProvRazonSocial.Text.Trim(), txtProvTelefono.Text.Trim());
            if (_empresa.AgregarProveedor(prov, out string error))
            {
                txtProvCodigo.Clear();
                txtProvRazonSocial.Clear();
                txtProvTelefono.Clear();
            }
            else
            {
                MessageBox.Show(error, "Error al Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProv_Click(object sender, EventArgs e)
        {
            var provSel = ObtenerProveedorSeleccionadoG2();
            if (provSel == null)
            {
                MessageBox.Show("Seleccione un proveedor de la Grilla 2.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_empresa.EliminarProveedor(provSel, out string error))
            {
                MessageBox.Show(error, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // Botón Asociar
        private void btnAsociar_Click(object sender, EventArgs e)
        {
            var org = ObtenerOrganizadorSeleccionadoG1();
            var prov = ObtenerProveedorSeleccionadoG2();

            if (org == null || prov == null)
            {
                MessageBox.Show("Debe seleccionar un organizador en la Grilla 1 y un proveedor en la Grilla 2 para asociarlos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_empresa.AsociarOrganizadorProveedor(org, prov, out string error))
            {
                MessageBox.Show($"Se asoció exitosamente a '{org.Nombre}' con '{prov.RazonSocial}'.", "Asociación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(error, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botón Agregar Pago
        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            var org = ObtenerOrganizadorSeleccionadoG1();
            var prov = ObtenerProveedorSeleccionadoG3() ?? ObtenerProveedorSeleccionadoG2();

            if (org == null || prov == null)
            {
                MessageBox.Show("Debe seleccionar un organizador (Grilla 1) y un proveedor (Grilla 3 o Grilla 2) para asignar el pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtImportePago.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("Ingrese un importe numérico mayor a cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbTipoPago.SelectedItem?.ToString() ?? "Tarjeta";
            string detalle = string.IsNullOrWhiteSpace(txtDetallePago.Text) ? "Sin detalle" : txtDetallePago.Text.Trim();
            DateTime vencimiento = dtpVencimiento.Value;

            Pago nuevoPago;
            if (tipo == "Tarjeta")
            {
                nuevoPago = new PagoTarjeta(_pagoIdContador++, vencimiento, importe, detalle, org, prov);
            }
            else
            {
                nuevoPago = new PagoEfectivo(_pagoIdContador++, vencimiento, importe, detalle, org, prov);
            }

            _empresa.AgregarPago(nuevoPago);

            txtImportePago.Clear();
            txtDetallePago.Clear();
        }

        // Botón Pagar
        private void btnPagar_Click(object sender, EventArgs e)
        {
            var pagoSel = ObtenerPagoSeleccionado();
            if (pagoSel == null)
            {
                MessageBox.Show("Seleccione un pago pendiente en la Grilla 5 o Grilla 6.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaPagoHoy = DateTime.Now;
            if (_empresa.RealizarPago(pagoSel, fechaPagoHoy, out string error))
            {
                string infoRecargo = pagoSel.Recargo > 0
                    ? $"⚠️ ¡PAGO VENCIDO! Se aplicó un recargo del {(pagoSel.TipoPago == "Tarjeta" ? "20%" : "10%")} por mora: ${pagoSel.Recargo:N2}"
                    : "✅ Pago abonado a término sin recargo.";

                MessageBox.Show(
                    $"Pago #{pagoSel.ID} procesado con éxito.\n" +
                    $"Monto Original: ${pagoSel.Importe:N2}\n" +
                    $"Recargo: ${pagoSel.Recargo:N2}\n" +
                    $"Total Neto Abonado: ${pagoSel.Neto:N2}\n\n" +
                    $"{infoRecargo}",
                    "Pago Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(error, "Error al Pagar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helpers auxiliares de grilla
        private int GetSelectedRowId(DataGridView dgv, string columnName)
        {
            if (dgv.CurrentRow != null && dgv.Columns.Contains(columnName) && dgv.CurrentRow.Cells[columnName].Value != null)
            {
                return Convert.ToInt32(dgv.CurrentRow.Cells[columnName].Value);
            }
            return -1;
        }

        private void RestoreSelection(DataGridView dgv, string columnName, int targetId)
        {
            if (targetId <= 0 || !dgv.Columns.Contains(columnName)) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnName].Value != null && Convert.ToInt32(row.Cells[columnName].Value) == targetId)
                {
                    row.Selected = true;
                    dgv.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
    }
}
