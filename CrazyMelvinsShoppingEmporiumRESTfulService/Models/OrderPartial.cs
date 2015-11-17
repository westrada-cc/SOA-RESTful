using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService.Models
{
    [MetadataType(typeof(OrderMetadata))]
    public partial class Order
    {
        private sealed class OrderMetadata
        {
            [Required]
            public int orderID { get; set; }

            [Required]
            public int custID { get; set; }

            public string poNumber { get; set; }

            [Required]
            public System.DateTime orderDate { get; set; }

        }
        
    }
}