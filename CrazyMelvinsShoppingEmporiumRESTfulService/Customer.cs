using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    [DataContract(IsReference = true)]
    public class Customer : IDbModelConvertable<Models.Customer>
    {
        public Customer(Models.Customer dbCustomer)
        {
            this.PopulateFromDbModel(dbCustomer);
        }

        public Customer() { }

        [DataMember]
        public int custID { get; set; }

        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastName { get; set; }

        [DataMember]
        public string phoneNumber { get; set; }

        public Models.Customer GenerateDbModel()
        {
            return new Models.Customer()
            {
                custID = this.custID,
                firstName = this.firstName,
                lastName = this.lastName,
                phoneNumber = this.phoneNumber
            };
        }

        public void PopulateFromDbModel(Models.Customer dbModel)
        {
            if (dbModel == null) { throw new ArgumentNullException(); }

            custID = dbModel.custID;
            firstName = dbModel.firstName;
            lastName = dbModel.lastName;
            phoneNumber = dbModel.phoneNumber;
        }
    }
}