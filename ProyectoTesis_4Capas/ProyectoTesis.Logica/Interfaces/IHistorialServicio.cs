using System.Collections.Generic;
using ProyectoTesis.Entidades;

namespace ProyectoTesis.Logica.Interfaces
{
    public interface IHistorialServicio
    {
        IEnumerable<HistorialProgresion> ObtenerPorEstudiante(int estudianteId);
        void RegistrarProgresion(InformeCabecera informe);
    }
}
