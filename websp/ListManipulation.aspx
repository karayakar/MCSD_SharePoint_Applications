<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListManipulation.aspx.cs" Inherits="ListManipulation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="addList" Text="Add List" runat="server" onclick="addList_Click" />
    <asp:Button ID="addColumns" Text="Add Columns" runat="server" 
            onclick="addColumns_Click" />
    <asp:Button ID="addViews" Text="Add Views" runat="server" 
            onclick="addViews_Click" />
    <asp:Button ID="addItems" Text="Add Items" runat="server" 
            onclick="addItems_Click" />
    <asp:GridView AutoGenerateColumns="true" runat="server" ID="listView"></asp:GridView>


    </div>
    </form>
</body>
</html>
