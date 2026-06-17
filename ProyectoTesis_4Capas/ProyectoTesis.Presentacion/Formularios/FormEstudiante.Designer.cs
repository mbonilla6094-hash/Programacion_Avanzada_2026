using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTesis.Presentacion.Formularios
{
    partial class FormEstudiante
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.lblTituloTesis = new System.Windows.Forms.Label();
            this.txtTituloTesis = new System.Windows.Forms.TextBox();
            this.lblNumeroResolucion = new System.Windows.Forms.Label();
            this.txtNumeroResolucion = new System.Windows.Forms.TextBox();
            this.lblFechaResolucion = new System.Windows.Forms.Label();
            this.dtpFechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.lblResolucion = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Nombres
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new Point(20, 20);
            this.lblNombres.Text = "Nombres:";
            this.txtNombres.Location = new Point(130, 17);
            this.txtNombres.Size = new Size(250, 22);

            // Apellidos
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new Point(20, 50);
            this.lblApellidos.Text = "Apellidos:";
            this.txtApellidos.Location = new Point(130, 47);
            this.txtApellidos.Size = new Size(250, 22);

            // Cedula
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new Point(20, 80);
            this.lblCedula.Text = "Cedula:";
            this.txtCedula.Location = new Point(130, 77);
            this.txtCedula.Size = new Size(250, 22);

            // Carrera
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Location = new Point(20, 110);
            this.lblCarrera.Text = "Carrera:";
            this.txtCarrera.Location = new Point(130, 107);
            this.txtCarrera.Size = new Size(250, 22);

            // Titulo Tesis
            this.lblTituloTesis.AutoSize = true;
            this.lblTituloTesis.Location = new Point(20, 140);
            this.lblTituloTesis.Text = "Titulo Tesis:";
            this.txtTituloTesis.Location = new Point(130, 137);
            this.txtTituloTesis.Size = new Size(250, 22);

            // N. Resolucion
            this.lblNumeroResolucion.AutoSize = true;
            this.lblNumeroResolucion.Location = new Point(20, 170);
            this.lblNumeroResolucion.Text = "N. Resolucion:";
            this.txtNumeroResolucion.Location = new Point(130, 167);
            this.txtNumeroResolucion.Size = new Size(250, 22);

            // Fecha Res.
            this.lblFechaResolucion.AutoSize = true;
            this.lblFechaResolucion.Location = new Point(20, 200);
            this.lblFechaResolucion.Text = "Fecha Res.:";
            this.dtpFechaResolucion.Format = DateTimePickerFormat.Short;
            this.dtpFechaResolucion.Location = new Point(130, 197);
            this.dtpFechaResolucion.Size = new Size(120, 22);

            // Resolucion PDF
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Location = new Point(20, 230);
            this.lblResolucion.Text = "Resolucion PDF:";
            this.btnExaminar.Location = new Point(130, 227);
            this.btnExaminar.Size = new Size(80, 23);
            this.btnExaminar.Text = "Examinar...";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.BtnExaminar_Click);
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.ForeColor = Color.Gray;
            this.lblArchivo.Location = new Point(220, 230);
            this.lblArchivo.Text = "Ningun archivo";

            // Guardar
            this.btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(130, 265);
            this.btnGuardar.Size = new Size(100, 35);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            // Cancelar
            this.btnCancelar.Location = new Point(250, 265);
            this.btnCancelar.Size = new Size(100, 35);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);

            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(420, 320);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblApellidos);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCarrera);
            this.Controls.Add(this.txtCarrera);
            this.Controls.Add(this.lblTituloTesis);
            this.Controls.Add(this.txtTituloTesis);
            this.Controls.Add(this.lblNumeroResolucion);
            this.Controls.Add(this.txtNumeroResolucion);
            this.Controls.Add(this.lblFechaResolucion);
            this.Controls.Add(this.dtpFechaResolucion);
            this.Controls.Add(this.lblResolucion);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nuevo Estudiante";
            this.Load += new System.EventHandler(this.FormEstudiante_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblNombres; private TextBox txtNombres;
        private Label lblApellidos; private TextBox txtApellidos;
        private Label lblCedula; private TextBox txtCedula;
        private Label lblCarrera; private TextBox txtCarrera;
        private Label lblTituloTesis; private TextBox txtTituloTesis;
        private Label lblNumeroResolucion; private TextBox txtNumeroResolucion;
        private Label lblFechaResolucion; private DateTimePicker dtpFechaResolucion;
        private Label lblResolucion; private Button btnExaminar; private Label lblArchivo;
        private Button btnGuardar; private Button btnCancelar;
    }
}
