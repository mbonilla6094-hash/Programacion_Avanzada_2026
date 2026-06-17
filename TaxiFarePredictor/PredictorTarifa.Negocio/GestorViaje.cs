using System;
using System.Collections.Generic;
using PredictorTarifa.Datos;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Negocio
{
    // Gestor de viajes: orquesta la logica entre la Vista, el Servicio ML y el Repositorio de datos
    public class GestorViaje
    {
        private readonly ServicioML _servicioML;
        private readonly RepositorioViaje _repositorioViaje;

        public GestorViaje()
        {
            _servicioML = new ServicioML();
            _repositorioViaje = new RepositorioViaje();
        }

        // Entrena el modelo de ML con el CSV historico
        public string EntrenarModelo()
        {
            return _servicioML.EntrenarModelo();
        }

        // Predice la tarifa y guarda el viaje en la base de datos SQL Server
        public ResultadoOperacion PredecirYGuardar(
            string empresa,
            float codigoTarifa,
            float numeroPasajeros,
            float duracionSegundos,
            float distanciaMillas,
            string tipoPago)
        {
            try
            {
                if (!_servicioML.EstaEntrenado())
                    return new ResultadoOperacion
                    {
                        Exitoso = false,
                        Mensaje = "El modelo aun no ha sido entrenado. Haga clic en Entrenar primero."
                    };

                // Crear el objeto de entrada para el modelo ML
                var datosViaje = new ViajeML
                {
                    Empresa = empresa,
                    CodigoTarifa = codigoTarifa,
                    NumeroPasajeros = numeroPasajeros,
                    DuracionSegundos = duracionSegundos,
                    DistanciaMillas = distanciaMillas,
                    TipoPago = tipoPago,
                    TarifaReal = 0
                };

                // Obtener la prediccion del modelo ML
                float tarifaPredicha = _servicioML.PredecirTarifa(datosViaje);

                // Crear el registro completo para guardar en SQL Server
                var viaje = new Viaje
                {
                    Empresa = empresa,
                    CodigoTarifa = codigoTarifa,
                    NumeroPasajeros = numeroPasajeros,
                    DuracionSegundos = duracionSegundos,
                    DistanciaMillas = distanciaMillas,
                    TipoPago = tipoPago,
                    TarifaReal = 0,
                    TarifaPredicha = tarifaPredicha,
                    FechaRegistro = DateTime.Now
                };

                // Persistir en la base de datos mediante Entity Framework
                _repositorioViaje.GuardarViaje(viaje);

                return new ResultadoOperacion
                {
                    Exitoso = true,
                    TarifaPredicha = tarifaPredicha,
                    ViajeId = viaje.Id,
                    Mensaje = string.Format(
                        "Tarifa estimada: ${0:F2}\nViaje guardado en BD con ID: {1}",
                        tarifaPredicha,
                        viaje.Id
                    )
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exitoso = false,
                    Mensaje = "Error al procesar la operacion: " + ex.Message
                };
            }
        }

        // Obtiene el historial de viajes desde la base de datos
        public List<Viaje> ObtenerHistorial(int cantidad = 50)
        {
            return _repositorioViaje.ObtenerUltimos(cantidad);
        }

        // Devuelve el total de viajes guardados en la BD
        public int TotalViajesGuardados()
        {
            return _repositorioViaje.ContarViajes();
        }
    }

    // Clase de resultado para la comunicacion entre la Vista y el Gestor
    public class ResultadoOperacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public float TarifaPredicha { get; set; }
        public int ViajeId { get; set; }
    }
}
