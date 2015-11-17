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
                    poGenDiv.Visible = false;
                    break;
                case 1:
                case 2:
                case 3:
                    poGenDiv.Visible = true;
                    break;
                default:
                    break;
            }

            execType = exeType;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
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

            //Add Service call code here
            switch(execType)
            {
                //Search
                case 0:
                    Customer results = service.searchCustomer(Convert.ToInt32(customerID), firstName, lastName, phoneNumber);
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

            Session["ServiceResults"] = "some kind of resulting XML string or whatever from the service for testing";
            Server.Transfer("pages/Screen3.aspx");
        }
    }
}