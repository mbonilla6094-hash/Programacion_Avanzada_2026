namespace ControlEstudiantes
{
    public class Tutor
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
        public int CupoMaximo { get; set; }

        public Tutor(int id, string cedula, string nombres, string apellidos, string especialidad, int cupoMaximo)
        {
            Id = id;
            Cedula = cedula;
            Nombres = nombres;
            Apellidos = apellidos;
            Especialidad = especialidad;
            CupoMaximo = cupoMaximo;
        }

        public Tutor() { }

        public override string ToString()
        {
            return $"{Apellidos} {Nombres} - {Especialidad}";
        }
    }
}
