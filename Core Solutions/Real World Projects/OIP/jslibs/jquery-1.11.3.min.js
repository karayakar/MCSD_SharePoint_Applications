/*

moveItems = function(){
	
	 url = "/sites/OIP";//get url     
	
     var clientContext = new SP.ClientContext(url);//get site context
     var oList = clientContext.get_web().get_lists().getByTitle("Test(UI_List)");//get list
     var camlQuery = new SP.CamlQuery();//get query  
	 camlQuery.set_viewXml('<Query><Where><FieldRef Name=\'Title\'/><FieldRef Name=\'MutiLine\'/></Where></Query>'); //create query    
     this.collListItem = oList.getItems(camlQuery);//apply query to list items
     clientContext.load(collListItem);//load list in current context
     clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));      
      //execute either onQuerySucceeded or onQueryFailed asynchronously on server
};

function onQuerySucceeded(sender, args) {

	var listItemInfo = '';
	var listItemEnumerator = collListItem.getEnumerator();
	
	while(listItemEnumerator.moveNext() ){
		
	   var objListItem = listItemEnumerator.get_current();
       var clientContext = new SP.ClientContext(url);
       var oList = clientContext.get_web().get_lists().getByTitle('Test(Learning Institution)'); 
       var itemCreateInfo = new SP.ListItemCreationInformation();
       this.oListItem = oList.addItem(itemCreateInfo);
       oListItem.set_item('Title',objListItem.get_item('Title'));
       oListItem.set_item('MutiLine',objListItem.get_item('MutiLine'));
       
       oListItem.update();
       clientContext.load(oListItem);
       clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceededFinal), Function.createDelegate(this, this.onQueryFailed));
      
		//alert("sweet");		
	}

}

function onQueryFailed(sender, args) {

	alert("query failed");

}

function onQuerySucceededFinal(sender, args) {
     alert("Succeeded");
     
}


$( window ).load(function() {
 	SP.SOD.executeFunc('sp.js', 'SP.ClientContext', moveItems);
});


*/