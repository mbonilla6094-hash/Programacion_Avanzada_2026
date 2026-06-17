using System;

namespace CajeroAutomatico
{
    public class Transaccion
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoNuevo { get; set; }

        public Transaccion() { }

        public Transaccion(int id, string tipo, decimal monto, DateTime fecha,
                          decimal saldoAnterior, decimal saldoNuevo)
        {
            Id = id;
            Tipo = tipo;
            Monto = monto;
            Fecha = fecha;
            SaldoAnterior = saldoAnterior;
            SaldoNuevo = saldoNuevo;
        }
    }
}
