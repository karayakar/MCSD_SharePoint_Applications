using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

using Microsoft.SharePoint.Administration;

namespace Navigation_Provider.Features.Navigation_Provider
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("0838bd53-7446-48a3-ad46-826f9b084b0e")]
    public class Navigation_ProviderEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.
        const string modName = "add[@Name='TestSiteProvider']";

        //this event receiver will add sitemap to web.config at /inetpub/wwwroot/wss/VirtualDirectories/TARGET WEB APP
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var webapp = properties.Feature.Parent as SPWebApplication;
            SPWebConfigModification modification = new SPWebConfigModification();
            modification.Path = "configuration/system,web/siteMap/providers";
            modification.Name = modName;
            modification.Sequence = 0;
            modification.Owner = "administrator@myDomain.com";
            modification.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;
            modification.Value = "<add name = 'TestSiteProvider' siteMapFile='_layouts/15/Navigation Provider/testSiteMap' type='Microsoft.SharePoint.Navigation.SPXmlContentMapProvider, Micorosoft.SHarePoint, Version=15.0.0.0, Culture=neutral, PublicKeyoken=71e9bce111e9429c' />";//GAC Properties
            webapp.WebConfigModifications.Add(modification);
            webapp.Update();
            webapp.WebService.ApplyWebConfigModifications();

        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWebConfigModification modificationToRemove = null;
            var webapp = properties.Feature.Parent as SPWebApplication;
            var modifications = webapp.WebConfigModifications;
            foreach (var modification in modifications)
            {
                if(modification.Name == modName)
                {
                    modificationToRemove = modification;
                }
            }
            modifications.Remove(modificationToRemove);
            webapp.Update();
            webapp.WebService.ApplyWebConfigModifications();
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
