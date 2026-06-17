using System;

namespace AnalisisVehiculos
{
    public class VentaVehiculo
    {
        public int Anio { get; set; }
        public int Periodo { get; set; }
        public string Vehiculo { get; set; } = string.Empty;
        public int UnidadesVendidas { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Creditos { get; set; }

        public VentaVehiculo() { }

        public VentaVehiculo(int anio, int periodo, string vehiculo,
                            int unidadesVendidas, decimal montoTotal, decimal creditos)
        {
            Anio = anio;
            Periodo = periodo;
            Vehiculo = vehiculo;
            UnidadesVendidas = unidadesVendidas;
            MontoTotal = montoTotal;
            Creditos = creditos;
        }

        public override string ToString()
        {
            return Vehiculo + " (" + Anio + " - P" + Periodo + ")";
        }
    }
}
