Uninstall-SPSolution -Identity "anywsp.wsp" -Confirm:$false
Remove-SPSolution -Identity "anywsp.wsp" -Confirm:$false

Add-SPSolution -LiteralPath "C:\absolutePath\toanywsp.wsp"
Install-SPSolution -Identity "anywsp.wsp" -GACDeployment

Enable-SPFeature -Url http://budostylz.sharepoint.com
Enable-SPFeature -Url http://budostylz.sharepoint.com

Update-SPSolution -Identity "anywsp.wsp" -LiteralPath "C:\absolutePath\anywsp.wsp"
