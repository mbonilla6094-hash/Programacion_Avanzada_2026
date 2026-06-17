namespace ControlEstudiantes
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public Estudiante(int id, string cedula, string nombres, string apellidos, string correo, string telefono)
        {
            Id = id;
            Cedula = cedula;
            Nombres = nombres;
            Apellidos = apellidos;
            Correo = correo;
            Telefono = telefono;
        }

        public Estudiante() { }

        public override string ToString()
        {
            return $"{Apellidos} {Nombres} ({Cedula})";
        }
    }
}
