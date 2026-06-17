namespace longarbhor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ingrese la hora (formato 24h): ");
                int hora = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese los minutos: ");
                int minutos = Convert.ToInt32(Console.ReadLine());

                SombraArbol arbol = new SombraArbol(20);
                double sombra = arbol.Calcular(hora, minutos);

                Console.WriteLine("La longitud de la sombra es: " + sombra + " metros");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
