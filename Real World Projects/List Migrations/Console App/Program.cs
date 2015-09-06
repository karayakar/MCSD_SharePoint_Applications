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
            SPList catsList = new SPSite(catsUrl).OpenWeb().Lists.TryGetList("AttachmentList1");//get Taskers list

            /*
            
            DateTime date = DateTime.Now;
            SPFieldCalculated calculatedField = catsList.Fields.GetField("SubjectSuspenseDate") as SPFieldCalculated; //calculated field
            SPFieldUser user = new SPFieldUser(catsList.Fields, "Author");
				user.SelectionMode = SPFieldUserSelectionMode.PeopleOnly;
                SPFieldUser user2 = new SPFieldUser(catsList.Fields, "Editor");
			user2.SelectionMode = SPFieldUserSelectionMode.PeopleOnly;
 
                
            

			//set item
            SPListItem item = catsList.AddItem();
			item["ActionOfficer"] = "Shaun Lewis"; //Single Line of Text
			item["ActionRequired"] = "Provide Answer via Email"; //Choice 
			item["AlternateNumber"] = "2"; //Single Line of Text
			item["Comments"] = "BBP 3.0 Prototyping and Experimentation"; //Multiple Lines of Text Fields
			item["CompletionStatus"] = "Open";//Choice
			item["ContainsPII"] = false; //yes / no
			item["ControlNumber"] = "AA151212";//Single line of text
			item["CurrentLocation"] = "20";//Single line of text
			item["CurrentLocationDate"] = date; //Date and Time
			item["DateClosed"] = date; //Date and Time
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
			item["ReceivedDate"] = date; //Date and Time
			item["Recipient"] = "Recipient"; //Single line of text
			item["SecurityLevel"] = "SecurityLevel"; //Choice
			item["SubjectSuspenseDate"] = "SubjectSuspenseDate"; //Calculated (calculation based on other columns) 
			calculatedField.Formula = "=IF(SuspenseDate='','',TEXT(SuspenseDate,'mm/dd/yyyy'))"; //set calculated field formula
			calculatedField.OutputType = SPFieldType.Text;//set return type to text
			item["SuspenseDate"] = date; //date and time 
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
                        //web.AllowUnsafeUpdates = true;
                        SPList NEWTRADOCTaskers = web.Lists.TryGetList("AttachmentList2");//get list
                        int taskersItemCount = taskers.Items.Count; //taskers item count
                        int NEWTRADOCTaskersItemCount = NEWTRADOCTaskers.Items.Count; //NEWTRADOCTaskers item count


                        if (taskersItemCount > NEWTRADOCTaskersItemCount) { useCaseAddItems(taskers, NEWTRADOCTaskers);} //add items NEWTRADOCTaskers
                            NEWTRADOCTaskersItemCount = NEWTRADOCTaskers.Items.Count; //update count
                        if (taskersItemCount < NEWTRADOCTaskersItemCount) { useCaseDeleteItems(taskers, NEWTRADOCTaskers); } //remove items NEWTRADOCTaskers
                            NEWTRADOCTaskersItemCount = NEWTRADOCTaskers.Items.Count;//update count
                        if (taskersItemCount == NEWTRADOCTaskersItemCount) { useCaseUpdateItems(taskers, NEWTRADOCTaskers, web); } //update items  NEWTRADOCTaskers

                        //web.AllowUnsafeUpdates = false;


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
                int catsListItemCount = catsList.Items.Count;
                int cascomListIyemCount = cascomList.Items.Count;
                int catsItemIndex = 0;

                foreach (SPListItem catsItem in catsList.Items)//iterate items in cats
                {
                    Console.WriteLine("CATS Item " + catsItem + " : " + catsItemIndex);
                    Console.WriteLine("\tCASCOM Items " + cascomList.Items[catsItemIndex].Title);
                    SPListItem cascomItem = cascomList.Items[catsItemIndex];//cascom list item

                    for (int i = cascomList.Items[catsItemIndex].Fields.Count - 1; i >= 0; i--)//iterate cascom fields per cascom item
                    {
                        //Console.WriteLine(cascomItem.Fields[i].GetType());
                        SPField cascomField = cascomList.Items[catsItemIndex].Fields[i];
                        string getFieldTypes = cascomField.GetType().ToString();//get cascom field types
                        //string NEWTRADOCTaskersInternalName;//get cascom internal names
                        //Console.WriteLine("\t\t" + cascomField.GetType());

                        if (getFieldTypes.Contains("SPFieldAttachments"))//add choice fields
                        {
                            SPAttachmentCollection catsAttachments = catsItem.Attachments; //set cats attachment collection
                            SPAttachmentCollection cascomAttachments = cascomItem.Attachments; //set cascom attachment collection
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
                            }//end if
                        }//end if
                    }//end for
                    cascomItem.Update();
                    Console.WriteLine("Item Updated");
                    catsItemIndex++;
                }//end foreach items


            }//end try

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }//end useCaseUpdateItems


        static void useCaseAddItems(SPList catsList, SPList cascomList)
        {
            try
            {
                int catsListItemCount = catsList.Items.Count;
                int cascomListCount = cascomList.Items.Count;
                int howManyMoreItemsCATSHave = catsListItemCount - cascomListCount;


                //taskersIndex--> start point of taskers new item(s)
                for (int taskersIndex = catsListItemCount - howManyMoreItemsCATSHave; taskersIndex < catsListItemCount; taskersIndex++)
                {
                    SPListItem catsListItem = catsList.Items[taskersIndex];
                    //Console.WriteLine(catsListItem + " at " + taskersIndex);

                    SPListItem addNEWTRADOCTaskersItem = cascomList.AddItem();//get items to add
                    foreach (SPField taskersField in catsList.Fields)//iterate fields fields
                    {
                        string getFieldTypes = taskersField.GetType().ToString();//get taskers field types
                        string taskersInternalNames = taskersField.InternalName;//get taskers internal names
                        SPField NEWTRADOCTaskersField = cascomList.Fields.GetField(taskersInternalNames);//get cascom list internal names

                        //want to use else if due to iterations = 88
                        //focus on fields with content
                        if (getFieldTypes.Contains("SPFieldChoice"))//add choice fields
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        else if (getFieldTypes.Contains("SPFieldDateTime"))//add date fields
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        else if ((taskersField.Title == "ContainsPII") && (taskersField.Title != "IsDraft"))//add yes/no fields
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        else if (getFieldTypes.Contains("SPFieldCalculated"))//add calculated columns
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        else if (getFieldTypes.Contains("SPFieldUser"))//add Person/Group Fields
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        else if (getFieldTypes.Contains("SPFieldText") && taskersField.InternalName != "_CopySource" && taskersField.InternalName != "_UIVersionString") //add single lines of text
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        else if (getFieldTypes.Contains("SPFieldMultiLineText"))//add miltiple lines of text fields
                        {
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }
                        /*else if (getFieldTypes.Contains("SPFieldAttachments"))//add miltiple lines of text fields
                        {
                            catsListItem.Attachments.Add();
                            Console.WriteLine(taskersField.GetType());
                            addNEWTRADOCTaskersItem[taskersInternalNames] = catsListItem[taskersInternalNames];
                            NEWTRADOCTaskersField.Update();
                        }*/
                    }//end foreach fields 
                    //Console.WriteLine("Update Item Here ");
                    addNEWTRADOCTaskersItem.Update();//update items

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
                    //Console.WriteLine("CATS List Items " + NEWTRADOCTaskersControlNumber + " : " + j);

                    if (Object.Equals(NEWTRADOCTaskersControlNumber, taskersControlNumber))
                    {
                        checkControlNumberExistsInCATS = true;
                        Console.WriteLine("CATS Control Number " + taskersControlNumber + "   CASCOM Control Number " + NEWTRADOCTaskersControlNumber + " : " + checkControlNumberExistsInCATS);
                    }//end if



                }//end for
                if (checkControlNumberExistsInCATS == false)
                {

                    Console.WriteLine("CASCOM Control Number " + NEWTRADOCTaskersControlNumber + " : " + checkControlNumberExistsInCATS);
                    Console.WriteLine("Deleting items at Index " + i);
                    cascomList.Items.Delete(i);

                }//end if
                //Console.WriteLine("Deleting items: " + i);
                //cascomList.Items.Delete(i);

            }//end for


        }//end useCaseDeleteItems








    }//end class
}
