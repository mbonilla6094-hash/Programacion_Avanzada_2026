using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using SistemaVentas.Entidades;

namespace SistemaVentas.LogicaNegocio
{
    // Clase que mapea los datos de entrada para la IA
    public class DatosVentaML
    {
        [LoadColumn(0)] public string Region { get; set; }
        [LoadColumn(1)] public string Pais { get; set; }
        [LoadColumn(2)] public string TipoProducto { get; set; }
        [LoadColumn(3)] public float UnidadesVendidas { get; set; }
    }

    // Clase que recibe la prediccion de la IA
    public class PrediccionVentaML
    {
        [ColumnName("Score")]
        public float UnidadesProyectadas { get; set; }
    }

    // Motor principal de Inteligencia Artificial
    public class PredictorVentas
    {
        private readonly MLContext _mlContext;
        private ITransformer _modelo;

        public PredictorVentas()
        {
            _mlContext = new MLContext(seed: 0);
        }

        public void EntrenarModelo(List<Venta> datosHistoricos)
        {
            // Convertir las ventas de ADO.NET a la estructura de la IA
            var datos = datosHistoricos.Select(v => new DatosVentaML
            {
                Region = v.Region,
                Pais = v.Pais,
                TipoProducto = v.TipoProducto,
                UnidadesVendidas = (float)v.UnidadesVendidas
            });

            // Cargar los 10,000 registros a la memoria del algoritmo
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(datos);

            // Pipeline: Codificar textos y usar regresion con FastTree
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding(new[]
                {
                    new InputOutputColumnPair("RegionEncoded", "Region"),
                    new InputOutputColumnPair("PaisEncoded", "Pais"),
                    new InputOutputColumnPair("TipoProductoEncoded", "TipoProducto")
                })
                .Append(_mlContext.Transforms.Concatenate("Features", "RegionEncoded", "PaisEncoded", "TipoProductoEncoded"))
                .Append(_mlContext.Regression.Trainers.FastTree(labelColumnName: "UnidadesVendidas", featureColumnName: "Features"));

            // ¡Entrenamiento!
            _modelo = pipeline.Fit(dataView);
        }

        public float Predecir(string region, string pais, string producto)
        {
            if (_modelo == null) throw new Exception("El modelo no ha sido entrenado aun.");

            var engine = _mlContext.Model.CreatePredictionEngine<DatosVentaML, PrediccionVentaML>(_modelo);
            var entrada = new DatosVentaML { Region = region, Pais = pais, TipoProducto = producto };
            
            // Prediccion matematica real
            var prediccion = engine.Predict(entrada);
            return prediccion.UnidadesProyectadas;
        }
    }
}
