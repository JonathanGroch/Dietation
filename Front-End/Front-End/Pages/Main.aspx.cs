using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICaller;
using Dietation_Test;
using Front_End.Models;
using MySql.Data.MySqlClient;

namespace Front_End.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginId"] != null)
            {
                lblUsername.Text = (string)Session["LoginName"];
                btnLogin.Visible = false;
                pnlLogin.Visible = true;
            }
            if (Session["CustomFilter1"] != null || Session["CustomFilter2"] != null || Session["CustomerFilter3"] != null) {
                if(Session["CustomFilter3"] != null && Session["CustomFilter2"] != null && Session["CustomFilter1"] != null)
                {
                    CustomFilter cf1 = (CustomFilter)Session["CustomFilter1"];
                    CustomFilter cf2 = (CustomFilter)Session["CustomFilter2"];
                    CustomFilter cf3 = (CustomFilter)Session["CustomFilter3"];
                    cblFilters.Items.FindByValue("0").Text = cf1.Title;
                    cblFilters.Items.FindByValue("1").Text = cf2.Title;
                    cblFilters.Items.FindByValue("2").Text = cf3.Title;

                }
                else if(Session["CustomFilter2"] != null && Session["CustomFilter1"] != null)
                {
                    CustomFilter cf1 = (CustomFilter)Session["CustomFilter1"];
                    CustomFilter cf2 = (CustomFilter)Session["CustomFilter2"];
                    cblFilters.Items.FindByValue("0").Text = cf1.Title;
                    cblFilters.Items.FindByValue("1").Text = cf2.Title;
                }
                else
                {
                    CustomFilter cf1 = (CustomFilter)Session["CustomFilter1"];
                    cblFilters.Items.FindByValue("0").Text = cf1.Title;
                }
                
            }
        }

        protected void btnSearchButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid) { 
            bool directionFlag = true;
            bool customFlag = false;
            string searchTerm = txtSearchBox.Text;
            List<String> selected = new List<String>();
            foreach(ListItem item in cblFilters.Items)
            {
                if(item.Selected)
                {
                    selected.Add(item.Value);
                    if((item.Value).All(char.IsDigit))
                    {
                        customFlag = true;
                    }
                }
            }
            //Sql Connection info
            MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
            try
            {
                mysqlConnection.Open();
                string selectedProduct = "select FoodName, ";
                //Gets all the predefined filters
                for(int i = 0; i < selected.Count; i++)
                {
                    if(!customFlag)
                    {
                        if (i == selected.Count - 1)
                        {
                            selectedProduct += selected[i] + " ";
                        }
                        else
                        {
                            selectedProduct += selected[i] + ", ";
                        }
                    }
                    else
                    {
                            //Get predefined and detects custom filters 
                        if((selected[i]).All(char.IsDigit))
                        {
                            selectedProduct.Substring(0, selectedProduct.Length - 2);
                            break;
                        }
                        else if (i == selected.Count - 1)
                        {
                            selectedProduct += selected[i] + " ";
                        }
                        else
                        {
                            selectedProduct += selected[i] + ", ";
                        }
                    }

                }
                //API call to FDA database
                List<FDAFoodInfo> info = new SimpleAPIClass(searchTerm).getFoodInfo();
                FDAFoodInfo topValue = info.ElementAt(0);
                if (info == null)
                {
                    Response.Redirect("UnknownResult.aspx");
                }
                selectedProduct += "from foodfilter where FoodName = \'" + topValue.foodName + "\'";
                MySqlCommand cmd1 = new MySqlCommand(selectedProduct, mysqlConnection);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                //Executes the database search
                //No Custom Filter
                if(!customFlag)
                {
                    //Nothing in database
                    if (!rdr.HasRows)
                    {
                        //Load in classes, cls -> is a compare list on list
                        //Load prefilters holds the predefined filter values
                        CompareListsSearching cls = new CompareListsSearching();
                        PredefinedFilters preFilters = new PredefinedFilters();
                        //sqla commands that fill the database
                        SQLAccess sqla = new SQLAccess();
                        sqla.FillIngredients(topValue.foodName, topValue.foodIngredients);
                        sqla.FillPrefilters(topValue.foodName, topValue.foodBrand, topValue.foodIngredients);
                        //Sets session cookie to loginId
                        Session["ProductName"] = topValue.foodName;
                        //Compare predefined filters against ingredients of the product
                        foreach (string s in selected)
                        {
                            if (!cls.Compare(preFilters.getFilters(s), topValue.foodIngredients))
                            {
                                directionFlag = false;
                                break;
                            }
                        }
                        //If direction is false then its a negative value
                        if (directionFlag)
                        {
                            Response.Redirect("PositiveResult.aspx");

                        }
                        else
                        {
                            Response.Redirect("NegativeResult.aspx");
                        }

                    }

                    //Item detected in database
                    else if (rdr.HasRows)
                    {
                        //Reads 
                        rdr.Read();
                        Session["ProductName"] = topValue.foodName;
                        //Looks through the database to see the if predefined filters values
                        //Equal 0 in any place, if so then return a false
                        foreach (string s in selected)
                        {
                            int flag = (int)rdr[s];
                            if (flag == 0)
                            {
                                directionFlag = false;
                                break;
                            }
                        }
                        if (directionFlag)
                        {
                            Response.Redirect("PositiveResult.aspx");

                        }
                        else
                        {
                            Response.Redirect("NegativeResult.aspx");
                        }
                    }
                }
                //Custom Filters
                else
                {
                    if (!rdr.HasRows)
                    {
                        //Future Feature have a list of items for the customer to choose from when searching
                        SQLAccess sqla = new SQLAccess();
                        sqla.FillIngredients(topValue.foodName, topValue.foodIngredients);
                        sqla.FillPrefilters(topValue.foodName, topValue.foodBrand, topValue.foodIngredients);
                        CompareListsSearching cls = new CompareListsSearching();
                        PredefinedFilters preFilters = new PredefinedFilters();
                        Session["ProductName"] = topValue.foodName;
                        foreach (string s in selected)
                        {
                            if (!cls.Compare(preFilters.getFilters(s), topValue.foodIngredients))
                            {
                                directionFlag = false;
                                break;
                            }
                        }
                        if (directionFlag)
                        {

                            List<List<String>> customFilters = new List<List<String>>();
                            foreach (ListItem item in cblFilters.Items)
                            {
                                switch (item.Value)
                                {
                                    case "0":
                                        CustomFilter cf1 = (CustomFilter)Session["CustomFilter1"];
                                        customFilters.Add(cf1.Ingredients);
                                        break;
                                    case "1":
                                        CustomFilter cf2 = (CustomFilter)Session["CustomFilter2"];
                                        customFilters.Add(cf2.Ingredients);
                                        break;
                                    case "2":
                                        CustomFilter cf3 = (CustomFilter)Session["CustomFilter3"];
                                        customFilters.Add(cf3.Ingredients);
                                        break;
                                }
                            }
                            foreach (List<String> ls in customFilters)
                            {
                                if (!cls.Compare(ls, topValue.foodIngredients))
                                {
                                    directionFlag = false;
                                    break;
                                }
                            }


                        }
                        if (directionFlag)
                        {
                            Response.Redirect("PositiveResult.aspx");

                        }
                        else
                        {
                            Response.Redirect("NegativeResult.aspx");
                        }

                    }
                    else if (rdr.HasRows)
                    {
                        rdr.Read();
                        Session["ProductName"] = topValue.foodName;
                        foreach (string s in selected)
                        {
                            int flag = (int)rdr[s];
                            if (flag == 0)
                            {
                                directionFlag = false;
                                break;
                            }
                        }
                        //If predefined filters through back false, why should the program
                        //search the custom filters?
                        if (directionFlag)
                        {
                            //Searchs the custom filters
                            List<List<String>> customFilters = new List<List<String>>();
                            foreach (ListItem item in cblFilters.Items)
                            {
                                switch (item.Value)
                                {
                                    case "0":
                                        CustomFilter cf1 = (CustomFilter)Session["CustomFilter1"];
                                        customFilters.Add(cf1.Ingredients);
                                        break;
                                    case "1":
                                        CustomFilter cf2 = (CustomFilter)Session["CustomFilter2"];
                                        customFilters.Add(cf2.Ingredients);
                                        break;
                                    case "2":
                                        CustomFilter cf3 = (CustomFilter)Session["CustomFilter3"];
                                        customFilters.Add(cf3.Ingredients);
                                        break;
                                }
                            }
                            SQLAccess sqla = new SQLAccess();
                            List<String> ingredients = new List<String>();
                            sqla.GetIngredients(rdr[selected[0]].ToString(), ingredients);
                            CompareListsSearching cls = new CompareListsSearching();
                            foreach(List<String> ls in customFilters)
                            {
                                if(!cls.Compare(ls, ingredients))
                                {
                                    directionFlag = false;
                                    break;
                                }
                            }
                        }
                        if (directionFlag)
                        {
                            Response.Redirect("PositiveResult.aspx");

                        }
                        else
                        {
                            Response.Redirect("NegativeResult.aspx");
                        }
                    }
                }

            }
            catch(ThreadAbortException except)
            {
                Console.WriteLine("Exception ThreadAborted: {0}", except.Message);
            }
            catch
            {
                Response.Redirect("UnknownResult.aspx");
            }
            finally
            {
                mysqlConnection.Close();
            }

            }

        }

        protected void btnCreateCustom_Click(object sender, EventArgs e)
        {
            if(Session["LoginId"] != null)
            {
                Response.Redirect("Custom_Filter.aspx");
            }
            else
            {
                Response.Redirect("Login_Page.aspx");
            }

        }

        protected void btnFiltersList_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilterInformation.aspx");
        }

        protected void lnbSignOut_Click(object sender, EventArgs e)
        {
            //Reset everything to null, visibility or reassign value texts
            Session["LoginId"] = null;
            Session["LoginName"] = null;
            Session["CustomFilter1"] = null;
            Session["CustomFilter2"] = null;
            Session["CustomFilter3"] = null;
            cblFilters.Items.FindByValue("0").Text = "Custom_Filter_1";
            cblFilters.Items.FindByValue("1").Text = "Custom_Filter_2";
            cblFilters.Items.FindByValue("2").Text = "Custom_Filter_3";
            btnLogin.Visible = true;
            pnlLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Page.aspx");
        }

        protected void lnbUserInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_Information_Page.aspx");
        }

        protected void ctvCheckboxValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cblFilters.SelectedIndex != -1)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}