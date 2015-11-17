using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Service_API;

namespace SOA_A04_Website.pages
{
    public partial class Screen3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer results = (Customer)Session["SearchResults"];
            outputTxtBox.Text = "";
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Screen2.aspx");
        }
    }
}