using System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Libro
    {
        public int LibroID { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int AnioPublicacion { get; set; }
        public int EjemplaresTotales { get; set; }
        public int EjemplaresDisponibles { get; set; }
        public int CategoriaID { get; set; }
        public bool Activo { get; set; }
        
        
        public Categoria Categoria { get; set; }
        public List<Prestamo> Prestamos { get; set; }
        
        
        public Libro()
        {
            Prestamos = new List<Prestamo>();
            Activo = true;
            EjemplaresTotales = 1;
            EjemplaresDisponibles = 1;
        }
        
        public Libro(string isbn, string titulo, string autor, int ejemplares) : this()
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            EjemplaresTotales = ejemplares;
            EjemplaresDisponibles = ejemplares;
        }
        
        public Libro(string isbn, string titulo, string autor, string editorial, 
                     int anio, int ejemplares, int categoriaID) : this(isbn, titulo, autor, ejemplares)
        {
            Editorial = editorial;
            AnioPublicacion = anio;
            CategoriaID = categoriaID;
        }
        
        public bool TieneDisponibilidad()
        {
            return EjemplaresDisponibles > 0;
        }
    }
}
