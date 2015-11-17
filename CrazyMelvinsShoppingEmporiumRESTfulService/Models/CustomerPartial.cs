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
        public const int MaxLastNameLength = 50;

        private sealed class CustomerMetadata
        {
            [Required]
            public int custID { get; set; }

            [Required(AllowEmptyStrings = false)]
            [StringLength(MaxFirstNameLength)]
            public string firstName { get; set; }

            [Required(AllowEmptyStrings = false)]
            [StringLength(MaxLastNameLength)]
            public string lastName { get; set; }

            [Required(AllowEmptyStrings=false)]
            [RegularExpression("^\\d{3}-\\d{3}-\\d{4}$")]
            public string phoneNumber { get; set; }
        }
    }
}