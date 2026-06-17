using System;
using System.Windows.Forms;
using ProyectoTesis.Logica.Interfaces;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion
{
    public partial class FormLogin : Form
    {
        private readonly ILoginServicio _loginServicio;

        public FormLogin()
        {
            InitializeComponent();
            _loginServicio = new LoginServicio();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Ingrese usuario y contrasena", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var profesor = _loginServicio.Autenticar(usuario, contrasena);

            if (profesor != null)
            {
                var principal = new FormPrincipal(profesor);
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contrasena incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtUsuario.Focus();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BtnIngresar_Click(sender, e);
        }
    }
}
