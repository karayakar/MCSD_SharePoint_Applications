
init = function(){
	
	
		
	
	function getParentList(){
				//alert($('#ctl00_m_g_4b5062cb_cb3e_405b_8caa_38fefbdb3178_ctl00_ctl05_ctl02_ctl00_ctl00_ctl04_ctl00_DropDownChoice').text());//parent choice
				
				//var parent = $('#ctl00_m_g_4b5062cb_cb3e_405b_8caa_38fefbdb3178_ctl00_ctl05_ctl02_ctl00_ctl00_ctl04_ctl00_DropDownChoice'); //parent text field
				//var proponent = $('#ctl00_m_g_4b5062cb_cb3e_405b_8caa_38fefbdb3178_ctl00_ctl05_ctl03_ctl00_ctl00_ctl04_ctl00_DropDownChoice');//proponent text field
				parent_items = {};	
				proponent_items = {};	
				cas_items = {};
					
				
				var SLASH = "/";
				var query = "<Query><OrderBy><FieldRef Name='Title' Ascending='True'/></OrderBy></Query>";
				 
				
				//url
				//test = new String(window.location);
			   // tp1 = test.indexOf("sites");
			    //var tp1 = test.substring(0, tp1);
			   // var tp2 = tp1 + "sites" + SLASH + "oip";
				
					
				
				 url = "/sites/OIP";
			     clientContext = new SP.ClientContext(url);//get site context
			     var oList = clientContext.get_web().get_lists().getByTitle("Parent");//get list
			     var camlQuery = new SP.CamlQuery();//get query  
				 camlQuery.set_viewXml('<Query><Where><FieldRef Name=\'Title\'/><FieldRef Name=\'Parent_ID\'/></Where></Query>'); //create query    
			     this.collListItem = oList.getItems(camlQuery);//apply query to list items
			     clientContext.load(collListItem);//load list in current context
			     
			     clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));   
			     //alert(true) ;  
			     //execute either onQuerySucceeded or onQueryFailed asynchronously on server
      
        }
        
        var parent_list = getParentList();  
      
      
};



function onQuerySucceeded(sender, args) {

	
	listItemInfo = '';
	listItemEnumerator = collListItem.getEnumerator();
	parentArr = [];
	parentArr2 = [];
	
	while (listItemEnumerator.moveNext()) {//get items
        var oListItem = listItemEnumerator.get_current();
        parentArr.push(oListItem.get_item('Title'));
        parentArr2.push(oListItem.get_item('Parent_ID'));
        
        parent_items = {
        	title: parentArr,
        	id:   parentArr2
        };
        
      
        
       var proponent_list_items = getProponentList();
        	
                    
       
    }

		
	
	
	function getProponentList(){
		
		 var oList = clientContext.get_web().get_lists().getByTitle("Proponent");//get list
		 var camlQuery = new SP.CamlQuery();//get query 
		 camlQuery.set_viewXml('<Query><Where><FieldRef Name=\'Title\'/><FieldRef Name=\'Proponent_ID\'/></Where></Query>'); //create query    
		 this.collListItem = oList.getItems(camlQuery);//apply query to list items
		 clientContext.load(collListItem);//load list in current context

		 clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded2), Function.createDelegate(this, this.onQueryFailed2));   

		
			
		
		
		
	
	}
		
	
}


