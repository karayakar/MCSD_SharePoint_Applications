using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

public partial class ListManipulation : System.Web.UI.Page
{
    SPWeb web = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        web = SPContext.Current.Web;
        list = web.Lists.TryGetList("Student Assignments");
        loadList();
    }

    SPList list = null;
    protected void addList_Click(object sender, EventArgs e)
    {
        web.AllowUnsafeUpdates = true;
        SPListCollection lists = web.Lists;

        list = lists.TryGetList("Student Assignments");
        if (list == null)
        {
            System.Guid listID
                = web.Lists.Add("Student Assignments", "", SPListTemplateType.TasksWithTimelineAndHierarchy);
            list = web.Lists[listID];
        }
        loadList();
        
    }
    protected void addColumns_Click(object sender, EventArgs e)
    {
        web.AllowUnsafeUpdates = true;
        
        SPFieldCollection fields = list.Fields;
        SPField gradeField;

        if (fields.ContainsField("Grade"))
        {
            gradeField = fields["Grade"];
        }
        else
        {
            fields.Add("Grade", SPFieldType.Number, false);
        }
        loadList();
      
    }
    protected void loadList()
    {
        if (list != null)
        {
            listView.DataSource = list.Items.GetDataTable();
            listView.DataBind();
        }

    }

    protected void addViews_Click(object sender, EventArgs e)
    {
        web.AllowUnsafeUpdates = true;
        
        SPView defaultView = list.DefaultView;
        if (!defaultView.ViewFields.Exists("Grade"))
        {
            defaultView.ViewFields.Add("Grade");
            defaultView.Update();
        }
        loadList();
    }
    protected void addItems_Click(object sender, EventArgs e)
    {
        web.AllowUnsafeUpdates = true;

        SPListItemCollection items = list.Items;
        SPListItem newItem = items.Add();
        newItem["Title"] = "Homework 1";
        newItem["DueDate"] = System.DateTime.Now;
        newItem["Grade"] = 5;
        newItem.Update();
        loadList();
    }
}