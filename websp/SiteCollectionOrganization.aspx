<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteCollectionOrganization.aspx.cs" Inherits="SiteCollectionOrganization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="labelMessage" runat="server" />
    <asp:TreeView ID="treeWeb" runat="server">
    </asp:TreeView>
   
    <asp:TreeView ID="treeSiteCollection" runat="server">
    </asp:TreeView>
   
    </div>
    </form>
</body>
</html>
