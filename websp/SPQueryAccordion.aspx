<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js"></script> 
<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.2/jquery-ui.min.js"></script> 
      <link type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.2/themes/black-tie/jquery-ui.css" rel="stylesheet"/> 
         		<script type="text/javascript">
       		    $(document).ready(function () {

       		        $("#accordion").accordion();
            }); 
        </script> 
        
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>SharePoint List Through an Accordion</h1>

        <%
        SPWeb web = SPContext.Current.Web;
        SPQuery query = new SPQuery();
        query.ViewFields = "<FieldRef Name=\"Title\"/><FieldRef Name=\"Body\"/>";
        query.Query = "<Where><Contains><FieldRef Name=\"Title\"/><Value Type=\"Text\">point</Value></Contains></Equals>";
        SPList list = web.Lists["Announcements"];
        SPListItemCollection items = list.GetItems(query);
        %>
          <div id="accordion">
        <%    
        foreach (SPListItem item in items)
        {
        %>
          <h3><a href="#"><%= item.Title %></a></h3>
          <div><%= item["Body"] %></div>
            
        <%
        }
        %>
        </ol>
        </div>
    </div>
    </form>
</body>
</html>
