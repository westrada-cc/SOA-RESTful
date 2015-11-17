using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Service_API;
using System.Xml;

namespace SOA_A04_Website.pages
{
    public partial class Screen3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument result = (XmlDocument)Session["SearchResults"];

            outputTxtBox.Text = result.ToString();

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();

            //outputTxtBox.Text = "Customer Information" + Environment.NewLine +
            //                    "ID: " + results.customerID + Environment.NewLine +
            //                    "Name: " + results.firstName + " " + results.lastName + Environment.NewLine +
            //                    "Phone: " + results.phoneNumber + Environment.NewLine +
            //                    Environment.NewLine + "Purchase Date: " + Environment.NewLine +
            //                    Environment.NewLine + "P.O. Number: " + Environment.NewLine;

            //sb.Append("\t\tID:\t\tProduct Name\t\tQuantity\t\tUnit Price\t\tUnit Weight");
            //sb.AppendFormat("\t\t{0}\t\t{1}\t\t{2}\t\t{3}", 1234, "a", 5, 1.99, 10);
            //sb.AppendFormat("\t\t\t\t\t\tSubTotal:\t\t{0}", 40);
            //sb.AppendFormat("\t\t\t\t\t\tTax (13%):\t\t{0}", 13);
            //sb.AppendFormat("\t\t\t\t\t\tTotal:\t\t{0}", 53);

            //outputTxtBox.Text += sb.ToString();

            //outputTxtBox.Text += "Total Number of pieces ordered " + numberOfPieces + Environment.NewLine +
            //                      "Total Weight of order " + totalWeight + " kg.";
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Screen2.aspx");
        }
    }
}