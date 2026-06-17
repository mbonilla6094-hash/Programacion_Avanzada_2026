using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ControlEstudiantes
{
    public partial class Form1 : Form
    {
        List<Estudiante> listaEstudiantes = new List<Estudiante>();
        List<Tutor> listaTutores = new List<Tutor>();
        List<Horario> listaHorarios = new List<Horario>();
        List<Inscripcion> listaInscripciones = new List<Inscripcion>();

        BindingList<Estudiante> bindingEstudiantes;
        BindingList<Tutor> bindingTutores;
        BindingList<Horario> bindingHorarios;
        BindingList<Inscripcion> bindingInscripciones;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
            ConfigurarGrids();
            ActualizarComboBoxes();
        }

        private void CargarDatosIniciales()
        {
            listaEstudiantes.Add(new Estudiante(1, "1850116094", "Mateo", "Bonilla", "mbonilla6094@uta.edu.ec", "0995909727"));
            listaEstudiantes.Add(new Estudiante(2, "1705123456", "Ana", "Rodriguez", "ana.rodriguez@uta.edu.ec", "0998123456"));
            listaEstudiantes.Add(new Estudiante(3, "0912345678", "Carlos", "Gomez", "carlos.gomez@uta.edu.ec", "0987654321"));
            listaEstudiantes.Add(new Estudiante(4, "1309876543", "Maria", "Lopez", "maria.lopez@uta.edu.ec", "0999876543"));
            listaEstudiantes.Add(new Estudiante(5, "1801234567", "Jose", "Martinez", "jose.martinez@uta.edu.ec", "0981234567"));

            listaTutores.Add(new Tutor(1, "1800001111", "Luis", "Herrera", "Programacion", 5));
            listaTutores.Add(new Tutor(2, "1800002222", "Patricia", "Salazar", "Base de Datos", 4));
            listaTutores.Add(new Tutor(3, "1800003333", "Roberto", "Mendoza", "Redes", 6));

            listaHorarios.Add(new Horario(1, "Lunes", "08:00 - 09:00", "Lab-01", 1, "Herrera Luis"));
            listaHorarios.Add(new Horario(2, "Martes", "10:00 - 11:00", "Lab-02", 2, "Salazar Patricia"));
            listaHorarios.Add(new Horario(3, "Miercoles", "14:00 - 15:00", "Lab-03", 3, "Mendoza Roberto"));
            listaHorarios.Add(new Horario(4, "Jueves", "08:00 - 09:00", "Lab-01", 1, "Herrera Luis"));
        }

        private void ConfigurarGrids()
        {
            bindingEstudiantes = new BindingList<Estudiante>(listaEstudiantes);
            dataGridViewEstudiantes.DataSource = bindingEstudiantes;

            bindingTutores = new BindingList<Tutor>(listaTutores);
            dataGridViewTutores.DataSource = bindingTutores;

            bindingHorarios = new BindingList<Horario>(listaHorarios);
            dataGridViewHorarios.DataSource = bindingHorarios;

            bindingInscripciones = new BindingList<Inscripcion>(listaInscripciones);
            dataGridViewInscripciones.DataSource = bindingInscripciones;
        }

        private void ActualizarComboBoxes()
        {
            // ComboBox Tutor en Horarios
            comboBoxTutorHor.Items.Clear();
            comboBoxTutorHor.Items.Add("-- Seleccione --");
            foreach (var tutor in listaTutores)
                comboBoxTutorHor.Items.Add(tutor);
            comboBoxTutorHor.SelectedIndex = 0;

            // ComboBox Estudiante en Inscripciones
            comboBoxEstudianteInsc.Items.Clear();
            comboBoxEstudianteInsc.Items.Add("-- Seleccione --");
            foreach (var est in listaEstudiantes)
                comboBoxEstudianteInsc.Items.Add(est);
            comboBoxEstudianteInsc.SelectedIndex = 0;

            // ComboBox Tutor en Inscripciones
            comboBoxTutorInsc.Items.Clear();
            comboBoxTutorInsc.Items.Add("-- Seleccione --");
            foreach (var tutor in listaTutores)
                comboBoxTutorInsc.Items.Add(tutor);
            comboBoxTutorInsc.SelectedIndex = 0;

            // ComboBox Filtrar Tutor
            comboBoxFiltrarTutor.Items.Clear();
            comboBoxFiltrarTutor.Items.Add("-- Todos --");
            foreach (var tutor in listaTutores)
                comboBoxFiltrarTutor.Items.Add(tutor);
            comboBoxFiltrarTutor.SelectedIndex = 0;

            // ComboBox Filtrar Horario
            comboBoxFiltrarHorario.Items.Clear();
            comboBoxFiltrarHorario.Items.Add("-- Todos --");
            foreach (var horario in listaHorarios)
                comboBoxFiltrarHorario.Items.Add(horario);
            comboBoxFiltrarHorario.SelectedIndex = 0;
        }

        // ====================================================================
        //  ESTUDIANTES
        // ====================================================================
        private void buttonRegistrarEst_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxCedulaEst.Text) ||
                    string.IsNullOrWhiteSpace(textBoxNombresEst.Text) ||
                    string.IsNullOrWhiteSpace(textBoxApellidosEst.Text))
                {
                    MessageBox.Show("Los campos Cedula, Nombres y Apellidos son obligatorios.",
                        "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cedula = textBoxCedulaEst.Text.Trim();

                if (cedula.Length != 10 || !cedula.All(char.IsDigit))
                {
                    MessageBox.Show("La cedula debe tener exactamente 10 digitos numericos.",
                        "Formato Invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar cedula unica
                foreach (var est in listaEstudiantes)
                {
                    if (est.Cedula.Equals(cedula, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Ya existe un estudiante registrado con esta cedula.",
                            "Cedula Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int nuevoId = listaEstudiantes.Count > 0 ? listaEstudiantes.Max(x => x.Id) + 1 : 1;

                var estudiante = new Estudiante(
                    nuevoId,
                    cedula,
                    textBoxNombresEst.Text.Trim(),
                    textBoxApellidosEst.Text.Trim(),
                    textBoxCorreoEst.Text.Trim(),
                    textBoxTelefonoEst.Text.Trim()
                );

                listaEstudiantes.Add(estudiante);
                RefrescarGridEstudiantes();
                ActualizarComboBoxes();
                LimpiarCamposEstudiante();
                MessageBox.Show("Estudiante registrado exitosamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar estudiante: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpiarEst_Click(object sender, EventArgs e)
        {
            LimpiarCamposEstudiante();
        }

        private void buttonEliminarEst_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEstudiantes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un estudiante para eliminar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var estudiante = (Estudiante)dataGridViewEstudiantes.SelectedRows[0].DataBoundItem;

                // Verificar si tiene inscripciones
                bool tieneInscripciones = listaInscripciones.Any(i => i.EstudianteId == estudiante.Id);
                if (tieneInscripciones)
                {
                    MessageBox.Show("No se puede eliminar, el estudiante tiene inscripciones activas.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var resultado = MessageBox.Show($"¿Esta seguro de eliminar al estudiante {estudiante}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    listaEstudiantes.Remove(estudiante);
                    RefrescarGridEstudiantes();
                    ActualizarComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposEstudiante()
        {
            textBoxCedulaEst.Text = string.Empty;
            textBoxNombresEst.Text = string.Empty;
            textBoxApellidosEst.Text = string.Empty;
            textBoxCorreoEst.Text = string.Empty;
            textBoxTelefonoEst.Text = string.Empty;
            textBoxCedulaEst.Focus();
        }

        private void textBoxBuscarEst_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = textBoxBuscarEst.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(filtro))
                {
                    dataGridViewEstudiantes.DataSource = new BindingList<Estudiante>(listaEstudiantes);
                }
                else
                {
                    var filtrados = listaEstudiantes.Where(est =>
                        est.Cedula.ToLower().Contains(filtro) ||
                        est.Nombres.ToLower().Contains(filtro) ||
                        est.Apellidos.ToLower().Contains(filtro)
                    ).ToList();
                    dataGridViewEstudiantes.DataSource = new BindingList<Estudiante>(filtrados);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGridEstudiantes()
        {
            bindingEstudiantes = new BindingList<Estudiante>(listaEstudiantes);
            dataGridViewEstudiantes.DataSource = bindingEstudiantes;
        }

        // ====================================================================
        //  TUTORES
        // ====================================================================
        private void buttonRegistrarTut_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxCedulaTut.Text) ||
                    string.IsNullOrWhiteSpace(textBoxNombresTut.Text) ||
                    string.IsNullOrWhiteSpace(textBoxApellidosTut.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEspecialidad.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.",
                        "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cedula = textBoxCedulaTut.Text.Trim();

                if (cedula.Length != 10 || !cedula.All(char.IsDigit))
                {
                    MessageBox.Show("La cedula debe tener exactamente 10 digitos numericos.",
                        "Formato Invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar cedula unica
                foreach (var tut in listaTutores)
                {
                    if (tut.Cedula.Equals(cedula, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Ya existe un tutor registrado con esta cedula.",
                            "Cedula Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int nuevoId = listaTutores.Count > 0 ? listaTutores.Max(x => x.Id) + 1 : 1;

                var tutor = new Tutor(
                    nuevoId,
                    cedula,
                    textBoxNombresTut.Text.Trim(),
                    textBoxApellidosTut.Text.Trim(),
                    textBoxEspecialidad.Text.Trim(),
                    (int)numericUpDownCupo.Value
                );

                listaTutores.Add(tutor);
                RefrescarGridTutores();
                ActualizarComboBoxes();
                LimpiarCamposTutor();
                MessageBox.Show("Tutor registrado exitosamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar tutor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpiarTut_Click(object sender, EventArgs e)
        {
            LimpiarCamposTutor();
        }

        private void buttonEliminarTut_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTutores.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un tutor para eliminar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tutor = (Tutor)dataGridViewTutores.SelectedRows[0].DataBoundItem;

                bool tieneInscripciones = listaInscripciones.Any(i => i.TutorId == tutor.Id);
                if (tieneInscripciones)
                {
                    MessageBox.Show("No se puede eliminar, el tutor tiene inscripciones activas.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var resultado = MessageBox.Show($"¿Esta seguro de eliminar al tutor {tutor}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    listaTutores.Remove(tutor);
                    RefrescarGridTutores();
                    ActualizarComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposTutor()
        {
            textBoxCedulaTut.Text = string.Empty;
            textBoxNombresTut.Text = string.Empty;
            textBoxApellidosTut.Text = string.Empty;
            textBoxEspecialidad.Text = string.Empty;
            numericUpDownCupo.Value = 10;
            textBoxCedulaTut.Focus();
        }

        private void RefrescarGridTutores()
        {
            bindingTutores = new BindingList<Tutor>(listaTutores);
            dataGridViewTutores.DataSource = bindingTutores;
        }

        // ====================================================================
        //  HORARIOS
        // ====================================================================
        private void buttonRegistrarHor_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDia.SelectedIndex < 0 ||
                    comboBoxHora.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(textBoxAula.Text) ||
                    comboBoxTutorHor.SelectedIndex <= 0)
                {
                    MessageBox.Show("Todos los campos son obligatorios. Seleccione dia, hora, aula y tutor.",
                        "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string dia = comboBoxDia.SelectedItem.ToString();
                string hora = comboBoxHora.SelectedItem.ToString();
                string aula = textBoxAula.Text.Trim();
                Tutor tutorSeleccionado = (Tutor)comboBoxTutorHor.SelectedItem;

                // Validar choque de horario (mismo dia y hora en la misma aula)
                foreach (var h in listaHorarios)
                {
                    if (h.Dia.Equals(dia, StringComparison.OrdinalIgnoreCase) &&
                        h.Hora.Equals(hora, StringComparison.OrdinalIgnoreCase) &&
                        h.Aula.Equals(aula, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Ya existe un horario registrado en {dia} a las {hora} en el aula {aula}.",
                            "Choque de Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Validar choque de horario del tutor (mismo dia y hora)
                foreach (var h in listaHorarios)
                {
                    if (h.Dia.Equals(dia, StringComparison.OrdinalIgnoreCase) &&
                        h.Hora.Equals(hora, StringComparison.OrdinalIgnoreCase) &&
                        h.TutorId == tutorSeleccionado.Id)
                    {
                        MessageBox.Show($"El tutor {tutorSeleccionado.Apellidos} ya tiene un horario asignado el {dia} a las {hora}.",
                            "Choque de Horario del Tutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int nuevoId = listaHorarios.Count > 0 ? listaHorarios.Max(x => x.Id) + 1 : 1;

                var horario = new Horario(
                    nuevoId, dia, hora, aula,
                    tutorSeleccionado.Id,
                    $"{tutorSeleccionado.Apellidos} {tutorSeleccionado.Nombres}"
                );

                listaHorarios.Add(horario);
                RefrescarGridHorarios();
                ActualizarComboBoxes();
                LimpiarCamposHorario();
                MessageBox.Show("Horario registrado exitosamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar horario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpiarHor_Click(object sender, EventArgs e)
        {
            LimpiarCamposHorario();
        }

        private void buttonEliminarHor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewHorarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un horario para eliminar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var horario = (Horario)dataGridViewHorarios.SelectedRows[0].DataBoundItem;

                bool tieneInscripciones = listaInscripciones.Any(i => i.HorarioId == horario.Id);
                if (tieneInscripciones)
                {
                    MessageBox.Show("No se puede eliminar, el horario tiene inscripciones activas.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var resultado = MessageBox.Show($"¿Esta seguro de eliminar el horario {horario}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    listaHorarios.Remove(horario);
                    RefrescarGridHorarios();
                    ActualizarComboBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposHorario()
        {
            comboBoxDia.SelectedIndex = -1;
            comboBoxHora.SelectedIndex = -1;
            textBoxAula.Text = string.Empty;
            if (comboBoxTutorHor.Items.Count > 0)
                comboBoxTutorHor.SelectedIndex = 0;
        }

        private void RefrescarGridHorarios()
        {
            bindingHorarios = new BindingList<Horario>(listaHorarios);
            dataGridViewHorarios.DataSource = bindingHorarios;
        }

        // ====================================================================
        //  INSCRIPCIONES
        // ====================================================================
        private void comboBoxTutorInsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxHorarioInsc.Items.Clear();
                comboBoxHorarioInsc.Items.Add("-- Seleccione --");

                if (comboBoxTutorInsc.SelectedIndex > 0)
                {
                    Tutor tutorSeleccionado = (Tutor)comboBoxTutorInsc.SelectedItem;
                    var horariosDelTutor = listaHorarios.Where(h => h.TutorId == tutorSeleccionado.Id).ToList();

                    foreach (var horario in horariosDelTutor)
                        comboBoxHorarioInsc.Items.Add(horario);

                    // Actualizar resumen de cupos
                    int cupoMax = tutorSeleccionado.CupoMaximo;
                    int ocupados = listaInscripciones.Count(i => i.TutorId == tutorSeleccionado.Id);
                    int disponibles = cupoMax - ocupados;

                    labelCuposOcupados.Text = $"Cupos Ocupados: {ocupados}";
                    labelCuposDisponibles.Text = $"Cupos Disponibles: {disponibles}";
                    labelTotalInscritos.Text = $"Total Inscritos: {listaInscripciones.Count}";
                }

                comboBoxHorarioInsc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInscribir_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEstudianteInsc.SelectedIndex <= 0 ||
                    comboBoxTutorInsc.SelectedIndex <= 0 ||
                    comboBoxHorarioInsc.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar estudiante, tutor y horario.",
                        "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Estudiante estSeleccionado = (Estudiante)comboBoxEstudianteInsc.SelectedItem;
                Tutor tutorSeleccionado = (Tutor)comboBoxTutorInsc.SelectedItem;
                Horario horarioSeleccionado = (Horario)comboBoxHorarioInsc.SelectedItem;

                // Validar cupo maximo
                int inscritosAlTutor = listaInscripciones.Count(i => i.TutorId == tutorSeleccionado.Id);
                if (inscritosAlTutor >= tutorSeleccionado.CupoMaximo)
                {
                    MessageBox.Show($"El tutor {tutorSeleccionado.Apellidos} ya alcanzo el cupo maximo ({tutorSeleccionado.CupoMaximo}).",
                        "Cupo Lleno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que el estudiante no este ya inscrito en este horario
                bool yaInscrito = listaInscripciones.Any(i =>
                    i.EstudianteId == estSeleccionado.Id &&
                    i.HorarioId == horarioSeleccionado.Id);

                if (yaInscrito)
                {
                    MessageBox.Show("El estudiante ya se encuentra inscrito en este horario.",
                        "Inscripcion Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar choque de horario del estudiante (mismo dia y hora en otro tutor)
                foreach (var insc in listaInscripciones)
                {
                    if (insc.EstudianteId == estSeleccionado.Id)
                    {
                        var horarioExistente = listaHorarios.FirstOrDefault(h => h.Id == insc.HorarioId);
                        if (horarioExistente != null &&
                            horarioExistente.Dia.Equals(horarioSeleccionado.Dia, StringComparison.OrdinalIgnoreCase) &&
                            horarioExistente.Hora.Equals(horarioSeleccionado.Hora, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show($"El estudiante ya tiene una tutoria el {horarioSeleccionado.Dia} a las {horarioSeleccionado.Hora}. Existe un choque de horario.",
                                "Choque de Horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                int nuevoId = listaInscripciones.Count > 0 ? listaInscripciones.Max(x => x.Id) + 1 : 1;

                var inscripcion = new Inscripcion(
                    nuevoId,
                    estSeleccionado.Id,
                    $"{estSeleccionado.Apellidos} {estSeleccionado.Nombres}",
                    estSeleccionado.Cedula,
                    tutorSeleccionado.Id,
                    $"{tutorSeleccionado.Apellidos} {tutorSeleccionado.Nombres}",
                    horarioSeleccionado.Id,
                    horarioSeleccionado.ToString()
                );

                listaInscripciones.Add(inscripcion);
                RefrescarGridInscripciones();
                ActualizarResumenCupos(tutorSeleccionado);
                MessageBox.Show("Estudiante inscrito exitosamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inscribir: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminarInsc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewInscripciones.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una inscripcion para eliminar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var inscripcion = (Inscripcion)dataGridViewInscripciones.SelectedRows[0].DataBoundItem;

                var resultado = MessageBox.Show($"¿Esta seguro de eliminar la inscripcion de {inscripcion.NombreEstudiante}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    listaInscripciones.Remove(inscripcion);
                    RefrescarGridInscripciones();

                    if (comboBoxTutorInsc.SelectedIndex > 0)
                        ActualizarResumenCupos((Tutor)comboBoxTutorInsc.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumenCupos(Tutor tutor)
        {
            int ocupados = listaInscripciones.Count(i => i.TutorId == tutor.Id);
            int disponibles = tutor.CupoMaximo - ocupados;

            labelCuposOcupados.Text = $"Cupos Ocupados: {ocupados}";
            labelCuposDisponibles.Text = $"Cupos Disponibles: {disponibles}";
            labelTotalInscritos.Text = $"Total Inscritos: {listaInscripciones.Count}";
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = listaInscripciones.AsEnumerable();

                if (comboBoxFiltrarTutor.SelectedIndex > 0)
                {
                    Tutor tutorFiltro = (Tutor)comboBoxFiltrarTutor.SelectedItem;
                    resultado = resultado.Where(i => i.TutorId == tutorFiltro.Id);
                }

                if (comboBoxFiltrarHorario.SelectedIndex > 0)
                {
                    Horario horarioFiltro = (Horario)comboBoxFiltrarHorario.SelectedItem;
                    resultado = resultado.Where(i => i.HorarioId == horarioFiltro.Id);
                }

                dataGridViewInscripciones.DataSource = new BindingList<Inscripcion>(resultado.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMostrarTodos_Click(object sender, EventArgs e)
        {
            RefrescarGridInscripciones();
            comboBoxFiltrarTutor.SelectedIndex = 0;
            comboBoxFiltrarHorario.SelectedIndex = 0;
        }

        private void RefrescarGridInscripciones()
        {
            bindingInscripciones = new BindingList<Inscripcion>(listaInscripciones);
            dataGridViewInscripciones.DataSource = bindingInscripciones;
        }

        private void labelCedulaEst_Click(object sender, EventArgs e)
        {

        }
    }
}