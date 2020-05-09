using System;
using System.Collections.Generic;
using System.Linq;
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
            if(Session["LoginId"] != null)
            {
                lblUsername.Text = (string)Session["LoginName"];
                btnLogin.Visible = false;
                pnlLogin.Visible = true;
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
                if(!customFlag)
                {
                    if (!rdr.HasRows)
                    {
                        List<FDAFoodInfo> info = new SimpleAPIClass(searchTerm).getFoodInfo();
                        if(info == null)
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
                    }
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
                else
                {

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
            btnLogin.Visible = true;
            pnlLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Page.aspx");
        }
    }
}