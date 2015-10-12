using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.Office.Server.Utilities;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIterator_Click(object sender, EventArgs e)
    {
        using (SPSite site = new SPSite(SPContext.Current.Web.Url)) ;
        using (SPWeb web = site.OpenWeb())
        {
            SPList list = web.Lists.TryGetList("LargeList");
            if(list != null)
            {
                SPQuery camlQuery = new SPQuery();
                camlQuery.ViewFields = @"<FieldRef Name =""Title""/><FieldRef Name=""Description""/>";
                camlQuery.RowLimit = 8000;

                ContentIterator iterator = new ContentIterator();
                iterator.ProcessListItems(list, camlQuery, ProcessItem, ProcessError);
                grdData.DataSource = table;
                grdData.DataBind();
            }
        }
    }

    private void ProcessItem(SPListItem item)
    {
        string title = item["Title"].ToString();
        string description = item["Description"].ToString();
        table.Rows.Add(title, description);

    }

    private void ProcessError(SPListItem item, Exception e)
    {
        throw new Exception("An error occured ", e);
    }
}