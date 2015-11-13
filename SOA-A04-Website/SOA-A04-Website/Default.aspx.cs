using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOA_A04_Website
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Stupid name... I know...
        protected void goToNextScreen(int exeType)
        {
            Session["exeType"] = exeType;
            Server.Transfer("pages/Screen2.aspx");
        }


        protected void searchBtn_Click(object sender, EventArgs e)
        {
            goToNextScreen(0);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            goToNextScreen(1);
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            goToNextScreen(2);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            goToNextScreen(3);
        }
    }
}