using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_A04_Website
{
    public partial class Screen2 : System.Web.UI.Page
    {
        int execType;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            //Add Service call code here
            switch(execType)
            {
                //Search
                case 0:
                    break;
                //Update
                case 1:
                    break;
                //Insert
                case 2:
                    break;
                //Delete
                case 3:
                    break;
                default:
                    break;
            }

            Session["ServiceResults"] = "some kind of resulting XML string or whatever from the service for testing";
            Response.Redirect("Screen3.aspx");
        }
    }
}