using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    [DataContract]
    public class PurchaseOrder
    {
        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public Order Order {get;set;}

        [DataMember]
        public List<OrderedProduct> OrderedProducts {get;set;}

        [DataMember]
        public double SubTotal { get; set; }

        [DataMember]
        public double Tax { get; set; }

        [DataMember]
        public double Total { get; set; }

        [DataMember]
        public int TotalQuanity { get; set; }

        [DataMember]
        public double TotalWeight { get; set; }
    }

    [DataContract]
    public class OrderedProduct
    {
        [DataMember]
        public Product Product {get;set;}

        [DataMember]
        public int quantity { get; set; }
    }
}