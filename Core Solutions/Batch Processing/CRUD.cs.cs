		//Add New Items Using Batch  

                                  //set schema
                                    Console.WriteLine("Item ID " + addNEWTRADOCTaskersItem.ID);
                                   
                                    StringBuilder stringBuilder = new StringBuilder();

                                    string schema =
                                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?><ows:Batch OnError=\"Return\">" +
                                            "<Method ID=\"A" + id + "\">" +
                                                "<SetList>" + strGuid + "</SetList>" +
                                                "<SetVar Name=\"ID\">New</SetVar>" +
                                                "<SetVar Name=\"Cmd\">Save</SetVar>";

                                    string schema2 = "";

                                    Object author = taskersItem["Author"];
                                    schema2 = (author == null) ? "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Author\">" + author.ToString() + "</SetVar>" : "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Author\">" + author.ToString() + "</SetVar>";
                                    Object editor = taskersItem["Editor"];
                                    schema2 += (author == null) ? "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Editor\">" + editor.ToString() + "</SetVar>" : "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Editor\">" + editor.ToString() + "</SetVar>";


                                    string schema3 = "</Method>" +
                                        "</ows:Batch>";

                                    stringBuilder.Append(schema + schema2 + schema3);

                                    

                                    string strProcessBatch = cascomWeb.ProcessBatchData(stringBuilder.ToString());


                                    //Console.WriteLine(id + " : " + strProcessBatch);

                                    id++;
   




		//Update Items using Batch
                                 //set schema
                                    Console.WriteLine("Item ID " + addNEWTRADOCTaskersItem.ID);
                                   
                                    StringBuilder stringBuilder = new StringBuilder();

                                    string schema =
                                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?><ows:Batch OnError=\"Return\">" +
                                            "<Method ID=\"A" + id + "\">" +
                                                "<SetList>" + strGuid + "</SetList>" +
                                                "<SetVar Name=\"ID\">"+addNEWTRADOCTaskersItem.ID.ToString()+"</SetVar>" +
                                                "<SetVar Name=\"Cmd\">Save</SetVar>";

                                    string schema2 = "";

                                    Object author = taskersItem["Author"];
                                    schema2 = (author == null) ? "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Author\">" + author.ToString() + "</SetVar>" : "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Author\">" + author.ToString() + "</SetVar>";
                                    Object editor = taskersItem["Editor"];
                                    schema2 += (author == null) ? "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Editor\">" + editor.ToString() + "</SetVar>" : "<SetVar Name=\"urn:schemas-microsoft-com:office:office#Editor\">" + editor.ToString() + "</SetVar>";


                                    string schema3 = "</Method>" +
                                        "</ows:Batch>";

                                    stringBuilder.Append(schema + schema2 + schema3);

                                    

                                    string strProcessBatch = cascomWeb.ProcessBatchData(stringBuilder.ToString());


                                    //Console.WriteLine(id + " : " + strProcessBatch);

                                    id++;



//Delete Using Batch

                        StringBuilder deletebuilder = new StringBuilder();
                        deletebuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Batch>");
                        string command = "<Method><SetList Scope=\"Request\">" + NEWTRADOCTaskers.ID +
                            "</SetList><SetVar Name=\"ID\">{0}</SetVar><SetVar Name=\"Cmd\">Delete</SetVar></Method>";

                        foreach (SPListItem item in NEWTRADOCTaskers.Items)
                        {
                            deletebuilder.Append(string.Format(command, item.ID.ToString()));
                        }
                        deletebuilder.Append("</Batch>");

                        cascomWeb.ProcessBatchData(deletebuilder.ToString());

