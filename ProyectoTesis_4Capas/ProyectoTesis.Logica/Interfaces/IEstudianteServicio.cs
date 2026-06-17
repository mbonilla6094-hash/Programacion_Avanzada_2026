using System;
using System.Collections.Generic;
using ProyectoTesis.Entidades;

namespace ProyectoTesis.Logica.Interfaces
{
    public interface IEstudianteServicio
    {
        IEnumerable<Estudiante> ObtenerPorProfesor(int profesorId);
        Estudiante ObtenerPorId(int estudianteId);
        IEnumerable<Estudiante> BuscarConFiltros(int profesorId, string nombre = null, string apellido = null, string carrera = null, string estado = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null);
        void Agregar(Estudiante estudiante);
        void Actualizar(Estudiante estudiante);
        void Eliminar(int estudianteId);
        void ActualizarEstado(int estudianteId, string estado, int porcentaje);
        bool CedulaDisponible(string cedula, int? excluirId = null);
    }
}
