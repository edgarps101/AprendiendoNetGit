using System;
using System.Collections.Generic;

#nullable disable

namespace Modelos
{
    public partial class Auto
    {
        public int IdAuto { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public int Modelo { get; set; }
        public decimal? Precio { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public bool Activo { get; set; }
    }
}
