using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoTesis.Datos.Repositorios
{
    public class HistorialRepositorio : RepositorioBase<HistorialProgresion>
    {
        public HistorialRepositorio(SistemaTesisEntities context) : base(context) { }

        public IEnumerable<HistorialProgresion> ObtenerPorEstudiante(int estudianteId)
        {
            return ((SistemaTesisEntities)_context).HistorialProgresion
                .Include(h => h.InformeCabecera)
                .Where(h => h.EstudianteId == estudianteId)
                .OrderBy(h => h.FechaInforme)
                .ToList();
        }
    }
}
