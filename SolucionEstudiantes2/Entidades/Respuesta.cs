namespace Entidades
{
    public class Respuesta
    {
        public bool   Exitoso { get; set; }
        public string Mensaje { get; set; }
        public object Data    { get; set; }

        public static Respuesta Ok(string mensaje = "Operacion exitosa", object data = null)
        {
            return new Respuesta { Exitoso = true,  Mensaje = mensaje, Data = data };
        }

        public static Respuesta Error(string mensaje)
        {
            return new Respuesta { Exitoso = false, Mensaje = mensaje, Data = null };
        }
    }
}
