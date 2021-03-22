using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces
{
    public interface IBaseNegocio <T>
    {
        List<T> consultar();
        T consultarId(int id);
        void insertar(T objeto);
        void actualizar(T objeto);
        void eliminar(int id);
    }
}
