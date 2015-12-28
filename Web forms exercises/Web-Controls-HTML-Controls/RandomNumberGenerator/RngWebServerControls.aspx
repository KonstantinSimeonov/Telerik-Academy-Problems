<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RngWebServerControls.aspx.cs" Inherits="RandomNumberGenerator.RandomNumberGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>RNG with Web Server controls</h2>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="tbMin" runat="server" placeholder="Lower bound"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="tbMax" runat="server" placeholder="Upper bound"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Generate random number"/>
        <br /><br />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
