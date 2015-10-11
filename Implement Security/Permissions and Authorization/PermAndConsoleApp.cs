using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermAndAuthConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateANewRoleDefinition(); 
            //CopyAndCustomizeARoleDefinition();
            ImpersonationNation();
            //BreakInheritance();
            Console.ReadLine();
        }

        static void CreateANewRoleDefinition()
        {
            //Show whats out there already for Permissions...
            Dictionary<int, string> PermissionsDictionary = new Dictionary<int, string>();

            Console.WriteLine("Possible permissions from the SPBasePermissions set.");

            int counter = 0;

            foreach (SPBasePermissions kind in Enum.GetValues(typeof(SPBasePermissions)))
            {
                counter++;
                PermissionsDictionary.Add(counter, Enum.GetName(typeof(SPBasePermissions), kind));


            }

            foreach (KeyValuePair<int, string> entry in PermissionsDictionary)
            {
                Console.WriteLine("{0,-5}: {1,-30}", entry.Key, entry.Value);
            }
            Console.WriteLine("** END of current permissions**");

            SPSecurity.RunWithElevatedPrivileges(delegate () {
                //Lets's create the new RoleDefinition with 5 Permissions...
                SPSite mySite = new SPSite("http://abcuniversity/_layouts/15/start.aspx");
                SPWeb myWeb = mySite.OpenWeb();

                Console.WriteLine("Lets create a new role definition from 5 existing permissions!");

                SPRoleDefinition newRoleDefinition = new SPRoleDefinition();
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("New permission #{0}: Choose a number -> ", i + 1);
                    int newPermissionNumberFromCollection = int.Parse(Console.ReadLine());
                    string newPermissionString = PermissionsDictionary[newPermissionNumberFromCollection].ToString();
                    SPBasePermissions actualPermission = (SPBasePermissions)Enum.Parse(typeof(SPBasePermissions), newPermissionString);
                    newRoleDefinition.BasePermissions |= actualPermission;
                }

                //The loop is the same as doing "newRoleDefinition.BasePermissions = SPBasePermissions.FirstNewOne |
                //  SPBasePermissions.SecondNewOne | SPBasePermissions.ThirdNewOne | etc...

                Console.Write("Name your new role ->");
                string roleName = Console.ReadLine();
                newRoleDefinition.Name = roleName;
                newRoleDefinition.Description = string.Format("A new role created from Visual Studio");

                try
                {
                    mySite.RootWeb.RoleDefinitions.Add(newRoleDefinition);
                    Console.WriteLine("New role added: {0}", newRoleDefinition);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Role not added: {0}", ex.Message);
                }

                //Clean up your mess
                myWeb.Dispose();


            }); 

        }

        static void CopyAndCustomizeARoleDefinition()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate () {

                //Get an existing roledefinition
                SPSite mySite = new SPSite("http://abcuniversity/_layouts/15/start.aspx");
                SPWeb myWeb = mySite.OpenWeb();

                //Get existingroledefinitions
                Console.WriteLine("Here's the role definitions we have so far.");
                foreach(SPRoleDefinition role in mySite.RootWeb.RoleDefinitions)
                {
                    Console.WriteLine("{0}'\n'{1}'\n", role.Name, role.Description);
                }
                Console.Write("Hit any key to continue..."); Console.Read();

                //create role definition
                SPRoleDefinition definitionToCopy = mySite.RootWeb.RoleDefinitions["Read"];
                definitionToCopy.Name = "Designer Reader";
                definitionToCopy.Description = "Owns all Read permissions, plus the ability to configure CSS," +
                    "Themes, and Borders";

                //Copy the exisitng definition...with the constructor!
                SPRoleDefinition newDefinition = new SPRoleDefinition(definitionToCopy);
                Console.WriteLine("Current permissions NOT configured for {0} level:", definitionToCopy.Name);
                foreach (SPBasePermissions permission in Enum.GetValues(typeof(SPBasePermissions)))
                {
                    if(!definitionToCopy.BasePermissions.HasFlag(permission))
                    {
                        Console.WriteLine(permission.ToString());
                    }
                    Console.WriteLine("Hit any key to continue and add two new permissions...");Console.Read();

                    //So lets add a couple of those to our new definition
                    newDefinition.BasePermissions |= SPBasePermissions.ApplyStyleSheets;
                    newDefinition.BasePermissions |= SPBasePermissions.ApplyThemeAndBorder;

                    try
                    {
                        mySite.RootWeb.RoleDefinitions.Add(newDefinition);
                        Console.WriteLine("New role added: {0}", newDefinition.Name);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Role not added: {0}", ex.Message);
                    }

                    //Clean up your mess
                    myWeb.Dispose();

                }

            });
        }

        static void BreakInheritance()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate () {

                //Get a list
                SPSite mySite = new SPSite("http://abcuniversity/_layouts/15/start.aspx");
                SPWeb myWeb = mySite.OpenWeb();

                string listUrl = "//abcuniversity/Lists/Chemicals";
                SPList chemicalList = myWeb.GetList(listUrl);

                //Break inheritence:
                chemicalList.BreakRoleInheritance(true);

                /*//add group to list with broken permissions
                SPGroup readersGroup = myWeb.SiteGroups["Readers"];
                chemicalList.RoleAssignments.Add(readersGroup);
                Console.WriteLine("Added {0} group to {1} list!", readersGroup.Name, chemicalList.EntityTypeName);*/

                //Clean up the mess
                myWeb.Dispose();
                mySite.Dispose();

                Console.WriteLine("Permissions Broken.");



            });
        }

        static void ImpersonationNation()
        {
            SPUserToken myAdminToken = null;
            SPSecurity.RunWithElevatedPrivileges(delegate () {
                SPSite myPermSite = new SPSite("http://abcuniversity/_layouts/15/start.aspx");

                myAdminToken = myPermSite.SystemAccount.UserToken;


            });

            SPSite mySite = new SPSite("http://abcuniversity/_layouts/15/start.aspx");
            SPWeb myWeb = mySite.OpenWeb();


            SPUser actualUser = myWeb.CurrentUser;
            Console.Write("Logged in as {0}", actualUser.Name);
            string isAdmin = (actualUser.IsSiteAdmin) ? "are" : "are not";
            Console.WriteLine(", and you {0} a Site Admin", isAdmin);

            //Let's see who we can pretend to be..
            SPUserCollection allUsers = myWeb.AllUsers;
            for(int i = 0; i < allUsers.Count; i++)
            {
                Console.WriteLine("{0} : {1}", i, allUsers[i].LoginName);

            }

            bool quit = false;
            while(quit != true)
            {
                Console.Write("Let's be someone else! Choose a number to impersonate -->");
                int chosenUser = int.Parse(Console.ReadLine());

                string chosenUserName = allUsers[chosenUser].LoginName;

                SPUserToken impersonateToken = myWeb.AllUsers[chosenUserName].UserToken;
                //Log in with the other user token, and let's see what the permissions are...
                SPSite myImpersonatedSite = new SPSite("http://abcuniversity/_layouts/15/start.aspx",impersonateToken);
                SPWeb myImpersonatedWeb = myImpersonatedSite.OpenWeb();
                Console.WriteLine("Now logged in as user {0}", myImpersonatedWeb.CurrentUser);

                //Find out what permissions I(this user) has on a list...
                string listUrl = "//abcuniversity/Lists/Chemicals";
                SPList chemicalList = myWeb.GetList(listUrl);
                SPBasePermissions perms =
                    chemicalList.GetUserEffectivePermissions(myImpersonatedWeb.CurrentUser.LoginName);

                //Enumerate the full permission set here and check which permissions this user has...
                //using chemicalList.DOesUserHavePermissions(user,perms);
                int howManyPermissions = 0;
                Console.WriteLine("Permissions on {0} list for {1} user.", chemicalList.EntityTypeName,
                    myImpersonatedWeb.CurrentUser.LoginName);

                foreach(SPBasePermissions permission in Enum.GetValues(typeof(SPBasePermissions)))
                {
                    if (perms.HasFlag(permission))
                    {
                        howManyPermissions++;
                        Console.WriteLine(permission.ToString());
                    }
                }
                Console.WriteLine("*** {0} permissions on list for this user *** ", howManyPermissions);

            }

        }
    }
}
