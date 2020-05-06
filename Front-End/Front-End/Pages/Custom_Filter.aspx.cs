using Front_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class Custom_Filter : System.Web.UI.Page
    {
        private int lbxIndex = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddIngredient_Click(object sender, EventArgs e)
        {
            String ingredient = txtSearchIngredient.Text;
            ingredient.Trim();
            if(lbxViewableFilterList.Items.FindByText(txtSearchIngredient.Text) == null)
            {
                lbxViewableFilterList.Items.Add(ingredient);
            }
        }

        protected void btnRenameTitle_Click(object sender, EventArgs e)
        {
            lblFilterTitle.Text = txtFilterTitle.Text;
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            lbxViewableFilterList.Items.Clear();
            lblFilterTitle.Text = "";
            txtFilterTitle.Text = "";
            txtSearchIngredient.Text = "";
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            lbxViewableFilterList.Items.RemoveAt(lbxIndex);
        }

        protected void btnClearList_Click(object sender, EventArgs e)
        {
            lbxViewableFilterList.Items.Clear();
        }

        protected void lbxViewableFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxIndex = lbxViewableFilterList.SelectedIndex;
        }

        protected void ctnSaveFilter_Click(object sender, EventArgs e)
        {
            if(Session["CustomerFilter1"] == null)
            {
                CustomFilter cf1 = new CustomFilter(txtFilterTitle.Text, lbxViewableFilterList.Items.Cast<String>().ToList());
                Session["CustomFilter1"] = cf1;
            }
            else if(Session["CustomerFilter2"] == null)
            {
                CustomFilter cf2 = new CustomFilter(txtFilterTitle.Text, lbxViewableFilterList.Items.Cast<String>().ToList());
                Session["CustomFilter2"] = cf2;
            }
            else if(Session["CustomerFilter3"] == null)
            {
                CustomFilter cf3 = new CustomFilter(txtFilterTitle.Text, lbxViewableFilterList.Items.Cast<String>().ToList());
                Session["CustomFilter3"] = cf3;
            }
            Response.Redirect("Main.aspx");

        }
    }
}