using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.SharePoint;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblWebApp.Text = SPContext.Current.Site.WebApplication.Name;
        lblSite.Text = SPContext.Current.Site.Url;
        lblWeb.Text = SPContext.Current.Web.Title;
        lblUser.Text = SPContext.Current.Web.CurrentUser.Name;

       
    }
}