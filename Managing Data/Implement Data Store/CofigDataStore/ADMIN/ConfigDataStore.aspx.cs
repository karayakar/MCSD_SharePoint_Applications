//Need to Troubleshoot This

using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;


namespace CofigDataStore.Layouts.CofigDataStore
{
    public partial class ConfigDataStore : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SPFarm farm = SPFarm.Local;
                ConfigObject = farm.GetChild<ConfigDataStore.ConfigObject>("root");
                txtConnString.Text = rootConfig == null ? "" : rootConfig.connString;



            }
        }

        protected void btnPersist_Click(object sender, EventArgs e)
        {
            try
            {
                SPFarm farm = SPFarm.Local;
                //SPContext.Current.AllowUnsafeUpdates = true;
                ConfigDataStore.ConfigObject rootConfig = farm.GetChild<ConfigDataStore.ConfigObject>("root");
                if (rootConfig == null)
                    rootConfig = new ConfigDataStore.ConfigObject("root", farm);

                rootConfig.connString = txtConnString.Text;
                rootConfig.Update();

                lblResult.Text = "Settings updated successfully";
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

        }
    }
}
