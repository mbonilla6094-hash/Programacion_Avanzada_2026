namespace LibreriaGeometria
{
    public class Triangulo
    {
        public Punto VerticeA { get; private set; }
        public Punto VerticeB { get; private set; }
        public Punto VerticeC { get; private set; }

        public double LadoAB { get; private set; }
        public double LadoBC { get; private set; }
        public double LadoCA { get; private set; }

        public Triangulo(Punto a, Punto b, Punto c)
        {
            VerticeA = a;
            VerticeB = b;
            VerticeC = c;
            CalcularLados();
        }

        /// <summary>
        /// Calcula las longitudes de los tres lados en base a la distancia entre los puntos
        /// </summary>
        private void CalcularLados()
        {
            LadoAB = VerticeA.DistanciaA(VerticeB);
            LadoBC = VerticeB.DistanciaA(VerticeC);
            LadoCA = VerticeC.DistanciaA(VerticeA);
        }

        /// <summary>
        /// Verifica si los puntos forman un triangulo valido (usando la desigualdad triangular)
        /// </summary>
        public bool EsTrianguloValido()
        {
            const double EPSILON = 0.0001;

            bool c1 = (LadoAB + LadoBC) > (LadoCA + EPSILON);
            bool c2 = (LadoBC + LadoCA) > (LadoAB + EPSILON);
            bool c3 = (LadoCA + LadoAB) > (LadoBC + EPSILON);

            return c1 && c2 && c3 && LadoAB > 0 && LadoBC > 0 && LadoCA > 0;
        }

        /// <summary>
        /// Determina el tipo de triangulo segun sus lados
        /// </summary>
        public string ObtenerTipoDeTriangulo()
        {
            if (!EsTrianguloValido()) return "No es un triangulo valido";

            const double epsilon = 0.0001;

            bool abIgualBC = Math.Abs(LadoAB - LadoBC) < epsilon;
            bool bcIgualCA = Math.Abs(LadoBC - LadoCA) < epsilon;
            bool caIgualAB = Math.Abs(LadoCA - LadoAB) < epsilon;

            if (abIgualBC && bcIgualCA)
                return "Equilatero";
            else if (abIgualBC || bcIgualCA || caIgualAB)
                return "Isosceles";
            else
                return "Escaleno";
        }

        /// <summary>
        /// Calcula el perimetro del triangulo
        /// </summary>
        public double CalcularPerimetro()
        {
            if (!EsTrianguloValido()) return 0;
            return LadoAB + LadoBC + LadoCA;
        }

        /// <summary>
        /// Calcula el semiperimetro del triangulo
        /// </summary>
        public double CalcularSemiperimetro()
        {
            return CalcularPerimetro() / 2;
        }

        /// <summary>
        /// Calcula el area usando la formula de Heron
        /// </summary>
        public double CalcularArea()
        {
            if (!EsTrianguloValido()) return 0;
            double s = CalcularSemiperimetro(); 
            double area = Math.Sqrt(Math.Max(0, s * (s - LadoAB) * (s - LadoBC) * (s - LadoCA)));
            return area;
        }

        public override string ToString()
        {
            return $"Triangulo compuesto por:\n" +
                   $"  Vertices: A{VerticeA}, B{VerticeB}, C{VerticeC}\n" +
                   $"  Calculando sus lados: LadoAB={LadoAB:F2}, LadoBC={LadoBC:F2}, LadoCA={LadoCA:F2}";
        }
    }
}