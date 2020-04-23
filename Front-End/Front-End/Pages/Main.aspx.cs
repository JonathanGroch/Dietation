using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchButton_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateCustom_Click(object sender, EventArgs e)
        {
            Response.Redirect("Custom_Filter.aspx");
        }
    }
}