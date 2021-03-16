using System;
using Microsoft.Data.SqlClient;
using Negocio;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            new AutosNegocio().listarAutos();
        }
    }
}
