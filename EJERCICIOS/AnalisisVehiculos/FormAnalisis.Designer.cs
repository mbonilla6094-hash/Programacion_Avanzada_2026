namespace AnalisisVehiculos
{
    partial class FormAnalisis
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
            panelTitulo = new Panel();
            labelTitulo = new Label();
            labelSubtitulo = new Label();
            buttonCargarCSV = new Button();
            labelArchivoCargado = new Label();
            groupBoxDatos = new GroupBox();
            dataGridViewDatos = new DataGridView();
            groupBoxResultados = new GroupBox();
            labelVehiculoMasVendido = new Label();
            labelMejorAnio = new Label();
            labelTotalVehiculos = new Label();
            labelTotalRecaudado = new Label();
            labelMejorAnioVenta = new Label();
            labelMejorCreditos = new Label();
            groupBoxPorcentajes = new GroupBox();
            dataGridViewPorcentajes = new DataGridView();
            groupBoxDiferencias = new GroupBox();
            dataGridViewDiferencias = new DataGridView();
            buttonCalcular = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panelTitulo.SuspendLayout();
            groupBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatos).BeginInit();
            groupBoxResultados.SuspendLayout();
            groupBoxPorcentajes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPorcentajes).BeginInit();
            groupBoxDiferencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiferencias).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = System.Drawing.Color.FromArgb(40, 60, 100);
            panelTitulo.Controls.Add(labelTitulo);
            panelTitulo.Controls.Add(labelSubtitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new System.Drawing.Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new System.Drawing.Size(1050, 60);
            panelTitulo.TabIndex = 0;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            labelTitulo.ForeColor = System.Drawing.Color.White;
            labelTitulo.Location = new System.Drawing.Point(15, 5);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(360, 30);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Analisis de Ventas de Vehiculos";
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelSubtitulo.ForeColor = System.Drawing.Color.LightGray;
            labelSubtitulo.Location = new System.Drawing.Point(15, 38);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new System.Drawing.Size(200, 15);
            labelSubtitulo.TabIndex = 1;
            labelSubtitulo.Text = "Periodos 2020 - 2026 | 4 periodos por anio";
            // 
            // buttonCargarCSV
            // 
            buttonCargarCSV.BackColor = System.Drawing.Color.FromArgb(40, 60, 100);
            buttonCargarCSV.FlatStyle = FlatStyle.Flat;
            buttonCargarCSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonCargarCSV.ForeColor = System.Drawing.Color.White;
            buttonCargarCSV.Location = new System.Drawing.Point(15, 70);
            buttonCargarCSV.Name = "buttonCargarCSV";
            buttonCargarCSV.Size = new System.Drawing.Size(130, 33);
            buttonCargarCSV.TabIndex = 1;
            buttonCargarCSV.Text = "Cargar CSV";
            buttonCargarCSV.UseVisualStyleBackColor = false;
            buttonCargarCSV.Click += buttonCargarCSV_Click;
            // 
            // labelArchivoCargado
            // 
            labelArchivoCargado.AutoSize = true;
            labelArchivoCargado.ForeColor = System.Drawing.Color.Gray;
            labelArchivoCargado.Location = new System.Drawing.Point(155, 78);
            labelArchivoCargado.Name = "labelArchivoCargado";
            labelArchivoCargado.Size = new System.Drawing.Size(140, 15);
            labelArchivoCargado.TabIndex = 2;
            labelArchivoCargado.Text = "Ningun archivo cargado";
            // 
            // buttonCalcular
            // 
            buttonCalcular.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            buttonCalcular.Enabled = false;
            buttonCalcular.FlatStyle = FlatStyle.Flat;
            buttonCalcular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonCalcular.ForeColor = System.Drawing.Color.White;
            buttonCalcular.Location = new System.Drawing.Point(900, 70);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new System.Drawing.Size(135, 33);
            buttonCalcular.TabIndex = 3;
            buttonCalcular.Text = "Calcular Todo";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.Controls.Add(dataGridViewDatos);
            groupBoxDatos.Location = new System.Drawing.Point(15, 110);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new System.Drawing.Size(1020, 200);
            groupBoxDatos.TabIndex = 4;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "Datos del CSV";
            // 
            // dataGridViewDatos
            // 
            dataGridViewDatos.AllowUserToAddRows = false;
            dataGridViewDatos.AllowUserToDeleteRows = false;
            dataGridViewDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDatos.Location = new System.Drawing.Point(6, 22);
            dataGridViewDatos.Name = "dataGridViewDatos";
            dataGridViewDatos.ReadOnly = true;
            dataGridViewDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDatos.Size = new System.Drawing.Size(1008, 170);
            dataGridViewDatos.TabIndex = 0;
            // 
            // groupBoxResultados
            // 
            groupBoxResultados.Controls.Add(labelVehiculoMasVendido);
            groupBoxResultados.Controls.Add(labelMejorAnio);
            groupBoxResultados.Controls.Add(labelTotalVehiculos);
            groupBoxResultados.Controls.Add(labelTotalRecaudado);
            groupBoxResultados.Controls.Add(labelMejorAnioVenta);
            groupBoxResultados.Controls.Add(labelMejorCreditos);
            groupBoxResultados.Location = new System.Drawing.Point(15, 320);
            groupBoxResultados.Name = "groupBoxResultados";
            groupBoxResultados.Size = new System.Drawing.Size(1020, 110);
            groupBoxResultados.TabIndex = 5;
            groupBoxResultados.TabStop = false;
            groupBoxResultados.Text = "Resultados del Analisis";
            // 
            // labelVehiculoMasVendido
            // 
            labelVehiculoMasVendido.AutoSize = true;
            labelVehiculoMasVendido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelVehiculoMasVendido.Location = new System.Drawing.Point(15, 25);
            labelVehiculoMasVendido.Name = "labelVehiculoMasVendido";
            labelVehiculoMasVendido.Size = new System.Drawing.Size(150, 15);
            labelVehiculoMasVendido.TabIndex = 0;
            labelVehiculoMasVendido.Text = "Vehiculo mas vendido: ---";
            // 
            // labelMejorAnio
            // 
            labelMejorAnio.AutoSize = true;
            labelMejorAnio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelMejorAnio.Location = new System.Drawing.Point(15, 50);
            labelMejorAnio.Name = "labelMejorAnio";
            labelMejorAnio.Size = new System.Drawing.Size(180, 15);
            labelMejorAnio.TabIndex = 1;
            labelMejorAnio.Text = "Mejor anio (recaudacion): ---";
            // 
            // labelTotalVehiculos
            // 
            labelTotalVehiculos.AutoSize = true;
            labelTotalVehiculos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelTotalVehiculos.Location = new System.Drawing.Point(15, 75);
            labelTotalVehiculos.Name = "labelTotalVehiculos";
            labelTotalVehiculos.Size = new System.Drawing.Size(160, 15);
            labelTotalVehiculos.TabIndex = 2;
            labelTotalVehiculos.Text = "Total vehiculos vendidos: ---";
            // 
            // labelTotalRecaudado
            // 
            labelTotalRecaudado.AutoSize = true;
            labelTotalRecaudado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelTotalRecaudado.Location = new System.Drawing.Point(400, 25);
            labelTotalRecaudado.Name = "labelTotalRecaudado";
            labelTotalRecaudado.Size = new System.Drawing.Size(130, 15);
            labelTotalRecaudado.TabIndex = 3;
            labelTotalRecaudado.Text = "Total recaudado: ---";
            // 
            // labelMejorAnioVenta
            // 
            labelMejorAnioVenta.AutoSize = true;
            labelMejorAnioVenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelMejorAnioVenta.Location = new System.Drawing.Point(400, 50);
            labelMejorAnioVenta.Name = "labelMejorAnioVenta";
            labelMejorAnioVenta.Size = new System.Drawing.Size(180, 15);
            labelMejorAnioVenta.TabIndex = 4;
            labelMejorAnioVenta.Text = "Mejor anio de ventas: ---";
            // 
            // labelMejorCreditos
            // 
            labelMejorCreditos.AutoSize = true;
            labelMejorCreditos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelMejorCreditos.Location = new System.Drawing.Point(400, 75);
            labelMejorCreditos.Name = "labelMejorCreditos";
            labelMejorCreditos.Size = new System.Drawing.Size(200, 15);
            labelMejorCreditos.TabIndex = 5;
            labelMejorCreditos.Text = "Vehiculo mejores creditos: ---";
            // 
            // groupBoxPorcentajes
            // 
            groupBoxPorcentajes.Controls.Add(dataGridViewPorcentajes);
            groupBoxPorcentajes.Location = new System.Drawing.Point(15, 440);
            groupBoxPorcentajes.Name = "groupBoxPorcentajes";
            groupBoxPorcentajes.Size = new System.Drawing.Size(500, 200);
            groupBoxPorcentajes.TabIndex = 6;
            groupBoxPorcentajes.TabStop = false;
            groupBoxPorcentajes.Text = "Porcentaje de Ingresos por Anio";
            // 
            // dataGridViewPorcentajes
            // 
            dataGridViewPorcentajes.AllowUserToAddRows = false;
            dataGridViewPorcentajes.AllowUserToDeleteRows = false;
            dataGridViewPorcentajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPorcentajes.Location = new System.Drawing.Point(6, 22);
            dataGridViewPorcentajes.Name = "dataGridViewPorcentajes";
            dataGridViewPorcentajes.ReadOnly = true;
            dataGridViewPorcentajes.Size = new System.Drawing.Size(488, 170);
            dataGridViewPorcentajes.TabIndex = 0;
            // 
            // groupBoxDiferencias
            // 
            groupBoxDiferencias.Controls.Add(dataGridViewDiferencias);
            groupBoxDiferencias.Location = new System.Drawing.Point(525, 440);
            groupBoxDiferencias.Name = "groupBoxDiferencias";
            groupBoxDiferencias.Size = new System.Drawing.Size(510, 200);
            groupBoxDiferencias.TabIndex = 7;
            groupBoxDiferencias.TabStop = false;
            groupBoxDiferencias.Text = "Diferencia de Ventas entre Anios Pares";
            // 
            // dataGridViewDiferencias
            // 
            dataGridViewDiferencias.AllowUserToAddRows = false;
            dataGridViewDiferencias.AllowUserToDeleteRows = false;
            dataGridViewDiferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiferencias.Location = new System.Drawing.Point(6, 22);
            dataGridViewDiferencias.Name = "dataGridViewDiferencias";
            dataGridViewDiferencias.ReadOnly = true;
            dataGridViewDiferencias.Size = new System.Drawing.Size(498, 170);
            dataGridViewDiferencias.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new System.Drawing.Point(0, 653);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1050, 22);
            statusStrip1.TabIndex = 8;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // FormAnalisis
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1050, 675);
            Controls.Add(statusStrip1);
            Controls.Add(groupBoxDiferencias);
            Controls.Add(groupBoxPorcentajes);
            Controls.Add(groupBoxResultados);
            Controls.Add(groupBoxDatos);
            Controls.Add(buttonCalcular);
            Controls.Add(labelArchivoCargado);
            Controls.Add(buttonCargarCSV);
            Controls.Add(panelTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormAnalisis";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Analisis de Ventas de Vehiculos";
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            groupBoxDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatos).EndInit();
            groupBoxResultados.ResumeLayout(false);
            groupBoxResultados.PerformLayout();
            groupBoxPorcentajes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPorcentajes).EndInit();
            groupBoxDiferencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiferencias).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTitulo;
        private Label labelTitulo;
        private Label labelSubtitulo;
        private Button buttonCargarCSV;
        private Label labelArchivoCargado;
        private Button buttonCalcular;
        private GroupBox groupBoxDatos;
        private DataGridView dataGridViewDatos;
        private GroupBox groupBoxResultados;
        private Label labelVehiculoMasVendido;
        private Label labelMejorAnio;
        private Label labelTotalVehiculos;
        private Label labelTotalRecaudado;
        private Label labelMejorAnioVenta;
        private Label labelMejorCreditos;
        private GroupBox groupBoxPorcentajes;
        private DataGridView dataGridViewPorcentajes;
        private GroupBox groupBoxDiferencias;
        private DataGridView dataGridViewDiferencias;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
