using Modelos;
using Modelos.Entidades;
using Negocio;
using Negocio.Interfaces;
using Servicios.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class AutoServicios : IAutoServicio
    {
        private readonly IAutoNegocio autoNegocio;

        public AutoServicios(IAutoNegocio autoNegocio)
        {
            this.autoNegocio = autoNegocio;
        }

        public List<AutoModelo> consultar()
        {
            List<AutoModelo> listaAutoModelo = new List<AutoModelo>();
            List<DTAuto> listaDTAuto;
            try
            {
                listaDTAuto = autoNegocio.consultar();
                foreach (DTAuto auto in listaDTAuto)
                {
                    var autoModelo = new AutoModelo()
                    {
                        Id_Auto = auto.Id_Auto,
                        Marca = auto.Marca,
                        Color = auto.Color,
                        Modelo = auto.Modelo,
                        Precio = auto.Precio
                    };
                    listaAutoModelo.Add(autoModelo);
                }
                return listaAutoModelo;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public AutoModelo consultarId(int id)
        {
            DTAuto dtAuto = new DTAuto();
            try
            {
                dtAuto = autoNegocio.consultarId(id);
                var autoModelo = new AutoModelo()
                {
                    Id_Auto = dtAuto.Id_Auto,
                    Marca = dtAuto.Marca,
                    Color = dtAuto.Color,
                    Modelo = dtAuto.Modelo,
                    Precio = dtAuto.Precio
                };
                Console.WriteLine("=========================================\n");
                Console.WriteLine("Identificador: " + dtAuto.Id_Auto);
                Console.WriteLine("Marca: " + dtAuto.Marca);
                Console.WriteLine("Color:" + dtAuto.Color);
                Console.WriteLine("Modelo:" + dtAuto.Modelo);
                Console.WriteLine("Precio:" + dtAuto.Precio);
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
        public void insertar(AutoModelo autoModelo)
        {
            try
            {
                var dtAuto = new DTAuto()
                {
                    Id_Auto = autoModelo.Id_Auto,
                    Marca = autoModelo.Marca,
                    Color = autoModelo.Color,
                    Modelo = autoModelo.Modelo,
                    Precio = autoModelo.Precio
                };
                autoNegocio.insertar(dtAuto);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void actualizar(AutoModelo autoModelo)
        {
            DTAuto dtAuto2;
            try
            {
                dtAuto2 = autoNegocio.consultarId(autoModelo.Id_Auto);
                var dtAuto = new DTAuto()
                {
                    Id_Auto = autoModelo.Id_Auto,
                    Marca = autoModelo.Marca == "" ? dtAuto2.Marca : autoModelo.Marca,
                    Color = autoModelo.Color == "" ? dtAuto2.Color : autoModelo.Color,
                    Modelo = autoModelo.Modelo == 0 ? dtAuto2.Modelo : autoModelo.Modelo,
                    Precio = autoModelo.Precio == 0 ? dtAuto2.Precio : autoModelo.Precio
                };
                autoNegocio.actualizar(dtAuto);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                autoNegocio.eliminar(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
