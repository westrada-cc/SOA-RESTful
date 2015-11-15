using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    public partial class Product : IDbModelConvertable<Models.Product>
    {
        public Product(Models.Product dbProduct)
        {
            this.PopulateFromDbModel(dbProduct);
        }

        public Product() { }

        public int prodID { get; set; }
        public string prodName { get; set; }
        public double price { get; set; }
        public double prodWeight { get; set; }
        public bool inStock { get; set; }

        public Models.Product GenerateDbModel()
        {
            return new Models.Product()
            {
                prodID = this.prodID,
                prodName = this.prodName,
                price = this.price,
                prodWeight = this.prodWeight,
                inStock = this.inStock
            };
        }

        public void PopulateFromDbModel(Models.Product dbModel)
        {
            prodID = dbModel.prodID;
            prodName = dbModel.prodName;
            price = dbModel.price;
            prodWeight = dbModel.prodWeight;
            inStock = dbModel.inStock;
        }
    }
}