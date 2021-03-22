using System;
using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.Entidades;
using Servicios;

namespace Prueba
{
    class Prueba
    {
        static void Main(string[] args)
        {
            //    int opc, id;
            //    AutoModelo autoModelo = new AutoModelo();
            //    AutoServicios autoServicio = new AutoServicios();
            //    do
            //    {
            //        Console.Clear();
            //        Console.WriteLine("¿Que desea hacer?\n 1.-Consultar autos\n 2.- Agregar un auto\n 3.- Actualizar un auto\n 4.- Eliminar un auto\n 5.- Salir");
            //        opc = int.Parse(Console.ReadLine());
            //        switch (opc)
            //        {
            //            case 1:
            //                Console.Clear();
            //                autoServicio.consultar();
            //                break;
            //            case 2:
            //                Console.Clear();
            //                Console.WriteLine("Ingresa la marca: ");
            //                autoModelo.Marca = Console.ReadLine();
            //                Console.WriteLine("Ingresa el color: ");
            //                autoModelo.Color = Console.ReadLine();
            //                Console.WriteLine("Ingresa el modelo: ");
            //                autoModelo.Modelo = int.Parse(Console.ReadLine());
            //                Console.WriteLine("Ingresa el precio: ");
            //                autoModelo.Precio = decimal.Parse(Console.ReadLine());
            //                autoServicio.insertar(autoModelo);
            //                break;
            //            case 3:
            //                Console.Clear();
            //                Console.WriteLine("Ingresa el identificador: ");
            //                autoModelo.Id_Auto = int.Parse(Console.ReadLine());
            //                autoServicio.consultarId(autoModelo.Id_Auto);
            //                Console.WriteLine("Ingresa la marca: ");
            //                autoModelo.Marca = Console.ReadLine();
            //                Console.WriteLine("Ingresa el color: ");
            //                autoModelo.Color = Console.ReadLine();
            //                Console.WriteLine("Ingresa el modelo: ");
            //                autoModelo.Modelo = int.Parse(Console.ReadLine());
            //                Console.WriteLine("Ingresa el precio: ");
            //                autoModelo.Precio = decimal.Parse(Console.ReadLine());
            //                autoServicio.actualizar(autoModelo);
            //                Console.ReadLine();
            //                break;
            //            case 4:
            //                Console.Clear();
            //                Console.WriteLine("Ingresa el identificador: ");
            //                id = int.Parse(Console.ReadLine());
            //                autoServicio.eliminar(id);
            //                Console.ReadLine();
            //                break;
            //            case 5:
            //                Console.Clear();
            //                Environment.Exit(1);
            //                break;
            //            default:
            //                Console.Clear();
            //                Console.WriteLine("La opción seleccionada no existe, vuelva a intentarlo");
            //                Console.ReadLine();
            //                break;
            //        }
            //    } while (opc > 0 || opc < 6);
        }
    }
}
