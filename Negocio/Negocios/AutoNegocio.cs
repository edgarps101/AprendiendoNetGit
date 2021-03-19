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
        public List<DTAuto> consultar()
        {
            List<DTAuto> listaDtAuto = new List<DTAuto>();
            try
            {
                listaDtAuto = new ConexionDB().consultarAutos();
                return listaDtAuto;
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
        public DTAuto consultarId(int id)
        {
            DTAuto dtAuto = new DTAuto();
            try
            {
                dtAuto = new ConexionDB().consultarAuto(id);
                return dtAuto;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Método para insertar un auto nuevo
        /// </summary>
        /// <param name="dtAuto"></param>
        public void insertar(DTAuto dtAuto)
        {
            try
            {
                new ConexionDB().insertarAuto(dtAuto);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para actualizar un auto
        /// </summary>
        /// <param name="dtAuto"></param>
        public void actualizar(DTAuto dtAuto)
        {
            try
            {
                new ConexionDB().actualizarAuto(dtAuto);
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
