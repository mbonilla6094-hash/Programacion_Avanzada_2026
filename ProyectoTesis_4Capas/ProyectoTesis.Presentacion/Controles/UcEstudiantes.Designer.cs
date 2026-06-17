using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTesis.Presentacion.Controles
{
    partial class UcEstudiantes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btnVerPdf = new System.Windows.Forms.Button();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            this.btnNuevoInforme = new System.Windows.Forms.Button();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.gbFiltros.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.SuspendLayout();

            this.gbFiltros.Controls.Add(this.lblResultados);
            this.gbFiltros.Controls.Add(this.btnLimpiar);
            this.gbFiltros.Controls.Add(this.btnBuscar);
            this.gbFiltros.Controls.Add(this.chkFecha);
            this.gbFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbFiltros.Controls.Add(this.dtpFechaDesde);
            this.gbFiltros.Controls.Add(this.cboEstado);
            this.gbFiltros.Controls.Add(this.txtCarrera);
            this.gbFiltros.Controls.Add(this.txtApellido);
            this.gbFiltros.Controls.Add(this.txtNombre);
            this.gbFiltros.Controls.Add(this.lblEstado);
            this.gbFiltros.Controls.Add(this.lblCarrera);
            this.gbFiltros.Controls.Add(this.lblApellido);
            this.gbFiltros.Controls.Add(this.lblNombre);
            this.gbFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltros.Size = new System.Drawing.Size(1100, 85);
            this.gbFiltros.Text = "Filtros";

            this.lblNombre.AutoSize = true; this.lblNombre.Location = new Point(15, 25); this.lblNombre.Text = "Nombre:";
            this.txtNombre.Location = new Point(70, 22); this.txtNombre.Size = new Size(130, 20);
            this.lblApellido.AutoSize = true; this.lblApellido.Location = new Point(210, 25); this.lblApellido.Text = "Apellido:";
            this.txtApellido.Location = new Point(270, 22); this.txtApellido.Size = new Size(130, 20);
            this.lblCarrera.AutoSize = true; this.lblCarrera.Location = new Point(410, 25); this.lblCarrera.Text = "Carrera:";
            this.txtCarrera.Location = new Point(465, 22); this.txtCarrera.Size = new Size(130, 20);
            this.lblEstado.AutoSize = true; this.lblEstado.Location = new Point(605, 25); this.lblEstado.Text = "Estado:";
            this.cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new Point(655, 22); this.cboEstado.Size = new Size(110, 21);

            this.chkFecha.AutoSize = true; this.chkFecha.Location = new Point(15, 55); this.chkFecha.Text = "Filtrar fecha";
            this.chkFecha.CheckedChanged += new System.EventHandler(this.ChkFecha_CheckedChanged);

            this.dtpFechaDesde.Enabled = false; this.dtpFechaDesde.Format = DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new Point(100, 53); this.dtpFechaDesde.Size = new Size(95, 20);
            this.dtpFechaHasta.Enabled = false; this.dtpFechaHasta.Format = DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new Point(205, 53); this.dtpFechaHasta.Size = new Size(95, 20);

            this.btnBuscar.Location = new Point(320, 51); this.btnBuscar.Size = new Size(75, 23); this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true; this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);

            this.btnLimpiar.Location = new Point(405, 51); this.btnLimpiar.Size = new Size(75, 23); this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true; this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);

            this.lblResultados.AutoSize = true; this.lblResultados.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            this.lblResultados.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblResultados.Location = new Point(500, 55);

            this.gbAcciones.Controls.Add(this.btnVerPdf);
            this.gbAcciones.Controls.Add(this.btnVerHistorial);
            this.gbAcciones.Controls.Add(this.btnNuevoInforme);
            this.gbAcciones.Dock = DockStyle.Bottom;
            this.gbAcciones.Size = new Size(1100, 55);
            this.gbAcciones.Text = "Acciones";

            this.btnNuevoInforme.BackColor = Color.FromArgb(0, 123, 255);
            this.btnNuevoInforme.FlatStyle = FlatStyle.Flat; this.btnNuevoInforme.ForeColor = Color.White;
            this.btnNuevoInforme.Location = new Point(15, 18); this.btnNuevoInforme.Size = new Size(130, 28);
            this.btnNuevoInforme.Text = "Nuevo Informe"; this.btnNuevoInforme.UseVisualStyleBackColor = false;
            this.btnNuevoInforme.Click += new System.EventHandler(this.BtnNuevoInforme_Click);

            this.btnVerHistorial.BackColor = Color.FromArgb(23, 162, 184);
            this.btnVerHistorial.FlatStyle = FlatStyle.Flat; this.btnVerHistorial.ForeColor = Color.White;
            this.btnVerHistorial.Location = new Point(155, 18); this.btnVerHistorial.Size = new Size(130, 28);
            this.btnVerHistorial.Text = "Ver Historial"; this.btnVerHistorial.UseVisualStyleBackColor = false;
            this.btnVerHistorial.Click += new System.EventHandler(this.BtnVerHistorial_Click);

            this.btnVerPdf.BackColor = Color.FromArgb(40, 167, 69);
            this.btnVerPdf.FlatStyle = FlatStyle.Flat; this.btnVerPdf.ForeColor = Color.White;
            this.btnVerPdf.Location = new Point(295, 18); this.btnVerPdf.Size = new Size(130, 28);
            this.btnVerPdf.Text = "Generar PDF"; this.btnVerPdf.UseVisualStyleBackColor = false;
            this.btnVerPdf.Click += new System.EventHandler(this.BtnVerPdf_Click);

            this.dgvEstudiantes.AllowUserToAddRows = false; this.dgvEstudiantes.AllowUserToDeleteRows = false;
            this.dgvEstudiantes.AutoGenerateColumns = true; this.dgvEstudiantes.Dock = DockStyle.Fill;
            this.dgvEstudiantes.ReadOnly = true; this.dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.dgvEstudiantes);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbFiltros);
            this.Size = new Size(1100, 540);
            this.Load += new System.EventHandler(this.UcEstudiantes_Load);
            this.gbFiltros.ResumeLayout(false); this.gbFiltros.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.ResumeLayout(false);
        }

        private GroupBox gbFiltros;
        private Label lblResultados;
        private Button btnLimpiar; private Button btnBuscar;
        private CheckBox chkFecha; private DateTimePicker dtpFechaHasta; private DateTimePicker dtpFechaDesde;
        private ComboBox cboEstado; private TextBox txtCarrera; private TextBox txtApellido; private TextBox txtNombre;
        private Label lblEstado; private Label lblCarrera; private Label lblApellido; private Label lblNombre;
        private GroupBox gbAcciones;
        private Button btnVerPdf; private Button btnVerHistorial; private Button btnNuevoInforme;
        private DataGridView dgvEstudiantes;
    }
}
