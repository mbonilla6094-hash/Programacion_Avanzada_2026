namespace DeCENTAFAREN
{
    internal class CentAFaren : Conversion
    {
        public CentAFaren(double valor) : base(valor)
        {
        }

        public override double Convertir()
        {
            return (Valor * 9 / 5) + 32;
        }

        public override string ObtenerDescripcion()
        {
            return $"{Valor} grados Celsius = {Convertir()} grados Fahrenheit";
        }
    }
}
