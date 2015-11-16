using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    public partial class Cart : IDbModelConvertable<Models.Cart>
    {
        public Cart(Models.Cart dbCart)
        {
            this.PopulateFromDbModel(dbCart);
        }

        public Cart() { }

        public int orderID { get; set; }
        public int prodID { get; set; }
        public int quantity { get; set; }

        public Models.Cart GenerateDbModel()
        {
            return new Models.Cart()
            {
                orderID = this.orderID,
                prodID = this.prodID,
                quantity = this.quantity
            };
        }

        public void PopulateFromDbModel(Models.Cart dbModel)
        {
            this.orderID = dbModel.orderID;
            this.prodID = dbModel.prodID;
            this.quantity = dbModel.quantity;
        }
    }
}