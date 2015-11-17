using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService.Models
{
    [MetadataType(typeof(CartMetadata))]
    public partial class Cart
    {
        private sealed class CartMetadata
        {
            [Required]
            public int orderID { get; set; }

            [Required]
            public int prodID { get; set; }

            [Required]
            public int quantity { get; set; }
        }
        
    }
}