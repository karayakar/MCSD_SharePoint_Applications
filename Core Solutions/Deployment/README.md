# PowerShell Deployment

	1. (Visual Studio)Build -> Configuration Manager -> Active Solution Configuration -> Release
	2. (Visual Studio)Click Build -> Publish
	3. Use .wsp for next steps in PowerShell

#PowerShell Commands for Deployment

Add-SPSolution

https://technet.microsoft.com/en-us/library/ff607552.aspx

Install-SPSolution

https://technet.microsoft.com/en-us/library/Ff607534.aspx

Uninstall-SPSolution

https://technet.microsoft.com/en-us/library/ff607873.aspx

Remove-SPSolution

https://technet.microsoft.com/en-us/library/ff607748.aspx

Get-SPSolution

https://technet.microsoft.com/en-us/library/ff607754.aspx


#Deployment Process

https://msdn.microsoft.com/en-us/library/aa544500%28office.14%29.aspx

#Deploy solution packages (SharePoint Server 2010)

https://technet.microsoft.com/en-us/library/Cc262995%28v=Office.14%29.aspx

#Stsadm Deployment Steps
	
	1. Add the solution
	stsadm -o addsolution -filename {WSPFILENAME}
	2. Deploy the solution
	stsadm -o deploysolution -name {WSPFILENAME} -url {SITEURL}
	3. Install the feature
	stsadm -o installfeature -filename {FeatureFolder}\feature.xml
	4. Activate the feature
	stsadm -o activatefeature -id {FEATUREID} -url {SITEURL} -force
	5. Deactive the feature
	Stsadm.exe -o deactivatefeature -filename “C:\Program Files\Common Files\Microsoft Shared\web server extensions\12\TEMPLATE\FEATURES\ViewFormPagesLockDown\feature.xml” -ur http://servername/
	6.Uninstall the feature
	stsadm -o uninstallfeature -filename
	7.Retract Solution
	stsadm -o retractsolution

	-name

	[-url]

	[-allcontenturls]

	[-time]

	[-immediate]
	8.Delete Solution
	stsadm -o deletesolution

	-name 





