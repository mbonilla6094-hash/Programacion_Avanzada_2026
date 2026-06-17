using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DatosADO;
using Entidades;

namespace Negocio
{
    public class EstudianteNEG
    {
  
        public static Respuesta Insertar(Estudiante e)
        {
            try
            {
                Respuesta validacion = Validar(e);
                if (!validacion.Exitoso) return validacion;

                bool resultado = EstudianteDAL.Insertar(e);
                return resultado
                    ? Respuesta.Ok("Estudiante registrado correctamente.")
                    : Respuesta.Error("No se pudo registrar el estudiante.");
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta ObtenerTodos()
        {
            try
            {
                List<Estudiante> lista = EstudianteDAL.ObtenerTodos();
                return Respuesta.Ok("OK", lista);
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta Buscar(string termino)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(termino))
                    return ObtenerTodos();

                List<Estudiante> lista = EstudianteDAL.Buscar(termino.Trim());
                return Respuesta.Ok("OK", lista);
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta Actualizar(Estudiante e)
        {
            try
            {
                if (e.Id <= 0)
                    return Respuesta.Error("ID invalido para actualizar.");

                Respuesta validacion = Validar(e);
                if (!validacion.Exitoso) return validacion;

                bool resultado = EstudianteDAL.Actualizar(e);
                return resultado
                    ? Respuesta.Ok("Estudiante actualizado correctamente.")
                    : Respuesta.Error("No se pudo actualizar el estudiante.");
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return Respuesta.Error("ID invalido para eliminar.");

                bool resultado = EstudianteDAL.Eliminar(id);
                return resultado
                    ? Respuesta.Ok("Estudiante eliminado correctamente.")
                    : Respuesta.Error("No se encontro el estudiante a eliminar.");
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }


        private static Respuesta Validar(Estudiante e)
        {
            if (e == null)
                return Respuesta.Error("El objeto estudiante no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(e.Cedula))
                return Respuesta.Error("La cedula es obligatoria.");
            if (e.Cedula.Trim().Length != 10)
                return Respuesta.Error("La cedula debe tener exactamente 10 digitos.");
            if (!Regex.IsMatch(e.Cedula.Trim(), @"^\d{10}$"))
                return Respuesta.Error("La cedula solo debe contener numeros.");
            if (string.IsNullOrWhiteSpace(e.Nombres))
                return Respuesta.Error("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(e.Apellidos))
                return Respuesta.Error("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(e.Email))
                return Respuesta.Error("El email es obligatorio.");
            if (!Regex.IsMatch(e.Email.Trim(),
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return Respuesta.Error("El formato del email no es valido.");
            if (string.IsNullOrWhiteSpace(e.Carrera))
                return Respuesta.Error("La carrera es obligatoria.");
            return Respuesta.Ok();
        }
    }
}
