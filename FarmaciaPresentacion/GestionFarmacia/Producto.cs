// Archivo: Producto.cs
using System;

namespace GestionFarmacia
{
    public class Producto
    {
        public Producto(int id, string nombre, string nombreComercial, string nombreGenerico, string presentacion, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            NombreComercial = nombreComercial;
            NombreGenerico = nombreGenerico;
            Presentacion = presentacion;
            Precio = precio;
            Stock = stock;
        }

        public Producto() { }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public string NombreGenerico { get; set; }
        public string Presentacion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{NombreComercial} ({NombreGenerico})";
        }
    }
}