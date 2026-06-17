using QRCoder;
using BarcodeLib;
using System.Drawing;

namespace GestionFarmacia
{
    public partial class Form1 : Form
    {
        VentaCabecera venta = new VentaCabecera();
        Producto productoActual;

        public Form1()
        {
            InitializeComponent();
            ConfigurarGrid();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MostarDatosStatusTrip();

            GenerarNumeroComprobante();
        }
        private void ConfigurarGrid()
        {
            dataGridView1.DataSource = venta.listaVentaDetalle;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void CargarDatosClientePantalla(Cliente cliente)
        {
            textBox_Apellido.Text = cliente.Apellidos.ToUpper();
            textBox_Nombre.Text = cliente.Nombres.ToUpper();
            textBox_Direccion.Text = cliente.Direccion;
            textBox_CedulaRuc.Text = cliente.Cedula;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void GenerarNumeroComprobante()
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            int numero = random.Next(1000, 9999);

            venta.NumeroComprobante = "FAC-" + fecha + "-" + numero;
            labelNumeroComprobanteValor.Text = venta.NumeroComprobante;
        }

        private string ObtenerConsecutivo()
        {
            Random aleatorio = new Random();
            int numero = aleatorio.Next(1000, 9999);
            return numero.ToString();
        }

        private void BuscarClientePorCedulaRuc(string cedulaRuc)
        {
            Boolean resultado = false;
            foreach (var item in ObtenerTodos())
            {
                if (item.Cedula.Trim().Equals(cedulaRuc.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                  
                    venta.Cliente = item;

                  
                    textBox_Nombre.Text = item.Nombres;
                    textBox_Apellido.Text = item.Apellidos;
                    textBox_Telefono.Text = item.Telefono;
                    textBox_Direccion.Text = item.Direccion;
                    textBox_Correo.Text = item.Correo;

                    resultado = true;
                    return;
                }
            }
            if (!resultado)
            {
                MessageBox.Show("No se encontraron resultados",
                                "Sin coincidencias",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //Encerar Datos de los controles
                EncerarDatosenControles();
                //Apuntar el cursor
                textBox_CedulaRuc.Focus();
            }
        }

        private void EncerarDatosenControles()
        {
            textBox_CedulaRuc.Text = string.Empty;
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
            textBox_Telefono.Text = "";
            textBox_Direccion.Text = string.Empty;
            textBox_Correo.Text = string.Empty;
        }

        public List<Cliente> ObtenerTodos()
        {
            return new List<Cliente>
    {
        new Cliente(1, "Bonilla", "Mateo", "1850116094", "0995909727", "Ambato", "mbonilla6094@uta.edu.ec"),
        new Cliente(2, "Rodríguez", "Ana", "1705123456", "0998123456", "Quito", "ana.rodriguez@gmail.com"),
        new Cliente(3, "Gómez", "Carlos", "0912345678", "0987654321", "Guayaquil", "carlos.gomez@outlook.com"),
        new Cliente(4, "López", "María", "1309876543", "0999876543", "Cuenca", "maria.lopez@yahoo.com"),
        new Cliente(5, "Martínez", "José", "1801234567", "0981234567", "Santo Domingo", "jose.martinez@hotmail.com"),
        new Cliente(6, "Fernández", "Laura", "1009876543", "0998765432", "Machala", "laura.fernandez@gmail.com"),
        new Cliente(7, "Sánchez", "Pedro", "1401234567", "0987654321", "Manta", "pedro.sanchez@outlook.com"),
        new Cliente(8, "Pérez", "Isabel", "1509876543", "0991234567", "Portoviejo", "isabel.perez@yahoo.com"),
        new Cliente(9, "Ramírez", "Andrés", "1601234567", "0987654321", "Loja", "andres.ramirez@gmail.com"),
        new Cliente(10, "Castro", "Sofía", "1909876543", "0999876543", "Ibarra", "sofia.castro@hotmail.com"),
        new Cliente(11, "Ortiz", "Javier", "2001234567", "0987654321", "Riobamba", "javier.ortiz@outlook.com"),
        new Cliente(12, "Morales", "Daniela", "2109876543", "0991234567", "Esmeraldas", "daniela.morales@gmail.com")
    };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BuscarClientePorCedulaRuc(textBox_CedulaRuc.Text);
        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {
            LLamarFormularioProductos();

        }

        private void LLamarFormularioProductos()
        {
            using (Form_Productos form_productos = new Form_Productos())
            {
                if (form_productos.ShowDialog() == DialogResult.OK)
                {
                    productoActual = form_productos.SelectedProducto;
                    if (productoActual != null)
                    {
                        textBox_Comercial.Text = productoActual.NombreComercial;
                        textBox_Generico.Text = productoActual.NombreGenerico;
                        textBox_Presentacion.Text = productoActual.Presentacion;
                        textBox_Precio.Text = productoActual.Precio.ToString("N2");
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ValidarCantidad())
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productoActual != null)
            {
                if (!int.TryParse(textBoxCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número entero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var detalle = new VentaDetalle
                {
                    Id = venta.listaVentaDetalle.Count + 1,
                    ProductoId = productoActual.Id,
                    NombreProducto = productoActual.NombreComercial,
                    Precio = productoActual.Precio,
                    Cantidad = cantidad
                };
                venta.listaVentaDetalle.Add(detalle);
                CalculatMontos();
            }
            else
            {
                MessageBox.Show("Seleccione un producto primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculatMontos()
        {
            CalcularSubTotal();
            CalcularIva();
            CalcularTotal();
        }

        private decimal ObtenerSubtotalActual()
        {
            decimal subtotal = 0;
            foreach (var item in venta.listaVentaDetalle)
            {
                subtotal += item.Subtotal;
            }
            return subtotal;
        }

        private void CalcularSubTotal()
        {
            decimal subtotal = ObtenerSubtotalActual();
            textBox2.Text = subtotal.ToString("N2");
        }

        private void MostarDatosStatusTrip()
        {
            try
            {
                toolStripStatusLabel1.Text = "Autor: " + Properties.Settings.Default.autor + " | ";
                toolStripStatusLabel2.Text = "Version: " + Properties.Settings.Default.version + " | ";
                toolStripStatusLabel3.Text = "Fecha de Publicacion: " + Properties.Settings.Default.FechaPublicacion.ToString("dd/MM/yyyy") + " | ";
                toolStripStatusLabel4.Text = "Contacto: " + Properties.Settings.Default.contactoSoporte;
            }
            catch { }
        }

        private void CalcularIva()
        {
            decimal subtotal = ObtenerSubtotalActual();
            decimal iva = subtotal * (decimal)Properties.Settings.Default.IVA;
            textBox1.Text = iva.ToString("N2");
        }

        bool ValidarCantidad()
        {
            if (string.IsNullOrWhiteSpace(textBoxCantidad.Text) || textBoxCantidad.Text.Trim() == "0")
            {
                return true;
            }
            return false;
        }

        private void CalcularTotal()
        {
            decimal subtotal = ObtenerSubtotalActual();
            decimal iva = subtotal * (decimal)Properties.Settings.Default.IVA;
            decimal total = subtotal + iva;

            textBox_SubTotal.Text = total.ToString("N2");
            this.Text = "Venta de Productos - Total: $" + total.ToString("N2");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFechaVenta_ValueChanged(object sender, EventArgs e)
        {
            venta.FechaVenta = dateTimePickerFechaVenta.Value;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalirAplicacion();
        }

        private void SalirAplicacion()
        {
            if (MessageBox.Show("Desea Salir de la aplicacion", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Comprobante-" + venta.NumeroComprobante;
            printPreviewDialog1.Document = printDocument1;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Pen penBlack = new Pen(Color.Black, 2);
            Rectangle rectangle = new Rectangle(50, 50, 700, 900);
            e.Graphics.DrawRectangle(penBlack, rectangle);
            Font fuenteCabecera = new Font("Arial", 12, FontStyle.Bold);
            Font fuenteCabecera2 = new Font("Arial", 10, FontStyle.Bold);
            Font fuenteNormal = new Font("Arial", 9);

            int y = 70;

            // Título
            e.Graphics.DrawString("FARMACIA", fuenteCabecera, Brushes.Black, 350, y);
            y += 30;
            e.Graphics.DrawString("DETALLE DE VENTA", fuenteCabecera2, Brushes.Black, 360, y);
            y += 40;

            // Número de comprobante
            e.Graphics.DrawString("N° COMPROBANTE: " + venta.NumeroComprobante, fuenteNormal, Brushes.Black, 60, y);
            y += 25;

            // Fecha
            e.Graphics.DrawString("FECHA: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteNormal, Brushes.Black, 60, y);
            y += 35;

            // Datos del cliente
            if (venta.Cliente != null)
            {
                e.Graphics.DrawString("DATOS DEL CLIENTE", fuenteCabecera2, Brushes.Black, 60, y);
                y += 25;
                e.Graphics.DrawString("Cliente: " + venta.Cliente.NombreCompleto(), fuenteNormal, Brushes.Black, 70, y);
                y += 20;
                e.Graphics.DrawString("Cédula: " + venta.Cliente.Cedula, fuenteNormal, Brushes.Black, 70, y);
                y += 20;
                e.Graphics.DrawString("Teléfono: " + venta.Cliente.Telefono, fuenteNormal, Brushes.Black, 70, y);
                y += 20;
                e.Graphics.DrawString("Correo: " + venta.Cliente.Correo, fuenteNormal, Brushes.Black, 70, y);
                y += 20;
                e.Graphics.DrawString("Dirección: " + venta.Cliente.Direccion, fuenteNormal, Brushes.Black, 70, y);
            }
            else
            {
                e.Graphics.DrawString("Cliente: No seleccionado", fuenteNormal, Brushes.Red, 60, y);
            }

            y += 35;

            // Línea separadora
            e.Graphics.DrawLine(penBlack, 60, y, 740, y);
            y += 15;

            // Cabeceras de productos
            e.Graphics.DrawString("Cant.", fuenteCabecera2, Brushes.Black, 60, y);
            e.Graphics.DrawString("Producto", fuenteCabecera2, Brushes.Black, 120, y);
            e.Graphics.DrawString("Precio", fuenteCabecera2, Brushes.Black, 450, y);
            e.Graphics.DrawString("Subtotal", fuenteCabecera2, Brushes.Black, 600, y);
            y += 20;

            // Línea separadora
            e.Graphics.DrawLine(penBlack, 60, y, 740, y);
            y += 10;

            // Detalle de productos
            Font fuenteDetalle = new Font("Arial", 8);
            StringFormat stringFormatDerecha = new StringFormat();
            stringFormatDerecha.Alignment = StringAlignment.Far;

            foreach (var detalle in venta.listaVentaDetalle)
            {
                e.Graphics.DrawString(detalle.Cantidad.ToString(), fuenteDetalle, Brushes.Black, 60, y);
                e.Graphics.DrawString(detalle.NombreProducto, fuenteDetalle, Brushes.Black, 120, y);
                e.Graphics.DrawString("$" + detalle.Precio.ToString("N2"), fuenteDetalle, Brushes.Black, new RectangleF(400, y, 90, 20), stringFormatDerecha);
                e.Graphics.DrawString("$" + detalle.Subtotal.ToString("N2"), fuenteDetalle, Brushes.Black, new RectangleF(550, y, 90, 20), stringFormatDerecha);
                y += 18;
            }

            y += 20;

            // Totales
            decimal subtotal = ObtenerSubtotalActual();
            decimal iva = subtotal * (decimal)Properties.Settings.Default.IVA;
            decimal total = subtotal + iva;

            e.Graphics.DrawString("Subtotal:", fuenteNormal, Brushes.Black, 500, y);
            e.Graphics.DrawString("$" + subtotal.ToString("N2"), fuenteNormal, Brushes.Black, new RectangleF(545, y, 95, 20), stringFormatDerecha);
            y += 20;

            e.Graphics.DrawString("IVA (12%):", fuenteNormal, Brushes.Black, 500, y);
            e.Graphics.DrawString("$" + iva.ToString("N2"), fuenteNormal, Brushes.Black, new RectangleF(545, y, 95, 20), stringFormatDerecha);
            y += 20;

            e.Graphics.DrawString("TOTAL:", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 500, y);
            e.Graphics.DrawString("$" + total.ToString("N2"), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new RectangleF(545, y, 95, 20), stringFormatDerecha);
            y += 40;

            try
            {
                Barcode barcode = new Barcode();
                barcode.IncludeLabel = true;
                Image imgBarcode = barcode.Encode(TYPE.CODE128, venta.NumeroComprobante, Color.Black, Color.Transparent, 250, 60);
                e.Graphics.DrawImage(imgBarcode, 60, y);

                string urlGoogleSites = "https://sites.google.com/view/mifarmacia/inicio?comprobante=" + venta.NumeroComprobante;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(urlGoogleSites, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(3);
                e.Graphics.DrawImage(qrCodeImage, 500, y);

                y += 80;
            }
            catch (Exception ex)
            {
                e.Graphics.DrawString("Error generando códigos: " + ex.Message, fuenteDetalle, Brushes.Red, 60, y);
                y += 20;
            }

            // Mensaje de agradecimiento
            y += 20;
            e.Graphics.DrawString("¡Gracias por su compra!", fuenteNormal, Brushes.DarkGray, 330, y);

            // Liberar recursos
            penBlack.Dispose();
            fuenteCabecera.Dispose();
            fuenteCabecera2.Dispose();
            fuenteNormal.Dispose();
            fuenteDetalle.Dispose();
        }

        private void vistaPreviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           printPreviewDialog1.Document=printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
