using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.SharePoint;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SPSite site;
        SPWeb web;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            site = new SPSite("http://abcuniversity");
            web = site.RootWeb;

            lstObjects.Items.Add(site.ToString());
            lstObjects.Items.Add(web);

            //lstObjects.Items.Add("SPSite Url: http://abcuniversity ");
            //lstObjects.Items.Add("ABC University: http://abcuniversity/_layouts/15/start.aspx#/SitePages/Home.aspx ");



        }

        private void lstObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstProperties.Items.Clear();
            if (lstObjects.SelectedIndex == 0)
                DisplaySiteProperties();
            else
                DisplayWebProperties();

        }

        private void DisplayWebProperties()
        {
            //site = new SPSite("http://abcuniversity");
            //web = site.RootWeb;

            lstProperties.Items.Add("Url: " + web.Url);
            lstProperties.Items.Add("Title: " + web.Title);
            lstProperties.Items.Add("Description: " + web.Description);

        }

        private void DisplaySiteProperties()
        {
            //site = new SPSite("http://abcuniversity");

            lstProperties.Items.Add("Url: " + site.Url);
            lstProperties.Items.Add("Read-Only: " + site.ReadOnly);
            lstProperties.Items.Add("Last content modification: " + site.LastContentModifiedDate);
            lstProperties.Items.Add("Description: " + site.LastSecurityModifiedDate);


        }

    }
}
