using ProyectoTesis.Entidades;

namespace ProyectoTesis.Logica.Interfaces
{
    public interface ILoginServicio
    {
        Profesor Autenticar(string usuario, string contrasena);
    }
}
