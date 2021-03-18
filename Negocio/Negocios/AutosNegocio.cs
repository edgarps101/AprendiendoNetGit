using Datos;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class AutosNegocio : IAutosNegocio
    {
        /// <summary>
        /// Método para consultar todos los autos
        /// </summary>
        /// <returns>Regresa la lista completa de autos de la base de datos</returns>
        public List<AutoModelo> consultar()
        {
            List<AutoModelo> listaAutos = new List<AutoModelo>();
            try
            {
                listaAutos = new ConexionDB().consultarAutos();
                Console.WriteLine("=========================================\n");
                foreach (AutoModelo auto in listaAutos)
                {
                    Console.WriteLine("Identificador: " + auto.Id_Auto);
                    Console.WriteLine("Marca: " + auto.Marca);
                    Console.WriteLine("Color:" + auto.Color);
                    Console.WriteLine("Modelo:" + auto.Modelo);
                    Console.WriteLine("Precio:" + auto.Precio);
                    Console.WriteLine();
                    Console.WriteLine("=========================================\n");
                }
                Console.ReadLine();
                return listaAutos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al listar los carros " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para consultar un solo auto por el numero de identificador
        /// </summary>
        /// <param name="id">identificador del auto</param>
        /// <returns>Retorna un onjeto de tipo AutoModelo</returns>
        public AutoModelo consultarId(int id)
        {
            AutoModelo autoModelo = new AutoModelo();
            try
            {
                autoModelo = new ConexionDB().consultarAuto(id);
                Console.WriteLine("=========================================\n");
                Console.WriteLine("Identificador: " + autoModelo.Id_Auto);
                Console.WriteLine("Marca: " + autoModelo.Marca);
                Console.WriteLine("Color:" + autoModelo.Color);
                Console.WriteLine("Modelo:" + autoModelo.Modelo);
                Console.WriteLine("Precio:" + autoModelo.Precio);
                Console.WriteLine();
                Console.WriteLine("=========================================\n");
                return autoModelo;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al buscar auto " + e.Message);
                throw;
            }
        }
        
        /// <summary>
        /// Método para insertar un auto nuevo
        /// </summary>
        /// <param name="autoModelo"></param>
        public void insertar(AutoModelo autoModelo)
        {
            try
            {
                new ConexionDB().insertarAuto(autoModelo);
                Console.WriteLine("Auto agregado exitosamente\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al agregar auto " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para actualizar un auto
        /// </summary>
        /// <param name="autoModelo"></param>
        public void actualizar(AutoModelo autoModelo)
        {
            AutoModelo autoModelo2 = new AutoModelo();
            try
            {
                autoModelo2 = new ConexionDB().consultarAuto(autoModelo.Id_Auto);
                autoModelo.Marca = autoModelo.Marca == "" ? autoModelo2.Marca : autoModelo.Marca;
                autoModelo.Color = autoModelo.Color == "" ? autoModelo2.Color : autoModelo.Color;
                autoModelo.Modelo = autoModelo.Modelo == 0 ? autoModelo2.Modelo : autoModelo.Modelo;
                autoModelo.Precio = autoModelo.Precio == 0 ? autoModelo2.Precio : autoModelo.Precio;
                new ConexionDB().actualizarAuto(autoModelo);
                Console.WriteLine("Auto actualizado exitosamente\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al agregar auto " + e.Message);
            }
        }

        /// <summary>
        /// Método para eliminar un auto
        /// </summary>
        /// <param name="id">identificador del auto</param>
        public void eliminar(int id)
        {
            try
            {
                new ConexionDB().eliminarAuto(id);
                Console.WriteLine("Auto eliminado exitosamente\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al eliminar auto " + e.Message);
            }
        }
    }
}
