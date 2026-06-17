using System;
using System.Collections.Generic;
using SistemaVentas.Datos;
using SistemaVentas.Entidades;

namespace SistemaVentas.LogicaNegocio
{
    // Gestor principal: orquesta la logica entre la Vista y la capa de Datos
    public class GestorVentas
    {
        private readonly RepositorioVenta _repositorio;

        public GestorVentas()
        {
            _repositorio = new RepositorioVenta();
        }

        // Obtiene las ventas para mostrar en el grid
        public List<Venta> ObtenerVentas(int cantidad = 500)
        {
            return _repositorio.ObtenerTodas(cantidad);
        }

        // Busca ventas por pais
        public List<Venta> BuscarPorPais(string pais)
        {
            return _repositorio.BuscarPorPais(pais);
        }

        // Busca ventas por tipo de producto
        public List<Venta> BuscarPorProducto(string tipoProducto)
        {
            return _repositorio.BuscarPorProducto(tipoProducto);
        }

        // Inserta una venta nueva
        public int AgregarVenta(Venta venta)
        {
            return _repositorio.Insertar(venta);
        }

        // Elimina una venta
        public bool EliminarVenta(int id)
        {
            return _repositorio.Eliminar(id);
        }

        // Cuenta el total de registros en la BD
        public int TotalRegistros()
        {
            return _repositorio.ContarTotal();
        }

        // Reporte por region
        public List<ReporteRegion> ObtenerReportePorRegion()
        {
            return _repositorio.ReportePorRegion();
        }

        // Reporte por producto
        public List<ReporteProducto> ObtenerReportePorProducto()
        {
            return _repositorio.ReportePorProducto();
        }

        // ---------- MACHINE LEARNING ML.NET ----------
        private PredictorVentas? _predictor;
        private bool _modeloEntrenado = false;

        public float PredecirVentasFuturas(string region, string pais, string producto)
        {
            if (!_modeloEntrenado)
            {
                _predictor = new PredictorVentas();
                // Traemos una muestra representativa de 10,000 registros de SQL Server
                var todasLasVentas = _repositorio.ObtenerTodas(10000); 
                _predictor.EntrenarModelo(todasLasVentas);
                _modeloEntrenado = true;
            }
            if (_predictor == null) return 0;
            return _predictor.Predecir(region, pais, producto);
        }
    }
}
