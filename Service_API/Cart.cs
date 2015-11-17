using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    public class Cart
    {
        public int orderID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }

        // default constructor
        public Cart()
        {

        }

        public Cart(int orderID, int productID, int quantity)
        {
            this.orderID = orderID;
            this.productID = productID;
            this.quantity = quantity;
        }
    }
}
