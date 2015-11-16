using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    class Product
    {
        int productID { get; set; }
        string productName { get; set; }
        float price { get; set; }
        float productWeight { get; set; }
        bool soldOut { get; set; }

        // default constructor
        public Product()
        {

        }

        public Product(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.productWeight = productWeight;
            this.soldOut = soldOut;
        }
    }
}
