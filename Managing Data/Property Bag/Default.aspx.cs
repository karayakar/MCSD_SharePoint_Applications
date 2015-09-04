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
        SPWeb web = SPContext.Current.Web;
        if (web.AllProperties.ContainsKey("corporateDb"))
            txtConnString.Text = web.AllProperties["corporateDb"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SPWeb web = SPContext.Current.Web;
            web.AllowUnsafeUpdates = true;
            if (web.AllProperties.ContainsKey("corporateDb"))
                web.AllProperties["corporateDb"] = txtConnString.Text;
            else
                web.Properties.Add("CurrentDb", txtConnString.Text);
            web.AllowUnsafeUpdates = false;
            lblResult.Text = "Update Success";
        }
        catch(Exception ex)
        {
            lblResult.Text = ex.Message;
        }
    }
}