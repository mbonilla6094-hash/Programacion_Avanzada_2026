using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AnalisisVehiculos
{
    public partial class FormAnalisis : Form
    {
        private List<VentaVehiculo> listaVentas;

        public FormAnalisis()
        {
            InitializeComponent();
            listaVentas = new List<VentaVehiculo>();
        }

        // ===================== CARGAR CSV =====================
        private void buttonCargarCSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                openFileDialog.Title = "Seleccionar archivo CSV de ventas";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CargarDatosDesdeCSV(openFileDialog.FileName);
                        labelArchivoCargado.Text = "Archivo: " + Path.GetFileName(openFileDialog.FileName);
                        labelArchivoCargado.ForeColor = System.Drawing.Color.Green;
                        buttonCalcular.Enabled = true;
                        toolStripStatusLabel1.Text = "CSV cargado: " + listaVentas.Count + " registros";

                        MessageBox.Show("Se cargaron " + listaVentas.Count + " registros exitosamente",
                            "CSV Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar el archivo: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarDatosDesdeCSV(string rutaArchivo)
        {
            listaVentas.Clear();
            string[] lineas = File.ReadAllLines(rutaArchivo);

            // Saltar la cabecera (primera linea)
            for (int i = 1; i < lineas.Length; i++)
            {
                string linea = lineas[i].Trim();
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] campos = linea.Split(',');

                if (campos.Length >= 6)
                {
                    var venta = new VentaVehiculo
                    {
                        Anio = int.Parse(campos[0].Trim()),
                        Periodo = int.Parse(campos[1].Trim()),
                        Vehiculo = campos[2].Trim(),
                        UnidadesVendidas = int.Parse(campos[3].Trim()),
                        MontoTotal = decimal.Parse(campos[4].Trim()),
                        Creditos = decimal.Parse(campos[5].Trim())
                    };
                    listaVentas.Add(venta);
                }
            }

            // Mostrar datos en el DataGridView
            dataGridViewDatos.DataSource = null;
            dataGridViewDatos.DataSource = listaVentas;
            dataGridViewDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ===================== CALCULAR TODO =====================
        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            if (listaVentas.Count == 0)
            {
                MessageBox.Show("No hay datos cargados. Cargue un archivo CSV primero",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CalcularVehiculoMasVendido();
            CalcularMejorAnioRecaudacion();
            CalcularTotalVehiculosVendidos();
            CalcularTotalRecaudado();
            CalcularMejorAnioVentas();
            CalcularVehiculoMejoresCreditos();
            CalcularPorcentajeIngresosPorAnio();
            CalcularDiferenciaVentasAniosPares();

            toolStripStatusLabel1.Text = "Calculos completados | " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            MessageBox.Show("Todos los calculos se realizaron exitosamente",
                "Calculos Completos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 1. Vehiculo mas vendido (mayor unidades totales)
        private void CalcularVehiculoMasVendido()
        {
            var agrupado = new Dictionary<string, int>();
            foreach (var v in listaVentas)
            {
                if (agrupado.ContainsKey(v.Vehiculo))
                    agrupado[v.Vehiculo] += v.UnidadesVendidas;
                else
                    agrupado[v.Vehiculo] = v.UnidadesVendidas;
            }

            string mejorVehiculo = "";
            int maxUnidades = 0;
            foreach (var par in agrupado)
            {
                if (par.Value > maxUnidades)
                {
                    maxUnidades = par.Value;
                    mejorVehiculo = par.Key;
                }
            }

            labelVehiculoMasVendido.Text = "Vehiculo mas vendido: " + mejorVehiculo +
                " (" + maxUnidades + " unidades)";
        }

        // 2. Mejor anio por recaudacion
        private void CalcularMejorAnioRecaudacion()
        {
            var agrupado = new Dictionary<int, decimal>();
            foreach (var v in listaVentas)
            {
                if (agrupado.ContainsKey(v.Anio))
                    agrupado[v.Anio] += v.MontoTotal;
                else
                    agrupado[v.Anio] = v.MontoTotal;
            }

            int mejorAnio = 0;
            decimal maxMonto = 0;
            foreach (var par in agrupado)
            {
                if (par.Value > maxMonto)
                {
                    maxMonto = par.Value;
                    mejorAnio = par.Key;
                }
            }

            labelMejorAnio.Text = "Mejor anio (recaudacion): " + mejorAnio +
                " ($" + maxMonto.ToString("N2") + ")";
        }

        // 3. Total de vehiculos vendidos
        private void CalcularTotalVehiculosVendidos()
        {
            int total = 0;
            foreach (var v in listaVentas)
            {
                total += v.UnidadesVendidas;
            }

            labelTotalVehiculos.Text = "Total vehiculos vendidos: " + total.ToString("N0") + " unidades";
        }

        // 4. Total recaudado
        private void CalcularTotalRecaudado()
        {
            decimal total = 0;
            foreach (var v in listaVentas)
            {
                total += v.MontoTotal;
            }

            labelTotalRecaudado.Text = "Total recaudado: $" + total.ToString("N2");
        }

        // 5. Mejor anio de ventas (por unidades)
        private void CalcularMejorAnioVentas()
        {
            var agrupado = new Dictionary<int, int>();
            foreach (var v in listaVentas)
            {
                if (agrupado.ContainsKey(v.Anio))
                    agrupado[v.Anio] += v.UnidadesVendidas;
                else
                    agrupado[v.Anio] = v.UnidadesVendidas;
            }

            int mejorAnio = 0;
            int maxUnidades = 0;
            foreach (var par in agrupado)
            {
                if (par.Value > maxUnidades)
                {
                    maxUnidades = par.Value;
                    mejorAnio = par.Key;
                }
            }

            labelMejorAnioVenta.Text = "Mejor anio de ventas: " + mejorAnio +
                " (" + maxUnidades + " unidades)";
        }

        // 6. Vehiculo con mejores creditos
        private void CalcularVehiculoMejoresCreditos()
        {
            var agrupado = new Dictionary<string, decimal>();
            foreach (var v in listaVentas)
            {
                if (agrupado.ContainsKey(v.Vehiculo))
                    agrupado[v.Vehiculo] += v.Creditos;
                else
                    agrupado[v.Vehiculo] = v.Creditos;
            }

            string mejorVehiculo = "";
            decimal maxCreditos = 0;
            foreach (var par in agrupado)
            {
                if (par.Value > maxCreditos)
                {
                    maxCreditos = par.Value;
                    mejorVehiculo = par.Key;
                }
            }

            labelMejorCreditos.Text = "Vehiculo mejores creditos: " + mejorVehiculo +
                " ($" + maxCreditos.ToString("N2") + ")";
        }

        // 7. Porcentaje de ingresos por anio
        private void CalcularPorcentajeIngresosPorAnio()
        {
            decimal totalGeneral = 0;
            var montoPorAnio = new Dictionary<int, decimal>();

            foreach (var v in listaVentas)
            {
                totalGeneral += v.MontoTotal;
                if (montoPorAnio.ContainsKey(v.Anio))
                    montoPorAnio[v.Anio] += v.MontoTotal;
                else
                    montoPorAnio[v.Anio] = v.MontoTotal;
            }

            var tablaPorcentajes = new List<PorcentajeAnio>();
            foreach (var par in montoPorAnio)
            {
                decimal porcentaje = (totalGeneral > 0) ? (par.Value / totalGeneral) * 100 : 0;
                tablaPorcentajes.Add(new PorcentajeAnio
                {
                    Anio = par.Key,
                    MontoTotal = par.Value,
                    Porcentaje = Math.Round(porcentaje, 2)
                });
            }

            tablaPorcentajes.Sort((a, b) => a.Anio.CompareTo(b.Anio));

            dataGridViewPorcentajes.DataSource = null;
            dataGridViewPorcentajes.DataSource = tablaPorcentajes;
            dataGridViewPorcentajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 8. Diferencia de ventas entre anios pares (2020 vs 2022, 2022 vs 2024, 2024 vs 2026)
        private void CalcularDiferenciaVentasAniosPares()
        {
            var montoPorAnio = new Dictionary<int, decimal>();
            var unidadesPorAnio = new Dictionary<int, int>();

            foreach (var v in listaVentas)
            {
                if (montoPorAnio.ContainsKey(v.Anio))
                {
                    montoPorAnio[v.Anio] += v.MontoTotal;
                    unidadesPorAnio[v.Anio] += v.UnidadesVendidas;
                }
                else
                {
                    montoPorAnio[v.Anio] = v.MontoTotal;
                    unidadesPorAnio[v.Anio] = v.UnidadesVendidas;
                }
            }

            int[] aniosPares = { 2020, 2022, 2024, 2026 };
            var tablaDiferencias = new List<DiferenciaAnios>();

            for (int i = 0; i < aniosPares.Length - 1; i++)
            {
                int anioA = aniosPares[i];
                int anioB = aniosPares[i + 1];

                decimal montoA = montoPorAnio.ContainsKey(anioA) ? montoPorAnio[anioA] : 0;
                decimal montoB = montoPorAnio.ContainsKey(anioB) ? montoPorAnio[anioB] : 0;

                int unidadesA = unidadesPorAnio.ContainsKey(anioA) ? unidadesPorAnio[anioA] : 0;
                int unidadesB = unidadesPorAnio.ContainsKey(anioB) ? unidadesPorAnio[anioB] : 0;

                tablaDiferencias.Add(new DiferenciaAnios
                {
                    Comparacion = anioA + " vs " + anioB,
                    UnidadesAnioA = unidadesA,
                    UnidadesAnioB = unidadesB,
                    DiferenciaUnidades = unidadesB - unidadesA,
                    DifMonto = montoB - montoA
                });
            }

            dataGridViewDiferencias.DataSource = null;
            dataGridViewDiferencias.DataSource = tablaDiferencias;
            dataGridViewDiferencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

    // Clases auxiliares para los DataGridView de resultados
    public class PorcentajeAnio
    {
        public int Anio { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Porcentaje { get; set; }
    }

    public class DiferenciaAnios
    {
        public string Comparacion { get; set; } = string.Empty;
        public int UnidadesAnioA { get; set; }
        public int UnidadesAnioB { get; set; }
        public int DiferenciaUnidades { get; set; }
        public decimal DifMonto { get; set; }
    }
}
