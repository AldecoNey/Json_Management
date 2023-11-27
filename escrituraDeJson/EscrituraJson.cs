using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace escrituraDeJson
{

    public class EscritorData
    {
        public long id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public List<string> libros { get; set; }
    }
    public class EscrituraJson
    {
        public static void Main(string[] args)
        {
            //ConexionDB db = new ConexionDB();
            //db.CrearTablas();
            
            Escritor escritor1 = new Escritor();
            escritor1.id = 1;
            escritor1.apellido = "Kafka";
            escritor1.nombre = "Franz";
            escritor1.dni = "123432";
            escritor1.libros = new List<Libro>();

            Libro libro1 = new Libro();
            libro1.nombre = "La metamorfosis";
            libro1.anioDePublicacion = 1915;
            libro1.editorial = "Ribolti";
            libro1.escritor = escritor1;

            Libro libro2 = new Libro();
            libro2.nombre = "Cartas a Milena";
            libro2.anioDePublicacion = 1952;
            libro2.editorial = "Messi";
            libro2.escritor = escritor1;

            escritor1.libros.Add(libro1);
            escritor1.libros.Add(libro2);

            Escritor escritor2 = new Escritor();
            escritor2.id = 2;
            escritor2.apellido = "Wilde";
            escritor2.nombre = "Oscar";
            escritor2.dni = "123432";
            escritor2.libros = new List<Libro>();

            Libro libro3 = new Libro();
            libro3.nombre = "El retrato de Dorian Gray";
            libro3.anioDePublicacion = 1915;
            libro3.editorial = "Ribolti";
            libro3.escritor = escritor2;

            escritor2.libros.Add(libro3);

            //db.CargarDatosDePruebaEscritor(escritor1.apellido, escritor1.nombre, escritor1.dni);
            //db.CargarDatosDePruebaEscritor(escritor2.apellido, escritor2.nombre, escritor2.dni);

            //db.CargarDatosDePruebaLibro(libro1.nombre, libro1.anioDePublicacion, libro1.editorial, libro1.escritor.id);
            //db.CargarDatosDePruebaLibro(libro2.nombre, libro2.anioDePublicacion, libro2.editorial, libro2.escritor.id);
            //db.CargarDatosDePruebaLibro(libro3.nombre, libro3.anioDePublicacion, libro3.editorial, libro3.escritor.id);

            string path = @"C:\Users\neyda\OneDrive\Escritorio\UTN\Lab\TP_Json\escrituraDeJson\archivoJSON.json";

            var escritorData1 = new EscritorData
            {
                id = escritor1.id,
                apellido = escritor1.apellido,
                nombre = escritor1.nombre,
                dni = escritor1.dni,
                libros = escritor1.libros.Select(libro => libro.nombre).ToList()
            };

            var escritorData2 = new EscritorData
            {
                id = escritor2.id,
                apellido = escritor2.apellido,
                nombre = escritor2.nombre,
                dni = escritor2.dni,
                libros = escritor2.libros.Select(libro => libro.nombre).ToList()
            };

            var escritoresData = new List<EscritorData> { escritorData1, escritorData2 };
            EscribirJsonFile(escritoresData, path);

        }

        public static void EscribirJsonFile(List<EscritorData> escritores, string pathFile)
        {
            string jsonFile = JsonConvert.SerializeObject(escritores.ToArray(), Formatting.Indented);
            File.WriteAllText(pathFile, jsonFile);
        }
    }
}
