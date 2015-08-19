using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Microsoft.SharePoint;

public partial class CAML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SPSite site = new SPSite(SPContext.Current.Web.Url))
        using (SPWeb web = site.OpenWeb())
        {
            SPList oList = web.Lists.TryGetList("MyList");
            string sQuery = @"<Where><IsNotNull><FieldRef Name = ""My_Field""></IsNotNull></Where>";
            string sViewFields = @"<FieldRef Name = ""My_Field"" />";
            uint iRowLimit = 10;

            SPListItemCollection collListItems = oList.GetItems(oQuery);

            DataSourceView dv = new DataView(collListItems);
            DataTable dt = dv.ToTable(true, "Product");
            1stProducts.DataSource = dt;
            1stProducts.DataTextField = "Product";
            1stProducts.Databind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
            using (SPSite site = new SPSite(SPContext.CurrentWeb.Url))
            using (SPWeb web = site.OpenWeb())
                SPList courseList = web.Lists.TryGetList("MyList");
                if (courseList != null)
                {
                    StringBuilder query = new StringBuilder();
                query.Append("<Where>"); // -----> finish schema with subsequent appends...
                }

                SPQuery camlQuery = new SPQuery();
                camlQuery.Query = Queryable.ToString();
                camlQuery.ViewFields = "<FieldRef Name = 'Title' ";

                SPListItemCollection items = courseList.GetItems(camlQuery);
                grdClasses.DataSource = items.GetDataTable();
                grdClasses.DataBind();


                
            }
            catch
            {

            }
        }

    }
}