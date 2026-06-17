namespace LibreriaGeometria
{
    public class Punto
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Punto(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanciaA(Punto otro)
        {
            double dx = this.X - otro.X;
            double dy = this.Y - otro.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
