using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace escrituraDeJson
{
    public class Libro
    {
        public string nombre { get; set; }
        public int anioDePublicacion { get; set; }
        public string editorial { get; set; }

        [JsonIgnore] // Agrega esta anotación para evitar la serialización de la propiedad escritor
        public Escritor escritor { get; set; }
    }
}
