using Microsoft.ML.Data;

namespace PredictorTarifa.Entidades
{
    // Clase de entrada para el modelo de ML.NET (mapea columnas del CSV)
    public class ViajeML
    {
        [LoadColumn(0)]
        public string Empresa { get; set; }

        [LoadColumn(1)]
        public float CodigoTarifa { get; set; }

        [LoadColumn(2)]
        public float NumeroPasajeros { get; set; }

        [LoadColumn(3)]
        public float DuracionSegundos { get; set; }

        [LoadColumn(4)]
        public float DistanciaMillas { get; set; }

        [LoadColumn(5)]
        public string TipoPago { get; set; }

        // Esta es la columna que el modelo debe predecir (Label)
        [LoadColumn(6)]
        [ColumnName("Label")]
        public float TarifaReal { get; set; }
    }

    // Clase de salida con el resultado de la prediccion del modelo
    public class PrediccionTarifa
    {
        [ColumnName("Score")]
        public float TarifaPredicha { get; set; }
    }
}
