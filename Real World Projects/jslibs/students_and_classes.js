
$( window ).ready(function() {
    
	var tracked_classes = {};
	var classes_under_question = {};
	
				
				var total_classes = function(){
				
					
					var query = "<Query><OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy></Query>";
				  	var view_fields = "<ViewFields><FieldRef Name=\'ID\'/><FieldRef Name=\'Title\'/></ViewFields>";   				  
				    var source_list = "ClassList";
				    class_arr = [];
				    
				        

							$().SPServices({
					
							        operation: "GetListItems",
							        async: false,
							        listName: source_list,
							        CAMLViewFields: view_fields,
							        CAMLQuery: query,
							        completefunc: function (xData, status) {
							            	//alert(xData.responseXML.xml);
							            
				    						
				    					$(xData.responseXML).SPFilterNode("z:row").each(function() {
							            
							            
							            	try{
							            		
							            			var class_id = parseInt($(this).attr("ows_ID"));
							            			var title = $(this).attr("ows_Title");
							            			class_arr.push(class_id + " : " + title);
			
							            	
							            	}
							            	catch(err){
							            		//console.log('message: ' + err.message);
							            	
							            	}
							            		
							            });//end  $(xData.responseXML).SPFilterNode
				    						
				   
							            
							        }//end completefunc: function
							    });//end $().SPServices({
							    
							 student_tracked_classes();
				};//end total_classes



				var student_tracked_classes = function(){
				
				
					var query = "<Query><OrderBy><FieldRef Name='Display_Name' Ascending='True' /></OrderBy></Query>";
				  	var view_fields = "<ViewFields><FieldRef Name=\'ClassID\'/><FieldRef Name=\'Display_Name\'/><FieldRef Name=\'Class\'/><FieldRef Name=\'Class_x0020_Completed\'/><FieldRef Name=\'Next_x0020_Due\'/></ViewFields>";   				  
				    var source_list = "TrackedClasses";
				    var student_id2 = 0;
				        

							    $().SPServices({
					
							        operation: "GetListItems",
							        async: false,
							        listName: source_list,
							        CAMLViewFields: view_fields,
							        CAMLQuery: query,
							        completefunc: function (xData, status) {
							            	//alert(xData.responseXML.xml);
							            
							            	//1. create object to hold student and classes that needs to be taken
				    						
				    						$(xData.responseXML).SPFilterNode("z:row").each(function() {
							            
							            
							            	try{
							            			var class_id = parseInt($(this).attr("ows_ClassID"));
							            			var title = $(this).attr("ows_Display_Name");
							            			var _class = $(this).attr("ows_Class");
							            			var class_complete = $(this).attr("ows_Class_x0020_Completed");
													var next_due = new Date ( $(this).attr("ows_Next_x0020_Due").replace( /(\d{4})-(\d{2})-(\d{2})/, "$2/$3/$1") );
													
													 //new Date(($(this).attr("ows_SampleDate")).replace( /(\d{4})-(\d{2})-(\d{2})/, "$2/$3/$1"));

							            			

							            			
							            			if(typeof title === "string"){
							            			
							            				//split id output off lookup values
							            				var title_split = title.split(";");							            				
							            				student_id = parseInt(title_split[0]);//set field condition 1
							            				

							            				
							            				if(student_id != student_id2){//get student data
							            				
							            					//format student and class from lookup outputs
							            					var title_split2 = title.split("#");
							            					student = title_split2[1];
							            					var class_split = _class.split("#");							            				
							            					_class = class_split[1].trim();
							            					
							            					date_arr = [];
							            					date_arr.push(class_id);
							            					date_arr.push(class_complete);
							            					date_arr.push(next_due);
							            					
							            					
							            					tracked_classes[student] = {};
							            					tracked_classes[student][_class] = date_arr;
							            					
							            					


							            					
															
							            				
							            				}
							            				else{//get class data
							            					
							            					//format class data from lookup outputs
							            					var class_split = _class.split("#");							            				
							            					_class = class_split[1].trim();
							            					
							            					date_arr = [];
							            					date_arr.push(class_id);
							            					date_arr.push(class_complete);
							            					date_arr.push(next_due);

							            					
							            					tracked_classes[student][_class] = date_arr;
							            					
							            					
							            					
							            				}
							            				
							            				student_id2 = parseInt(title_split[0]);//set field conition 2
							            				
							            			}//end if
							            	
							            	}
							            	catch(err){
							            		//console.log(student + ' have no classes here ');
							            		//console.log(err.message);
							            	
							            	}
							            		
							            });//end  $(xData.responseXML).SPFilterNode
				    						
				   
							            
							        }//end completefunc: function
							    });//end $().SPServices({
							    
							   classes_not_enrolled();
								
				
				};//end student_tracked_classes
				
	
	
			var classes_not_enrolled = function(){
			
				try{
								var total_classes = class_arr.sort();
								var sc = 0;//student course count until we add al class id's to tracked casses to 
								
								for(students in tracked_classes){

														//console.log(students);
														
														classes_under_question[students] = {};//set student objects
														classes_not_enrolled_arr = [];//set new property
														classes_due_arr = [];//set new property
														date_due_arr = [];//set new property
														
														
														for(var i = 0, count = total_classes.length; i < count; i++){//total classes
					

																		var class_split = total_classes[i].split(":");
																		var class_list_id = parseInt(class_split[0]);
																		var class_name = class_split[1];
																		//console.log("\t" +class_list_id + " : " +  class_name);//all classes
																		
																		
																		var num_arr = [];
																		
																		for(classes in tracked_classes[students]){	
																				var tracked_class_id = tracked_classes[students][classes][0];
																				num_arr.push(tracked_class_id);
				
									
																		}//end for
																		
																		
																		
																		
																		
																		var num_result =  num_arr.sort().indexOf(class_list_id);//get -1 for classes not enrolled
																		
																		//console.log("\t\t\t" + num_arr.sort() + " : " + num_result);
																		
																		
																		//classes due based on exclusion of data via class list -> classes_not_enrolled property
																		if(num_result === -1 && sc <= 2){
																							  
																		
																			classes_not_enrolled_arr.push(class_name);//push
																			//console.log("\t" + class_name + "count " + sc);
																		
																		}//end if
				
														}//end for
														classes_under_question[students]["classes not enrolled"] = classes_not_enrolled_arr;
				
														sc++;	
								
													
								}//end for
								
				}
				catch(err){
				
					//console.log(err.name + " : " + err.message)
				
				}
				
				
				view();
					
				
			};//end classes_due
			
			
			var view = function(){
			
						$(".table").append("<tr><td>Students</td><td>Classes Not Enrolled</td><td>Classes Due(An Empty Field Means No Classes Due)</td><td>Due Date</td></tr>");


			
				try{
				
				
					var row_id = 0;	
					//iterate classes due
					for(students in tracked_classes){
								
							//console.log(students + " : " + row_id);
							$(".table").append("<tr id="+row_id+"><td class=students>"+students+"</td><td><table class=classes_not_found"+row_id+"></table></td><td><table class=classes_due"+row_id+"></table></td><td><table class=due_date"+row_id+"></table></td></tr>");

										
								for(classes in tracked_classes[students]){						
									var current_date_obj = new Date();
									var current_date = Date.parse(current_date_obj);
									var due_date = tracked_classes[students][classes][2];
									var year = due_date.getFullYear();
									var month = due_date.getMonth();
									var day = due_date.getDay();
									var date_format = month + "/" + day + "/" + year;
									//console.log(date_format);
									
									
									//get classes due
									if(current_date > due_date){
											//console.log("\tClasses Due: " + classes + " : " + due_date);
											$(".classes_due"+row_id+"").append("<tr id="+row_id+"><td>"+classes+"</td></tr>");
											$(".due_date"+row_id+"").append("<tr id="+row_id+"><td>"+date_format+"</td></tr>");

									}							
								}//end for
								
																
								
								//get classes not enrolled in
								for(classes_not_enrolled_in in classes_under_question[students]){										
										var classes_not_enrolled_arr = classes_under_question[students][classes_not_enrolled_in];
												
										for(var i = 0, count = classes_not_enrolled_arr.length; i < count; i++){//get classes not enrolled in
											$(".classes_not_found"+row_id+"").append("<tr id="+row_id+"><td>"+classes_not_enrolled_arr[i]+"</td></tr>");
											//console.log("\t\tClasses Not Enrolled" + classes_not_enrolled_arr[i]);
					
										}
								}//end for
								
								row_id++;
									
					}//end for

				

				
				}
				catch(err){
				
					console.log(err.name + " : " + err.message );
				
				
				}
			
			
			};//end view
				
	    
			   total_classes();//entry point
			   
    
			    
			    
});




			    




