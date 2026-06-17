using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionFarmacia
{
    public partial class Form_Productos : Form
    {
        

        public Producto SelectedProducto { get; private set; }

        public Form_Productos()
        {
            InitializeComponent();
        }

        private void Form_Productos_Load(object sender, EventArgs e)
        {
            CargarDatosProductosEnDataGrid();
        }

        private void CargarDatosProductosEnDataGrid()
        {
            dataGridView_Productos.DataSource = DevolverListadoDeProductos();
            // Opcional: Ajustar columnas
            dataGridView_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Productos.MultiSelect = false;
            dataGridView_Productos.ReadOnly = true;

            // Ocultar columna Id (mantener si es necesario, la instrucción no lo elimina explícitamente)
            if (dataGridView_Productos.Columns["Id"] != null)
                dataGridView_Productos.Columns["Id"].Visible = false;
        }

        public List<Producto> DevolverListadoDeProductos()
        {
            List<Producto> listaProducto = new List<Producto>();

            listaProducto.Add(new Producto(1, "Orencia 250mg", "Orencia", "Abatacept", "Caja x 1 Vial", 450.00m, 10));
            listaProducto.Add(new Producto(2, "Panadol 500mg", "Panadol", "Paracetamol", "Caja x 100 Tab", 5.50m, 50));
            listaProducto.Add(new Producto(3, "Advil 200mg", "Advil", "Ibuprofeno", "Caja x 50 Cap", 8.20m, 30));
            listaProducto.Add(new Producto(4, "Amoxil 500mg", "Amoxil", "Amoxicilina", "Caja x 20 Cap", 12.00m, 20));
            listaProducto.Add(new Producto(5, "Zyrtec 10mg", "Zyrtec", "Cetirizina", "Caja x 10 Tab", 7.50m, 40));
            listaProducto.Add(new Producto(6, "Nexium 40mg", "Nexium", "Esomeprazol", "Caja x 14 Tab", 25.00m, 15));
            listaProducto.Add(new Producto(7, "Glucophage 850mg", "Glucophage", "Metformina", "Caja x 30 Tab", 10.00m, 60));
            listaProducto.Add(new Producto(8, "Lipitor 20mg", "Lipitor", "Atorvastatina", "Caja x 30 Tab", 35.00m, 25));
            listaProducto.Add(new Producto(9, "Ventolin Inhalador", "Ventolin", "Salbutamol", "Frasco x 200 Dosis", 18.00m, 12));
            listaProducto.Add(new Producto(10, "Aspirina 100mg", "Aspirina", "Ácido Acetilsalicílico", "Caja x 100 Tab", 4.00m, 100));

            return listaProducto;
        }

        private void dataGridView_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedProducto = (Producto)dataGridView_Productos.Rows[e.RowIndex].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}