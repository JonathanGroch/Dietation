<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterInformation.aspx.cs" Inherits="Front_End.Pages.FilterInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Dietation.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<div class="filter_information">
    <div class="container">
        <div class="row">
            <img class="banner_img" src="../Images/3226_Dietation_RB-01.png" />
            <br />
                <div class="banner_desc">
                    <p>Dietation understands that you can't always take the predefined filters at there word. We've been there. So to ensure peace of mind, 
                    this page allows you scrolls through all the ingredients of each filter. 
                    </p>
                </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="row">
                <asp:DropDownList ID="ddlPredefinedFilterSelection" runat="server">
                    <asp:ListItem Value="0">Gluten Free</asp:ListItem>
                    <asp:ListItem Value="1">Dairy Free</asp:ListItem>
                    <asp:ListItem Value="2">Nut Free</asp:ListItem>
                    <asp:ListItem Value="3">Corn Free</asp:ListItem>
                    <asp:ListItem Value="4">Vegan</asp:ListItem>
                    <asp:ListItem Value="5">Vegetarian</asp:ListItem>
                    <asp:ListItem Value="6">Pescatarian</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnFilterInfo" runat="server" CssClass="btn dietation-btn" Text="Show Filter Banned Ingredients" OnClick="btnFilterInfo_Click" />
                &nbsp;<asp:Button ID="btnMain" runat="server" CssClass="btn dietation-btn" Text="Main Page" OnClick="btnMain_Click" />
                </div>
                <div class="row">
                    <asp:ListBox ID="lbxFilterListInfo" runat="server" Height="100%" Rows="15" Width="100%"></asp:ListBox>
                </div>
            </div>
            <div class="col">
                <h3 class="dietation-h3">Dietation Mission Statement</h3>
                <p>Our mission here at OrangeSustenance from day one is about easing the 
                    worries and stress of all those that suffer or are limited by 
                    constricted diets based on medical, lifestyle and or spiritual pressures. 
                    </p>
                <p>Because here at OrangeSustenance, we know, I know how difficult it is to find products 
                    that you can eat, how long it takes to search through products, and how frustrating 
                    and dangerous it is trying to look through the nutritional information only to miss 
                    one ingredient only to end up in the hospital? As I said we get. Thus why we have 
                    brought this service to you so you can enjoy your time doing activities you enjoy, 
                    instead of the tedium of reading nutrition labels. Because life needs to be lived, 
                    because life is not lived in a grocery store aisle, not in the emergency room and 
                    definitely not in the grave. </p>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <h3 class="dietation-h3">Follow us at these Links.</h3>
                <asp:ImageButton ID="ibnFacebook" runat="server" CssClass="dietation-img-btn" ImageUrl="~/Images/iconmonstr-facebook-3-240.png" CausesValidation="False" ImageAlign="Left" />
                <asp:ImageButton ID="ibnYoutube" runat="server" CssClass="dietation-img-btn" ImageUrl="~/Images/iconmonstr-youtube-3-240.png" CausesValidation="False" ImageAlign="Left" />
                <asp:ImageButton ID="ibnInstagram" runat="server" CssClass="dietation-img-btn" ImageUrl="~/Images/iconmonstr-instagram-13-240.png" CausesValidation="False" ImageAlign="Left" />
                <asp:ImageButton ID="ibnSnapchat" runat="server" CssClass="dietation-img-btn" ImageUrl="~/Images/iconmonstr-snapchat-3-240.png" CausesValidation="False" ImageAlign="Left" />
            </div>
            <div class="col">
                <h3 class="dietation-h3">Have a question? Contact us here.
                </h3>
                <asp:TextBox ID="txtSupport" runat="server" Columns="64" Rows="5" TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button ID="btnSubmitSupport" runat="server" CssClass="btn dietation-btn" Text="Submit" />
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
