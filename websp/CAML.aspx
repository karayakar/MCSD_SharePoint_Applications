<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CAML.aspx.cs" Inherits="CAML" %>

<!-- THIS NEEDS SOME FIGURING???-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:DropDownList ID="1stProducts" runat="server"></asp:DropDownList>
            <asp:Button ID="btnQuery" runat="server" Text="Filter" OnClick="btnQuery_Click" /> <br />
            <asp:GridView ID="grdClasses" runat="server" ></asp:GridView>
    </div>
    </form>
</body>
</html>
