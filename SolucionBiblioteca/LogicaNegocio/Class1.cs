using System;
using System.Collections.Generic;
using System.Linq;
using SolucionBiblioteca.Entidades;
using Datos;

namespace LogicaNegocio
{
    public class BibliotecaLogica
    {
        private Repositorio _repo = Repositorio.Instancia;

        public void RegistrarLibro(Libro libro)
        {
            if (string.IsNullOrEmpty(libro.ISBN) || string.IsNullOrEmpty(libro.Titulo))
                throw new ArgumentException("ISBN y Titulo son obligatorios");
                
            _repo.AgregarLibro(libro);
        }

        public void RegistrarEstudiante(Estudiante estudiante)
        {
            if (string.IsNullOrEmpty(estudiante.Matricula))
                throw new ArgumentException("Matricula obligatoria");
                
            _repo.AgregarEstudiante(estudiante);
        }

        public void RegistrarCategoria(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
                throw new ArgumentException("El nombre es obligatorio");

            _repo.AgregarCategoria(categoria);
        }

        public Prestamo PrestarLibro(int libroId, int estudianteId)
        {
            var libro = _repo.Libros.FirstOrDefault(l => l.LibroID == libroId);
            var estudiante = _repo.Estudiantes.FirstOrDefault(e => e.EstudianteID == estudianteId);

            if (libro == null || estudiante == null)
                throw new Exception("Libro o estudiante no encontrado");

            if (!libro.TieneDisponibilidad())
                throw new Exception("No hay ejemplares disponibles");
            
            var prestamo = new Prestamo(libro, estudiante);
            _repo.RegistrarPrestamo(prestamo);
            
            return prestamo;
        }

        public void DevolverLibro(int prestamoId)
        {
            var prestamo = _repo.Prestamos.FirstOrDefault(p => p.PrestamoID == prestamoId);
            if (prestamo == null || prestamo.Estado != "ACTIVO")
                throw new Exception("Préstamo no válido");

            prestamo.FechaDevolucionReal = DateTime.Now;
            prestamo.CalcularMulta();
            if (prestamo.MontoMulta == 0)
                prestamo.Estado = "DEVUELTO";
                
            var libro = _repo.Libros.FirstOrDefault(l => l.LibroID == prestamo.LibroID);
            if (libro != null)
            {
                libro.EjemplaresDisponibles++;
            }
            
            _repo.ActualizarPrestamoYLibro(prestamo, libro);
        }

        public List<Libro> ObtenerLibros() => _repo.Libros;
        public List<Estudiante> ObtenerEstudiantes() => _repo.Estudiantes;
        public List<Prestamo> ObtenerPrestamos() => _repo.Prestamos;
        public List<Categoria> ObtenerCategorias() => _repo.Categorias;

        public Dictionary<string, int> ObtenerEstadisticasPrestamos()
        {
            var estadisticas = new Dictionary<string, int>();
            var prestamos = _repo.Prestamos;
            
            estadisticas["ACTIVO"] = prestamos.Count(p => p.Estado == "ACTIVO");
            estadisticas["DEVUELTO"] = prestamos.Count(p => p.Estado == "DEVUELTO");
            estadisticas["CON_MULTA"] = prestamos.Count(p => p.Estado == "CON_MULTA");
            
            return estadisticas;
        }
    }
}
