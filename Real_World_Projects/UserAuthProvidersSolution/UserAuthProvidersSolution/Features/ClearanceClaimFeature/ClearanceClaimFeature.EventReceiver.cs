using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Claims;

namespace UserAuthProvidersSolution.Features.ClearanceClaimFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Microsoft.SharePoint.Security.SharePointPermission
        (System.Security.Permissions.SecurityAction.Demand,
            ObjectModel = true)]

    [Guid("f81ff831-4a89-4f1c-9aaf-a1264fb7004a")]
    public class ClearanceClaimFeatureEventReceiver : SPClaimProviderFeatureReceiver
    {

        #region Overrides
        public override string ClaimProviderAssembly
        {
            get { return typeof(UserAuthProvidersSolution.SecurityClearanceCP).Assembly.FullName; }
        }

        public override string ClaimProviderDescription
        {
            get { return "A claim provider that describes the user's highst currently attained Security " +
                    "Clearance (See directive A3/J-02";}
        }

        public override string ClaimProviderDisplayName
        {
            get { return UserAuthProvidersSolution.SecurityClearanceCP.ProviderDisplayName; }
        }

        public override string ClaimProviderType
        {
            get { return UserAuthProvidersSolution.SecurityClearanceCP.ProviderDisplayName; }
        }

      

        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            ExecBaseFeatureActivated(properties);
        }

        #endregion

        //Helper method to avoid possible failure to resolve lambda expressions in CIL code
        private void ExecBaseFeatureActivated(SPFeatureReceiverProperties properties)
        {
            base.FeatureActivated(properties);
        }

        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


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
    };
}
