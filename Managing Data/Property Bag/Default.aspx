<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Label1" runat="server" Text="Connection String"></asp:Label>
        <asp:TextBox ID="txtConnString" runat="server" style="margin-top: 3px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
        </p>
        <p>
            <asp:Label ID="lblResult" runat="server" Text="lblResult"></asp:Label>
        </p>
    </form>
</body>
</html>
