namespace SistemaVentas.Entidades
{
    // Clase para agrupar reportes de ventas por region
    public class ReporteRegion
    {
        public string Region { get; set; }
        public int TotalVentas { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal GananciaTotal { get; set; }

        public ReporteRegion()
        {
            Region = "";
        }
    }

    // Clase para agrupar reportes de ventas por tipo de producto
    public class ReporteProducto
    {
        public string TipoProducto { get; set; }
        public int TotalVentas { get; set; }
        public int UnidadesTotales { get; set; }
        public decimal IngresoTotal { get; set; }

        public ReporteProducto()
        {
            TipoProducto = "";
        }
    }
}
