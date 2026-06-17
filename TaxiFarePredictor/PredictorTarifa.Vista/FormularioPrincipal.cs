using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using PredictorTarifa.Negocio;

namespace PredictorTarifa.Vista
{
    // Capa de Vista: Formulario principal de Windows Forms
    // Este archivo contiene SOLO los eventos y la logica de presentacion
    // Los controles visuales estan definidos en FormularioPrincipal.Designer.cs
    public partial class FormularioPrincipal : Form
    {
        // El gestor puede ser null cuando el Disenador de VS carga el formulario
        private GestorViaje? _gestorViaje;

        public FormularioPrincipal()
        {
            InitializeComponent();

            // Verificar si estamos en modo diseño (Visual Studio Designer)
            // Si es modo diseño, NO conectamos a BD ni a ML para evitar errores
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !DesignMode)
            {
                _gestorViaje = new GestorViaje();
                CargarHistorial();
            }
        }

        // =====================================================
        // EVENTO: Boton Entrenar Modelo
        // =====================================================
        private async void BtnEntrenar_Click(object sender, EventArgs e)
        {
            if (_gestorViaje == null) return;

            btnEntrenar.Enabled = false;
            btnEntrenar.Text = "Entrenando... por favor espere";
            barraProgreso.MarqueeAnimationSpeed = 30;
            lblEstadoModelo.Text = "Procesando archivo CSV con miles de registros...";
            lblEstadoModelo.ForeColor = Color.FromArgb(100, 116, 139);

            string resultado = await Task.Run(() => _gestorViaje.EntrenarModelo());

            barraProgreso.MarqueeAnimationSpeed = 0;
            btnEntrenar.Enabled = true;
            btnEntrenar.Text = "Entrenar con Datos Historicos (CSV)";

            if (resultado.StartsWith("ERROR"))
            {
                lblEstadoModelo.ForeColor = Color.Red;
                lblEstadoModelo.Text = resultado;
                MessageBox.Show(resultado, "Error de Entrenamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblEstadoModelo.ForeColor = Color.FromArgb(22, 163, 74);
                lblEstadoModelo.Text = "Modelo listo. " + resultado.Split('\n')[0];
                btnEntrenar.BackColor = Color.FromArgb(22, 163, 74);
                lblEstadoConexion.Text = "Modelo entrenado correctamente | SQL Server conectado";
            }
        }

        // =====================================================
        // EVENTO: Boton Predecir y Guardar
        // =====================================================
        private async void BtnPredecir_Click(object sender, EventArgs e)
        {
            if (_gestorViaje == null) return;

            string empresa = cmbEmpresa.SelectedItem?.ToString() ?? "CMT";
            float pasajeros = (float)numPasajeros.Value;
            float distancia = (float)numDistancia.Value;
            float duracion = (float)numDuracion.Value;
            string tipoPago = cmbTipoPago.SelectedIndex == 0 ? "CRD" : "CSH";

            btnPredecir.Enabled = false;
            btnPredecir.Text = "Procesando...";
            lblTarifaPredicha.Text = "$ ...";
            panelResultado.BackColor = Color.FromArgb(240, 253, 244);

            var resultado = await Task.Run(() =>
                _gestorViaje.PredecirYGuardar(empresa, 1f, pasajeros, duracion, distancia, tipoPago)
            );

            btnPredecir.Enabled = true;
            btnPredecir.Text = "Predecir Tarifa y Guardar en BD";

            if (resultado.Exitoso)
            {
                lblTarifaPredicha.Text = "$" + resultado.TarifaPredicha.ToString("F2");
                lblMensajeGuardado.Text = "Guardado en SQL Server con ID: " + resultado.ViajeId;
                panelResultado.BackColor = Color.FromArgb(240, 253, 244);
                CargarHistorial();
            }
            else
            {
                lblTarifaPredicha.Text = "Error";
                lblMensajeGuardado.Text = resultado.Mensaje;
                panelResultado.BackColor = Color.FromArgb(254, 242, 242);
            }
        }

        // =====================================================
        // EVENTO: Boton Refrescar Historial
        // =====================================================
        private void BtnRefrescarHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        // =====================================================
        // METODO: Cargar historial desde SQL Server via EF Core
        // =====================================================
        private void CargarHistorial()
        {
            if (_gestorViaje == null) return;

            try
            {
                var viajes = _gestorViaje.ObtenerHistorial(100);
                int total = _gestorViaje.TotalViajesGuardados();

                lblTotalViajes.Text = "Total en BD: " + total + " viajes";
                lblEstadoConexion.Text = "SQL Server conectado | " + total + " registros en PredictorTarifaDB";

                gridHistorial.DataSource = null;
                gridHistorial.Columns.Clear();
                gridHistorial.DataSource = viajes;

                // Renombrar encabezados de columnas al espanol
                if (gridHistorial.Columns.Count > 0)
                {
                    gridHistorial.Columns["Id"].HeaderText = "ID";
                    gridHistorial.Columns["Empresa"].HeaderText = "Empresa";
                    gridHistorial.Columns["CodigoTarifa"].HeaderText = "Codigo";
                    gridHistorial.Columns["NumeroPasajeros"].HeaderText = "Pasajeros";
                    gridHistorial.Columns["DuracionSegundos"].HeaderText = "Duracion (s)";
                    gridHistorial.Columns["DistanciaMillas"].HeaderText = "Distancia (mi)";
                    gridHistorial.Columns["TipoPago"].HeaderText = "Pago";
                    gridHistorial.Columns["TarifaReal"].HeaderText = "Tarifa Real";
                    gridHistorial.Columns["TarifaPredicha"].HeaderText = "Tarifa IA ($)";
                    gridHistorial.Columns["FechaRegistro"].HeaderText = "Fecha Registro";

                    // Formatos de presentacion
                    gridHistorial.Columns["TarifaPredicha"].DefaultCellStyle.Format = "F2";
                    gridHistorial.Columns["TarifaReal"].DefaultCellStyle.Format = "F2";
                    gridHistorial.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    gridHistorial.Columns["Id"].Width = 40;
                    gridHistorial.Columns["Empresa"].Width = 65;
                    gridHistorial.Columns["CodigoTarifa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblEstadoConexion.Text = "Error de conexion a SQL Server: " + ex.Message;
                lblTotalViajes.Text = "Error al cargar datos";
            }
        }

        private void gridHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grupoHistorial_Enter(object sender, EventArgs e)
        {

        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
