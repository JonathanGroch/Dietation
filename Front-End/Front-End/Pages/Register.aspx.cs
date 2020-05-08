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
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
            if(txtRegisterPassword.Text == txtRegisterPassword2.Text)
            {
                string loginIdAssignment = RandomString(16);
                User u = new User(txtRegisterEmail.Text, txtFirstName.Text, loginIdAssignment, txtRegisterPassword.Text, txtLastName.Text);
                MySql.Data.MySqlClient.MySqlConnection mysqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
                mysqlConnection.ConnectionString = "server=127.0.0.1;uid=root;pwd=Defense;database=Dietation";
                try
                {
                    mysqlConnection.Open();

                    MySqlCommand cmd = new MySqlCommand(u.sqlInsertInto(), mysqlConnection);
                    cmd.ExecuteNonQuery();
                    Session["LoginId"] = loginIdAssignment;
                    Session["LoginName"] = txtFirstName.Text + " " + txtLastName.Text;
                }
                catch
                {
                    Response.Redirect("UnknownResult.aspx");
                }
                finally
                {
                    mysqlConnection.Close();
                    Response.Redirect("Main.aspx");
                }
            }
            else
            {
                lblErrorMsg.Text = "Password doesn't match";
            }

        }


    }
}