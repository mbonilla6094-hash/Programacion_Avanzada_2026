namespace DeCENTAFAREN
{
    internal abstract class Conversion
    {
        protected double Valor { get; set; }

        public Conversion(double valor)
        {
            Valor = valor;
        }

        public abstract double Convertir();

        public abstract string ObtenerDescripcion();
    }
}
