namespace PredictorTarifa.Vista
{
    partial class FormularioPrincipal
    {
        // Necesario para el Disenador de formularios de Windows Forms
        private System.ComponentModel.IContainer components = null;

        // Liberar los recursos que se esten usando
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // ================================================================
        // METODO GENERADO POR EL DISENADOR - NO MODIFICAR MANUALMENTE
        // ================================================================
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            panelEncabezado = new System.Windows.Forms.Panel();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            panelIzquierdo = new System.Windows.Forms.Panel();
            panelResultado = new System.Windows.Forms.Panel();
            lblMensajeGuardado = new System.Windows.Forms.Label();
            lblTarifaPredicha = new System.Windows.Forms.Label();
            lblResultadoTitulo = new System.Windows.Forms.Label();
            grupoPrediccion = new System.Windows.Forms.GroupBox();
            btnPredecir = new System.Windows.Forms.Button();
            cmbTipoPago = new System.Windows.Forms.ComboBox();
            lblTipoPago = new System.Windows.Forms.Label();
            numDuracion = new System.Windows.Forms.NumericUpDown();
            lblDuracion = new System.Windows.Forms.Label();
            numDistancia = new System.Windows.Forms.NumericUpDown();
            lblDistancia = new System.Windows.Forms.Label();
            numPasajeros = new System.Windows.Forms.NumericUpDown();
            lblPasajeros = new System.Windows.Forms.Label();
            cmbEmpresa = new System.Windows.Forms.ComboBox();
            lblEmpresa = new System.Windows.Forms.Label();
            grupoEntrenamiento = new System.Windows.Forms.GroupBox();
            lblEstadoModelo = new System.Windows.Forms.Label();
            barraProgreso = new System.Windows.Forms.ProgressBar();
            btnEntrenar = new System.Windows.Forms.Button();
            panelDerecho = new System.Windows.Forms.Panel();
            grupoHistorial = new System.Windows.Forms.GroupBox();
            gridHistorial = new System.Windows.Forms.DataGridView();
            panelBotonesHistorial = new System.Windows.Forms.Panel();
            lblTotalViajes = new System.Windows.Forms.Label();
            btnRefrescarHistorial = new System.Windows.Forms.Button();
            barraEstado = new System.Windows.Forms.StatusStrip();
            lblEstadoConexion = new System.Windows.Forms.ToolStripStatusLabel();
            panelEncabezado.SuspendLayout();
            panelIzquierdo.SuspendLayout();
            panelResultado.SuspendLayout();
            grupoPrediccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDistancia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPasajeros).BeginInit();
            grupoEntrenamiento.SuspendLayout();
            panelDerecho.SuspendLayout();
            grupoHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistorial).BeginInit();
            panelBotonesHistorial.SuspendLayout();
            barraEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panelEncabezado
            // 
            panelEncabezado.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            panelEncabezado.Controls.Add(lblSubtitulo);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            panelEncabezado.Location = new System.Drawing.Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new System.Drawing.Size(1020, 90);
            panelEncabezado.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(191, 219, 254);
            lblSubtitulo.Location = new System.Drawing.Point(22, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(413, 15);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Sistema inteligente con ML.NET y Entity Framework Core | SQL Server Express";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(324, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Predictor de Tarifas de Taxi";
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.Controls.Add(panelResultado);
            panelIzquierdo.Controls.Add(grupoPrediccion);
            panelIzquierdo.Controls.Add(grupoEntrenamiento);
            panelIzquierdo.Location = new System.Drawing.Point(12, 100);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Size = new System.Drawing.Size(408, 620);
            panelIzquierdo.TabIndex = 1;
            // 
            // panelResultado
            // 
            panelResultado.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            panelResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelResultado.Controls.Add(lblMensajeGuardado);
            panelResultado.Controls.Add(lblTarifaPredicha);
            panelResultado.Controls.Add(lblResultadoTitulo);
            panelResultado.Location = new System.Drawing.Point(0, 425);
            panelResultado.Name = "panelResultado";
            panelResultado.Size = new System.Drawing.Size(408, 125);
            panelResultado.TabIndex = 2;
            // 
            // lblMensajeGuardado
            // 
            lblMensajeGuardado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensajeGuardado.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblMensajeGuardado.Location = new System.Drawing.Point(10, 92);
            lblMensajeGuardado.Name = "lblMensajeGuardado";
            lblMensajeGuardado.Size = new System.Drawing.Size(385, 25);
            lblMensajeGuardado.TabIndex = 0;
            lblMensajeGuardado.Text = "Ingrese los datos y haga clic en Predecir.";
            // 
            // lblTarifaPredicha
            // 
            lblTarifaPredicha.AutoSize = true;
            lblTarifaPredicha.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            lblTarifaPredicha.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            lblTarifaPredicha.Location = new System.Drawing.Point(8, 28);
            lblTarifaPredicha.Name = "lblTarifaPredicha";
            lblTarifaPredicha.Size = new System.Drawing.Size(113, 59);
            lblTarifaPredicha.TabIndex = 1;
            lblTarifaPredicha.Text = "$ ---";
            // 
            // lblResultadoTitulo
            // 
            lblResultadoTitulo.AutoSize = true;
            lblResultadoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblResultadoTitulo.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            lblResultadoTitulo.Location = new System.Drawing.Point(10, 10);
            lblResultadoTitulo.Name = "lblResultadoTitulo";
            lblResultadoTitulo.Size = new System.Drawing.Size(182, 15);
            lblResultadoTitulo.TabIndex = 2;
            lblResultadoTitulo.Text = "RESULTADO DE LA PREDICCION";
            // 
            // grupoPrediccion
            // 
            grupoPrediccion.BackColor = System.Drawing.Color.White;
            grupoPrediccion.Controls.Add(btnPredecir);
            grupoPrediccion.Controls.Add(cmbTipoPago);
            grupoPrediccion.Controls.Add(lblTipoPago);
            grupoPrediccion.Controls.Add(numDuracion);
            grupoPrediccion.Controls.Add(lblDuracion);
            grupoPrediccion.Controls.Add(numDistancia);
            grupoPrediccion.Controls.Add(lblDistancia);
            grupoPrediccion.Controls.Add(numPasajeros);
            grupoPrediccion.Controls.Add(lblPasajeros);
            grupoPrediccion.Controls.Add(cmbEmpresa);
            grupoPrediccion.Controls.Add(lblEmpresa);
            grupoPrediccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grupoPrediccion.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            grupoPrediccion.Location = new System.Drawing.Point(0, 138);
            grupoPrediccion.Name = "grupoPrediccion";
            grupoPrediccion.Padding = new System.Windows.Forms.Padding(8);
            grupoPrediccion.Size = new System.Drawing.Size(408, 278);
            grupoPrediccion.TabIndex = 1;
            grupoPrediccion.TabStop = false;
            grupoPrediccion.Text = "Paso 2 - Ingresar Datos del Viaje";
            // 
            // btnPredecir
            // 
            btnPredecir.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            btnPredecir.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPredecir.FlatAppearance.BorderSize = 0;
            btnPredecir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPredecir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnPredecir.ForeColor = System.Drawing.Color.White;
            btnPredecir.Location = new System.Drawing.Point(10, 220);
            btnPredecir.Name = "btnPredecir";
            btnPredecir.Size = new System.Drawing.Size(385, 42);
            btnPredecir.TabIndex = 5;
            btnPredecir.Text = "Predecir Tarifa y Guardar en BD";
            btnPredecir.UseVisualStyleBackColor = false;
            btnPredecir.Click += BtnPredecir_Click;
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipoPago.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbTipoPago.Items.AddRange(new object[] { "CRD - Tarjeta", "CSH - Efectivo" });
            cmbTipoPago.Location = new System.Drawing.Point(210, 168);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new System.Drawing.Size(185, 25);
            cmbTipoPago.TabIndex = 4;
            // 
            // lblTipoPago
            // 
            lblTipoPago.AutoSize = true;
            lblTipoPago.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblTipoPago.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblTipoPago.Location = new System.Drawing.Point(210, 148);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new System.Drawing.Size(80, 15);
            lblTipoPago.TabIndex = 6;
            lblTipoPago.Text = "Tipo de pago:";
            // 
            // numDuracion
            // 
            numDuracion.Font = new System.Drawing.Font("Segoe UI", 10F);
            numDuracion.Increment = new decimal(new int[] { 60, 0, 0, 0 });
            numDuracion.Location = new System.Drawing.Point(10, 168);
            numDuracion.Maximum = new decimal(new int[] { 7200, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new System.Drawing.Size(185, 25);
            numDuracion.TabIndex = 3;
            numDuracion.Value = new decimal(new int[] { 900, 0, 0, 0 });
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblDuracion.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblDuracion.Location = new System.Drawing.Point(10, 148);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new System.Drawing.Size(171, 15);
            lblDuracion.TabIndex = 7;
            lblDuracion.Text = "Duracion estimada (segundos):";
            // 
            // numDistancia
            // 
            numDistancia.DecimalPlaces = 1;
            numDistancia.Font = new System.Drawing.Font("Segoe UI", 10F);
            numDistancia.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numDistancia.Location = new System.Drawing.Point(210, 108);
            numDistancia.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numDistancia.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numDistancia.Name = "numDistancia";
            numDistancia.Size = new System.Drawing.Size(185, 25);
            numDistancia.TabIndex = 2;
            numDistancia.Value = new decimal(new int[] { 35, 0, 0, 65536 });
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblDistancia.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblDistancia.Location = new System.Drawing.Point(210, 88);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new System.Drawing.Size(146, 15);
            lblDistancia.TabIndex = 8;
            lblDistancia.Text = "Distancia del viaje (millas):";
            // 
            // numPasajeros
            // 
            numPasajeros.Font = new System.Drawing.Font("Segoe UI", 10F);
            numPasajeros.Location = new System.Drawing.Point(10, 108);
            numPasajeros.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numPasajeros.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPasajeros.Name = "numPasajeros";
            numPasajeros.Size = new System.Drawing.Size(185, 25);
            numPasajeros.TabIndex = 1;
            numPasajeros.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPasajeros
            // 
            lblPasajeros.AutoSize = true;
            lblPasajeros.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblPasajeros.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblPasajeros.Location = new System.Drawing.Point(10, 88);
            lblPasajeros.Name = "lblPasajeros";
            lblPasajeros.Size = new System.Drawing.Size(122, 15);
            lblPasajeros.TabIndex = 9;
            lblPasajeros.Text = "Numero de pasajeros:";
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEmpresa.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbEmpresa.Items.AddRange(new object[] { "CMT", "VTS" });
            cmbEmpresa.Location = new System.Drawing.Point(10, 50);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new System.Drawing.Size(385, 25);
            cmbEmpresa.TabIndex = 0;
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblEmpresa.Location = new System.Drawing.Point(10, 30);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new System.Drawing.Size(94, 15);
            lblEmpresa.TabIndex = 10;
            lblEmpresa.Text = "Empresa de Taxi:";
            // 
            // grupoEntrenamiento
            // 
            grupoEntrenamiento.BackColor = System.Drawing.Color.White;
            grupoEntrenamiento.Controls.Add(lblEstadoModelo);
            grupoEntrenamiento.Controls.Add(barraProgreso);
            grupoEntrenamiento.Controls.Add(btnEntrenar);
            grupoEntrenamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            grupoEntrenamiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grupoEntrenamiento.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            grupoEntrenamiento.Location = new System.Drawing.Point(0, 0);
            grupoEntrenamiento.Name = "grupoEntrenamiento";
            grupoEntrenamiento.Padding = new System.Windows.Forms.Padding(8);
            grupoEntrenamiento.Size = new System.Drawing.Size(408, 130);
            grupoEntrenamiento.TabIndex = 0;
            grupoEntrenamiento.TabStop = false;
            grupoEntrenamiento.Text = "Paso 1 - Entrenar Modelo de IA";
            // 
            // lblEstadoModelo
            // 
            lblEstadoModelo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblEstadoModelo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblEstadoModelo.Location = new System.Drawing.Point(10, 88);
            lblEstadoModelo.Name = "lblEstadoModelo";
            lblEstadoModelo.Size = new System.Drawing.Size(385, 30);
            lblEstadoModelo.TabIndex = 0;
            lblEstadoModelo.Text = "Estado: Modelo no entrenado. Haga clic en Entrenar.";
            // 
            // barraProgreso
            // 
            barraProgreso.Location = new System.Drawing.Point(10, 73);
            barraProgreso.MarqueeAnimationSpeed = 0;
            barraProgreso.Name = "barraProgreso";
            barraProgreso.Size = new System.Drawing.Size(385, 10);
            barraProgreso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            barraProgreso.TabIndex = 1;
            // 
            // btnEntrenar
            // 
            btnEntrenar.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            btnEntrenar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEntrenar.FlatAppearance.BorderSize = 0;
            btnEntrenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEntrenar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnEntrenar.ForeColor = System.Drawing.Color.White;
            btnEntrenar.Location = new System.Drawing.Point(10, 28);
            btnEntrenar.Name = "btnEntrenar";
            btnEntrenar.Size = new System.Drawing.Size(385, 38);
            btnEntrenar.TabIndex = 0;
            btnEntrenar.Text = "Entrenar con Datos Historicos (CSV)";
            btnEntrenar.UseVisualStyleBackColor = false;
            btnEntrenar.Click += BtnEntrenar_Click;
            // 
            // panelDerecho
            // 
            panelDerecho.Controls.Add(grupoHistorial);
            panelDerecho.Location = new System.Drawing.Point(435, 100);
            panelDerecho.Name = "panelDerecho";
            panelDerecho.Size = new System.Drawing.Size(570, 635);
            panelDerecho.TabIndex = 2;
            // 
            // grupoHistorial
            // 
            grupoHistorial.BackColor = System.Drawing.Color.White;
            grupoHistorial.Controls.Add(gridHistorial);
            grupoHistorial.Controls.Add(panelBotonesHistorial);
            grupoHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            grupoHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grupoHistorial.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            grupoHistorial.Location = new System.Drawing.Point(0, 0);
            grupoHistorial.Name = "grupoHistorial";
            grupoHistorial.Padding = new System.Windows.Forms.Padding(8);
            grupoHistorial.Size = new System.Drawing.Size(570, 635);
            grupoHistorial.TabIndex = 0;
            grupoHistorial.TabStop = false;
            grupoHistorial.Text = "Historial de Viajes - Base de Datos SQL Server";
            grupoHistorial.Enter += grupoHistorial_Enter;
            // 
            // gridHistorial
            // 
            gridHistorial.AllowUserToAddRows = false;
            gridHistorial.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            gridHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridHistorial.BackgroundColor = System.Drawing.Color.White;
            gridHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            gridHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridHistorial.ColumnHeadersHeight = 35;
            gridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridHistorial.EnableHeadersVisualStyles = false;
            gridHistorial.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            gridHistorial.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            gridHistorial.Location = new System.Drawing.Point(-9, 73);
            gridHistorial.Name = "gridHistorial";
            gridHistorial.ReadOnly = true;
            gridHistorial.RowHeadersVisible = false;
            gridHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridHistorial.Size = new System.Drawing.Size(548, 552);
            gridHistorial.TabIndex = 1;
            gridHistorial.CellContentClick += gridHistorial_CellContentClick;
            // 
            // panelBotonesHistorial
            // 
            panelBotonesHistorial.Controls.Add(lblTotalViajes);
            panelBotonesHistorial.Controls.Add(btnRefrescarHistorial);
            panelBotonesHistorial.Location = new System.Drawing.Point(10, 25);
            panelBotonesHistorial.Name = "panelBotonesHistorial";
            panelBotonesHistorial.Size = new System.Drawing.Size(548, 38);
            panelBotonesHistorial.TabIndex = 0;
            // 
            // lblTotalViajes
            // 
            lblTotalViajes.AutoSize = true;
            lblTotalViajes.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalViajes.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblTotalViajes.Location = new System.Drawing.Point(170, 10);
            lblTotalViajes.Name = "lblTotalViajes";
            lblTotalViajes.Size = new System.Drawing.Size(111, 15);
            lblTotalViajes.TabIndex = 0;
            lblTotalViajes.Text = "Total en BD: 0 viajes";
            // 
            // btnRefrescarHistorial
            // 
            btnRefrescarHistorial.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            btnRefrescarHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescarHistorial.FlatAppearance.BorderSize = 0;
            btnRefrescarHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescarHistorial.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnRefrescarHistorial.ForeColor = System.Drawing.Color.White;
            btnRefrescarHistorial.Location = new System.Drawing.Point(0, 3);
            btnRefrescarHistorial.Name = "btnRefrescarHistorial";
            btnRefrescarHistorial.Size = new System.Drawing.Size(160, 32);
            btnRefrescarHistorial.TabIndex = 0;
            btnRefrescarHistorial.Text = "Actualizar Historial";
            btnRefrescarHistorial.UseVisualStyleBackColor = false;
            btnRefrescarHistorial.Click += BtnRefrescarHistorial_Click;
            // 
            // barraEstado
            // 
            barraEstado.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblEstadoConexion });
            barraEstado.Location = new System.Drawing.Point(0, 727);
            barraEstado.Name = "barraEstado";
            barraEstado.Size = new System.Drawing.Size(1020, 22);
            barraEstado.TabIndex = 3;
            // 
            // lblEstadoConexion
            // 
            lblEstadoConexion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblEstadoConexion.ForeColor = System.Drawing.Color.White;
            lblEstadoConexion.Name = "lblEstadoConexion";
            lblEstadoConexion.Size = new System.Drawing.Size(149, 17);
            lblEstadoConexion.Text = "Conectando a SQL Server...";
            // 
            // FormularioPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1020, 749);
            Controls.Add(panelDerecho);
            Controls.Add(panelIzquierdo);
            Controls.Add(panelEncabezado);
            Controls.Add(barraEstado);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            MinimumSize = new System.Drawing.Size(1020, 726);
            Name = "FormularioPrincipal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Predictor de Tarifas de Taxi - ML.NET + SQL Server";
            Load += FormularioPrincipal_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelIzquierdo.ResumeLayout(false);
            panelResultado.ResumeLayout(false);
            panelResultado.PerformLayout();
            grupoPrediccion.ResumeLayout(false);
            grupoPrediccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDistancia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPasajeros).EndInit();
            grupoEntrenamiento.ResumeLayout(false);
            panelDerecho.ResumeLayout(false);
            grupoHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridHistorial).EndInit();
            panelBotonesHistorial.ResumeLayout(false);
            panelBotonesHistorial.PerformLayout();
            barraEstado.ResumeLayout(false);
            barraEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // ================================================================
        // DECLARACION DE CONTROLES (visible en el Disenador de VS)
        // ================================================================
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.GroupBox grupoEntrenamiento;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.ProgressBar barraProgreso;
        private System.Windows.Forms.Label lblEstadoModelo;

        private System.Windows.Forms.GroupBox grupoPrediccion;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label lblPasajeros;
        private System.Windows.Forms.NumericUpDown numPasajeros;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.NumericUpDown numDistancia;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown numDuracion;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.ComboBox cmbTipoPago;
        private System.Windows.Forms.Button btnPredecir;

        private System.Windows.Forms.Panel panelResultado;
        private System.Windows.Forms.Label lblResultadoTitulo;
        private System.Windows.Forms.Label lblTarifaPredicha;
        private System.Windows.Forms.Label lblMensajeGuardado;

        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.GroupBox grupoHistorial;
        private System.Windows.Forms.Panel panelBotonesHistorial;
        private System.Windows.Forms.Button btnRefrescarHistorial;
        private System.Windows.Forms.Label lblTotalViajes;
        private System.Windows.Forms.DataGridView gridHistorial;

        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblEstadoConexion;
    }
}
