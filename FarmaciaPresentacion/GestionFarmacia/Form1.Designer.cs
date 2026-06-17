namespace GestionFarmacia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBox_Telefono = new TextBox();
            textBox_Direccion = new TextBox();
            textBox_Correo = new TextBox();
            textBox_Apellido = new TextBox();
            textBox_Nombre = new TextBox();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox_CedulaRuc = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            textBox2 = new TextBox();
            label15 = new Label();
            textBoxCantidad = new TextBox();
            textBox1 = new TextBox();
            label12 = new Label();
            label14 = new Label();
            pictureBox2 = new PictureBox();
            textBox_SubTotal = new TextBox();
            textBox_Precio = new TextBox();
            label13 = new Label();
            label11 = new Label();
            textBox_Presentacion = new TextBox();
            label10 = new Label();
            textBox_Generico = new TextBox();
            label8 = new Label();
            textBox_Comercial = new TextBox();
            label9 = new Label();
            buttonProductos = new Button();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            groupBox3 = new GroupBox();
            labelNumeroComprobanteValor = new Label();
            labelNumeroComprobanteTitulo = new Label();
            dateTimePickerFechaVenta = new DateTimePicker();
            labelFechaVenta = new Label();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            herramientaToolStripMenuItem = new ToolStripMenuItem();
            imprimirToolStripMenuItem = new ToolStripMenuItem();
            vistaPreviaToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Location = new Point(6, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 10);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(268, 35);
            label1.Name = "label1";
            label1.Size = new Size(280, 36);
            label1.TabIndex = 1;
            label1.Text = "Venta de Productos";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox_Telefono);
            groupBox1.Controls.Add(textBox_Direccion);
            groupBox1.Controls.Add(textBox_Correo);
            groupBox1.Controls.Add(textBox_Apellido);
            groupBox1.Controls.Add(textBox_Nombre);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox_CedulaRuc);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(6, 192);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 158);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox_Telefono
            // 
            textBox_Telefono.Location = new Point(461, 33);
            textBox_Telefono.Name = "textBox_Telefono";
            textBox_Telefono.Size = new Size(169, 23);
            textBox_Telefono.TabIndex = 17;
            // 
            // textBox_Direccion
            // 
            textBox_Direccion.Location = new Point(461, 70);
            textBox_Direccion.Name = "textBox_Direccion";
            textBox_Direccion.Size = new Size(169, 23);
            textBox_Direccion.TabIndex = 16;
            // 
            // textBox_Correo
            // 
            textBox_Correo.Location = new Point(461, 112);
            textBox_Correo.Name = "textBox_Correo";
            textBox_Correo.Size = new Size(169, 23);
            textBox_Correo.TabIndex = 15;
            // 
            // textBox_Apellido
            // 
            textBox_Apellido.Location = new Point(145, 112);
            textBox_Apellido.Name = "textBox_Apellido";
            textBox_Apellido.Size = new Size(169, 23);
            textBox_Apellido.TabIndex = 12;
            // 
            // textBox_Nombre
            // 
            textBox_Nombre.Location = new Point(145, 78);
            textBox_Nombre.Name = "textBox_Nombre";
            textBox_Nombre.Size = new Size(169, 23);
            textBox_Nombre.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(653, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(398, 115);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 10;
            label5.Text = "Correo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(398, 78);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 8;
            label6.Text = "Direccion";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(398, 38);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 6;
            label7.Text = "Telefono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 118);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 4;
            label4.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 81);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombres";
            // 
            // textBox_CedulaRuc
            // 
            textBox_CedulaRuc.Location = new Point(145, 38);
            textBox_CedulaRuc.Name = "textBox_CedulaRuc";
            textBox_CedulaRuc.Size = new Size(169, 23);
            textBox_CedulaRuc.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 41);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 0;
            label2.Text = "Cedula";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(textBoxCantidad);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Controls.Add(textBox_SubTotal);
            groupBox2.Controls.Add(textBox_Precio);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(textBox_Presentacion);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBox_Generico);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBox_Comercial);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(buttonProductos);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(6, 356);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(783, 287);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos deVenta";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(128, 252);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 16;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(50, 255);
            label15.Name = "label15";
            label15.Size = new Size(51, 15);
            label15.TabIndex = 15;
            label15.Text = "Subtotal";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(128, 89);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(169, 23);
            textBoxCantidad.TabIndex = 26;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(347, 252);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 14;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 92);
            label12.Name = "label12";
            label12.Size = new Size(55, 15);
            label12.TabIndex = 25;
            label12.Text = "Cantidad";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(262, 260);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 13;
            label14.Text = "Iva(15%)";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(695, 45);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 18);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // textBox_SubTotal
            // 
            textBox_SubTotal.Location = new Point(546, 249);
            textBox_SubTotal.Name = "textBox_SubTotal";
            textBox_SubTotal.Size = new Size(100, 23);
            textBox_SubTotal.TabIndex = 12;
            // 
            // textBox_Precio
            // 
            textBox_Precio.Location = new Point(429, 55);
            textBox_Precio.Name = "textBox_Precio";
            textBox_Precio.Size = new Size(169, 23);
            textBox_Precio.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(477, 255);
            label13.Name = "label13";
            label13.Size = new Size(33, 15);
            label13.TabIndex = 11;
            label13.Text = "Total";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(315, 60);
            label11.Name = "label11";
            label11.Size = new Size(40, 15);
            label11.TabIndex = 23;
            label11.Text = "Precio\r\n";
            // 
            // textBox_Presentacion
            // 
            textBox_Presentacion.Location = new Point(128, 57);
            textBox_Presentacion.Name = "textBox_Presentacion";
            textBox_Presentacion.Size = new Size(169, 23);
            textBox_Presentacion.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 58);
            label10.Name = "label10";
            label10.Size = new Size(75, 15);
            label10.TabIndex = 21;
            label10.Text = "Presentacion";
            // 
            // textBox_Generico
            // 
            textBox_Generico.Location = new Point(429, 22);
            textBox_Generico.Name = "textBox_Generico";
            textBox_Generico.Size = new Size(169, 23);
            textBox_Generico.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(315, 25);
            label8.Name = "label8";
            label8.Size = new Size(101, 15);
            label8.TabIndex = 20;
            label8.Text = "Nombre Generico";
            label8.Click += label8_Click;
            // 
            // textBox_Comercial
            // 
            textBox_Comercial.Location = new Point(128, 22);
            textBox_Comercial.Name = "textBox_Comercial";
            textBox_Comercial.Size = new Size(169, 23);
            textBox_Comercial.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 25);
            label9.Name = "label9";
            label9.Size = new Size(108, 15);
            label9.TabIndex = 19;
            label9.Text = "Nombre Comercial";
            // 
            // buttonProductos
            // 
            buttonProductos.Location = new Point(674, 13);
            buttonProductos.Name = "buttonProductos";
            buttonProductos.Size = new Size(78, 27);
            buttonProductos.TabIndex = 1;
            buttonProductos.Text = "Productos";
            buttonProductos.UseVisualStyleBackColor = true;
            buttonProductos.Click += buttonProductos_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(770, 127);
            dataGridView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel4 });
            statusStrip1.Location = new Point(0, 444);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(0, 17);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(labelNumeroComprobanteValor);
            groupBox3.Controls.Add(labelNumeroComprobanteTitulo);
            groupBox3.Controls.Add(dateTimePickerFechaVenta);
            groupBox3.Controls.Add(labelFechaVenta);
            groupBox3.Location = new Point(6, 104);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 82);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "DetalleVenta";
            // 
            // labelNumeroComprobanteValor
            // 
            labelNumeroComprobanteValor.AutoSize = true;
            labelNumeroComprobanteValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNumeroComprobanteValor.ForeColor = Color.Red;
            labelNumeroComprobanteValor.Location = new Point(440, 27);
            labelNumeroComprobanteValor.Name = "labelNumeroComprobanteValor";
            labelNumeroComprobanteValor.Size = new Size(74, 15);
            labelNumeroComprobanteValor.TabIndex = 21;
            labelNumeroComprobanteValor.Text = "FAC-000000";
            // 
            // labelNumeroComprobanteTitulo
            // 
            labelNumeroComprobanteTitulo.AutoSize = true;
            labelNumeroComprobanteTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelNumeroComprobanteTitulo.Location = new Point(320, 27);
            labelNumeroComprobanteTitulo.Name = "labelNumeroComprobanteTitulo";
            labelNumeroComprobanteTitulo.Size = new Size(103, 15);
            labelNumeroComprobanteTitulo.TabIndex = 20;
            labelNumeroComprobanteTitulo.Text = "N° Comprobante:";
            // 
            // dateTimePickerFechaVenta
            // 
            dateTimePickerFechaVenta.Location = new Point(97, 23);
            dateTimePickerFechaVenta.Name = "dateTimePickerFechaVenta";
            dateTimePickerFechaVenta.Size = new Size(200, 23);
            dateTimePickerFechaVenta.TabIndex = 19;
            dateTimePickerFechaVenta.Value = new DateTime(2026, 4, 1, 8, 8, 51, 0);
            dateTimePickerFechaVenta.ValueChanged += dateTimePickerFechaVenta_ValueChanged;
            // 
            // labelFechaVenta
            // 
            labelFechaVenta.AutoSize = true;
            labelFechaVenta.Location = new Point(14, 29);
            labelFechaVenta.Name = "labelFechaVenta";
            labelFechaVenta.Size = new Size(70, 15);
            labelFechaVenta.TabIndex = 18;
            labelFechaVenta.Text = "Fecha Venta";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, herramientaToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // herramientaToolStripMenuItem
            // 
            herramientaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { imprimirToolStripMenuItem, vistaPreviaToolStripMenuItem });
            herramientaToolStripMenuItem.Name = "herramientaToolStripMenuItem";
            herramientaToolStripMenuItem.Size = new Size(85, 20);
            herramientaToolStripMenuItem.Text = "Herramienta";
            // 
            // imprimirToolStripMenuItem
            // 
            imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            imprimirToolStripMenuItem.Size = new Size(180, 22);
            imprimirToolStripMenuItem.Text = "Imprimir";
            imprimirToolStripMenuItem.Click += imprimirToolStripMenuItem_Click;
            // 
            // vistaPreviaToolStripMenuItem
            // 
            vistaPreviaToolStripMenuItem.Name = "vistaPreviaToolStripMenuItem";
            vistaPreviaToolStripMenuItem.Size = new Size(180, 22);
            vistaPreviaToolStripMenuItem.Text = "Vista Previa";
            vistaPreviaToolStripMenuItem.Click += vistaPreviaToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 466);
            Controls.Add(groupBox3);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox_CedulaRuc;
        private TextBox textBox_Nombre;
        private TextBox textBox_Apellido;
        private TextBox textBox_Telefono;
        private TextBox textBox_Direccion;
        private TextBox textBox_Correo;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private Button buttonProductos;
        private DataGridView dataGridView1;
        private Label label8;
        private TextBox textBox_Comercial;
        private Label label9;
        private PictureBox pictureBox2;
        private TextBox textBox_Precio;
        private Label label11;
        private TextBox textBox_Presentacion;
        private Label label10;
        private TextBox textBox_Generico;
        private TextBox textBoxCantidad;
        private Label label12;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBox1;
        private Label label14;
        private TextBox textBox_SubTotal;
        private Label label13;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePickerFechaVenta;
        private Label labelFechaVenta;
        private Label labelNumeroComprobanteTitulo;
        internal Label labelNumeroComprobanteValor;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem herramientaToolStripMenuItem;
        private ToolStripMenuItem imprimirToolStripMenuItem;
        private ToolStripMenuItem vistaPreviaToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
    }
}