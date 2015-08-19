<%@ Page Language="C#" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.WebControls" %>
<%@ Import Namespace="Microsoft.SharePoint.Utilities" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <SharePoint:SPGridView ID="spGrid" AutoGenerateColumns="false" AllowSorting="true" runat="server">
       
       <Columns>
       <SharePoint:SPBoundField DataField="Title" HeaderText="Title" />
       <SharePoint:SPBoundField DataField="StartDate" HeaderText="Start Date" />
       <SharePoint:SPBoundField DataField="DueDate" HeaderText="Due Date" />
       <SharePoint:SPBoundField DataField="WebId" HeaderText="Web" />
       <SharePoint:SPBoundField DataField="ListId" HeaderText="List" />
       <SharePoint:SPBoundField DataField="ListProperty.Title" HeaderText="List Title" />
       <SharePoint:SPBoundField DataField="ProjectProperty.Title" HeaderText="Web Title" />
       </Columns>
      
        </SharePoint:SPGridView>
    <script language="C#" runat="server">
    SPWebCollection allWebs = null;
    DataTable dt = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        SPSite site =  SPContext.Current.Site;
                
            
        SPWeb rootWeb = site.RootWeb;
        SPSiteDataQuery query = new SPSiteDataQuery();
        
        //look through all webs
        query.Webs = "<Webs Scope=\"SiteCollection\">";
        //only look through tasks lists
        query.Lists = "<Lists ServerTemplate=\"171\" />";
        query.ViewFields = "<FieldRef Name=\"Title\" />"
            + "<FieldRef Name=\"StartDate\" /><FieldRef Name=\"DueDate\" />"
            + "<ProjectProperty Name='Title' /><ListProperty Name='Title' />";

        //get only the items where the start date is greater than 7/01/2006
        query.Query = String.Format("<Where><Gt><FieldRef Name='StartDate'/>" +
                "<Value Type='DateTime' StorageTZ='TRUE'>{0}</Value></Gt></Where>", 
                SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.UtcNow.AddDays(-10)));
        
        spGrid.DataSource = rootWeb.GetSiteData(query);
        
        spGrid.DataBind();
        site.Dispose();
        rootWeb.Dispose();    
    }
                
   </script>

    </div>
    </form>
</body>
</html>
