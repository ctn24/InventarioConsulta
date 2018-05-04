namespace InventarioConsulta.Models
{

    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Product
    {
        public string Name { get; set; }

        public List<string> TopLevelDomain { get; set; }

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        public List<string> CallingCodes { get; set; }

        public string Capital { get; set; }

        public List<string> AltSpellings { get; set; }

        public string Region { get; set; }

        public List<double> Latlng { get; set; }

    }
}
}
