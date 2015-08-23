using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

public partial class SiteCollectionOrganization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        #region Getting lists and list items for the current website
        SPWeb web = SPContext.Current.Web;

        TreeNode webNode = new TreeNode(web.Title);
        treeWeb.Nodes.Add(webNode);
        SPListCollection lists = web.Lists;
        foreach (SPList list in lists)
        {

            TreeNode listNode = new TreeNode(list.Title);
            listNode.Expanded = false;
            webNode.ChildNodes.Add(listNode);
            if (list.Fields.ContainsField("Title"))
            {
                SPListItemCollection items = list.Items;
                foreach (SPListItem item in items)
                {
                    TreeNode itemNode = new TreeNode(item.Title);

                    listNode.ChildNodes.Add(itemNode);
                }
            }
        }
        #endregion

        #region Site Collection Navigation
        SPSite siteCollection = SPContext.Current.Site;
        SPWeb rootWeb = siteCollection.RootWeb;
        TreeNode rootNode = new TreeNode(rootWeb.Title);
        treeSiteCollection.Nodes.Add(rootNode);
        addSubWebsToTree(rootWeb, rootNode);
        rootWeb.Dispose();
        #endregion

    }

    #region Site Collection Recurssion

    private void addSubWebsToTree(SPWeb currentWeb, TreeNode currentNode)
    {
        foreach (SPWeb subWeb in currentWeb.Webs)
        {
            TreeNode subWebNode = new TreeNode(subWeb.Title);
            currentNode.ChildNodes.Add(subWebNode);
            addSubWebsToTree(subWeb, subWebNode);
            subWeb.Dispose();
        }
    }
    #endregion
}