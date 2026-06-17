using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class EstudianteServicio : IEstudianteServicio
    {
        private Estudiante MapDatosAEntidad(ProyectoTesis.Datos.Estudiante e)
        {
            if (e == null) return null;
            return new Estudiante
            {
                EstudianteId = e.EstudianteId,
                ProfesorId = e.ProfesorId,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                Cedula = e.Cedula,
                Carrera = e.Carrera,
                TituloTesis = e.TituloTesis,
                NumeroResolucion = e.NumeroResolucion,
                FechaResolucion = e.FechaResolucion,
                ArchivoResolucion = e.ArchivoResolucion,
                Estado = e.Estado,
                PorcentajeAvance = e.PorcentajeAvance,
                FechaRegistro = e.FechaRegistro,
                Profesor = e.Profesor != null ? new Profesor
                {
                    ProfesorId = e.Profesor.ProfesorId,
                    Nombres = e.Profesor.Nombres,
                    Apellidos = e.Profesor.Apellidos,
                    Usuario = e.Profesor.Usuario,
                    Contrasena = e.Profesor.Contrasena,
                    Email = e.Profesor.Email,
                    Activo = e.Profesor.Activo
                } : null
            };
        }

        private ProyectoTesis.Datos.Estudiante MapEntidadADatos(Estudiante e)
        {
            if (e == null) return null;
            return new ProyectoTesis.Datos.Estudiante
            {
                EstudianteId = e.EstudianteId,
                ProfesorId = e.ProfesorId,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                Cedula = e.Cedula,
                Carrera = e.Carrera,
                TituloTesis = e.TituloTesis,
                NumeroResolucion = e.NumeroResolucion,
                FechaResolucion = e.FechaResolucion,
                ArchivoResolucion = e.ArchivoResolucion,
                Estado = e.Estado,
                PorcentajeAvance = e.PorcentajeAvance,
                FechaRegistro = e.FechaRegistro
            };
        }

        private List<ProyectoTesis.Datos.InformeCabecera> MapInformesEntidadADatos(ICollection<InformeCabecera> informes)
        {
            if (informes == null) return null;
            return informes.Select(i => new ProyectoTesis.Datos.InformeCabecera
            {
                InformeCabeceraId = i.InformeCabeceraId,
                EstudianteId = i.EstudianteId,
                ProfesorId = i.ProfesorId,
                NumeroInforme = i.NumeroInforme,
                FechaEmision = i.FechaEmision,
                PorcentajeAcumulado = i.PorcentajeAcumulado,
                Estado = i.Estado,
                EsFinal = i.EsFinal
            }).ToList();
        }

        public IEnumerable<Estudiante> ObtenerPorProfesor(int profesorId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.EstudianteRepositorio.ObtenerPorProfesor(profesorId)
                    .Select(e => MapDatosAEntidad(e)).ToList();
            }
        }

        public Estudiante ObtenerPorId(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return MapDatosAEntidad(uow.EstudianteRepositorio.ObtenerPorId(estudianteId));
            }
        }

        public IEnumerable<Estudiante> BuscarConFiltros(int profesorId, string nombre = null, string apellido = null, string carrera = null, string estado = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.EstudianteRepositorio.BuscarConFiltros(profesorId, nombre, apellido, carrera, estado, fechaDesde, fechaHasta)
                    .Select(e => MapDatosAEntidad(e)).ToList();
            }
        }

        public void Agregar(Estudiante estudiante)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                estudiante.FechaRegistro = DateTime.Now;
                estudiante.Estado = "En Proceso";
                if (!estudiante.PorcentajeAvance.HasValue)
                    estudiante.PorcentajeAvance = 0;
                var datos = MapEntidadADatos(estudiante);
                uow.EstudianteRepositorio.Agregar(datos);
                uow.Guardar();
            }
        }

        public void Actualizar(Estudiante estudiante)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var existente = uow.EstudianteRepositorio.ObtenerPorId(estudiante.EstudianteId);
                if (existente != null)
                {
                    existente.Nombres = estudiante.Nombres;
                    existente.Apellidos = estudiante.Apellidos;
                    existente.Carrera = estudiante.Carrera;
                    existente.TituloTesis = estudiante.TituloTesis;
                    existente.NumeroResolucion = estudiante.NumeroResolucion;
                    existente.FechaResolucion = estudiante.FechaResolucion;
                    if (estudiante.ArchivoResolucion != null)
                        existente.ArchivoResolucion = estudiante.ArchivoResolucion;
                    uow.EstudianteRepositorio.Actualizar(existente);
                    uow.Guardar();
                }
            }
        }

        public void Eliminar(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                uow.EstudianteRepositorio.Eliminar(estudianteId);
                uow.Guardar();
            }
        }

        public void ActualizarEstado(int estudianteId, string estado, int porcentaje)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var est = uow.EstudianteRepositorio.ObtenerPorId(estudianteId);
                if (est != null)
                {
                    est.Estado = estado;
                    est.PorcentajeAvance = porcentaje;
                    uow.EstudianteRepositorio.Actualizar(est);
                    uow.Guardar();
                }
            }
        }

        public bool CedulaDisponible(string cedula, int? excluirId = null)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                if (excluirId.HasValue)
                    return !uow.EstudianteRepositorio.Existe(e => e.Cedula == cedula && e.EstudianteId != excluirId.Value);
                return !uow.EstudianteRepositorio.Existe(e => e.Cedula == cedula);
            }
        }
    }
}
