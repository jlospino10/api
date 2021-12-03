using System;
namespace Restaurante.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
       
        public string user { get; set; }
        public string pass { get; set; }
        public string imagen { get; set; }

    }
}