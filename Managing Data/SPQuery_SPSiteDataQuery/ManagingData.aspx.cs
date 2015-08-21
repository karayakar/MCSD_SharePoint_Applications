using System;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace ManagingData_.Layouts.ManagingData_
{
    public partial class ManagingData : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Retrieve Items from a List
            using (SPSite site = new SPSite(SPContext.Current.Web.Url)) ;
            using (SPWeb web = site.OpenWeb())
            {
                SPList oList = web.Lists.TryGetList("Courses");
                string sQuery = @"<Where><IsNotNull><FieldRef Name='Product'></FieldRef></IsNotNull></Where>";
                string sViewFields = @"<FieldRef Name = 'Product' />";
                uint iRowLimit = 10;

                var oQuery = new SPQuery();
                oQuery.Query = sQuery;
                oQuery.ViewFields = sViewFields;
                oQuery.RowLimit = iRowLimit;

                SPListItemCollection collListItems = oList.GetItems(oQuery);

                DataView dv = new DataView(collListItems.GetDataTable());
                DataTable dt = dv.ToTable(true, "Product");
                1stProducts.DataSource = dt;
                1stProducts.DataTextFied = "Product";
                1stProducts.DataBind();


            }

            


        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            //Retrieve Items From Multiple Lists
            using (SPSite site = new SPSite(SPContext.Current.Web.Url)) ;
            using (SPWeb web = site.OpenWeb()) ;

            SPSiteDataQuery dataQuery = new SPSiteDataQuery();

            dataQuery.Webs = @"<Webs Scope='Recursive'/>";
            dataQuery.Lists = @"<Lists ServerTempate='171'/>";
            dataQuery.ViewFields = @"<FieldRef Name='Product' /><FieldRef Name='Status' />";

            DataTable dt = web.GetSiteData(dataQuery);
            DataView dv = new DataView(dt);

            grdTasks.DataSource = dv;
            grdTasks.DataBind();
        }
            


    }
}
