using Modelos;
using Modelos.Entidades;
using Negocio;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class AutoServicios : IAutoServicio
    {
        public List<DTAuto> consultar()
        {
            List<AutoModelo> listaAutoModelos = new List<AutoModelo>();
            List<DTAuto> listaDTAuto = new List<DTAuto>();
            try
            {
                listaAutoModelos = new AutoNegocio().consultar();
                foreach (AutoModelo auto in listaAutoModelos)
                {
                    var dtAuto = new DTAuto()
                    {
                        Id_Auto = auto.Id_Auto,
                        Marca = auto.Marca,
                        Color = auto.Color,
                        Modelo = auto.Modelo,
                        Precio = auto.Precio
                    };
                    Console.WriteLine("Identificador: " + auto.Id_Auto);
                    Console.WriteLine("Marca: " + auto.Marca);
                    Console.WriteLine("Color:" + auto.Color);
                    Console.WriteLine("Modelo:" + auto.Modelo);
                    Console.WriteLine("Precio:" + auto.Precio);
                    Console.WriteLine();
                    Console.WriteLine("=========================================\n");
                    listaDTAuto.Add(dtAuto);
                }
                Console.ReadLine();
                return listaDTAuto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al listar los carros " + e.Message);
                throw;
            }
        }

        public DTAuto consultarId(int id)
        {
            AutoModelo autoModelo = new AutoModelo();
            try
            {
                autoModelo = new AutoNegocio().consultarId(id);
                var dtAuto = new DTAuto()
                {
                    Id_Auto = autoModelo.Id_Auto,
                    Marca = autoModelo.Marca,
                    Color = autoModelo.Color,
                    Modelo = autoModelo.Modelo,
                    Precio = autoModelo.Precio
                };
                Console.WriteLine("=========================================\n");
                Console.WriteLine("Identificador: " + autoModelo.Id_Auto);
                Console.WriteLine("Marca: " + autoModelo.Marca);
                Console.WriteLine("Color:" + autoModelo.Color);
                Console.WriteLine("Modelo:" + autoModelo.Modelo);
                Console.WriteLine("Precio:" + autoModelo.Precio);
                Console.WriteLine();
                Console.WriteLine("=========================================\n");
                return dtAuto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al buscar auto " + e.Message);
                throw;
            }
        }
        public void insertar(DTAuto dtAuto)
        {
            try
            {
                var autoModelo = new AutoModelo()
                {
                    Id_Auto = dtAuto.Id_Auto,
                    Marca = dtAuto.Marca,
                    Color = dtAuto.Color,
                    Modelo = dtAuto.Modelo,
                    Precio = dtAuto.Precio
                };
                new AutoNegocio().insertar(autoModelo);
                Console.WriteLine("Auto agregado exitosamente\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al agregar auto " + e.Message);
                throw;
            }
        }
        public void actualizar(DTAuto dtAuto)
        {
            AutoModelo autoModelo2 = new AutoModelo();
            try
            {
                autoModelo2 = new AutoNegocio().consultarId(dtAuto.Id_Auto);
                var autoModelo = new AutoModelo()
                {
                    Id_Auto = dtAuto.Id_Auto,
                    Marca = dtAuto.Marca == "" ? autoModelo2.Marca : dtAuto.Marca,
                    Color = dtAuto.Color == "" ? autoModelo2.Color : dtAuto.Color,
                    Modelo = dtAuto.Modelo == 0 ? autoModelo2.Modelo : dtAuto.Modelo,
                    Precio = dtAuto.Precio == 0 ? autoModelo2.Precio : dtAuto.Precio
                };
                new AutoNegocio().actualizar(autoModelo);
                Console.WriteLine("Auto actualizado exitosamente\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al agregar auto " + e.Message);
            }
        }

        public void eliminar(int id)
        {
            try
            {
                new AutoNegocio().eliminar(id);
                Console.WriteLine("Auto eliminado exitosamente\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar auto " + e.Message);
            }
        }
    }
}
