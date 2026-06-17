using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace GestionFarmacia
{
    public class VentaCabecera
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NumeroComprobante { get; set; }
        public Cliente Cliente { get; set; }  // <-- Esta propiedad debe existir
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public BindingList<VentaDetalle> listaVentaDetalle { get; set; }

        public VentaCabecera()
        {
            listaVentaDetalle = new BindingList<VentaDetalle>();
        }
    }
}