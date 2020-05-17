using Front_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class User_Information_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LoginId"] == null)
            {
                Response.Redirect("Login_Page.aspx");
            }
            else
            {
                List<String> information = new List<String>();
                SQLAccess sqla = new SQLAccess();
                sqla.GetUserInformation(Session["LoginId"].ToString(), information);

            }
        }
    }
}