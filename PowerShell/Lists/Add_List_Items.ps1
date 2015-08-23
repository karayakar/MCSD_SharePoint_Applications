$webURL = "http://abcuniversity.com"
$listName = "LargeList"

$web = Get-SPWeb $webUrl
$list = $web.Lists[$listName]

for($i=1; $i -le 50000; $i++)
{
    $newItem = $list.Items.Add()
    $title = ""
    for($j=0; $j -le 5; $j++)
    {
        $randomChar = [Char](Get-Random -Minimum 65 -Maximum 90)
        $title += $randomChar

    }
    $newItem["Title"] = $title
    $newItem["Description"] = "Item number " + $i
    $newItem.Update()
}