<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Elevation.aspx.cs" Inherits="Elevation" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <SharePoint:FormDigest ID="FormDigest1" runat="server"></SharePoint:FormDigest>
  
    <div>
        <asp:Button ID="Button1" Text="Elevate Method 1" runat="server" 
            onclick="Button1_Click" />
    <asp:Button ID="Button2" Text="Elevate Method 2" runat="server" 
            onclick="Button2_Click" />
          <asp:GridView AutoGenerateColumns="false" runat="server" ID="listView">
          <Columns>
          <asp:BoundField DataField="Title" />
          <asp:BoundField DataField="Author" />
          <asp:BoundField DataField="Editor" />
          </Columns>
          </asp:GridView>

    </div>
    </form>
</body>
</html>
