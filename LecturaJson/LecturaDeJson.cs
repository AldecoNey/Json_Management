using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LecturaJson
{
    public class LecturaDeJson
    {
        public static void Main(string[] args)
        {
            LeerJSONFromURL();
        }

        public static void LeerJSONFromURL()
        {
            var url = "https://randomuser.me/api/?results=10";

            WebClient wc = new WebClient();
            string personasJson = wc.DownloadString(url);

            var personas = JsonConvert.DeserializeObject<Persona>(personasJson);
            foreach (Result persona in personas.results)
            {
               Console.WriteLine(persona.name.first + persona.name.last);
                Console.WriteLine("");
            }
        }
    }
}
