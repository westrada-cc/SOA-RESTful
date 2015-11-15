using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    public partial class Product
    {
        public int prodID { get; set; }
        public string prodName { get; set; }
        public double price { get; set; }
        public double prodWeight { get; set; }
        public bool inStock { get; set; }
    }
}