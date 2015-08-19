using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Server;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.Office.Server.Administration;
using Microsoft.SharePoint;

public partial class UserProfileInfo : System.Web.UI.Page
{
    UserProfileManager upm = null;
    Microsoft.Office.Server.UserProfiles.UserProfile up = null;


    protected void Page_Load(object sender, EventArgs e)
    {

        using (SPSite site = SPContext.Current.Site)
        {
            SPServiceContext context =
                SPServiceContext.GetContext(site);
            upm = new UserProfileManager(context);
            up = upm.GetUserProfile("abcph\\administrator");
            Response.Write("work email is " + up[PropertyConstants.WorkEmail].Value + "<br>");
            Response.Write("state is " + up["State"].Value);

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        up["State"].Value = "WY";
        up.Commit();

    }
}
