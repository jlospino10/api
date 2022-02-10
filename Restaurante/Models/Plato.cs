using System;
namespace Restaurante.Models
{
    public class Plato
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
       
        
        public string imagen { get; set; }
          public string restaurante_id { get; set; }

    }
}