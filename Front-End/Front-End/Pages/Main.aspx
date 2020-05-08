﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Front_End.Pages.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Dietation.css" rel="stylesheet" />
</head>
<body>
<div class="main_block">
    <div class="container">
        <form id="main_search" runat="server">
        <div class="row">
            <asp:Button ID="btnLogin" runat="server" CssClass="dietation-btn" Text="Login" />
        </div>
        <div class="row">
            <img class="banner_img" src="../Images/3226_Dietation_RB-01.png" />
            <br />
                <div class="banner_desc">
                    <p>Dietation is a web/mobile application that helps you find food products that are 
                       with in your dietary or lifestyle restrictions. Be that gluten free, nut free, vegan, 
                       vegetarian or even custom ones. Just type in your product, and we'll tell you whether
                       or not it's safe to eat. 
                    </p>
                </div>
        </div>
            <hr />
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:TextBox ID="txtSearchBox" runat="server" Font-Italic="True" placeholder="Search the product here..." Columns="64"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearchButton" runat="server" Text="Search!" OnClick="btnSearchButton_Click" CssClass="dietation-btn" />
            &nbsp;
            <asp:Button ID="btnCreateCustom" runat="server" Text="Create Custom Filter" OnClick="btnCreateCustom_Click" CssClass="dietation-btn" />
            <asp:Button ID="btnFiltersList" runat="server" CssClass="dietation-btn" Text="More information on Filters" OnClick="btnFiltersList_Click" />
            </div>
        </div>
        <div class="row">
                <asp:CheckBoxList ID="cblFilters" runat="server" CssClass="dietation-checkbox">
                    <asp:ListItem Value="GlutenFree">Gluten Free</asp:ListItem>
                    <asp:ListItem Value="DairyFree">Dairy Free</asp:ListItem>
                    <asp:ListItem Value="NutFree">Nut Free</asp:ListItem>
                    <asp:ListItem Value="CornFree">Corn Free</asp:ListItem>
                    <asp:ListItem Value="Vegan">Vegan</asp:ListItem>
                    <asp:ListItem Value="Vegetarian">Vegetarian</asp:ListItem>
                    <asp:ListItem Value="Pescatarian">Pescatarian</asp:ListItem>
                    <asp:ListItem Value="0">Custom Filter 1</asp:ListItem>
                    <asp:ListItem Value="1">Custom Filter 2</asp:ListItem>
                    <asp:ListItem Value="2">Custom Filter 3</asp:ListItem>
                </asp:CheckBoxList>
        </div>
            <hr />
        <div class="row">
            <div class="col">
                <h3>Follow us at these Links.</h3>
                <asp:ImageButton ID="ibnFacebook" runat="server" CssClass="dietation-link" ImageUrl="~/Images/iconmonstr-facebook-3-240.png" CausesValidation="False" ImageAlign="Left" />
                <asp:ImageButton ID="ibnYoutube" runat="server" CssClass="dietation-link" ImageUrl="~/Images/iconmonstr-youtube-3-240.png" CausesValidation="False" ImageAlign="Left" />
                <asp:ImageButton ID="ibnInstagram" runat="server" CssClass="dietation-link" ImageUrl="~/Images/iconmonstr-instagram-13-240.png" CausesValidation="False" ImageAlign="Left" />
                <asp:ImageButton ID="ibnSnapchat" runat="server" CssClass="dietation-link" ImageUrl="~/Images/iconmonstr-snapchat-3-240.png" CausesValidation="False" ImageAlign="Left" />
            </div>
            <div class="col">
                <h3>Have a question? Contact us here.</h3>
                <a>Support@Dietation.com</a>
            </div>
        </div>
        </form>
    </div>
</div>

</body>
</html>
