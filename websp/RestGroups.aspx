<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Groups with users with pictures</title>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js"></script> 

</head>
<body>

    <script type="text/javascript">
        $(document).ready(function () {

            $.ajax({
                url: "http://abcuniversity/_api/Web/SiteGroups",
                type: "GET",
                headers: {
                    "ACCEPT": "application/json;odata=verbose"
                },
                success: function (data) {
                    //document.getElementById("message").innerText = JSON.stringify(data, null, "\t");
                    var results = data["d"]["results"];
                    var groupTree = document.getElementById("groupTree");
                    
                    for (var i = 0, length = results.length; i < length; i++) {
                        var result = results[i];
                        console.log(result["Title"]);
                        var groupTitle = result["Title"];
                        var li = document.createElement("li");
                        li.id = groupTitle;
                        li.appendChild(document.createTextNode(groupTitle));
                        groupTree.appendChild(li);
                        console.log(result["__metadata"]["uri"]);
                        getUsers(result["__metadata"]["uri"], li);
                    }
                },
                failure: function (data) {
                    console.log("got an error");
                }
            });

            function getUsers(usersURL, liList) {
                $.ajax({
                    url: usersURL + "/Users",
                    type: "GET",
                    headers: {
                        "ACCEPT": "application/json;odata=verbose"
                    },
                    success: function (data) {
                        var results = data["d"]["results"];
                        //console.log(JSON.stringify(results, null, "\t"));
                        var ul = document.createElement('ul');
                        if (results != null) {
                            for (var i = 0, length = results.length; i < length; i++) {
                                var result = results[i];
                                // console.log(result["Title"]);

                                var userName = result["LoginName"];
                                //to strip out claims information
                                userName = userName.substring(userName.indexOf('|') + 1);

                                var li = document.createElement("li");
                                li.appendChild(document.createTextNode(result["Title"]));
                                ul.appendChild(li);

                                var profileURL = "http://abcuniversity/_api/SP.UserProfiles.PeopleManager/GetUserProfilePropertyFor(accountName=@v,propertyName='PictureURL')?@v='" + userName + "'";

                                console.log('profile url' + profileURL);
                                $.ajax({
                                    "li": li,
                                    url: profileURL,
                                    type: "GET",
                                    headers: {
                                        "ACCEPT": "application/json;odata=verbose"
                                    },
                                    success: function (data) {
                                        console.log(JSON.stringify(data, null, "\t"));
                                        if (data["d"]["GetUserProfilePropertyFor"].length > 0) {
                                            var img = document.createElement("img");
                                            this.li.insertBefore(img, this.li.firstChild);
                                            img.src = data["d"]["GetUserProfilePropertyFor"];
                                        }
                                    },
                                    failure: function (data) {
                                        console.log("got an error getting a picture");
                                    }
                                });

                            }
                            liList.appendChild(ul);
                        }
                    },
                    failure: function (data) {
                        console.log("got an error getting users");
                    }
                });
            }

        
        });
</script>    
         <div id="jsonPanel">
            </div>
    <ul id="groupTree">
    </ul>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
