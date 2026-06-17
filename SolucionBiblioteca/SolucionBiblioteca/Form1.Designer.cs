namespace SolucionBiblioteca
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLibros = new System.Windows.Forms.TabPage();
            this.btnAgregarLibro = new System.Windows.Forms.Button();
            this.lblEjemplares = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.numEjemplares = new System.Windows.Forms.NumericUpDown();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.tabPageCategorias = new System.Windows.Forms.TabPage();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.lblCatNombre = new System.Windows.Forms.Label();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.txtCatNombre = new System.Windows.Forms.TextBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.tabPageEstudiantes = new System.Windows.Forms.TabPage();
            this.btnAgregarEstudiante = new System.Windows.Forms.Button();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lblEstApellido = new System.Windows.Forms.Label();
            this.lblEstNombre = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.numSemestre = new System.Windows.Forms.NumericUpDown();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.txtEstApellido = new System.Windows.Forms.TextBox();
            this.txtEstNombre = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.tabPagePrestamos = new System.Windows.Forms.TabPage();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.lblPrestamoLibro = new System.Windows.Forms.Label();
            this.lblPrestamoEst = new System.Windows.Forms.Label();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.tabPageEstadisticas = new System.Windows.Forms.TabPage();
            this.chartPrestamos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPageLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEjemplares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.tabPageCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.tabPageEstudiantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSemestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.tabPagePrestamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.tabPageEstadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLibros);
            this.tabControl1.Controls.Add(this.tabPageCategorias);
            this.tabControl1.Controls.Add(this.tabPageEstudiantes);
            this.tabControl1.Controls.Add(this.tabPagePrestamos);
            this.tabControl1.Controls.Add(this.tabPageEstadisticas);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(650, 480);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLibros
            // 
            this.tabPageLibros.Controls.Add(this.btnAgregarLibro);
            this.tabPageLibros.Controls.Add(this.lblEjemplares);
            this.tabPageLibros.Controls.Add(this.lblAutor);
            this.tabPageLibros.Controls.Add(this.lblTitulo);
            this.tabPageLibros.Controls.Add(this.lblISBN);
            this.tabPageLibros.Controls.Add(this.numEjemplares);
            this.tabPageLibros.Controls.Add(this.txtAutor);
            this.tabPageLibros.Controls.Add(this.txtTitulo);
            this.tabPageLibros.Controls.Add(this.txtISBN);
            this.tabPageLibros.Controls.Add(this.dgvLibros);
            this.tabPageLibros.Location = new System.Drawing.Point(4, 22);
            this.tabPageLibros.Name = "tabPageLibros";
            this.tabPageLibros.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLibros.Size = new System.Drawing.Size(642, 454);
            this.tabPageLibros.TabIndex = 0;
            this.tabPageLibros.Text = "Libros";
            this.tabPageLibros.UseVisualStyleBackColor = true;
            // 
            // btnAgregarLibro
            // 
            this.btnAgregarLibro.Location = new System.Drawing.Point(100, 400);
            this.btnAgregarLibro.Name = "btnAgregarLibro";
            this.btnAgregarLibro.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarLibro.TabIndex = 0;
            this.btnAgregarLibro.Text = "Agregar Libro";
            this.btnAgregarLibro.Click += new System.EventHandler(this.btnAgregarLibro_Click);
            // 
            // lblEjemplares
            // 
            this.lblEjemplares.Location = new System.Drawing.Point(20, 360);
            this.lblEjemplares.Name = "lblEjemplares";
            this.lblEjemplares.Size = new System.Drawing.Size(100, 23);
            this.lblEjemplares.TabIndex = 1;
            this.lblEjemplares.Text = "Ejemplares:";
            // 
            // lblAutor
            // 
            this.lblAutor.Location = new System.Drawing.Point(20, 330);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(100, 23);
            this.lblAutor.TabIndex = 2;
            this.lblAutor.Text = "Autor:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(20, 300);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(100, 23);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Título:";
            // 
            // lblISBN
            // 
            this.lblISBN.Location = new System.Drawing.Point(20, 270);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(100, 23);
            this.lblISBN.TabIndex = 4;
            this.lblISBN.Text = "ISBN:";
            // 
            // numEjemplares
            // 
            this.numEjemplares.Location = new System.Drawing.Point(126, 360);
            this.numEjemplares.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEjemplares.Name = "numEjemplares";
            this.numEjemplares.Size = new System.Drawing.Size(150, 20);
            this.numEjemplares.TabIndex = 5;
            this.numEjemplares.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(126, 330);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(150, 20);
            this.txtAutor.TabIndex = 6;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(126, 300);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(150, 20);
            this.txtTitulo.TabIndex = 7;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(126, 270);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(150, 20);
            this.txtISBN.TabIndex = 8;
            // 
            // dgvLibros
            // 
            this.dgvLibros.Location = new System.Drawing.Point(6, 6);
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.Size = new System.Drawing.Size(628, 250);
            this.dgvLibros.TabIndex = 0;
            // 
            // tabPageCategorias
            // 
            this.tabPageCategorias.Controls.Add(this.btnAgregarCategoria);
            this.tabPageCategorias.Controls.Add(this.lblCatDesc);
            this.tabPageCategorias.Controls.Add(this.lblCatNombre);
            this.tabPageCategorias.Controls.Add(this.txtCatDesc);
            this.tabPageCategorias.Controls.Add(this.txtCatNombre);
            this.tabPageCategorias.Controls.Add(this.dgvCategorias);
            this.tabPageCategorias.Location = new System.Drawing.Point(4, 22);
            this.tabPageCategorias.Name = "tabPageCategorias";
            this.tabPageCategorias.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCategorias.Size = new System.Drawing.Size(642, 454);
            this.tabPageCategorias.TabIndex = 1;
            this.tabPageCategorias.Text = "Categorías";
            this.tabPageCategorias.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(100, 340);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarCategoria.TabIndex = 0;
            this.btnAgregarCategoria.Text = "Agregar Categoría";
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // lblCatDesc
            // 
            this.lblCatDesc.Location = new System.Drawing.Point(20, 300);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(100, 23);
            this.lblCatDesc.TabIndex = 1;
            this.lblCatDesc.Text = "Descripción:";
            // 
            // lblCatNombre
            // 
            this.lblCatNombre.Location = new System.Drawing.Point(20, 270);
            this.lblCatNombre.Name = "lblCatNombre";
            this.lblCatNombre.Size = new System.Drawing.Size(100, 23);
            this.lblCatNombre.TabIndex = 2;
            this.lblCatNombre.Text = "Nombre:";
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(126, 303);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(200, 20);
            this.txtCatDesc.TabIndex = 3;
            // 
            // txtCatNombre
            // 
            this.txtCatNombre.Location = new System.Drawing.Point(126, 274);
            this.txtCatNombre.Name = "txtCatNombre";
            this.txtCatNombre.Size = new System.Drawing.Size(200, 20);
            this.txtCatNombre.TabIndex = 4;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.Location = new System.Drawing.Point(6, 6);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.Size = new System.Drawing.Size(628, 250);
            this.dgvCategorias.TabIndex = 5;
            // 
            // tabPageEstudiantes
            // 
            this.tabPageEstudiantes.Controls.Add(this.btnAgregarEstudiante);
            this.tabPageEstudiantes.Controls.Add(this.lblSemestre);
            this.tabPageEstudiantes.Controls.Add(this.lblCarrera);
            this.tabPageEstudiantes.Controls.Add(this.lblEstApellido);
            this.tabPageEstudiantes.Controls.Add(this.lblEstNombre);
            this.tabPageEstudiantes.Controls.Add(this.lblMatricula);
            this.tabPageEstudiantes.Controls.Add(this.numSemestre);
            this.tabPageEstudiantes.Controls.Add(this.txtCarrera);
            this.tabPageEstudiantes.Controls.Add(this.txtEstApellido);
            this.tabPageEstudiantes.Controls.Add(this.txtEstNombre);
            this.tabPageEstudiantes.Controls.Add(this.txtMatricula);
            this.tabPageEstudiantes.Controls.Add(this.dgvEstudiantes);
            this.tabPageEstudiantes.Location = new System.Drawing.Point(4, 22);
            this.tabPageEstudiantes.Name = "tabPageEstudiantes";
            this.tabPageEstudiantes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEstudiantes.Size = new System.Drawing.Size(642, 454);
            this.tabPageEstudiantes.TabIndex = 2;
            this.tabPageEstudiantes.Text = "Estudiantes";
            this.tabPageEstudiantes.UseVisualStyleBackColor = true;
            // 
            // btnAgregarEstudiante
            // 
            this.btnAgregarEstudiante.Location = new System.Drawing.Point(100, 370);
            this.btnAgregarEstudiante.Name = "btnAgregarEstudiante";
            this.btnAgregarEstudiante.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarEstudiante.TabIndex = 0;
            this.btnAgregarEstudiante.Text = "Agregar Estudiante";
            this.btnAgregarEstudiante.Click += new System.EventHandler(this.btnAgregarEstudiante_Click);
            // 
            // lblSemestre
            // 
            this.lblSemestre.Location = new System.Drawing.Point(270, 330);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(100, 23);
            this.lblSemestre.TabIndex = 1;
            this.lblSemestre.Text = "Semestre:";
            // 
            // lblCarrera
            // 
            this.lblCarrera.Location = new System.Drawing.Point(20, 330);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(100, 23);
            this.lblCarrera.TabIndex = 2;
            this.lblCarrera.Text = "Carrera:";
            // 
            // lblEstApellido
            // 
            this.lblEstApellido.Location = new System.Drawing.Point(270, 300);
            this.lblEstApellido.Name = "lblEstApellido";
            this.lblEstApellido.Size = new System.Drawing.Size(100, 23);
            this.lblEstApellido.TabIndex = 3;
            this.lblEstApellido.Text = "Apellido:";
            // 
            // lblEstNombre
            // 
            this.lblEstNombre.Location = new System.Drawing.Point(20, 300);
            this.lblEstNombre.Name = "lblEstNombre";
            this.lblEstNombre.Size = new System.Drawing.Size(100, 23);
            this.lblEstNombre.TabIndex = 4;
            this.lblEstNombre.Text = "Nombre:";
            // 
            // lblMatricula
            // 
            this.lblMatricula.Location = new System.Drawing.Point(20, 270);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(100, 23);
            this.lblMatricula.TabIndex = 5;
            this.lblMatricula.Text = "Matrícula:";
            // 
            // numSemestre
            // 
            this.numSemestre.Location = new System.Drawing.Point(376, 330);
            this.numSemestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSemestre.Name = "numSemestre";
            this.numSemestre.Size = new System.Drawing.Size(120, 20);
            this.numSemestre.TabIndex = 6;
            this.numSemestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtCarrera
            // 
            this.txtCarrera.Location = new System.Drawing.Point(126, 330);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(100, 20);
            this.txtCarrera.TabIndex = 7;
            // 
            // txtEstApellido
            // 
            this.txtEstApellido.Location = new System.Drawing.Point(376, 297);
            this.txtEstApellido.Name = "txtEstApellido";
            this.txtEstApellido.Size = new System.Drawing.Size(100, 20);
            this.txtEstApellido.TabIndex = 8;
            // 
            // txtEstNombre
            // 
            this.txtEstNombre.Location = new System.Drawing.Point(126, 300);
            this.txtEstNombre.Name = "txtEstNombre";
            this.txtEstNombre.Size = new System.Drawing.Size(100, 20);
            this.txtEstNombre.TabIndex = 9;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(126, 270);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(100, 20);
            this.txtMatricula.TabIndex = 10;
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.Location = new System.Drawing.Point(6, 6);
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.Size = new System.Drawing.Size(628, 250);
            this.dgvEstudiantes.TabIndex = 11;
            // 
            // tabPagePrestamos
            // 
            this.tabPagePrestamos.Controls.Add(this.btnDevolver);
            this.tabPagePrestamos.Controls.Add(this.btnPrestar);
            this.tabPagePrestamos.Controls.Add(this.lblPrestamoLibro);
            this.tabPagePrestamos.Controls.Add(this.lblPrestamoEst);
            this.tabPagePrestamos.Controls.Add(this.cmbLibro);
            this.tabPagePrestamos.Controls.Add(this.cmbEstudiante);
            this.tabPagePrestamos.Controls.Add(this.dgvPrestamos);
            this.tabPagePrestamos.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrestamos.Name = "tabPagePrestamos";
            this.tabPagePrestamos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrestamos.Size = new System.Drawing.Size(642, 454);
            this.tabPagePrestamos.TabIndex = 3;
            this.tabPagePrestamos.Text = "Préstamos";
            this.tabPagePrestamos.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(270, 310);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(150, 30);
            this.btnDevolver.TabIndex = 0;
            this.btnDevolver.Text = "Devolver Libro Seleccionado";
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnPrestar
            // 
            this.btnPrestar.Location = new System.Drawing.Point(100, 310);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(150, 30);
            this.btnPrestar.TabIndex = 1;
            this.btnPrestar.Text = "Registrar Préstamo";
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // lblPrestamoLibro
            // 
            this.lblPrestamoLibro.Location = new System.Drawing.Point(328, 270);
            this.lblPrestamoLibro.Name = "lblPrestamoLibro";
            this.lblPrestamoLibro.Size = new System.Drawing.Size(100, 23);
            this.lblPrestamoLibro.TabIndex = 2;
            this.lblPrestamoLibro.Text = "Libro:";
            // 
            // lblPrestamoEst
            // 
            this.lblPrestamoEst.Location = new System.Drawing.Point(20, 270);
            this.lblPrestamoEst.Name = "lblPrestamoEst";
            this.lblPrestamoEst.Size = new System.Drawing.Size(100, 23);
            this.lblPrestamoEst.TabIndex = 3;
            this.lblPrestamoEst.Text = "Estudiante:";
            // 
            // cmbLibro
            // 
            this.cmbLibro.Location = new System.Drawing.Point(434, 267);
            this.cmbLibro.Name = "cmbLibro";
            this.cmbLibro.Size = new System.Drawing.Size(200, 21);
            this.cmbLibro.TabIndex = 4;
            // 
            // cmbEstudiante
            // 
            this.cmbEstudiante.Location = new System.Drawing.Point(126, 270);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(200, 21);
            this.cmbEstudiante.TabIndex = 5;
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.Location = new System.Drawing.Point(6, 6);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.Size = new System.Drawing.Size(628, 250);
            this.dgvPrestamos.TabIndex = 6;
            // 
            // tabPageEstadisticas
            // 
            this.tabPageEstadisticas.Controls.Add(this.chartPrestamos);
            this.tabPageEstadisticas.Location = new System.Drawing.Point(4, 22);
            this.tabPageEstadisticas.Name = "tabPageEstadisticas";
            this.tabPageEstadisticas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEstadisticas.Size = new System.Drawing.Size(642, 454);
            this.tabPageEstadisticas.TabIndex = 4;
            this.tabPageEstadisticas.Text = "Estadísticas";
            this.tabPageEstadisticas.UseVisualStyleBackColor = true;
            // 
            // chartPrestamos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPrestamos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPrestamos.Legends.Add(legend1);
            this.chartPrestamos.Location = new System.Drawing.Point(8, 6);
            this.chartPrestamos.Name = "chartPrestamos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Prestamos";
            this.chartPrestamos.Series.Add(series1);
            this.chartPrestamos.Size = new System.Drawing.Size(626, 440);
            this.chartPrestamos.TabIndex = 0;
            this.chartPrestamos.Text = "Estadísticas de Préstamos";
            this.chartPrestamos.Click += new System.EventHandler(this.chartPrestamos_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(650, 480);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Gestión de Biblioteca N-Capas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLibros.ResumeLayout(false);
            this.tabPageLibros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEjemplares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.tabPageCategorias.ResumeLayout(false);
            this.tabPageCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.tabPageEstudiantes.ResumeLayout(false);
            this.tabPageEstudiantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSemestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.tabPagePrestamos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.tabPageEstadisticas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPrestamos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLibros;
        private System.Windows.Forms.TabPage tabPageCategorias;
        private System.Windows.Forms.TabPage tabPageEstudiantes;
        private System.Windows.Forms.TabPage tabPagePrestamos;

        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.Button btnAgregarLibro;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.NumericUpDown numEjemplares;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblEjemplares;

        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.TextBox txtCatNombre;
        private System.Windows.Forms.TextBox txtCatDesc;
        private System.Windows.Forms.Label lblCatNombre;
        private System.Windows.Forms.Label lblCatDesc;

        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.Button btnAgregarEstudiante;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtEstNombre;
        private System.Windows.Forms.TextBox txtEstApellido;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.NumericUpDown numSemestre;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblEstNombre;
        private System.Windows.Forms.Label lblEstApellido;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.Label lblSemestre;

        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.ComboBox cmbLibro;
        private System.Windows.Forms.Label lblPrestamoEst;
        private System.Windows.Forms.Label lblPrestamoLibro;
        private System.Windows.Forms.TabPage tabPageEstadisticas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrestamos;
    }
}
