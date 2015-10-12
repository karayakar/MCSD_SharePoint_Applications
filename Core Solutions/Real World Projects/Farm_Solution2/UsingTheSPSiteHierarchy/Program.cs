using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UsingTheSPSiteHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowSPInfo(); //iterate through the farm and web applications
            //BackUpSites(); //back up site collections
            //ShowLastModifiedSites();//show last modified sites
            DeleteInactiveSites(); //delete inactive site collections
            Console.ReadLine();
        }

        private static void ShowSPInfo()
        {
            //Hit the Farm
            SPFarm myFarm = null;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                Console.WriteLine("Joined to Farm...");

                myFarm = SPFarm.Local;
                Console.WriteLine(string.Format("Properties of {0}", myFarm.Name));
                foreach(DictionaryEntry kvp in myFarm.Properties)
                {
                    Console.WriteLine(string.Format("Name = {0}, Value = {1}", kvp.Key, kvp.Value));
                }
            });

            //Hit the WebApplications and Content Databases --> Code Not Complete
            /* SPSecurity.RunWithElevatedPrivileges(delegate () {
                 SPWebService defaultService = myFarm.Services.GetValue<SPWebService>();
                 foreach(SPWebApplication app in defaultService.WebApplications)
                 {
                     Console.WriteLine("The content database for this site is: " + aSite.ContentDatabase.Name);
                     foreach(SPWeb aWeb in SPAdministrationSiteType.AllWebs)
                     {
                         if(!Strung,IsNullOrEmpty(aWeb.Description))
                         {
                             Console.WriteLine("-Web with Description:" +)
                         }
                     }
                 }

             });*/
  
        }//end ShowSPInfo()

        private static void BackUpSites()
        {
            //Backup Sites Here
            string backupDirectory = @"C:\SPBackups";
            string backupFile = "FromVSCode.spbak";
            string backupPath = System.IO.Path.Combine(backupDirectory,backupFile);

            try
            {
                SPSite backupSite = new SPSite("http://abcuniversity/sites/sitecreatedinpowershell/");
                SPSiteCollection siteitems = backupSite.WebApplication.Sites;
                siteitems.Backup(backupSite.Url, @"C:\SPbackups\FromVSCode.spbak", false);
                Console.WriteLine("Backup of" + "siteitems" + "performed sucessfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem performing backup: " + ex.Message);
            }
        }//end BackUpSites()

        private static void ShowLastModifiedSites()
        {
            //here's the sites we can manipulate
            foreach(SPWebApplication app in SPWebService.ContentService.WebApplications) //web application
            {
                foreach(SPSite site in app.Sites) //site collection
                {
                    foreach(SPWeb web in site.RootWeb.GetSubwebsForCurrentUser()) //target web site
                    {
                        Console.WriteLine(web.Url);
                    }
                    SPSecurity.RunWithElevatedPrivileges(delegate () {
                        try
                        {
                            if (site.Url.StartsWith("http://abc"))
                            {
                                string texttoWrite = string.Format("{0} was last modified {1}", site.Url,
                                    site.LastContentModifiedDate.ToString("MMMM dd, yyyy \a\t hh:mm"));

                                Console.WriteLine(texttoWrite);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message); 
                        }
                    });//end delegate()

                }
            }
        }

        public static void DeleteInactiveSites()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate () {
                    SPSite selectedSite = new SPSite("http://abcuniversity/sitedefinition1");
                    Console.WriteLine("Site pegged for deletion: {0}", selectedSite.RootWeb.GetSubwebsForCurrentUser()[0].Url);
                    selectedSite.RootWeb.GetSubwebsForCurrentUser()[0].Delete();
                    selectedSite.Dispose();


                });
                Console.WriteLine("Site deleted!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }//end class program
}//end namespace
