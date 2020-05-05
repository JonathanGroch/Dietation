<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="Front_End.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Dietation.css" rel="stylesheet" />
</head>
<body>

<div class="login_page">
    <div class="container">
         <form id="loginForm" runat="server">
            <div class="login_block">
                <h3>Welcome back</h3>
                <p>Username or Email Address</p>
                <asp:TextBox ID="txtUsername" placeholder="Enter email here.." runat="server"></asp:TextBox>
                <p>Password</p>
                <asp:TextBox ID="txtPassword" placeholder="Enter password here... " runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" CssClass="dietation-btn" />
                <br />
                <asp:LinkButton ID="lbnForgot" runat="server" OnClick="lbnForgot_Click" CssClass="dietation-lnk">Forgot Password?</asp:LinkButton><asp:LinkButton ID="lbnNotRegistered" runat="server" OnClick="lbnNotRegistered_Click" CssClass="dietation-lnk">Not Registered?</asp:LinkButton>
            </div>
        </form>
    </div>
</div>

</body>
</html>
