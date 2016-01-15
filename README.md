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

#Microsoft.SharePoint.WebControls Namespace

https://msdn.microsoft.com/en-us/library/office/Microsoft.SharePoint.WebControls%28v=office.14%29.aspx

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

#Convert .wmv to .mov Files to Run via HTML5 

  1. Convert .wmv to .mov files at http://www.zamzar.com/
  2. Apply HTML5 Video element.
  3. Most of Object element properties are obsolete.

#Suffixes

##Users and Permissions:

  1. People and Groups: _layouts/people.aspx
  2. Site Collection Admins: _layouts/mngsiteadmin.aspx 
  3. Master Pages: _Layouts/ChangeSiteMasterPage.aspx 
  
##Look and Feel:

  1. Title, Description, and Icon: _layouts/prjsetng.aspx 
  2. Navigation: _layouts/AreaNavigationSettings.aspx 
  3. Page Layout and Site Templates: _Layouts/AreaTemplateSettings.aspx 
  4. Welcome Page: _Layouts/AreaWelcomePage.aspx 
  5. Tree View: _layouts/navoptions.aspx 
  6. Top Navigation Bar: _layouts/topnav.aspx 
  7. Site Theme: _layouts/themeweb.aspx 
  8. Reset to Site Definition: _layouts/reghost.aspx 
  9. Searchable Columns: _Layouts/NoCrawlSettings.aspx 
  10. Site Content Types: _layouts/mngctype.aspx 
  
##Galleries 

  1. Site Columns: _layouts/mngfield.aspx 
  2. Site Templates: _catalogs/wt/Forms/Common.aspx 
  3. List Templates: _catalogs/lt/Forms/AllItems.aspx 
  4. Web Parts: _catalogs/wp/Forms/AllItems.aspx 
  5. Workflows: _layouts/wrkmng.aspx 
  6. Master Pages and Page Layouts: _catalogs/masterpage/Forms/AllItems.aspx 
  7. Regional Settings: _layouts/regionalsetng.aspx 
  
##Site Administration 

  1. Site Libraries and Lists: _layouts/mcontent.aspx 
  2. Site Usage Report: _layouts/usageDetails.aspx 
  3. User Alerts: _layouts/sitesubs.aspx 
  4. RSS: _layouts/siterss.aspx 
  5. Search Visibility: _layouts/srchvis.aspx 
  6. Sites and Workspaces: _layouts/mngsubwebs.aspx 
  7. Site Features: _layouts/ManageFeatures.aspx 
  8. Delete This Site: _layouts/deleteweb.aspx 
  9. Site Output Cache: _Layouts/areacachesettings.aspx 
  10. Content and Structure: _Layouts/sitemanager.aspx 
  11. Content and Structure Logs: _Layouts/SiteManager.aspx?lro=all 
  12. Search Settings: _layouts/enhancedSearch.aspx 
  
##Site Collection Administration 

  1. Search Scopes: _layouts/viewscopes.aspx?mode=site 
  2. Search Keywords: _layouts/listkeywords.aspx 
  3. Recycle Bin: _layouts/AdminRecycleBin.aspx 
  4. Site Collection Features: _layouts/ManageFeatures.aspx?Scope=Site 
  5. Site Hierarchy: _layouts/vsubwebs.aspx 
  6. Portal Site Connection: _layouts/portal.aspx 
  7. Site Collection Audit Settings: _layouts/AuditSettings.aspx 
  8. Site Collection Policies: _layouts/Policylist.aspx 
  9. Site Collection Cache Profiles: Cache%20Profiles/AllItems.aspx 
  10. Site Collection Output Cache: _Layouts/sitecachesettings.aspx 
  11. Site Collection Object Cache: _Layouts/objectcachesettings.aspx 
  12. Variations: _Layouts/VariationSettings.aspx 
  13. Variation Labels: _Layouts/VariationLabels.aspx 
  14. Translatable Columns: _Layouts/TranslatableSettings.aspx 
  15. Variation Logs: _Layouts/VariationLogs.aspx 
  16. Site Settings: _layouts/settings.aspx 
  
##Function Add to the URL Notes 

  Add Web Parts Pane ?ToolPaneView=2 Add to the end of the page URL; will only
  work if the page is already checked out 
  Create [area]/_layouts/spscreate.aspx   
  Create /_layouts/create.aspx   
  
  Create list in a different portal area /_layouts/new.aspx?
  NewPageFilename=YourTemplateName.stp&
  ListTemplate=100&
  ListBaseType=0 
  
  When you save a template in a portal area and try to create a
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
  
##Quick Launch
https://any.domain/sites/any_site/_layouts/quiklnch.aspx

#Install Additional VS Templates at VS Command Line
  devenv /installvstemplates
  


#Chill Out ----- Concentration Musica

http://www.dancetrippin.tv/
