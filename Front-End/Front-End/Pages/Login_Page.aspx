<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="Front_End.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<div class="login_page">
    <div class="container">
        <div class="row">
            <div class="login_block">
                <div class="row">
                    <p>Username or Email Address</p>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <p>Password</p>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Button ID="btnLogin" runat="server" Text="Log In" />
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbnForgot" runat="server">Forgot Password?</asp:LinkButton><asp:LinkButton ID="lbnNotRegistered" runat="server">Not Registered?</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
