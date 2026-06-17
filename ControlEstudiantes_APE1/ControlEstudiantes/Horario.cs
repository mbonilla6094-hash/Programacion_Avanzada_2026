namespace ControlEstudiantes
{
    public class Horario
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string Aula { get; set; }
        public int TutorId { get; set; }
        public string NombreTutor { get; set; }

        public Horario(int id, string dia, string hora, string aula, int tutorId, string nombreTutor)
        {
            Id = id;
            Dia = dia;
            Hora = hora;
            Aula = aula;
            TutorId = tutorId;
            NombreTutor = nombreTutor;
        }

        public Horario() { }

        public override string ToString()
        {
            return $"{Dia} {Hora} - Aula: {Aula} ({NombreTutor})";
        }
    }
}
