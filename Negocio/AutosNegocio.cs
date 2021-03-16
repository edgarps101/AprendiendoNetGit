using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class AutosNegocio
    {
        public AutosNegocio() { }

        public void listarAutos() {
            List<AutoModelo> listaAutos = new List<AutoModelo>();
            //auto.Add(new Auto(1,"Chevrolet", "Rojo", "2020", 150000));
            //auto.Add(new Auto(2,"Chevrolet", "Rojo", "2020", 150000));
            try
            {
                listaAutos = new ConexionDB().consultarAutos();
                Console.WriteLine("=========================================\n");
                foreach (AutoModelo auto in listaAutos)
                {
                    Console.WriteLine(auto.Id_Auto);
                    Console.WriteLine(auto.Marca);
                    Console.WriteLine(auto.Color);
                    Console.WriteLine(auto.Modelo);
                    Console.WriteLine(auto.Precio);
                    Console.WriteLine();
                    Console.WriteLine("=========================================\n");
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al listar los carros " + e.Message);
            }
        }

    }
}
