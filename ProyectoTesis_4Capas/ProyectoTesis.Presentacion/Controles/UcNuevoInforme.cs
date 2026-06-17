using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion.Controles
{
    public partial class UcNuevoInforme : UserControl
    {
        private readonly Estudiante _estudiante;
        private readonly Profesor _profesor;
        private readonly FormPrincipal _principal;
        private readonly IInformeServicio _informeServicio;
        private BindingSource _bsDetalles;

        public UcNuevoInforme(Estudiante estudiante, Profesor profesor, FormPrincipal principal)
        {
            InitializeComponent();
            _estudiante = estudiante;
            _profesor = profesor;
            _principal = principal;
            _informeServicio = new InformeServicio();
        }

        private void UcNuevoInforme_Load(object sender, EventArgs e)
        {
            lblEstudiante.Text = $"{_estudiante.Nombres} {_estudiante.Apellidos} - {_estudiante.TituloTesis}";
            _bsDetalles = new BindingSource();
            AgregarFilaVacia();
            ActualizarTotal();
        }

        private void AgregarFilaVacia()
        {
            var lista = _bsDetalles.DataSource as List<InformeDetalleViewModel>;
            if (lista == null) lista = new List<InformeDetalleViewModel>();
            lista.Add(new InformeDetalleViewModel());
            _bsDetalles.DataSource = lista;
            dgvActividades.DataSource = _bsDetalles;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvActividades.Columns.Count == 0) return;
            dgvActividades.Columns["DescripcionActividad"].HeaderText = "Actividad";
            dgvActividades.Columns["DescripcionActividad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvActividades.Columns["PorcentajeActividad"].HeaderText = "% Avance";
            dgvActividades.Columns["PorcentajeActividad"].Width = 90;
        }

        private void BtnAgregarActividad_Click(object sender, EventArgs e)
        {
            AgregarFilaVacia();
        }

        private void BtnQuitarActividad_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow == null) return;
            var lista = (List<InformeDetalleViewModel>)_bsDetalles.DataSource;
            if (lista.Count <= 1) return;
            int idx = dgvActividades.CurrentRow.Index;
            if (idx >= 0 && idx < lista.Count)
            {
                lista.RemoveAt(idx);
                _bsDetalles.ResetBindings(false);
            }
        }

        private void DgvActividades_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarTotal();
        }

        private void DgvActividades_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ActualizarTotal()
        {
            var lista = _bsDetalles?.DataSource as List<InformeDetalleViewModel>;
            if (lista == null) return;
            int total = lista.Where(x => x.PorcentajeActividad.HasValue).Sum(x => x.PorcentajeActividad.Value);
            lblTotal.Text = $"Total: {total}%";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var modelos = _bsDetalles.DataSource as List<InformeDetalleViewModel>;
            if (modelos == null || modelos.Count == 0 ||
                modelos.Any(d => string.IsNullOrWhiteSpace(d.DescripcionActividad) ||
                                 !d.PorcentajeActividad.HasValue ||
                                 d.PorcentajeActividad < 0 || d.PorcentajeActividad > 100))
            {
                MessageBox.Show("Complete todas las actividades con % entre 0 y 100", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (modelos.Sum(d => d.PorcentajeActividad.Value) > 100)
            {
                MessageBox.Show("La suma de porcentajes no puede superar 100%", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var detalles = new List<InformeDetalle>();
                for (int i = 0; i < modelos.Count; i++)
                {
                    detalles.Add(new InformeDetalle
                    {
                        NumeroActividad = i + 1,
                        DescripcionActividad = modelos[i].DescripcionActividad,
                        PorcentajeActividad = modelos[i].PorcentajeActividad.Value
                    });
                }

                _informeServicio.CrearInforme(_estudiante.EstudianteId, _profesor.ProfesorId, detalles);

                MessageBox.Show("Informe guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _principal.AbrirControl(new UcEstudiantes(_profesor, _principal));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            _principal.AbrirControl(new UcEstudiantes(_profesor, _principal));
        }
    }

    public class InformeDetalleViewModel
    {
        public string DescripcionActividad { get; set; }
        public int? PorcentajeActividad { get; set; }
    }
}
