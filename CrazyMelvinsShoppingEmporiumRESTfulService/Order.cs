using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    public partial class Order
    {
        public int orderID { get; set; }
        public int custID { get; set; }
        public string poNumber { get; set; }
        public System.DateTime orderDate { get; set; }
    }
}