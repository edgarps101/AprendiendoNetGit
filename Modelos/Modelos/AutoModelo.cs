using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
	//Modelo de auto
    public class AutoModelo
    {
        public int Id_Auto { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public int? Modelo { get; set; }
        public decimal? Precio { get; set; }

        public AutoModelo()
        {
        }

        public AutoModelo(int id_Auto, string marca, string color, int modelo, decimal precio)
        {
            this.Id_Auto = id_Auto;
            this.Marca = marca;
            this.Color = color;
            this.Modelo = modelo;
            this.Precio = precio;
        }
    }
}
