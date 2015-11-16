using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    class Order
    {
        int orderID { get; set; }
        int customerID { get; set; }
        string poNumber { get; set; }
        string orderDate { get; set; }

        // default constructor
        public Order()
        {

        }

        public Order(int orderID, int customerID, string poNumber, string orderDate)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.poNumber = poNumber;
            this.orderDate = orderDate;
        }
    }
}
