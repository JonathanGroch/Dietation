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

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
        }

        protected void lbnForgot_Click(object sender, EventArgs e)
        {

        }

        protected void lbnNotRegistered_Click(object sender, EventArgs e)
        {

        }
    }
}