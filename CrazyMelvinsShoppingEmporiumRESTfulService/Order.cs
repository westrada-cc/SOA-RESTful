using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    public partial class Order : IDbModelConvertable<Models.Order>
    {
        public Order(Models.Order dbOrder)
        {
            this.PopulateFromDbModel(dbOrder);
        }

        public Order() { }

        public int orderID { get; set; }
        public int custID { get; set; }
        public string poNumber { get; set; }
        public System.DateTime orderDate { get; set; }

        public Models.Order GenerateDbModel()
        {
            return new Models.Order()
            {
                orderID = this.orderID,
                custID = this.custID,
                poNumber = this.poNumber,
                orderDate = this.orderDate
            };
        }

        public void PopulateFromDbModel(Models.Order dbModel)
        {
            this.orderID = dbModel.orderID;
            this.custID = dbModel.custID;
            this.poNumber = dbModel.poNumber;
            this.orderDate = dbModel.orderDate;
        }
    }
}