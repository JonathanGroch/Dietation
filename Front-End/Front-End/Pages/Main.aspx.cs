using System;
using System.Collections.Generic;
using System.Linq;
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
            MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
            try
            {
                mysqlConnection.Open();
                string selectedProduct =  "select FoodName, ";
                
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
                selectedProduct += "from foodfilter where FoodName = \'" + searchTerm + "\'";
                MySqlCommand cmd1 = new MySqlCommand(selectedProduct, mysqlConnection);
                MySqlDataReader rdr = cmd1.ExecuteReader();

                //No Custom Filter
                if(!customFlag)
                {
                    //Nothing in database
                    if (!rdr.HasRows)
                    {
                        List<FDAFoodInfo> info = new SimpleAPIClass(searchTerm).getFoodInfo();
                        Parallel.Invoke(() =>
                        {
                            if (info == null)
                            {
                                Response.Redirect("UnknownResult.aspx");
                            }
                            else
                            {
                                //Future Feature have a list of items for the customer to choose from when searching
                                FDAFoodInfo principleFood = info.ElementAt(0);
                                CompareListsSearching cls = new CompareListsSearching();
                                PredefinedFilters preFilters = new PredefinedFilters();
                                Session["ProductName"] = principleFood.foodName;
                                foreach (string s in selected)
                                {
                                    if (!cls.Compare(preFilters.getFilters(s), principleFood.foodIngredients))
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
                        }, () =>
                        {
                            if(info == null)
                            {
                                Response.Redirect("UnknownResult.aspx");
                            }
                            else
                            {
                                FDAFoodInfo principleFood = info.ElementAt(0);
                                SQLAccess sqla = new SQLAccess();
                                sqla.FillIngredients(principleFood.foodName, principleFood.foodIngredients);
                                sqla.FillPrefilters(principleFood.foodName, principleFood.foodIngredients);

                            }
                        });


                    }
                    //Item detected in database
                    else if (rdr.HasRows)
                    {
                        rdr.Read();
                        Session["ProductName"] = rdr[selected[0]];
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
                        List<FDAFoodInfo> info = new SimpleAPIClass(searchTerm).getFoodInfo();
                        Parallel.Invoke(() =>
                        {
                            if (info == null)
                            {
                                Response.Redirect("UnknownResult.aspx");
                            }
                            else
                            {
                                //Future Feature have a list of items for the customer to choose from when searching
                                FDAFoodInfo principleFood = info.ElementAt(0);
                                CompareListsSearching cls = new CompareListsSearching();
                                PredefinedFilters preFilters = new PredefinedFilters();
                                Session["ProductName"] = principleFood.foodName;
                                foreach (string s in selected)
                                {
                                    if (!cls.Compare(preFilters.getFilters(s), principleFood.foodIngredients))
                                    {
                                        directionFlag = false;
                                        break;
                                    }
                                }
                                if (directionFlag)
                                {
                                    
                                    List<List<String>> customFilters = new List<List<String>>();
                                    foreach(ListItem item in cblFilters.Items)
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
                                        if (!cls.Compare(ls, principleFood.foodIngredients))
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
                        }, () =>
                        {
                            FDAFoodInfo principleFood = info.ElementAt(0);
                            SQLAccess sqla = new SQLAccess();
                            sqla.FillIngredients(principleFood.foodName, principleFood.foodIngredients);
                            sqla.FillPrefilters(principleFood.foodName, principleFood.foodIngredients);
                        });

                    }
                    else if (rdr.HasRows)
                    {
                        rdr.Read();
                        Session["ProductName"] = rdr[selected[0]].ToString();
                        foreach (string s in selected)
                        {
                            int flag = (int)rdr[s];
                            if (flag == 0)
                            {
                                directionFlag = false;
                                break;
                            }
                        }
                        mysqlConnection.Close();
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
            catch
            {
                Response.Redirect("UnknownResult.aspx");
            }
            finally
            {
                mysqlConnection.Close();
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
            Session["LoginId"] = null;
            Session["LoginName"] = null;
            Session["CustomFilter1"] = null;
            Session["CustomFilter2"] = null;
            Session["CustomFilter3"] = null;
            btnLogin.Visible = true;
            pnlLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Page.aspx");
        }
    }
}