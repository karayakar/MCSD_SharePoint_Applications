<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Rest Client</title>
<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js"></script> 
</head>
<body>

<script type="text/javascript">
    $(document).ready(function () {

        $.ajax({
            url: "http://abcuniversity/_api/Web/Lists",
            type: "GET",
            headers: {
                "ACCEPT": "application/json;odata=verbose"
            },
            success: function (data) {
                //document.getElementById("message").innerText = JSON.stringify(data, null, "\t");
                var results = data["d"]["results"];
                var listTree = document.getElementById("listTree");
                    
                for (var i = 0, length = results.length; i < length; i++) {
                    var result = results[i];
                    console.log(result["Title"] + " " + result["ItemCount"]);
                    var listTitle = result["Title"];
                    var li = document.createElement("li");
                    li.id = listTitle;
                    li.appendChild(document.createTextNode(listTitle));
                    listTree.appendChild(li);
                    getListItems(result["__metadata"]["uri"], li);
                }
            },
            failure: function (data) {
                console.log("got an error");
            }
        });

        function getListItems(listURL, liList) {
            $.ajax({
                url: listURL + "/Items",
                type: "GET",
                headers: {
                    "ACCEPT": "application/json;odata=verbose"
                },
                success: function (data) {
                    var results = data["d"]["results"];
                    console.log(JSON.stringify(results));
                    var ul = document.createElement('ul');

                    for (var i = 0, length = results.length; i < length; i++) {
                        var result = results[i];
                        // console.log(result["Title"]);
                        var li = document.createElement("li");
                        li.appendChild(document.createTextNode(result["Title"]));
                        ul.appendChild(li);

                    }
                    liList.appendChild(ul);
                },
                failure: function (data) {
                    console.log("got an error getting items");
                }
            });
        }
    });
</script>    <form id="form1" runat="server">
    
         <div id="message">
            </div>
    <ul id="listTree">
    </ul>
    </form>
</body>
</html>
