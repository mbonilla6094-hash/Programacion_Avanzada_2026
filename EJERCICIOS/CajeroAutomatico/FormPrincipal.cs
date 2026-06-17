using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class FormPrincipal : Form
    {
        private Usuario usuarioActual;
        private BindingList<Transaccion> listaTransacciones;
        private Transaccion? ultimaTransaccion;

        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            listaTransacciones = new BindingList<Transaccion>();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            ConfigurarGrid();
            ActualizarStatusBar();
        }

        private void CargarDatosUsuario()
        {
            labelBienvenida.Text = "Bienvenido/a, " + usuarioActual.Nombre;
            labelInfoUsuario.Text = "ID de Usuario: " + usuarioActual.Id;
            ActualizarSaldo();
        }

        private void ActualizarSaldo()
        {
            labelSaldoValor.Text = "$" + usuarioActual.Saldo.ToString("N2");
            this.Text = "Cajero Automatico - Saldo: $" + usuarioActual.Saldo.ToString("N2");
        }

        private void ConfigurarGrid()
        {
            dataGridViewTransacciones.DataSource = listaTransacciones;
            dataGridViewTransacciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ActualizarStatusBar()
        {
            toolStripStatusLabel1.Text = "Usuario: " + usuarioActual.Nombre +
                " | Transacciones: " + listaTransacciones.Count +
                " | " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        // ===================== DEPOSITAR =====================
        private void buttonDepositar_Click(object sender, EventArgs e)
        {
            if (!ValidarMonto(out decimal monto))
                return;

            decimal saldoAnterior = usuarioActual.Saldo;
            usuarioActual.Saldo += monto;

            var transaccion = new Transaccion(
                listaTransacciones.Count + 1,
                "Deposito",
                monto,
                DateTime.Now,
                saldoAnterior,
                usuarioActual.Saldo
            );

            listaTransacciones.Add(transaccion);
            ultimaTransaccion = transaccion;
            ActualizarSaldo();
            ActualizarStatusBar();
            LimpiarMonto();

            MessageBox.Show(
                "Deposito realizado exitosamente\n\n" +
                "Monto depositado: $" + monto.ToString("N2") + "\n" +
                "Saldo anterior: $" + saldoAnterior.ToString("N2") + "\n" +
                "Saldo actual: $" + usuarioActual.Saldo.ToString("N2"),
                "Deposito Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ===================== RETIRAR =====================
        private void buttonRetirar_Click(object sender, EventArgs e)
        {
            if (!ValidarMonto(out decimal monto))
                return;

            // Verificar que el saldo sea suficiente
            if (monto > usuarioActual.Saldo)
            {
                MessageBox.Show(
                    "Fondos insuficientes para realizar el retiro\n\n" +
                    "Monto solicitado: $" + monto.ToString("N2") + "\n" +
                    "Saldo disponible: $" + usuarioActual.Saldo.ToString("N2"),
                    "Fondos Insuficientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Mensaje de confirmacion antes del retiro
            DialogResult confirmacion = MessageBox.Show(
                "Confirmar retiro?\n\n" +
                "Monto a retirar: $" + monto.ToString("N2") + "\n" +
                "Saldo actual: $" + usuarioActual.Saldo.ToString("N2") + "\n" +
                "Saldo despues del retiro: $" + (usuarioActual.Saldo - monto).ToString("N2"),
                "Confirmacion de Retiro",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.OK)
                return;

            decimal saldoAnterior = usuarioActual.Saldo;
            usuarioActual.Saldo -= monto;

            var transaccion = new Transaccion(
                listaTransacciones.Count + 1,
                "Retiro",
                monto,
                DateTime.Now,
                saldoAnterior,
                usuarioActual.Saldo
            );

            listaTransacciones.Add(transaccion);
            ultimaTransaccion = transaccion;
            ActualizarSaldo();
            ActualizarStatusBar();
            LimpiarMonto();

            MessageBox.Show(
                "Retiro realizado exitosamente\n\n" +
                "Monto retirado: $" + monto.ToString("N2") + "\n" +
                "Saldo anterior: $" + saldoAnterior.ToString("N2") + "\n" +
                "Saldo actual: $" + usuarioActual.Saldo.ToString("N2"),
                "Retiro Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ===================== VALIDACIONES =====================
        private bool ValidarMonto(out decimal monto)
        {
            monto = 0;

            if (string.IsNullOrWhiteSpace(textBoxMonto.Text))
            {
                MessageBox.Show("Ingrese un monto para la operacion",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMonto.Focus();
                return false;
            }

            if (!decimal.TryParse(textBoxMonto.Text.Trim(), out monto))
            {
                MessageBox.Show("El monto debe ser un valor numerico valido",
                    "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMonto.Focus();
                return false;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero. No se permiten valores negativos ni cero",
                    "Monto invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMonto.Text = string.Empty;
                textBoxMonto.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarMonto()
        {
            textBoxMonto.Text = string.Empty;
            textBoxMonto.Focus();
        }

        // ===================== CERRAR SESION =====================
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la sesion actual?",
                "Cerrar Sesion", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        // ===================== FACTURA / IMPRESION =====================
        private string GenerarNumeroComprobante()
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            int numero = random.Next(1000, 9999);
            return "TRX-" + fecha + "-" + numero;
        }

        private void vistaPreviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultimaTransaccion == null)
            {
                MessageBox.Show("No hay transacciones para mostrar",
                    "Sin transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultimaTransaccion == null)
            {
                MessageBox.Show("No hay transacciones para imprimir",
                    "Sin transacciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            printDocument1.DocumentName = "Comprobante-Cajero";
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null || ultimaTransaccion == null) return;

            string numComprobante = GenerarNumeroComprobante();

            Pen penBlack = new Pen(Color.Black, 2);
            Rectangle rectangle = new Rectangle(50, 50, 700, 600);
            e.Graphics.DrawRectangle(penBlack, rectangle);

            Font fuenteTitulo = new Font("Arial", 14, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Arial", 11, FontStyle.Bold);
            Font fuenteNormal = new Font("Arial", 10);
            Font fuenteDetalle = new Font("Arial", 9);

            StringFormat formatoDerecha = new StringFormat();
            formatoDerecha.Alignment = StringAlignment.Far;

            int y = 70;

            // Titulo
            e.Graphics.DrawString("CAJERO AUTOMATICO", fuenteTitulo, Brushes.Black, 280, y);
            y += 30;
            e.Graphics.DrawString("COMPROBANTE DE TRANSACCION", fuenteSubtitulo, Brushes.Black, 250, y);
            y += 40;

            // Numero de comprobante
            e.Graphics.DrawString("N COMPROBANTE: " + numComprobante, fuenteNormal, Brushes.Black, 60, y);
            y += 25;

            // Fecha
            e.Graphics.DrawString("FECHA: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), fuenteNormal, Brushes.Black, 60, y);
            y += 35;

            // Linea separadora
            e.Graphics.DrawLine(penBlack, 60, y, 740, y);
            y += 15;

            // Datos del usuario
            e.Graphics.DrawString("DATOS DEL USUARIO", fuenteSubtitulo, Brushes.Black, 60, y);
            y += 25;
            e.Graphics.DrawString("Nombre: " + usuarioActual.Nombre, fuenteNormal, Brushes.Black, 70, y);
            y += 22;
            e.Graphics.DrawString("ID: " + usuarioActual.Id, fuenteNormal, Brushes.Black, 70, y);
            y += 35;

            // Linea separadora
            e.Graphics.DrawLine(penBlack, 60, y, 740, y);
            y += 15;

            // Detalle de la transaccion
            e.Graphics.DrawString("DETALLE DE OPERACION", fuenteSubtitulo, Brushes.Black, 60, y);
            y += 30;

            e.Graphics.DrawString("Tipo de Operacion:", fuenteNormal, Brushes.Black, 70, y);
            e.Graphics.DrawString(ultimaTransaccion.Tipo.ToUpper(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 250, y);
            y += 25;

            e.Graphics.DrawString("Monto:", fuenteNormal, Brushes.Black, 70, y);
            e.Graphics.DrawString("$" + ultimaTransaccion.Monto.ToString("N2"), fuenteNormal, Brushes.Black, 250, y);
            y += 25;

            e.Graphics.DrawString("Saldo Anterior:", fuenteNormal, Brushes.Black, 70, y);
            e.Graphics.DrawString("$" + ultimaTransaccion.SaldoAnterior.ToString("N2"), fuenteNormal, Brushes.Black, 250, y);
            y += 25;

            e.Graphics.DrawString("Saldo Actual:", fuenteNormal, Brushes.Black, 70, y);
            e.Graphics.DrawString("$" + ultimaTransaccion.SaldoNuevo.ToString("N2"), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 250, y);
            y += 40;

            // Linea separadora
            e.Graphics.DrawLine(penBlack, 60, y, 740, y);
            y += 20;

            // Resumen de todas las transacciones
            e.Graphics.DrawString("HISTORIAL DE TRANSACCIONES", fuenteSubtitulo, Brushes.Black, 60, y);
            y += 25;

            // Cabeceras
            e.Graphics.DrawString("N", fuenteSubtitulo, Brushes.Black, 70, y);
            e.Graphics.DrawString("Tipo", fuenteSubtitulo, Brushes.Black, 110, y);
            e.Graphics.DrawString("Monto", fuenteSubtitulo, Brushes.Black, 250, y);
            e.Graphics.DrawString("Saldo Ant.", fuenteSubtitulo, Brushes.Black, 400, y);
            e.Graphics.DrawString("Saldo Nvo.", fuenteSubtitulo, Brushes.Black, 550, y);
            y += 20;
            e.Graphics.DrawLine(penBlack, 60, y, 740, y);
            y += 8;

            foreach (var trx in listaTransacciones)
            {
                if (y > 580) break;
                e.Graphics.DrawString(trx.Id.ToString(), fuenteDetalle, Brushes.Black, 70, y);
                e.Graphics.DrawString(trx.Tipo, fuenteDetalle, Brushes.Black, 110, y);
                e.Graphics.DrawString("$" + trx.Monto.ToString("N2"), fuenteDetalle, Brushes.Black, 250, y);
                e.Graphics.DrawString("$" + trx.SaldoAnterior.ToString("N2"), fuenteDetalle, Brushes.Black, 400, y);
                e.Graphics.DrawString("$" + trx.SaldoNuevo.ToString("N2"), fuenteDetalle, Brushes.Black, 550, y);
                y += 18;
            }

            y += 30;

            // Mensaje de agradecimiento
            e.Graphics.DrawString("Gracias por usar nuestro cajero automatico", fuenteNormal, Brushes.DarkGray, 250, y);

            // Liberar recursos
            penBlack.Dispose();
            fuenteTitulo.Dispose();
            fuenteSubtitulo.Dispose();
            fuenteNormal.Dispose();
            fuenteDetalle.Dispose();
            formatoDerecha.Dispose();
        }
    }
}
