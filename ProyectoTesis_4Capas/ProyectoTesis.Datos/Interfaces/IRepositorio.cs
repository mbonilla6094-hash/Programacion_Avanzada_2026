using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProyectoTesis.Datos.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado);
        void Agregar(T entidad);
        void AgregarRango(IEnumerable<T> entidades);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
        void Eliminar(int id);
        int Contar(Expression<Func<T, bool>> predicado = null);
        bool Existe(Expression<Func<T, bool>> predicado);
    }
}
