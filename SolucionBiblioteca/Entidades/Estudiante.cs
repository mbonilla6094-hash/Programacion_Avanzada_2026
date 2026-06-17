using System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
        public int Semestre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        
        public List<Prestamo> Prestamos { get; set; }
        
        public Estudiante()
        {
            Prestamos = new List<Prestamo>();
            Activo = true;
        }
        
        public Estudiante(string matricula, string nombre, string apellido) : this()
        {
            Matricula = matricula;
            Nombre = nombre;
            Apellido = apellido;
        }
        
        public Estudiante(string matricula, string nombre, string apellido, 
                         string carrera, int semestre) : this(matricula, nombre, apellido)
        {
            Carrera = carrera;
            Semestre = semestre;
        }
        
        public string NombreCompleto => $"{Nombre} {Apellido}";
        
        public int PrestamosActivos()
        {
            return Prestamos.FindAll(p => p.Estado == "ACTIVO").Count;
        }
    }
}
