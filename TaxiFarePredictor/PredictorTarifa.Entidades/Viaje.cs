using System;

namespace PredictorTarifa.Entidades
{
    // Entidad principal que representa un viaje guardado en la base de datos
    public class Viaje
    {
        public int Id { get; set; }

        // Empresa de taxis (CMT o VTS)
        public string Empresa { get; set; }

        // Codigo de tarifa aplicada
        public float CodigoTarifa { get; set; }

        // Numero de pasajeros en el viaje
        public float NumeroPasajeros { get; set; }

        // Duracion del viaje en segundos
        public float DuracionSegundos { get; set; }

        // Distancia del viaje en millas
        public float DistanciaMillas { get; set; }

        // Tipo de pago (CRD = Tarjeta, CSH = Efectivo)
        public string TipoPago { get; set; }

        // Tarifa real del viaje en dolares
        public float TarifaReal { get; set; }

        // Tarifa que predijo el modelo de ML
        public float TarifaPredicha { get; set; }

        // Fecha y hora en que se registro el viaje
        public DateTime FechaRegistro { get; set; }
    }
}
