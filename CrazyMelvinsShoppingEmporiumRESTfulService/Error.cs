using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string Info { get; private set; }

        [DataMember]
        public string Details { get; private set; }

        public Error(string info, string details)
        {
            this.Info = info;
            this.Details = details;
        }
    }
}