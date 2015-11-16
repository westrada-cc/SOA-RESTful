using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_A04_Website.pages
{
    public partial class Screen3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string results = (string)Session["ServiceResults"];
            outputTxtBox.Text = results;
        }
    }
}