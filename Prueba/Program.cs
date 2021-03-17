using System;
using Microsoft.Data.SqlClient;
using Negocio;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            string marca, color;
            int opc, modelo, id;
            decimal precio;
            do
            {
                Console.Clear();
                Console.WriteLine("¿Que desea hacer?\n 1.-Consultar autos\n 2.- Agregar un auto\n 3.- Actualizar un auto\n 4.- Eliminar un auto\n 5.- Salir");
                //linea = Console.ReadLine();
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        new AutosNegocio().listarAutos();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingresa la marca: ");
                        marca = Console.ReadLine();
                        Console.WriteLine("Ingresa el color: ");
                        color = Console.ReadLine();
                        Console.WriteLine("Ingresa el modelo: ");
                        modelo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingresa el precio: ");
                        precio = decimal.Parse(Console.ReadLine());
                        new AutosNegocio().insertarAuto(marca, color, modelo, precio);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingresa el identificador: ");
                        id = int.Parse(Console.ReadLine());
                        new AutosNegocio().consultarAuto(id);
                        Console.WriteLine("Ingresa la marca: ");
                        marca = Console.ReadLine();
                        Console.WriteLine("Ingresa el color: ");
                        color = Console.ReadLine();
                        Console.WriteLine("Ingresa el modelo: ");
                        modelo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingresa el precio: ");
                        precio = decimal.Parse(Console.ReadLine());
                        new AutosNegocio().actualizarAuto(id, marca, color, modelo, precio);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Ingresa el identificador: ");
                        id = int.Parse(Console.ReadLine());
                        new AutosNegocio().eliminarAuto(id);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opción seleccionada no existe, vuelva a intentarlo");
                        Console.ReadLine();
                        break;
                }
            } while (opc > 0 || opc < 6);
        }
    }
}
