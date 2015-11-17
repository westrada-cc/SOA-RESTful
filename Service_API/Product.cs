using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public float productWeight { get; set; }
        public bool soldOut { get; set; }

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
