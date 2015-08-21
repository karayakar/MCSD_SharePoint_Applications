/*Parent Child OIP Script, Beta Version*/


init = function(){

    var get_parents = function(){
    			//get url
				var SLASH = "/";
				var test = new String(window.location);
				var tp1 = test.indexOf("sites");
				var tp1 = test.substring(0, tp1);
				var tp2 = tp1 + "sites" + SLASH + "oip";
				
							$().SPServices({
														operation: "GetListItems",
														async: false,
														listName: 'Calendar',
														webURL: tp2,
														CAMLViewFields: "<ViewFields properties='true'><FieldRef Name='Title' /><FieldRef Name='LI' /></ViewFields>",
														CAMLQuery: "<Query><OrderBy><FieldRef Name='Title' Ascending='True'/></OrderBy></Query>",
														completefunc: function (xData, status) {
											            
														//alert(xData.responseXML.xml);//debug xml
																			
																$(xData.responseXML).SPFilterNode("z:row").each(function() {
																		var text_field = $('#ctl00_m_g_a2971a75_99c6_43fa_b9ea_6dcbb886d4ed_ctl00_ctl05_ctl00_ctl00_ctl00_ctl04_ctl00_ctl00_TextField');
																		var option = $( "#ctl00_m_g_a2971a75_99c6_43fa_b9ea_6dcbb886d4ed_ctl00_ctl05_ctl01_ctl00_ctl00_ctl04_ctl00_Lookup option" );
																		var title = $(this).attr("ows_Title");
																		var li = $(this).attr("ows_LI");
																		var dom_title = text_field.val();
																		
																		if(li !== undefined){//get parents
																			//alert('parents: ' + title);
																			
																			if(dom_title != title){
																				//alert(dom_title + ' is a parent');
																				
																				
																				var iterate = option.each(function(){//compare parents with children
																					var options = $(this).text();
																					if(title === options){//match child from list child in dom
																						//alert(options + ' is a child ');
																						$(this).remove();//remove child <option>
																					
																					}
																		
																				});	
																			}//end if
																		}//end if
																});
																            	  
											        	}//end completefunc()
											       
					    				});//end getlistitems	
					    				
    		return true;
    
    }//end get_items()
    
    var calendar_obj = get_parents();
       
    
}//end init


$( window ).load(function() {//load

	

 	SP.SOD.executeFunc('sp.js', 'SP.ClientContext',init);
 	
 	
 	
});