function onQuerySucceeded2(sender, args) {
     
    listItemInfo2 = '';
	listItemEnumerator2 = collListItem.getEnumerator();
	proponentArr = [];
	proponentArr2 = [];
	
	
	while (listItemEnumerator2.moveNext()) {//get items
	
		
        var oListItem2 = listItemEnumerator2.get_current();
        proponentArr.push(oListItem2.get_item('Title'));
        proponentArr2.push(oListItem2.get_item('Proponent_ID'));
        
        proponent_items = {
        	title: proponentArr,
        	id:   proponentArr2
        };

        
    }
		
	
	
	
	function consolidatedAccreditationSchedule(){
		
			
	
		
		var oList = clientContext.get_web().get_lists().getByTitle("Calendar");//get list
		
		var myField = SPUtility.GetSPField('Prop');
		alert(myField);
		//fieldCollection = oList.get_fields();//get fields
		//this.oneField = fieldCollection.getByInternalNameOrTitle("TestChoice");//get field
		//this.oneField.set_description('New Description');
		
		
		
		//SPUtility.GetSPField('TestChoice').SetValue('Hello world!')
		
		
		this.oneField.update();
		
		
		
		
		
		
		alert(parent_items.title);
		alert(proponent_items.title);
		alert(this.oneField)
		
		
		
        

       // clientContext.load(this.fieldCollection);
         
	
		//alert(true);
		
		
		//var camlQuery = new SP.CamlQuery();//get query 
		//camlQuery.set_viewXml('<Query><Where><FieldRef Name=\'Parent\'/><FieldRef Name=\'Proponents\'/></Where></Query>'); //create query    
		//this.collListItem = oList.getItems(camlQuery);//apply query to list items
		//clientContext.load(collListItem);//load list in current context
		
		//var priorityField = context.castTo(list.get_fields().getByInternalNameOrTitle("Parent"),SP.FieldChoice);
		
		
		//clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded3), Function.createDelegate(this, this.onQueryFailed3));   
		
	
		
		
		

	} 
	
	var consolidated_accreditation_schedule = consolidatedAccreditationSchedule();
	
	
     
}


function onQuerySucceeded3(sender, args) {

	alert("success");

	//FieldChoice myChoicesfield = context.CastTo<FieldChoice>list.Fields["Parent"];
	//var choices = priorityField.get_choices();
    //alert(choices);



	listItemInfo3 = '';
	listItemEnumerator3 = collListItem.getEnumerator();
	casArr = [];
	casArr2 = [];

	while (listItemEnumerator3.moveNext()) {//get items
	
		
        var oListItem3 = listItemEnumerator3.get_current();
        casArr.push(oListItem3.get_item('Parent'));
        casArr2.push(oListItem3.get_item('Proponent'));
        
        //alert(typeof oListItem3.get_item('Parent'));
        
        cas_items = {
        	title: casArr,
        	id:   casArr2
        };

        
    }

		var user_select = $( '#ctl00_m_g_4b5062cb_cb3e_405b_8caa_38fefbdb3178_ctl00_ctl05_ctl02_ctl00_ctl00_ctl04_ctl00_DropDownChoice' ).click( function() {
  			
  			
  			
  			var index = 0;
  			alert("parent id" + parent_items.title);
			//alert("proponent id: "+ proponent_items.title);
			//alert("proponent id: "+ cas_items.title);
			
			
			//access parent
			for(prop in parent_items.title){
				
				alert(typeof parent_items.title[index]);
				
				index++;
			
			}
			
		});
		
	
		
		
	
	
}

function onQueryFailed(sender, args) {

	alert("failed")
	
}

function onQueryFailed2(sender, args) {
	alert("Proponent Failed")
		

}



function onQueryFailed3(sender, args) {
	alert("Proponent Failed")
		

}



$( window ).load(function() {


 	SP.SOD.executeFunc('sp.js', 'SP.ClientContext',init);
 	
 	alert(true);
 	
 	  /*
 	  
 	  SLASH = "/";
 	  current = new String(window.location);
      tp1 = current.indexOf("sites");
      tp1 = current.substring(0, tp1);
      tp2 = tp1 + "sites" + SLASH + "oip";
	  caml = "<Query><OrderBy><FieldRef Name='Title' Ascending='True'/><FieldRef Name='MutiLine' Ascending='True'/></OrderBy></Query>";
	  
	  */
 	
 	
	
 	
 	
 	
 	
 	
});


/*
	
	while(listItemEnumerator.moveNext() ){
		
	   var objListItem = listItemEnumerator.get_current();
       var clientContext = new SP.ClientContext(url);
       var oList = clientContext.get_web().get_lists().getByTitle('Consolidated Accreditation Schedule');
        
       //var itemCreateInfo = new SP.ListItemCreationInformation();
       //this.oListItem = oList.addItem(itemCreateInfo);
       //oListItem.set_item('Title',objListItem.get_item('Title'));
       //oListItem.set_item('MutiLine',objListItem.get_item('MutiLine'));
       
             
       
       
       //oListItem.update();
       //clientContext.load(oListItem);
       //clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceededFinal), Function.createDelegate(this, this.onQueryFailed));
      
		//alert("sweet");		
	}
	
	*/

