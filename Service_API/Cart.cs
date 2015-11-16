using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    class Cart
    {
        int orderID { get; set; }
        int productID { get; set; }
        int quantity { get; set; }

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
