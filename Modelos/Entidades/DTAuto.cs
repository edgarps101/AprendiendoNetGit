using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Entidades
{
    public class DTAuto : DTEntidadBase
    {
        public int Id_Auto { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public int? Modelo { get; set; }
        public decimal? Precio { get; set; }
        
    }
}
