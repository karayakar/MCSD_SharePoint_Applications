using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace SOMDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://abcuniversity"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    //set List
                    Guid listGuid = web.Lists.Add("My Contacts", string.Empty, SPListTemplateType.Contacts);
                    SPList list = web.Lists[listGuid];
                    list.OnQuickLaunch = true;
                    list.Update();

                    //set Item
                    SPListItem item = list.AddItem();
                    item["Title"] = "Mr .";
                    item["First Name"] = "Shaun";
                    item["Last Name"] = "Lewis";
                    item.Update();
                }
            }
        }
    }
}
