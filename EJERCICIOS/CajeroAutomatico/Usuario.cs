using System;
using System.Collections.Generic;

namespace CajeroAutomatico
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public decimal Saldo { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string contrasena, decimal saldo)
        {
            Id = id;
            Nombre = nombre;
            Contrasena = contrasena;
            Saldo = saldo;
        }

        public override string ToString()
        {
            return Nombre + " (ID: " + Id + ")";
        }

        /// <summary>
        /// Devuelve la lista de usuarios registrados en el sistema con datos iniciales
        /// </summary>
        public static List<Usuario> ObtenerUsuariosIniciales()
        {
            return new List<Usuario>
            {
                new Usuario(1001, "Mateo Bonilla", "mat2024", 1500.00m),
                new Usuario(1002, "Ana Rodriguez", "ana1234", 3200.50m),
                new Usuario(1003, "Carlos Gomez", "car5678", 850.75m),
                new Usuario(1004, "Maria Lopez", "mar9012", 5000.00m),
                new Usuario(1005, "Jose Martinez", "jos3456", 2100.30m),
                new Usuario(1006, "Laura Fernandez", "lau7890", 4750.00m),
                new Usuario(1007, "Pedro Sanchez", "ped2345", 920.00m),
                new Usuario(1008, "Isabel Perez", "isa6789", 6300.25m),
                new Usuario(1009, "Andres Ramirez", "and0123", 1800.00m),
                new Usuario(1010, "Sofia Castro", "sof4567", 3500.00m)
            };
        }
    }
}
