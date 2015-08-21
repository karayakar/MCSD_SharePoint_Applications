moveItems = function(){
	
	alert('in again');
	 url = "/sites/tec/omms/";//get url     
	
     var clientContext = new SP.ClientContext(url);//get site context
     alert(clientContext.get_url());
     var oList = clientContext.get_web().get_lists().getByTitle("59th Ordnance Brigade Calendar");//get list
     alert(oList);
     var camlQuery = new SP.CamlQuery();//get query  
	 camlQuery.set_viewXml('<Query><Where><FieldRef Name=\'Title\'/><FieldRef Name=\'Location\'/><FieldRef Name=\'EventDate\'/><FieldRef Name=\'EndDate\'/><FieldRef Name=\'fAllDayEvent\'/><FieldRef Name=\'Created\'/><FieldRef Name=\'Author\'/></Where></Query>'); //create query    
     this.collListItem = oList.getItems(camlQuery);//apply query to list items
     clientContext.load(collListItem);//load list in current context
     clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));      
      //execute either onQuerySucceeded or onQueryFailed asynchronously on server
};

function onQuerySucceeded(sender, args) {

	alert('success');
	var listItemInfo = '';
	var listItemEnumerator = collListItem.getEnumerator();
	
	while(listItemEnumerator.moveNext() ){
		
	   var objListItem = listItemEnumerator.get_current();
       var clientContext = new SP.ClientContext(url);
       var oList = clientContext.get_web().get_lists().getByTitle('Calendar'); 
       var itemCreateInfo = new SP.ListItemCreationInformation();
       this.oListItem = oList.addItem(itemCreateInfo);
       oListItem.set_item('Title',objListItem.get_item('Title'));
       oListItem.set_item('Location',objListItem.get_item('Location'));
       oListItem.set_item('EventDate',objListItem.get_item('EventDate'));
       oListItem.set_item('EndDate',objListItem.get_item('EndDate'));
       oListItem.set_item('fAllDayEvent',objListItem.get_item('fAllDayEvent'));

       
       
       oListItem.update();
       clientContext.load(oListItem);
       clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceededFinal), Function.createDelegate(this, this.onQueryFailedFinal));
      
			
	}
	
	alert('compete');

}

function onQueryFailed(sender, args) {

	alert("query failed");

}

function onQueryFailedFinal(sender, args) {

	alert("query failed");

}

function onQuerySucceededFinal(sender, args) {
     //alert("Succeeded");
     //alert("sweet");	
     
}




//ExecuteOrDelayUntilScriptLoaded(moveItems, "SP.js");
	
	$( window ).load(function() {
	 	SP.SOD.executeFunc('sp.js', 'SP.ClientContext', moveItems);
	});
	
	

	




