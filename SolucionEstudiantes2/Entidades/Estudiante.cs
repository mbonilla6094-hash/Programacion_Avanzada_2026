using System;

namespace Entidades
{
    public class Estudiante
    {
        public int      Id            { get; set; }
        public string   Cedula        { get; set; }
        public string   Nombres       { get; set; }
        public string   Apellidos     { get; set; }
        public string   Email         { get; set; }
        public string   Carrera       { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string NombreCompleto
        {
            get { return Nombres + " " + Apellidos; }
        }
    }
}
