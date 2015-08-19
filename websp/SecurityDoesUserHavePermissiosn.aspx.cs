using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

public partial class SecurityDoesUserHavePermissiosn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SPWeb web = SPContext.Current.Web;
      
        Response.Write(web.CurrentUser + " has permmsion to add items: " 
            + web.DoesUserHavePermissions(SPBasePermissions.AddListItems));

    }
}