Add-SPSolution -LiteralPath "C:\solutionsFolder\appendNewVersionNameHere.wsp"
Install-SPSolution -Identity "solution.wsp" -GACDeployment
#check timer job /_admin/ServiceRunningJobs.aspx

Uninstall-SPSolution -Identity "solution.wsp" -Confirm:$false
Remove-SPSOlution -Identity "solution.wsp" -Confirm:$false