Update-SPSolution -Identity "anywsp.wsp" -LiteralPath "C\AbsolutePaths"

$featureName="FeatureName"
$latestVersion=(get-spfeature|where{$_.DisplayName -eq $featureName}).Version
$web=get-spweb http://budostylz.sharepoint.com
$feature=$web.Features|where {$_.Definition.DisplayName - eq $featureName}
$currentVersion = $feature.Version
write-host "Current Version: $currentVersion, Latest Version: $latestVersion"

$web=get-spweb http://budostylz.sharepoint.com
$feature=$web.Features|where {$_.Definition.DisplayName - eq $featureName}
$feature.Upgrade($false)
