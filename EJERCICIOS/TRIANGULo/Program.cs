using System;
using LibreriaGeometria;

namespace TRIANGULo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CALCULADORA DE TRIANGULOS ===\n");


            Punto a = new Punto(0, 0);
            Punto b = new Punto(4, 0);
            Punto c = new Punto(2, 3.464);

            Triangulo tri = new Triangulo(a, b, c);

            Console.WriteLine(tri.ToString());
            Console.WriteLine("Es Valido?: " + tri.EsTrianguloValido());
            Console.WriteLine("Tipo: " + tri.ObtenerTipoDeTriangulo());
            Console.WriteLine("Perimetro: " + tri.CalcularPerimetro().ToString("F2"));
            Console.WriteLine("Semiperimetro: " + tri.CalcularSemiperimetro().ToString("F2"));
            Console.WriteLine("Area: " + tri.CalcularArea().ToString("F2"));

            Console.WriteLine("\n--- Otro Triangulo ---");
            Punto p1 = new Punto(0, 0);
            Punto p2 = new Punto(3, 0);
            Punto p3 = new Punto(0, 4);

            Triangulo tri2 = new Triangulo(p1, p2, p3);
            Console.WriteLine(tri2.ToString());
            Console.WriteLine("Es Valido?: " + tri2.EsTrianguloValido());
            Console.WriteLine("Tipo: " + tri2.ObtenerTipoDeTriangulo());
            Console.WriteLine("Perimetro: " + tri2.CalcularPerimetro().ToString());
            Console.WriteLine("Semiperimetro: " + tri2.CalcularSemiperimetro().ToString());
            Console.WriteLine("Area: " + tri2.CalcularArea().ToString());
        }
    }
}