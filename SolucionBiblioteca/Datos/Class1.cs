using System;
using System.Collections.Generic;
using System.Linq;
using SolucionBiblioteca.Entidades;

namespace Datos
{
    public class Repositorio
    {
        private static Repositorio _instancia;
        public static Repositorio Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Repositorio();
                return _instancia;
            }
        }

        private Repositorio() { }

        
        private Categoria Mapear(Categorias c)
        {
            if (c == null) return null;
            return new Categoria
            {
                CategoriaID = c.CategoriaID,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Activo = c.Activo ?? true
            };
        }

        private Libro Mapear(Libros l)
        {
            if (l == null) return null;
            return new Libro
            {
                LibroID = l.LibroID,
                ISBN = l.ISBN,
                Titulo = l.Titulo,
                Autor = l.Autor,
                Editorial = l.Editorial,
                AnioPublicacion = l.AnioPublicacion ?? 0,
                EjemplaresTotales = l.EjemplaresTotales,
                EjemplaresDisponibles = l.EjemplaresDisponibles,
                CategoriaID = l.CategoriaID ?? 0,
                Activo = l.Activo ?? true
            };
        }

        private Estudiante Mapear(Estudiantes e)
        {
            if (e == null) return null;
            return new Estudiante
            {
                EstudianteID = e.EstudianteID,
                Matricula = e.Matricula,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Carrera = e.Carrera,
                Semestre = e.Semestre ?? 1,
                Email = e.Email,
                Telefono = e.Telefono,
                Activo = e.Activo ?? true
            };
        }

        private Prestamo Mapear(Prestamos p)
        {
            if (p == null) return null;
            return new Prestamo
            {
                PrestamoID = p.PrestamoID,
                LibroID = p.LibroID ?? 0,
                EstudianteID = p.EstudianteID ?? 0,
                FechaPrestamo = p.FechaPrestamo,
                FechaDevolucionEsperada = p.FechaDevolucionEsperada ?? DateTime.Now,
                FechaDevolucionReal = p.FechaDevolucionReal,
                Estado = p.Estado,
                DiasRetraso = p.DiasRetraso ?? 0,
                MontoMulta = p.MontoMulta ?? 0
            };
        }

        // PROPIEDADES (GETTERS)
        public List<Categoria> Categorias
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Categorias.ToList().Select(Mapear).ToList();
                }
            }
        }

        public List<Libro> Libros
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Libros.ToList().Select(Mapear).ToList();
                }
            }
        }

        public List<Estudiante> Estudiantes
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Estudiantes.ToList().Select(Mapear).ToList();
                }
            }
        }

        public List<Prestamo> Prestamos
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Prestamos.ToList().Select(Mapear).ToList();
                }
            }
        }

        // ADD METHODS
        public void AgregarCategoria(Categoria c)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Categorias.Add(new Categorias
                {
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Activo = c.Activo
                });
                db.SaveChanges();
            }
        }

        public void AgregarLibro(Libro l)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Libros.Add(new Libros
                {
                    ISBN = l.ISBN,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    Editorial = l.Editorial,
                    AnioPublicacion = l.AnioPublicacion == 0 ? (int?)null : l.AnioPublicacion,
                    EjemplaresTotales = l.EjemplaresTotales,
                    EjemplaresDisponibles = l.EjemplaresDisponibles,
                    CategoriaID = l.CategoriaID == 0 ? (int?)null : l.CategoriaID,
                    Activo = l.Activo
                });
                db.SaveChanges();
            }
        }

        public void AgregarEstudiante(Estudiante e)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Estudiantes.Add(new Estudiantes
                {
                    Matricula = e.Matricula,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Carrera = e.Carrera,
                    Semestre = e.Semestre,
                    Email = e.Email,
                    Telefono = e.Telefono,
                    Activo = e.Activo
                });
                db.SaveChanges();
            }
        }

        public void RegistrarPrestamo(Prestamo p)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Prestamos.Add(new Prestamos
                {
                    LibroID = p.LibroID,
                    EstudianteID = p.EstudianteID,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucionEsperada = p.FechaDevolucionEsperada,
                    Estado = p.Estado,
                    DiasRetraso = p.DiasRetraso,
                    MontoMulta = p.MontoMulta
                });
                
                var libroDb = db.Libros.Find(p.LibroID);
                if (libroDb != null)
                {
                    libroDb.EjemplaresDisponibles--;
                }
                
                db.SaveChanges();
            }
        }

        public void ActualizarPrestamoYLibro(Prestamo p, Libro l)
        {
            using (var db = new BibliotecaDBEntities())
            {
                var prestamoDb = db.Prestamos.Find(p.PrestamoID);
                if (prestamoDb != null)
                {
                    prestamoDb.FechaDevolucionReal = p.FechaDevolucionReal;
                    prestamoDb.Estado = p.Estado;
                    prestamoDb.DiasRetraso = p.DiasRetraso;
                    prestamoDb.MontoMulta = p.MontoMulta;
                }

                if (l != null)
                {
                    var libroDb = db.Libros.Find(l.LibroID);
                    if (libroDb != null)
                    {
                        libroDb.EjemplaresDisponibles = l.EjemplaresDisponibles;
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
