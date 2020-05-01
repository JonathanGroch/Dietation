<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Custom_Filter.aspx.cs" Inherits="Front_End.Custom_Filter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Dietation.css" rel="stylesheet" />
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
                    <p>Here at Dietation we understand that sometimes you can't trust always pre-defined filters, or want to filter particular ingredients,
                        thus why we present you Dietation Custom filter. 
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<hr />
<div class="create_filter_block">
    <form id="main_filter" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-lg-6 col-md-6">

                    <asp:Label ID="lblFilterLabel" runat="server" Text="Enter Filter Title: "></asp:Label>

                    <asp:TextBox ID="txtFilterTitle" runat="server" Columns="32"></asp:TextBox>

                </div>
                <div class="col-sm-6 col-lg-6 col-md-6">

                    &nbsp;<asp:Button ID="btnRenameTitle" runat="server" OnClick="btnRenameTitle_Click" Text="Rename Title" />

                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-lg-6 col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Enter Ingredient: "></asp:Label>
                    <asp:TextBox ID="txtSearchIngredient" runat="server" Columns="32"></asp:TextBox>
                </div>
                <div class="col-sm-6 col-lg-6 col-md-6">
                    <asp:Button ID="btnAddIngredient" runat="server" Text="Add Ingredient" OnClick="btnAddIngredient_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-lg-6 col-md-6">
                    <asp:Button ID="btnRemoveItem" runat="server" Text="Remove Selected Item" OnClick="btnRemoveItem_Click" />
                    <asp:Button ID="btnClearList" runat="server" Text="Clear List" OnClick="btnClearList_Click" />
                </div>
                <div class="col-sm-6 col-lg-6 col-md-6">
                 <h3>Banned Ingredients on 
                     <asp:Label ID="lblFilterTitle" runat="server"></asp:Label>
                 </h3>
                 <asp:ListBox ID="lbxViewableFilterList" runat="server" OnSelectedIndexChanged="lbxViewableFilterList_SelectedIndexChanged"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-lg-6 col-md-6">

                    <asp:Button ID="ctnSaveFilter" runat="server" Text="Save Filter" />

                </div>
                <div class="col-sm-6 col-lg-6 col-md-6">

                    <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />

                </div>
            </div>
        </div>
    </form>
</div>
<div class="footer">
    <div class="container">
        <div class="row">

        </div>
    </div>
</div>
</body>
</html>
