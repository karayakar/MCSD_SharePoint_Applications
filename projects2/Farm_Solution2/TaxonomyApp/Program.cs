using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxonomyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetTermInformation();
            CreateAContentType();
            Console.ReadLine();
        }

        private static void GetTermInformation()
        {
            //TaxonomySession
            TaxonomySession session = new TaxonomySession(new Microsoft.SharePoint.SPSite("http://abcuniversity/"));

            //TermStores
            TermStoreCollection termStores = session.TermStores;
            Console.WriteLine("There is/are {0} term stores(s) in this site", termStores.Count);

            //Groups
            foreach (TermStore store in termStores)
            {
                GroupCollection groups = store.Groups;
                Console.WriteLine("There is/are {0} groups in Term Store {1}", groups.Count,store.Name);

                foreach (Group group in groups)
                {
                    //If you want to add terms...
                    //group.CreateTermSet("Some new group");

                    Console.WriteLine("Group {0}:", group.Name);
                    //TermSetcollections
                    TermSetCollection terms = group.TermSets;

                    //TermSets
                    foreach (TermSet set in terms)
                    {
                        Console.WriteLine("-Set Name: {0}", set.Name);
                        if (set.Name == "People")
                        {
                            Console.WriteLine("Defined term {0} is described as {1} and has a count of {2}",
                                set.Name, set.Description, set.Terms.Count);

                            //Terms
                            foreach (Term term in set.Terms)
                            {
                                Console.WriteLine("Term '{0}'", term.Name);
                            }
                        }
                    }

                }

            }
        }

        private static void CreateAContentType()
        {
            SPList listFields;
            SPWeb myWeb;
            SPSite myDemoSite = new SPSite("http://abcuniversity");

            Console.WriteLine("Talking to SharePoint, Don't Go Anywhere.");

            myWeb = myDemoSite.OpenWeb();
            listFields = myWeb.Lists.TryGetList("CustomizableList");

            List<SPField> fieldsForContentType = new List<SPField>();
            string[] fieldsIWantToAdd = {"AnnualSalary", "SportType", "CurrentStatus"};
            foreach(SPField field in listFields.Fields)
            {
                //Console.WriteLine("Field name: {0}, \nField ID: {1}\nField Group: {2}\n",
                    //field.StaticName, field.Id.ToString(),field.Group);

                //3 differencet ways of adding fields
                //-1- Adding field directly to list using ADD()
                string newFieldA = null, newFieldB = null, newFieldC = null;
                if(listFields.Fields.ContainsField("CurrentTeam") == false)
                {
                    Console.WriteLine("Adding CurrentTeam...");
                    newFieldA = listFields.Fields.Add("CurrentTeam", SPFieldType.Text, false);
                    Console.WriteLine("Added CurrentTeam column to list");
                }
                else
                {
                    Console.WriteLine("Added CurrentTeam column to list.");
                }

                //-and2- Adding the same field to site columns ausing SPField object and target list.
                if (listFields.Fields.ContainsField("PlayerPosition") == false)
                {
                    SPField addANewField = listFields.Fields.CreateNewField("Text", "PlayerPosition");
                    addANewField.Description = "This position, will vary by sport.";

                    //Add it to the Web first... We should probably do the duplication here, too...
                    myWeb.Fields.Add(addANewField);
                    newFieldB = listFields.Fields.Add(addANewField);
                    Console.WriteLine("PlayerPosition column added to the list...");

                }
                else
                {
                    Console.WriteLine("Added PlayerPosition column to list.");
                }
                
                //-and3!- //Using System.Collections to create and add choice field
                if(listFields.Fields.ContainsField("MyPeronalField") == false)
                {
                    System.Collections.Specialized.StringCollection choices = new System.Collections.Specialized.StringCollection();
                    choices.AddRange(new string[] {"Healthy","Out","Likely","Probable"});
                    //Add("DisplayName",FieldType,Required,CompactName,choicelist
                    newFieldC = listFields.Fields.Add("MyPeronalField", SPFieldType.Choice, false, false, choices);
                    Console.WriteLine("MyPeronalField field added to the list...");

                }
                else
                {
                    Console.WriteLine("MyPeronalField not added, already part of the list...");
                }



                /*//If its one of the fields we're interested in, add it to our collection
                if(fieldsIWantToAdd.Contains(field.StaticName))
                {
                    fieldsForContentType.Add(field);
                }*/



            }//end foreach

            SPContentTypeCollection allMyContent = myWeb.ContentTypes;
            SPContentType newContentType = new SPContentType(
                    allMyContent["item"], allMyContent, "TestContentType");
            allMyContent.Add(newContentType);

            string newField1 = myWeb.Fields.Add("AnnualSalary", SPFieldType.Number, false);
            SPFieldLink newField1Link = new SPFieldLink(myWeb.Fields.GetField(newField1));
            newContentType.FieldLinks.Add(newField1Link);

            string newField2 = myWeb.Fields.Add("CurrentStatus", SPFieldType.Text, false);
            SPFieldLink newField2Link = new SPFieldLink(myWeb.Fields.GetField(newField2));
            newContentType.FieldLinks.Add(newField2Link);

            string newField3 = myWeb.Fields.Add("SportType", SPFieldType.Text, false);
            SPFieldLink newField3Link = new SPFieldLink(myWeb.Fields.GetField(newField3));
            newContentType.FieldLinks.Add(newField3Link);

            //newContentType.Update();

        }
    }
}
