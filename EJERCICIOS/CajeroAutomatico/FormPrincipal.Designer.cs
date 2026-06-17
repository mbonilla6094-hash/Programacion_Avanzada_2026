namespace CajeroAutomatico
{
    partial class FormPrincipal
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
            panelCabecera = new Panel();
            labelBienvenida = new Label();
            labelInfoUsuario = new Label();
            labelSaldoTitulo = new Label();
            labelSaldoValor = new Label();
            groupBoxOperaciones = new GroupBox();
            labelMonto = new Label();
            textBoxMonto = new TextBox();
            buttonDepositar = new Button();
            buttonRetirar = new Button();
            groupBoxHistorial = new GroupBox();
            dataGridViewTransacciones = new DataGridView();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            vistaPreviaToolStripMenuItem = new ToolStripMenuItem();
            imprimirToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();
            panelCabecera.SuspendLayout();
            groupBoxOperaciones.SuspendLayout();
            groupBoxHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransacciones).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCabecera
            // 
            panelCabecera.BackColor = System.Drawing.Color.FromArgb(0, 100, 150);
            panelCabecera.Controls.Add(labelBienvenida);
            panelCabecera.Controls.Add(labelInfoUsuario);
            panelCabecera.Controls.Add(labelSaldoTitulo);
            panelCabecera.Controls.Add(labelSaldoValor);
            panelCabecera.Location = new System.Drawing.Point(12, 30);
            panelCabecera.Name = "panelCabecera";
            panelCabecera.Size = new System.Drawing.Size(776, 85);
            panelCabecera.TabIndex = 0;
            // 
            // labelBienvenida
            // 
            labelBienvenida.AutoSize = true;
            labelBienvenida.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            labelBienvenida.ForeColor = System.Drawing.Color.White;
            labelBienvenida.Location = new System.Drawing.Point(15, 10);
            labelBienvenida.Name = "labelBienvenida";
            labelBienvenida.Size = new System.Drawing.Size(130, 25);
            labelBienvenida.TabIndex = 0;
            labelBienvenida.Text = "Bienvenido/a";
            // 
            // labelInfoUsuario
            // 
            labelInfoUsuario.AutoSize = true;
            labelInfoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelInfoUsuario.ForeColor = System.Drawing.Color.White;
            labelInfoUsuario.Location = new System.Drawing.Point(15, 45);
            labelInfoUsuario.Name = "labelInfoUsuario";
            labelInfoUsuario.Size = new System.Drawing.Size(100, 15);
            labelInfoUsuario.TabIndex = 1;
            labelInfoUsuario.Text = "ID: 0000";
            // 
            // labelSaldoTitulo
            // 
            labelSaldoTitulo.AutoSize = true;
            labelSaldoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelSaldoTitulo.ForeColor = System.Drawing.Color.White;
            labelSaldoTitulo.Location = new System.Drawing.Point(500, 15);
            labelSaldoTitulo.Name = "labelSaldoTitulo";
            labelSaldoTitulo.Size = new System.Drawing.Size(95, 15);
            labelSaldoTitulo.TabIndex = 2;
            labelSaldoTitulo.Text = "Saldo Disponible:";
            // 
            // labelSaldoValor
            // 
            labelSaldoValor.AutoSize = true;
            labelSaldoValor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            labelSaldoValor.ForeColor = System.Drawing.Color.FromArgb(144, 238, 144);
            labelSaldoValor.Location = new System.Drawing.Point(500, 38);
            labelSaldoValor.Name = "labelSaldoValor";
            labelSaldoValor.Size = new System.Drawing.Size(100, 37);
            labelSaldoValor.TabIndex = 3;
            labelSaldoValor.Text = "$0.00";
            // 
            // groupBoxOperaciones
            // 
            groupBoxOperaciones.Controls.Add(labelMonto);
            groupBoxOperaciones.Controls.Add(textBoxMonto);
            groupBoxOperaciones.Controls.Add(buttonDepositar);
            groupBoxOperaciones.Controls.Add(buttonRetirar);
            groupBoxOperaciones.Location = new System.Drawing.Point(12, 125);
            groupBoxOperaciones.Name = "groupBoxOperaciones";
            groupBoxOperaciones.Size = new System.Drawing.Size(776, 80);
            groupBoxOperaciones.TabIndex = 1;
            groupBoxOperaciones.TabStop = false;
            groupBoxOperaciones.Text = "Operaciones";
            // 
            // labelMonto
            // 
            labelMonto.AutoSize = true;
            labelMonto.Location = new System.Drawing.Point(20, 35);
            labelMonto.Name = "labelMonto";
            labelMonto.Size = new System.Drawing.Size(121, 15);
            labelMonto.TabIndex = 0;
            labelMonto.Text = "Monto de operacion:";
            // 
            // textBoxMonto
            // 
            textBoxMonto.Location = new System.Drawing.Point(150, 32);
            textBoxMonto.Name = "textBoxMonto";
            textBoxMonto.Size = new System.Drawing.Size(200, 23);
            textBoxMonto.TabIndex = 1;
            // 
            // buttonDepositar
            // 
            buttonDepositar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            buttonDepositar.FlatStyle = FlatStyle.Flat;
            buttonDepositar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonDepositar.ForeColor = System.Drawing.Color.White;
            buttonDepositar.Location = new System.Drawing.Point(400, 25);
            buttonDepositar.Name = "buttonDepositar";
            buttonDepositar.Size = new System.Drawing.Size(150, 35);
            buttonDepositar.TabIndex = 2;
            buttonDepositar.Text = "Depositar";
            buttonDepositar.UseVisualStyleBackColor = false;
            buttonDepositar.Click += buttonDepositar_Click;
            // 
            // buttonRetirar
            // 
            buttonRetirar.BackColor = System.Drawing.Color.FromArgb(200, 80, 30);
            buttonRetirar.FlatStyle = FlatStyle.Flat;
            buttonRetirar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            buttonRetirar.ForeColor = System.Drawing.Color.White;
            buttonRetirar.Location = new System.Drawing.Point(580, 25);
            buttonRetirar.Name = "buttonRetirar";
            buttonRetirar.Size = new System.Drawing.Size(150, 35);
            buttonRetirar.TabIndex = 3;
            buttonRetirar.Text = "Retirar";
            buttonRetirar.UseVisualStyleBackColor = false;
            buttonRetirar.Click += buttonRetirar_Click;
            // 
            // groupBoxHistorial
            // 
            groupBoxHistorial.Controls.Add(dataGridViewTransacciones);
            groupBoxHistorial.Location = new System.Drawing.Point(12, 215);
            groupBoxHistorial.Name = "groupBoxHistorial";
            groupBoxHistorial.Size = new System.Drawing.Size(776, 250);
            groupBoxHistorial.TabIndex = 2;
            groupBoxHistorial.TabStop = false;
            groupBoxHistorial.Text = "Historial de Transacciones";
            // 
            // dataGridViewTransacciones
            // 
            dataGridViewTransacciones.AllowUserToAddRows = false;
            dataGridViewTransacciones.AllowUserToDeleteRows = false;
            dataGridViewTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransacciones.Location = new System.Drawing.Point(6, 22);
            dataGridViewTransacciones.Name = "dataGridViewTransacciones";
            dataGridViewTransacciones.ReadOnly = true;
            dataGridViewTransacciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTransacciones.Size = new System.Drawing.Size(764, 220);
            dataGridViewTransacciones.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, herramientasToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(800, 24);
            menuStrip1.TabIndex = 3;
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesionToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vistaPreviaToolStripMenuItem, imprimirToolStripMenuItem });
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // vistaPreviaToolStripMenuItem
            // 
            vistaPreviaToolStripMenuItem.Name = "vistaPreviaToolStripMenuItem";
            vistaPreviaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            vistaPreviaToolStripMenuItem.Text = "Vista Previa";
            vistaPreviaToolStripMenuItem.Click += vistaPreviaToolStripMenuItem_Click;
            // 
            // imprimirToolStripMenuItem
            // 
            imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            imprimirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            imprimirToolStripMenuItem.Text = "Imprimir";
            imprimirToolStripMenuItem.Click += imprimirToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new System.Drawing.Point(0, 478);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(800, 22);
            statusStrip1.TabIndex = 4;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 500);
            Controls.Add(statusStrip1);
            Controls.Add(groupBoxHistorial);
            Controls.Add(groupBoxOperaciones);
            Controls.Add(panelCabecera);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cajero Automatico";
            Load += FormPrincipal_Load;
            panelCabecera.ResumeLayout(false);
            panelCabecera.PerformLayout();
            groupBoxOperaciones.ResumeLayout(false);
            groupBoxOperaciones.PerformLayout();
            groupBoxHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransacciones).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCabecera;
        private Label labelBienvenida;
        private Label labelInfoUsuario;
        private Label labelSaldoTitulo;
        private Label labelSaldoValor;
        private GroupBox groupBoxOperaciones;
        private Label labelMonto;
        private TextBox textBoxMonto;
        private Button buttonDepositar;
        private Button buttonRetirar;
        private GroupBox groupBoxHistorial;
        private DataGridView dataGridViewTransacciones;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem vistaPreviaToolStripMenuItem;
        private ToolStripMenuItem imprimirToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
    }
}
