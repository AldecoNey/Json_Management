﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escrituraDeJson
{
    public class Escritor
    {
        public long id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public List<Libro> libros { get; set; }
    }
}
