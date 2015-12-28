<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="HtmlEscaping.Escaping" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbInput" runat="server" placeholder="Dangerous text here!"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <br /><br />
        <asp:TextBox ID="tbOutput" runat="server" placeholder="Result ^_-"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
