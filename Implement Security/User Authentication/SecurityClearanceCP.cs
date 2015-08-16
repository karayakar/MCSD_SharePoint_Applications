using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Claims;
using Microsoft.SharePoint.Diagnostics;
using IDModel = Microsoft.IdentityModel;
using Microsoft.IdentityModel.Claims;
using Microsoft.SharePoint.WebControls;

namespace UserAuthProvidersSolution
{
    class SecurityClearanceCP : SPClaimProvider
    {
        public SecurityClearanceCP(string displayName) : base(displayName) { }

        private string[] clearances = { "PublicTrust", "Confidential", "Secret", "TopSecret" };
        private string[] clearanceKeys = { "keyPT", "keyConf", "keySecret", "keyTop" };
        private string[] clearanceLabels = { "Public Trust", "Confidential", "Secret", "Top Secret" };

        //overrides
        //Gets the display name of the claims provider.
        internal static string ProviderDisplayName
        { get { return "Security Clearance Provider"; } }

        internal static string ClearanceClaimType
        { get { return "http://abcuniversity/"; } }

        private static string ProviderInternalName
        { get { return "SecurityClearanceProvider"; } }

        private static string ClearanceClaimValueType
        { get { return IDModel.Claims.ClaimValueTypes.String; } }

        //gets the unique name for the claims provider.
        public override string Name
        { get { throw new NotImplementedException(); } }

        // Supports claims augmentation
        public override bool SupportsEntityInformation
        { get { return true; } }

        // Returns true if you support claims resolution in the People Picker control.
        public override bool SupportsResolve
        { get { return true; } }

        // determines whether the claims provider supports hierarchical display.
        public override bool SupportsHierarchy
        { get { throw new NotImplementedException(); } }

        //determines whether the claims provider supports search operations.
        public override bool SupportsSearch
        { get { throw new NotImplementedException(); } }

        //specifies the set of possible claim value type for claim type that the claims provider supports.
        protected override void FillClaimTypes(List<string> claimTypes)
        {
            if (claimTypes == null) throw new ArgumentException("Cannot have a null set of claims");
            claimTypes.Add(ClearanceClaimType);
        }

        //specifies the set of possible claim value type for claim type that the claims provider supports.
        protected override void FillClaimValueTypes(List<string> claimValueTypes)
        {
            if (claimValueTypes == null) { throw new ArgumentNullException("Cannot have empty set of claimValueTypes"); }

            claimValueTypes.Add(ClearanceClaimValueType);
        }
        //augments custom claims into a claims token.
        protected override void FillClaimsForEntity(Uri context, SPClaim entity, List<SPClaim> claims)
        {
            if (entity == null) { throw new ArgumentNullException("Cannot have empty entity"); }
            if (claims == null) { throw new ArgumentNullException("Cannot have empty claims"); }

            //string assignedClearance = GetClearance(entity); //------> RESOLVE  GetClearance(entity);

            //claims.Add(CreateClaim(ClearanceClaimType, assignedClearance, ClearanceClaimValueType));

        }

        //specifies the set of possible entity types that the claims provider is supporting for display in the People Picker control.
        protected override void FillEntityTypes(List<string> entityTypes)
        {
            entityTypes.Add(SPClaimEntityTypes.FormsRole);
        }

        //provides the People Picker control with the ability to load portions of 
        //the[T:HYPERLINK"ms-help://MS.SPF14SDK.en/SPF14MrefControls/html/a4bf54d0-29e5-e5c2-231e-b1b9f4728a7f.htm
        //"Microsoft.SharePoint.WebControls.SPProviderHierarchyTree] tree from the claims provider and specifies the hierarchy for displaying the picker entities.
        protected override void FillHierarchy(Uri context, string[] entityTypes, string hierarchyNodeID, int numberOfLevels, SPProviderHierarchyTree hierarchy)
        {
            if (!EntityTypesContain(entityTypes, SPClaimEntityTypes.FormsRole))
            {
                return;
            }
            if (hierarchyNodeID == null)
            {
                int numberOfKeys = clearanceKeys.Length;
                for (int i = 0; i < numberOfKeys; i++)
                {
                    hierarchy.AddChild(
                        new Microsoft.SharePoint.WebControls.SPProviderHierarchyNode(
                            SecurityClearanceCP.ProviderInternalName,
                            clearanceLabels[i],
                            clearanceKeys[i],
                            true


                   ));
                }
            }
        }

        //This method attempts to resolve a claim
        protected override void FillResolve(Uri context, string[] entityTypes, SPClaim resolveInput, List<PickerEntity> resolved)
        {
            if (!EntityTypesContain(entityTypes, SPClaimEntityTypes.FormsRole))
            {
                return;
            }
            //Loop through the possible locations
            foreach (string clearance in clearances)
            {
                //Check if the entered claim matches the current list location
                if (clearance.ToLower() == resolveInput.Value.ToLower())
                {
                    //There is a match so create an entity for the location
                    //and add it to the resolved collection
                    //PickerEntity entity = PickerEntityHelper(clearance); // -----> RESOLVE PickerEntityHelper(clearance); 
                    //resolved.Add(entity);
                }
            }
        }
        
        //The schema is used by People Picker control to display the entity data.
        protected override void FillSchema(SPProviderSchema schema)
        {
            throw new NotImplementedException();
        }
        //resolves claims by using the type-in control of the claims picker.
        protected override void FillResolve(Uri context, string[] entityTypes, string resolveInput, List<PickerEntity> resolved)
        {

            throw new NotImplementedException();

        }

        // fills search results in People Picker control window.
        protected override void FillSearch(Uri context, string[] entityTypes, string searchPattern, string hierarchyNodeID, int maxCount, SPProviderHierarchyTree searchTree)
        {
            throw new NotImplementedException();
        }
    }
}
