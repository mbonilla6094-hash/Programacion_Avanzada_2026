using System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Prestamo
    {
        public int PrestamoID { get; set; }
        public int LibroID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
        public string Estado { get; set; }
        public int DiasRetraso { get; set; }
        public decimal MontoMulta { get; set; }
        
        public Libro Libro { get; set; }
        public Estudiante Estudiante { get; set; }
        
        public const int DIAS_PRESTAMO = 15;
        public const decimal MULTA_POR_DIA = 5.00m;
        
        public Prestamo()
        {
            FechaPrestamo = DateTime.Now;
            FechaDevolucionEsperada = DateTime.Now.AddDays(DIAS_PRESTAMO);
            Estado = "ACTIVO";
            DiasRetraso = 0;
            MontoMulta = 0;
        }
        
        public Prestamo(Libro libro, Estudiante estudiante) : this()
        {
            Libro = libro;
            LibroID = libro?.LibroID ?? 0;
            Estudiante = estudiante;
            EstudianteID = estudiante?.EstudianteID ?? 0;
        }
        
        public void CalcularMulta()
        {
            if (FechaDevolucionReal.HasValue && FechaDevolucionReal > FechaDevolucionEsperada)
            {
                DiasRetraso = (FechaDevolucionReal.Value - FechaDevolucionEsperada).Days;
                MontoMulta = DiasRetraso * MULTA_POR_DIA;
                Estado = "CON_MULTA";
            }
        }
    }
}
