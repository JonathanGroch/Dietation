using Front_End.Models;
using Front_End.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Front_End.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                if (Session["LoginId"] != null)
                {
                    Response.Redirect("Main.aspx");
                }
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Stuff to do check to see if there's already a user with the same email addresss
            if(txtRegisterPassword.Text == txtRegisterPassword2.Text)
            {
                User u = new User(txtRegisterEmail.Text, txtFirstName.Text, txtRegisterPassword.Text, txtLastName.Text);
                MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
                mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
                try
                {
                    mysqlConnection.Open();
                    SQLAccess sqla = new SQLAccess();
                    if(!sqla.CheckEmailAddress(txtRegisterEmail.Text))
                    {
                        lblErrorMsg.Text = "Email address is already registered" +
                            " either login into " + txtRegisterEmail.Text + " or choose a different" +
                            " email address to register with";
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand(u.sqlInsertInto(), mysqlConnection);
                        cmd.ExecuteNonQuery();
                        Session["LoginId"] = u.getLoginId();
                        Session["LoginName"] = txtFirstName.Text + " " + txtLastName.Text;
                        Response.Redirect("Main.aspx");
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
            else
            {
                lblErrorMsg.Text = "Password doesn't match";
            }

        }


    }
}