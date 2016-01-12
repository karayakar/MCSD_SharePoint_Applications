//new list items
$().SPServices({
								        operation: "UpdateListItems",
								        async: false,
								        batchCmd: "New",
								        listName: source_list,
								        valuepairs: [["Key", Value]],
							        	completefunc: function(xData, Status) {
							          		//console.log("completed");
							        	}
	});


//update list items
$().SPServices({
								        operation: "UpdateListItems",
								        ID: 1,
								        async: false,
								        batchCmd: "Update",
								        listName: source_list,
								        valuepairs: [["Key", Value]],
							        	completefunc: function(xData, Status) {
							          		//console.log("completed");
							        	}
	});
	
	//delete list items
	$().SPServices({
								        operation: "UpdateListItems",
								        ID: 1,
								        async: false,
								        batchCmd: "Delete",
								        listName: source_list,
								        valuepairs: [["Key", Value]],
							        	completefunc: function(xData, Status) {
							          		//console.log("completed");
							        	}
	});
