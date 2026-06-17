using System.Collections.Generic;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class HistorialServicio : IHistorialServicio
    {
        private HistorialProgresion MapDatosAEntidad(ProyectoTesis.Datos.HistorialProgresion h)
        {
            if (h == null) return null;
            return new HistorialProgresion
            {
                HistorialId = h.HistorialId,
                EstudianteId = h.EstudianteId,
                InformeCabeceraId = h.InformeCabeceraId,
                FechaInforme = h.FechaInforme,
                PorcentajeEnInforme = h.PorcentajeEnInforme,
                EstadoEnInforme = h.EstadoEnInforme,
                ResumenActividades = h.ResumenActividades
            };
        }

        public IEnumerable<HistorialProgresion> ObtenerPorEstudiante(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.HistorialRepositorio.ObtenerPorEstudiante(estudianteId)
                    .Select(h => MapDatosAEntidad(h)).ToList();
            }
        }

        public void RegistrarProgresion(InformeCabecera informe)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                string resumen = string.Join("; ",
                    informe.InformeDetalle.Select(d => $"{d.DescripcionActividad} ({d.PorcentajeActividad}%)"));

                var historial = new ProyectoTesis.Datos.HistorialProgresion
                {
                    EstudianteId = informe.EstudianteId,
                    InformeCabeceraId = informe.InformeCabeceraId,
                    FechaInforme = informe.FechaEmision,
                    PorcentajeEnInforme = informe.PorcentajeAcumulado,
                    EstadoEnInforme = informe.Estado,
                    ResumenActividades = resumen
                };

                uow.HistorialRepositorio.Agregar(historial);
                uow.Guardar();

                if (informe.EsFinal == true)
                {
                    var estudiante = uow.EstudianteRepositorio.ObtenerPorId(informe.EstudianteId);
                    if (estudiante != null)
                    {
                        estudiante.Estado = "Aprobado";
                        estudiante.PorcentajeAvance = 100;
                        uow.EstudianteRepositorio.Actualizar(estudiante);
                        uow.Guardar();
                    }
                }
            }
        }
    }
}
