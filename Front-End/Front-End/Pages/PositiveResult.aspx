<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositiveResult.aspx.cs" Inherits="Front_End.Pages.PositiveResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Dietation.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="positive_div">
            <div class="positive_result">
                <img src="../Images/iconmonstr-thumb-10-240.png" />
                <br />
                <p><asp:Label ID="lblResultFood" runat="server"></asp:Label> is compatible with your diet!</p>
                <br />
                <asp:Button ID="btnReturnHome" runat="server" CssClass="dietation-btn" Text="Return" />
            </div>
        </div>
    </form>
</body>
</html>
