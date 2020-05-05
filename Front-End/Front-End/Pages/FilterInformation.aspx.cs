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
            PredefinedFilters predefFilt = new PredefinedFilters();
            if(ddlPredefinedFilterSelection.SelectedIndex == 0)
            {
                List<String> glutenfree = predefFilt.getGlutenFree();
                foreach (string element in glutenfree)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else if(ddlPredefinedFilterSelection.SelectedIndex == 1)
            {
                List<String> dairyFree = predefFilt.getDairyFree();
                foreach (string element in dairyFree)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else if(ddlPredefinedFilterSelection.SelectedIndex == 2)
            {
                List<String> nutfree = predefFilt.getNutFree();
                foreach (string element in nutfree)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else if(ddlPredefinedFilterSelection.SelectedIndex == 3)
            {
                List<String> cornfree = predefFilt.getCornFree();
                foreach (string element in cornfree)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else if(ddlPredefinedFilterSelection.SelectedIndex == 4)
            {
                List<String> vegan = predefFilt.getVegan();
                foreach(string element in vegan)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else if(ddlPredefinedFilterSelection.SelectedIndex == 5)
            {
                List<String> vegetarian = predefFilt.getVegetarian();
                foreach(string element in vegetarian)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
            else if(ddlPredefinedFilterSelection.SelectedIndex == 6)
            {
                List<String> pescatarian = predefFilt.getPescatarian();
                foreach (string element in pescatarian)
                {
                    lbxFilterListInfo.Items.Add(element);
                }
            }
        }
    }
}