<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <style>
        table {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table border="1">
        <thead>
            <tr>
                <th colspan="4">
                    <asp:TextBox ID="tbResult" runat="server" type="number"></asp:TextBox>
                </th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                <td colspan="4">
                    <asp:Button runat="server" OnClick="Evaluate" Text="           =           " />
                </td>
            </tr>
        </tfoot>
        <tbody>
            <tr>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="9" Text=" 9 "/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="8" Text=" 8 "/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="7" Text=" 7 "/></td>
                <td><asp:Button runat="server" OnCommand="Operation" CommandArgument="+" Text="+"/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="6" Text=" 6 "/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="5" Text=" 5 "/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="4" Text=" 4 "/></td>
                <td><asp:Button runat="server" OnCommand="Operation" CommandArgument="-" Text=" - "/></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="3" Text=" 3 "/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="2" Text=" 2 "/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="1" Text=" 1 "/></td>
                <td><asp:Button runat="server" OnCommand="Operation" CommandArgument="X" Text=" X "/></td>
            </tr>
                        <tr>
                <td><asp:Button runat="server" OnClick="Clear" Text="C"/></td>
                <td><asp:Button runat="server" OnCommand="CalcBtnClick" CommandArgument="0" Text=" 0 "/></td>
                <td><asp:Button runat="server" OnCommand="Operation" CommandArgument="sr" Text=" s "/></td>
                <td><asp:Button runat="server" OnCommand="Operation" CommandArgument="/" Text=" / "/></td>
            </tr>
        </tbody>
        <tr></tr>
    </table>
    </form>
</body>
</html>
