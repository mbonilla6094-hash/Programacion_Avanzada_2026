using System.Drawing;
using System.Windows.Forms;

namespace ProyectoTesis.Presentacion.Controles
{
    partial class UcNuevoInforme
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
            this.lblMes = new System.Windows.Forms.Label();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.gbActividades = new System.Windows.Forms.GroupBox();
            this.tblActividades = new System.Windows.Forms.TableLayoutPanel();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.pnlBotonesActividades = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregarActividad = new System.Windows.Forms.Button();
            this.btnQuitarActividad = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbActividades.SuspendLayout();
            this.tblActividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.pnlBotonesActividades.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(232, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Informe Mensual";
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic);
            this.lblEstudiante.Location = new System.Drawing.Point(15, 40);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(0, 17);
            this.lblEstudiante.TabIndex = 1;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(15, 70);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(46, 13);
            this.lblMes.TabIndex = 2;
            this.lblMes.Text = "Periodo:";
            // 
            // dtpMes
            // 
            this.dtpMes.CustomFormat = "MMMM yyyy";
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(70, 68);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.ShowUpDown = true;
            this.dtpMes.Size = new System.Drawing.Size(150, 20);
            this.dtpMes.TabIndex = 3;
            // 
            // gbActividades
            // 
            this.gbActividades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActividades.Controls.Add(this.tblActividades);
            this.gbActividades.Location = new System.Drawing.Point(15, 100);
            this.gbActividades.Name = "gbActividades";
            this.gbActividades.Size = new System.Drawing.Size(770, 400);
            this.gbActividades.TabIndex = 4;
            this.gbActividades.TabStop = false;
            this.gbActividades.Text = "Actividades del Mes";
            // 
            // tblActividades
            // 
            this.tblActividades.ColumnCount = 1;
            this.tblActividades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblActividades.Controls.Add(this.dgvActividades, 0, 0);
            this.tblActividades.Controls.Add(this.pnlBotonesActividades, 0, 1);
            this.tblActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblActividades.Location = new System.Drawing.Point(3, 16);
            this.tblActividades.Name = "tblActividades";
            this.tblActividades.RowCount = 2;
            this.tblActividades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActividades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblActividades.Size = new System.Drawing.Size(764, 381);
            this.tblActividades.TabIndex = 0;
            // 
            // dgvActividades
            // 
            this.dgvActividades.AllowUserToAddRows = false;
            this.dgvActividades.AllowUserToDeleteRows = false;
            this.dgvActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActividades.Location = new System.Drawing.Point(3, 3);
            this.dgvActividades.Name = "dgvActividades";
            this.dgvActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvActividades.Size = new System.Drawing.Size(758, 340);
            this.dgvActividades.TabIndex = 0;
            this.dgvActividades.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvActividades_CellEndEdit);
            this.dgvActividades.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvActividades_DataError);
            // 
            // pnlBotonesActividades
            // 
            this.pnlBotonesActividades.Controls.Add(this.btnAgregarActividad);
            this.pnlBotonesActividades.Controls.Add(this.btnQuitarActividad);
            this.pnlBotonesActividades.Controls.Add(this.lblTotal);
            this.pnlBotonesActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotonesActividades.Location = new System.Drawing.Point(3, 349);
            this.pnlBotonesActividades.Name = "pnlBotonesActividades";
            this.pnlBotonesActividades.Size = new System.Drawing.Size(758, 29);
            this.pnlBotonesActividades.TabIndex = 1;
            // 
            // btnAgregarActividad
            // 
            this.btnAgregarActividad.Location = new System.Drawing.Point(3, 3);
            this.btnAgregarActividad.Name = "btnAgregarActividad";
            this.btnAgregarActividad.Size = new System.Drawing.Size(120, 23);
            this.btnAgregarActividad.TabIndex = 0;
            this.btnAgregarActividad.Text = "Agregar Actividad";
            this.btnAgregarActividad.UseVisualStyleBackColor = true;
            this.btnAgregarActividad.Click += new System.EventHandler(this.BtnAgregarActividad_Click);
            // 
            // btnQuitarActividad
            // 
            this.btnQuitarActividad.Location = new System.Drawing.Point(129, 3);
            this.btnQuitarActividad.Name = "btnQuitarActividad";
            this.btnQuitarActividad.Size = new System.Drawing.Size(120, 23);
            this.btnQuitarActividad.TabIndex = 1;
            this.btnQuitarActividad.Text = "Quitar Actividad";
            this.btnQuitarActividad.UseVisualStyleBackColor = true;
            this.btnQuitarActividad.Click += new System.EventHandler(this.BtnQuitarActividad_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(255, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(77, 17);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total: 0%";
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAcciones.Controls.Add(this.btnGuardar);
            this.pnlAcciones.Controls.Add(this.btnCancelar);
            this.pnlAcciones.Location = new System.Drawing.Point(15, 510);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(260, 40);
            this.pnlAcciones.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(129, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // UcNuevoInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblEstudiante);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.dtpMes);
            this.Controls.Add(this.gbActividades);
            this.Controls.Add(this.pnlAcciones);
            this.Name = "UcNuevoInforme";
            this.Size = new System.Drawing.Size(800, 560);
            this.Load += new System.EventHandler(this.UcNuevoInforme_Load);
            this.gbActividades.ResumeLayout(false);
            this.tblActividades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            this.pnlBotonesActividades.ResumeLayout(false);
            this.pnlBotonesActividades.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblTitulo; private Label lblEstudiante;
        private Label lblMes; private DateTimePicker dtpMes;
        private GroupBox gbActividades;
        private TableLayoutPanel tblActividades;
        private DataGridView dgvActividades;
        private FlowLayoutPanel pnlBotonesActividades;
        private Button btnAgregarActividad; private Button btnQuitarActividad; private Label lblTotal;
        private FlowLayoutPanel pnlAcciones;
        private Button btnGuardar; private Button btnCancelar;
    }
}
