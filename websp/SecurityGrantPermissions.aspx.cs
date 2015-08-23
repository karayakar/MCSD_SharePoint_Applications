using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

public partial class SecurityGrantPermissions : System.Web.UI.Page
{
    SPWeb web = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        web = SPContext.Current.Web;
        if (!IsPostBack)
        {
            SPListCollection lists = web.GetListsOfType(SPBaseType.DocumentLibrary);
            ddDocLibs.DataSource = lists;
            ddDocLibs.DataTextField = "Title";
            ddDocLibs.DataValueField = "Title";
            ddDocLibs.DataBind();

         
            SPUserCollection users = web.SiteUsers;
            ddUsers.DataSource = users;
            ddUsers.DataTextField = "Name";
            ddUsers.DataValueField = "LoginName";
            ddUsers.DataBind();

            SPRoleDefinitionCollection roleDefinitions = web.RoleDefinitions;
            ddPermissionsLevels.DataSource = roleDefinitions;

            ddPermissionsLevels.DataTextField = "Name";
            ddPermissionsLevels.DataValueField = "Name";
            ddPermissionsLevels.DataBind();
        }

    }
    protected void btnGrantPermssion_Click(object sender, EventArgs e)
    {
        SPPrincipal principal = web.SiteUsers[ddUsers.SelectedValue];
        SPFolderCollection submissions = web.Lists[ddDocLibs.SelectedValue].RootFolder.SubFolders;
        SPFolder newFolder = submissions.Add(folderName.Text);
        
        SPListItem folderItem = newFolder.Item;
        folderItem.BreakRoleInheritance(false);
        folderItem.Update();

        SPRoleAssignment folderRoleAssignment = new SPRoleAssignment(principal);
        folderRoleAssignment.RoleDefinitionBindings.Add(web.RoleDefinitions[ddPermissionsLevels.SelectedValue]);
        folderItem.RoleAssignments.Add(folderRoleAssignment);
      
    }
}