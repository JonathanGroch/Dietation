<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="Front_End.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Approval.css" rel="stylesheet" />
</head>
<body>

<div class="login_page">
    <div class="container">
         <form id="loginForm" runat="server">
            <div class="login_block">
                <h3>Welcome back</h3>
                <p>Username or Email Address</p>
                <asp:TextBox ID="txtUsername" placeholder="Enter email here.." runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" CssClass="font-weight-bold text-danger" Display="Dynamic" ErrorMessage="Please enter a username or email."></asp:RequiredFieldValidator>
                <p>Password</p>
                <asp:TextBox ID="txtPassword" placeholder="Enter password here... " runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" CssClass="font-weight-bold text-danger" Display="Dynamic" ErrorMessage="Please enter a password."></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" CssClass="btn dietation-btn" />
                <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                <br />
                <asp:LinkButton ID="lbnForgot" runat="server" OnClick="lbnForgot_Click" CssClass="dietation-lnk" CausesValidation="False">Forgot Password?</asp:LinkButton>
                <br />
                <asp:LinkButton ID="lbnNotRegistered" runat="server" OnClick="lbnNotRegistered_Click" CssClass="dietation-lnk" CausesValidation="False">Not Registered?</asp:LinkButton>
            </div>
        </form>
    </div>
</div>

</body>
</html>
