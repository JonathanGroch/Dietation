<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NegativeResult.aspx.cs" Inherits="Front_End.Pages.NegativeResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Approval.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="negative">
            <div class="negative_result">
                <img src="../Images/iconmonstr-thumb-6-240.png" />
                <br />
                <p><asp:Label ID="lblResultFood" runat="server"></asp:Label> is not compatible with your diet!</p>
                <br />
                <asp:Button ID="btnReturnHome" runat="server" CssClass="dietation-btn" Text="Return" OnClick="btnReturnHome_Click" />
            </div>
        </div>

    </form>
</body>
</html>
