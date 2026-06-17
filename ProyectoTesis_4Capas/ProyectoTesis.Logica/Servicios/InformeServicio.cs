using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class InformeServicio : IInformeServicio
    {
        private readonly IHistorialServicio _historialServicio;
        private readonly IPdfServicio _pdfServicio;

        public InformeServicio()
        {
            _historialServicio = new HistorialServicio();
            _pdfServicio = new PdfServicio();
        }

        private InformeCabecera MapDatosAEntidad(ProyectoTesis.Datos.InformeCabecera i)
        {
            if (i == null) return null;
            var entidad = new InformeCabecera
            {
                InformeCabeceraId = i.InformeCabeceraId,
                EstudianteId = i.EstudianteId,
                ProfesorId = i.ProfesorId,
                NumeroInforme = i.NumeroInforme,
                FechaEmision = i.FechaEmision,
                PorcentajeAcumulado = i.PorcentajeAcumulado,
                Estado = i.Estado,
                EsFinal = i.EsFinal,
                InformeDetalle = i.InformeDetalle?.Select(d => new InformeDetalle
                {
                    InformeDetalleId = d.InformeDetalleId,
                    InformeCabeceraId = d.InformeCabeceraId,
                    NumeroActividad = d.NumeroActividad,
                    DescripcionActividad = d.DescripcionActividad,
                    PorcentajeActividad = d.PorcentajeActividad,
                    Observacion = d.Observacion
                }).ToList()
            };
            if (i.Estudiante != null)
            {
                entidad.Estudiante = new Estudiante
                {
                    EstudianteId = i.Estudiante.EstudianteId,
                    ProfesorId = i.Estudiante.ProfesorId,
                    Nombres = i.Estudiante.Nombres,
                    Apellidos = i.Estudiante.Apellidos,
                    Cedula = i.Estudiante.Cedula,
                    Carrera = i.Estudiante.Carrera,
                    TituloTesis = i.Estudiante.TituloTesis,
                    NumeroResolucion = i.Estudiante.NumeroResolucion,
                    FechaResolucion = i.Estudiante.FechaResolucion,
                    Estado = i.Estudiante.Estado,
                    PorcentajeAvance = i.Estudiante.PorcentajeAvance,
                    FechaRegistro = i.Estudiante.FechaRegistro
                };
            }
            if (i.Profesor != null)
            {
                entidad.Profesor = new Profesor
                {
                    ProfesorId = i.Profesor.ProfesorId,
                    Nombres = i.Profesor.Nombres,
                    Apellidos = i.Profesor.Apellidos,
                    Usuario = i.Profesor.Usuario,
                    Contrasena = i.Profesor.Contrasena,
                    Email = i.Profesor.Email,
                    Activo = i.Profesor.Activo
                };
            }
            return entidad;
        }

        public InformeCabecera CrearInforme(int estudianteId, int profesorId, List<InformeDetalle> actividades)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var estudiante = uow.EstudianteRepositorio.ObtenerPorId(estudianteId);
                if (estudiante == null)
                    throw new ArgumentException("El estudiante no existe");

                int totalPorcentaje = actividades.Sum(a => a.PorcentajeActividad);
                if (totalPorcentaje > 100)
                    throw new ArgumentException("La suma de porcentajes no puede exceder 100%");

                int nuevoNumero = uow.InformeCabeceraRepositorio.ObtenerUltimoNumeroInforme(estudianteId) + 1;
                int porcentajeActual = estudiante.PorcentajeAvance ?? 0;
                int porcentajeAcumulado = porcentajeActual + totalPorcentaje;
                if (porcentajeAcumulado > 100) porcentajeAcumulado = 100;

                var informe = new ProyectoTesis.Datos.InformeCabecera
                {
                    EstudianteId = estudianteId,
                    ProfesorId = profesorId,
                    NumeroInforme = $"INF-{nuevoNumero:D3}",
                    FechaEmision = DateTime.Now,
                    PorcentajeAcumulado = porcentajeAcumulado,
                    Estado = porcentajeAcumulado >= 100 ? "Aprobado" : "En Proceso",
                    EsFinal = porcentajeAcumulado >= 100
                };

                uow.InformeCabeceraRepositorio.Agregar(informe);
                uow.Guardar();

                var detalles = actividades.Select(act => new ProyectoTesis.Datos.InformeDetalle
                {
                    InformeCabeceraId = informe.InformeCabeceraId,
                    NumeroActividad = act.NumeroActividad,
                    DescripcionActividad = act.DescripcionActividad,
                    PorcentajeActividad = act.PorcentajeActividad,
                    Observacion = act.Observacion
                }).ToList();

                uow.InformeDetalleRepositorio.AgregarRango(detalles);

                estudiante.PorcentajeAvance = porcentajeAcumulado;
                estudiante.Estado = porcentajeAcumulado >= 100 ? "Aprobado" : estudiante.Estado;
                uow.EstudianteRepositorio.Actualizar(estudiante);
                uow.Guardar();

                var informeCompletoDatos = uow.InformeCabeceraRepositorio.ObtenerConDetalles(informe.InformeCabeceraId);
                var informeCompleto = MapDatosAEntidad(informeCompletoDatos);
                _historialServicio.RegistrarProgresion(informeCompleto);

                return informeCompleto;
            }
        }

        public IEnumerable<InformeCabecera> ObtenerInformesPorEstudiante(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.InformeCabeceraRepositorio.ObtenerPorEstudiante(estudianteId)
                    .Select(i => MapDatosAEntidad(i)).ToList();
            }
        }

        public InformeCabecera ObtenerInformeConDetalles(int informeId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return MapDatosAEntidad(uow.InformeCabeceraRepositorio.ObtenerConDetalles(informeId));
            }
        }

        public byte[] GenerarPdfInforme(int informeId, string rutaLogo)
        {
            var informe = ObtenerInformeConDetalles(informeId);
            if (informe == null)
                throw new ArgumentException("El informe no existe");

            return _pdfServicio.GenerarInformeMensual(informe, informe.InformeDetalle.ToList(), rutaLogo);
        }

        public byte[] GenerarPdfInformeFinal(int estudianteId, string rutaLogo)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var estudianteDatos = uow.EstudianteRepositorio.ObtenerConHistorial(estudianteId);
                if (estudianteDatos == null)
                    throw new ArgumentException("El estudiante no existe");

                var historialDatos = uow.HistorialRepositorio.ObtenerPorEstudiante(estudianteId).ToList();

                var estudiante = new Estudiante
                {
                    EstudianteId = estudianteDatos.EstudianteId,
                    ProfesorId = estudianteDatos.ProfesorId,
                    Nombres = estudianteDatos.Nombres,
                    Apellidos = estudianteDatos.Apellidos,
                    Cedula = estudianteDatos.Cedula,
                    Carrera = estudianteDatos.Carrera,
                    TituloTesis = estudianteDatos.TituloTesis,
                    NumeroResolucion = estudianteDatos.NumeroResolucion,
                    FechaResolucion = estudianteDatos.FechaResolucion,
                    ArchivoResolucion = estudianteDatos.ArchivoResolucion,
                    Estado = estudianteDatos.Estado,
                    PorcentajeAvance = estudianteDatos.PorcentajeAvance,
                    FechaRegistro = estudianteDatos.FechaRegistro
                };

                if (estudianteDatos.Profesor != null)
                {
                    estudiante.Profesor = new Profesor
                    {
                        ProfesorId = estudianteDatos.Profesor.ProfesorId,
                        Nombres = estudianteDatos.Profesor.Nombres,
                        Apellidos = estudianteDatos.Profesor.Apellidos,
                        Usuario = estudianteDatos.Profesor.Usuario,
                        Contrasena = estudianteDatos.Profesor.Contrasena,
                        Email = estudianteDatos.Profesor.Email,
                        Activo = estudianteDatos.Profesor.Activo
                    };
                }

                var historial = historialDatos.Select(h => new HistorialProgresion
                {
                    HistorialId = h.HistorialId,
                    EstudianteId = h.EstudianteId,
                    InformeCabeceraId = h.InformeCabeceraId,
                    FechaInforme = h.FechaInforme,
                    PorcentajeEnInforme = h.PorcentajeEnInforme,
                    EstadoEnInforme = h.EstadoEnInforme,
                    ResumenActividades = h.ResumenActividades
                }).ToList();

                return _pdfServicio.GenerarInformeFinal(estudiante, historial, rutaLogo);
            }
        }
    }
}
