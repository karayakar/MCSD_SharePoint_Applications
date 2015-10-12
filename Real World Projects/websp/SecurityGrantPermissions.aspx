<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecurityGrantPermissions.aspx.cs" Inherits="SecurityGrantPermissions" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Document Library:
    <asp:DropDownList ID="ddDocLibs" runat="server"></asp:DropDownList>
<br />
    <br />
    Folder Name;
    <asp:TextBox ID="folderName" runat="server">
    </asp:TextBox>
<br />
    <br />
    User:
    <asp:DropDownList ID="ddUsers" runat="server">
    </asp:DropDownList>
    <br />
    <br />
Permission Level:
    <asp:DropDownList ID="ddPermissionsLevels" runat="server">
    </asp:DropDownList>
    
    <br />
    <br />
    <SharePoint:FormDigest runat="server"></SharePoint:FormDigest>
        <asp:Button Text="Grant Permissions" ID="btnGrantPermssion" runat="server" 
            onclick="btnGrantPermssion_Click" />
    </div>

    </form>
</body>
</html>
