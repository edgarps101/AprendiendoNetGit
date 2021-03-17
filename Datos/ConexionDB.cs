using Microsoft.Data.SqlClient;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class ConexionDB
    {

        public List<AutoModelo> consultarAutos()
        {
            //cadena de conexion
            string conexion = "Data Source = DESKTOP-EFK49GE\\SQLEXPRESS; Initial Catalog = Prueba; Integrated Security = True";
            List<AutoModelo> listaAutos = new List<AutoModelo>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conexion))
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
                Console.WriteLine(e.ToString());
                return listaAutos;
            }
        }
    }
}
