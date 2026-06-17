using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        private bool _modoEdicion = false;

        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarEstudiantes();
        }

        // ── Configuracion del DataGridView ────────────────────────────────
        private void ConfigurarGrid()
        {
            dgvEstudiantes.AutoGenerateColumns = false;
            dgvEstudiantes.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvEstudiantes.ReadOnly            = true;
            dgvEstudiantes.AllowUserToAddRows  = false;
            dgvEstudiantes.BackgroundColor     = Color.White;
            dgvEstudiantes.RowHeadersVisible   = false;
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId",        HeaderText = "ID",        DataPropertyName = "Id",            Width = 45  });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCedula",    HeaderText = "Cedula",    DataPropertyName = "Cedula",        Width = 100 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombres",   HeaderText = "Nombres",   DataPropertyName = "Nombres",       Width = 120 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colApellidos", HeaderText = "Apellidos", DataPropertyName = "Apellidos",     Width = 120 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail",     HeaderText = "Email",     DataPropertyName = "Email",         Width = 180 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCarrera",   HeaderText = "Carrera",   DataPropertyName = "Carrera",       Width = 180 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFecha",     HeaderText = "Fecha",     DataPropertyName = "FechaRegistro", Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        }

        // ── Cargar todos ──────────────────────────────────────────────────
        private void CargarEstudiantes()
        {
            try
            {
                Respuesta resp = EstudianteNEG.ObtenerTodos();
                if (resp.Exitoso)
                {
                    List<Estudiante> lista = resp.Data as List<Estudiante>;
                    dgvEstudiantes.DataSource = lista;
                    lblConteo.Text = "Total registros: " + lista.Count;
                }
                else
                {
                    MostrarError(resp.Mensaje);
                }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Buscar ────────────────────────────────────────────────────────
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Respuesta resp = EstudianteNEG.Buscar(txtBuscar.Text.Trim());
                if (resp.Exitoso)
                {
                    List<Estudiante> lista = resp.Data as List<Estudiante>;
                    dgvEstudiantes.DataSource = lista;
                    lblConteo.Text = "Resultados: " + lista.Count;
                }
                else { MostrarError(resp.Mensaje); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Seleccionar fila ──────────────────────────────────────────────
        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvEstudiantes.Rows[e.RowIndex];
            txtId.Text        = fila.Cells["colId"].Value.ToString();
            txtCedula.Text    = fila.Cells["colCedula"].Value.ToString();
            txtNombres.Text   = fila.Cells["colNombres"].Value.ToString();
            txtApellidos.Text = fila.Cells["colApellidos"].Value.ToString();
            txtEmail.Text     = fila.Cells["colEmail"].Value.ToString();
            txtCarrera.Text   = fila.Cells["colCarrera"].Value.ToString();

            _modoEdicion         = true;
            btnGuardar.Text      = "Actualizar";
            btnEliminar.Enabled  = true;
        }

        // ── Guardar / Actualizar ──────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Estudiante est = new Estudiante();
                est.Cedula    = txtCedula.Text.Trim();
                est.Nombres   = txtNombres.Text.Trim();
                est.Apellidos = txtApellidos.Text.Trim();
                est.Email     = txtEmail.Text.Trim();
                est.Carrera   = txtCarrera.Text.Trim();

                Respuesta resp;
                if (_modoEdicion)
                {
                    est.Id = int.Parse(txtId.Text);
                    resp   = EstudianteNEG.Actualizar(est);
                }
                else
                {
                    resp = EstudianteNEG.Insertar(est);
                }

                if (resp.Exitoso) { MostrarExito(resp.Mensaje); LimpiarFormulario(); CargarEstudiantes(); }
                else              { MostrarError(resp.Mensaje); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Eliminar ──────────────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult confirm = MessageBox.Show(
                "Seguro desea eliminar a " + txtNombres.Text + " " + txtApellidos.Text + "?",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Respuesta resp = EstudianteNEG.Eliminar(int.Parse(txtId.Text));
                if (resp.Exitoso) { MostrarExito(resp.Mensaje); LimpiarFormulario(); CargarEstudiantes(); }
                else              { MostrarError(resp.Mensaje); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Nuevo / Limpiar ───────────────────────────────────────────────
        private void btnNuevo_Click(object sender, EventArgs e)   { LimpiarFormulario(); }
        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarFormulario(); }

        private void LimpiarFormulario()
        {
            txtId.Clear(); txtCedula.Clear(); txtNombres.Clear();
            txtApellidos.Clear(); txtEmail.Clear(); txtCarrera.Clear();
            txtBuscar.Clear();
            _modoEdicion         = false;
            btnGuardar.Text      = "Guardar";
            btnEliminar.Enabled  = false;
        }

        private void MostrarExito(string msg) =>
            MessageBox.Show(msg, "Exito",  MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void MostrarError(string msg) =>
            MessageBox.Show(msg, "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
