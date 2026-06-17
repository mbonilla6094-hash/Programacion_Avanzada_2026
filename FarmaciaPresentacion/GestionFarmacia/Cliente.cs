using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace GestionFarmacia
{
    public class Cliente
    {
      
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public Cliente(int id, string apellidos, string nombres,
                      string cedula, string telefono, string direccion, string correo)
        {
            Id = id;
            Apellidos = apellidos;
            Nombres = nombres;
            Cedula = cedula;
            Telefono = telefono;
            Direccion = direccion;
            Correo = correo;
        }


        public Cliente() { }
        public String NombreCompleto()
        {
            return Apellidos+" "+Nombres;
        }
    }
}
