using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    [DataContract(IsReference = true)]
    public class Customer
    {
        [DataMember]
        public int custID { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastName { get; set; }

        [DataMember]
        public string phoneNumber { get; set; }
    }
}