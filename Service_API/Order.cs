using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    public class Order
    {
        public int orderID { get; set; }
        public int customerID { get; set; }
        public string poNumber { get; set; }
        public string orderDate { get; set; }

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
