using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Servicios
{
    public interface IServicioBase <T>
    {
        List<T> consultar();
        T consultarId(int id);
        void insertar(T objeto);
        void actualizar(T objeto);
        void eliminar(int id);
    }
}
