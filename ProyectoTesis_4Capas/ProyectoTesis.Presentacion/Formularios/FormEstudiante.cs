using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion.Formularios
{
    public partial class FormEstudiante : Form
    {
        private readonly int _profesorId;
        private readonly int? _estudianteId;
        private readonly EstudianteServicio _servicio;
        private byte[] _archivoSeleccionado;

        public FormEstudiante(int profesorId, int? estudianteId = null)
        {
            InitializeComponent();
            _profesorId = profesorId;
            _estudianteId = estudianteId;
            _servicio = new EstudianteServicio();
        }

        private void FormEstudiante_Load(object sender, EventArgs e)
        {
            if (_estudianteId.HasValue)
            {
                this.Text = "Editar Estudiante";
                CargarDatos(_estudianteId.Value);
            }
        }

        private void CargarDatos(int id)
        {
            var est = _servicio.ObtenerPorId(id);
            if (est == null) return;

            txtNombres.Text = est.Nombres;
            txtApellidos.Text = est.Apellidos;
            txtCedula.Text = est.Cedula;
            txtCarrera.Text = est.Carrera;
            txtTituloTesis.Text = est.TituloTesis;
            txtNumeroResolucion.Text = est.NumeroResolucion;
            dtpFechaResolucion.Value = est.FechaResolucion;
            if (est.ArchivoResolucion != null)
            {
                _archivoSeleccionado = est.ArchivoResolucion;
                lblArchivo.Text = "Archivo cargado";
                lblArchivo.ForeColor = Color.Green;
            }
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos PDF|*.pdf";
                ofd.Title = "Seleccionar resolucion (PDF)";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _archivoSeleccionado = File.ReadAllBytes(ofd.FileName);
                    lblArchivo.Text = Path.GetFileName(ofd.FileName);
                    lblArchivo.ForeColor = Color.Green;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                if (_estudianteId.HasValue)
                {
                    var est = new Estudiante
                    {
                        EstudianteId = _estudianteId.Value,
                        Nombres = txtNombres.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Carrera = txtCarrera.Text.Trim(),
                        TituloTesis = txtTituloTesis.Text.Trim(),
                        NumeroResolucion = txtNumeroResolucion.Text.Trim(),
                        FechaResolucion = dtpFechaResolucion.Value,
                        ArchivoResolucion = _archivoSeleccionado
                    };
                    _servicio.Actualizar(est);
                }
                else
                {
                    var est = new Estudiante
                    {
                        ProfesorId = _profesorId,
                        Nombres = txtNombres.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Carrera = txtCarrera.Text.Trim(),
                        TituloTesis = txtTituloTesis.Text.Trim(),
                        NumeroResolucion = txtNumeroResolucion.Text.Trim(),
                        FechaResolucion = dtpFechaResolucion.Value,
                        ArchivoResolucion = _archivoSeleccionado
                    };
                    _servicio.Agregar(est);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text) ||
                string.IsNullOrWhiteSpace(txtTituloTesis.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroResolucion.Text))
            {
                MessageBox.Show("Complete todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_servicio.CedulaDisponible(txtCedula.Text.Trim(), _estudianteId))
            {
                MessageBox.Show("La cedula ya esta registrada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
