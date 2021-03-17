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
        public AutosNegocio() { }//constructor

        /// <summary>
        /// 
        /// </summary>
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
                    Console.WriteLine("Identificador: " + auto.Id_Auto);
                    Console.WriteLine("Marca: " + auto.Marca);
                    Console.WriteLine("Color:" + auto.Color);
                    Console.WriteLine("Modelo:" + auto.Modelo);
                    Console.WriteLine("Precio:" + auto.Precio);
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
        /// <summary>
        /// Método para insertar auto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public void insertarAuto(string marca, string color, int modelo, decimal precio)
        {
            AutoModelo autoModelo = new AutoModelo();
            try
            {
                autoModelo.Marca = marca;
                autoModelo.Color = color;
                autoModelo.Modelo = modelo;
                autoModelo.Precio = precio;
                new ConexionDB().insertarAuto(autoModelo);
                Console.WriteLine("Auto agregado exitosamente\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al agregar auto " + e.Message);
            }
        }

        public void consultarAuto(int id)
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
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al buscar auto " + e.Message);
            }
        }

        public void actualizarAuto(int id, string marca, string color, int? modelo, decimal? precio)
        {
            AutoModelo autoModelo = new AutoModelo();
            AutoModelo autoModelo2 = new AutoModelo();
            try
            {
                autoModelo = new ConexionDB().consultarAuto(id);
                autoModelo2.Id_Auto = autoModelo.Id_Auto;
                autoModelo2.Marca = marca == "" ? autoModelo.Marca : marca;
                autoModelo2.Color = color == "" ? autoModelo.Color : color;
                autoModelo2.Modelo = modelo == 0 ? autoModelo.Modelo : modelo;
                autoModelo2.Precio = precio == 0 ? autoModelo.Precio : precio;
                new ConexionDB().actualizarAuto(autoModelo2);
                Console.WriteLine("Auto actualizado exitosamente\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al agregar auto " + e.Message);
            }
        }

        public void eliminarAuto(int id)
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

        public List<AutosNegocio> consultar()
        {
            throw new NotImplementedException();
        }

        public AutosNegocio consultarId(int id)
        {
            throw new NotImplementedException();
        }

        public void insertar(AutosNegocio objeto)
        {
            throw new NotImplementedException();
        }

        public void actualizar(AutosNegocio objeto)
        {
            throw new NotImplementedException();
        }

        public void eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void encender()
        {
            throw new NotImplementedException();
        }

        public void apagar()
        {
            throw new NotImplementedException();
        }
    }
}
