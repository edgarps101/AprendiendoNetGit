using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces
{
    public interface IAutosNegocio : INegocioBase<AutosNegocio>
    {
        void encender();
        void apagar();
    }
}
