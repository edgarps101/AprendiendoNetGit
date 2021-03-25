using Datos;
using System.Linq;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class AutoNegocio : IAutoNegocio
    {
        private readonly PruebaContext _context;

        public AutoNegocio(PruebaContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Método para consultar todos los autos
        /// </summary>
        /// <returns>Regresa la lista completa de autos de la base de datos</returns>
        public List<Auto> consultar()
        {
            try
            {
                var query = from au in _context.Autos
                            select au;

                var autos = query.ToList();
                return autos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para consultar un solo auto por el numero de identificador
        /// </summary>
        /// <param name="id">identificador del auto</param>
        /// <returns>Retorna un onjeto de tipo AutoModelo</returns>
        public Auto consultarId(int id)
        {
            try
            {
                var query = from au in _context.Autos
                            where au.IdAuto == id
                            select au;

                var auto = query.FirstOrDefault();
                return auto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método para insertar un auto nuevo
        /// </summary>
        /// <param name="auto"></param>
        public void insertar(Auto auto)
        {
            try
            {
                _context.Autos.Add(auto);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para actualizar un auto
        /// </summary>
        /// <param name="auto"></param>
        public void actualizar(Auto auto)
        {
            try
            {
                var oldAuto = _context.Autos.Where(x => x.IdAuto == auto.IdAuto).FirstOrDefault();
                oldAuto.Marca = auto.Marca;
                oldAuto.Color = auto.Color;
                oldAuto.Modelo = auto.Modelo;
                oldAuto.Precio = auto.Precio;
                oldAuto.Activo = auto.Activo;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
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
                var auto = _context.Autos.FirstOrDefault(x => x.IdAuto == id);
                _context.Autos.Remove(auto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
