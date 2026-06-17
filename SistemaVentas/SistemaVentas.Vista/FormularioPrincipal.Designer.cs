namespace SistemaVentas.Vista
{
    partial class FormularioPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            panelEncabezado = new System.Windows.Forms.Panel();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            panelBotones = new System.Windows.Forms.Panel();
            btnVerTodas = new System.Windows.Forms.Button();
            btnReporteRegion = new System.Windows.Forms.Button();
            btnReporteProducto = new System.Windows.Forms.Button();
            btnPrediccionML = new System.Windows.Forms.Button();
            panelBusqueda = new System.Windows.Forms.Panel();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            btnBuscarPais = new System.Windows.Forms.Button();
            btnBuscarProducto = new System.Windows.Forms.Button();
            panelInfo = new System.Windows.Forms.Panel();
            lblTotalRegistros = new System.Windows.Forms.Label();
            lblEstado = new System.Windows.Forms.Label();
            gridDatos = new System.Windows.Forms.DataGridView();
            barraEstado = new System.Windows.Forms.StatusStrip();
            lblBarraEstado = new System.Windows.Forms.ToolStripStatusLabel();
            panelEncabezado.SuspendLayout();
            panelBotones.SuspendLayout();
            panelBusqueda.SuspendLayout();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDatos).BeginInit();
            barraEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panelEncabezado
            // 
            panelEncabezado.BackColor = System.Drawing.Color.Black;
            panelEncabezado.Controls.Add(lblSubtitulo);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            panelEncabezado.Location = new System.Drawing.Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new System.Drawing.Size(1100, 80);
            panelEncabezado.TabIndex = 4;
            panelEncabezado.Paint += panelEncabezado_Paint;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = System.Drawing.Color.White;
            lblSubtitulo.Location = new System.Drawing.Point(22, 50);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(0, 15);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Click += lblSubtitulo_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(503, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "SISTEMA DE VENTAS - ANALISIS DE DATOS";
            // 
            // panelBotones
            // 
            panelBotones.BackColor = System.Drawing.Color.Black;
            panelBotones.Controls.Add(btnVerTodas);
            panelBotones.Controls.Add(btnReporteRegion);
            panelBotones.Controls.Add(btnReporteProducto);
            panelBotones.Controls.Add(btnPrediccionML);
            panelBotones.Location = new System.Drawing.Point(12, 90);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new System.Drawing.Size(1076, 50);
            panelBotones.TabIndex = 3;
            // 
            // btnVerTodas
            // 
            btnVerTodas.BackColor = System.Drawing.Color.Black;
            btnVerTodas.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVerTodas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnVerTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVerTodas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnVerTodas.ForeColor = System.Drawing.Color.White;
            btnVerTodas.Location = new System.Drawing.Point(5, 8);
            btnVerTodas.Name = "btnVerTodas";
            btnVerTodas.Size = new System.Drawing.Size(180, 35);
            btnVerTodas.TabIndex = 0;
            btnVerTodas.Text = "Ver Todas las Ventas";
            btnVerTodas.UseVisualStyleBackColor = false;
            btnVerTodas.Click += BtnVerTodas_Click;
            // 
            // btnReporteRegion
            // 
            btnReporteRegion.BackColor = System.Drawing.Color.Black;
            btnReporteRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReporteRegion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnReporteRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReporteRegion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnReporteRegion.ForeColor = System.Drawing.Color.White;
            btnReporteRegion.Location = new System.Drawing.Point(195, 8);
            btnReporteRegion.Name = "btnReporteRegion";
            btnReporteRegion.Size = new System.Drawing.Size(190, 35);
            btnReporteRegion.TabIndex = 1;
            btnReporteRegion.Text = "Reporte por Region";
            btnReporteRegion.UseVisualStyleBackColor = false;
            btnReporteRegion.Click += BtnReporteRegion_Click;
            // 
            // btnReporteProducto
            // 
            btnReporteProducto.BackColor = System.Drawing.Color.Black;
            btnReporteProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReporteProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnReporteProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReporteProducto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnReporteProducto.ForeColor = System.Drawing.Color.White;
            btnReporteProducto.Location = new System.Drawing.Point(395, 8);
            btnReporteProducto.Name = "btnReporteProducto";
            btnReporteProducto.Size = new System.Drawing.Size(200, 35);
            btnReporteProducto.TabIndex = 2;
            btnReporteProducto.Text = "Reporte por Producto";
            btnReporteProducto.UseVisualStyleBackColor = false;
            btnReporteProducto.Click += BtnReporteProducto_Click;
            // 
            // btnPrediccionML
            // 
            btnPrediccionML.BackColor = System.Drawing.Color.Black;
            btnPrediccionML.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPrediccionML.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnPrediccionML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrediccionML.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnPrediccionML.ForeColor = System.Drawing.Color.White;
            btnPrediccionML.Location = new System.Drawing.Point(605, 8);
            btnPrediccionML.Name = "btnPrediccionML";
            btnPrediccionML.Size = new System.Drawing.Size(200, 35);
            btnPrediccionML.TabIndex = 3;
            btnPrediccionML.Text = "Prediccion Ventas (IA)";
            btnPrediccionML.UseVisualStyleBackColor = false;
            btnPrediccionML.Click += BtnPrediccionML_Click;
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = System.Drawing.Color.Black;
            panelBusqueda.Controls.Add(lblBuscar);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscarPais);
            panelBusqueda.Controls.Add(btnBuscarProducto);
            panelBusqueda.Location = new System.Drawing.Point(12, 148);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new System.Drawing.Size(1076, 45);
            panelBusqueda.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblBuscar.ForeColor = System.Drawing.Color.White;
            lblBuscar.Location = new System.Drawing.Point(10, 12);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(53, 17);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = System.Drawing.Color.Black;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscar.ForeColor = System.Drawing.Color.White;
            txtBuscar.Location = new System.Drawing.Point(70, 8);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new System.Drawing.Size(400, 25);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscarPais
            // 
            btnBuscarPais.BackColor = System.Drawing.Color.Black;
            btnBuscarPais.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscarPais.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnBuscarPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarPais.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscarPais.ForeColor = System.Drawing.Color.White;
            btnBuscarPais.Location = new System.Drawing.Point(485, 7);
            btnBuscarPais.Name = "btnBuscarPais";
            btnBuscarPais.Size = new System.Drawing.Size(140, 30);
            btnBuscarPais.TabIndex = 2;
            btnBuscarPais.Text = "Buscar por Pais";
            btnBuscarPais.UseVisualStyleBackColor = false;
            btnBuscarPais.Click += BtnBuscarPais_Click;
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.BackColor = System.Drawing.Color.Black;
            btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscarProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscarProducto.ForeColor = System.Drawing.Color.White;
            btnBuscarProducto.Location = new System.Drawing.Point(635, 7);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new System.Drawing.Size(170, 30);
            btnBuscarProducto.TabIndex = 3;
            btnBuscarProducto.Text = "Buscar por Producto";
            btnBuscarProducto.UseVisualStyleBackColor = false;
            btnBuscarProducto.Click += BtnBuscarProducto_Click;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = System.Drawing.Color.Black;
            panelInfo.Controls.Add(lblTotalRegistros);
            panelInfo.Controls.Add(lblEstado);
            panelInfo.Location = new System.Drawing.Point(12, 200);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new System.Drawing.Size(1076, 30);
            panelInfo.TabIndex = 1;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalRegistros.ForeColor = System.Drawing.Color.White;
            lblTotalRegistros.Location = new System.Drawing.Point(10, 7);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new System.Drawing.Size(136, 15);
            lblTotalRegistros.TabIndex = 0;
            lblTotalRegistros.Text = "Total en BD: 0 registros";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblEstado.ForeColor = System.Drawing.Color.White;
            lblEstado.Location = new System.Drawing.Point(300, 7);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(32, 15);
            lblEstado.TabIndex = 1;
            lblEstado.Text = "Listo";
            // 
            // gridDatos
            // 
            gridDatos.AllowUserToAddRows = false;
            gridDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            gridDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            gridDatos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridDatos.BackgroundColor = System.Drawing.Color.Black;
            gridDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            gridDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            gridDatos.ColumnHeadersHeight = 35;
            gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            gridDatos.DefaultCellStyle = dataGridViewCellStyle6;
            gridDatos.EnableHeadersVisualStyles = false;
            gridDatos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            gridDatos.GridColor = System.Drawing.Color.White;
            gridDatos.Location = new System.Drawing.Point(12, 235);
            gridDatos.Name = "gridDatos";
            gridDatos.ReadOnly = true;
            gridDatos.RowHeadersVisible = false;
            gridDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridDatos.Size = new System.Drawing.Size(1076, 425);
            gridDatos.TabIndex = 0;
            // 
            // barraEstado
            // 
            barraEstado.BackColor = System.Drawing.Color.Black;
            barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblBarraEstado });
            barraEstado.Location = new System.Drawing.Point(0, 668);
            barraEstado.Name = "barraEstado";
            barraEstado.Size = new System.Drawing.Size(1100, 22);
            barraEstado.TabIndex = 5;
            // 
            // lblBarraEstado
            // 
            lblBarraEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblBarraEstado.ForeColor = System.Drawing.Color.White;
            lblBarraEstado.Name = "lblBarraEstado";
            lblBarraEstado.Size = new System.Drawing.Size(190, 17);
            lblBarraEstado.Text = "Conectando a SQL Server Express...";
            lblBarraEstado.Click += lblBarraEstado_Click;
            // 
            // FormularioPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1100, 690);
            Controls.Add(gridDatos);
            Controls.Add(panelInfo);
            Controls.Add(panelBusqueda);
            Controls.Add(panelBotones);
            Controls.Add(panelEncabezado);
            Controls.Add(barraEstado);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            MinimumSize = new System.Drawing.Size(1000, 650);
            Name = "FormularioPrincipal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sistema de Ventas - ADO.NET + SQL Server";
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelBotones.ResumeLayout(false);
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridDatos).EndInit();
            barraEstado.ResumeLayout(false);
            barraEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnVerTodas;
        private System.Windows.Forms.Button btnReporteRegion;
        private System.Windows.Forms.Button btnReporteProducto;
        private System.Windows.Forms.Button btnPrediccionML;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscarPais;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView gridDatos;
        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraEstado;
    }
}
