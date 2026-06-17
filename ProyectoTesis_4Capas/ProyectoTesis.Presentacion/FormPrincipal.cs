using System;
using System.Windows.Forms;
using ProyectoTesis.Entidades;

namespace ProyectoTesis.Presentacion
{
    public partial class FormPrincipal : Form
    {
        private readonly Profesor _profesor;
        public Profesor ProfesorActual => _profesor;

        public FormPrincipal(Profesor profesor)
        {
            InitializeComponent();
            _profesor = profesor;
            this.Text = $"Sistema de Gestion de Tesis - {profesor.Nombres} {profesor.Apellidos}";
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarVistaEstudiantes();
        }

        public void CargarVistaEstudiantes()
        {
            AbrirControl(new Controles.UcEstudiantes(_profesor, this));
        }

        private void BtnEstudiantes_Click(object sender, EventArgs e)
        {
            CargarVistaEstudiantes();
        }

        private void BtnNuevoEstudiante_Click(object sender, EventArgs e)
        {
            var form = new Formularios.FormEstudiante(_profesor.ProfesorId);
            if (form.ShowDialog() == DialogResult.OK)
                CargarVistaEstudiantes();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void AbrirControl(UserControl control)
        {
            pnlContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(control);
        }
    }
}
