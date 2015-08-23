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
            ShowSPInfo();
            Console.ReadKey();
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
            
        }

    }
}
