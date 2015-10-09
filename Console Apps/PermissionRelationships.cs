using System;
using Microsoft.SharePoint;
using System.Collections;

namespace CalendarRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            string ecadminSiteCol = "http://eusta043tg6wbkd:8083/sites/ecadmin/";
            Console.WriteLine("Updating ECADMIN Permissions List...");
             try
            {
                using (SPSite ecadmin = new SPSite(ecadminSiteCol))//ecadmin
                {
                    using (SPWeb ecadminWeb = ecadmin.OpenWeb())
                    {
                       
                        //get lists
                        SPList enterpriseCalendarRegistration = ecadminWeb.Lists.TryGetList("Registration");
                        SPList enterpriseCalendarPermissions = ecadminWeb.Lists.TryGetList("Permissions");

                        //set registration query
                        SPQuery registrationQuery = new SPQuery();
                        registrationQuery.Query = "<Query><Where><OrderBy><FieldRef Name='Title' /></OrderBy></Where></Query>";

                        //set registration enumerator
                        IEnumerator registrationEnumerator = enterpriseCalendarRegistration.GetItems(registrationQuery).GetEnumerator();

                        while (registrationEnumerator.MoveNext())
                        {
                            //set registration item
                            SPListItem registrationItem = (SPListItem)registrationEnumerator.Current;

                            //registration key fields
                            string registrationTitle = registrationItem["Title"].ToString();
                            string registrationUID = registrationItem["UID"].ToString();
                            string registrationcalendarUrl = registrationItem["CalendarUrl"].ToString();

                            //set permissions query
                            SPQuery permissionsQuery = new SPQuery();
                            permissionsQuery.Query = "<Query><Where><OrderBy><FieldRef Name='Title' /></OrderBy></Where></Query>";

                            //set permissions enumerator
                            IEnumerator permissionsEnumerator = enterpriseCalendarPermissions.GetItems(permissionsQuery).GetEnumerator();

                                while (permissionsEnumerator.MoveNext())
                                {

                                    //set permissions item
                                    SPListItem permissionsItem = (SPListItem)permissionsEnumerator.Current;

                                    //get fields
                                    string fromCalendarName = permissionsItem["FromCalendarName"].ToString();
                                    string toCalendaName = permissionsItem["ToCalendarName"].ToString();
                                    string toCalendarUrl = permissionsItem["ToCalendarUrl"].ToString();
                                    string fromCalendar = permissionsItem["FromCalendar"].ToString();
                                    string toCalendar = permissionsItem["ToCalendar"].ToString();

                                    if (fromCalendarName.Contains(registrationTitle))
                                    {
                                        //Change From Calendar GUID
                                        permissionsItem["FromCalendar"] = registrationItem["UID"].ToString();
                                        permissionsItem.Update();

                                       
                                    }
                                    if (toCalendaName.Contains(registrationTitle))
                                    {
                                        //change To Calendar Url
                                        permissionsItem["ToCalendarUrl"] = registrationItem["CalendarUrl"].ToString();

                                        //change To Calendar GUID
                                        permissionsItem["ToCalendar"] = registrationItem["UID"].ToString();
                                        permissionsItem.Update();

                                    }

                                }//end permissions

                                
                            
                        }//end registration

                         
                        //check runtime 
                        

                        Console.WriteLine("Runtime Complete");
                        Console.ReadLine();

                        

                        
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
        }//end useCaseDeleteItems
        
    }
}
