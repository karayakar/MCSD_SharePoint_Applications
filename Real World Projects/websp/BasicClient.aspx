<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Javascript client</title>

</head>
<body>
<script 
    src="//ajax.aspnetcdn.com/ajax/4.0/1/MicrosoftAjax.js" 
    type="text/javascript">
</script>
<script 
    type="text/javascript" 
    src="/_layouts/15/sp.runtime.js">
</script>
<script 
    type="text/javascript" 
    src="/_layouts/15/sp.js">
</script>
    <script type="text/javascript">

    //this examples works best in the Courses site with Course Directory list

    var collList;
    var clientContext;

    retrieveWebSiteProperties();
    
    function retrieveWebSiteProperties() { 
        clientContext = new SP.ClientContext.get_current();

        this.oWebsite = clientContext.get_web();
        clientContext.load(this.oWebsite, 'Title', 'Created');

        collList = oWebsite.get_lists();
        clientContext.load(collList, 'Include(Title, Id)');

        clientContext.executeQueryAsync(
            Function.createDelegate(this, this.onQuerySucceeded),
            Function.createDelegate(this, this.onQueryFailed)
        );
    }

    function onQuerySucceeded(sender, args) {
        var message = 'Title: ' + this.oWebsite.get_title() +
            ' Created: ' + this.oWebsite.get_created();

        document.getElementById("message").innerText = message;

        //display lists
        var listEnumerator = collList.getEnumerator();
        var listTree = document.getElementById("listTree");
        while (listEnumerator.moveNext()) {
            var oList = listEnumerator.get_current();
            var listTitle = oList.get_title();
            var li = document.createElement("li");
            li.id = listTitle;
            li.appendChild(document.createTextNode(listTitle));
            listTree.appendChild(li);
            if (listTitle == "Course Directory")
            {
                getListItems();
            }
        }
    }

    function getListItems()
    {
        //alert('getting list items');
        var oList = clientContext.get_web().get_lists().getByTitle('Course Directory');

        var camlQuery = new SP.CamlQuery();
        camlQuery.set_viewXml(
            '<View><Query><Where><Geq><FieldRef Name=\'ID\'/>' +
            '<Value Type=\'Number\'>1</Value></Geq></Where></Query>' +
            '<RowLimit>25</RowLimit></View>'
        );
        this.collListItem = oList.getItems(camlQuery);

        clientContext.load(collListItem);
        clientContext.executeQueryAsync(
            Function.createDelegate(this, this.onItemsGetQuerySucceeded),
            Function.createDelegate(this, this.onQueryFailed)
        );

    }

    function onQueryFailed(sender, args) {
        console.log('Request failed. ' + args.get_message() +
            '\n' + args.get_stackTrace());
    }


    function createListItem() {

        var oList = clientContext.get_web().get_lists().getByTitle('Course Directory');

        var itemCreateInfo = new SP.ListItemCreationInformation();
        this.oListItem = oList.addItem(itemCreateInfo);
        oListItem.set_item('Title', document.getElementById("itemTitle").value);
        oListItem.set_item('Description', 'advanced chemistry lab');
        oListItem.set_item('Department', 'Chemistry');
        oListItem.set_item('Start_x0020_Date', '4/15/2013');
        oListItem.set_item('End_x0020_Date', '4/30/2013');
        oListItem.update();

        clientContext.load(oListItem);
        clientContext.executeQueryAsync(
            Function.createDelegate(this, this.onItemCreateQuerySucceeded),
            Function.createDelegate(this, this.onQueryFailed)
        );
    }


    function onItemsGetQuerySucceeded() {
        var listItemEnumerator = collListItem.getEnumerator();

        var cl = document.getElementById("Course Directory");
        while (cl.childNodes.length > 0)
        {
            cl.removeChild(cl.childNodes[0]);

        }
        cl.textContent = cl.id;
        var ul = document.createElement("ul");;
        while (listItemEnumerator.moveNext()) {
            var oListItem = listItemEnumerator.get_current();
            var li = document.createElement("li");
            li.appendChild(document.createTextNode("Title:" + oListItem.get_item('Title') + " Department: " + oListItem.get_item('Department')));
            ul.appendChild(li);
        }
        cl.appendChild(ul);
        var div = document.createElement("div");
        div.innerHTML = document.getElementById("addItemPanel").innerHTML;
        cl.appendChild(div);
    }

    function onItemCreateQuerySucceeded() {
        //alert('Item created: ' + oListItem.get_id());
        getListItems();
    }

</script>

    <form id="form1" runat="server">
    <div id="message">
    </div>
    <ul id="listTree">
    </ul>
   
    <div id="addItemPanel" style='display:none'>     
    Item Title: <input type="text" name="itemTitle" title="Item Title" id="itemTitle"/>
    <a href="javascript:createListItem()">Create List Item</a>
    </div>
    </form>
</body>
</html>
