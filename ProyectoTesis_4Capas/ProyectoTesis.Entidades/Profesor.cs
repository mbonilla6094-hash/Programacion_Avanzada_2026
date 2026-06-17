using System;
using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class Profesor
    {
        public Profesor()
        {
            this.Estudiante = new HashSet<Estudiante>();
            this.InformeCabecera = new HashSet<InformeCabecera>();
        }

        public int ProfesorId { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Activo { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
        public virtual ICollection<InformeCabecera> InformeCabecera { get; set; }
    }
}
