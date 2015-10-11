using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

using System.Configuration;

namespace _61528.Features.WebConfigFeature.Layouts
{
    public partial class web_config1 : LayoutsPageBase
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            lblCS.Text = ConfigurationManager.ConnectionStrings["corporateDb"].ConnectionString;
        }
    }
}
