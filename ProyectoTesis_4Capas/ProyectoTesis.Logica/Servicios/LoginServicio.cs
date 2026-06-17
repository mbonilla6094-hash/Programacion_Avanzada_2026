using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        private Profesor MapDatosAEntidad(ProyectoTesis.Datos.Profesor profesor)
        {
            if (profesor == null) return null;
            return new Profesor
            {
                ProfesorId = profesor.ProfesorId,
                Nombres = profesor.Nombres,
                Apellidos = profesor.Apellidos,
                Usuario = profesor.Usuario,
                Contrasena = profesor.Contrasena,
                Email = profesor.Email,
                Activo = profesor.Activo
            };
        }

        public Profesor Autenticar(string usuario, string contrasena)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var datosProfesor = uow.ProfesorRepositorio.ObtenerPorUsuario(usuario);
                return MapDatosAEntidad(datosProfesor);
            }
        }
    }
}
