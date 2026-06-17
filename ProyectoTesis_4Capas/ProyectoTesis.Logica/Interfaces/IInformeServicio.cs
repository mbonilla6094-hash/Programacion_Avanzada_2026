using System.Collections.Generic;
using ProyectoTesis.Entidades;

namespace ProyectoTesis.Logica.Interfaces
{
    public interface IInformeServicio
    {
        InformeCabecera CrearInforme(int estudianteId, int profesorId, List<InformeDetalle> actividades);
        IEnumerable<InformeCabecera> ObtenerInformesPorEstudiante(int estudianteId);
        InformeCabecera ObtenerInformeConDetalles(int informeId);
        byte[] GenerarPdfInforme(int informeId, string rutaLogo);
        byte[] GenerarPdfInformeFinal(int estudianteId, string rutaLogo);
    }
}
