using System;
using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class HistorialProgresion
    {
        public int HistorialId { get; set; }
        public int EstudianteId { get; set; }
        public int InformeCabeceraId { get; set; }
        public DateTime FechaInforme { get; set; }
        public int PorcentajeEnInforme { get; set; }
        public string EstadoEnInforme { get; set; }
        public string ResumenActividades { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual InformeCabecera InformeCabecera { get; set; }
    }
}
