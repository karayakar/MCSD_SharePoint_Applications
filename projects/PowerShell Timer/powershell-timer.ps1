cls

$array = @();
$today = Get-Date

$web = Get-SPWeb http://intranet.contoso.com
$list = $web.Lists["Tasks"]

$obj = $list.Items | foreach-object{$_["DueDate"]}

$array += $obj





$today.CompareTo($array[2])


#$array[0] = [System.DateTime]::$array[0].AddDays(-2);


#$today= [System.DateTime]::$array[0].now #Get Days