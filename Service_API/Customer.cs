using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    public class Customer
    {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }

        // default constructor
        public Customer()
        {

        }

        public Customer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }
    }
}
