using System.Collections.Generic;
using ProyectoTesis.Entidades;

namespace ProyectoTesis.Logica.Interfaces
{
    public interface IPdfServicio
    {
        byte[] GenerarInformeMensual(InformeCabecera datosCabecera, List<InformeDetalle> detalles, string rutaLogo);
        byte[] GenerarInformeFinal(Estudiante datosEstudiante, List<HistorialProgresion> historial, string rutaLogo);
    }
}
