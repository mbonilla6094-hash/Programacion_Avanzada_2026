using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTesis.Presentacion.Controles
{
    partial class UcHistorialProgresion
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true; this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(0, 123, 255);
            this.lblTitulo.Location = new Point(15, 10); this.lblTitulo.Text = "Historial de Progresion";

            this.lblEstudiante.AutoSize = true; this.lblEstudiante.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic);
            this.lblEstudiante.Location = new Point(15, 40);

            this.lblPorcentaje.AutoSize = true; this.lblPorcentaje.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblPorcentaje.ForeColor = Color.FromArgb(40, 167, 69);
            this.lblPorcentaje.Location = new Point(15, 65);

            this.dgvHistorial.AllowUserToAddRows = false; this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvHistorial.AutoGenerateColumns = true; this.dgvHistorial.Location = new Point(15, 95);
            this.dgvHistorial.ReadOnly = true; this.dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new Size(770, 350);

            this.btnCerrar.Location = new Point(15, 455); this.btnCerrar.Size = new Size(100, 30);
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.UseVisualStyleBackColor = true; this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo); this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.lblPorcentaje); this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnCerrar);
            this.Size = new Size(800, 500);
            this.Load += new System.EventHandler(this.UcHistorialProgresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }

        private Label lblTitulo; private Label lblEstudiante; private Label lblPorcentaje;
        private DataGridView dgvHistorial; private Button btnCerrar;
    }
}
