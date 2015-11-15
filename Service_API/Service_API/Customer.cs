using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    class Customer
    {
        int customerID { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string phoneNumber { get; set; }

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
