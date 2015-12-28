<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="WebformsIntroHomework.HelloWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnSubmitName" runat="server" Text="Submit name" OnClick="btnSubmitName_Click"/>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
