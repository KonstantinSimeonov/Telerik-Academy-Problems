<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistrationForm.aspx.cs" Inherits="StudentRegistration.StudentRegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Fill the form:</h2>
        <asp:TextBox ID="tbFirstName" runat="server" placeholder="First Name"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="tbLastName" runat="server" placeholder="Last Name"></asp:TextBox>
        <br /><br />
        <asp:TextBox ID="tbFacultyNumber" runat="server" placeholder="Faculty Number"></asp:TextBox>
        <br /><br />
        <asp:DropDownList ID="ddlUniversities" runat="server" SelectMethod="GetUniversities"></asp:DropDownList>
        <br /><br />
        <asp:DropDownList ID="ddlSpecialties" runat="server" SelectMethod="GetSpecialties"></asp:DropDownList>
        <br /><br />
        <asp:CheckBoxList ID="cblCourses" runat="server" SelectMethod="GetCourses"></asp:CheckBoxList>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"></asp:Button>
        <br /><br />
        <hr />
        <h2>Result:</h2>
        <asp:Literal ID="ltlResult" runat="server"></asp:Literal>
    </form>
</body>
</html>
