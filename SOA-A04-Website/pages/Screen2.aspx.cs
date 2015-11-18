using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service_API;
using System.Xml;

namespace SOA_A04_Website
{
    public partial class Screen2 : System.Web.UI.Page
    {
        int execType;
        private Service service;
        public XmlDocument result;

        protected void Page_Load(object sender, EventArgs e)
        {
            service = new Service();

            int exeType = (int)Session["exeType"];
            switch (exeType)
            {
                case 0:
                    CrazyMelvins_po_generator.Visible = true;
                    break;
                case 1:
                case 2:
                case 3:
                    CrazyMelvins_po_generator.Visible = false;
                    break;
                default:
                    break;
            }

            execTypeID.Value = exeType.ToString();
            execType = exeType;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void executeBtn_Click(object sender, EventArgs e)
        {
            //Customer Text Box IDs
            string customerID = custID.Value;
            string firstName = firstNameID.Value;
            string lastName = lastNameID.Value;
            string phoneNumber = phoneNumberID.Value;

            //Product Text Box IDs
            string productID = prodID.Value;
            string productName = prodNameID.Value;
            string price = priceID.Value;
            string productWeight = prodWeightID.Value;
            bool soldOut = soChkBoxID.Checked;

            //Order Text Box IDs
            string _orderID = orderID.Value;
            string customerID2 = custID2.Value;
            string poNumber = poNumberID.Value;
            string orderDate = orderDateID.Value;

            //Cart Text Box IDs
            string _orderID2 = orderID2.Value;
            string productID2 = prodID2.Value;
            string quantity = quantityID.Value;

            Customer customer = new Customer();
            Product product = new Product();
            Order order = new Order();
            Cart cart = new Cart();

            //Add Service call code here
            switch(execType)
            {
                //Search
                case 0:
                    Dictionary<string, string> query = new Dictionary<string, string>();
                    result = new XmlDocument();

                    if (custID.Value != "")
                    {
                        query.Add("custID", customerID);
                    }
                    if (firstNameID.Value != "")
                    {
                        query.Add("firstName", firstName);
                    }
                    if (lastNameID.Value != "")
                    {
                        query.Add("lastName", lastName);
                    }
                    if (phoneNumberID.Value != "")
                    {
                        query.Add("phoneNumber", phoneNumber);
                    }
                    if (prodID.Value != "")
                    {
                        query.Add("prodID", productID);
                    }
                    if (prodNameID.Value != "")
                    {
                        query.Add("prodName", productName);
                    }
                    if (priceID.Value != "")
                    {
                        query.Add("price", price);
                    }
                    if (prodWeightID.Value != "")
                    {
                        query.Add("prodWeight", productWeight);
                    }
                    if (soldOut)
                    {
                        query.Add("soldOut", soldOut.ToString());   
                    }
                    if (orderID.Value != "")
                    {
                        query.Add("orderID", _orderID);
                    }
                    if (custID2.Value != "")
                    {
                        query.Add("order_custID", customerID2);
                    }
                    if (poNumberID.Value != "")
                    {
                        query.Add("poNumber", poNumber);
                    }
                    if (orderDateID.Value != "")
                    {
                        query.Add("orderDate", orderDate);
                    }
                    if (orderID2.Value != "")
                    {
                        query.Add("cart_orderID", _orderID2);
                    }
                    if (prodID2.Value != "")
                    {
                        query.Add("cart_prodID", productID2);
                    }
                    if (quantityID.Value != "")
                    {
                        query.Add("quantity", quantity);
                    }

                    result = service.globalSearch(query);

                    //if (custID.Value != "")
                    //{
                    //    customer = service.searchCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    //}
                    //else if (prodID.Value != "")
                    //{
                    //    float priceConvert;
                    //    float weightConvert;

                    //    float.TryParse(price, out priceConvert);
                    //    float.TryParse(productWeight, out weightConvert);

                    //    product = service.searchProduct(Convert.ToInt32(productID), productName, priceConvert, weightConvert, soldOut);
                    //}
                    //else if (orderID.Value != "")
                    //{
                    //    order = service.searchOrder(Convert.ToInt32(_orderID), Convert.ToInt32(customerID2), poNumber, orderDate);
                    //}
                    //else if (orderID2.Value != "")
                    //{
                    //    cart = service.searchCart(Convert.ToInt32(_orderID2), Convert.ToInt32(productID2), Convert.ToInt32(quantity));
                    //}
                    break;
                //Update
                case 1:
                    if (custID.Value != "")
                    {
                        result = service.updateCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    }
                    else if (prodID.Value != "")
                    {
                        float priceConvert;
                        float weightConvert;

                        float.TryParse(price, out priceConvert);
                        float.TryParse(productWeight, out weightConvert);

                        result = service.updateProduct(Convert.ToInt32(productID), productName, priceConvert, weightConvert, soldOut);
                    }
                    else if (orderID.Value != "")
                    {
                        result = service.updateOrder(Convert.ToInt32(_orderID), Convert.ToInt32(customerID), poNumber, orderDate);
                    }
                    else if (orderID2.Value != "")
                    {
                        result = service.updateCart(Convert.ToInt32(_orderID2), Convert.ToInt32(prodID2), Convert.ToInt32(quantity));
                    }
                    break;
                //Insert
                case 2:
                    if (custID.Value != "")
                    {
                        result = service.insertCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    }
                    else if (prodID.Value != "")
                    {
                        float priceConvert;
                        float weightConvert;

                        float.TryParse(price, out priceConvert);
                        float.TryParse(productWeight, out weightConvert);

                        result = service.insertProduct(Convert.ToInt32(productID), productName, priceConvert, weightConvert, soldOut);
                    }
                    else if (orderID.Value != "")
                    {
                        result = service.insertOrder(Convert.ToInt32(_orderID), Convert.ToInt32(customerID2), poNumber, orderDate);
                    }
                    else if (orderID2.Value != "")
                    {
                        result = service.insertCart(Convert.ToInt32(_orderID2), Convert.ToInt32(productID2), Convert.ToInt32(quantity));
                    }
                    break;
                //Delete
                case 3:
                    if (custID.Value != "")
                    {
                        service.deleteCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    }
                    else if (prodID.Value != "")
                    {
                        float priceConvert;
                        float weightConvert;

                        float.TryParse(price, out priceConvert);
                        float.TryParse(productWeight, out weightConvert);

                        service.deleteProduct(Convert.ToInt32(productID), productName, priceConvert, weightConvert, soldOut);
                    }
                    else if (orderID.Value != "")
                    {
                        service.deleteOrder(Convert.ToInt32(_orderID), Convert.ToInt32(customerID2), poNumber, orderDate);
                    }
                    else if (orderID2.Value != "")
                    {
                        service.deleteCart(Convert.ToInt32(_orderID2), Convert.ToInt32(productID2), Convert.ToInt32(quantity));
                    }
                    break;
                default:
                    break;
            }

            Session["SearchResults"] = result;
            Response.Redirect("Screen3.aspx");
        }
    }
}