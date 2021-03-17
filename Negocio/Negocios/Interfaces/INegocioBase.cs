using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces
{
    public interface INegocioBase <T>
    {
        List<T> consultar();
        T consultarId(int id);
        void insertar(T objeto);
        void actualizar(T objeto);
        void eliminar(int id);
    }
}
