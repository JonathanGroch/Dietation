<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Front_End.Pages.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
<div class="banner_block">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-lg-4 col-sm-12">
                <img src="" alt="Banner of Dietation" />
            </div>
            <div class="col-md-8 col-sm-12">
                <h1>Dietation</h1>
                <div class="banner_desc">
                    <p>Dietation is a web/mobile application that helps you find food products that are 
                       with in your dietary or lifestyle restrictions. Be that gluten free, nut free, vegan, 
                       vegetarian or even custom ones. Just type in your product, and we'll tell you whether
                       or not it's safe to eat. 
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<hr />
<form id="main_search" runat="server">
<div class="main_search_block">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:TextBox ID="txtSearchBox" runat="server" Font-Italic="True" Columns="64"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearchButton" runat="server" Text="Search!" OnClick="btnSearchButton_Click" />
            &nbsp;<asp:Button ID="btnCreateCustom" runat="server" Text="Create Custom Filter" OnClick="btnCreateCustom_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <asp:CheckBox ID="chbGlutenFree" runat="server" Text="Gluten-Free" />
                <asp:CheckBox ID="chbDairyFree" runat="server" Text="Dairy Free" />
                <asp:CheckBox ID="chbNutFree" runat="server" Text="Nut Free" />
                <asp:CheckBox ID="chbCornFree" runat="server" Text="Corn Free" />
                <asp:CheckBox ID="chbVegan" runat="server" Text="Vegan" />
                <asp:CheckBox ID="chbVegetarian" runat="server" Text="Vegetarian" />
                <asp:CheckBox ID="chbPescatarian" runat="server" Text="Pescatarian" />
                <asp:CheckBox ID="chbCustom1" runat="server" Text="Custom_Filter_1" />
                <asp:CheckBox ID="chbCustom2" runat="server" Text="Custom_Filter_2" />
                <asp:CheckBox ID="chbCustom3" runat="server" Text="Custom_Filter_3" />

             </div>
        </div>
    </div>
</div>
<hr />
<div class="footer">
    <div class="container">
        <div class="row">

        </div>
    </div>
</div>
</form>
</body>
</html>
