using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class FormLogin : Form
    {
        private List<Usuario> listaUsuarios;

        public FormLogin()
        {
            InitializeComponent();
            listaUsuarios = Usuario.ObtenerUsuariosIniciales();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                MessageBox.Show("Ingrese el ID de usuario",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxId.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxContrasena.Text))
            {
                MessageBox.Show("Ingrese la contrasena",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxContrasena.Focus();
                return;
            }

            if (!int.TryParse(textBoxId.Text.Trim(), out int idUsuario))
            {
                MessageBox.Show("El ID debe ser un numero entero",
                    "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxId.Focus();
                return;
            }

            Usuario? usuarioEncontrado = BuscarUsuario(idUsuario, textBoxContrasena.Text.Trim());

            if (usuarioEncontrado != null)
            {
                this.Hide();
                FormPrincipal formPrincipal = new FormPrincipal(usuarioEncontrado);
                formPrincipal.FormClosed += (s, args) =>
                {
                    LimpiarCampos();
                    this.Show();
                };
                formPrincipal.Show();
            }
            else
            {
                labelMensaje.Text = "ID o contrasena incorrectos";
                MessageBox.Show("Las credenciales ingresadas no son validas",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContrasena.Text = string.Empty;
                textBoxContrasena.Focus();
            }
        }

        private Usuario? BuscarUsuario(int id, string contrasena)
        {
            foreach (var usuario in listaUsuarios)
            {
                if (usuario.Id == id &&
                    usuario.Contrasena.Equals(contrasena, StringComparison.Ordinal))
                {
                    return usuario;
                }
            }
            return null;
        }

        private void LimpiarCampos()
        {
            textBoxId.Text = string.Empty;
            textBoxContrasena.Text = string.Empty;
            labelMensaje.Text = string.Empty;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicacion?",
                "Confirmar salida", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
