using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Collections.ObjectModel;

namespace _61528.Features.WebConfigFeature.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("1f157184-d589-4a75-9d90-efac50e526cb")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = properties.Feature.Parent as SPWebApplication;

            SPWebConfigModification mod = new SPWebConfigModification();
            mod.Path = "configuration";
            mod.Name = "connectionStrings";
            mod.Sequence = 0;
            mod.Owner = "_61528";//<--------------------------------------- Change ID
            mod.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureSection;

            webApp.WebConfigModifications.Add(mod);

            mod = new SPWebConfigModification();
            mod.Path = "configuration/connectionStrings";
            mod.Name = "add[@name = 'corporateDb']";
            mod.Sequence = 0;
            mod.Value = "<add name ='corporateDb' connectionString='blah' />";
            mod.Owner = "_61528";//<--------------------------------------- Change ID
            mod.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;

            webApp.WebConfigModifications.Add(mod);
            webApp.Update();
            webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();

        }



        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = properties.Feature.Parent as SPWebApplication;
            Collection<SPWebConfigModification> collection = webApp.WebConfigModifications;
            int iStartCount = collection.Count;

            foreach(SPWebConfigModification mod in collection)
            {
                if (mod.Owner == "_61528") //<--------------------------------------- Change ID
                {
                    collection.Remove(mod);
                }
                
            }

            if (iStartCount > collection.Count)
            {
                webApp.Update();
                webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();
            }
            
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
