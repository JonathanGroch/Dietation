<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Front_End.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Approval.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div class="register_page">
    <div class="container">
        <div class="row">
            <h1>Registration</h1>
        </div>
        <div class="row">
                <p>First Name</p>
        </div>
        <div class="row">
            <asp:TextBox ID="txtFirstName" placeholder="Your firstname..." runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" CssClass="text-danger" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
                <p>Last Name</p>
        </div>
        <div class="row">
                <asp:TextBox ID="txtLastName" placeholder="Your lastname..." runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" CssClass="text-danger" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div> 
        <div class="row">
             <p>Your Email</p>
         </div>
         <div class="row">
             <asp:TextBox ID="txtRegisterEmail" placeholder="Your email..." runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtRegisterEmail" CssClass="text-danger" ErrorMessage="*"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtRegisterEmail" CssClass="text-danger" ErrorMessage="Please enter a valid email address " ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         </div>
         <div class="row">
             <p>Password</p>
         </div>
         <div class="row">
             <asp:TextBox ID="txtRegisterPassword" placeholder="Your password..." runat="server" TextMode="Password"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvRegisterPassword" runat="server" ControlToValidate="txtRegisterPassword" CssClass="text-danger" ErrorMessage="*"></asp:RequiredFieldValidator>
         </div>
         <div class="row">
             <p>Confirm Password</p>
         </div>
         <div class="row">
             <asp:TextBox ID="txtRegisterPassword2" placeholder="Confirm your password..." runat="server" TextMode="Password"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvRegisterPassword2" runat="server" ControlToValidate="txtRegisterPassword2" CssClass="text-danger" ErrorMessage="*"></asp:RequiredFieldValidator>
         </div>
         <div class="row">
             <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn dietation-btn" />
             <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
         </div>
    </div>
</div>
</form>
</body>
</html>
