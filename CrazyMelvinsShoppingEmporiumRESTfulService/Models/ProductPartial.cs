using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService.Models
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        private sealed class ProductMetadata
        {
            [Required]
            public int prodID { get; set; }

            [Required(AllowEmptyStrings = false)]
            public string prodName { get; set; }
            
            [Required]
            public double price { get; set; }

            [Required]
            public double prodWeight { get; set; }

            [Required]
            public bool inStock { get; set; }
        }
        
    }
}