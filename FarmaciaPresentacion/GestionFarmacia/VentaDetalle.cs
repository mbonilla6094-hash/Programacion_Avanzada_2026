using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFarmacia
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;

        public decimal Subtotal1 { get; internal set; }
    }
    public class VentaDetalleResumen
    {
        public VentaDetalleResumen(int id, int cantidad, int productoId, string presentacion, string nombreComercial, decimal subtotal)
        {
            Id = id;
            Cantidad = cantidad;
            ProductoId = productoId;
            Presentacion = presentacion;
            NombreComercial = nombreComercial;
            Subtotal = subtotal;
        }

        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public string Presentacion { get; set; }
        public string NombreComercial { get; set; }
        public decimal Subtotal { get; set; }
    }
}
