#SharePoint Dojo

Shaun Lewis(aka budostylz): SharePoint 2010/2013 Applications/Solutions  Developer

#SharePoint Development Walkthroughs

https://msdn.microsoft.com/en-us/library/ee290858.aspx

#Client Object Model (sp.js Namespace)

https://msdn.microsoft.com/en-us/library/ee557057

#SharePoint 2013 .NET Server, CSOM, JSOM, and REST API index

https://msdn.microsoft.com/en-us/library/office/dn268594.aspx

#Server Object Model Namespaces

https://msdn.microsoft.com/en-us/library/office/ms453225%28v=office.14%29.aspx

#SPServices

http://spservices.codeplex.com/

#JavaScript Beautifier

http://jsbeautifier.org/

#JavaScript Minifier

http://javascript-minifier.com/

#HTML Encoding Symbols(debug urls)

http://www.w3schools.com/tags/ref_urlencode.asp

#SPBuiltInFieldId fields

https://msdn.microsoft.com/EN-US/library/office/microsoft.sharepoint.spbuiltinfieldid_fields.aspx

#Frodes awesome list of SharePoint Column Field IDs

http://aarebrot.net/blog/2008/07/frodes-awesome-list-of-sharepoint-column-field-ids-for-sharepoint-2007/?tmpl=component&print=1&page=

#wsp Deployment Analysis Tools

http://www.telerik.com/products/decompiler.aspx

http://spdisposecheckstatic.codeplex.com/

http://www.spcaf.com/partners/offerings/microsoft/

#Suffixes

##Users and Permissions:

  People and Groups: _layouts/people.aspx
  
  Site Collection Admins: _layouts/mngsiteadmin.aspx 
  
  Master Pages: _Layouts/ChangeSiteMasterPage.aspx 
  
##Look and Feel:

  Title, Description, and Icon: _layouts/prjsetng.aspx 
  Navigation: _layouts/AreaNavigationSettings.aspx 
  Page Layout and Site Templates: _Layouts/AreaTemplateSettings.aspx 
  Welcome Page: _Layouts/AreaWelcomePage.aspx 
  Tree View: _layouts/navoptions.aspx 
  Top Navigation Bar: _layouts/topnav.aspx 
  Site Theme: _layouts/themeweb.aspx 
  Reset to Site Definition: _layouts/reghost.aspx 
  Searchable Columns: _Layouts/NoCrawlSettings.aspx 
  Site Content Types: _layouts/mngctype.aspx 
  
##Galleries 
Site Columns: _layouts/mngfield.aspx 
Site Templates: _catalogs/wt/Forms/Common.aspx 
List Templates: _catalogs/lt/Forms/AllItems.aspx 
Web Parts: _catalogs/wp/Forms/AllItems.aspx 
Workflows: _layouts/wrkmng.aspx 
Master Pages and Page Layouts: _catalogs/masterpage/Forms/AllItems.aspx 
Regional Settings: _layouts/regionalsetng.aspx 
  
##Site Administration 
Site Libraries and Lists: _layouts/mcontent.aspx 
Site Usage Report: _layouts/usageDetails.aspx 
User Alerts: _layouts/sitesubs.aspx 
RSS: _layouts/siterss.aspx 
Search Visibility: _layouts/srchvis.aspx 
Sites and Workspaces: _layouts/mngsubwebs.aspx 
Site Features: _layouts/ManageFeatures.aspx 
Delete This Site: _layouts/deleteweb.aspx 
Site Output Cache: _Layouts/areacachesettings.aspx 
Content and Structure: _Layouts/sitemanager.aspx 
Content and Structure Logs: _Layouts/SiteManager.aspx?lro=all 
Search Settings: _layouts/enhancedSearch.aspx 
  
