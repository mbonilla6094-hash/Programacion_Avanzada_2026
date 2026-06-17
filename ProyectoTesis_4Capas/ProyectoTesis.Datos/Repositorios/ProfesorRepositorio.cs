using System.Linq;
using ProyectoTesis.Datos.Interfaces;

namespace ProyectoTesis.Datos.Repositorios
{
    public class ProfesorRepositorio : RepositorioBase<Profesor>
    {
        public ProfesorRepositorio(SistemaTesisEntities context) : base(context) { }

        public Profesor ObtenerPorUsuario(string usuario)
        {
            return Buscar(p => p.Usuario == usuario && (p.Activo == null || p.Activo == true)).FirstOrDefault();
        }

        public bool ValidarCredenciales(string usuario, string contrasena)
        {
            return Existe(p => p.Usuario == usuario && p.Contrasena == contrasena && (p.Activo == null || p.Activo == true));
        }
    }
}
