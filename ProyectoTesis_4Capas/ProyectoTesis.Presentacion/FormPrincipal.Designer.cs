namespace ProyectoTesis.Presentacion
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnNuevoEstudiante = new System.Windows.Forms.Button();
            this.btnEstudiantes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();

            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.pnlSuperior.Controls.Add(this.btnNuevoEstudiante);
            this.pnlSuperior.Controls.Add(this.btnEstudiantes);
            this.pnlSuperior.Controls.Add(this.btnSalir);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Size = new System.Drawing.Size(1200, 50);

            this.btnEstudiantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstudiantes.ForeColor = System.Drawing.Color.White;
            this.btnEstudiantes.Location = new System.Drawing.Point(10, 10);
            this.btnEstudiantes.Size = new System.Drawing.Size(120, 30);
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.UseVisualStyleBackColor = false;
            this.btnEstudiantes.Click += new System.EventHandler(this.BtnEstudiantes_Click);

            this.btnNuevoEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoEstudiante.ForeColor = System.Drawing.Color.White;
            this.btnNuevoEstudiante.Location = new System.Drawing.Point(140, 10);
            this.btnNuevoEstudiante.Size = new System.Drawing.Size(150, 30);
            this.btnNuevoEstudiante.Text = "Nuevo Estudiante";
            this.btnNuevoEstudiante.UseVisualStyleBackColor = false;
            this.btnNuevoEstudiante.Click += new System.EventHandler(this.BtnNuevoEstudiante_Click);

            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(1100, 10);
            this.btnSalir.Size = new System.Drawing.Size(80, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);

            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 50);
            this.pnlContenido.Size = new System.Drawing.Size(1200, 600);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlSuperior);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestion de Tesis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Button btnNuevoEstudiante;
        private System.Windows.Forms.Button btnEstudiantes;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.Panel pnlContenido;
    }
}
