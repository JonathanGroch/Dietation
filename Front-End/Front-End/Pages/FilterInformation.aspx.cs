using Front_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End.Pages
{
    public partial class FilterInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFilterInfo_Click(object sender, EventArgs e)
        {
            if(lbxFilterListInfo.Items.Count > 0)
            {
                lbxFilterListInfo.Items.Clear();
                PredefinedFilters predefFilt = new PredefinedFilters();
                List<string> filter = predefFilt.getFilters(ddlPredefinedFilterSelection.SelectedIndex);
                foreach (string element in filter)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else
            {
                PredefinedFilters predefFilt = new PredefinedFilters();
                List<string> filter = predefFilt.getFilters(ddlPredefinedFilterSelection.SelectedIndex);
                foreach (string element in filter)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }

            
        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}