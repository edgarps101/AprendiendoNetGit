using System.Linq;
using Microsoft.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class ConexionDB
    {
        /// <summary>
        /// Cadena de conexión base de datos local
        /// </summary>
        private string cadenaConexion = "Data Source = DESKTOP-EFK49GE\\SQLEXPRESS; Initial Catalog = Prueba; Integrated Security = True";
        private readonly PruebaContext _context;

        public ConexionDB(PruebaContext context)
        {
            this._context = context;
        }

        public List<Auto> consultarAutos()
        {
            try
            {
                var query = from au in _context.Autos
                            orderby au.Color
                            select au;

                var autos = query.ToList();
                return autos;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public Auto consultarAuto(int id)
        {
            try
            {
                var query = from au in _context.Autos
                            where au.IdAuto == id
                            select au;

                var auto = query.FirstOrDefault();
                return auto;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void insertarAuto(Auto auto)
        {
            try
            {
                _context.Autos.Add(auto);
                _context.SaveChanges();

            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void actualizarAuto(Auto auto)
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
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void eliminarAuto(int id)
        {
            try
            {
                var auto = _context.Autos.FirstOrDefault(x => x.IdAuto == id);
                _context.Autos.Remove(auto);
                _context.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
