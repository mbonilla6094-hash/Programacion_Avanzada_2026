using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class InformeDetalle
    {
        public int InformeDetalleId { get; set; }
        public int InformeCabeceraId { get; set; }
        public int NumeroActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public int PorcentajeActividad { get; set; }
        public string Observacion { get; set; }

        public virtual InformeCabecera InformeCabecera { get; set; }
    }
}
