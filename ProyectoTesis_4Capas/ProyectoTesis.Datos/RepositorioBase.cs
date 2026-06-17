using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProyectoTesis.Datos.Interfaces;

namespace ProyectoTesis.Datos
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T ObtenerPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _dbSet.Where(predicado).ToList();
        }

        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public void AgregarRango(IEnumerable<T> entidades)
        {
            _dbSet.AddRange(entidades);
        }

        public void Actualizar(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
        }

        public void Eliminar(T entidad)
        {
            if (_context.Entry(entidad).State == EntityState.Detached)
                _dbSet.Attach(entidad);
            _dbSet.Remove(entidad);
        }

        public void Eliminar(int id)
        {
            var entidad = _dbSet.Find(id);
            if (entidad != null)
                Eliminar(entidad);
        }

        public int Contar(Expression<Func<T, bool>> predicado = null)
        {
            if (predicado == null)
                return _dbSet.Count();
            return _dbSet.Count(predicado);
        }

        public bool Existe(Expression<Func<T, bool>> predicado)
        {
            return _dbSet.Any(predicado);
        }
    }
}
