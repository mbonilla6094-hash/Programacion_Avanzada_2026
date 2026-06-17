using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoTesis.Datos.Repositorios
{
    public class EstudianteRepositorio : RepositorioBase<Estudiante>
    {
        public EstudianteRepositorio(SistemaTesisEntities context) : base(context) { }

        public IEnumerable<Estudiante> ObtenerPorProfesor(int profesorId)
        {
            return Buscar(e => e.ProfesorId == profesorId);
        }

        public IEnumerable<Estudiante> BuscarConFiltros(
            int profesorId,
            string nombre = null,
            string apellido = null,
            string carrera = null,
            string estado = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null)
        {
            var query = ((SistemaTesisEntities)_context).Estudiante
                .Include(e => e.Profesor)
                .Where(e => e.ProfesorId == profesorId);

            if (!string.IsNullOrWhiteSpace(nombre))
                query = query.Where(e => e.Nombres.Contains(nombre));

            if (!string.IsNullOrWhiteSpace(apellido))
                query = query.Where(e => e.Apellidos.Contains(apellido));

            if (!string.IsNullOrWhiteSpace(carrera))
                query = query.Where(e => e.Carrera.Contains(carrera));

            if (!string.IsNullOrWhiteSpace(estado))
                query = query.Where(e => e.Estado == estado);

            if (fechaDesde.HasValue)
                query = query.Where(e => e.FechaRegistro >= fechaDesde.Value);

            if (fechaHasta.HasValue)
                query = query.Where(e => e.FechaRegistro <= fechaHasta.Value);

            return query.OrderByDescending(e => e.FechaRegistro).ToList();
        }

        public Estudiante ObtenerConHistorial(int estudianteId)
        {
            return ((SistemaTesisEntities)_context).Estudiante
                .Include(e => e.HistorialProgresion)
                .Include(e => e.InformeCabecera)
                .FirstOrDefault(e => e.EstudianteId == estudianteId);
        }
    }
}
