using System;
using System.Collections.Generic;
using APICaller;

namespace Front_End.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchBox.Text;
            List<FDAFoodInfo> info = new SimpleAPIClass(searchTerm).getFoodInfo();
            
        }

        protected void btnCreateCustom_Click(object sender, EventArgs e)
        {
            Response.Redirect("Custom_Filter.aspx");
        }

        protected void btnFiltersList_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilterInformation.aspx");
        }
    }
}