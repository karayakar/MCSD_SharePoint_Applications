using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint;

public partial class SecurityTree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SPSite site = SPContext.Current.Site;
        SPWeb rootWeb = site.RootWeb;

        TreeNode rootNode = new TreeNode(site.Url);
        securityTree.Nodes.Add(rootNode);

        TreeNode allSPGroupsNode = new TreeNode("All SharePoint Groups");
        allSPGroupsNode.Expanded = false;
        rootNode.ChildNodes.Add(allSPGroupsNode);
        SPGroupCollection allSPGroups = rootWeb.SiteGroups;
        foreach (SPGroup group in allSPGroups)
        {
            allSPGroupsNode.ChildNodes.Add(new TreeNode(group.Name));
        }

        TreeNode allUsersNode = new TreeNode("All Users");
        allUsersNode.Expanded = false;
        rootNode.ChildNodes.Add(allUsersNode);
        SPUserCollection allUsers = rootWeb.SiteUsers;
        foreach (SPUser user in allUsers)
        {
            allUsersNode.ChildNodes.Add(new TreeNode(user.Name));
        }
        webDetails(rootWeb, rootNode);
        webRecursive(rootWeb, rootNode);
    }


    protected void webRecursive(SPWeb parentWeb, TreeNode parentNode)
    {
        SPWebCollection webs = parentWeb.Webs;
        foreach (SPWeb web in webs)
        {
            TreeNode webNode = new TreeNode(web.Title + " Inherits: " + !web.HasUniqueRoleAssignments);
            parentNode.ChildNodes.Add(webNode);
            webDetails(web, webNode);
            webRecursive(web, webNode);
        }
    }

    protected void webDetails(SPWeb web, TreeNode parentNode)
    {

        SPRoleAssignmentCollection rac = web.RoleAssignments;
        TreeNode raNode = new TreeNode("Permssions Grants");
        if (!web.HasUniqueRoleAssignments)
        {
            raNode.Expanded = false;
        }
        parentNode.ChildNodes.Add(raNode);
        foreach (SPRoleAssignment ra in rac)
        {
            raNode.ChildNodes.Add(new TreeNode("member: " + ra.Member.Name + " permission level: " + ra.RoleDefinitionBindings[0].Name));
        }
        SPListCollection lists = web.Lists;
        foreach (SPList list in lists)
        {
            TreeNode listNode = new TreeNode(list.Title + " inherits: " + !list.HasUniqueRoleAssignments);
            if (!list.HasUniqueRoleAssignments)
            {
                listNode.Expanded = false;
            }
            parentNode.ChildNodes.Add(listNode);
            SPRoleAssignmentCollection lrac = list.RoleAssignments;
            foreach (SPRoleAssignment ra in lrac)
            {
                listNode.ChildNodes.Add(new TreeNode("member: " + ra.Member.Name + " permission level: " + ra.RoleDefinitionBindings[0].Name));
            }
        }

    }
}