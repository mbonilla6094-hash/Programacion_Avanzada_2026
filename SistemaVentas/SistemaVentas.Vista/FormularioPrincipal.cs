using System;
using System.ComponentModel;
using System.Windows.Forms;
using SistemaVentas.LogicaNegocio;

namespace SistemaVentas.Vista
{
    public partial class FormularioPrincipal : Form
    {
        private GestorVentas? _gestor;

        public FormularioPrincipal()
        {
            InitializeComponent();

            // No ejecutar logica en modo disenador de Visual Studio
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !DesignMode)
            {
                _gestor = new GestorVentas();
                this.Load += FormularioPrincipal_Load;
            }
        }

        private void FormularioPrincipal_Load(object? sender, EventArgs e)
        {
            InicializarSistema();
        }

        private void InicializarSistema()
        {
            try
            {
                if (_gestor == null) return;
                int total = _gestor.TotalRegistros();
                lblTotalRegistros.Text = "Total en BD: " + total + " registros";
                lblBarraEstado.Text = "SQL Server conectado | Base de datos: SistemaVentasDB | " + total + " registros";
                if (total > 0) CargarGrid();
            }
            catch (Exception ex)
            {
                lblBarraEstado.Text = "Error al conectar: " + ex.Message;
            }
        }

        // Boton: Ver todas las ventas
        private void BtnVerTodas_Click(object sender, EventArgs e)
        {
            CargarGrid();
            lblEstado.Text = "Mostrando las ultimas 500 ventas";
        }

        // Boton: Reporte por Region
        private void BtnReporteRegion_Click(object sender, EventArgs e)
        {
            if (_gestor == null) return;
            try
            {
                var reporte = _gestor.ObtenerReportePorRegion();
                gridDatos.DataSource = null;
                gridDatos.DataSource = reporte;
                lblEstado.Text = "Reporte agrupado por region - " + reporte.Count + " regiones";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton: Reporte por Producto
        private void BtnReporteProducto_Click(object sender, EventArgs e)
        {
            if (_gestor == null) return;
            try
            {
                var reporte = _gestor.ObtenerReportePorProducto();
                gridDatos.DataSource = null;
                gridDatos.DataSource = reporte;
                lblEstado.Text = "Reporte agrupado por producto - " + reporte.Count + " productos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton: Buscar por pais
        private void BtnBuscarPais_Click(object sender, EventArgs e)
        {
            if (_gestor == null || string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            try
            {
                var ventas = _gestor.BuscarPorPais(txtBuscar.Text.Trim());
                gridDatos.DataSource = null;
                gridDatos.DataSource = ventas;
                lblEstado.Text = "Resultados para pais '" + txtBuscar.Text + "': " + ventas.Count + " ventas";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton: Buscar por producto
        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (_gestor == null || string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            try
            {
                var ventas = _gestor.BuscarPorProducto(txtBuscar.Text.Trim());
                gridDatos.DataSource = null;
                gridDatos.DataSource = ventas;
                lblEstado.Text = "Resultados para producto '" + txtBuscar.Text + "': " + ventas.Count + " ventas";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga las ventas en el DataGridView
        private void CargarGrid()
        {
            if (_gestor == null) return;
            try
            {
                var ventas = _gestor.ObtenerVentas(500);
                gridDatos.DataSource = null;
                gridDatos.DataSource = ventas;
                int total = _gestor.TotalRegistros();
                lblTotalRegistros.Text = "Total en BD: " + total + " registros";
            }
            catch (Exception ex)
            {
                lblBarraEstado.Text = "Error: " + ex.Message;
            }
        }

        // Boton: Prediccion ML.NET
        private void BtnPrediccionML_Click(object sender, EventArgs e)
        {
            if (_gestor == null) return;
            try
            {
                lblEstado.Text = "Entrenando modelo de IA con 10,000 registros... Por favor espere.";
                Application.DoEvents();

                string pais = string.IsNullOrWhiteSpace(txtBuscar.Text) ? "Mexico" : txtBuscar.Text.Trim();
                string region = "Central America and the Caribbean";
                string producto = "Cosmetics";

                var listaPais = _gestor.BuscarPorPais(pais);
                if (listaPais.Count > 0)
                {
                    region = listaPais[0].Region;
                    producto = listaPais[0].TipoProducto;
                }

                float prediccion = _gestor.PredecirVentasFuturas(region, pais, producto);
                lblEstado.Text = "Prediccion completada.";

                MessageBox.Show($"[ PREDICCION INTELIGENCIA ARTIFICIAL ]\n\n" +
                                $"Pais Analizado: {pais}\n" +
                                $"Region Estimada: {region}\n" +
                                $"Categoria: {producto}\n\n" +
                                $"El modelo ML.NET proyecta que la proxima orden tendra:\n" +
                                $"*** {Math.Round(prediccion)} Unidades Vendidas ***",
                                "Machine Learning ML.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ML.NET: " + ex.Message, "Error");
            }
        }

        private void lblSubtitulo_Click(object sender, EventArgs e)
        {

        }

        private void panelEncabezado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBarraEstado_Click(object sender, EventArgs e)
        {

        }
    }
}
