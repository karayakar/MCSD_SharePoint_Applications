Add-SPSolution -LiteralPath "C:\solutionsFolder\solution.wsp"
Install-SPSolution -Idenity "solution.wsp" -GACDeployment
#check timer job /_admin/ServiceRunningJobs.aspx

Uninstall-SPSolution -Identity "solution.wsp" -Confirm:$false
Remove-SPSOlution -Identity "solution.wsp" -Confirm:$false