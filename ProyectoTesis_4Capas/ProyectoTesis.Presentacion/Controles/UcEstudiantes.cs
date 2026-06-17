using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;
using ProyectoTesis.Logica.Servicios;
using ProyectoTesis.Presentacion.Formularios;

namespace ProyectoTesis.Presentacion.Controles
{
    public partial class UcEstudiantes : UserControl
    {
        private readonly Profesor _profesor;
        private readonly FormPrincipal _principal;
        private readonly IEstudianteServicio _estudianteServicio;
        private readonly IInformeServicio _informeServicio;

        public UcEstudiantes(Profesor profesor, FormPrincipal principal)
        {
            InitializeComponent();
            _profesor = profesor;
            _principal = principal;
            _estudianteServicio = new EstudianteServicio();
            _informeServicio = new InformeServicio();
        }

        private void UcEstudiantes_Load(object sender, EventArgs e)
        {
            cboEstado.Items.AddRange(new object[] { "Todos", "En Proceso", "Aprobado" });
            cboEstado.SelectedIndex = 0;
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            try
            {
                var lista = _estudianteServicio.ObtenerPorProfesor(_profesor.ProfesorId);
                dgvEstudiantes.DataSource = lista.ToList();
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvEstudiantes.Columns.Count == 0) return;

            var ocultar = new[] { "ProfesorId", "Profesor", "ArchivoResolucion", "HistorialProgresion", "InformeCabecera" };
            foreach (var col in ocultar)
                if (dgvEstudiantes.Columns[col] != null)
                    dgvEstudiantes.Columns[col].Visible = false;

            if (dgvEstudiantes.Columns["EstudianteId"] != null)
                dgvEstudiantes.Columns["EstudianteId"].Visible = false;

            var headerText = new System.Collections.Generic.Dictionary<string, string>
            {
                {"Nombres","Nombres"},{"Apellidos","Apellidos"},{"Cedula","Cedula"},
                {"Carrera","Carrera"},{"TituloTesis","Titulo Tesis"},{"NumeroResolucion","N.Resolucion"},
                {"FechaResolucion","Fecha Res."},{"Estado","Estado"},{"PorcentajeAvance","% Avance"},
                {"FechaRegistro","Fecha Reg."}
            };
            foreach (var kv in headerText)
                if (dgvEstudiantes.Columns[kv.Key] != null)
                    dgvEstudiantes.Columns[kv.Key].HeaderText = kv.Value;

            dgvEstudiantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = cboEstado.SelectedIndex > 0 ? cboEstado.SelectedItem.ToString() : null;
                DateTime? fd = chkFecha.Checked ? dtpFechaDesde.Value : (DateTime?)null;
                DateTime? fh = chkFecha.Checked ? dtpFechaHasta.Value : (DateTime?)null;

                var lista = _estudianteServicio.BuscarConFiltros(
                    _profesor.ProfesorId, txtNombre.Text.Trim(), txtApellido.Text.Trim(),
                    txtCarrera.Text.Trim(), estado, fd, fh);

                dgvEstudiantes.DataSource = lista.ToList();
                ConfigurarColumnas();
                lblResultados.Text = $"Resultados: {lista.Count()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en busqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear(); txtApellido.Clear(); txtCarrera.Clear();
            cboEstado.SelectedIndex = 0;
            chkFecha.Checked = false;
            lblResultados.Text = "";
            CargarEstudiantes();
        }

        private void ChkFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.Enabled = chkFecha.Checked;
            dtpFechaHasta.Enabled = chkFecha.Checked;
        }

        private void BtnNuevoInforme_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var est = (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;
            _principal.AbrirControl(new UcNuevoInforme(est, _profesor, _principal));
        }

        private void BtnVerHistorial_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var est = (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;
            _principal.AbrirControl(new UcHistorialProgresion(est, _principal));
        }

        private void BtnVerPdf_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0) return;
            var est = (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Logo PNG|*.png";
                ofd.Title = "Seleccionar logo de la universidad";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] pdf;
                    if ((est.PorcentajeAvance ?? 0) >= 100)
                        pdf = _informeServicio.GenerarPdfInformeFinal(est.EstudianteId, ofd.FileName);
                    else
                    {
                        var informes = _informeServicio.ObtenerInformesPorEstudiante(est.EstudianteId).ToList();
                        if (informes.Count == 0)
                        {
                            MessageBox.Show("El estudiante no tiene informes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        pdf = _informeServicio.GenerarPdfInforme(informes[0].InformeCabeceraId, ofd.FileName);
                    }

                    string ruta = Path.Combine(Path.GetTempPath(), $"Informe_{est.Nombres}_{est.Apellidos}_{DateTime.Now:yyyyMMdd}.pdf");
                    File.WriteAllBytes(ruta, pdf);
                    System.Diagnostics.Process.Start(ruta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
