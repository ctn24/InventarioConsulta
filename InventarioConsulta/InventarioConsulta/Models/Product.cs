namespace InventarioConsulta.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public string Key { get; set; }

        public string Description { get; set; }

        public string Existence { get; set; }

        public string PromoQuantity { get; set; }

        public string PromoPrice { get; set; }

        public string ListPrice { get; set; }

        public string CashPrice { get; set; }

        public string WholesalePrice { get; set; }

        public string WholesalersPrice { get; set; }

        public string Coin { get; set; }

        public string Observations { get; set; }

        //public List<string> CallingCodes { get; set; }

        //public List<double> Latlng { get; set; }

    }
}

