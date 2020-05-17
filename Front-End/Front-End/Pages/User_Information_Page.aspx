<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Information_Page.aspx.cs" Inherits="Front_End.User_Information_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Dietation.css" rel="stylesheet" />

</head>
<body>
<form id="form1" runat="server">
    <div class="user_information_page">
        <div class="container">
            <div class="row">
                <img class="banner_img" src="../Images/3226_Dietation_RB-01.png" />
            </div>
            <div class="row">
                <div class="text-center">
                    <h3>Your Profile</h3>
                </div>
                <div class="col-md-4 offset-4">
                    <div class="row">
                        <div class="text-center">
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
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