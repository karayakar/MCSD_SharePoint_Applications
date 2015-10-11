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
        using (SPSite site = new SPSite(SPContext.Current.Web.Url))

        using (SPWeb web = site.OpenWeb())
        {
            SPList oList = web.Lists.TryGetList("Settings");
            string sQuery = @"<Where><Eq><FieldRef Name='Key' /><Value Type = 'Text'>corporateDb</Value></Eq></Where>";
            string sViewFields = @"<FieldRef Name = 'Title' />";
            uint iRowLimit = 1;

            var oQuery = new SPQuery();
            oQuery.Query = sQuery;
            oQuery.ViewFields = sViewFields;
            oQuery.RowLimit = iRowLimit;

            SPListItemCollection collListItems = oList.GetItems(oQuery);
            string connString = collListItems[0].GetFormattedValue("Title");

            //do something with connString


        }
    }

    
}