namespace EJERCICIOS
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
    
            int rangoInicial = 1;
            int rangoFinal = 100;

            int[] primos = ObtenerPrimosSinTerminarEn1(rangoInicial, rangoFinal);

            Console.WriteLine($"Primos entre {rangoInicial} y {rangoFinal} (sin terminar en 1):");
            Console.WriteLine(string.Join(", ", primos));
        }

        /// <summary>
        /// Obtiene un vector de numeros primos en el rango especificado,
        /// excluyendo aquellos que terminan en 1
        /// </summary>
        static int[] ObtenerPrimosSinTerminarEn1(int inicio, int fin)
        {
            List<int> primos = new List<int>();

            for (int numero = Math.Max(2, inicio); numero <= fin; numero++)
            {
           
                if (EsPrimo(numero))
                {
                   
                    if (numero % 10 != 1)
                    {
                        primos.Add(numero);
                    }
                }
            }

            return primos.ToArray();
        }

        /// <summary>
        /// Verifica si un numero es primo
        /// </summary>
        static bool EsPrimo(int numero)
        {
            if (numero < 2) return false;
            if (numero == 2) return true;
            if (numero % 2 == 0) return false;

  
            int limite = (int)Math.Sqrt(numero);

            for (int i = 3; i <= limite; i += 2)
            {
                if (numero % i == 0)
                    return false;
            }

            return true;
        }
    }
}
