using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoTesis.Datos.Repositorios
{
    public class InformeCabeceraRepositorio : RepositorioBase<InformeCabecera>
    {
        public InformeCabeceraRepositorio(SistemaTesisEntities context) : base(context) { }

        public IEnumerable<InformeCabecera> ObtenerPorEstudiante(int estudianteId)
        {
            return ((SistemaTesisEntities)_context).InformeCabecera
                .Include(i => i.InformeDetalle)
                .Include(i => i.Estudiante)
                .Include(i => i.Profesor)
                .Where(i => i.EstudianteId == estudianteId)
                .OrderByDescending(i => i.FechaEmision)
                .ToList();
        }

        public InformeCabecera ObtenerConDetalles(int informeId)
        {
            return ((SistemaTesisEntities)_context).InformeCabecera
                .Include(i => i.InformeDetalle)
                .Include(i => i.Estudiante)
                .Include(i => i.Profesor)
                .FirstOrDefault(i => i.InformeCabeceraId == informeId);
        }

        public int ObtenerUltimoNumeroInforme(int estudianteId)
        {
            var ultimo = ((SistemaTesisEntities)_context).InformeCabecera
                .Where(i => i.EstudianteId == estudianteId)
                .OrderByDescending(i => i.InformeCabeceraId)
                .FirstOrDefault();

            if (ultimo == null) return 0;

            if (int.TryParse(ultimo.NumeroInforme?.Replace("INF-", ""), out int num))
                return num;

            return 0;
        }
    }
}
