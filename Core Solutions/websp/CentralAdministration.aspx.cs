using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

public partial class CentralAdministration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Iterating through web servers

        SPWebApplicationCollection webApplications = SPWebService.ContentService.WebApplications;

        foreach (SPWebApplication webApplication in webApplications)
        {
            TreeNode webAppNode = new TreeNode(webApplication.Name);
            treeGlobal.Nodes.Add(webAppNode);

            #region iterating through content databases and sites
            SPContentDatabaseCollection contentDatabases = webApplication.ContentDatabases;
            foreach (SPContentDatabase contentDatabase in contentDatabases)
            {
                TreeNode contentDBNode = new TreeNode(contentDatabase.Name);

                webAppNode.ChildNodes.Add(contentDBNode);
                SPSiteCollection sites = contentDatabase.Sites;
                foreach (SPSite site in sites)
                {
                    TreeNode siteNode = new TreeNode(site.Url);
                    contentDBNode.ChildNodes.Add(siteNode);
                }
            }
            #endregion
           
            SPDeletedSiteCollection deletedSites = webApplication.GetDeletedSites();
            if (deletedSites.Count > 0)
            {
                TreeNode deletedSitesNode = new TreeNode("Deleted Sites");
                webAppNode.ChildNodes.Add(deletedSitesNode);
                foreach (SPDeletedSite deletedSite in deletedSites)
                {
                    TreeNode siteNode = new TreeNode(deletedSite.Path + " content db: " + webApplication.ContentDatabases[deletedSite.DatabaseId].Name);
                    deletedSitesNode.ChildNodes.Add(siteNode);
                }
            }
        }

        #endregion

    }
}