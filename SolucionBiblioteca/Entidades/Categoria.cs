using System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        
    
        public List<Libro> Libros { get; set; }
        
       
        public Categoria()
        {
            Libros = new List<Libro>();
            Activo = true;
        }
        
        public Categoria(string nombre, string descripcion) : this()
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        
        public Categoria(int id, string nombre, string descripcion) : this(nombre, descripcion)
        {
            CategoriaID = id;
        }
    }
}
