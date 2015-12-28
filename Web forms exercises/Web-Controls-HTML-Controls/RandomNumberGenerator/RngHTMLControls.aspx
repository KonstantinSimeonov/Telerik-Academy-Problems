<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RngHTMLControls.aspx.cs" Inherits="RandomNumberGenerator.RngHTMLControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>RNG with HTML Controls</h2>
    <form id="form1" runat="server">
    <div>
        <input type="number" ID="tbMin" runat="server" placeholder="Lower bound" />
        <br /><br />
        <input type="number" ID="tbMax" runat="server" placeholder="Upper bound"/>
        <br /><br />
        <button ID="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick">Generate random number</button>
        <br /><br />
        <label ID="lblResult" runat="server"></label>
    </div>
    </form>
</body>
</html>
