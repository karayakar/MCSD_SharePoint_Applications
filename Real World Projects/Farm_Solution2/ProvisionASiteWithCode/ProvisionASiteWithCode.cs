using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace ProvisionASiteWithCode
{
    public class ProvisionASiteWithCode : SPWebProvisioningProvider
    {
        //Override the Provision method
        public override void Provision(SPWebProvisioningProperties props)
        {
            SPWeb siteDefWeb = props.Web;

            //Can also use the Template names as strings, like
            // STS#0, BLOG#0, but this string enum makes it more readable
            //siteDefWeb, ApplyWebTemplates("STS#0");
            siteDefWeb.ApplyWebTemplate(SPWebTemplate.WebTemplateBLOG);


            string siteConfigData = props.Data;

            SPContentType chemicalType = siteDefWeb.ContentTypes["ChemicalContent"];

            siteDefWeb.ContentTypes.Add(chemicalType);

            // throw new NotImplementedException();
        }
    }
}
