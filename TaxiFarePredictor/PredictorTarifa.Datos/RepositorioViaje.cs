using System;
using System.Collections.Generic;
using System.Linq;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Datos
{
    // Repositorio: maneja todas las operaciones de la base de datos para Viaje
    public class RepositorioViaje
    {
        // Guarda un viaje nuevo en la base de datos SQL Server
        public void GuardarViaje(Viaje viaje)
        {
            using (var contexto = new ContextoBD())
            {
                viaje.FechaRegistro = DateTime.Now;
                contexto.Viajes.Add(viaje);
                contexto.SaveChanges();
            }
        }

        // Obtiene todos los viajes registrados en la base de datos
        public List<Viaje> ObtenerTodos()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Viajes
                    .OrderByDescending(v => v.FechaRegistro)
                    .ToList();
            }
        }

        // Obtiene los ultimos N viajes registrados
        public List<Viaje> ObtenerUltimos(int cantidad)
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Viajes
                    .OrderByDescending(v => v.FechaRegistro)
                    .Take(cantidad)
                    .ToList();
            }
        }

        // Elimina un viaje por su ID
        public bool EliminarViaje(int id)
        {
            using (var contexto = new ContextoBD())
            {
                var viaje = contexto.Viajes.Find(id);
                if (viaje == null) return false;

                contexto.Viajes.Remove(viaje);
                contexto.SaveChanges();
                return true;
            }
        }

        // Verifica si la base de datos esta disponible y tiene registros
        public int ContarViajes()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Viajes.Count();
            }
        }
    }
}
