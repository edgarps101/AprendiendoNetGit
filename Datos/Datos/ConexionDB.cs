using Microsoft.Data.SqlClient;
using Modelos;
using Modelos.Entidades;
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

        public List<AutoModelo> consultarAutos()
        {
            List<AutoModelo> listaAutos = new List<AutoModelo>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.cadenaConexion))
                {
                    String sql = "SELECT * FROM Autos";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AutoModelo autoModelo = new AutoModelo();
                                autoModelo.Id_Auto = (int)reader["Id_Auto"];
                                autoModelo.Marca = (string)reader["Marca"];
                                autoModelo.Color = (string)reader["Color"];
                                autoModelo.Modelo = (int)reader["Modelo"];
                                autoModelo.Precio = (decimal)reader["Precio"];
                                listaAutos.Add(autoModelo);
                            }
                        }
                        connection.Close();
                    }
                }
                return listaAutos;
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void insertarAuto(AutoModelo auto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.cadenaConexion))
                {
                    String sql = "INSERT INTO Autos VALUES ('" + auto.Marca+ "', '" + auto.Color + "', " + auto.Modelo + ", " + auto.Precio + ", GETDATE(), 1)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public AutoModelo consultarAuto(int id)
        {
            AutoModelo autoModelo = new AutoModelo();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.cadenaConexion))
                {
                    String sql = "SELECT * FROM Autos WHERE Id_Auto = " + id;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //AutoModelo autoModelo = new AutoModelo();
                                autoModelo.Id_Auto = (int)reader["Id_Auto"];
                                autoModelo.Marca = (string)reader["Marca"];
                                autoModelo.Color = (string)reader["Color"];
                                autoModelo.Modelo = (int)reader["Modelo"];
                                autoModelo.Precio = (decimal)reader["Precio"];
                            }
                        }
                        connection.Close();
                    }
                }
                return autoModelo;
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void actualizarAuto(AutoModelo auto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.cadenaConexion))
                {
                    String sql = "UPDATE Autos SET Marca = '" + auto.Marca + "', Color = '" + auto.Color + "', Modelo = " + auto.Modelo + ", Precio = " + auto.Precio + " WHERE Id_Auto = " + auto.Id_Auto;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }

        public void eliminarAuto(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.cadenaConexion))
                {
                    String sql = "DELETE FROM Autos WHERE Id_Auto = " + id;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
        }
    }
}
