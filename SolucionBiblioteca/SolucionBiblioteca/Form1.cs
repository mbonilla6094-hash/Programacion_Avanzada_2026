using System;
using System.Linq;
using System.Windows.Forms;
using LogicaNegocio;
using SolucionBiblioteca.Entidades;

namespace SolucionBiblioteca
{
    public partial class Form1 : Form
    {
        private BibliotecaLogica _logica;

        public Form1()
        {
            InitializeComponent();
            _logica = new BibliotecaLogica();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarListas();
        }

        private void ActualizarListas()
        {
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = _logica.ObtenerLibros();

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = _logica.ObtenerCategorias();

            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = _logica.ObtenerEstudiantes();

            dgvPrestamos.DataSource = null;
            dgvPrestamos.DataSource = _logica.ObtenerPrestamos();

            ActualizarComboBoxes();
            CargarGrafica();
        }

        private void ActualizarComboBoxes()
        {
            cmbEstudiante.DataSource = null;
            cmbEstudiante.DataSource = _logica.ObtenerEstudiantes();
            cmbEstudiante.DisplayMember = "NombreCompleto";
            cmbEstudiante.ValueMember = "EstudianteID";

            cmbLibro.DataSource = null;
            cmbLibro.DataSource = _logica.ObtenerLibros().Where(l => l.TieneDisponibilidad()).ToList();
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "LibroID";
        }

        private void CargarGrafica()
        {
            var estadisticas = _logica.ObtenerEstadisticasPrestamos();
            chartPrestamos.Series[0].Points.Clear();
            
            foreach (var kvp in estadisticas)
            {
                chartPrestamos.Series[0].Points.AddXY(kvp.Key, kvp.Value);
            }
        }
        
        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                var libro = new Libro
                {
                    ISBN = txtISBN.Text,
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    EjemplaresTotales = (int)numEjemplares.Value,
                    EjemplaresDisponibles = (int)numEjemplares.Value
                };
                
                _logica.RegistrarLibro(libro);
                MessageBox.Show("Libro agregado exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

       
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                var categoria = new Categoria(txtCatNombre.Text, txtCatDesc.Text);
                _logica.RegistrarCategoria(categoria);
                
                MessageBox.Show("Categoría agregada exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        
        private void btnAgregarEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                var estudiante = new Estudiante(txtMatricula.Text, txtEstNombre.Text, txtEstApellido.Text, txtCarrera.Text, (int)numSemestre.Value);
                _logica.RegistrarEstudiante(estudiante);
                
                MessageBox.Show("Estudiante agregado exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // PRESTAMOS
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLibro.SelectedValue == null || cmbEstudiante.SelectedValue == null)
                    throw new Exception("Debe seleccionar un estudiante y un libro");

                int libroId = (int)cmbLibro.SelectedValue;
                int estudianteId = (int)cmbEstudiante.SelectedValue;

                _logica.PrestarLibro(libroId, estudianteId);
                MessageBox.Show("Préstamo registrado exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrestamos.CurrentRow == null)
                    throw new Exception("Seleccione un préstamo de la tabla para devolver");

                var prestamo = (Prestamo)dgvPrestamos.CurrentRow.DataBoundItem;
                if (prestamo.Estado != "ACTIVO")
                    throw new Exception("Este préstamo ya fue devuelto o procesado");

                _logica.DevolverLibro(prestamo.PrestamoID);
                
                string mensaje = "Libro devuelto exitosamente. ";
                if (prestamo.MontoMulta > 0)
                    mensaje += $"El estudiante tiene una multa de ${prestamo.MontoMulta}";
                    
                MessageBox.Show(mensaje, "Devolución");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void chartPrestamos_Click(object sender, EventArgs e)
        {

        }
    }
}
