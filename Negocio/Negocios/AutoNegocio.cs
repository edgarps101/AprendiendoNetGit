using Datos;
using Modelos;
using Modelos.Entidades;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class AutoNegocio : IAutoNegocio
    {
        /// <summary>
        /// Método para consultar todos los autos
        /// </summary>
        /// <returns>Regresa la lista completa de autos de la base de datos</returns>
        public List<AutoModelo> consultar()
        {
            List<AutoModelo> listaAutosModelo = new List<AutoModelo>();
            try
            {
                listaAutosModelo = new ConexionDB().consultarAutos();
                return listaAutosModelo;
            }
            catch (Exception e)
            {
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
                return autoModelo;
            }
            catch (Exception e)
            {
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
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para actualizar un auto
        /// </summary>
        /// <param name="autoModelo"></param>
        public void actualizar(AutoModelo autoModelo)
        {
            try
            {
                new ConexionDB().actualizarAuto(autoModelo);
            }
            catch (Exception e)
            {
                throw;
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
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
