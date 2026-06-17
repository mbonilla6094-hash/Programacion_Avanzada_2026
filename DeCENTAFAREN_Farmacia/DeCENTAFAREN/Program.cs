namespace DeCENTAFAREN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la temperatura en Celsius: ");
            double celsius = Convert.ToDouble(Console.ReadLine());

            Conversion conversion = new CentAFaren(celsius);

            Console.WriteLine(conversion.ObtenerDescripcion());
        }
    }
}
