﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaJson
{
    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public object postcode { get; set; }
        public Coordenadas coordinates { get; set; }
        public Timezone timezone { get; set; }
    }
}
