<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Information_Page.aspx.cs" Inherits="Front_End.User_Information_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    <div class="user_information_page">
        <div class="container">
            <div class="row">
                <div class="dietation_user_banner">
                    <img src="" alt="Dietation Banner" />
                </div>
            </div>
            <div class="row">
                <div class="user_information_block_1">
                    <div class="col-sm-4 col-md-3 col-lg-2">
                        <img src="" alt="Name_Icon" />
                        <img src="" alt="Email_Icon" />
            
                    </div>
                    <div class="col-sm-8 col-md-9 col-lg-10">
                        <asp:Label ID="userNameInfo" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="userEmailInfo" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="user_information_block_2">
                    <h3>Saved Filters</h3>
                    
                </div>
            </div>
        </div>
    </div>
 </form>       
</body>
</html>