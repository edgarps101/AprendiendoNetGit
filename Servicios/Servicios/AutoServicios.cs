using Modelos;
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

        public List<AutoModel> consultar()
        {
            List<Auto> listaAutoDTO = new List<Auto>();
            List<AutoModel> listaAutoModel = new List<AutoModel>();
            try
            {
                listaAutoDTO = autoNegocio.consultar();
                foreach (Auto autoDTO in listaAutoDTO)
                {
                    var autoModelo = new AutoModel()
                    {
                        IdAuto = autoDTO.IdAuto,
                        Marca = autoDTO.Marca,
                        Color = autoDTO.Color,
                        Modelo = autoDTO.Modelo,
                        Precio = autoDTO.Precio,
                        FechaMovimiento = autoDTO.FechaMovimiento,
                        Activo = autoDTO.Activo
                    };
                    listaAutoModel.Add(autoModelo);
                }
                return listaAutoModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public AutoModel consultarId(int id)
        {
            Auto AutoDTO = new Auto();
            try
            {
                AutoDTO = autoNegocio.consultarId(id);
                var autoModelo = new AutoModel()
                {
                    IdAuto = AutoDTO.IdAuto,
                    Marca = AutoDTO.Marca,
                    Color = AutoDTO.Color,
                    Modelo = AutoDTO.Modelo,
                    Precio = AutoDTO.Precio,
                    FechaMovimiento = AutoDTO.FechaMovimiento,
                    Activo = AutoDTO.Activo
                };
                return autoModelo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void insertar(AutoModel autoModelo)
        {
            try
            {
                var AutoDTO = new Auto()
                {
                    Marca = autoModelo.Marca,
                    Color = autoModelo.Color,
                    Modelo = autoModelo.Modelo,
                    Precio = autoModelo.Precio,
                    FechaMovimiento = DateTime.Now,
                    Activo = autoModelo.Activo
                };
                autoNegocio.insertar(AutoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void actualizar(AutoModel autoModelo)
        {
            Auto autoDTO = new Auto();
            try
            {
                autoDTO = autoNegocio.consultarId(autoModelo.IdAuto);
                var AutoDTO = new Auto()
                {
                    IdAuto = autoModelo.IdAuto,
                    Marca = autoModelo.Marca == "" ? autoDTO.Marca : autoModelo.Marca,
                    Color = autoModelo.Color == "" ? autoDTO.Color : autoModelo.Color,
                    Modelo = autoModelo.Modelo == 0 ? autoDTO.Modelo : autoModelo.Modelo,
                    Precio = autoModelo.Precio == 0 ? autoDTO.Precio : autoModelo.Precio,
                    FechaMovimiento = autoDTO.FechaMovimiento,
                    Activo = autoModelo.Activo
                };
                autoNegocio.actualizar(AutoDTO);
            }
            catch (Exception e)
            {
                throw e;
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
                throw e;
            }
        }
    }
}
