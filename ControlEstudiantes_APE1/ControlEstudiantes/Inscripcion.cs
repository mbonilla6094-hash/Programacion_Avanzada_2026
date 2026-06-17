namespace ControlEstudiantes
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string NombreEstudiante { get; set; }
        public string CedulaEstudiante { get; set; }
        public int TutorId { get; set; }
        public string NombreTutor { get; set; }
        public int HorarioId { get; set; }
        public string DescripcionHorario { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public Inscripcion(int id, int estudianteId, string nombreEstudiante, string cedulaEstudiante,
                          int tutorId, string nombreTutor, int horarioId, string descripcionHorario)
        {
            Id = id;
            EstudianteId = estudianteId;
            NombreEstudiante = nombreEstudiante;
            CedulaEstudiante = cedulaEstudiante;
            TutorId = tutorId;
            NombreTutor = nombreTutor;
            HorarioId = horarioId;
            DescripcionHorario = descripcionHorario;
            FechaInscripcion = DateTime.Now;
        }

        public Inscripcion() { }
    }
}
