<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnknownResult.aspx.cs" Inherits="Front_End.Pages.UnknownResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Approval.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="unknown">
            <p>Either an unknown error has occured in the application or the item entered in the search box is not recognized by the FDA database. Please try again</p>
            <asp:Button ID="btnReturnToMain" runat="server" Text="Return to Main" CssClass="btn dietation-btn" OnClick="btnReturnToMain_Click" />
        </div>
    </form>
</body>
</html>
