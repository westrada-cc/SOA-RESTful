using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service_API;

namespace SOA_A04_Website
{
    public partial class Screen2 : System.Web.UI.Page
    {
        int execType;
        private Service service;

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
                    if (custID.Value != "")
                    {
                        customer = service.searchCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    }
                    else if (prodID.Value != "")
                    {
                        float priceConvert;
                        float weightConvert;

                        float.TryParse(price, out priceConvert);
                        float.TryParse(productWeight, out weightConvert);

                        product = service.searchProduct(Convert.ToInt32(productID), productName, priceConvert, weightConvert, soldOut);
                    }
                    else if (orderID.Value != "")
                    {
                        order = service.searchOrder(Convert.ToInt32(_orderID), Convert.ToInt32(customerID2), poNumber, orderDate);
                    }
                    else if (orderID2.Value != "")
                    {
                        cart = service.searchCart(Convert.ToInt32(_orderID2), Convert.ToInt32(productID2), Convert.ToInt32(quantity));
                    }
                    break;
                //Update
                case 1:
                    service.updateCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    break;
                //Insert
                case 2:
                    service.insertCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    break;
                //Delete
                case 3:
                    service.deleteCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
                    break;
                default:
                    break;
            }

            //Session["SearchResults"] = results;
            Response.Redirect("Screen3.aspx");
        }
    }
}