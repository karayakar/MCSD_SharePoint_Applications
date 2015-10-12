using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace ConsoleApplication1
{
    class CATSToCASCOM
    {
        static void Main(string[] args)
        {

            SPList taskers = getCATS();//method in constructor
            useCases(taskers);
            Console.WriteLine("Run Time Complete");

            Console.ReadLine();

        }//end main()

        static SPList getCATS()
        {


            string catsUrl = "http://abcuniversity/";//update urls
            SPList catsList = new SPSite(catsUrl).OpenWeb().Lists.TryGetList("Taskers");//get Taskers list

                
                /*
                

                DateTime d1 = new DateTime(1999,05,20);
                DateTime d2 = new DateTime(2015, 10, 04);
                DateTime d3 = new DateTime(2000, 01, 25);
                DateTime d4 = new DateTime(1917, 03, 22);
                DateTime d5 = new DateTime(2001, 09, 11);
                DateTime d6 = new DateTime(4000, 02, 20);
                SPFieldCalculated calculatedField = catsList.Fields.GetField("SubjectSuspenseDate") as SPFieldCalculated; //calculated field
                SPFieldUser user = new SPFieldUser(catsList.Fields, "Author");
                SPFieldUser user2 = new SPFieldUser(catsList.Fields, "Editor"); 




                //set item
                SPListItem item = catsList.AddItem();
                item["ActionOfficer"] = "Shaun Lewis"; //Single Line of Text
                item["ActionRequired"] = "Prepare CSA Brief/IPR"; //Choice 
                item["AlternateNumber"] = "2"; //Single Line of Text
                item["Comments"] = "BBP 3.0 Prototyping and Experimentation"; //Multiple Lines of Text Fields
                item["CompletionStatus"] = "Open";//Choice
                item["ContainsPII"] = false; //yes / no
                item["ControlNumber"] = "BB151212";//Single line of text
                item["CurrentLocation"] = "20";//Single line of text
                item["CurrentLocationDate"] = d1; //Date and Time
                item["DateClosed"] = d2; //Date and Time
                item["DocumentType"] = "ALARACT"; //Choice 
                item["ECCNumber"] = "ECCNumber"; //Single line of text
                item["Email1"] = "Email1\r\nEmail1\r\nEmail1"; //Multiple lines of text
                item["Email2"] = "Email2\r\nEmail2\r\nEmail2"; //Multiple lines of text
                item["EmailRecipients"] = "EmailRecipents\r\nEmailRecipents\r\nEmailReceipients"; //Multiple lines of text
                item["IsDraft"] = true; //Yes/No
                item["LeadAssistPOC"] = "LeadAssistPOC\r\nLeadAssistPOC\r\nLeadAssistPOC\r\n"; //Multiple lines of text
                item["OfficeSymbol"] = "OfficeSymbol"; //Single line of text
                item["Orginator"] = "Orginator"; //Single line of text
                item["Phone"] = "Phone"; //Single line of text
                item["ReceivedDate"] = d3; //Date and Time
                item["Recipient"] = "Recipient"; //Single line of text
                item["SecurityLevel"] = "FOUO"; //Choice
                item["SubjectSuspenseDate"] = "SubjectSuspenseDate"; //Calculated (calculation based on other columns) 
                calculatedField.Formula = "=IF(SuspenseDate='','',TEXT(SuspenseDate,'mm/dd/yyyy'))"; //set calculated field formula
                calculatedField.OutputType = SPFieldType.Text;//set return type to text
                item["SuspenseDate"] = d4; //date and time 
                item["Created"] = d5;//date and time
                item["Modified"] = d6;//date and time
                item["TaskDeliverables"] = "TaskDeliverables\r\nTaskDeliverables\r\nTaskDeliverables"; //Multiple lines of text
                item["TaskerAssists"] = "TaskerAssists\r\nTaskerAssists\r\nTaskerAssists\r\n"; //Multiple lines of text
                item["TaskerHistory"] = "TaskerHistory\r\nTaskerHistory\r\nTaskerHistory\r\n"; //Multiple lines of text
                item["TaskerInfo"] = "TaskerInfo\r\nTaskerInfo\r\nTaskerInfo\r\n"; //Multiple lines of text
                item["TaskerLeads"] = "TaskerLeads\r\nTaskerLeads\r\nTaskerLeads\r\n"; //Multiple lines of text
                item["TaskerName"] = "TaskerName"; //Single line of text
                item["TaskerType"] = "CG"; //Choice
                item["WorkflowStatus"] = true; //yes/no


                item.Update();

                 */
                



            return catsList;//return CATS taskers

        }//end getCATS()

        static void useCases(SPList taskers)
        {
            string cascomUrl = "http://abcuniversity/";

            try
            {
                using (SPSite site = new SPSite(cascomUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;

                        SPList NEWTRADOCTaskers = web.Lists.TryGetList("NEWTRADOCTaskers");//get list
                        int taskersItemCount = taskers.Items.Count; //taskers item count
                        int NEWTRADOCTaskersItemCount = NEWTRADOCTaskers.Items.Count; //NEWTRADOCTaskers item count

                        //add/update NEWTRADOCTaskers items
                        if (taskersItemCount > NEWTRADOCTaskersItemCount || taskersItemCount == NEWTRADOCTaskersItemCount) { useCaseUpdateItems(taskers, NEWTRADOCTaskers, web); } 
                            NEWTRADOCTaskersItemCount = NEWTRADOCTaskers.Items.Count; //update count
                        if (taskersItemCount < NEWTRADOCTaskersItemCount) { useCaseDeleteItems(taskers, NEWTRADOCTaskers); } //remove NEWTRADOCTaskers items

                        web.AllowUnsafeUpdates = false;


                    }//end SPWeb
                }//end using SPSite
            }//end try

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }//end useCases()

        static void useCaseUpdateItems(SPList catsList, SPList cascomList, SPWeb webSite)
        {
            try
            {
                //we are going to add items for the first time in NEWTRADOC taskers here;we will break this into a seprate method to increase debugging simplicity
                if (cascomList.Items.Count == 0) { useCaseAddInitialItems(catsList, cascomList); }//add NEWTRADOC Taskers on initial push

                foreach (SPListItem catsListItem in catsList.Items)//iterate taskers items
                {
                    //Console.WriteLine("CATS Item " + catsListItem);
                    bool checkControlNumberExistsInCASCOM = false;
                    string taskersPrimaryKey = catsListItem.Fields.GetField("Title").ToString();
                    Object taskersControlNumber = catsListItem[taskersPrimaryKey];
                    //Console.WriteLine("CATS Control Number " + taskersControlNumber);

                    foreach (SPListItem cascomListItem in cascomList.Items)//iterate NEWTRADOCTaskers items
                    {
                        //Console.WriteLine("\tCASCOM Item " + cascomListItem);

                        string NEWTRADOCTaskersprimaryKey = cascomListItem.Fields.GetField("Title").ToString();
                        Object NEWTRADOCTaskersControlNumber = cascomListItem[NEWTRADOCTaskersprimaryKey];
                        //Console.WriteLine("\tCASCOM Control Number " + NEWTRADOCTaskersControlNumber);

                        if (Object.Equals(NEWTRADOCTaskersControlNumber, taskersControlNumber))//we are going to update the items here since they exist in NEWTRADOC taskers
                        {
                            DateTime d1 = new DateTime(1900, 05, 20);
                            checkControlNumberExistsInCASCOM = true;
                            //Console.WriteLine("\tCATS Control Number " + taskersControlNumber + "   CASCOM Control Number " + NEWTRADOCTaskersControlNumber + " : " + checkControlNumberExistsInCASCOM);
                            foreach (SPField taskersField in catsList.Fields)//iterate taskers fields
                            {
                                string getFieldTypes2 = taskersField.GetType().ToString();//get taskers field types
                                string taskersInternalName2 = taskersField.InternalName;//get taskers internal names

                                if (getFieldTypes2.Contains("SPFieldText") && taskersInternalName2 != "_CopySource" && taskersInternalName2 != "_UIVersionString" && taskersInternalName2 != "Title") //add single lines of text
                                {
                                    //Copy Source/_CopySource and _UIVersionString/Version pertains to local list settings and should not copy over                          
                                    //Console.WriteLine("\t\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName2]);
                                    cascomListItem[taskersInternalName2] = catsListItem[taskersInternalName2];
                                    
                                }
                                else if (getFieldTypes2.Contains("SPFieldMultiLineText"))//add miltiple lines of text fields
                                {
                                    //Console.WriteLine("\t\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName2]);
                                    cascomListItem[taskersInternalName2] = catsListItem[taskersInternalName2];
                                    
                                }
                                else if (getFieldTypes2.Contains("SPFieldChoice"))//add choice fields
                                {
                                    cascomListItem[taskersInternalName2] = catsListItem[taskersInternalName2];
                                }
                                else if (getFieldTypes2.Contains("SPFieldBoolean") && taskersInternalName2 != "_HasCopyDestinations" && taskersInternalName2 != "_IsCurrentVersion")//add yes/no fields
                                {
                                    //_HasCopyDestinations/_IsCurrentVersion pertains to local list settings
                                    cascomListItem[taskersInternalName2] = catsListItem[taskersInternalName2];

                                }
                                else if (getFieldTypes2.Contains("SPFieldDateTime"))
                                {
                                    cascomListItem[taskersInternalName2] = catsListItem[taskersInternalName2];
                                }
                                else if (getFieldTypes2.Contains("SPFieldUser"))
                                {
                                    Console.WriteLine("\t" + getFieldTypes2);
                                    Console.WriteLine("\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName2]);
                                    cascomListItem[taskersInternalName2] = catsListItem[taskersInternalName2];
                                }
                                else if (getFieldTypes2.Contains("SPFieldAttachments"))//add attachments
                                {
                                    //addNEWTRADOCTaskersItem.Update();//might need an update to for attachments to recognize item
                                    /*SPAttachmentCollection catsAttachments = catsListItem.Attachments; //set cats attachment collection
                                    SPAttachmentCollection cascomAttachments = cascomListItem.Attachments; //set cascom attachment collection
                                    int numberOfCatsAttachments = catsAttachments.Count;//get number of cats attachments
                                    int numberOfCASCOMAttachments = cascomAttachments.Count;//get number of cascom attachments

                                    if (numberOfCatsAttachments > 0)// if any attachments exists
                                    {
                                        if (numberOfCASCOMAttachments > 0)//delete and add current attachments to refresh
                                        {
                                            Console.WriteLine("\t\tDeleting CASCOM attachments.");
                                            Console.WriteLine("\t\tNumber of CASCOM Attachments " + numberOfCASCOMAttachments);
                                            for (int j = 0; j < catsAttachments.Count; j++)//cats attachments
                                            {
                                                string path = catsAttachments.UrlPrefix + catsAttachments[j];//specify relative url for file location
                                                SPFile catsFile = webSite.GetFile(path);//cats file object
                                                string catsFileName = catsFile.Name;//cats file name
                                                cascomAttachments.Delete(catsFileName);//delete attachments
                                                Console.WriteLine("\t\tDeleting Attachment: " + catsFileName);
                                                //Console.WriteLine("\tAdding Attachments: " + catsFileName);
                                            }//end for
                                        }//end if
                                        numberOfCASCOMAttachments = cascomAttachments.Count;
                                        if (numberOfCASCOMAttachments == 0)//add attachments
                                        {
                                            Console.WriteLine("\t\tAdding CASCOM attachments.");
                                            Console.WriteLine("\t\tNumber of CASCOMAttachments " + numberOfCASCOMAttachments);
                                            for (int j = 0; j < catsAttachments.Count; j++)//cats attachments
                                            {
                                                string path = catsAttachments.UrlPrefix + catsAttachments[j];//specify relative url for file location
                                                SPFile catsFile = webSite.GetFile(path);//cats file object
                                                string catsFileName = catsFile.Name;//cats file name
                                                Console.WriteLine("\t\tAdding Attachment: " + catsFileName);
                                                byte[] binFile = catsFile.OpenBinary();//open file in binary format
                                                cascomAttachments.Add(catsFileName, binFile);//add files to cascom item

                                            }//end for
                                        }//end if    
                                    }//end if*/
                                }//end if



                            }//end for taskers fields
                            Console.WriteLine("Updating Item.");
                            cascomListItem.Update();//update content database
                        }//end if
                       
                    }//end for //taskers items
                    if (checkControlNumberExistsInCASCOM == false)//we are going to add items here since they do not exist in NEWTRADOC taskers
                    {

                        //Console.WriteLine("CATS Control Number DO Not EXIST in CASCOM -> " + taskersControlNumber);
                        SPListItem addNEWTRADOCTaskersItem = cascomList.AddItem();//items to add to NEWTRADOCTaskers
                        foreach (SPField taskersField in catsList.Fields)//iterate taskers fields
                        {
                            string getFieldTypes = taskersField.GetType().ToString();//get taskers field types
                            string taskersInternalName = taskersField.InternalName;//get taskers internal names

                            if (getFieldTypes.Contains("SPFieldText") && taskersInternalName != "_CopySource" && taskersInternalName != "_UIVersionString") //add single lines of text
                            {
                                //Copy Source/_CopySource and _UIVersionString/Version pertains to local list settings and should not copy over                          

                                //Console.WriteLine("\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName]);
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                                
                            }
                            else if (getFieldTypes.Contains("SPFieldMultiLineText"))//add miltiple lines of text fields
                            {
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                               
                                //Console.WriteLine("\t\t\tUpdating " + cascomField.Title);
                            }
                            else if (getFieldTypes.Contains("SPFieldChoice"))//add choice fields
                            {
                                //Console.WriteLine("\t" + getFieldTypes);
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldBoolean") && taskersInternalName != "_HasCopyDestinations" && taskersInternalName != "_IsCurrentVersion")//add yes/no fields
                            {
                                //_HasCopyDestinations/_IsCurrentVersion pertains to local list settings
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldDateTime"))
                            {
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldUser"))
                            {
                                Console.WriteLine("\t" + getFieldTypes);
                                Console.WriteLine("\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName]);
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldAttachments"))//add attachments
                            {
                                //addNEWTRADOCTaskersItem.Update();//might need an update to for attachments to recognize item
                                /*SPAttachmentCollection catsAttachments = catsListItem.Attachments; //set cats attachment collection
                                SPAttachmentCollection cascomAttachments = cascomListItem.Attachments; //set cascom attachment collection
                                int numberOfCatsAttachments = catsAttachments.Count;//get number of cats attachments
                                int numberOfCASCOMAttachments = cascomAttachments.Count;//get number of cascom attachments

                                if (numberOfCatsAttachments > 0)// if any attachments exists
                                {
                                    if (numberOfCASCOMAttachments > 0)//delete and add current attachments to refresh
                                    {
                                        Console.WriteLine("\t\tDeleting CASCOM attachments.");
                                        Console.WriteLine("\t\tNumber of CASCOM Attachments " + numberOfCASCOMAttachments);
                                        for (int j = 0; j < catsAttachments.Count; j++)//cats attachments
                                        {
                                            string path = catsAttachments.UrlPrefix + catsAttachments[j];//specify relative url for file location
                                            SPFile catsFile = webSite.GetFile(path);//cats file object
                                            string catsFileName = catsFile.Name;//cats file name
                                            cascomAttachments.Delete(catsFileName);//delete attachments
                                            Console.WriteLine("\t\tDeleting Attachment: " + catsFileName);
                                            //Console.WriteLine("\tAdding Attachments: " + catsFileName);
                                        }//end for
                                    }//end if
                                    numberOfCASCOMAttachments = cascomAttachments.Count;
                                    if (numberOfCASCOMAttachments == 0)//add attachments
                                    {
                                        Console.WriteLine("\t\tAdding CASCOM attachments.");
                                        Console.WriteLine("\t\tNumber of CASCOMAttachments " + numberOfCASCOMAttachments);
                                        for (int j = 0; j < catsAttachments.Count; j++)//cats attachments
                                        {
                                            string path = catsAttachments.UrlPrefix + catsAttachments[j];//specify relative url for file location
                                            SPFile catsFile = webSite.GetFile(path);//cats file object
                                            string catsFileName = catsFile.Name;//cats file name
                                            Console.WriteLine("\t\tAdding Attachment: " + catsFileName);
                                            byte[] binFile = catsFile.OpenBinary();//open file in binary format
                                            cascomAttachments.Add(catsFileName, binFile);//add files to cascom item

                                        }//end for
                                    }//end if    
                                }//end if*/
                            }//end if
                        }//end for taskers fields
                        Console.WriteLine("Adding Item");
                        addNEWTRADOCTaskersItem.Update();//update content database
                    }//end if
                }//end for taskers items
                   
            }//end try

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }//end useCaseUpdateItems



        static void useCaseAddInitialItems(SPList catsList, SPList cascomList)
        {
            try
            {
               //Console.WriteLine("NEWTRADOCTaskers Item Count = 0");
                foreach(SPListItem catsListItem in catsList.Items)//iterate taskers items
                {
                    //Console.WriteLine("CATS Item " + catsListItem);
                        SPListItem addNEWTRADOCTaskersItem = cascomList.AddItem();//items to add to NEWTRADOCTaskers
                        foreach (SPField taskersField in catsList.Fields)//iterate taskers fields
                        {
                            string getFieldTypes = taskersField.GetType().ToString();//get taskers field types
                            string taskersInternalName = taskersField.InternalName;//get taskers internal names

                            if (getFieldTypes.Contains("SPFieldText") && taskersInternalName != "_CopySource" && taskersInternalName != "_UIVersionString") //add single lines of text
                            {
                                //Copy Source/_CopySource and _UIVersionString/Version pertains to local list settings and should not copy over                          

                                //Console.WriteLine("\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName]);
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                                
                            }                         
                            else if (getFieldTypes.Contains("SPFieldMultiLineText"))//add miltiple lines of text fields
                            {
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];                               
                                //Console.WriteLine("\t\t\tUpdating " + cascomField.Title);
                            }
                            else if (getFieldTypes.Contains("SPFieldChoice"))//add choice fields
                            {
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldBoolean") && taskersInternalName != "_HasCopyDestinations" && taskersInternalName != "_IsCurrentVersion")//add yes/no fields
                            {
                                    //_HasCopyDestinations/_IsCurrentVersion pertains to local list settings
                                    addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldDateTime"))
                            {
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                            }
                            else if (getFieldTypes.Contains("SPFieldUser"))
                            {
                                Console.WriteLine("\t" + getFieldTypes);
                                Console.WriteLine("\tCATS Field Internal Name: " + taskersField.InternalName + "\n\tCATS Display Name: " + taskersField.Title + "\n\tValue: " + catsListItem[taskersInternalName]);
                                addNEWTRADOCTaskersItem[taskersInternalName] = catsListItem[taskersInternalName];
                        }




                    }//end for
                    Console.WriteLine("\n Item Updated");
                    addNEWTRADOCTaskersItem.Update(); ;//update content database

                }//end for



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }


        }//end useCaseAddItems





        static void useCaseDeleteItems(SPList catsList, SPList cascomList)
        {

            //NEWTRADOCTaskersIndex--> start point of taskers new item(s) top-down
            try
            {
                Console.WriteLine("Deleting Items");
                for (int i = cascomList.Items.Count - 1; i >= 0; i--)
                {
                    bool checkControlNumberExistsInCATS = false;
                    string NEWTRADOCTaskersInternalName = cascomList.Items[i].Fields.GetField("Title").ToString();
                    Object NEWTRADOCTaskersControlNumber = cascomList.Items[i][NEWTRADOCTaskersInternalName];
                    //Console.WriteLine("CASCOM Control Number " + NEWTRADOCTaskersControlNumber);

                    for (int j = catsList.Items.Count - 1; j >= 0; j--)
                    {
                        string taskersInternalName = catsList.Items[j].Fields.GetField("Title").ToString();
                        Object taskersControlNumber = catsList.Items[j][taskersInternalName];
                        Console.WriteLine("\tCATS Control Number " + taskersControlNumber + " : " + j);

                        if (Object.Equals(NEWTRADOCTaskersControlNumber, taskersControlNumber))
                        {
                            checkControlNumberExistsInCATS = true;
                            Console.WriteLine("\tCATS Control Number " + taskersControlNumber + "   CASCOM Control Number " + NEWTRADOCTaskersControlNumber + " : " + checkControlNumberExistsInCATS);
                        }//end if



                    }//end for
                    if (checkControlNumberExistsInCATS == false)
                    {

                        Console.WriteLine("CASCOM Control Number " + NEWTRADOCTaskersControlNumber + " : " + checkControlNumberExistsInCATS);
                        Console.WriteLine("Deleting items at Index " + i);
                        cascomList.Items.Delete(i);

                    }//end if


                }//end for

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }


        }//end useCaseDeleteItems








    }//end class
}
