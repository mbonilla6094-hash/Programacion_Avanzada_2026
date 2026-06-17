namespace ControlEstudiantes
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPageEstudiantes = new TabPage();
            groupBoxEstudiante = new GroupBox();
            labelCedulaEst = new Label();
            textBoxCedulaEst = new TextBox();
            labelNombresEst = new Label();
            textBoxNombresEst = new TextBox();
            labelApellidosEst = new Label();
            textBoxApellidosEst = new TextBox();
            labelCorreoEst = new Label();
            textBoxCorreoEst = new TextBox();
            labelTelefonoEst = new Label();
            textBoxTelefonoEst = new TextBox();
            buttonRegistrarEst = new Button();
            buttonLimpiarEst = new Button();
            buttonEliminarEst = new Button();
            groupBoxListaEst = new GroupBox();
            labelBuscarEst = new Label();
            textBoxBuscarEst = new TextBox();
            dataGridViewEstudiantes = new DataGridView();
            tabPageTutores = new TabPage();
            groupBoxTutor = new GroupBox();
            labelCedulaTut = new Label();
            textBoxCedulaTut = new TextBox();
            labelNombresTut = new Label();
            textBoxNombresTut = new TextBox();
            labelApellidosTut = new Label();
            textBoxApellidosTut = new TextBox();
            labelEspecialidad = new Label();
            textBoxEspecialidad = new TextBox();
            labelCupoMax = new Label();
            numericUpDownCupo = new NumericUpDown();
            buttonRegistrarTut = new Button();
            buttonLimpiarTut = new Button();
            buttonEliminarTut = new Button();
            groupBoxListaTut = new GroupBox();
            dataGridViewTutores = new DataGridView();
            tabPageHorarios = new TabPage();
            groupBoxHorario = new GroupBox();
            labelDia = new Label();
            comboBoxDia = new ComboBox();
            labelHora = new Label();
            comboBoxHora = new ComboBox();
            labelAula = new Label();
            textBoxAula = new TextBox();
            labelTutorHor = new Label();
            comboBoxTutorHor = new ComboBox();
            buttonRegistrarHor = new Button();
            buttonLimpiarHor = new Button();
            buttonEliminarHor = new Button();
            groupBoxListaHor = new GroupBox();
            dataGridViewHorarios = new DataGridView();
            tabPageInscripciones = new TabPage();
            groupBoxInscripcion = new GroupBox();
            labelEstudianteInsc = new Label();
            comboBoxEstudianteInsc = new ComboBox();
            labelTutorInsc = new Label();
            comboBoxTutorInsc = new ComboBox();
            labelHorarioInsc = new Label();
            comboBoxHorarioInsc = new ComboBox();
            buttonInscribir = new Button();
            buttonEliminarInsc = new Button();
            groupBoxResumen = new GroupBox();
            labelCuposOcupados = new Label();
            labelCuposDisponibles = new Label();
            labelTotalInscritos = new Label();
            groupBoxListaInsc = new GroupBox();
            labelFiltrarTutor = new Label();
            comboBoxFiltrarTutor = new ComboBox();
            labelFiltrarHorario = new Label();
            comboBoxFiltrarHorario = new ComboBox();
            buttonFiltrar = new Button();
            buttonMostrarTodos = new Button();
            dataGridViewInscripciones = new DataGridView();
            panelTitulo = new Panel();
            labelTitulo = new Label();
            panelLinea = new Panel();
            tabControl1.SuspendLayout();
            tabPageEstudiantes.SuspendLayout();
            groupBoxEstudiante.SuspendLayout();
            groupBoxListaEst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEstudiantes).BeginInit();
            tabPageTutores.SuspendLayout();
            groupBoxTutor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCupo).BeginInit();
            groupBoxListaTut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTutores).BeginInit();
            tabPageHorarios.SuspendLayout();
            groupBoxHorario.SuspendLayout();
            groupBoxListaHor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHorarios).BeginInit();
            tabPageInscripciones.SuspendLayout();
            groupBoxInscripcion.SuspendLayout();
            groupBoxResumen.SuspendLayout();
            groupBoxListaInsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInscripciones).BeginInit();
            panelTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageEstudiantes);
            tabControl1.Controls.Add(tabPageTutores);
            tabControl1.Controls.Add(tabPageHorarios);
            tabControl1.Controls.Add(tabPageInscripciones);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.Location = new Point(0, 53);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 558);
            tabControl1.TabIndex = 0;
            // 
            // tabPageEstudiantes
            // 
            tabPageEstudiantes.Controls.Add(groupBoxEstudiante);
            tabPageEstudiantes.Controls.Add(groupBoxListaEst);
            tabPageEstudiantes.Location = new Point(4, 26);
            tabPageEstudiantes.Name = "tabPageEstudiantes";
            tabPageEstudiantes.Padding = new Padding(3);
            tabPageEstudiantes.Size = new Size(976, 528);
            tabPageEstudiantes.TabIndex = 0;
            tabPageEstudiantes.Text = "  Estudiantes  ";
            tabPageEstudiantes.UseVisualStyleBackColor = true;
            // 
            // groupBoxEstudiante
            // 
            groupBoxEstudiante.Controls.Add(labelCedulaEst);
            groupBoxEstudiante.Controls.Add(textBoxCedulaEst);
            groupBoxEstudiante.Controls.Add(labelNombresEst);
            groupBoxEstudiante.Controls.Add(textBoxNombresEst);
            groupBoxEstudiante.Controls.Add(labelApellidosEst);
            groupBoxEstudiante.Controls.Add(textBoxApellidosEst);
            groupBoxEstudiante.Controls.Add(labelCorreoEst);
            groupBoxEstudiante.Controls.Add(textBoxCorreoEst);
            groupBoxEstudiante.Controls.Add(labelTelefonoEst);
            groupBoxEstudiante.Controls.Add(textBoxTelefonoEst);
            groupBoxEstudiante.Controls.Add(buttonRegistrarEst);
            groupBoxEstudiante.Controls.Add(buttonLimpiarEst);
            groupBoxEstudiante.Controls.Add(buttonEliminarEst);
            groupBoxEstudiante.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxEstudiante.Location = new Point(10, 10);
            groupBoxEstudiante.Name = "groupBoxEstudiante";
            groupBoxEstudiante.Size = new Size(955, 160);
            groupBoxEstudiante.TabIndex = 0;
            groupBoxEstudiante.TabStop = false;
            groupBoxEstudiante.Text = "Registro de Estudiante";
            // 
            // labelCedulaEst
            // 
            labelCedulaEst.AutoSize = true;
            labelCedulaEst.Font = new Font("Segoe UI", 9F);
            labelCedulaEst.Location = new Point(20, 30);
            labelCedulaEst.Name = "labelCedulaEst";
            labelCedulaEst.Size = new Size(47, 15);
            labelCedulaEst.TabIndex = 0;
            labelCedulaEst.Text = "Cedula:";
            labelCedulaEst.Click += labelCedulaEst_Click;
            // 
            // textBoxCedulaEst
            // 
            textBoxCedulaEst.Font = new Font("Segoe UI", 9F);
            textBoxCedulaEst.Location = new Point(110, 27);
            textBoxCedulaEst.Name = "textBoxCedulaEst";
            textBoxCedulaEst.Size = new Size(170, 23);
            textBoxCedulaEst.TabIndex = 1;
            // 
            // labelNombresEst
            // 
            labelNombresEst.AutoSize = true;
            labelNombresEst.Font = new Font("Segoe UI", 9F);
            labelNombresEst.Location = new Point(20, 62);
            labelNombresEst.Name = "labelNombresEst";
            labelNombresEst.Size = new Size(59, 15);
            labelNombresEst.TabIndex = 2;
            labelNombresEst.Text = "Nombres:";
            // 
            // textBoxNombresEst
            // 
            textBoxNombresEst.Font = new Font("Segoe UI", 9F);
            textBoxNombresEst.Location = new Point(110, 59);
            textBoxNombresEst.Name = "textBoxNombresEst";
            textBoxNombresEst.Size = new Size(170, 23);
            textBoxNombresEst.TabIndex = 3;
            // 
            // labelApellidosEst
            // 
            labelApellidosEst.AutoSize = true;
            labelApellidosEst.Font = new Font("Segoe UI", 9F);
            labelApellidosEst.Location = new Point(20, 94);
            labelApellidosEst.Name = "labelApellidosEst";
            labelApellidosEst.Size = new Size(59, 15);
            labelApellidosEst.TabIndex = 4;
            labelApellidosEst.Text = "Apellidos:";
            // 
            // textBoxApellidosEst
            // 
            textBoxApellidosEst.Font = new Font("Segoe UI", 9F);
            textBoxApellidosEst.Location = new Point(110, 91);
            textBoxApellidosEst.Name = "textBoxApellidosEst";
            textBoxApellidosEst.Size = new Size(170, 23);
            textBoxApellidosEst.TabIndex = 5;
            // 
            // labelCorreoEst
            // 
            labelCorreoEst.AutoSize = true;
            labelCorreoEst.Font = new Font("Segoe UI", 9F);
            labelCorreoEst.Location = new Point(320, 30);
            labelCorreoEst.Name = "labelCorreoEst";
            labelCorreoEst.Size = new Size(46, 15);
            labelCorreoEst.TabIndex = 6;
            labelCorreoEst.Text = "Correo:";
            // 
            // textBoxCorreoEst
            // 
            textBoxCorreoEst.Font = new Font("Segoe UI", 9F);
            textBoxCorreoEst.Location = new Point(400, 27);
            textBoxCorreoEst.Name = "textBoxCorreoEst";
            textBoxCorreoEst.Size = new Size(200, 23);
            textBoxCorreoEst.TabIndex = 7;
            // 
            // labelTelefonoEst
            // 
            labelTelefonoEst.AutoSize = true;
            labelTelefonoEst.Font = new Font("Segoe UI", 9F);
            labelTelefonoEst.Location = new Point(320, 62);
            labelTelefonoEst.Name = "labelTelefonoEst";
            labelTelefonoEst.Size = new Size(56, 15);
            labelTelefonoEst.TabIndex = 8;
            labelTelefonoEst.Text = "Telefono:";
            // 
            // textBoxTelefonoEst
            // 
            textBoxTelefonoEst.Font = new Font("Segoe UI", 9F);
            textBoxTelefonoEst.Location = new Point(400, 59);
            textBoxTelefonoEst.Name = "textBoxTelefonoEst";
            textBoxTelefonoEst.Size = new Size(200, 23);
            textBoxTelefonoEst.TabIndex = 9;
            // 
            // buttonRegistrarEst
            // 
            buttonRegistrarEst.BackColor = Color.FromArgb(0, 122, 204);
            buttonRegistrarEst.FlatStyle = FlatStyle.Flat;
            buttonRegistrarEst.Font = new Font("Segoe UI", 9F);
            buttonRegistrarEst.ForeColor = Color.White;
            buttonRegistrarEst.Location = new Point(660, 25);
            buttonRegistrarEst.Name = "buttonRegistrarEst";
            buttonRegistrarEst.Size = new Size(130, 30);
            buttonRegistrarEst.TabIndex = 10;
            buttonRegistrarEst.Text = "Registrar";
            buttonRegistrarEst.UseVisualStyleBackColor = false;
            buttonRegistrarEst.Click += buttonRegistrarEst_Click;
            // 
            // buttonLimpiarEst
            // 
            buttonLimpiarEst.FlatStyle = FlatStyle.Flat;
            buttonLimpiarEst.Font = new Font("Segoe UI", 9F);
            buttonLimpiarEst.Location = new Point(660, 62);
            buttonLimpiarEst.Name = "buttonLimpiarEst";
            buttonLimpiarEst.Size = new Size(130, 30);
            buttonLimpiarEst.TabIndex = 11;
            buttonLimpiarEst.Text = "Limpiar";
            buttonLimpiarEst.UseVisualStyleBackColor = true;
            buttonLimpiarEst.Click += buttonLimpiarEst_Click;
            // 
            // buttonEliminarEst
            // 
            buttonEliminarEst.BackColor = Color.FromArgb(200, 50, 50);
            buttonEliminarEst.FlatStyle = FlatStyle.Flat;
            buttonEliminarEst.Font = new Font("Segoe UI", 9F);
            buttonEliminarEst.ForeColor = Color.White;
            buttonEliminarEst.Location = new Point(660, 99);
            buttonEliminarEst.Name = "buttonEliminarEst";
            buttonEliminarEst.Size = new Size(130, 30);
            buttonEliminarEst.TabIndex = 12;
            buttonEliminarEst.Text = "Eliminar";
            buttonEliminarEst.UseVisualStyleBackColor = false;
            buttonEliminarEst.Click += buttonEliminarEst_Click;
            // 
            // groupBoxListaEst
            // 
            groupBoxListaEst.Controls.Add(labelBuscarEst);
            groupBoxListaEst.Controls.Add(textBoxBuscarEst);
            groupBoxListaEst.Controls.Add(dataGridViewEstudiantes);
            groupBoxListaEst.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxListaEst.Location = new Point(10, 178);
            groupBoxListaEst.Name = "groupBoxListaEst";
            groupBoxListaEst.Size = new Size(955, 340);
            groupBoxListaEst.TabIndex = 1;
            groupBoxListaEst.TabStop = false;
            groupBoxListaEst.Text = "Lista de Estudiantes";
            // 
            // labelBuscarEst
            // 
            labelBuscarEst.AutoSize = true;
            labelBuscarEst.Font = new Font("Segoe UI", 9F);
            labelBuscarEst.Location = new Point(15, 25);
            labelBuscarEst.Name = "labelBuscarEst";
            labelBuscarEst.Size = new Size(146, 15);
            labelBuscarEst.TabIndex = 0;
            labelBuscarEst.Text = "Buscar (cédula o nombre):";
            // 
            // textBoxBuscarEst
            // 
            textBoxBuscarEst.Font = new Font("Segoe UI", 9F);
            textBoxBuscarEst.Location = new Point(185, 22);
            textBoxBuscarEst.Name = "textBoxBuscarEst";
            textBoxBuscarEst.Size = new Size(300, 23);
            textBoxBuscarEst.TabIndex = 1;
            textBoxBuscarEst.TextChanged += textBoxBuscarEst_TextChanged;
            // 
            // dataGridViewEstudiantes
            // 
            dataGridViewEstudiantes.AllowUserToAddRows = false;
            dataGridViewEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEstudiantes.BackgroundColor = Color.White;
            dataGridViewEstudiantes.Font = new Font("Segoe UI", 9F);
            dataGridViewEstudiantes.Location = new Point(10, 55);
            dataGridViewEstudiantes.MultiSelect = false;
            dataGridViewEstudiantes.Name = "dataGridViewEstudiantes";
            dataGridViewEstudiantes.ReadOnly = true;
            dataGridViewEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEstudiantes.Size = new Size(935, 275);
            dataGridViewEstudiantes.TabIndex = 2;
            // 
            // tabPageTutores
            // 
            tabPageTutores.Controls.Add(groupBoxTutor);
            tabPageTutores.Controls.Add(groupBoxListaTut);
            tabPageTutores.Location = new Point(4, 26);
            tabPageTutores.Name = "tabPageTutores";
            tabPageTutores.Padding = new Padding(3);
            tabPageTutores.Size = new Size(976, 528);
            tabPageTutores.TabIndex = 1;
            tabPageTutores.Text = "  Tutores  ";
            tabPageTutores.UseVisualStyleBackColor = true;
            // 
            // groupBoxTutor
            // 
            groupBoxTutor.Controls.Add(labelCedulaTut);
            groupBoxTutor.Controls.Add(textBoxCedulaTut);
            groupBoxTutor.Controls.Add(labelNombresTut);
            groupBoxTutor.Controls.Add(textBoxNombresTut);
            groupBoxTutor.Controls.Add(labelApellidosTut);
            groupBoxTutor.Controls.Add(textBoxApellidosTut);
            groupBoxTutor.Controls.Add(labelEspecialidad);
            groupBoxTutor.Controls.Add(textBoxEspecialidad);
            groupBoxTutor.Controls.Add(labelCupoMax);
            groupBoxTutor.Controls.Add(numericUpDownCupo);
            groupBoxTutor.Controls.Add(buttonRegistrarTut);
            groupBoxTutor.Controls.Add(buttonLimpiarTut);
            groupBoxTutor.Controls.Add(buttonEliminarTut);
            groupBoxTutor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxTutor.Location = new Point(10, 10);
            groupBoxTutor.Name = "groupBoxTutor";
            groupBoxTutor.Size = new Size(955, 160);
            groupBoxTutor.TabIndex = 0;
            groupBoxTutor.TabStop = false;
            groupBoxTutor.Text = "Registro de Tutor";
            // 
            // labelCedulaTut
            // 
            labelCedulaTut.AutoSize = true;
            labelCedulaTut.Font = new Font("Segoe UI", 9F);
            labelCedulaTut.Location = new Point(20, 30);
            labelCedulaTut.Name = "labelCedulaTut";
            labelCedulaTut.Size = new Size(47, 15);
            labelCedulaTut.TabIndex = 0;
            labelCedulaTut.Text = "Cedula:";
            // 
            // textBoxCedulaTut
            // 
            textBoxCedulaTut.Font = new Font("Segoe UI", 9F);
            textBoxCedulaTut.Location = new Point(120, 27);
            textBoxCedulaTut.Name = "textBoxCedulaTut";
            textBoxCedulaTut.Size = new Size(170, 23);
            textBoxCedulaTut.TabIndex = 1;
            // 
            // labelNombresTut
            // 
            labelNombresTut.AutoSize = true;
            labelNombresTut.Font = new Font("Segoe UI", 9F);
            labelNombresTut.Location = new Point(20, 62);
            labelNombresTut.Name = "labelNombresTut";
            labelNombresTut.Size = new Size(59, 15);
            labelNombresTut.TabIndex = 2;
            labelNombresTut.Text = "Nombres:";
            // 
            // textBoxNombresTut
            // 
            textBoxNombresTut.Font = new Font("Segoe UI", 9F);
            textBoxNombresTut.Location = new Point(120, 59);
            textBoxNombresTut.Name = "textBoxNombresTut";
            textBoxNombresTut.Size = new Size(170, 23);
            textBoxNombresTut.TabIndex = 3;
            // 
            // labelApellidosTut
            // 
            labelApellidosTut.AutoSize = true;
            labelApellidosTut.Font = new Font("Segoe UI", 9F);
            labelApellidosTut.Location = new Point(20, 94);
            labelApellidosTut.Name = "labelApellidosTut";
            labelApellidosTut.Size = new Size(59, 15);
            labelApellidosTut.TabIndex = 4;
            labelApellidosTut.Text = "Apellidos:";
            // 
            // textBoxApellidosTut
            // 
            textBoxApellidosTut.Font = new Font("Segoe UI", 9F);
            textBoxApellidosTut.Location = new Point(120, 91);
            textBoxApellidosTut.Name = "textBoxApellidosTut";
            textBoxApellidosTut.Size = new Size(170, 23);
            textBoxApellidosTut.TabIndex = 5;
            // 
            // labelEspecialidad
            // 
            labelEspecialidad.AutoSize = true;
            labelEspecialidad.Font = new Font("Segoe UI", 9F);
            labelEspecialidad.Location = new Point(330, 30);
            labelEspecialidad.Name = "labelEspecialidad";
            labelEspecialidad.Size = new Size(75, 15);
            labelEspecialidad.TabIndex = 6;
            labelEspecialidad.Text = "Especialidad:";
            // 
            // textBoxEspecialidad
            // 
            textBoxEspecialidad.Font = new Font("Segoe UI", 9F);
            textBoxEspecialidad.Location = new Point(430, 27);
            textBoxEspecialidad.Name = "textBoxEspecialidad";
            textBoxEspecialidad.Size = new Size(200, 23);
            textBoxEspecialidad.TabIndex = 7;
            // 
            // labelCupoMax
            // 
            labelCupoMax.AutoSize = true;
            labelCupoMax.Font = new Font("Segoe UI", 9F);
            labelCupoMax.Location = new Point(330, 62);
            labelCupoMax.Name = "labelCupoMax";
            labelCupoMax.Size = new Size(85, 15);
            labelCupoMax.TabIndex = 8;
            labelCupoMax.Text = "Cupo Maximo:";
            // 
            // numericUpDownCupo
            // 
            numericUpDownCupo.Font = new Font("Segoe UI", 9F);
            numericUpDownCupo.Location = new Point(430, 59);
            numericUpDownCupo.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownCupo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCupo.Name = "numericUpDownCupo";
            numericUpDownCupo.Size = new Size(80, 23);
            numericUpDownCupo.TabIndex = 9;
            numericUpDownCupo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // buttonRegistrarTut
            // 
            buttonRegistrarTut.BackColor = Color.FromArgb(0, 122, 204);
            buttonRegistrarTut.FlatStyle = FlatStyle.Flat;
            buttonRegistrarTut.Font = new Font("Segoe UI", 9F);
            buttonRegistrarTut.ForeColor = Color.White;
            buttonRegistrarTut.Location = new Point(700, 25);
            buttonRegistrarTut.Name = "buttonRegistrarTut";
            buttonRegistrarTut.Size = new Size(130, 30);
            buttonRegistrarTut.TabIndex = 10;
            buttonRegistrarTut.Text = "Registrar";
            buttonRegistrarTut.UseVisualStyleBackColor = false;
            buttonRegistrarTut.Click += buttonRegistrarTut_Click;
            // 
            // buttonLimpiarTut
            // 
            buttonLimpiarTut.FlatStyle = FlatStyle.Flat;
            buttonLimpiarTut.Font = new Font("Segoe UI", 9F);
            buttonLimpiarTut.Location = new Point(700, 62);
            buttonLimpiarTut.Name = "buttonLimpiarTut";
            buttonLimpiarTut.Size = new Size(130, 30);
            buttonLimpiarTut.TabIndex = 11;
            buttonLimpiarTut.Text = "Limpiar";
            buttonLimpiarTut.Click += buttonLimpiarTut_Click;
            // 
            // buttonEliminarTut
            // 
            buttonEliminarTut.BackColor = Color.FromArgb(200, 50, 50);
            buttonEliminarTut.FlatStyle = FlatStyle.Flat;
            buttonEliminarTut.Font = new Font("Segoe UI", 9F);
            buttonEliminarTut.ForeColor = Color.White;
            buttonEliminarTut.Location = new Point(700, 99);
            buttonEliminarTut.Name = "buttonEliminarTut";
            buttonEliminarTut.Size = new Size(130, 30);
            buttonEliminarTut.TabIndex = 12;
            buttonEliminarTut.Text = "Eliminar";
            buttonEliminarTut.UseVisualStyleBackColor = false;
            buttonEliminarTut.Click += buttonEliminarTut_Click;
            // 
            // groupBoxListaTut
            // 
            groupBoxListaTut.Controls.Add(dataGridViewTutores);
            groupBoxListaTut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxListaTut.Location = new Point(10, 178);
            groupBoxListaTut.Name = "groupBoxListaTut";
            groupBoxListaTut.Size = new Size(955, 340);
            groupBoxListaTut.TabIndex = 1;
            groupBoxListaTut.TabStop = false;
            groupBoxListaTut.Text = "Lista de Tutores";
            // 
            // dataGridViewTutores
            // 
            dataGridViewTutores.AllowUserToAddRows = false;
            dataGridViewTutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTutores.BackgroundColor = Color.White;
            dataGridViewTutores.Font = new Font("Segoe UI", 9F);
            dataGridViewTutores.Location = new Point(10, 25);
            dataGridViewTutores.MultiSelect = false;
            dataGridViewTutores.Name = "dataGridViewTutores";
            dataGridViewTutores.ReadOnly = true;
            dataGridViewTutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTutores.Size = new Size(935, 305);
            dataGridViewTutores.TabIndex = 0;
            // 
            // tabPageHorarios
            // 
            tabPageHorarios.Controls.Add(groupBoxHorario);
            tabPageHorarios.Controls.Add(groupBoxListaHor);
            tabPageHorarios.Location = new Point(4, 26);
            tabPageHorarios.Name = "tabPageHorarios";
            tabPageHorarios.Padding = new Padding(3);
            tabPageHorarios.Size = new Size(976, 528);
            tabPageHorarios.TabIndex = 2;
            tabPageHorarios.Text = "  Horarios  ";
            tabPageHorarios.UseVisualStyleBackColor = true;
            // 
            // groupBoxHorario
            // 
            groupBoxHorario.Controls.Add(labelDia);
            groupBoxHorario.Controls.Add(comboBoxDia);
            groupBoxHorario.Controls.Add(labelHora);
            groupBoxHorario.Controls.Add(comboBoxHora);
            groupBoxHorario.Controls.Add(labelAula);
            groupBoxHorario.Controls.Add(textBoxAula);
            groupBoxHorario.Controls.Add(labelTutorHor);
            groupBoxHorario.Controls.Add(comboBoxTutorHor);
            groupBoxHorario.Controls.Add(buttonRegistrarHor);
            groupBoxHorario.Controls.Add(buttonLimpiarHor);
            groupBoxHorario.Controls.Add(buttonEliminarHor);
            groupBoxHorario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxHorario.Location = new Point(10, 10);
            groupBoxHorario.Name = "groupBoxHorario";
            groupBoxHorario.Size = new Size(955, 130);
            groupBoxHorario.TabIndex = 0;
            groupBoxHorario.TabStop = false;
            groupBoxHorario.Text = "Registro de Horario";
            // 
            // labelDia
            // 
            labelDia.AutoSize = true;
            labelDia.Font = new Font("Segoe UI", 9F);
            labelDia.Location = new Point(20, 35);
            labelDia.Name = "labelDia";
            labelDia.Size = new Size(27, 15);
            labelDia.TabIndex = 0;
            labelDia.Text = "Día:";
            // 
            // comboBoxDia
            // 
            comboBoxDia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDia.Font = new Font("Segoe UI", 9F);
            comboBoxDia.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" });
            comboBoxDia.Location = new Point(100, 32);
            comboBoxDia.Name = "comboBoxDia";
            comboBoxDia.Size = new Size(150, 23);
            comboBoxDia.TabIndex = 1;
            // 
            // labelHora
            // 
            labelHora.AutoSize = true;
            labelHora.Font = new Font("Segoe UI", 9F);
            labelHora.Location = new Point(20, 72);
            labelHora.Name = "labelHora";
            labelHora.Size = new Size(36, 15);
            labelHora.TabIndex = 2;
            labelHora.Text = "Hora:";
            // 
            // comboBoxHora
            // 
            comboBoxHora.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHora.Font = new Font("Segoe UI", 9F);
            comboBoxHora.Items.AddRange(new object[] { "07:00 - 08:00", "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00" });
            comboBoxHora.Location = new Point(100, 69);
            comboBoxHora.Name = "comboBoxHora";
            comboBoxHora.Size = new Size(150, 23);
            comboBoxHora.TabIndex = 3;
            // 
            // labelAula
            // 
            labelAula.AutoSize = true;
            labelAula.Font = new Font("Segoe UI", 9F);
            labelAula.Location = new Point(300, 35);
            labelAula.Name = "labelAula";
            labelAula.Size = new Size(34, 15);
            labelAula.TabIndex = 4;
            labelAula.Text = "Aula:";
            // 
            // textBoxAula
            // 
            textBoxAula.Font = new Font("Segoe UI", 9F);
            textBoxAula.Location = new Point(380, 32);
            textBoxAula.Name = "textBoxAula";
            textBoxAula.Size = new Size(120, 23);
            textBoxAula.TabIndex = 5;
            // 
            // labelTutorHor
            // 
            labelTutorHor.AutoSize = true;
            labelTutorHor.Font = new Font("Segoe UI", 9F);
            labelTutorHor.Location = new Point(300, 72);
            labelTutorHor.Name = "labelTutorHor";
            labelTutorHor.Size = new Size(39, 15);
            labelTutorHor.TabIndex = 6;
            labelTutorHor.Text = "Tutor:";
            // 
            // comboBoxTutorHor
            // 
            comboBoxTutorHor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTutorHor.Font = new Font("Segoe UI", 9F);
            comboBoxTutorHor.Location = new Point(380, 69);
            comboBoxTutorHor.Name = "comboBoxTutorHor";
            comboBoxTutorHor.Size = new Size(250, 23);
            comboBoxTutorHor.TabIndex = 7;
            // 
            // buttonRegistrarHor
            // 
            buttonRegistrarHor.BackColor = Color.FromArgb(0, 122, 204);
            buttonRegistrarHor.FlatStyle = FlatStyle.Flat;
            buttonRegistrarHor.Font = new Font("Segoe UI", 9F);
            buttonRegistrarHor.ForeColor = Color.White;
            buttonRegistrarHor.Location = new Point(700, 28);
            buttonRegistrarHor.Name = "buttonRegistrarHor";
            buttonRegistrarHor.Size = new Size(130, 30);
            buttonRegistrarHor.TabIndex = 8;
            buttonRegistrarHor.Text = "Registrar";
            buttonRegistrarHor.UseVisualStyleBackColor = false;
            buttonRegistrarHor.Click += buttonRegistrarHor_Click;
            // 
            // buttonLimpiarHor
            // 
            buttonLimpiarHor.FlatStyle = FlatStyle.Flat;
            buttonLimpiarHor.Font = new Font("Segoe UI", 9F);
            buttonLimpiarHor.Location = new Point(700, 65);
            buttonLimpiarHor.Name = "buttonLimpiarHor";
            buttonLimpiarHor.Size = new Size(130, 30);
            buttonLimpiarHor.TabIndex = 9;
            buttonLimpiarHor.Text = "Limpiar";
            buttonLimpiarHor.Click += buttonLimpiarHor_Click;
            // 
            // buttonEliminarHor
            // 
            buttonEliminarHor.BackColor = Color.FromArgb(200, 50, 50);
            buttonEliminarHor.FlatStyle = FlatStyle.Flat;
            buttonEliminarHor.Font = new Font("Segoe UI", 9F);
            buttonEliminarHor.ForeColor = Color.White;
            buttonEliminarHor.Location = new Point(850, 28);
            buttonEliminarHor.Name = "buttonEliminarHor";
            buttonEliminarHor.Size = new Size(90, 30);
            buttonEliminarHor.TabIndex = 10;
            buttonEliminarHor.Text = "Eliminar";
            buttonEliminarHor.UseVisualStyleBackColor = false;
            buttonEliminarHor.Click += buttonEliminarHor_Click;
            // 
            // groupBoxListaHor
            // 
            groupBoxListaHor.Controls.Add(dataGridViewHorarios);
            groupBoxListaHor.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxListaHor.Location = new Point(10, 148);
            groupBoxListaHor.Name = "groupBoxListaHor";
            groupBoxListaHor.Size = new Size(955, 370);
            groupBoxListaHor.TabIndex = 1;
            groupBoxListaHor.TabStop = false;
            groupBoxListaHor.Text = "Lista de Horarios";
            // 
            // dataGridViewHorarios
            // 
            dataGridViewHorarios.AllowUserToAddRows = false;
            dataGridViewHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHorarios.BackgroundColor = Color.White;
            dataGridViewHorarios.Font = new Font("Segoe UI", 9F);
            dataGridViewHorarios.Location = new Point(10, 25);
            dataGridViewHorarios.MultiSelect = false;
            dataGridViewHorarios.Name = "dataGridViewHorarios";
            dataGridViewHorarios.ReadOnly = true;
            dataGridViewHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHorarios.Size = new Size(935, 335);
            dataGridViewHorarios.TabIndex = 0;
            // 
            // tabPageInscripciones
            // 
            tabPageInscripciones.Controls.Add(groupBoxInscripcion);
            tabPageInscripciones.Controls.Add(groupBoxResumen);
            tabPageInscripciones.Controls.Add(groupBoxListaInsc);
            tabPageInscripciones.Location = new Point(4, 26);
            tabPageInscripciones.Name = "tabPageInscripciones";
            tabPageInscripciones.Padding = new Padding(3);
            tabPageInscripciones.Size = new Size(976, 528);
            tabPageInscripciones.TabIndex = 3;
            tabPageInscripciones.Text = "  Inscripciones  ";
            tabPageInscripciones.UseVisualStyleBackColor = true;
            // 
            // groupBoxInscripcion
            // 
            groupBoxInscripcion.Controls.Add(labelEstudianteInsc);
            groupBoxInscripcion.Controls.Add(comboBoxEstudianteInsc);
            groupBoxInscripcion.Controls.Add(labelTutorInsc);
            groupBoxInscripcion.Controls.Add(comboBoxTutorInsc);
            groupBoxInscripcion.Controls.Add(labelHorarioInsc);
            groupBoxInscripcion.Controls.Add(comboBoxHorarioInsc);
            groupBoxInscripcion.Controls.Add(buttonInscribir);
            groupBoxInscripcion.Controls.Add(buttonEliminarInsc);
            groupBoxInscripcion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxInscripcion.Location = new Point(10, 10);
            groupBoxInscripcion.Name = "groupBoxInscripcion";
            groupBoxInscripcion.Size = new Size(620, 130);
            groupBoxInscripcion.TabIndex = 0;
            groupBoxInscripcion.TabStop = false;
            groupBoxInscripcion.Text = "Nueva Inscripcion";
            // 
            // labelEstudianteInsc
            // 
            labelEstudianteInsc.AutoSize = true;
            labelEstudianteInsc.Font = new Font("Segoe UI", 9F);
            labelEstudianteInsc.Location = new Point(15, 30);
            labelEstudianteInsc.Name = "labelEstudianteInsc";
            labelEstudianteInsc.Size = new Size(65, 15);
            labelEstudianteInsc.TabIndex = 0;
            labelEstudianteInsc.Text = "Estudiante:";
            // 
            // comboBoxEstudianteInsc
            // 
            comboBoxEstudianteInsc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstudianteInsc.Font = new Font("Segoe UI", 9F);
            comboBoxEstudianteInsc.Location = new Point(105, 27);
            comboBoxEstudianteInsc.Name = "comboBoxEstudianteInsc";
            comboBoxEstudianteInsc.Size = new Size(280, 23);
            comboBoxEstudianteInsc.TabIndex = 1;
            // 
            // labelTutorInsc
            // 
            labelTutorInsc.AutoSize = true;
            labelTutorInsc.Font = new Font("Segoe UI", 9F);
            labelTutorInsc.Location = new Point(15, 62);
            labelTutorInsc.Name = "labelTutorInsc";
            labelTutorInsc.Size = new Size(39, 15);
            labelTutorInsc.TabIndex = 2;
            labelTutorInsc.Text = "Tutor:";
            // 
            // comboBoxTutorInsc
            // 
            comboBoxTutorInsc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTutorInsc.Font = new Font("Segoe UI", 9F);
            comboBoxTutorInsc.Location = new Point(105, 59);
            comboBoxTutorInsc.Name = "comboBoxTutorInsc";
            comboBoxTutorInsc.Size = new Size(280, 23);
            comboBoxTutorInsc.TabIndex = 3;
            comboBoxTutorInsc.SelectedIndexChanged += comboBoxTutorInsc_SelectedIndexChanged;
            // 
            // labelHorarioInsc
            // 
            labelHorarioInsc.AutoSize = true;
            labelHorarioInsc.Font = new Font("Segoe UI", 9F);
            labelHorarioInsc.Location = new Point(15, 94);
            labelHorarioInsc.Name = "labelHorarioInsc";
            labelHorarioInsc.Size = new Size(50, 15);
            labelHorarioInsc.TabIndex = 4;
            labelHorarioInsc.Text = "Horario:";
            // 
            // comboBoxHorarioInsc
            // 
            comboBoxHorarioInsc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHorarioInsc.Font = new Font("Segoe UI", 9F);
            comboBoxHorarioInsc.Location = new Point(105, 91);
            comboBoxHorarioInsc.Name = "comboBoxHorarioInsc";
            comboBoxHorarioInsc.Size = new Size(280, 23);
            comboBoxHorarioInsc.TabIndex = 5;
            // 
            // buttonInscribir
            // 
            buttonInscribir.BackColor = Color.FromArgb(40, 167, 69);
            buttonInscribir.FlatStyle = FlatStyle.Flat;
            buttonInscribir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonInscribir.ForeColor = Color.White;
            buttonInscribir.Location = new Point(420, 25);
            buttonInscribir.Name = "buttonInscribir";
            buttonInscribir.Size = new Size(170, 35);
            buttonInscribir.TabIndex = 6;
            buttonInscribir.Text = "Inscribir Estudiante";
            buttonInscribir.UseVisualStyleBackColor = false;
            buttonInscribir.Click += buttonInscribir_Click;
            // 
            // buttonEliminarInsc
            // 
            buttonEliminarInsc.BackColor = Color.FromArgb(200, 50, 50);
            buttonEliminarInsc.FlatStyle = FlatStyle.Flat;
            buttonEliminarInsc.Font = new Font("Segoe UI", 9F);
            buttonEliminarInsc.ForeColor = Color.White;
            buttonEliminarInsc.Location = new Point(420, 70);
            buttonEliminarInsc.Name = "buttonEliminarInsc";
            buttonEliminarInsc.Size = new Size(170, 30);
            buttonEliminarInsc.TabIndex = 7;
            buttonEliminarInsc.Text = "Eliminar Inscripcion";
            buttonEliminarInsc.UseVisualStyleBackColor = false;
            buttonEliminarInsc.Click += buttonEliminarInsc_Click;
            // 
            // groupBoxResumen
            // 
            groupBoxResumen.Controls.Add(labelCuposOcupados);
            groupBoxResumen.Controls.Add(labelCuposDisponibles);
            groupBoxResumen.Controls.Add(labelTotalInscritos);
            groupBoxResumen.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxResumen.ForeColor = Color.FromArgb(0, 122, 204);
            groupBoxResumen.Location = new Point(640, 10);
            groupBoxResumen.Name = "groupBoxResumen";
            groupBoxResumen.Size = new Size(325, 130);
            groupBoxResumen.TabIndex = 1;
            groupBoxResumen.TabStop = false;
            groupBoxResumen.Text = "Resumen de Cupos";
            // 
            // labelCuposOcupados
            // 
            labelCuposOcupados.AutoSize = true;
            labelCuposOcupados.Font = new Font("Segoe UI", 11F);
            labelCuposOcupados.ForeColor = Color.FromArgb(200, 50, 50);
            labelCuposOcupados.Location = new Point(15, 35);
            labelCuposOcupados.Name = "labelCuposOcupados";
            labelCuposOcupados.Size = new Size(136, 20);
            labelCuposOcupados.TabIndex = 0;
            labelCuposOcupados.Text = "Cupos Ocupados: 0";
            // 
            // labelCuposDisponibles
            // 
            labelCuposDisponibles.AutoSize = true;
            labelCuposDisponibles.Font = new Font("Segoe UI", 11F);
            labelCuposDisponibles.ForeColor = Color.FromArgb(40, 167, 69);
            labelCuposDisponibles.Location = new Point(15, 65);
            labelCuposDisponibles.Name = "labelCuposDisponibles";
            labelCuposDisponibles.Size = new Size(147, 20);
            labelCuposDisponibles.TabIndex = 1;
            labelCuposDisponibles.Text = "Cupos Disponibles: 0";
            // 
            // labelTotalInscritos
            // 
            labelTotalInscritos.AutoSize = true;
            labelTotalInscritos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalInscritos.ForeColor = Color.Black;
            labelTotalInscritos.Location = new Point(15, 95);
            labelTotalInscritos.Name = "labelTotalInscritos";
            labelTotalInscritos.Size = new Size(125, 20);
            labelTotalInscritos.TabIndex = 2;
            labelTotalInscritos.Text = "Total Inscritos: 0";
            // 
            // groupBoxListaInsc
            // 
            groupBoxListaInsc.Controls.Add(labelFiltrarTutor);
            groupBoxListaInsc.Controls.Add(comboBoxFiltrarTutor);
            groupBoxListaInsc.Controls.Add(labelFiltrarHorario);
            groupBoxListaInsc.Controls.Add(comboBoxFiltrarHorario);
            groupBoxListaInsc.Controls.Add(buttonFiltrar);
            groupBoxListaInsc.Controls.Add(buttonMostrarTodos);
            groupBoxListaInsc.Controls.Add(dataGridViewInscripciones);
            groupBoxListaInsc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupBoxListaInsc.Location = new Point(10, 148);
            groupBoxListaInsc.Name = "groupBoxListaInsc";
            groupBoxListaInsc.Size = new Size(955, 370);
            groupBoxListaInsc.TabIndex = 2;
            groupBoxListaInsc.TabStop = false;
            groupBoxListaInsc.Text = "Inscripciones Registradas";
            // 
            // labelFiltrarTutor
            // 
            labelFiltrarTutor.AutoSize = true;
            labelFiltrarTutor.Font = new Font("Segoe UI", 9F);
            labelFiltrarTutor.Location = new Point(10, 28);
            labelFiltrarTutor.Name = "labelFiltrarTutor";
            labelFiltrarTutor.Size = new Size(93, 15);
            labelFiltrarTutor.TabIndex = 0;
            labelFiltrarTutor.Text = "Filtrar por Tutor:";
            // 
            // comboBoxFiltrarTutor
            // 
            comboBoxFiltrarTutor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltrarTutor.Font = new Font("Segoe UI", 9F);
            comboBoxFiltrarTutor.Location = new Point(120, 25);
            comboBoxFiltrarTutor.Name = "comboBoxFiltrarTutor";
            comboBoxFiltrarTutor.Size = new Size(220, 23);
            comboBoxFiltrarTutor.TabIndex = 1;
            // 
            // labelFiltrarHorario
            // 
            labelFiltrarHorario.AutoSize = true;
            labelFiltrarHorario.Font = new Font("Segoe UI", 9F);
            labelFiltrarHorario.Location = new Point(360, 28);
            labelFiltrarHorario.Name = "labelFiltrarHorario";
            labelFiltrarHorario.Size = new Size(104, 15);
            labelFiltrarHorario.TabIndex = 2;
            labelFiltrarHorario.Text = "Filtrar por Horario:";
            // 
            // comboBoxFiltrarHorario
            // 
            comboBoxFiltrarHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltrarHorario.Font = new Font("Segoe UI", 9F);
            comboBoxFiltrarHorario.Location = new Point(480, 25);
            comboBoxFiltrarHorario.Name = "comboBoxFiltrarHorario";
            comboBoxFiltrarHorario.Size = new Size(220, 23);
            comboBoxFiltrarHorario.TabIndex = 3;
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.BackColor = Color.FromArgb(0, 122, 204);
            buttonFiltrar.FlatStyle = FlatStyle.Flat;
            buttonFiltrar.Font = new Font("Segoe UI", 9F);
            buttonFiltrar.ForeColor = Color.White;
            buttonFiltrar.Location = new Point(720, 22);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(100, 28);
            buttonFiltrar.TabIndex = 4;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = false;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // buttonMostrarTodos
            // 
            buttonMostrarTodos.FlatStyle = FlatStyle.Flat;
            buttonMostrarTodos.Font = new Font("Segoe UI", 9F);
            buttonMostrarTodos.Location = new Point(830, 22);
            buttonMostrarTodos.Name = "buttonMostrarTodos";
            buttonMostrarTodos.Size = new Size(110, 28);
            buttonMostrarTodos.TabIndex = 5;
            buttonMostrarTodos.Text = "Mostrar Todos";
            buttonMostrarTodos.Click += buttonMostrarTodos_Click;
            // 
            // dataGridViewInscripciones
            // 
            dataGridViewInscripciones.AllowUserToAddRows = false;
            dataGridViewInscripciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInscripciones.BackgroundColor = Color.White;
            dataGridViewInscripciones.Font = new Font("Segoe UI", 9F);
            dataGridViewInscripciones.Location = new Point(10, 58);
            dataGridViewInscripciones.MultiSelect = false;
            dataGridViewInscripciones.Name = "dataGridViewInscripciones";
            dataGridViewInscripciones.ReadOnly = true;
            dataGridViewInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInscripciones.Size = new Size(935, 302);
            dataGridViewInscripciones.TabIndex = 6;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(45, 45, 48);
            panelTitulo.Controls.Add(labelTitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(984, 50);
            panelTitulo.TabIndex = 2;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(280, 8);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(522, 32);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Sistema de Control de Estudiantes y Tutorías";
            // 
            // panelLinea
            // 
            panelLinea.BackColor = Color.FromArgb(0, 122, 204);
            panelLinea.Dock = DockStyle.Top;
            panelLinea.Location = new Point(0, 50);
            panelLinea.Name = "panelLinea";
            panelLinea.Size = new Size(984, 3);
            panelLinea.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(tabControl1);
            Controls.Add(panelLinea);
            Controls.Add(panelTitulo);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de Estudiantes y Tutorías";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPageEstudiantes.ResumeLayout(false);
            groupBoxEstudiante.ResumeLayout(false);
            groupBoxEstudiante.PerformLayout();
            groupBoxListaEst.ResumeLayout(false);
            groupBoxListaEst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEstudiantes).EndInit();
            tabPageTutores.ResumeLayout(false);
            groupBoxTutor.ResumeLayout(false);
            groupBoxTutor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCupo).EndInit();
            groupBoxListaTut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTutores).EndInit();
            tabPageHorarios.ResumeLayout(false);
            groupBoxHorario.ResumeLayout(false);
            groupBoxHorario.PerformLayout();
            groupBoxListaHor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHorarios).EndInit();
            tabPageInscripciones.ResumeLayout(false);
            groupBoxInscripcion.ResumeLayout(false);
            groupBoxInscripcion.PerformLayout();
            groupBoxResumen.ResumeLayout(false);
            groupBoxResumen.PerformLayout();
            groupBoxListaInsc.ResumeLayout(false);
            groupBoxListaInsc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInscripciones).EndInit();
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Titulo
        private Panel panelTitulo;
        private Label labelTitulo;
        private Panel panelLinea;

        // TabControl
        private TabControl tabControl1;
        private TabPage tabPageEstudiantes;
        private TabPage tabPageTutores;
        private TabPage tabPageHorarios;
        private TabPage tabPageInscripciones;

        // Tab Estudiantes
        private GroupBox groupBoxEstudiante;
        private Label labelCedulaEst;
        private TextBox textBoxCedulaEst;
        private Label labelNombresEst;
        private TextBox textBoxNombresEst;
        private Label labelApellidosEst;
        private TextBox textBoxApellidosEst;
        private Label labelCorreoEst;
        private TextBox textBoxCorreoEst;
        private Label labelTelefonoEst;
        private TextBox textBoxTelefonoEst;
        private Button buttonRegistrarEst;
        private Button buttonLimpiarEst;
        private Button buttonEliminarEst;
        private GroupBox groupBoxListaEst;
        private Label labelBuscarEst;
        private TextBox textBoxBuscarEst;
        private DataGridView dataGridViewEstudiantes;

        // Tab Tutores
        private GroupBox groupBoxTutor;
        private Label labelCedulaTut;
        private TextBox textBoxCedulaTut;
        private Label labelNombresTut;
        private TextBox textBoxNombresTut;
        private Label labelApellidosTut;
        private TextBox textBoxApellidosTut;
        private Label labelEspecialidad;
        private TextBox textBoxEspecialidad;
        private Label labelCupoMax;
        private NumericUpDown numericUpDownCupo;
        private Button buttonRegistrarTut;
        private Button buttonLimpiarTut;
        private Button buttonEliminarTut;
        private GroupBox groupBoxListaTut;
        private DataGridView dataGridViewTutores;

        // Tab Horarios
        private GroupBox groupBoxHorario;
        private Label labelDia;
        private ComboBox comboBoxDia;
        private Label labelHora;
        private ComboBox comboBoxHora;
        private Label labelAula;
        private TextBox textBoxAula;
        private Label labelTutorHor;
        private ComboBox comboBoxTutorHor;
        private Button buttonRegistrarHor;
        private Button buttonLimpiarHor;
        private Button buttonEliminarHor;
        private GroupBox groupBoxListaHor;
        private DataGridView dataGridViewHorarios;

        // Tab Inscripciones
        private GroupBox groupBoxInscripcion;
        private Label labelEstudianteInsc;
        private ComboBox comboBoxEstudianteInsc;
        private Label labelTutorInsc;
        private ComboBox comboBoxTutorInsc;
        private Label labelHorarioInsc;
        private ComboBox comboBoxHorarioInsc;
        private Button buttonInscribir;
        private Button buttonEliminarInsc;
        private GroupBox groupBoxResumen;
        private Label labelCuposOcupados;
        private Label labelCuposDisponibles;
        private Label labelTotalInscritos;
        private GroupBox groupBoxListaInsc;
        private Label labelFiltrarTutor;
        private ComboBox comboBoxFiltrarTutor;
        private Label labelFiltrarHorario;
        private ComboBox comboBoxFiltrarHorario;
        private Button buttonFiltrar;
        private Button buttonMostrarTodos;
        private DataGridView dataGridViewInscripciones;
    }
}
