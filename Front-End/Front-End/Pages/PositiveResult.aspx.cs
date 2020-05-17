using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End.Pages
{
    public partial class PositiveResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ProductName"] != null)
            {
                lblResultFood.Text = Session["ProductName"].ToString();
            }
            else
            {
                lblResultFood.Text = "Error: Product Not Found";
            }
            
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}