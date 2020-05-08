using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End.Pages
{
    public partial class NegativeResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResultFood.Text = Session["ProductName"].ToString();
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}