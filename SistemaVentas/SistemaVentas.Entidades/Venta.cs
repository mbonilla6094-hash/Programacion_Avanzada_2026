using System;

namespace SistemaVentas.Entidades
{
    // Entidad que representa una venta en la base de datos
    public class Venta
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }
        public string TipoProducto { get; set; }
        public string CanalVenta { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaOrden { get; set; }
        public long OrdenId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal GananciaTotal { get; set; }

        public Venta()
        {
            Region = "";
            Pais = "";
            TipoProducto = "";
            CanalVenta = "";
            Prioridad = "";
        }

        public override string ToString()
        {
            return string.Format("Venta #{0} - {1} | {2} | ${3:N2}", Id, Pais, TipoProducto, IngresoTotal);
        }
    }
}
