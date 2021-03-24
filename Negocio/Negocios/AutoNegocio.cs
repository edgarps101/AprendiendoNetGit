using Datos;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class AutoNegocio : IAutoNegocio
    {
        private readonly ConexionDB conexionDB;

        public AutoNegocio(ConexionDB conexionDB)
        {
            this.conexionDB = conexionDB;
        }

        /// <summary>
        /// Método para consultar todos los autos
        /// </summary>
        /// <returns>Regresa la lista completa de autos de la base de datos</returns>
        public List<Auto> consultar()
        {
            List<Auto> listaDtAuto = new List<Auto>();
            try
            {
                listaDtAuto = conexionDB.consultarAutos();
                return listaDtAuto;
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
            Auto autoDTO = new Auto();
            try
            {
                autoDTO = conexionDB.consultarAuto(id);
                return autoDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método para insertar un auto nuevo
        /// </summary>
        /// <param name="autoDTO"></param>
        public void insertar(Auto autoDTO)
        {
            try
            {
                conexionDB.insertarAuto(autoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para actualizar un auto
        /// </summary>
        /// <param name="autoDTO"></param>
        public void actualizar(Auto autoDTO)
        {
            try
            {
                conexionDB.actualizarAuto(autoDTO);
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
                conexionDB.eliminarAuto(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
