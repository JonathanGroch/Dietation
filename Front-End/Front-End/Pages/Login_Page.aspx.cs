using Front_End.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_End
{
    public partial class Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LoginId"] != null)
            {
                Response.Redirect("Main.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text;
            string password = txtPassword.Text;
            
            MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
            mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
            string sqlString = "select userPassword, LoginID from users where EmailAddress='" + email + "'";
            try
            {
                mysqlConnection.Open();

                MySqlCommand cmd = new MySqlCommand(sqlString, mysqlConnection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.HasRows)
                {
                    User u = new User(email);
                    if (u.comparatorPassword(password, rdr[0].ToString()))
                    {
                        Response.Redirect("Main.aspx");
                        Session["LoginId"] = rdr[1].ToString();
                        string sqlString2 = "select FirstName, LastName from user where EmailAddress=" + email;
                        MySqlCommand cmd2 = new MySqlCommand(sqlString, mysqlConnection);
                        MySqlDataReader rdr2 = cmd2.ExecuteReader();
                        Session["LoginName"] = rdr2[0].ToString() + " " + rdr2[1].ToString();
                        Response.Redirect("Main.aspx");
                    }
                    else
                    {
                        lblErrorMsg.Text = "You have entered an invalid username or password";
                    }
                }
                else
                {
                    lblErrorMsg.Text = "You have entered an invalid username or password";
                }

                
            }
            catch
            {

            }
            finally
            {
                mysqlConnection.Close();
            }
        }

        protected void lbnForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnknownResult.aspx");
        }

        protected void lbnNotRegistered_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}