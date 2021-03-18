using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Entidades
{
    public abstract class DTEntidadBase
    {
        public DateTime Fecha_Movimiento { set; get; }
        public bool Activo { get; set; }
    }
}
