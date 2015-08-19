using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Security;
using System.Security.Principal;

public partial class Elevation : System.Web.UI.Page
{
    SPUser currentUser = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        SPWeb web = SPContext.Current.Web;
        currentUser = web.CurrentUser;
        Response.Write("Current SharePoint user: " + currentUser + "<BR/>");
        loadList();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        SPWeb web = SPContext.Current.Web;
   
        SPSecurity.RunWithElevatedPrivileges(delegate()
        {
            // any code that will run with elevated privileges
      
            using (SPSite site = new SPSite(web.Site.ID))
            {
                SPWeb rootWeb = site.RootWeb;
                rootWeb.AllowUnsafeUpdates = true;
                SPList list = rootWeb.Lists["Announcements"];
                SPListItemCollection items = list.Items;

                SPListItem item = items.Add();
                item["Title"] = "Method 1 This item was actually created by " + currentUser.Name;
                item["Created By"] = currentUser;
                item["Modified By"] = currentUser;

                item.SystemUpdate();
            }
        });
        loadList();
      
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      
        SPWeb web = SPContext.Current.Web;
        SPUser user = web.AllUsers[@"SHAREPOINT\SYSTEM"];
        SPUserToken userToken = user.UserToken;
        using (SPSite site = new SPSite(web.Url, userToken))
        {
            SPWeb rootWeb = site.RootWeb;
            rootWeb.AllowUnsafeUpdates = true;
            SPList list = rootWeb.Lists["Announcements"];
            SPListItemCollection items = list.Items;

            SPListItem item = items.Add();
            item["Title"] = "Method 2 This item was actually created by " + currentUser.Name;
            item["Created By"] = currentUser;
            item["Modified By"] = currentUser;

            item.SystemUpdate();
            
        }
        loadList();
    }

    protected void loadList()
    {
        listView.DataSource = SPContext.Current.Web.Lists["Announcements"].Items.GetDataTable();
        listView.DataBind();
        
    }
}