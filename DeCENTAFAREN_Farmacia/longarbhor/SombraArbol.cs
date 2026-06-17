namespace longarbhor
{
    internal class SombraArbol
    {
        private int altura;

        public SombraArbol(int altura)
        {
            this.altura = altura;
        }

        public double Calcular(int hora, int minutos)
        {
            if (hora < 6 || hora > 18 || (hora == 18 && minutos > 0) || hora > 23 || minutos < 0 || minutos > 59)
            {
                throw new Exception("El horario esta fuera del rango permitido");
            }

            int minutosDesdeAmanecer = ((hora - 6) * 60) + minutos;
            double anguloGrados = (minutosDesdeAmanecer / 720.0) * 180.0;

            if (anguloGrados == 0 || anguloGrados == 180)
            {
                return double.PositiveInfinity;
            }
            if (anguloGrados == 90)
            {
                return 0;
            }

            double anguloRadianes = (anguloGrados * Math.PI) / 180.0;
            double sombra = Math.Abs(altura / Math.Tan(anguloRadianes));

            return Math.Round(sombra, 2);
        }
    }
}
