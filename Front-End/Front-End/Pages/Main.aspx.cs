﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICaller;
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
            string searchTerm = txtSearchBox.Text;
            List<String> selected = new List<String>();
            foreach(ListItem item in cblFilters.Items)
            {
                if(item.Selected)
                {
                    selected.Add(item.Value);
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
                    if(i == selected.Count - 1)
                    {
                        selectedProduct += selected[i] + " ";
                    }
                    else
                    {
                        selectedProduct += selected[i] + ", ";
                    }
                }
                selectedProduct += "from foodfilter where FoodName = \'" + searchTerm + "\'";
                MySqlCommand cmd1 = new MySqlCommand(selectedProduct, mysqlConnection);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                if(!rdr.HasRows)
                {
                    List<FDAFoodInfo> info = new SimpleAPIClass(searchTerm).getFoodInfo();
                    
                }
                else if(rdr.HasRows)
                {
                    rdr.Read();
                    Session["ProductName"] = rdr[selected[0]];
                    foreach (string s in selected)
                    {
                        int flag = (int)rdr[s];
                        if(flag == 0)
                        {
                            directionFlag = false;
                            break;
                        }
                    }
                    if(directionFlag)
                    {
                        Response.Redirect("PositiveResult.aspx");

                    }
                    else
                    {
                        Response.Redirect("NegativeResult.aspx");
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
            btnLogin.Visible = true;
            pnlLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Page.aspx");
        }
    }
}