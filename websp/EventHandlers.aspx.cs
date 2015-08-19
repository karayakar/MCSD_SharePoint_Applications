using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

public partial class EventHandlers : System.Web.UI.Page
{
    SPWeb web;
    protected void Page_Load(object sender, EventArgs e)
    {
        web = SPContext.Current.Web;
        if (!IsPostBack)
        {
            ddLists.DataSource = web.Lists;
            ddLists.DataTextField = "Title";
            ddLists.DataValueField = "Title";
            ddLists.DataBind();
        }
        drawTreeView();

    }
    protected void addHandler_Click(object sender, EventArgs e)
    {
        web.AllowUnsafeUpdates = true;
        SPList list = web.Lists[ddLists.SelectedValue];
        string assemblyName = "SampleEventHandler,"
        + "Version=1.0.0.0,Culture=neutral,"
        + "PublicKeyToken=9c78755633557eaa";
        string className = "SampleEventHandler.ItemHandler";
        list.EventReceivers.Add(SPEventReceiverType.ItemAdded, assemblyName, className);
        message.Text = "everything is ok";
        drawTreeView();
    }
    protected void drawTreeView()
    {
        TreeNode webNode = new TreeNode(web.Title);
        SPListCollection lists = web.Lists;
        foreach (SPList list in lists)
        {
            TreeNode listNode = new TreeNode(list.Title);
            SPEventReceiverDefinitionCollection erc =   list.EventReceivers;
            if (erc.Count > 0)
            {
                webNode.ChildNodes.Add(listNode);
                foreach (SPEventReceiverDefinition erd in erc)
                {
                    TreeNode erNode = new TreeNode(erd.Type.ToString() + " " + erd.Class);
                    listNode.ChildNodes.Add(erNode);
                }
            }
        }
        tvEventRs.Nodes.Clear();
        tvEventRs.Nodes.Add(webNode);
    }
}