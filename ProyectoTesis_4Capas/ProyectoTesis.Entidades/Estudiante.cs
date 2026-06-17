using System;
using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            this.HistorialProgresion = new HashSet<HistorialProgresion>();
            this.InformeCabecera = new HashSet<InformeCabecera>();
        }

        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Carrera { get; set; }
        public string TituloTesis { get; set; }
        public string NumeroResolucion { get; set; }
        public DateTime FechaResolucion { get; set; }
        public byte[] ArchivoResolucion { get; set; }
        public string Estado { get; set; }
        public Nullable<int> PorcentajeAvance { get; set; }
        public Nullable<DateTime> FechaRegistro { get; set; }

        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<HistorialProgresion> HistorialProgresion { get; set; }
        public virtual ICollection<InformeCabecera> InformeCabecera { get; set; }
    }
}
