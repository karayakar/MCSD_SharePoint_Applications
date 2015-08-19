<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventHandlers.aspx.cs" Inherits="EventHandlers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Label ID="message" runat="server"></asp:Label>
            <asp:DropDownList ID="ddLists" runat="server"></asp:DropDownList>
            <asp:Button ID="addHandler" Text="add Handler" runat="server" 
            onclick="addHandler_Click" />
            <asp:TreeView ID="tvEventRs" runat="server"></asp:TreeView>
    </div>
    </form>
</body>
</html>
