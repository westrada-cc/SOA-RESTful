using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        public const int MaxFirstNameLength = 50;

        private sealed class CustomerMetadata
        {
            [Required]
            public int custID { get; set; }
            [Required]
            [StringLength(MaxFirstNameLength)]
            public string firstName { get; set; }
            [Required]
            public string lastName { get; set; }
            [Required]
            public string phoneNumber { get; set; }
        }
    }
}