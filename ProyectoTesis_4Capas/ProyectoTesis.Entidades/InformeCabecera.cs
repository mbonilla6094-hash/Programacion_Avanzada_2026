using System;
using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class InformeCabecera
    {
        public InformeCabecera()
        {
            this.HistorialProgresion = new HashSet<HistorialProgresion>();
            this.InformeDetalle = new HashSet<InformeDetalle>();
        }

        public int InformeCabeceraId { get; set; }
        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string NumeroInforme { get; set; }
        public DateTime FechaEmision { get; set; }
        public int PorcentajeAcumulado { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> EsFinal { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual ICollection<HistorialProgresion> HistorialProgresion { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<InformeDetalle> InformeDetalle { get; set; }
    }
}
