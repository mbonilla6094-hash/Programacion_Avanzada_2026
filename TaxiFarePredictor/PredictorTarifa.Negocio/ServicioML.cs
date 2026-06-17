using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Negocio
{
    // Servicio de Machine Learning: entrena el modelo con el CSV y realiza predicciones
    public class ServicioML
    {
        private readonly MLContext _contextoML;
        private ITransformer _modelo;
        private bool _modeloEntrenado = false;

        // Ruta del archivo CSV de entrenamiento
        private static readonly string RutaCSVEntrenamiento =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "taxi-fare-train.csv");

        public ServicioML()
        {
            _contextoML = new MLContext(seed: 0);
        }

        // Entrena el modelo con el CSV de datos historicos de taxis
        public string EntrenarModelo()
        {
            try
            {
                if (!File.Exists(RutaCSVEntrenamiento))
                    return "ERROR: No se encontro el archivo CSV de entrenamiento en: " + RutaCSVEntrenamiento;

                // Cargar datos del CSV (tiene encabezado, separado por coma)
                var datosEntrenamiento = _contextoML.Data.LoadFromTextFile<ViajeML>(
                    RutaCSVEntrenamiento,
                    hasHeader: true,
                    separatorChar: ','
                );

                // Definir el pipeline de transformacion y algoritmo de regresion
                var pipeline = _contextoML.Transforms
                    .CopyColumns(outputColumnName: "Label", inputColumnName: "Label")
                    .Append(_contextoML.Transforms.Categorical.OneHotEncoding("EmpresaCod", "Empresa"))
                    .Append(_contextoML.Transforms.Categorical.OneHotEncoding("TipoPagoCod", "TipoPago"))
                    .Append(_contextoML.Transforms.Concatenate("Features",
                        "EmpresaCod",
                        "CodigoTarifa",
                        "NumeroPasajeros",
                        "DuracionSegundos",
                        "DistanciaMillas",
                        "TipoPagoCod"
                    ))
                    .Append(_contextoML.Transforms.NormalizeMinMax("Features"))
                    .Append(_contextoML.Regression.Trainers.FastTree());

                // Entrenar el modelo con los datos del CSV
                _modelo = pipeline.Fit(datosEntrenamiento);
                _modeloEntrenado = true;

                // Evaluar la precision del modelo con los datos de entrenamiento
                var predicciones = _modelo.Transform(datosEntrenamiento);
                var metricas = _contextoML.Regression.Evaluate(predicciones, "Label", "Score");

                return string.Format(
                    "Modelo entrenado correctamente.\nR2: {0:P2} | Error Absoluto Medio: ${1:F2} | RMSE: ${2:F2}",
                    metricas.RSquared,
                    metricas.MeanAbsoluteError,
                    metricas.RootMeanSquaredError
                );
            }
            catch (Exception ex)
            {
                return "ERROR al entrenar el modelo: " + ex.Message;
            }
        }

        // Predice la tarifa de un viaje en base a sus datos
        public float PredecirTarifa(ViajeML datosViaje)
        {
            if (!_modeloEntrenado)
                throw new InvalidOperationException("El modelo no ha sido entrenado todavia.");

            var motorPrediccion = _contextoML.Model.CreatePredictionEngine<ViajeML, PrediccionTarifa>(_modelo);
            var resultado = motorPrediccion.Predict(datosViaje);

            // Asegurar que la tarifa predicha no sea negativa
            return Math.Max(0f, resultado.TarifaPredicha);
        }

        public bool EstaEntrenado()
        {
            return _modeloEntrenado;
        }
    }
}