##Site Collection Administration 
Search Scopes: _layouts/viewscopes.aspx?mode=site 
Search Keywords: _layouts/listkeywords.aspx 
Recycle Bin: _layouts/AdminRecycleBin.aspx 
Site Collection Features: _layouts/ManageFeatures.aspx?Scope=Site 
Site Hierarchy: _layouts/vsubwebs.aspx 
Portal Site Connection: _layouts/portal.aspx 
Site Collection Audit Settings: _layouts/AuditSettings.aspx 
Site Collection Policies: _layouts/Policylist.aspx 
Site Collection Cache Profiles: Cache%20Profiles/AllItems.aspx 
Site Collection Output Cache: _Layouts/sitecachesettings.aspx 
Site Collection Object Cache: _Layouts/objectcachesettings.aspx 
Variations: _Layouts/VariationSettings.aspx 
Variation Labels: _Layouts/VariationLabels.aspx 
Translatable Columns: _Layouts/TranslatableSettings.aspx 
Variation Logs: _Layouts/VariationLogs.aspx 
Site Settings: _layouts/settings.aspx 
  
##Function Add to the URL Notes 
Add Web Parts Pane ?ToolPaneView=2 Add to the end of the page URL; will only
work if the page is already checked out 
Create [area]/_layouts/spscreate.aspx   
Create /_layouts/create.aspx   
Create list in a different portal area /_layouts/new.aspx?
NewPageFilename=YourTemplateName.stp&
ListTemplate=100&
ListBaseType=0 When you save a template in a portal area and try to create a
new list in a different portal area, the template will not show on the
Create page. Use this URL to force it to show. 
Documents and Lists /_layouts/viewlsts.aspx   
List Template Gallery /_catalogs/lt   
Manage Audiences /_layouts/Audience_Main.aspx   
Manage Cross Site Groups /_layouts/mygrps.aspx   
Manage List Template Gallery /_catalogs/lt/Forms/AllItems.aspx   
Manage My Alerts /_layouts/MySubs.aspx   
Manage People /_layouts/people.aspx   
Manage Site Collection Administrators /_layouts/mngsiteadmin.aspx   
Manage Site Collection Users /_layouts/siteusrs.aspx To access you must be
an admin on the server or a site collection admin for the site. 
Manage Site Groups /_layouts/role.aspx   
Manage Site Template Gallery /_catalogs/wt/Forms/AllItems.aspx   
Manage Site Template Gallery /_catalogs/wt/Forms/Common.aspx   
Manage Sites and Workspaces /_layouts/mngsubwebs.aspx   
Manage User Alerts /_layouts/AlertsAdmin.aspx   
Manage User Alerts /_layouts/SiteSubs.aspx   
Manage User Permissions /_layouts/user.aspx   
Manage Web Part Gallery /_catalogs/wp/Forms/AllItems.aspx   
Master Page Gallery /_catalogs/masterpage Also includes Page Layouts 
Modify Navigation /_layouts/AreaNavigationSettings.aspx   
Recycle Bin /_layouts/AdminRecycleBin.aspx   
Save as site template /_layouts/savetmpl.aspx   
Site Column Gallery /_layouts/mngfield.aspx   
Site Content and Structure Manager /_layouts/sitemanager.aspx   
Site Content Types /_layouts/mngctype.aspx   
Site Settings /_layouts/settings.aspx   
Site Settings /_layouts/default.aspx   
Site Template Gallery /_catalogs/wt   
Site Theme /_layouts/themeweb.aspx   
Site usage details /_layouts/UsageDetails.aspx   
Site Usage Summary /_layouts/SpUsageWeb.aspx   
Site Usage Summary /_layouts/Usage.aspx   
Sites Registry /SiteDirectory/Lists/Sites/Summary.aspx   
Top-level Site Administration /_layouts/webadmin.aspx   
User Information /_layouts/userinfo.aspx   
Web Part Gallery /_catalogs/wp   
Web Part Page Maintenance ?contents=1 Add to the end of the page URL 
Workflows /_layouts/wrkmng.aspx   


#Chill Out ----- Concentration Musica

http://www.dancetrippin.tv/
