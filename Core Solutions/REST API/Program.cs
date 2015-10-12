using System;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Linq;
using System.Net;
using System.Data.Services;
using System.Data.Services.Client;
using WorkingREST.CATS;//create web service ListDataService --> CATS
using WorkingREST.CASCOM;


namespace WorkingREST
{
   

    public class Program 
    {
        static void Main(string[] args)
        {

            rest();  
            Console.Write("Stepping Complete");
            Console.ReadLine();

        }//end main()

        static void rest()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    //set context and authorization
                    CatsDataContext cats = new CatsDataContext(new Uri("http://eusta043tg6wbkd:46062/sites/cats/_vti_bin/listdata.svc/"));
                    cats.Credentials = System.Net.CredentialCache.DefaultCredentials; //get security authorization for web site

                    AMODataContext cascom = new AMODataContext(new Uri("http://eusta043tg6wbkd:8086/sites/AMO/_vti_bin/listdata.svc"));
                    cascom.Credentials = System.Net.CredentialCache.DefaultCredentials; //get security authorization for web site

                    
                    
                    cascom.AddToSiteGroups(
                            new SiteGroupsItem
                            {
                                Title = "New Title from Visual Studio"


                            });

                    cascom.SaveChanges();




                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();

            }
            
            


        }//end getCATS()



    }//end class



}
