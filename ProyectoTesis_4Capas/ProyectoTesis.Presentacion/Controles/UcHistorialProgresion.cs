using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion.Controles
{
    public partial class UcHistorialProgresion : UserControl
    {
        private readonly Estudiante _estudiante;
        private readonly FormPrincipal _principal;
        private readonly HistorialServicio _historialServicio;

        public UcHistorialProgresion(Estudiante estudiante, FormPrincipal principal)
        {
            InitializeComponent();
            _estudiante = estudiante;
            _principal = principal;
            _historialServicio = new HistorialServicio();
        }

        private void UcHistorialProgresion_Load(object sender, EventArgs e)
        {
            lblEstudiante.Text = $"{_estudiante.Nombres} {_estudiante.Apellidos} - {_estudiante.TituloTesis}";
            lblPorcentaje.Text = $"Progreso Actual: {_estudiante.PorcentajeAvance ?? 0}%";
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                var historial = _historialServicio.ObtenerPorEstudiante(_estudiante.EstudianteId).ToList();
                dgvHistorial.DataSource = historial;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvHistorial.Columns.Count == 0) return;
            if (dgvHistorial.Columns["HistorialId"] != null) dgvHistorial.Columns["HistorialId"].Visible = false;
            if (dgvHistorial.Columns["EstudianteId"] != null) dgvHistorial.Columns["EstudianteId"].Visible = false;
            if (dgvHistorial.Columns["Estudiante"] != null) dgvHistorial.Columns["Estudiante"].Visible = false;
            if (dgvHistorial.Columns["InformeCabeceraId"] != null) dgvHistorial.Columns["InformeCabeceraId"].Visible = false;
            if (dgvHistorial.Columns["InformeCabecera"] != null) dgvHistorial.Columns["InformeCabecera"].Visible = false;

            var headers = new System.Collections.Generic.Dictionary<string, string>
            {
                {"FechaInforme","Fecha Informe"},{"PorcentajeEnInforme","% en Informe"},
                {"EstadoEnInforme","Estado"},{"ResumenActividades","Actividades"}
            };
            foreach (var kv in headers)
                if (dgvHistorial.Columns[kv.Key] != null)
                    dgvHistorial.Columns[kv.Key].HeaderText = kv.Value;
            dgvHistorial.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            _principal.AbrirControl(new UcEstudiantes(_principal.ProfesorActual, _principal));
        }
    }
}
